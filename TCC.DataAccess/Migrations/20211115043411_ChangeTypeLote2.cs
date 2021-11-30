using Microsoft.EntityFrameworkCore.Migrations;

namespace TCC.DataAccess.Migrations
{
    public partial class ChangeTypeLote2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PrecoSaca",
                table: "Lotes",
                type: "Money",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "CustoPlantacao",
                table: "Lotes",
                type: "Money",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "CustoHectare",
                table: "Lotes",
                type: "Money",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "PrecoSaca",
                table: "Lotes",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Money");

            migrationBuilder.AlterColumn<double>(
                name: "CustoPlantacao",
                table: "Lotes",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Money");

            migrationBuilder.AlterColumn<double>(
                name: "CustoHectare",
                table: "Lotes",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Money");
        }
    }
}
