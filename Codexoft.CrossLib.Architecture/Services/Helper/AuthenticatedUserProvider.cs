using Codexoft.CrossLib.Architecture.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Codexoft.CrossLib.Architecture.Services.Helper
{
    public static class AuthenticatedUserProvider
    {
        public static User Instance { get; set; } = new User();
        public static bool NotClaimBasedAuthentication { get; private set; }
        public static void InitForNotClaimBasedAuthentication()
        {
            NotClaimBasedAuthentication = true;
        }

        public static void EnsureInitForNotClamBasedAuthentication()
        {
            if (NotClaimBasedAuthentication == false)
            {
                throw new Exception("Authenticated User Provider service is not initialized");
            }
        }

    }
}
