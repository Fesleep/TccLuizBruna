using Microsoft.EntityFrameworkCore.Migrations;

namespace TCC.DataAccess.Migrations
{
    public partial class Reestruturacao10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lotes_Campos_CampoId",
                table: "Lotes");

            migrationBuilder.AlterColumn<int>(
                name: "CampoId",
                table: "Lotes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Lotes_Campos_CampoId",
                table: "Lotes",
                column: "CampoId",
                principalTable: "Campos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lotes_Campos_CampoId",
                table: "Lotes");

            migrationBuilder.AlterColumn<int>(
                name: "CampoId",
                table: "Lotes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Lotes_Campos_CampoId",
                table: "Lotes",
                column: "CampoId",
                principalTable: "Campos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
