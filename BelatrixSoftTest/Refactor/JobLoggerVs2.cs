using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelatrixSoftTest.Refactor
{
    public class JobLoggerVs2
    {
        private List<ILogger> innerLoggers;
        private List<LogMessageType> supportedLogTypes;

        public JobLoggerVs2(List<ILogger> loggerList, List<LogMessageType> supportedLogTypes)
        {
            if (loggerList == null || loggerList.Count == 0)
            {
                throw new Exception("Error, invalid configuration");                
            }

            if (supportedLogTypes == null || supportedLogTypes.Count == 0)
            {
                throw new Exception("Error, invalid configuration");
            }

            this.innerLoggers = loggerList;
            this.supportedLogTypes = supportedLogTypes;
        }

        public void OutputLog(string message, LogMessageType logType)
        {
            if (!supportedLogTypes.Contains(logType))
            {
                return;
            }  

            foreach (var logger in innerLoggers)
            {
                logger.Process(message, logType);                           
            }            
        }
    }
}
