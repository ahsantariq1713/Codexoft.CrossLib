using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Codexoft.CrossLib.Architecture.Data.Entities;
using Codexoft.CrossLib.Architecture.Database;
using Codexoft.CrossLib.Architecture.Services.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Codexoft.CrossLib.Architecture.Services.Containers
{
    public class ClientServiceContainer
    {
        public static ServiceProvider Provider { get; private set; }

        public static IServiceCollection ServiceCollection { get; private set; }

        public static void Initialize()
        {
            ServiceCollection = new ServiceCollection();
            AuthenticatedUserProvider.EnsureInitForNotClamBasedAuthentication();
        }

        public static void Build()
        {
            //please register services here
            ServiceCollection.AddScoped<UserService>();

            //don't modify or delete this line
            Provider = ServiceCollection.BuildServiceProvider();
        }
    }
}
