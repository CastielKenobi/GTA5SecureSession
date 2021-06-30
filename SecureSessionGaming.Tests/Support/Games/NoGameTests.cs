using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecureSessionGaming.Support.Games;

namespace SecureSessionGaming.Tests.Support.Games
{
    [TestClass]

    public class NoGameTests
    {
       
        [TestMethod]
        public void TestGetName()
        {
            Assert.AreEqual("", new NoGame().GetName());
        }

        [TestMethod]
        public void TestGetPort()
        {
            Assert.AreEqual(
                "0",
                new NoGame().GetPort()
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
            Assert.AreEqual("", GameAbstract.FromString("Not a game").GetName());
        }
    }
}
