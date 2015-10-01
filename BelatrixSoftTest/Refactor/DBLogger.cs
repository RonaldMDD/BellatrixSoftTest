using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace BelatrixSoftTest.Refactor
{
    public class DBLogger : ILogger
    {
        private const string CnxString = "ConnectionString";
        private const string Query = "Insert into Log Values('{0}', {1})"; 

        public void Process(string message, LogMessageType logType)
        {
            int t = 0;

            var connection = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings[CnxString]);
            connection.Open();            
            switch (logType)
            {
                case LogMessageType.ERROR:
                    t = 1;
                    break;
                case LogMessageType.MESSAGE:
                    t = 2;
                    break;
                case LogMessageType.WARNING:
                    t = 3;
                    break;
            }
            var command = new SqlCommand(string.Format(Query, message, t.ToString()));
            command.ExecuteNonQuery(); 
        }
    }
}
