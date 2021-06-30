using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecureSessionGaming.Exceptions;
using SecureSessionGaming.Service;

namespace SecureSessionGaming.Tests.Service
{
    [TestClass]
    public class PolicyServiceTests
    {
        [TestMethod]
        public void TestNoGame()
        {
            PolicyService service = new PolicyService(true);
            try
            {
                service.UpdatePolicy();
            }
            catch (AppException e)
            {
                Assert.AreEqual("No game provided", e.Message);
            }
        }

        [TestMethod]
        public void TestInvalidGame()
        {
            PolicyService service = new PolicyService(true);
            service.ForGame("not a valid game");

            try
            {
                service.UpdatePolicy();
            }
            catch (AppException e)
            {
                Assert.AreEqual("Invalid game provided: ", e.Message);
            }
        }

    }
}
