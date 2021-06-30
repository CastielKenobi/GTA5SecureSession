using System;
using Newtonsoft.Json;
using SecureSessionGaming.Config;
using SecureSessionGaming.Support.Games;
using SecureSessionGaming.Support.Types;

namespace SecureSessionGaming.Support.Rules
{
    public class FirewallPropertiesRule : IDisposable
    {
        //
        // Constructor
        public FirewallPropertiesRule()
        {
        }

        public Game game { get; set; }

        //  Application name (.exe file) : firewallRule.ApplicationName
        public string ApplicationName { get; set; }

        // firewallRule.Direction
        public ActionType Action { get; set; }

        // firewallRule.RemoteAddresses
        public string RemoteAddresses { get; set; }

        // firewallRule.Direction
        public DirectionType Direction { get; set; }

        // Protocol : firewallRule.Protocol
        public int Protocol { get; set; }

        // Ports : firewallRule.LocalPorts
        public string Port { get; set; }

        // Enabled rule : firewallRule.Enabled
        public bool enabled
        {
            get => true;
            private set { }
        }


        // Format: AppNAme-[GameName]-[RuleType/ActionType]
        // firewallRule.Name : firewallRule.Name
        public string RuleName
        {
            get {
                return ApplicationConfig.NAME + " [" + game.GetName() + "] " + Action.Label + " " + Direction.Label;
        }
            private set { }
        }

        //
        // Interface : firewallRule.InterfaceTypes

        public string InterfaceTypes {
            get { return "All"; }
            private set { }
        }

        //
        // Public

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}