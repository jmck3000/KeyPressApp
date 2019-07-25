namespace KeyPressApp.Engine
{
    public interface ILogger
    {
        string LogText { get; set; }

        string WriteLog(string textLine);

        void ClearLog();
    }
}