//using PiClock_DesktopCompanion.Helpers;
using PiClock_DesktopCompanion.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PiClock_DesktopCompanion.ViewModels
{
    class PinLoginViewModel : INotifyPropertyChanged
    {
        #region Constructors
        public PinLoginViewModel()
        { _pin = new PinLogin(); }
        #endregion

        #region Members
        PinLogin _pin;
        #endregion

        #region Properties
        public PinLogin Pin
        {
            get { return _pin; }
            set { _pin = value; }
        }
        public string PinNumber
        {
            get { return Pin.Pin; }
            set
            {
                if (Pin.Pin != value)
                {
                    Pin.Pin = value;
                    RaisePropertyChanged("PinNumber");
                }
            }
        }
        public string PinError { get; set; }
        #endregion

        #region INPC Members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region INCP Methods
        private void RaisePropertyChanged(string propertyName)
        {
            //Use a handler to prevent threading issues
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Commands
        RelayCommand _updatePinLoginCommand;
        public ICommand UpdatePinLogin
        {
            get
            {
                if (_updatePinLoginCommand == null)
                    _updatePinLoginCommand = new RelayCommand(param => UpdatePinLoginExecute(param), param => CanUpdatePinLoginExecute()); //Pass the "CommandParameter" from the XAML view

                return _updatePinLoginCommand;
            }
        }

        void UpdatePinLoginExecute(object param)
        {
            PinNumber += param;
            CheckPin();
        }

        bool CanUpdatePinLoginExecute()
        { return true; }

        void CheckPin()
        {
            if (PinNumber.Length == 4)
            {
                if (PinNumber == "1111")
                {
                    PinError = "Logged In Successfully!";
                    RaisePropertyChanged("PinError");
                }
                else
                {
                    PinError = "Incorrect PIN";
                    RaisePropertyChanged("PinError");
                }
                PinNumber = null;
            }
        }
        #endregion
    }
}
