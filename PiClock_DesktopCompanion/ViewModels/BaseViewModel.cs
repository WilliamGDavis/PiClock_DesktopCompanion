using PiClock_DesktopCompanion.Classes;
using PiClock_DesktopCompanion.Helpers;
using PiClock_DesktopCompanion.Models;

namespace PiClock_DesktopCompanion.ViewModels
{
    abstract class BaseViewModel : BaseClass
    {
        #region Properties and Members
        public PageSwitcher PageSwitcher
        {
            get { return PageSwitcher.Instance; }
        }

        public MasterModel MasterModel
        {
            get { return MasterModel.Instance; }
        }
        #endregion Properties and Members
    }
}
