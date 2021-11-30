using Microsoft.EntityFrameworkCore.Migrations;

namespace TCC.DataAccess.Migrations
{
    public partial class Reestruturacao2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sacas_Culturas_CulturaId",
                table: "Sacas");

            migrationBuilder.DropForeignKey(
                name: "FK_Sementes_Culturas_CulturaId",
                table: "Sementes");

            migrationBuilder.DropIndex(
                name: "IX_Sacas_CulturaId",
                table: "Sacas");

            migrationBuilder.DropColumn(
                name: "CulturaId",
                table: "Sacas");

            migrationBuilder.AlterColumn<int>(
                name: "CulturaId",
                table: "Sementes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "SacaId",
                table: "Sementes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SementeId",
                table: "Lotes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sementes_SacaId",
                table: "Sementes",
                column: "SacaId");

            migrationBuilder.CreateIndex(
                name: "IX_Lotes_SementeId",
                table: "Lotes",
                column: "SementeId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Sementes_Sacas_SacaId",
                table: "Sementes",
                column: "SacaId",
                principalTable: "Sacas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lotes_Sementes_SementeId",
                table: "Lotes");

            migrationBuilder.DropForeignKey(
                name: "FK_Sementes_Culturas_CulturaId",
                table: "Sementes");

            migrationBuilder.DropForeignKey(
                name: "FK_Sementes_Sacas_SacaId",
                table: "Sementes");

            migrationBuilder.DropIndex(
                name: "IX_Sementes_SacaId",
                table: "Sementes");

            migrationBuilder.DropIndex(
                name: "IX_Lotes_SementeId",
                table: "Lotes");

            migrationBuilder.DropColumn(
                name: "SacaId",
                table: "Sementes");

            migrationBuilder.DropColumn(
                name: "SementeId",
                table: "Lotes");

            migrationBuilder.AlterColumn<int>(
                name: "CulturaId",
                table: "Sementes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CulturaId",
                table: "Sacas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sacas_CulturaId",
                table: "Sacas",
                column: "CulturaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sacas_Culturas_CulturaId",
                table: "Sacas",
                column: "CulturaId",
                principalTable: "Culturas",
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
    }
}
