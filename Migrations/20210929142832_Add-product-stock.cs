using Microsoft.EntityFrameworkCore.Migrations;

namespace KMA.Migrations
{
    public partial class Addproductstock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductStock",
                columns: table => new
                {
                    StockGuid = table.Column<string>(type: "text", nullable: false),
                    ProductCode = table.Column<string>(type: "text", nullable: true),
                    Quantity = table.Column<float>(type: "real", nullable: false),
                    SotckStaus = table.Column<int>(type: "integer", nullable: false),
                    IsBasic = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStock", x => x.StockGuid);
                    table.ForeignKey(
                        name: "FK_ProductStock_Product_ProductCode",
                        column: x => x.ProductCode,
                        principalTable: "Product",
                        principalColumn: "ProductCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductStock_ProductCode",
                table: "ProductStock",
                column: "ProductCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductStock");
        }
    }
}
