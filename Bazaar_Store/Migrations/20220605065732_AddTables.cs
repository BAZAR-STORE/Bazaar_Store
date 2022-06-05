using Microsoft.EntityFrameworkCore.Migrations;

namespace Bazaar_Store.Migrations
{
    public partial class AddTables : Migration
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
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
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
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TodaysDeals = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Details", "Name" },
                values: new object[,]
                {
                    { 1, "Sport Shose", "Shose" },
                    { 2, "roblox girl", "T-shirt" },
                    { 3, "Octa-core (1x2.84 GHz Kryo 585 & 3x2.42 GHz Kryo 585 & 4x1.8 GHz Kryo 585) , 6GB RAM , 128GB Storage", "Tablet PC" },
                    { 4, "4-Cores Processor】 11th Generation Intel Core i5-1135G7, up to 4.2 GHz Turbo, 4 core, 8 thread, 8MB", "T-Barebone" },
                    { 5, "L.A. Girl, Pro Eyeshadow Palette, Mastery, 1.23 oz (35 g)", "Eyeshadow" },
                    { 6, "L'Oreal, Infallible 24H Fresh Wear, Foundation In A Powder, 120 Vanilla, 0.31 oz (9 g)", "T-Foundation" }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 6, "Dell is an American technology company that develops, sells, repairs, and supports computers and related products and services, and is owned by its parent company of Dell Technologies", "Deall" },
                    { 5, "L'Oréal S.A. (French pronunciation: ​[lɔʁeal]) is a French personal care company headquartered in Clichy, Hauts-de-Seine[2] with a registered office in Paris", "L'Oreal" },
                    { 4, " eyeliner, mascara, primer, lipstick, lipgloss, blush, foundation,", "L.A. Girl" },
                    { 3, " HP, was an American multinational information technology company headquartered in Palo Alto, California. ", "HP" },
                    { 2, "is a Spanish clothing and accessories retailer based in Narón (A Coruña), Galicia founded in 1991.[1] It is part of Inditex, owner of Zara and Bershka brands. The name came from the word pull like pull from the shelf and bear", "IBM" },
                    { 1, "is an American multinational corporation that is engaged in the design, development, manufacturing, and worldwide marketing and sales of footwear, apparel, equipment, accessories, and services. The company is headquartered near Beaverton, Oregon, in the Portland metropolitan area.[3] It is the world's largest supplier of athletic shoes and apparel and a major manufacturer of sports equipment, with revenue in excess of US$37.4 billion in its fiscal year 2020 (ending May 31, 2020).[4] As of 2020, it employed 76,700 people worldwide.[5] In 2020 the brand alone was valued in excess of $32 billion, making it the most valuable brand among sports businesses.[6] Previously, in 2017, the Nike brand was valued at $29.6 billion.[7] Nike ranked 89th in the 2018 Fortune 500 list of the largest United States corporations by total revenue.[8]The company was founded on January 25,1964, as Blue Ribbon Sports,by Bill Bowerman and Phil Knight,and officially became Nike,", "Nike" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BarCode", "CategoryId", "Description", "DiscountPrice", "Name", "Price", "TodaysDeals" },
                values: new object[,]
                {
                    { 1, 34645768, null, "Comfort for running", "0%", "Nike Shoes", 12.0, "F" },
                    { 2, 4534676, null, "IBM P4 945G System Board For ThinkCentre A52 73P0780 41X0436", "15%", "IBM", 11.300000000000001, "T" },
                    { 3, 985012, null, "easy to use", "5%", "HP", 635.89999999999998, "F" },
                    { 4, 1403875, null, "Safe on the skin", "0%", "L.A. Girl", 9.0999999999999996, "T" },
                    { 5, 235752, null, "Safe on the skin", "50%", "L'Oreal", 25.600000000000001, "T" },
                    { 6, 78413566, null, "Comfort for running", "30%", "Deall", 400.5, "F" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
