using PiClock_DesktopCompanion.Classes;

namespace PiClock_DesktopCompanion.Models
{
    class JobModel : BaseClass
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

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                    _description = value;
                RaisePropertyChanged("Description");
            }
        }

        private string _code;
        public string Code
        {
            get { return _code; }
            set
            {
                if (_code != value)
                    _code = value;
                RaisePropertyChanged("Code");
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
        #endregion Properties and Members
    }
}
