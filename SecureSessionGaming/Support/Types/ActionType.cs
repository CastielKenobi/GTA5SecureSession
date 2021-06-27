using NetFwTypeLib;

namespace SecureSessionGaming.Support.Types
{
    public class ActionType
    {
        //
        // Const

        private const string LABEL_ALLOW = "Allow";
        private const string LABEL_BLOCK = "Block";

        //
        // Properties

        public string Label
        {
            get;
            private set;
        }

        public NET_FW_ACTION_ Action
        {
            get;
            private set;
        }

        //
        // Enum

        public static ActionType Allow
        {
            get
            {
                return new ActionType(
                    LABEL_ALLOW,
                    NET_FW_ACTION_.NET_FW_ACTION_ALLOW
                );
            }
        }

        public static ActionType Block
        {
            get
            {
                return new ActionType(
                    LABEL_BLOCK,
                    NET_FW_ACTION_.NET_FW_ACTION_BLOCK
                );
            }
        }

        //
        // Private

        private ActionType(string label, NET_FW_ACTION_ action)
        {
            this.Label = label;
            this.Action = action;
        }
    }
}
