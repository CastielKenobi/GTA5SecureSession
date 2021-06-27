using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecureSessionGaming.Support.Games;

namespace SecureSessionGaming.Tests.Support.Games
{
    [TestClass]
    public class GrandTheftAuto5Tests
    {
        [TestMethod]
        public void TestGetName()
        {
            Assert.AreEqual("Grand Theft Auto 5", new GrandTheftAuto5().GetName());
        }

        [TestMethod]
        public void TestGetPort()
        {
            Assert.AreEqual(
                "6672,61455,61456,61457,61458",
                new GrandTheftAuto5().GetPort()
            );
        }

        [TestMethod]
        public void TestGetProtocol()
        {
            Assert.AreEqual(17, new GrandTheftAuto5().GetProtocol());
        }

        [TestMethod]
        public void TestFromString()
        {
            Assert.AreEqual("Grand Theft Auto 5", GameAbstract.FromString("Grand Theft Auto 5").GetName());
        }
    }
}