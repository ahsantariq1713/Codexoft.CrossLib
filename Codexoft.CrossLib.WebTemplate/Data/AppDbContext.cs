using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Codexoft.CrossLib.Architecture.Database;
using Codexoft.CrossLib.Architecture.Data.Entities;
using Codexoft.CrossLib.Architecture.Database.Seeder;

namespace Codexoft.CrossLib.WebTemplate.Data
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string connection = "FileName=db.sqlite";
            optionsBuilder.UseSqlite(connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.RunDatabaseSeeder();
        }
    }
}
