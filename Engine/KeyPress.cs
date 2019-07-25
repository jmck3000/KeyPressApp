using KeyPressApp.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyPressApp.Engine
{
    public class KeyPress : IKeyPress
    {
        private bool _isStartPressing = false;
        private Settings _settings;
        private Process _process;


        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr handle);
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern bool ShowWindow(IntPtr handle, int nCmdShow);
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern bool IsIconic(IntPtr handle);
        const int SW_RESTORE = 9;

        public void StartKeyPress(Settings settings, Process process)
        {
            _process = process;
            _settings = settings;
            _isStartPressing = true;
            Task.Factory.StartNew((Action)(() => PressKey()));

        }

        private void PressKey()
        {
            int numberOfTimes = _settings.NumberOfTimes;

            while (_isStartPressing)
            {
                if (numberOfTimes <= 1)
                {
                    _isStartPressing = false;
                }

                if (_process != null)
                {
                    //Bring app to the front;
                    SetForegroundWindow(_process.MainWindowHandle);
                    if (IsIconic(_process.MainWindowHandle))
                    {
                        ShowWindow(_process.MainWindowHandle, SW_RESTORE);
                    }

                    //Send kep press to app.
                    SendKeys.SendWait(_settings.KeyToPress);
                    Thread.Sleep(_settings.SecoundsPerPress * 1000);
                }

                --numberOfTimes;
            }
        }

        public void StopKeyPress()
        {
            _isStartPressing = false;
        }



    }
}
