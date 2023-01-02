using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ludo.Infra.Persistence.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfPlayers",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "Games",
                newName: "MinimumNumberOfPlayers");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MaximumNumberOfPlayers",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinimumAge",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MaximumNumberOfPlayers",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "MinimumAge",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "MinimumNumberOfPlayers",
                table: "Games",
                newName: "Age");

            migrationBuilder.AddColumn<string>(
                name: "NumberOfPlayers",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
