using Microsoft.EntityFrameworkCore.Migrations;

namespace TaxAuditCommunity.Data.Migrations
{
    public partial class ProsoftEmpresas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Codigo = table.Column<string>(nullable: false),
                    Razao = table.Column<string>(nullable: true),
                    CNPJ = table.Column<string>(nullable: true),
                    IE = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Codigo);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_CNPJ",
                table: "Empresas",
                column: "CNPJ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empresas");
        }
    }
}
