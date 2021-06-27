using System.Windows.Media;

namespace SecureSessionGaming.Support.UserInterface
{
    public class InterfaceSupport
    {
        //
        // Constants
        private const string ACTIVE = "Active";
        private const string NOT_ACTIVE = "Not Active";

        private const string SECURE = "Secure";
        private const string END = "END";

        //
        // Properties

        private bool status;

        //
        // Public

        public InterfaceSupport(bool status)
        {
            this.status = status;
        }

        public SolidColorBrush GetBackground()
        {
            return status ? Green : Red;
        }

        public string GetStatusText()
        {
            return status ? ACTIVE : NOT_ACTIVE;
        }

        public string GetButtonText()
        {
            return status ? END : SECURE;
        }

        public bool GetActiveStatus()
        {
            return !status;
        }

        //
        // Private

        private static SolidColorBrush Red
        {
            get { return new SolidColorBrush(Color.FromArgb(255, (byte)220, (byte)50, (byte)70)); }
        }

        private static SolidColorBrush Green
        {
            get { return new SolidColorBrush(Color.FromArgb(255, (byte)40, (byte)170, (byte)70)); }
        }

    }
}
