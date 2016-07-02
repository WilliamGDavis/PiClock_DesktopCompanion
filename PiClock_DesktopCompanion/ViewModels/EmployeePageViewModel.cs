using PiClock_DesktopCompanion.Models;
using PiClock_DesktopCompanion.Helpers;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;
using PiClock_DesktopCompanion.Classes;

namespace PiClock_DesktopCompanion.ViewModels
{
    class EmployeePageViewModel : BaseViewModel
    {
        private string _newJobNumber;
        public string NewJobNumber
        {
            get { return _newJobNumber; }
            set
            {
                if (_newJobNumber != value)
                {
                    _newJobNumber = value;
                    RaisePropertyChanged("NewJobNumber");
                }
            }
        }

        private string _newJobNumberError;
        public string NewJobNumberError
        {
            get { return _newJobNumberError; }
            set
            {
                if (_newJobNumberError != value)
                {
                    _newJobNumberError = value;
                    RaisePropertyChanged("NewJobNumberError");
                }
            }
        }
                
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
            MasterModel.EmployeeModel = null;
            NewJobNumber = null;
            NewJobNumberError = null;
            PageSwitcher.Instance.ChangeView(param);
        }

        bool CanUpdateControlExecute()
        {
            return true;
        }
        #endregion - UpdateControl

        #region Commands - UpdateNewJobNumber
        RelayCommand _updateNewJobNumber;
        public ICommand UpdateNewJobNumber
        {
            get
            {
                if (_updateNewJobNumber == null)
                    _updateNewJobNumber = new RelayCommand(param => UpdateNewJobNumberExecute(param), param => CanUpdateNewJobNumberExecute());

                return _updateNewJobNumber;
            }
        }

        void UpdateNewJobNumberExecute(object param)
        {
            NewJobNumberError = null;
            NewJobNumber += param;
        }

        bool CanUpdateNewJobNumberExecute()
        {
            return true;
        }
        #endregion - UpdateNewJobNumber

        #region Commands - ChangeJob
        RelayCommand _changeJob;
        public ICommand ChangeJob
        {
            get
            {
                if (_changeJob == null)
                    _changeJob = new RelayCommand(param => ChangeJobExecute(param), param => CanChangeJobExecute());

                return _changeJob;
            }
        }

        async void ChangeJobExecute(object param)
        {
            //TODO: check for null value
            string oldJob = (MasterModel.EmployeeModel.CurrentJob == null) ? null : MasterModel.EmployeeModel.CurrentJob.Description;

            if (NewJobNumber == oldJob)
            {
                NewJobNumberError = "You are already punched into this job";
                return;
            }

            if (NewJobNumber == null)
            {
                NewJobNumberError = "Please punch in a job number to continue";
                return;
            }

            string newJobId = await JobLookup();

            if (newJobId == "")
            {
                NewJobNumberError = "Invalid Job Number";
                NewJobNumber = null;
                return;
            }

            await PunchIntoJob(newJobId);

            MasterModel.EmployeeModel = null;
            NewJobNumber = null;
            NewJobNumberError = null;
            PageSwitcher.Instance.ChangeView(param);
        }

        bool CanChangeJobExecute()
        {
            return true;
        }
        #endregion - ChangeJob

        #region Commands - ClearNewJobNumber
        RelayCommand _clearNewJobNumber;
        public ICommand ClearNewJobNumber
        {
            get
            {
                if (_clearNewJobNumber == null)
                    _clearNewJobNumber = new RelayCommand(param => ClearNewJobNumberExecute(), param => CanNewJobNumberExecute());

                return _clearNewJobNumber;
            }
        }

        void ClearNewJobNumberExecute()
        {
            NewJobNumber = null;
        }

        bool CanNewJobNumberExecute()
        {
            return true;
        }
        #endregion - ClearNewJobNumber

        #region Methods
        public async Task<string> JobLookup()
        {
            var paramDictionary = new Dictionary<string, string>()
            {
                {"action", "GetJobIdByJobDescription" },
                {"jobDescription", NewJobNumber }
            };
            var httpResponse = await CommonMethods.GetHttpResponseFromRpcServer(paramDictionary);
            var httpContent = await httpResponse.Content.ReadAsStringAsync();

            return (string)CommonMethods.Deserialize(typeof(string), httpContent);
        }

        public async Task PunchIntoJob(string newJobId)
        {
            string currentJobId = (null != MasterModel.EmployeeModel.CurrentJob) ? MasterModel.EmployeeModel.CurrentJob.Id.ToString() : "null";
            var paramDictionary = new Dictionary<string, string>()
            {
                { "action", "PunchIntoJob" },
                { "employeeId", MasterModel.EmployeeModel.Id },
                { "currentJobId",  currentJobId },
                { "newJobId", newJobId }
            };
            await CommonMethods.GetHttpResponseFromRpcServer(paramDictionary);
        }
        #endregion
    }
}
