using Codexoft.CrossLib.Architecture.Data.Entities;
using Codexoft.CrossLib.Architecture.Database;
using Codexoft.CrossLib.Architecture.Database.Seeder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.Consolas
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public DbSet<User> Users { get; set; }

        //setup connection string
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "FileName=db.sqlite";
            optionsBuilder.UseSqlite(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.RunDatabaseSeeder();
        }

    }
}
