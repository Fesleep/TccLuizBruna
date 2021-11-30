using Microsoft.EntityFrameworkCore.Migrations;

namespace TCC.DataAccess.Migrations
{
    public partial class Reestruturacao4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sementes_Sacas_SacaId",
                table: "Sementes");

            migrationBuilder.DropIndex(
                name: "IX_Sementes_SacaId",
                table: "Sementes");

            migrationBuilder.DropColumn(
                name: "SacaId",
                table: "Sementes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SacaId",
                table: "Sementes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sementes_SacaId",
                table: "Sementes",
                column: "SacaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sementes_Sacas_SacaId",
                table: "Sementes",
                column: "SacaId",
                principalTable: "Sacas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
