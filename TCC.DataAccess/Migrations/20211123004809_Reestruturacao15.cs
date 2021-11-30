using Microsoft.EntityFrameworkCore.Migrations;

namespace TCC.DataAccess.Migrations
{
    public partial class Reestruturacao15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plantacoes_Campos_CampoId",
                table: "Plantacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Campos",
                table: "Campos");

            migrationBuilder.RenameTable(
                name: "Campos",
                newName: "Lotes");

            migrationBuilder.RenameColumn(
                name: "CampoId",
                table: "Plantacoes",
                newName: "LoteId");

            migrationBuilder.RenameIndex(
                name: "IX_Plantacoes_CampoId",
                table: "Plantacoes",
                newName: "IX_Plantacoes_LoteId");

            migrationBuilder.AlterColumn<string>(
                name: "MetragemLinear",
                table: "Lotes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lotes",
                table: "Lotes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Plantacoes_Lotes_LoteId",
                table: "Plantacoes",
                column: "LoteId",
                principalTable: "Lotes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plantacoes_Lotes_LoteId",
                table: "Plantacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lotes",
                table: "Lotes");

            migrationBuilder.RenameTable(
                name: "Lotes",
                newName: "Campos");

            migrationBuilder.RenameColumn(
                name: "LoteId",
                table: "Plantacoes",
                newName: "CampoId");

            migrationBuilder.RenameIndex(
                name: "IX_Plantacoes_LoteId",
                table: "Plantacoes",
                newName: "IX_Plantacoes_CampoId");

            migrationBuilder.AlterColumn<string>(
                name: "MetragemLinear",
                table: "Campos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Campos",
                table: "Campos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Plantacoes_Campos_CampoId",
                table: "Plantacoes",
                column: "CampoId",
                principalTable: "Campos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
