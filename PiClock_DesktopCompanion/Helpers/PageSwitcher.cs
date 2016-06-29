using PiClock_DesktopCompanion.ViewModels;
using PiClock_DesktopCompanion.Views;
using System.Windows.Controls;

namespace PiClock_DesktopCompanion.Helpers
{
    class PageSwitcher : BaseViewModel
    {
        #region Singleton
        private static PageSwitcher _instance;
        private PageSwitcher() { }
        public static PageSwitcher Instance
        {
            get { return _instance ?? (_instance = new PageSwitcher()); }
        }
        #endregion

        UserControl _currentView;
        UserControl _pinLoginView;
        UserControl _configurationView;
        
        public UserControl CurrentView
        {
            get
            {
                if (_currentView == null)
                    _currentView = PinLoginView;
                return _currentView;
            }
            set
            {
                if (_currentView != value)
                    _currentView = value;
                RaisePropertyChanged("CurrentView");
            }
        }

        public UserControl PinLoginView
        {
            get
            {
                if (_pinLoginView == null)
                    _pinLoginView = new PinLoginView();
                return _pinLoginView;
            }
        }

        public UserControl ConfigurationView
        {
            get
            {
                if (_configurationView == null)
                    _configurationView = new ConfigurationView();
                return _configurationView;
            }
        }

        
    }
}
