using Microsoft.EntityFrameworkCore.Migrations;

namespace OnDigit.Infrastructure.Migrations
{
    public partial class CartRenamedToBasket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartEdition");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "124f0507-8fb9-4393-b61f-789bbfab5e4b");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "16308c41-07ba-48f7-b4d0-6044c6cfe81a");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "233555e0-8d9b-497d-bac7-bb947eca5479");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "3d210498-e9f8-4453-b7e0-7a1a38081fea");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "430bc4b5-2848-4b1a-945c-6460c027eda1");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "43b0383d-49c0-43db-ba20-e49b8058e8e6");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "65cfe07b-47ff-40b0-9571-2a1448ef1143");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "939ce2f4-d728-4b13-8526-c585d8bc748f");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "97c588df-7921-43a6-918c-bfc274416f28");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "aa2fa016-7ecb-4b0f-b0c9-f027c66aefa4");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "abf186ce-40c0-4b90-9403-8c0009de8cd8");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "b1e9f6ca-1d0e-4bd0-874f-85d56cca81d1");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "d29dd343-4852-4e91-8056-282f9d619993");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "ed8ff430-fa8d-4ad8-91de-2d9e3b81ac42");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "f3ca30a5-16af-4567-a551-85f553c9b311");

            migrationBuilder.CreateTable(
                name: "BasketEdition",
                columns: table => new
                {
                    BasketsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EditionsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketEdition", x => new { x.BasketsId, x.EditionsId });
                    table.ForeignKey(
                        name: "FK_BasketEdition_Baskets_BasketsId",
                        column: x => x.BasketsId,
                        principalTable: "Baskets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasketEdition_Editions_EditionsId",
                        column: x => x.EditionsId,
                        principalTable: "Editions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Editions",
                columns: new[] { "Id", "Description", "GenreId", "ImageUri", "Name", "Price", "Rating" },
                values: new object[,]
                {
                    { "3931be03-c722-4a05-81f4-dfdabbfce3b2", "Book1", 1, null, "Book1", 9.99m, 5f },
                    { "cf6a6823-c44a-4768-ba11-d629af23e44a", "Book2", 2, null, "Book2", 9.99m, 4.4f },
                    { "e73defe6-ddf4-4d88-a55a-df81eaa1345a", "Book3", 3, null, "Book3", 9.99m, 3.2f },
                    { "4f8b3d77-f4f5-44cd-bb06-c2292dacbfe3", "Book4", 4, null, "Book4", 9.99m, 3f },
                    { "ed542b1f-2931-455c-9f5a-909bbb64baa0", "Book5", 5, null, "Book5", 9.99m, 2f },
                    { "5e11cb6a-68f4-4b67-a1e1-b4bee7f4817b", "Book6", 6, null, "Book6", 9.99m, 1f },
                    { "c9337274-729c-4814-87ae-51ac15fc607d", "Book7", 7, null, "Book7", 9.99m, 0.6f }
                });

            migrationBuilder.InsertData(
                table: "Editions",
                columns: new[] { "Id", "Description", "GenreId", "ImageUri", "Name", "Price" },
                values: new object[,]
                {
                    { "a089007e-36b6-46af-b7bd-29769192adf4", "Book8", 8, null, "Book8", 9.99m },
                    { "c0cfe9d7-02d2-4f62-96a0-78cffc6dd7ca", "Book9", 9, null, "Book9", 9.99m },
                    { "bd21e862-33b0-4790-9130-25d5bc995517", "Book10", 10, null, "Book10", 9.99m },
                    { "6dfc3acf-de21-4dde-a58a-3b30ed3532e0", "Book11", 11, null, "Book11", 9.99m },
                    { "fd906661-cfe5-4c35-8472-7cf109192e97", "Book12", 12, null, "Book12", 9.99m },
                    { "cca099d6-0bb6-41cf-ab60-11f3c9746b9b", "Book13", 13, null, "Book13", 9.99m },
                    { "71d3100c-cf4d-49f6-8903-424214836e91", "Book14", 14, null, "Book14", 9.99m },
                    { "e5311665-d4e0-477c-8ac5-ec82cec7d073", "Book15", 15, null, "Book15", 9.99m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasketEdition_EditionsId",
                table: "BasketEdition",
                column: "EditionsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketEdition");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "3931be03-c722-4a05-81f4-dfdabbfce3b2");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "4f8b3d77-f4f5-44cd-bb06-c2292dacbfe3");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "5e11cb6a-68f4-4b67-a1e1-b4bee7f4817b");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "6dfc3acf-de21-4dde-a58a-3b30ed3532e0");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "71d3100c-cf4d-49f6-8903-424214836e91");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "a089007e-36b6-46af-b7bd-29769192adf4");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "bd21e862-33b0-4790-9130-25d5bc995517");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "c0cfe9d7-02d2-4f62-96a0-78cffc6dd7ca");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "c9337274-729c-4814-87ae-51ac15fc607d");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "cca099d6-0bb6-41cf-ab60-11f3c9746b9b");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "cf6a6823-c44a-4768-ba11-d629af23e44a");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "e5311665-d4e0-477c-8ac5-ec82cec7d073");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "e73defe6-ddf4-4d88-a55a-df81eaa1345a");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "ed542b1f-2931-455c-9f5a-909bbb64baa0");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "fd906661-cfe5-4c35-8472-7cf109192e97");

            migrationBuilder.CreateTable(
                name: "CartEdition",
                columns: table => new
                {
                    BasketsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EditionsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartEdition", x => new { x.BasketsId, x.EditionsId });
                    table.ForeignKey(
                        name: "FK_CartEdition_Baskets_BasketsId",
                        column: x => x.BasketsId,
                        principalTable: "Baskets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartEdition_Editions_EditionsId",
                        column: x => x.EditionsId,
                        principalTable: "Editions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Editions",
                columns: new[] { "Id", "Description", "GenreId", "ImageUri", "Name", "Price", "Rating" },
                values: new object[,]
                {
                    { "939ce2f4-d728-4b13-8526-c585d8bc748f", "Book1", 1, null, "Book1", 9.99m, 5f },
                    { "f3ca30a5-16af-4567-a551-85f553c9b311", "Book2", 2, null, "Book2", 9.99m, 4.4f },
                    { "d29dd343-4852-4e91-8056-282f9d619993", "Book3", 3, null, "Book3", 9.99m, 3.2f },
                    { "b1e9f6ca-1d0e-4bd0-874f-85d56cca81d1", "Book4", 4, null, "Book4", 9.99m, 3f },
                    { "97c588df-7921-43a6-918c-bfc274416f28", "Book5", 5, null, "Book5", 9.99m, 2f },
                    { "aa2fa016-7ecb-4b0f-b0c9-f027c66aefa4", "Book6", 6, null, "Book6", 9.99m, 1f },
                    { "3d210498-e9f8-4453-b7e0-7a1a38081fea", "Book7", 7, null, "Book7", 9.99m, 0.6f }
                });

            migrationBuilder.InsertData(
                table: "Editions",
                columns: new[] { "Id", "Description", "GenreId", "ImageUri", "Name", "Price" },
                values: new object[,]
                {
                    { "65cfe07b-47ff-40b0-9571-2a1448ef1143", "Book8", 8, null, "Book8", 9.99m },
                    { "43b0383d-49c0-43db-ba20-e49b8058e8e6", "Book9", 9, null, "Book9", 9.99m },
                    { "16308c41-07ba-48f7-b4d0-6044c6cfe81a", "Book10", 10, null, "Book10", 9.99m },
                    { "124f0507-8fb9-4393-b61f-789bbfab5e4b", "Book11", 11, null, "Book11", 9.99m },
                    { "ed8ff430-fa8d-4ad8-91de-2d9e3b81ac42", "Book12", 12, null, "Book12", 9.99m },
                    { "abf186ce-40c0-4b90-9403-8c0009de8cd8", "Book13", 13, null, "Book13", 9.99m },
                    { "233555e0-8d9b-497d-bac7-bb947eca5479", "Book14", 14, null, "Book14", 9.99m },
                    { "430bc4b5-2848-4b1a-945c-6460c027eda1", "Book15", 15, null, "Book15", 9.99m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartEdition_EditionsId",
                table: "CartEdition",
                column: "EditionsId");
        }
    }
}
