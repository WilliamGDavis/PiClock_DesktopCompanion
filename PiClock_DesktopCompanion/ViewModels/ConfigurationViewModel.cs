using System.ComponentModel;
using PiClock_DesktopCompanion.Properties;
using System.Windows.Input;
using PiClock_DesktopCompanion.Helpers;

namespace PiClock_DesktopCompanion.ViewModels
{
    class ConfigurationViewModel : BaseViewModel
    {
        #region Members
        string _apiServerAddress = Settings.Default.ApiServerAddress;
        string _apiServerPort = Settings.Default.ApiServerPort;
        string _apiDirectory = Settings.Default.ApiDirectory;
        string _apiUsername = Settings.Default.ApiUsername;
        string _apiPassword = Settings.Default.ApiPassword;
        string _uriPrefix = Settings.Default.UriPrefix;
        string _useSsl = Settings.Default.UseSsl;
        #endregion

        #region Properties
        public string ApiServerAddress
        {
            get { return _apiServerAddress; }
            set
            {
                if (_apiServerAddress != value)
                    _apiServerAddress = value;
                RaisePropertyChanged("ApiServerAddress");
            }
        }
        public string ApiServerPort
        {
            get { return _apiServerPort; }
            set
            {
                if (_apiServerPort != value)
                    _apiServerPort = value;
                RaisePropertyChanged("ApiServerPort");

            }
        }
        public string ApiDirectory
        {
            get { return _apiDirectory; }
            set
            {
                if (_apiDirectory != value)
                    _apiDirectory = value;
                RaisePropertyChanged("ApiDirectory");
            }
        }
        public string ApiUsername
        {
            get { return _apiUsername; }
            set
            {
                if (_apiUsername != value)
                    _apiUsername = value;
                RaisePropertyChanged("ApiUsername");
            }
        }
        public string ApiPassword
        {
            get { return _apiPassword; }
            set
            {
                if (_apiPassword != value)
                    _apiPassword = value;
                RaisePropertyChanged("ApiPassword");
            }
        }
        public string UriPrefix
        {
            get
            {
                return (_uriPrefix != "" && _uriPrefix == FormatUriPrefix()) ?
                    _uriPrefix : FormatUriPrefix();
            }
        }
        public string UseSsl
        {
            get { return _useSsl; }
            set
            {
                if (_useSsl != value)
                    _useSsl = value;
                RaisePropertyChanged("UseSsl");
            }
        }
        #endregion

        #region Commands
        #region Command - UpdateSettings
        RelayCommand _updateSettingsCommand;
        public ICommand UpdateSettings
        {
            get
            {
                if (_updateSettingsCommand == null)
                    _updateSettingsCommand = new RelayCommand(param => UpdateSettingsExecute(param), param => CanUpdateSettingsExecute());
                return _updateSettingsCommand;
            }
        }

        void UpdateSettingsExecute(object param)
        {
            Settings.Default.ApiServerAddress = ApiServerAddress;
            Settings.Default.ApiServerPort = ApiServerPort;
            Settings.Default.ApiDirectory = ApiDirectory;
            Settings.Default.ApiUsername = ApiUsername;
            Settings.Default.ApiPassword = ApiPassword;
            Settings.Default.UriPrefix = UriPrefix;
            Settings.Default.UseSsl = UseSsl;
            Settings.Default.Save();
            Settings.Default.Reload();
            PageSwitcher.Instance.ChangeView(param);
        }

        bool CanUpdateSettingsExecute()
        { return true; }
        #endregion
        #region Command - UpdateControl
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
            PageSwitcher.Instance.ChangeView(param);
        }

        bool CanUpdateControlExecute()
        {
            return true;
        }
        #endregion - UpdateControl
        #endregion

        #region Methods
        string FormatUriPrefix()
        {
            return string.Format("http{0}://{1}:{2}/{3}",
                                    UseSsl,
                                    ApiServerAddress,
                                    ApiServerPort,
                                    ApiDirectory);
        }
        public bool CheckboxIsChecked
        {
            get
            { return (UseSsl == "s") ? true : false; }
            set
            {
                UseSsl = (value == true) ? "s" : "";
                RaisePropertyChanged("CheckboxIsChecked");
            }
        }
        #endregion
    }
}
