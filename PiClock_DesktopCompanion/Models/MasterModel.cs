using PiClock_DesktopCompanion.Classes;

namespace PiClock_DesktopCompanion.Models
{
    class MasterModel : BaseClass
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

        #region Properties and Members
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

        private ConfigurationModel _configurationModel;
        public ConfigurationModel ConfigurationModel
        {
            get
            {
                if (_configurationModel == null)
                    _configurationModel = new ConfigurationModel();
                return _configurationModel;
            }
            set
            {
                if (_configurationModel != value)
                {
                    _configurationModel = value;
                    RaisePropertyChanged("ConfigurationModel");
                }
            }
        }
        #endregion Properties and Members

    }
}
