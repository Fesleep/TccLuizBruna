using Microsoft.EntityFrameworkCore.Migrations;

namespace TCC.DataAccess.Migrations
{
    public partial class Reestruturacao3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustoSaca",
                table: "Sacas");

            migrationBuilder.DropColumn(
                name: "PesoSacaKg",
                table: "Sacas");

            migrationBuilder.AddColumn<decimal>(
                name: "CustoSaca",
                table: "Sementes",
                type: "Money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<double>(
                name: "PesoSacaKg",
                table: "Sementes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustoSaca",
                table: "Sementes");

            migrationBuilder.DropColumn(
                name: "PesoSacaKg",
                table: "Sementes");

            migrationBuilder.AddColumn<decimal>(
                name: "CustoSaca",
                table: "Sacas",
                type: "Money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<double>(
                name: "PesoSacaKg",
                table: "Sacas",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
