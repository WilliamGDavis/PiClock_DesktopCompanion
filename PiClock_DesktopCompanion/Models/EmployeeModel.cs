using System.Collections.Generic;
using System.ComponentModel;

namespace PiClock_DesktopCompanion.Models
{
    class EmployeeModel : INotifyPropertyChanged
    {
        private string _id;
        public string Id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                    _id = value;
                RaisePropertyChanged("Id");
            }
        }

        private string _fname;
        public string Fname
        {
            get { return _fname; }
            set
            {
                if (_fname != value)
                    _fname = value;
                RaisePropertyChanged("Fname");
            }
        }

        private string _mname;
        public string Mname
        {
            get { return _mname; }
            set
            {
                if (_mname != value)
                    _mname = value;
                RaisePropertyChanged("Mname");
            }
        }

        private string _lname;
        public string Lname
        {
            get { return _lname; }
            set
            {
                if (_lname != value)
                    _lname = value;
                RaisePropertyChanged("Lname");
            }
        }

        private string _active;
        public string Active
        {
            get { return _active; }
            set
            {
                if (_active != value)
                    _active = value;
                RaisePropertyChanged("Active");
            }
        }

        private JobModelUpdated _currentJob;
        public JobModelUpdated CurrentJob
        {
            get { return _currentJob; }
            set
            {
                if (_currentJob != value)
                    _currentJob = value;
                RaisePropertyChanged("CurrentJob");
                RaisePropertyChanged("EmployeeModel");
            }
        }

        private List<JobModelUpdated> _jobList;
        public List<JobModelUpdated> JobList
        {
            get { return _jobList; }
            set
            {
                if (_jobList != value)
                    _jobList = value;
                RaisePropertyChanged("JobList");
            }
        }

        #region INotifyPropertyChanged
        #region INPC Members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion INPC Members

        #region INCP Methods
        public void RaisePropertyChanged(string propertyName)
        {
            //Use a handler to prevent threading issues
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion INPC Methods
        #endregion INotifyPropertyChanged
    }
}
