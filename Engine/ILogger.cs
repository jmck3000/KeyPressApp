namespace KeyPressApp.Engine
{
    public interface ILogger
    {
        string LogText { get; set; }
        void WriteLog(string textLine);
        void ClearLog();
    }
}