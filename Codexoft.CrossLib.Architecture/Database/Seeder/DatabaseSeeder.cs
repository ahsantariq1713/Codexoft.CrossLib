using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Codexoft.CrossLib.Architecture.Database.Seeder
{
    public static class DatabaseSeeder
    {
        public static void RunDatabaseSeeder(this ModelBuilder modelBuilder)
        {
            UserSeeder.Run(modelBuilder);
        }
    }
}
