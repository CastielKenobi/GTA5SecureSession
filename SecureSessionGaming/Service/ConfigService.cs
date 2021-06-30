using SecureSessionGaming.Repositories;
using SecureSessionGaming.Support.Log;

namespace SecureSessionGaming.Service
{
    public class ConfigService
    {
        private ConfigRepository Repository;

        public ConfigService()
        {
            Repository = new ConfigRepository();
        }

        public void SetLogLevel()
        {
            LogSupport.LOG_LEVEL = Repository.GetLogLevel();
        }
    }
}