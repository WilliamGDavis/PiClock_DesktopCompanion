using PiClock_DesktopCompanion.ViewModels;
using PiClock_DesktopCompanion.Views;
using System.Collections.Generic;
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

        #region Properties and Methods
        private Dictionary<string, UserControl> _views;
        private Dictionary<string, UserControl> Views
        {
            get
            {
                if (_views == null)
                    _views = new Dictionary<string, UserControl>()
                    {
                        { "PinLoginView", Instance.PinLoginView },
                        { "ConfigurationView", Instance.ConfigurationView },
                        { "EmployeePageView", Instance.EmployeePageView },
                        { "NotPunchedInView", Instance.NotPunchedInView }
                    };
                return _views;
            }
        }

        private UserControl _currentView;
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

        private UserControl _pinLoginView;
        private UserControl PinLoginView
        {
            get
            {
                if (_pinLoginView == null)
                    _pinLoginView = new PinLoginView();
                return _pinLoginView;
            }
        }

        private UserControl _configurationView;
        private UserControl ConfigurationView
        {
            get
            {
                if (_configurationView == null)
                    _configurationView = new ConfigurationView();
                return _configurationView;
            }
        }

        private UserControl _employeePageView;
        public UserControl EmployeePageView
        {
            get
            {
                if (_employeePageView == null)
                    _employeePageView = new EmployeePageView();
                return _employeePageView;
            }
        }

        private UserControl _notPunchedInView;
        public UserControl NotPunchedInView
        {
            get
            {
                if (_notPunchedInView == null)
                    _notPunchedInView = new NotPunchedInView();
                return _notPunchedInView;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Change the View, typically done from the ViewModel page (using an ICommand)
        /// </summary>
        /// <param name="requestedView">Passed in by the RelayCommand</param>
        public void ChangeView(object requestedView)
        {
            string newView = requestedView.ToString();

            //Throw an error if the View is not in the Views dictionary
            if (!Views.ContainsKey(newView))
                throw new KeyNotFoundException(string.Format("{0} is not a valid View", newView));

            //Update the CurrentView
            CurrentView = Views[newView];
        }
        #endregion Methods

    }
}
