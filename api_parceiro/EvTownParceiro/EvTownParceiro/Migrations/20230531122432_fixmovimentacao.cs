using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvTownParceiro.Migrations
{
    public partial class fixmovimentacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "QtdeMovimentacao",
                table: "MovimentacaoEstoque",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QtdeMovimentacao",
                table: "MovimentacaoEstoque");
        }
    }
}
