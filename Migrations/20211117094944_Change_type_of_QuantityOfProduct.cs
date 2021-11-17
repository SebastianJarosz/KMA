using Microsoft.EntityFrameworkCore.Migrations;

namespace KMA.Migrations
{
    public partial class Change_type_of_QuantityOfProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "QuantityOfProduct",
                table: "MenuPostionToProduct",
                type: "real",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "QuantityOfProduct",
                table: "MenuPostionToProduct",
                type: "text",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }
    }
}
