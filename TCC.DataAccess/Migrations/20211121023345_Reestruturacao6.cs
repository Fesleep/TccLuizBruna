using Microsoft.EntityFrameworkCore.Migrations;

namespace TCC.DataAccess.Migrations
{
    public partial class Reestruturacao6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lotes_Sementes_SementeId",
                table: "Lotes");

            migrationBuilder.DropForeignKey(
                name: "FK_Sementes_Culturas_CulturaId",
                table: "Sementes");

            migrationBuilder.AlterColumn<int>(
                name: "CulturaId",
                table: "Sementes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SementeId",
                table: "Lotes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Lotes_Sementes_SementeId",
                table: "Lotes",
                column: "SementeId",
                principalTable: "Sementes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sementes_Culturas_CulturaId",
                table: "Sementes",
                column: "CulturaId",
                principalTable: "Culturas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lotes_Sementes_SementeId",
                table: "Lotes");

            migrationBuilder.DropForeignKey(
                name: "FK_Sementes_Culturas_CulturaId",
                table: "Sementes");

            migrationBuilder.AlterColumn<int>(
                name: "CulturaId",
                table: "Sementes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SementeId",
                table: "Lotes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Lotes_Sementes_SementeId",
                table: "Lotes",
                column: "SementeId",
                principalTable: "Sementes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sementes_Culturas_CulturaId",
                table: "Sementes",
                column: "CulturaId",
                principalTable: "Culturas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
