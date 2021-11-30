using Microsoft.EntityFrameworkCore.Migrations;

namespace TCC.DataAccess.Migrations
{
    public partial class AddStoredProcForTiposAtividade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROC usp_GetTiposAtividade 
                                    AS 
                                    BEGIN 
                                     SELECT * FROM   dbo.TiposAtividade 
                                    END");

            migrationBuilder.Sql(@"CREATE PROC usp_GetTipoAtividade
                                    @Id int 
                                    AS 
                                    BEGIN 
                                     SELECT * FROM   dbo.TiposAtividade  WHERE  (Id = @Id) 
                                    END ");

            migrationBuilder.Sql(@"CREATE PROC usp_UpdateTipoAtividade
	                                @Id int,
	                                @Nome varchar(100)
                                    AS 
                                    BEGIN 
                                     UPDATE dbo.TiposAtividade
                                     SET  Nome = @Nome
                                     WHERE  Id = @Id
                                    END");

            migrationBuilder.Sql(@"CREATE PROC usp_DeleteTipoAtividade
	                                @Id int
                                    AS 
                                    BEGIN 
                                     DELETE FROM dbo.TiposAtividade
                                     WHERE  Id = @Id
                                    END");

            migrationBuilder.Sql(@"CREATE PROC usp_CreateTipoAtividade
                                   @Nome varchar(100)
                                   AS 
                                   BEGIN 
                                    INSERT INTO dbo.TiposAtividade(Nome)
                                    VALUES (@Nome)
                                   END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE usp_GetTiposAtividade");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_GetTipoAtividade");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_UpdateTipoAtividade");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_DeleteTipoAtividade");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_CreateTipoAtividade");
        }
    }
}
