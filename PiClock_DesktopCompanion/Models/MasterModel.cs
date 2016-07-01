using PiClock_DesktopCompanion.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiClock_DesktopCompanion.Models
{
    class MasterModel : BaseViewModel
    {
        #region Singleton
        private static volatile MasterModel _instance;
        private static object syncRoot = new object();
        private MasterModel() { }
        public static MasterModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncRoot)
                    {
                        if (_instance == null)
                            _instance = new MasterModel();
                    }
                }
                return _instance;
            }
        }
        #endregion Singleton

        private EmployeeModel _employeeModel;
        public EmployeeModel EmployeeModel
        {
            get
            {
                if (_employeeModel == null)
                    _employeeModel = new EmployeeModel();
                return _employeeModel;
            }
            set
            {
                if (_employeeModel != value)
                {
                    _employeeModel = value;
                    RaisePropertyChanged("EmployeeModel");
                }
            }
        }
        
    }
}
