using PiClock_DesktopCompanion.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PiClock_DesktopCompanion.Properties;
using System.Windows.Input;

namespace PiClock_DesktopCompanion.ViewModels
{
    class ConfigViewModel
    {
        #region Constructors
        public ConfigViewModel()
        { }
        #endregion

        #region Members
        //Configuration _configuration;
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
            }
        }
        public string ApiServerPort
        {
            get { return _apiServerPort; }
            set
            {
                if (_apiServerPort != value)
                    _apiServerPort = value;
            }
        }
        public string ApiDirectory
        {
            get { return _apiDirectory; }
            set
            {
                if (_apiDirectory != value)
                    _apiDirectory = value;
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
            get { return _uriPrefix; }
            set
            {
                if (_uriPrefix != value)
                    _uriPrefix = value;
            }
        }
        public string UseSsl
        {
            get { return _useSsl; }
            set
            {
                if (_useSsl != value)
                    _useSsl = value;
            }
        }
        #endregion

        #region Commands
        #region UpdateSettings
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
            Settings.Default.ApiServerAddress = _apiServerAddress;
            Settings.Default.ApiServerPort = _apiServerPort;
            Settings.Default.ApiDirectory = _apiDirectory;
            Settings.Default.ApiUsername = _apiUsername;
            Settings.Default.ApiPassword = _apiPassword;
            Settings.Default.UriPrefix = _uriPrefix;
            Settings.Default.UseSsl = _useSsl;
            Settings.Default.Save();
            Settings.Default.Reload();
        }

        bool CanUpdateSettingsExecute()
        { return true; }
        #endregion
        #endregion
    }
}
