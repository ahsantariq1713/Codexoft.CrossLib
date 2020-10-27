using Microsoft.EntityFrameworkCore;
using Codexoft.CrossLib.Architecture.Data.Entities;
using Codexoft.CrossLib.Architecture.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Codexoft.CrossLib.Architecture.Database.Seeder
{
    public class UserSeeder
    {
        public static void Run(ModelBuilder modelBuilder)
        {
            var user = new User
            {
                Name = "Ahsan Tariq",
                Email = "ahsantariq17130@gmail.com",
                Role = UserRoles.Administrator
            };
            user.TrackEntityState();
            user.SetHashPassword("password");

            modelBuilder.Entity<User>().HasData(user);
        }

    }
}
