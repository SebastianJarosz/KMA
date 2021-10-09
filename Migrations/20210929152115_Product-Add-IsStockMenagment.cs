using Microsoft.EntityFrameworkCore.Migrations;

namespace KMA.Migrations
{
    public partial class ProductAddIsStockMenagment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsStockMenagment",
                table: "Product",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsStockMenagment",
                table: "Product");
        }
    }
}
