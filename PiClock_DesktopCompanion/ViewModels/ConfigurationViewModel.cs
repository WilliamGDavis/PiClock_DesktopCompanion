using System.Windows.Input;
using PiClock_DesktopCompanion.Helpers;

namespace PiClock_DesktopCompanion.ViewModels
{
    class ConfigurationViewModel : BaseViewModel
    {
        #region ICommand
        #region ICommand {UpdateSettings}
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
            MasterModel.ConfigurationModel.SaveSettings();
            PageSwitcher.Instance.ChangeView(param);
        }

        bool CanUpdateSettingsExecute()
        { return true; }
        #endregion ICommand {UpdateSettings}

        #region ICommand {UpdateControl}
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
        { PageSwitcher.Instance.ChangeView(param); }

        bool CanUpdateControlExecute()
        { return true; }
        #endregion ICommand {UpdateControl}
        #endregion ICommand
    }
}
