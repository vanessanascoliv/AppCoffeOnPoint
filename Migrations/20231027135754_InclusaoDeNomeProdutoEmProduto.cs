using Microsoft.EntityFrameworkCore.Migrations;

namespace CoffeOnPoint.Migrations
{
    public partial class InclusaoDeNomeProdutoEmProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NomeProduto",
                table: "Pedido",
                type: "NVARCHAR(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeProduto",
                table: "Pedido");
        }
    }
}
