using KeyPressApp.Model;
using KeyPressApp.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using KeyPressApp.Engine;
using GalaSoft.MvvmLight.Command;

namespace KeyPressApp.ViewModel
{
    sealed class KeyPressViewModel : INotifyPropertyChanged
    {

      
        private IKeyPress _keyPress;
        private ILogger _logger;
        private IManager _manager;
        private Settings _settings;
        private string _logInfo;
        private string _stateDisplay;

        public KeyPressViewModel(IManager manager, IKeyPress keyPress, ILogger logger)
        {
            this.CloseWindowCommand = new RelayCommand<IClosable>(this.CloseWindow);

            _keyPress = keyPress;
            _logger = logger;
            _manager = manager;

            _settings = new Settings
            {
                AppName = "Notepad",
                KeyToPress = "a",
                SecoundsPerPress = 1,
                NumberOfTimes = 15,
            };
        }

        #region Methods 

        private void Start()
        {
            if (_manager.IsAppRunning(_settings.AppName))
            {
                _manager.Start(_settings);
            }

            LogInfo = _manager.GetLog();
            StateDisplay = "Running";
        }

        private void Stop()
        {
            _manager.Stop();
            LogInfo = _manager.GetLog();
            StateDisplay = "Stoped";
        }

        private void ClearLog()
        {
            _manager.ClearLog();
            LogInfo = _manager.GetLog();
        }

        private void CloseWindow(IClosable window)
        {
            if (window != null)
                window.Close();
        }

        #endregion

        #region Properties

        public string AppName
        {
            get
            {
                return _settings.AppName;
            }
            set
            {
                if (_settings.AppName != value)
                {
                    _settings.AppName = value;
                    OnPropertyChange("AppName");
                }
            }
        }


        public string KeyToPress
        {
            get
            {
                return _settings.KeyToPress;
            }
            set
            {
                if (_settings.KeyToPress != value)
                {
                    _settings.KeyToPress = value;
                    OnPropertyChange("KeyToPress");
                }
            }
        }

        public int SecoundsPerPress
        {
            get
            {
                return _settings.SecoundsPerPress;
            }
            set
            {
                if (_settings.SecoundsPerPress != value)
                {
                    _settings.SecoundsPerPress = value;
                    OnPropertyChange("SecoundsPerPress");
                }
            }
        }

        public int NumberOfTimes
        {
            get
            {
                return _settings.NumberOfTimes;
            }
            set
            {
                if (_settings.NumberOfTimes != value)
                {
                    _settings.NumberOfTimes = value;
                    OnPropertyChange("NumberOfTimes");
                }
            }
        }

        public string LogInfo
        {
            get
            {
                return _logInfo;
            }
            set
            {
                if (_logInfo != value)
                {
                    _logInfo = value;
                    OnPropertyChange("LogInfo");
                }
            }
        }

        public string StateDisplay
        {
            get
            {
                return _stateDisplay;
            }
            set
            {
                if (_stateDisplay != value)
                {
                    _stateDisplay = value;
                    OnPropertyChange("StateDisplay");
                }
            }
        }

        #endregion

        #region RelayCommands


        //Start
        private ICommand _startCommand;

        public ICommand StartCommand
        {
            get
            {
                if (_startCommand == null)
                {
                    _startCommand = new RelayCommand(
                        param => this.Start(),
                        param => this.CanRun()
                        );
                }
                return _startCommand;
            }
        }
 

        //Stop
        private ICommand _stopCommand;

        public ICommand StopCommand
        {
            get
            {
                if (_stopCommand == null)
                {
                    _stopCommand = new RelayCommand(
                        param => this.Stop(),
                        param => this.CanRun()
                        );
                }
                return _stopCommand;
            }
        }


        //CLearLog
        private ICommand _clearLogCommand;

        public ICommand ClearLogCommand
        {
            get
            {
                if (_clearLogCommand == null)
                {
                    _clearLogCommand = new RelayCommand(
                        param => this.ClearLog(),
                        param => this.CanRun()
                        );
                }
                return _clearLogCommand;
            }
        }


        //Close
        public RelayCommand<IClosable> CloseWindowCommand { get; private set; }

   
        private bool CanRun()
        {
            // Verify command can be executed here
            return true;
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
  
}
