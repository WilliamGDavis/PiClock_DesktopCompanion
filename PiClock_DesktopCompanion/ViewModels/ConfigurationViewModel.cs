using System.ComponentModel;
using PiClock_DesktopCompanion.Properties;
using System.Windows.Input;

namespace PiClock_DesktopCompanion.ViewModels
{
    class ConfigViewModel : INotifyPropertyChanged
    {
        #region Members
        string _apiServerAddress = Settings.Default.ApiServerAddress;
        string _apiServerPort = Settings.Default.ApiServerPort;
        string _apiDirectory = Settings.Default.ApiDirectory;
        string _apiUsername = Settings.Default.ApiUsername;
        string _apiPassword = Settings.Default.ApiPassword;
        string _uriPrefix = Settings.Default.UriPrefix;
        string _useSsl = "s" /*Settings.Default.UseSsl*/; //TODO: Fix this
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
            }
        }
        public string ApiPassword
        {
            get { return _apiPassword; }
            set
            {
                if (_apiPassword != value)
                    _apiPassword = value;
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
                RaisePropertyChanged("UriPrefix");
            }
        }
        #endregion

        #region INotifyPropertyChanged
        #region INPC Members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region INPC Methods
        private void RaisePropertyChanged(string propertyName)
        {
            //Use a handler to prevent threading issues
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #endregion

        #region Commands
        #region Command - UpdateSettings
        RelayCommand _updateSettingsCommand;
        public ICommand UpdateSettings
        {
            get
            {
                if (_updateSettingsCommand == null)
                    _updateSettingsCommand = new RelayCommand(param => UpdateSettingsExecute(), param => CanUpdateSettingsExecute());
                return _updateSettingsCommand;
            }
        }

        void UpdateSettingsExecute()
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
        }

        bool CanUpdateSettingsExecute()
        { return true; }
        #endregion
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
        #endregion
    }
}
