using PiClock_DesktopCompanion.Classes;

namespace PiClock_DesktopCompanion.Models
{
    class PinLoginModel : BaseClass
    {
        #region Properties and Members
        private string _pin;
        public string Pin
        {
            get { return _pin; }
            set
            {
                if (_pin != value)
                    _pin = value;
                RaisePropertyChanged("Pin");
            }
        }
        #endregion Properties and Members
    }
}
