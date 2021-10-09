using Microsoft.EntityFrameworkCore.Migrations;

namespace KMA.Migrations
{
    public partial class OrderAddIsReadybool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsReady",
                table: "OrderToMenuPostion",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsReady",
                table: "OrderToMenuPostion");
        }
    }
}
