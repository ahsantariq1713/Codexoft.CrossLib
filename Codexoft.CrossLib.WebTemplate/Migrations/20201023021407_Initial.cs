using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Codexoft.CrossLib.WebTemplate.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    HashPassword = table.Column<string>(nullable: false),
                    Role = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "HashPassword", "Name", "Role", "UpdatedAt" },
                values: new object[] { "0ba01ff8-b59c-47e3-99e4-71171f0200ac", new DateTime(2020, 10, 23, 7, 14, 7, 614, DateTimeKind.Local).AddTicks(2713), "shahzadwaheed0@email.com", "$2b$10$ZFv6SXnVBj9RnRqhQt4tVe5n7X4vJQUgXdRy1xbKNwL5YE6o8OI6q", "Shahzad Waheed", "Administrator", new DateTime(2020, 10, 23, 7, 14, 7, 615, DateTimeKind.Local).AddTicks(462) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
