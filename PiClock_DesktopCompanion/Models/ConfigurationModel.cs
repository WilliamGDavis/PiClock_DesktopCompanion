using PiClock_DesktopCompanion.Classes;
using PiClock_DesktopCompanion.Properties;

namespace PiClock_DesktopCompanion.Models
{
    class ConfigurationModel : BaseClass
    {
        #region Properties and Methods
        private string _apiServerAddress;
        public string ApiServerAddress
        {
            get { return _apiServerAddress; }
            set
            {
                if (_apiServerAddress != value)
                    _apiServerAddress = value;
                RaisePropertyChanged("ApiServerAddress");
                RaisePropertyChanged("UriPrefix");
            }
        }

        private string _apiServerPort;
        public string ApiServerPort
        {
            get { return _apiServerPort; }
            set
            {
                if (_apiServerPort != value)
                    _apiServerPort = value;
                RaisePropertyChanged("ApiServerPort");
                RaisePropertyChanged("UriPrefix");

            }
        }

        private string _apiDirectory;
        public string ApiDirectory
        {
            get { return _apiDirectory; }
            set
            {
                if (_apiDirectory != value)
                    _apiDirectory = value;
                RaisePropertyChanged("ApiDirectory");
                RaisePropertyChanged("UriPrefix");
            }
        }

        private string _apiUsername;
        public string ApiUsername
        {
            get
            { return _apiUsername; }
            set
            {
                if (_apiUsername != value)
                    _apiUsername = value;
                RaisePropertyChanged("ApiUsername");
            }
        }

        private string _apiPassword;
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

        private string _uriPrefix;
        public string UriPrefix
        {
            get { return _uriPrefix; }
            set
            {
                if (_uriPrefix != value)
                    _uriPrefix = value;
                RaisePropertyChanged("UriPrefix");
            }
        }

        private string _useSsl;
        public string UseSsl
        {
            get { return _useSsl; }
            set
            {
                if (_useSsl != value)
                    _useSsl = value;
                RaisePropertyChanged("UseSsl");
                RaisePropertyChanged("UriPrefix");
            }
        }
        #endregion Properties and Methods

        #region Constructors
        public ConfigurationModel()
        {
            ApiServerAddress =
                (Settings.Default.Properties["ApiServerAddress"] != null) ? Settings.Default.ApiServerAddress : null;
            ApiServerPort =
                (Settings.Default.Properties["ApiServerPort"] != null) ? Settings.Default.ApiServerPort : null;
            ApiDirectory =
                (Settings.Default.Properties["ApiDirectory"] != null) ? Settings.Default.ApiDirectory : null;
            ApiUsername =
                (Settings.Default.Properties["ApiUsername"] != null) ? Settings.Default.ApiUsername : null;
            ApiPassword =
                (Settings.Default.Properties["ApiPassword"] != null) ? Settings.Default.ApiPassword : null;
            UriPrefix =
                (Settings.Default.Properties["UriPrefix"] != null) ? Settings.Default.UriPrefix : null;
            UseSsl =
                (Settings.Default.Properties["UseSsl"] != null) ? Settings.Default.UseSsl : null;
        }
        #endregion Constructors

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

        public void SaveSettings()
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
        #endregion Methods
    }
}
