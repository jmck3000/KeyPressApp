using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyPressApp.Engine
{
    public class Logger : ILogger
    {
        public string LogText { get; set; }

        public Logger()
        {
            LogText = "";
        }

        public string WriteLog(string textLine)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(LogText);
            stringBuilder.Append("\r\n");
            stringBuilder.Append(textLine);
            LogText = stringBuilder.ToString();
            return LogText;
        }

        public void ClearLog()
        {
            LogText = "";
        }
    }
}
