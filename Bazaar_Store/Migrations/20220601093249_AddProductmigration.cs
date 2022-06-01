using Microsoft.EntityFrameworkCore.Migrations;

namespace Bazaar_Store.Migrations
{
    public partial class AddProductmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desciption = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BarCode = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    DiscountPrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desciption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TodaysDeals = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Desciption", "Name" },
                values: new object[,]
                {
                    { 1, "Haneen@Gmail.com", "Shose" },
                    { 2, "Aladdin@Gmail.com", "T-shirt" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BarCode", "Desciption", "DiscountPrice", "Name", "Price", "TodaysDeals" },
                values: new object[,]
                {
                    { 1, 12345, "584632", "0%", "Nike", 12.0, "F" },
                    { 2, 12346, "894201", "15%", "IBM", 11.300000000000001, "T" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
