using System.ComponentModel;

namespace PiClock_DesktopCompanion.Models
{
    class JobModel
    {
        public string id { get; set; }
        public string description { get; set; }
        public string code { get; set; }
        public string active { get; set; }
    }

    class JobModelUpdated : INotifyPropertyChanged
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
