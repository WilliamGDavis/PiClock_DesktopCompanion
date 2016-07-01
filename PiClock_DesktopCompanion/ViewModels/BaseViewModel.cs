using PiClock_DesktopCompanion.Helpers;
using PiClock_DesktopCompanion.Models;
using System.ComponentModel;

namespace PiClock_DesktopCompanion.ViewModels
{
    abstract class BaseViewModel : INotifyPropertyChanged
    {

        public PageSwitcher PageSwitcher
        {
            get { return PageSwitcher.Instance; }
        }

        public MasterModel MasterModel
        {
            get { return MasterModel.Instance; }
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
