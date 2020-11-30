using Microsoft.EntityFrameworkCore.Migrations;

namespace ImdbInfraData.Migrations
{
    public partial class movies_gender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GeneroFilme",
                table: "Movie",
                newName: "MovieGender");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MovieGender",
                table: "Movie",
                newName: "GeneroFilme");
        }
    }
}
