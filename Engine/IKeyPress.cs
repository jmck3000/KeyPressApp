using System.Diagnostics;
using KeyPressApp.Model;

namespace KeyPressApp.Engine
{
    public interface IKeyPress
    {
        void StartKeyPress(Settings settings, Process process);
        void StopKeyPress();
    }
}