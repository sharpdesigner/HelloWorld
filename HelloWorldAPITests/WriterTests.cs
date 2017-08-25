using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloWorldAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using HelloWorldAPI.Fakes;
using Microsoft.QualityTools.Testing.Fakes;

namespace HelloWorldAPI.Tests
{
    [TestClass()]
    public class WriterTests
    {
        [TestMethod()]
        public void WriteTest_NullSourceType()
        {
            using (ShimsContext.Create())
            {
                bool LogErrorCalled = false;
                ShimErrorLogger.LogErrorString = s => LogErrorCalled = true;
                Writer.Write(null, "Any random message");
                Assert.IsTrue(LogErrorCalled);
            }

        }

        [TestMethod()]
        public void WriteTest_InvalidSourceType()
        {
            using (ShimsContext.Create())
            {
                bool LogErrorCalled = false;
                ShimErrorLogger.LogErrorString = s => LogErrorCalled = true;
                Writer.Write("MyRandomSourceType", "Any random message");
                Assert.IsTrue(LogErrorCalled);
            }

        }

        [DataTestMethod()]
        [DataRow("Console")]
        [DataRow("Database")]
        [DataRow("EventViewer")]
        [DataRow("CustomLogger")]
        public void WriteTest_ValidSourceTypes(string sourceType)
        {
            using (ShimsContext.Create())
            {
                bool LogErrorCalled = false;
                bool writtenToOutput = false;
                ShimErrorLogger.LogErrorString = s => LogErrorCalled = true;
                ShimOutputSourceConsole.AllInstances.WriteString = (console, s) => writtenToOutput = true;
                ShimOutputSourceCustomLogger.AllInstances.WriteString = (logger, s) => writtenToOutput = true;
                ShimOutputSourceEventViewer.AllInstances.WriteString = (viewer, s) => writtenToOutput = true;
                ShimOutputSourceDatabase.AllInstances.WriteString = (database, s) => writtenToOutput = true;
                Writer.Write(OutputSourceTypes.Console.ToString(), "Any random message");
                Assert.IsFalse(LogErrorCalled);
                Assert.IsTrue(writtenToOutput);
            }
        }


        [DataTestMethod()]
        [DataRow("MyConsole")]
        [DataRow("TomTom")]
        [DataRow("Garmin")]
        public void GetRequestedSourceTest_InvalidType(string sourceType)
        {
            using (ShimsContext.Create())
            {
                bool errorLogged = false;
                ShimErrorLogger.LogErrorString = s => errorLogged = true;
                var outputSource =  Writer.GetRequestedSource(sourceType);
                Assert.IsTrue(errorLogged);
                Assert.IsNull(outputSource);
            }
        }

        [DataTestMethod()]
        [DataRow("Console")]
        [DataRow("Database")]
        [DataRow("EventViewer")]
        [DataRow("CustomLogger")]
        public void GetRequestedSourceTest_Valid(string sourceType)
        {
            using (ShimsContext.Create())
            {
                var source = new OutputSourceConsole();
                bool errorLogged = false;
                ShimErrorLogger.LogErrorString = s => errorLogged = true;
                ShimOutputSourceFactory.CreateSourceOutputSourceTypes = types => source;
                var outputSource=Writer.GetRequestedSource(sourceType);
                Assert.IsFalse(errorLogged);
                Assert.IsNotNull(outputSource);
            }
        }

    }
}