using NetFwTypeLib;

namespace SecureSessionGaming.Support.Games
{
    public class NoGame : GameAbstract
    {
        public const string NAME = "";

        public const int RULE_PORT_BASE = 0;

        public const int PROTOCOL = (int)NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_UDP;

        public NoGame()
        {
            this.name = NAME;
            this.port = RULE_PORT_BASE.ToString();
            this.protocol = PROTOCOL;
        }
    }
}

