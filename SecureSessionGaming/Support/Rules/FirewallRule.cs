using System;
using System.Linq;
using NetFwTypeLib;
using SecureSessionGaming.Config;
using SecureSessionGaming.Support.Types;

namespace SecureSessionGaming.Support.Rules
{
    public class FirewallRule
    {
        //
        // Properties

        private INetFwRule firewallRule;

        //
        // Public static

        public static FirewallRule Build(FirewallPropertiesRule properties)
        {
            FirewallRule rule = new FirewallRule();

            rule.firewallRule = (INetFwRule)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));

            //
            rule.firewallRule.ApplicationName = properties.ApplicationName;


            if (!string.IsNullOrEmpty(properties.RemoteAddresses))
            {
                rule.firewallRule.RemoteAddresses = properties.RemoteAddresses;
            }

            rule.firewallRule.Enabled = properties.enabled;
            rule.firewallRule.InterfaceTypes = properties.InterfaceTypes;

            rule.firewallRule.Action = properties.Action.Action;
            rule.firewallRule.Direction = properties.Direction.direction;
            if (properties.Direction.direction == DirectionType.Outbound.direction)
            {
                rule.firewallRule.Protocol = properties.Protocol;
                rule.firewallRule.LocalPorts = properties.Port;
            }

            rule.firewallRule.Name = properties.RuleName;
            rule.firewallRule.Grouping = ApplicationConfig.NAME;

            properties.Dispose();

            return rule;
        }

        public void Add()
        {
            if (!Exists(this.firewallRule.Name))
            {
                ((INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2")))
                    .Rules
                    .Add(this.firewallRule);
            }
        }

        //
        // Privates

        private FirewallRule()
        {
        }

        private bool Exists(string ruleName)
        {
            return ((INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2")))
                .Rules
                .OfType<INetFwRule>()
                .Where(x => x.Name == ruleName)
                .FirstOrDefault() != null;
        }
    }
}
