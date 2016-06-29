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
using System.Windows.Input;

namespace PiClock_DesktopCompanion.ViewModels
{
    class PinLoginViewModel : BaseViewModel
    {
        #region Members
        PinLoginModel _pinLoginModel;
        string _pinError;
        #endregion

        #region Constructors
        public PinLoginViewModel() { }
        #endregion

        #region Properties
        protected PinLoginModel PinModel
        {
            get
            {
                if (_pinLoginModel == null)
                    _pinLoginModel = new PinLoginModel();
                return _pinLoginModel;
            }
            //set
            //{
            //    if (_pinLoginModel == null)
            //        _pinLoginModel = new PinLoginModel();
            //}
        }

        public string Pin
        {
            get { return PinModel.Pin; }
            set
            {
                if (PinModel.Pin != value)
                {
                    PinModel.Pin = value;
                    RaisePropertyChanged("Pin");
                }
            }
        }
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
            Pin += param;
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
                    _updateControl = new RelayCommand(param => UpdateControlExecute(), param => CanUpdateControlExecute());

                return _updateControl;
            }
        }

        void UpdateControlExecute()
        {
            PageSwitcher.Instance.CurrentView = PageSwitcher.Instance.ConfigurationView;
        }

        bool CanUpdateControlExecute()
        {
            return true;
        }
        #endregion - UpdateControl
        #endregion

        #region Methods
        void CheckPin()
        {
            if (Pin.Length == 4)
            {
                if (Pin == "1111")
                {
                    PinError = "Logged In Successfully!";
                    RaisePropertyChanged("PinError");

                }
                else
                {
                    PinError = "Incorrect PIN";
                    RaisePropertyChanged("PinError");
                }
                Pin = null;
            }
        }
        #endregion - Methods
    }
}
