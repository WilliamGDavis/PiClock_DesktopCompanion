using PiClock_DesktopCompanion.Classes;
using PiClock_DesktopCompanion.Helpers;
using PiClock_DesktopCompanion.Models;
using PiClock_DesktopCompanion.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Net.Http;
using System.Windows.Input;

namespace PiClock_DesktopCompanion.ViewModels
{
    class PinLoginViewModel : BaseViewModel
    {
        #region Constructors
        public PinLoginViewModel() { }
        #endregion

        #region Properties
        private PinLoginModel _pinLoginModel;
        private PinLoginModel PinLoginModel
        {
            get
            {
                if (_pinLoginModel == null)
                    _pinLoginModel = new PinLoginModel();
                return _pinLoginModel;
            }
        }

        public string Pin
        {
            get { return PinLoginModel.Pin; }
            set
            {
                if (PinLoginModel.Pin != value)
                {
                    PinLoginModel.Pin = value;
                    RaisePropertyChanged("Pin");
                }
            }
        }

        private string _pinError;
        public string PinError
        {
            get { return _pinError; }
            set
            {
                if (_pinError != value)
                    _pinError = value;
                RaisePropertyChanged("PinError");
            }
        }
        #endregion

        #region Commands
        #region Commands - UpdatePinLogin
        RelayCommand _updatePinLoginCommand;
        public ICommand UpdatePinLogin
        {
            get
            {
                if (_updatePinLoginCommand == null)
                    _updatePinLoginCommand = new RelayCommand(param => UpdatePinLoginExecute(param), param => CanUpdatePinLoginExecute()); //Pass the "CommandParameter" from the XAML view

                return _updatePinLoginCommand;
            }
        }

        void UpdatePinLoginExecute(object param)
        {
            Pin += param.ToString();
            CheckPin();
        }

        bool CanUpdatePinLoginExecute()
        { return true; }
        #endregion - UpdatePinLogin
        #region Commands - UpdateControl
        RelayCommand _updateControl;
        public ICommand UpdateControl
        {
            get
            {
                if (_updateControl == null)
                    _updateControl = new RelayCommand(param => UpdateControlExecute(param), param => CanUpdateControlExecute());

                return _updateControl;
            }
        }

        void UpdateControlExecute(object param)
        {
            PageSwitcher.Instance.ChangeView(param);
        }

        bool CanUpdateControlExecute()
        {
            return true;
        }
        #endregion - UpdateControl
        #endregion

        #region Methods
        async void CheckPin()
        {
            //TODO: Check to see if a user is currently "parked" on another time clock (Basically, logged into more than one clock at a time)
            if (Pin.Length == 4) //Hardcoded - Needs to be changed (returned from a db)
            {
                MasterModel.EmployeeModel = await Authentication.TryLogin(Pin);

                if (MasterModel.EmployeeModel.Id == null)
                {
                    PinError = "Incorrect PIN";
                    Pin = null;
                    return;
                }

                Pin = null;

                //Check to see if an employee is punched in
                if (true == await CheckIfLoggedIn())
                {
                    MasterModel.EmployeeModel.CurrentJob = await GetCurrentJob();
                    PageSwitcher.Instance.ChangeView("EmployeePageView");
                }
                else
                {
                    PageSwitcher.Instance.ChangeView("NotPunchedInView");
                }
            }
            PinError = null;
        }

        async Task<bool> CheckIfLoggedIn()
        {
            var paramDictionary = new Dictionary<string, string>()
            {
                { "action", "CheckLoginStatus" },
                { "employeeId", MasterModel.EmployeeModel.Id }
            };
            var httpResponse = await CommonMethods.GetHttpResponseFromRpcServer(paramDictionary);
            var httpContent = await httpResponse.Content.ReadAsStringAsync();
            var isLoggedIn = (string)CommonMethods.Deserialize(typeof(string), httpContent);
            return (isLoggedIn == "true") ? true : false;
        }

        async Task<JobModelUpdated> GetCurrentJob()
        {
            var paramDictionary = new Dictionary<string, string>()
            {
                { "action", "GetCurrentJob" },
                { "employeeId", MasterModel.EmployeeModel.Id }
            };
            var httpResponse = await CommonMethods.GetHttpResponseFromRpcServer(paramDictionary);
            var httpContent = await httpResponse.Content.ReadAsStringAsync();
            return (JobModelUpdated)CommonMethods.Deserialize(typeof(JobModelUpdated), httpContent) ?? null;
        }
    }
    #endregion - Methods
}
