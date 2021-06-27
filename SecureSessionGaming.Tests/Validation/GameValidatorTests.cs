using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecureSessionGaming.Exceptions;
using SecureSessionGaming.Support.Games;
using SecureSessionGaming.Validation;

namespace SecureSessionGaming.Tests.Validation
{
    [TestClass]
    public class GameValidatorTests
    {
        [TestMethod]
        public void TestValidGame()
        {
            try
            {
                GameValidator.Validate(new GrandTheftAuto5());
            }
            catch (AppException e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void TestInvalidGame()
        {
            try
            {
                GameValidator.Validate(new NoGame());
            }
            catch (AppException e)
            {
                Assert.AreEqual("Invalid game provided: ", e.Message);
            }
        }
    }
}
