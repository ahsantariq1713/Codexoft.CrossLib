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
                Name = "Shahzad Waheed",
                Email = "shahzadwaheed0@email.com",
                Role = UserRoles.Administrator
            };
            user.TrackEntityState();
            user.SetHashPassword("password");

            modelBuilder.Entity<User>().HasData(user);
        }

    }
}
