using NetFwTypeLib;

namespace SecureSessionGaming.Support.Games
{
    public class RedDeadRedemption2 : GameAbstract
    {
        public const string NAME = "Red Dead Redemption 2";

        /*
         * UDP only, GTA 5 PC does not support TCP
         * 
         * https://support.rockstargames.com/articles/360037589074/Red-Dead-Online-PC-Connection-Troubleshooting
         */
        public const int RULE_PORT_BASE = 6672;
        public const int RULE_PORT_EXTENDED_1 = 61455;
        public const int RULE_PORT_EXTENDED_2 = 61456;
        public const int RULE_PORT_EXTENDED_3 = 61457;
        public const int RULE_PORT_EXTENDED_4 = 61458;

        public const int PROTOCOL = (int)NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_UDP;

        public RedDeadRedemption2()
        {
            this.name = NAME;
            this.port = RULE_PORT_BASE.ToString() + ","
                + RULE_PORT_EXTENDED_1.ToString() + ","
                + RULE_PORT_EXTENDED_2.ToString() + ","
                + RULE_PORT_EXTENDED_3.ToString() + ","
                + RULE_PORT_EXTENDED_4.ToString();
            this.protocol = PROTOCOL;
        }
    }
}
