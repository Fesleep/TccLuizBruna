using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCC.DataAccess.Migrations
{
    public partial class Reestruturacao9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lotes_Areas_AreaId",
                table: "Lotes");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropIndex(
                name: "IX_Lotes_AreaId",
                table: "Lotes");

            migrationBuilder.DropColumn(
                name: "AreaId",
                table: "Lotes");

            migrationBuilder.AddColumn<int>(
                name: "CampoId",
                table: "Lotes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Campos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Hectares = table.Column<double>(type: "float", nullable: false),
                    MetragemLinear = table.Column<double>(type: "float", nullable: false),
                    Coordinates = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deletado = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lotes_CampoId",
                table: "Lotes",
                column: "CampoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lotes_Campos_CampoId",
                table: "Lotes",
                column: "CampoId",
                principalTable: "Campos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lotes_Campos_CampoId",
                table: "Lotes");

            migrationBuilder.DropTable(
                name: "Campos");

            migrationBuilder.DropIndex(
                name: "IX_Lotes_CampoId",
                table: "Lotes");

            migrationBuilder.DropColumn(
                name: "CampoId",
                table: "Lotes");

            migrationBuilder.AddColumn<int>(
                name: "AreaId",
                table: "Lotes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Coordinates = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deletado = table.Column<bool>(type: "bit", nullable: true),
                    Hectares = table.Column<double>(type: "float", nullable: false),
                    MetragemLinear = table.Column<double>(type: "float", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lotes_AreaId",
                table: "Lotes",
                column: "AreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lotes_Areas_AreaId",
                table: "Lotes",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
