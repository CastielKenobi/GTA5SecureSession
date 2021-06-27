using NetFwTypeLib;

namespace SecureSessionGaming.Support.Types
{
    public class DirectionType
    {
        //
        // Const

        private const string LABEL_INBOUND = "Inbound";
        private const string LABEL_OUTBOUND = "Outbound";

        //
        // Properties
        public string Label
        {
            get;
            private set;
        }

        public NET_FW_RULE_DIRECTION_ direction
        {
            get;
            private set;
        }

        //
        // Enum
        public static DirectionType Inbound {
            get {
                return new DirectionType(
                    LABEL_INBOUND,
                    NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN
                );
            }
        }
        public static DirectionType Outbound {
            get {
                return new DirectionType(
                    LABEL_OUTBOUND,
                    NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT
                );
            }
        }

        //
        // Private

        private DirectionType(string label, NET_FW_RULE_DIRECTION_ direction)
        {
            this.Label = label;
            this.direction = direction;
        }
    }
}
