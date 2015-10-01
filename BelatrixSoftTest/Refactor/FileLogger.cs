using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;
using System.Threading.Tasks;

namespace BelatrixSoftTest.Refactor
{
    public class FileLogger : ILogger
    {
        private const string logFile = "LogFile{0}.txt";
        private string logFileDirectory = ConfigurationManager.AppSettings["LogFileDirectory"];
        
        public void Process(string message, LogMessageType logType)
        {
            string l = string.Empty;
            if (!File.Exists(logFileDirectory + string.Format(logFile, DateTime.Now.ToShortDateString())))
            {
                l = File.ReadAllText(logFileDirectory + string.Format(logFile, DateTime.Now.ToShortDateString()));
            }

            switch (logType)
            {
                case LogMessageType.ERROR:
                    l = l + DateTime.Now.ToShortDateString() + message;
                    break;
                case LogMessageType.MESSAGE:
                    l = l + DateTime.Now.ToShortDateString() + message;
                    break;
                case LogMessageType.WARNING:
                    l = l + DateTime.Now.ToShortDateString() + message;
                    break;
            }

            File.WriteAllText(logFileDirectory + string.Format(logFile, DateTime.Now.ToShortDateString()), l);   
        }
    }
}
