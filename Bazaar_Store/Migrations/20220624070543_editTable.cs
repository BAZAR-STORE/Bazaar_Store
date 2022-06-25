using Microsoft.EntityFrameworkCore.Migrations;

namespace Bazaar_Store.Migrations
{
    public partial class editTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.AddColumn<int>(
                name: "InStock",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BarCode", "CategoryId", "CategoryName", "Description", "DiscountPrice", "InStock", "Name", "Price", "TodaysDeals", "URL" },
                values: new object[,]
                {
                    { 10, 78413566, 4, null, "Comfort for running", "30%", 0, "Deall", 400.5, "F", null },
                    { 11, 78413566, 4, null, "Comfort for running", "30%", 0, "Deall", 400.5, "F", null },
                    { 12, 78413566, 4, null, "Comfort for running", "30%", 0, "Deall", 400.5, "F", null },
                    { 13, 78413566, 5, null, "Comfort for running", "30%", 0, "Deall", 400.5, "F", null },
                    { 14, 78413566, 5, null, "Comfort for running", "30%", 0, "Deall", 400.5, "F", null },
                    { 15, 78413566, 5, null, "Comfort for running", "30%", 0, "Deall", 400.5, "F", null },
                    { 16, 78413566, 6, null, "Comfort for running", "30%", 0, "Deall", 400.5, "F", null },
                    { 17, 78413566, 6, null, "Comfort for running", "30%", 0, "Deall", 400.5, "F", null },
                    { 18, 78413566, 6, null, "Comfort for running", "30%", 0, "Deall", 400.5, "F", null },
                    { 19, 78413566, 6, null, "Comfort for running", "30%", 0, "Deall", 400.5, "F", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DropColumn(
                name: "InStock",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
        }
    }
}
