using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ImdbInfraData.Migrations
{
    public partial class inital_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedAt", "Deleted", "Password", "Role", "UpdatedAt", "Username" },
                values: new object[] { new Guid("c177b3c0-5fac-4604-9287-2ddd76f19d14"), new DateTime(2020, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "admin", 0, new DateTime(2020, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
