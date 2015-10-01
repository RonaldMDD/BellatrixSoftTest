using BelatrixSoftTest.Refactor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelatrixSoftTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var supportedloggers = new List<ILogger>();
            supportedloggers.Add(new ConsoleLogger());
            supportedloggers.Add(new DBLogger());
            supportedloggers.Add(new FileLogger());

            var supportedLogTypes = new List<LogMessageType>();
            supportedLogTypes.Add(LogMessageType.ERROR);
            supportedLogTypes.Add(LogMessageType.MESSAGE);
            supportedLogTypes.Add(LogMessageType.WARNING);

            JobLoggerVs2 jobLogger = new JobLoggerVs2(supportedloggers, supportedLogTypes);

            jobLogger.OutputLog("Message for logging", LogMessageType.ERROR);

            jobLogger.OutputLog("Message for logging", LogMessageType.MESSAGE);

            jobLogger.OutputLog("Message for logging", LogMessageType.WARNING);
        }
    }
}
