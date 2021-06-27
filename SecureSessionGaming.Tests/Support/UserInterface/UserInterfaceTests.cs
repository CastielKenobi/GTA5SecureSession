using System.Windows.Media;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecureSessionGaming.Support.UserInterface;

namespace SecureSessionGaming.Tests.Support.UserInterface
{
    public class UserInterfaceTests
    {
        [TestMethod]
        public void TestActive()
        {
            InterfaceSupport interfaceObject = new InterfaceSupport(true);

            // 
            Assert.AreEqual(
                new SolidColorBrush(Color.FromArgb(255, (byte)40, (byte)170, (byte)70)),
                interfaceObject.GetBackground()
            );

            Assert.AreEqual(
                "Active",
                interfaceObject.GetStatusText()
            );

            Assert.AreEqual(
                "Secure",
                interfaceObject.GetButtonText()
            );

            // reverse logic for disable/enable button
            Assert.IsFalse(
                interfaceObject.GetActiveStatus()
            );
        }

        [TestMethod]
        public void TestInactive()
        {
            InterfaceSupport interfaceObject = new InterfaceSupport(false);

            // 
            Assert.AreEqual(
                new SolidColorBrush(Color.FromArgb(255, (byte)220, (byte)50, (byte)70)),
                interfaceObject.GetBackground()
            );

            Assert.AreEqual(
                "Not Active",
                interfaceObject.GetStatusText()
            );

            Assert.AreEqual(
                "Terminate",
                interfaceObject.GetButtonText()
            );

            // reverse logic for disable/enable button
            Assert.IsTrue(
                interfaceObject.GetActiveStatus()
            );
        }

    }
}
