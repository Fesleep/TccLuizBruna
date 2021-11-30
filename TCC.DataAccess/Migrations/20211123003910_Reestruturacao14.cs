using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCC.DataAccess.Migrations
{
    public partial class Reestruturacao14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lotes");

            migrationBuilder.CreateTable(
                name: "Plantacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PlantasTotal = table.Column<double>(type: "float", nullable: false),
                    PlantasPorMetro = table.Column<double>(type: "float", nullable: false),
                    SementesPorMetro = table.Column<double>(type: "float", nullable: false),
                    SementesTotal = table.Column<double>(type: "float", nullable: false),
                    PesoTotalSementes = table.Column<double>(type: "float", nullable: false),
                    QuantidadeDeSacas = table.Column<double>(type: "float", nullable: false),
                    CustoPorHectare = table.Column<decimal>(type: "Money", nullable: false),
                    CustoTotalPlantacao = table.Column<decimal>(type: "Money", nullable: false),
                    SementeId = table.Column<int>(type: "int", nullable: false),
                    CampoId = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deletado = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plantacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plantacoes_Campos_CampoId",
                        column: x => x.CampoId,
                        principalTable: "Campos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plantacoes_Sementes_SementeId",
                        column: x => x.SementeId,
                        principalTable: "Sementes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plantacoes_CampoId",
                table: "Plantacoes",
                column: "CampoId");

            migrationBuilder.CreateIndex(
                name: "IX_Plantacoes_SementeId",
                table: "Plantacoes",
                column: "SementeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plantacoes");

            migrationBuilder.CreateTable(
                name: "Lotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    CampoId = table.Column<int>(type: "int", nullable: false),
                    CustoPorHectare = table.Column<decimal>(type: "Money", nullable: false),
                    CustoTotalPlantacao = table.Column<decimal>(type: "Money", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deletado = table.Column<bool>(type: "bit", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PesoTotalSementes = table.Column<double>(type: "float", nullable: false),
                    PlantasPorMetro = table.Column<double>(type: "float", nullable: false),
                    PlantasTotal = table.Column<double>(type: "float", nullable: false),
                    QuantidadeDeSacas = table.Column<double>(type: "float", nullable: false),
                    SementeId = table.Column<int>(type: "int", nullable: false),
                    SementesPorMetro = table.Column<double>(type: "float", nullable: false),
                    SementesTotal = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lotes_Campos_CampoId",
                        column: x => x.CampoId,
                        principalTable: "Campos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lotes_Sementes_SementeId",
                        column: x => x.SementeId,
                        principalTable: "Sementes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lotes_CampoId",
                table: "Lotes",
                column: "CampoId");

            migrationBuilder.CreateIndex(
                name: "IX_Lotes_SementeId",
                table: "Lotes",
                column: "SementeId");
        }
    }
}
