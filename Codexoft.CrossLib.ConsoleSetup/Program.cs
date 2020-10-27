using Codexoft.CrossLib.Architecture.Data.Models;
using Codexoft.CrossLib.Architecture.Database;
using Codexoft.CrossLib.Architecture.Exceptions;
using Codexoft.CrossLib.Architecture.Services;
using Codexoft.CrossLib.Architecture.Services.Containers;
using Codexoft.CrossLib.Architecture.Services.Helper;
using Microsoft.Extensions.DependencyInjection;
using PostSharp.Aspects;
using PostSharp.Serialization;
using System;
using System.Linq;

namespace SMS.Consolas
{

    class Program
    {
        static void Main(string[] args)
        {
            using (var dbContext = new AppDbContext())
            {
                dbContext.Database.EnsureCreated();
            }

            AuthenticatedUserProvider.InitForNotClaimBasedAuthentication();

            ClientServiceContainer.Initialize();
            ClientServiceContainer.ServiceCollection.AddScoped<IAppDbContext, AppDbContext>();
            ClientServiceContainer.Build();

            try
            {
                var userService = ClientServiceContainer.Provider.GetService<UserService>();

                var credentials = new LoginModel { Email = "ahsantariq1713@gmail.com", Password = "password" };
                var user = userService.GetAuthenticatedUserAsync(credentials).GetAwaiter().GetResult();
                if (user == null)
                {
                    Console.WriteLine("Invalid email or password");
                    return;
                }

                var users = userService.GetAsync().GetAwaiter().GetResult();

                foreach (var usr in users)
                {
                    Console.WriteLine($"Id:{usr.Id}\t\tName:{usr.Name}\t\tEmail:{usr.Email}\t\tRole:{usr.Role}");
                }

                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("Total Users : " + users.Count());
            }
            catch (UnauthorizedRequestException)
            {
                Console.WriteLine("You are not allowd to access these serviuces");
            }
            catch (EntityNotFoundException)
            {
                Console.WriteLine("You requsted resources not found");
            }
            catch (ValidationFailedException ex)
            {
                foreach (var err in ex.ValidationErrors)
                {
                    Console.WriteLine(err.MemberNames.First() + " :" + err.ErrorMessage);
                }
            }

            Console.ReadKey();
        }


    }

}
