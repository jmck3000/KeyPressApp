using KeyPressApp.Engine;
using KeyPressApp.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyPressApp.Managers
{
    public class Manager : IManager
    {
        private IKeyPress _keyPress;
        private ILogger _logger;
        private Process _process;

        public Manager(IKeyPress keyPress, ILogger logger)
        {
            _keyPress = keyPress;
            _logger = logger;
        }


        public void Start(Settings settings)
        {

            Log($"Starting to press({settings.KeyToPress}).");
            _keyPress.StartKeyPress(settings, _process);
        }

        public void Stop()
        {
            _keyPress.StopKeyPress();
            Log($"Stoping KeyPress.");
        }


        public bool IsAppRunning(string appName)
        {
            var isAppRunning = false;

            Process process = ((IEnumerable<Process>)Process.GetProcessesByName(appName)).FirstOrDefault<Process>();
            if (process != null)
            {
                this._process = process;
                isAppRunning = true;
                Log($"Found app ({appName}) running. ");
            }
            else
            {
                Log($"Could not find app ({appName}) running. ");
            }

            return isAppRunning;
        }

        public void Log(string textLine)
        {
            _logger.WriteLog(textLine);
        }

        public string GetLog()
        {
            return _logger.LogText;
        }

        public void ClearLog()
        {
            _logger.ClearLog();
        }

    }
}
