using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OperationSystems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationSystems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Laptops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Processor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Display = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperationSystemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laptops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Laptops_OperationSystems_OperationSystemId",
                        column: x => x.OperationSystemId,
                        principalTable: "OperationSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "OperationSystems",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Windows" },
                    { 2, "macOS" },
                    { 3, "Linux" },
                    { 4, "MS DOS" }
                });

            migrationBuilder.InsertData(
                table: "Laptops",
                columns: new[] { "Id", "Display", "ImagePath", "Model", "OperationSystemId", "Price", "Processor" },
                values: new object[,]
                {
                    { 1, "13.3″ Full HD", "https://img.moyo.ua/img/gallery/4867/43/1104939_middle.jpg?1617223785", "Dell Latitude 5320", 1, 699m, "11th Gen Intel® Core i5" },
                    { 2, "11.6″ HD LED Display", "https://i5.walmartimages.com/asr/8d794c17-41b0-42b2-9e11-4c60bfd81af0_1.54a5a04f52a9a6f929e635df6d8c31e6.jpeg", "Samsung Chromebook 4 310XBA-KA1", 1, 199m, "Intel® Dual-Core" },
                    { 3, "13.3″ Full HD IPS Touch Screen", "https://www.notebookcheck-ru.com/uploads/tx_nbc2/LenovoIdeaPadFlex5-14IIL05__1__06.JPG", "Lenovo IdeaPad Flex 5", 3, 419m, "Intel® Core i3" },
                    { 4, "14” 4K Anti-glare", "https://hotline.ua/img/tx/132/13238035.jpg", "Dell Latitude E7420", 4, 899m, "11th Gen Intel Core i7" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Laptops_OperationSystemId",
                table: "Laptops",
                column: "OperationSystemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Laptops");

            migrationBuilder.DropTable(
                name: "OperationSystems");
        }
    }
}
