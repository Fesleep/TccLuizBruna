using Microsoft.EntityFrameworkCore.Migrations;

namespace TCC.DataAccess.Migrations
{
    public partial class Reestruturacao12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Leste",
                table: "Lotes");

            migrationBuilder.DropColumn(
                name: "Norte",
                table: "Lotes");

            migrationBuilder.DropColumn(
                name: "Oeste",
                table: "Lotes");

            migrationBuilder.DropColumn(
                name: "Sul",
                table: "Lotes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Leste",
                table: "Lotes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Norte",
                table: "Lotes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Oeste",
                table: "Lotes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sul",
                table: "Lotes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
