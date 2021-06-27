using SecureSessionGaming.Models;
using SecureSessionGaming.Support.Json;
using SecureSessionGaming.Support.Log;
using static SecureSessionGaming.Support.Log.LogSupport;

namespace SecureSessionGaming.Repositories
{
    public class ConfigRepository : JsonAbstractSupport<ConfigModel>
    {
        private const string FILE = "settings.json";

        protected ConfigModel ConfigModel { get; }

        public ConfigRepository()
        {
            ConfigModel = new ConfigModel();
            objectHandler = ConfigModel;

            // init
            SetFile(FILE);

            // Make sure we have a default file
            CreateDefault();

            Load();
        }

        public LogLevel GetLogLevel()
        {
            return LogSupport.GetLogLevel(objectHandler.LogLevel);
        }
    }
}
