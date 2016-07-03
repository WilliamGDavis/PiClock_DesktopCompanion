using System.ComponentModel;

namespace PiClock_DesktopCompanion.Classes
{
    class BaseClass : INotifyPropertyChanged
    {
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
