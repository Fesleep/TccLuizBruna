using Microsoft.EntityFrameworkCore.Migrations;

namespace TCC.DataAccess.Migrations
{
    public partial class coordinatesDouble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Sul",
                table: "Lotes",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,6)");

            migrationBuilder.AlterColumn<double>(
                name: "Oeste",
                table: "Lotes",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,6)");

            migrationBuilder.AlterColumn<double>(
                name: "Norte",
                table: "Lotes",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,6)");

            migrationBuilder.AlterColumn<double>(
                name: "Leste",
                table: "Lotes",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,6)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Sul",
                table: "Lotes",
                type: "decimal(8,6)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "Oeste",
                table: "Lotes",
                type: "decimal(9,6)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "Norte",
                table: "Lotes",
                type: "decimal(8,6)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "Leste",
                table: "Lotes",
                type: "decimal(9,6)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
