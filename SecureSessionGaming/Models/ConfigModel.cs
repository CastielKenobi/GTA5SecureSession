namespace SecureSessionGaming.Models
{
    public class ConfigModel
    {
        public string LogLevel { get; set; }

        public ConfigModel()
        {
            LogLevel = "info";
        }
    }
}
