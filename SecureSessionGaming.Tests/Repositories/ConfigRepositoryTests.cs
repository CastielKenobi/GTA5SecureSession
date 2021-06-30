using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecureSessionGaming.Repositories;
using static SecureSessionGaming.Support.Log.LogSupport;

namespace SecureSessionGaming.Tests.Repositories
{
    [TestClass]
    public class ConfigRepositoryTests
    {
        [TestMethod]
        public void TestDefault()
        {
            ConfigRepository repository = new ConfigRepository();
            Assert.AreEqual(LogLevel.INFO, repository.GetLogLevel());
        }
    }
}
