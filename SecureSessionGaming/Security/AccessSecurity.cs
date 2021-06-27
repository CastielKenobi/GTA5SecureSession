using System;
using System.Security.Principal;
using SecureSessionGaming.Support.Log;

// Variable is declared but never used
#pragma warning disable CS0168

namespace SecureSessionGaming.Security
{
    public class AccessSecurity
    {
        public AccessSecurity()
        {
        }

        public static bool IsUserAdministrator()
        {
            bool isAdmin;
            try
            {
                isAdmin = new WindowsPrincipal(
                    WindowsIdentity.GetCurrent()
                ).IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch (Exception e)
            {
                LogSupport.Info(e.Message);
                isAdmin = false;
            }
            return isAdmin;
        }
    }
}
