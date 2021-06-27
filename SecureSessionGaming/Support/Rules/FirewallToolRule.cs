using System;
using NetFwTypeLib;
using SecureSessionGaming.Config;
using SecureSessionGaming.Support.Games;
using SecureSessionGaming.Support.Types;

namespace SecureSessionGaming.Support.Rules
{
    public class FirewallToolRule
    {
        private const string IP_DENY = "1.1.1.1-255.255.255.254";

        //
        // Public static

        public static void Disable()
        {
            INetFwPolicy2 policy = (INetFwPolicy2)Activator.CreateInstance(
                Type.GetTypeFromProgID("HNetCfg.FwPolicy2")
            );
            policy.EnableRuleGroup(
                (int)NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_ALL,
                ApplicationConfig.NAME,
                false
            );
            /*
            foreach (INetFwRule p in firewallPolicy.Rules)
            {
                // Make sure we have our rule only
                if (p.Grouping == ApplicationConfig.NAME && p.Name.StartsWith(ApplicationConfig.NAME))
                {
                    firewallPolicy.Rules.Remove(p.Name);
                }
            }
            */
        }

        public static void Enable()
        {
            INetFwPolicy2 policy = (INetFwPolicy2)Activator.CreateInstance(
                Type.GetTypeFromProgID("HNetCfg.FwPolicy2")
            );
            policy.EnableRuleGroup(
                (int)NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_ALL,
                ApplicationConfig.NAME,
                true
            );
        }

        public static bool RequireInstall()
        {
            int count = 0;
            try
            {
                INetFwPolicy2 policy = (INetFwPolicy2)Activator.CreateInstance(
                    Type.GetTypeFromProgID("HNetCfg.FwPolicy2")
                );
                foreach (INetFwRule rule in policy.Rules)
                {
                    count += (rule.Grouping == ApplicationConfig.NAME) ? 1 : 0;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return count < 2; // inbound (block) + outbound (block)
        }

        public static void Install(Game game)
        {
            // Base
            FirewallPropertiesRule properties = new FirewallPropertiesRule();
            properties.game = game;
            // properties.applicationName // TODO

            //
            // Inbound Block
            properties.Direction = DirectionType.Inbound;
            properties.Action = ActionType.Block;
            properties.RemoteAddresses = IP_DENY;
            FirewallRule.Build(properties).Add();


            //
            // Outbound Block
            properties.Direction = DirectionType.Outbound;
            properties.Action = ActionType.Block;
            properties.RemoteAddresses = IP_DENY;
            properties.Protocol = game.GetProtocol();
            properties.Port = game.GetPort();
            FirewallRule.Build(properties).Add();

            //
            properties.Dispose();
        }
    }
}
