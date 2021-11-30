using Microsoft.EntityFrameworkCore.Migrations;

namespace TCC.DataAccess.Migrations
{
    public partial class Reestruturacao19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Endereco",
                table: "Fornecedores",
                newName: "Rua");

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Fornecedores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Fornecedores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Fornecedores");

            migrationBuilder.RenameColumn(
                name: "Rua",
                table: "Fornecedores",
                newName: "Endereco");
        }
    }
}
