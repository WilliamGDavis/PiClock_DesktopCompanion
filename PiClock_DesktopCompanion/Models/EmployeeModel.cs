using PiClock_DesktopCompanion.Classes;
using System.Collections.Generic;

namespace PiClock_DesktopCompanion.Models
{
    class EmployeeModel : BaseClass
    {
        #region Properties and Members
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

        private JobModel _currentJob;
        public JobModel CurrentJob
        {
            get { return _currentJob; }
            set
            {
                if (_currentJob != value)
                    _currentJob = value;
                RaisePropertyChanged("CurrentJob");
            }
        }

        private List<JobModel> _jobList;
        public List<JobModel> JobList
        {
            get { return _jobList; }
            set
            {
                if (_jobList != value)
                    _jobList = value;
                RaisePropertyChanged("JobList");
            }
        }
        #endregion Properties and Members
    }
}
