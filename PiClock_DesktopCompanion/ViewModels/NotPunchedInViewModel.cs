using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PiClock_DesktopCompanion.Helpers;

namespace PiClock_DesktopCompanion.ViewModels
{
    class NotPunchedInViewModel : BaseViewModel
    {
        #region ICommand
        #region ICommand {GoBack}
        RelayCommand _goback;
        public ICommand GoBack
        {
            get
            {
                if (_goback == null)
                    _goback = new RelayCommand(param => GoBackExecute(param), param => CanGoBackExecute());
                return _goback;
            }
        }

        void GoBackExecute(object param)
        { PageSwitcher.Instance.ChangeView(param); }

        bool CanGoBackExecute()
        { return true; }
        #endregion ICommand {GoBack}
        #endregion ICommand
    }
}
