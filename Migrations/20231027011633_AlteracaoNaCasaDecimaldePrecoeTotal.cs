using Microsoft.EntityFrameworkCore.Migrations;

namespace CoffeOnPoint.Migrations
{
    public partial class AlteracaoNaCasaDecimaldePrecoeTotal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Preco",
                table: "Produto",
                type: "Decimal(4,2)",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal",
                oldMaxLength: 8);

            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "Pedido",
                type: "DECIMAL(5,2)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL",
                oldMaxLength: 5);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Preco",
                table: "Produto",
                type: "Decimal",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(4,2)",
                oldMaxLength: 8);

            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "Pedido",
                type: "DECIMAL",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(5,2)",
                oldMaxLength: 5);
        }
    }
}
