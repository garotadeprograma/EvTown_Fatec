using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvTownParceiro.Migrations
{
    public partial class Venda4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataEvento",
                table: "Venda",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataEvento",
                table: "Venda");
        }
    }
}
