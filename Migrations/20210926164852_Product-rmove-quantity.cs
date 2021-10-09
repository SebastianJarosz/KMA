using Microsoft.EntityFrameworkCore.Migrations;

namespace KMA.Migrations
{
    public partial class Productrmovequantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Product");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Quantity",
                table: "Product",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
