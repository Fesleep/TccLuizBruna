using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCC.DataAccess.Migrations
{
    public partial class Reestruturacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lotes_Produtos_ProdutoId",
                table: "Lotes");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Lotes_ProdutoId",
                table: "Lotes");

            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "TiposAtividade");

            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Lotes");

            migrationBuilder.DropColumn(
                name: "CustoHectare",
                table: "Lotes");

            migrationBuilder.DropColumn(
                name: "Espacamento",
                table: "Lotes");

            migrationBuilder.DropColumn(
                name: "MetragemLinear",
                table: "Lotes");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "Lotes");

            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Atividades");

            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "Tamanho",
                table: "Areas");

            migrationBuilder.RenameColumn(
                name: "QtdeSaca",
                table: "Lotes",
                newName: "QuantidadeDeSacas");

            migrationBuilder.RenameColumn(
                name: "PrecoSaca",
                table: "Lotes",
                newName: "CustoTotalPlantacao");

            migrationBuilder.RenameColumn(
                name: "PesoSaca",
                table: "Lotes",
                newName: "PlantasTotal");

            migrationBuilder.RenameColumn(
                name: "PTS",
                table: "Lotes",
                newName: "PlantasPorMetro");

            migrationBuilder.RenameColumn(
                name: "PMS",
                table: "Lotes",
                newName: "PesoTotalSementes");

            migrationBuilder.RenameColumn(
                name: "CustoPlantacao",
                table: "Lotes",
                newName: "CustoPorHectare");

            migrationBuilder.AddColumn<double>(
                name: "Hectares",
                table: "Areas",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MetragemLinear",
                table: "Areas",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "Culturas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EspacamentoEntreLinhas = table.Column<float>(type: "real", nullable: false),
                    ImagemUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deletado = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Culturas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sacas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PesoSacaKg = table.Column<double>(type: "float", nullable: false),
                    CustoSaca = table.Column<decimal>(type: "Money", nullable: false),
                    CulturaId = table.Column<int>(type: "int", nullable: false),
                    FornecedorId = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deletado = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sacas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sacas_Culturas_CulturaId",
                        column: x => x.CulturaId,
                        principalTable: "Culturas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sacas_Fornecedores_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sementes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CustoMilSementes = table.Column<decimal>(type: "Money", nullable: false),
                    PesoMilSementesKg = table.Column<float>(type: "real", nullable: false),
                    PoderGerminativo = table.Column<float>(type: "real", nullable: false),
                    FornecedorId = table.Column<int>(type: "int", nullable: false),
                    CulturaId = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deletado = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sementes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sementes_Culturas_CulturaId",
                        column: x => x.CulturaId,
                        principalTable: "Culturas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sementes_Fornecedores_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sacas_CulturaId",
                table: "Sacas",
                column: "CulturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Sacas_FornecedorId",
                table: "Sacas",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Sementes_CulturaId",
                table: "Sementes",
                column: "CulturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Sementes_FornecedorId",
                table: "Sementes",
                column: "FornecedorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sacas");

            migrationBuilder.DropTable(
                name: "Sementes");

            migrationBuilder.DropTable(
                name: "Culturas");

            migrationBuilder.DropColumn(
                name: "Hectares",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "MetragemLinear",
                table: "Areas");

            migrationBuilder.RenameColumn(
                name: "QuantidadeDeSacas",
                table: "Lotes",
                newName: "QtdeSaca");

            migrationBuilder.RenameColumn(
                name: "PlantasTotal",
                table: "Lotes",
                newName: "PesoSaca");

            migrationBuilder.RenameColumn(
                name: "PlantasPorMetro",
                table: "Lotes",
                newName: "PTS");

            migrationBuilder.RenameColumn(
                name: "PesoTotalSementes",
                table: "Lotes",
                newName: "PMS");

            migrationBuilder.RenameColumn(
                name: "CustoTotalPlantacao",
                table: "Lotes",
                newName: "PrecoSaca");

            migrationBuilder.RenameColumn(
                name: "CustoPorHectare",
                table: "Lotes",
                newName: "CustoPlantacao");

            migrationBuilder.AddColumn<int>(
                name: "Codigo",
                table: "TiposAtividade",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Codigo",
                table: "Lotes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "CustoHectare",
                table: "Lotes",
                type: "Money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<double>(
                name: "Espacamento",
                table: "Lotes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MetragemLinear",
                table: "Lotes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "ProdutoId",
                table: "Lotes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Codigo",
                table: "Fornecedores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Codigo",
                table: "Atividades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Codigo",
                table: "Areas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "Tamanho",
                table: "Areas",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    CustoMedio = table.Column<double>(type: "float", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deletado = table.Column<bool>(type: "bit", nullable: true),
                    FornecedorId = table.Column<int>(type: "int", nullable: false),
                    ImagemUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PrecoVenda = table.Column<double>(type: "float", nullable: false),
                    TempoColheita = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_Fornecedores_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lotes_ProdutoId",
                table: "Lotes",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_FornecedorId",
                table: "Produtos",
                column: "FornecedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lotes_Produtos_ProdutoId",
                table: "Lotes",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
