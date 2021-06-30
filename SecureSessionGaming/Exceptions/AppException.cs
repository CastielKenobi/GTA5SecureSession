using System;

namespace SecureSessionGaming.Exceptions
{
    public class AppException : Exception
    {
        // Settings
        public const string EXCEPTION_SETTINGS_SAVE_ERROR = "Unable to save settings";
        public const string EXCEPTION_SETTINGS_LOAD_ERROR = "Unable to read settings";
        public const string EXCEPTION_SETTINGS_REMOVE_ERROR = "Unable to removing settings";

        // Policies
        public const string EXCEPTION_POLICY_ADD_RULE_ERROR = "Error while creating rule: {0}";
        public const string EXCEPTION_POLICY_REMOVE_RULE_ERROR = "Error while removing rule: {0}";

        // Game
        public const string EXCEPTION_GAME_INVALID = "No game provided";
        public const string EXCEPTION_GAME_INVALID_GAME = "Invalid game provided: {0}";

        //
        //

        public AppException(string source, object value)
            : base(String.Format(source, value))
        {
        }
    }
}
