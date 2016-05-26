using System.Security.Principal;

namespace BTC.Shared.Mvc
{
    public class NullPrincipal : IPrincipal
    {
        public bool IsInRole(string role)
        {
            return false;
        }

        public IIdentity Identity { get; private set; }
    }
}