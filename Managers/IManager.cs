using KeyPressApp.Model;

namespace KeyPressApp.Managers
{
    public interface IManager
    {
        void ClearLog();
        string GetLog();
        bool IsAppRunning(string appName);
        void Log(string textLine);
        void Start(Settings settings);
        void Stop();
    }
}