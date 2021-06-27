using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecureSessionGaming.Support.Log;
using static SecureSessionGaming.Support.Log.LogSupport;

namespace SecureSessionGaming.Tests.Support.Log
{
    [TestClass]
    public class LogSupportTests
    {
        [TestMethod]
        public void TestGetLogLevelError()
        {
            Assert.AreEqual(
                LogLevel.ERROR,
                LogSupport.GetLogLevel("error")
            );

            Assert.AreEqual(
                LogLevel.ERROR,
                LogSupport.GetLogLevel("ERROR")
            );
        }

        [TestMethod]
        public void TestGetLogLevelInfo()
        {
            Assert.AreEqual(
                LogLevel.INFO,
                LogSupport.GetLogLevel("nfo")
            );

            Assert.AreEqual(
                LogLevel.INFO,
                LogSupport.GetLogLevel("INFo")
            );
        }

        [TestMethod]
        public void TestGetLogLevelDebug()
        {
            Assert.AreEqual(
                LogLevel.DEBUG,
                LogSupport.GetLogLevel("debug")
            );

            Assert.AreEqual(
                LogLevel.DEBUG,
                LogSupport.GetLogLevel("Debug")
            );
        }
    }
}
