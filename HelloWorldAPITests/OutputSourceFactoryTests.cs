using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloWorldAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.QualityTools.Testing.Fakes;

namespace HelloWorldAPI.Tests
{
    [TestClass()]
    public class OutputSourceFactoryTests
    {
        [DataTestMethod()]
        [DataRow("Console")]
        [DataRow("Database")]
        [DataRow("EventViewer")]
        [DataRow("CustomLogger")]
        public void CreateSourceTest_Valid(string sourceType)
        {
            using (ShimsContext.Create())
            {
                var source = OutputSourceFactory.CreateSource(sourceType);
                Assert.IsNotNull(source);
            }
        }

        [DataTestMethod()]
        [DataRow("ConsoleA")]
        [DataRow("Database2")]
        [DataRow("EventViewer3")]
        [DataRow("CustomLogger4")]
        public void CreateSourceTest_Invalid(string sourceType)
        {
            using (ShimsContext.Create())
            {
                var source = OutputSourceFactory.CreateSource(sourceType);
                Assert.IsNull(source);
            }
        }

    }
}