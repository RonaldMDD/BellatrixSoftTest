using BelatrixSoftTest.Refactor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestJobLogger
{
    public class FileMockupLogger: ILogger
    {
        public string CurrentMessage { get; set; }
        public LogMessageType? CurrentMessageType { get; set; }

        public void Process(string message, LogMessageType logType)
        {
            CurrentMessage = message;
            CurrentMessageType = logType;
        }
    }

    public class DataBaseMockupLogger : ILogger
    {
        public string CurrentMessage { get; set; }
        public LogMessageType? CurrentMessageType { get; set; }

        public void Process(string message, LogMessageType logType)
        {
            CurrentMessage = message;
            CurrentMessageType = logType;
        }
    }

    public class ConsoleMockupLogger : ILogger
    {
        public string CurrentMessage { get; set; }
        public LogMessageType? CurrentMessageType { get; set; }

        public void Process(string message, LogMessageType logType)
        {
            CurrentMessage = message;
            CurrentMessageType = logType;
        }
    }
}
