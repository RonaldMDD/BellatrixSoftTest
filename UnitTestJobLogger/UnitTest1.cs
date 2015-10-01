using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using BelatrixSoftTest.Refactor;

namespace UnitTestJobLogger
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestJobLoggerClassDisplayOnlyErrors()
        {
            var mockup = new FileMockupLogger();

            var supportedloggers = new List<ILogger>();
            supportedloggers.Add(mockup);

            var supportedLogTypes = new List<LogMessageType>();
            supportedLogTypes.Add(LogMessageType.ERROR);

            JobLoggerVs2 jobLogger = new JobLoggerVs2(supportedloggers, supportedLogTypes);

            mockup.CurrentMessageType = null;
            jobLogger.OutputLog("Message for logging Error", LogMessageType.ERROR);
            Assert.IsTrue(mockup.CurrentMessageType == LogMessageType.ERROR);

            mockup.CurrentMessageType = null;
            jobLogger.OutputLog("Message for logging Warning", LogMessageType.WARNING);
            Assert.IsTrue(mockup.CurrentMessageType == null);

            mockup.CurrentMessageType = null;
            jobLogger.OutputLog("Message for logging Message", LogMessageType.MESSAGE);            
            Assert.IsTrue(mockup.CurrentMessageType == null);
        }

        [TestMethod]
        public void TestJobLoggerClassDisplayOnlyErrorWarningMessage()
        {
            var mockup = new FileMockupLogger();

            var supportedloggers = new List<ILogger>();
            supportedloggers.Add(mockup);

            var supportedLogTypes = new List<LogMessageType>();
            supportedLogTypes.Add(LogMessageType.ERROR);
            supportedLogTypes.Add(LogMessageType.MESSAGE);
            supportedLogTypes.Add(LogMessageType.WARNING);

            JobLoggerVs2 jobLogger = new JobLoggerVs2(supportedloggers, supportedLogTypes);

            mockup.CurrentMessageType = null;
            jobLogger.OutputLog("Message for logging Error", LogMessageType.ERROR);
            Assert.IsTrue(mockup.CurrentMessageType.Value == LogMessageType.ERROR);

            mockup.CurrentMessageType = null;
            jobLogger.OutputLog("Message for logging Warning", LogMessageType.WARNING);
            Assert.IsTrue(mockup.CurrentMessageType.Value == LogMessageType.WARNING);

            mockup.CurrentMessageType = null;
            jobLogger.OutputLog("Message for logging Message", LogMessageType.MESSAGE);
            Assert.IsTrue(mockup.CurrentMessageType.Value == LogMessageType.MESSAGE);
        }

        [TestMethod]
        public void TestMultipleLoggers()
        {
            var fileMockup = new FileMockupLogger();
            var dbMockup = new DataBaseMockupLogger();
            var consoleMockup = new ConsoleMockupLogger();
            
            var supportedloggers = new List<ILogger>();
            supportedloggers.Add(fileMockup);
            supportedloggers.Add(dbMockup);
            supportedloggers.Add(consoleMockup);

            var supportedLogTypes = new List<LogMessageType>();
            supportedLogTypes.Add(LogMessageType.ERROR);

            JobLoggerVs2 jobLogger = new JobLoggerVs2(supportedloggers, supportedLogTypes);

            jobLogger.OutputLog("ExecuteLogger", LogMessageType.WARNING);
            Assert.IsTrue(string.IsNullOrEmpty(fileMockup.CurrentMessage));
            Assert.IsTrue(string.IsNullOrEmpty(dbMockup.CurrentMessage));
            Assert.IsTrue(string.IsNullOrEmpty(consoleMockup.CurrentMessage));

            jobLogger.OutputLog("ExecuteLogger", LogMessageType.ERROR);
            Assert.IsTrue(fileMockup.CurrentMessage.Equals("ExecuteLogger"));
            Assert.IsTrue(dbMockup.CurrentMessage.Equals("ExecuteLogger"));
            Assert.IsTrue(consoleMockup.CurrentMessage.Equals("ExecuteLogger"));
        }

        /// <summary>
        /// Negative Test        
        /// </summary>
        [TestMethod]
        public void TestInnerExceptionSupportedLoggersAreNotSpecified()
        {
            var supportedloggers = new List<ILogger>();

            var supportedLogTypes = new List<LogMessageType>();
            supportedLogTypes.Add(LogMessageType.ERROR);
            supportedLogTypes.Add(LogMessageType.MESSAGE);
            supportedLogTypes.Add(LogMessageType.WARNING);            

            try
            {
                JobLoggerVs2 jobLogger = new JobLoggerVs2(null, supportedLogTypes);
                Assert.Fail("The inner exception was not thrown");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(true, ex.Message);
            }           

        }

        /// <summary>
        /// Negative Test 
        /// </summary>
        [TestMethod]
        public void TestInnerExceptionSupportedMessageTypesAreNotSpecified()
        {
            var supportedloggers = new List<ILogger>();
            supportedloggers.Add(new ConsoleLogger());

            var supportedLogTypes = new List<LogMessageType>();

            try
            {
                JobLoggerVs2 jobLogger = new JobLoggerVs2(supportedloggers, supportedLogTypes);
                Assert.Fail("The inner exception was not thrown");
            }
            catch (Exception)
            {
                Assert.IsTrue(true);
            }     
        }
    }
}
