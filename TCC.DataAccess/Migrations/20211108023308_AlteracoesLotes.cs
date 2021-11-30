using Microsoft.EntityFrameworkCore.Migrations;

namespace TCC.DataAccess.Migrations
{
    public partial class AlteracoesLotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "Lotes");

            migrationBuilder.RenameColumn(
                name: "Tamanho",
                table: "Lotes",
                newName: "SementesTotal");

            migrationBuilder.AddColumn<float>(
                name: "CustoHectare",
                table: "Lotes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "CustoPlantacao",
                table: "Lotes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Espacamento",
                table: "Lotes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "MetragemLinear",
                table: "Lotes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "PMS",
                table: "Lotes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "PTS",
                table: "Lotes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "PesoSaca",
                table: "Lotes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "PrecoSaca",
                table: "Lotes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "QtdeSaca",
                table: "Lotes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "SementesPorMetro",
                table: "Lotes",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustoHectare",
                table: "Lotes");

            migrationBuilder.DropColumn(
                name: "CustoPlantacao",
                table: "Lotes");

            migrationBuilder.DropColumn(
                name: "Espacamento",
                table: "Lotes");

            migrationBuilder.DropColumn(
                name: "MetragemLinear",
                table: "Lotes");

            migrationBuilder.DropColumn(
                name: "PMS",
                table: "Lotes");

            migrationBuilder.DropColumn(
                name: "PTS",
                table: "Lotes");

            migrationBuilder.DropColumn(
                name: "PesoSaca",
                table: "Lotes");

            migrationBuilder.DropColumn(
                name: "PrecoSaca",
                table: "Lotes");

            migrationBuilder.DropColumn(
                name: "QtdeSaca",
                table: "Lotes");

            migrationBuilder.DropColumn(
                name: "SementesPorMetro",
                table: "Lotes");

            migrationBuilder.RenameColumn(
                name: "SementesTotal",
                table: "Lotes",
                newName: "Tamanho");

            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "Lotes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
