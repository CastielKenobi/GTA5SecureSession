using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecureSessionGaming.Support.Games;

namespace SecureSessionGaming.Tests.Support.Games
{
    [TestClass]

    public class RedDeadRedemption2Tests
    {
        [TestMethod]
        public void TestGetName()
        {
            Assert.AreEqual("Red Dead Redemption 2", new RedDeadRedemption2().GetName());
        }

        [TestMethod]
        public void TestGetPort()
        {
            Assert.AreEqual(
                "6672,61455,61456,61457,61458",
                new RedDeadRedemption2().GetPort()
            );
        }

        [TestMethod]
        public void TestGetProtocol()
        {
            Assert.AreEqual(17, new RedDeadRedemption2().GetProtocol());
        }

        [TestMethod]
        public void TestFromString()
        {
            Assert.AreEqual("Red Dead Redemption 2", GameAbstract.FromString("Red Dead Redemption 2").GetName());
        }
    }
}
