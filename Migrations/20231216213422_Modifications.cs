using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class Modifications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id_game",
                table: "Pictures",
                newName: "Id_Game");

            migrationBuilder.AddColumn<int>(
                name: "material",
                table: "Games",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "material",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "Id_Game",
                table: "Pictures",
                newName: "Id_game");
        }
    }
}
