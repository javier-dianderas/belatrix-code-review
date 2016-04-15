using System;
using Logger.Client;
using Logger.Factory;
using Logger.Product.Console;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logger.Product.File;

namespace Logger.Tests.Client
{
    [TestClass]
    public class JobLoggerFileTest
    {
        private FactoryLogger _factory;
        private JobLogger _jobLogger;


        [TestInitialize]
        public void InitializeTest()
        {
            _factory = new FileFactory();
            _jobLogger = null;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Message is empty")]
        public void LogMessageIsEmptyTest()
        {
            //Arrange 
            _jobLogger = new JobLogger(_factory);
            //Act
            _jobLogger.LogMessage("", true, false, false);
            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Error or Warning or Message must be specified")]
        public void LogMessageIsWithoutAnyTypeOfMessageTest()
        {
            //Arrange 
            _jobLogger = new JobLogger(_factory);
            //Act
            _jobLogger.LogMessage("message", false, false, false);
            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "More than one type of message are not permitted")]
        public void LogMessageIsWithMoreThanOneTypeOfMessageTest()
        {
            //Arrange 
            _jobLogger = new JobLogger(_factory);
            //Act
            _jobLogger.LogMessage("message", true, false, true);
            //Assert
        }

        [TestMethod]
        public void LogMessageSuccessfullyTest()
        {
            //Arrange 
            _jobLogger = new JobLogger(_factory);
            //Act
            _jobLogger.LogMessage("message", true, false, false);
            //Assert
            var logger = (FileLogger)_jobLogger.Logger;            
            Assert.AreEqual(logger.Type, 1);
        }

        [TestMethod]
        public void LogWarningSuccessfullyTest()
        {
            //Arrange 
            _jobLogger = new JobLogger(_factory);
            //Act
            _jobLogger.LogMessage("message", false, true, false);
            //Assert
            var logger = (FileLogger)_jobLogger.Logger;            
            Assert.AreEqual(logger.Type, 3);
        }

        [TestMethod]
        public void LogErrorSuccessfullyTest()
        {
            //Arrange 
            _jobLogger = new JobLogger(_factory);
            //Act
            _jobLogger.LogMessage("message", false, false, true);
            //Assert
            var logger = (FileLogger)_jobLogger.Logger;            
            Assert.AreEqual(logger.Type, 2);
        }
    }
}
