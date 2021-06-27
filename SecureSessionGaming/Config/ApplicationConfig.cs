using System.Diagnostics;
using System.Reflection;
using static SecureSessionGaming.Support.Log.LogSupport;

namespace SecureSessionGaming.Config
{
    public class ApplicationConfig
    {
        public const LogLevel DEFAULT_LOG_LEVEL = LogLevel.INFO;

        public const string NAME = "Secure Session Gaming";

        public ApplicationConfig()
        {

        }

        public static object ApplicationDeployment { get; private set; }

        public static string GetVersion()
        {
            return " v" + FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductVersion;
        }
    }
}
