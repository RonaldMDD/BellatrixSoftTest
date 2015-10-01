using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelatrixSoftTest.Refactor
{
    public class ConsoleLogger : ILogger
    {
        public void Process(string message, LogMessageType logType)
        {
            switch (logType)
            {
                case LogMessageType.ERROR:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case LogMessageType.MESSAGE:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case LogMessageType.WARNING:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
            }
            Console.WriteLine(DateTime.Now.ToShortDateString() + message); 
        }
    }
}
