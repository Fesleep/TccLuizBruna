using Microsoft.EntityFrameworkCore.Migrations;

namespace TCC.DataAccess.Migrations
{
    public partial class Reestruturacao18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MetragemLinear",
                table: "Lotes");

            migrationBuilder.RenameColumn(
                name: "SementesPorMetro",
                table: "Plantacoes",
                newName: "SementesPorMetroLinear");

            migrationBuilder.RenameColumn(
                name: "PlantasPorMetro",
                table: "Plantacoes",
                newName: "PlantasPorMetroLinear");

            migrationBuilder.AddColumn<double>(
                name: "MetragemLinear",
                table: "Plantacoes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MetrosQuadrados",
                table: "Lotes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MetragemLinear",
                table: "Plantacoes");

            migrationBuilder.DropColumn(
                name: "MetrosQuadrados",
                table: "Lotes");

            migrationBuilder.RenameColumn(
                name: "SementesPorMetroLinear",
                table: "Plantacoes",
                newName: "SementesPorMetro");

            migrationBuilder.RenameColumn(
                name: "PlantasPorMetroLinear",
                table: "Plantacoes",
                newName: "PlantasPorMetro");

            migrationBuilder.AddColumn<string>(
                name: "MetragemLinear",
                table: "Lotes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
