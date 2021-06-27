using System;
using SecureSessionGaming.Support.Games;
using SecureSessionGaming.Support.Rules;
using SecureSessionGaming.Validation;

namespace SecureSessionGaming.Service
{
    public class PolicyService
    {
        private Game game;

        private bool status;

        public PolicyService(bool status)
        {
            this.status = status;
        }

        public PolicyService()
        {
            this.status = false;
        }

        public PolicyService ForGame(string game)
        {
            this.game = GameAbstract.FromString(game);
            return this;
        }

        public void UpdatePolicy()
        {
            GameValidator.Validate(game);
            
            try
            {
                //
                // Install rules if needed
                if (FirewallToolRule.RequireInstall())
                {
                    FirewallToolRule.Install(game);
                }
                else
                {
                    //
                    // clear rules
                    FirewallToolRule.Disable();

                    //
                    // Enable them if needed
                    if (status)
                    {
                        FirewallToolRule.Enable();
                    }
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public void RemoveAllPolicies()
        {
            FirewallToolRule.Disable();
        }
    }
}
