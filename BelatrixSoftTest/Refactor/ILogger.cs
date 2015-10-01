using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelatrixSoftTest.Refactor
{
    public interface ILogger
    {
        void Process(string message, LogMessageType logType);
    }
}
