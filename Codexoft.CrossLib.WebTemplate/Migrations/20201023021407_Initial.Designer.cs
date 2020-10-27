﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Codexoft.CrossLib.WebTemplate.Data;

namespace Codexoft.CrossLib.WebTemplate.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20201023021407_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8");

            modelBuilder.Entity("SMS.Shared.Data.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("HashPassword")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = "0ba01ff8-b59c-47e3-99e4-71171f0200ac",
                            CreatedAt = new DateTime(2020, 10, 23, 7, 14, 7, 614, DateTimeKind.Local).AddTicks(2713),
                            Email = "shahzadwaheed0@email.com",
                            HashPassword = "$2b$10$ZFv6SXnVBj9RnRqhQt4tVe5n7X4vJQUgXdRy1xbKNwL5YE6o8OI6q",
                            Name = "Shahzad Waheed",
                            Role = "Administrator",
                            UpdatedAt = new DateTime(2020, 10, 23, 7, 14, 7, 615, DateTimeKind.Local).AddTicks(462)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
