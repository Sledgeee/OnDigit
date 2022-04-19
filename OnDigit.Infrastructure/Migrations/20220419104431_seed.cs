using Microsoft.EntityFrameworkCore.Migrations;

namespace OnDigit.Infrastructure.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Editions",
                columns: new[] { "Id", "Description", "GenreId", "ImageUri", "Name", "Price", "Rating" },
                values: new object[,]
                {
                    { "84c60ae1-7c0b-4dbd-b9f8-37c9d3206fac", "Book1", 1, null, "Book1", 9.99m, 5f },
                    { "0d72308f-34b1-470e-93c5-fa9cb524756b", "Book2", 2, null, "Book2", 9.99m, 4.4f },
                    { "310b6266-9c11-4cc6-8bc7-198f04c4f753", "Book3", 3, null, "Book3", 9.99m, 3.2f },
                    { "14628a2f-287a-466c-81ff-8cb1e9dd25f9", "Book4", 4, null, "Book4", 9.99m, 3f },
                    { "5e816e35-2477-49b3-af96-5c5fa45b80c1", "Book5", 5, null, "Book5", 9.99m, 2f },
                    { "c85b4e26-72cb-4c26-bb65-d79990523eb1", "Book6", 6, null, "Book6", 9.99m, 1f },
                    { "91420ac4-3a51-4cd1-b287-e461dd88576f", "Book7", 7, null, "Book7", 9.99m, 0.6f }
                });

            migrationBuilder.InsertData(
                table: "Editions",
                columns: new[] { "Id", "Description", "GenreId", "ImageUri", "Name", "Price" },
                values: new object[,]
                {
                    { "c93eec40-3469-4c8a-8c77-81f8b52aaf3b", "Book8", 8, null, "Book8", 9.99m },
                    { "2641dd3d-c8d7-4d0b-81df-451dec1288f9", "Book9", 9, null, "Book9", 9.99m },
                    { "bc3c52cd-2d79-4fe5-a3d8-1c6ecdf5cc67", "Book10", 10, null, "Book10", 9.99m },
                    { "949d7c8e-eda7-4361-b827-0c5340a3d19c", "Book11", 11, null, "Book11", 9.99m },
                    { "f37a1582-586f-418c-b3aa-b383e80f5f98", "Book12", 12, null, "Book12", 9.99m },
                    { "b61db9ec-9164-4c51-94ad-2c56603e0bba", "Book13", 13, null, "Book13", 9.99m },
                    { "c85ae46b-eb28-4915-86a4-abcd9aa72e79", "Book14", 14, null, "Book14", 9.99m },
                    { "b1cd121e-de5b-4dd3-a15c-6806673b3b6d", "Book15", 15, null, "Book15", 9.99m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "0d72308f-34b1-470e-93c5-fa9cb524756b");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "14628a2f-287a-466c-81ff-8cb1e9dd25f9");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "2641dd3d-c8d7-4d0b-81df-451dec1288f9");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "310b6266-9c11-4cc6-8bc7-198f04c4f753");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "5e816e35-2477-49b3-af96-5c5fa45b80c1");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "84c60ae1-7c0b-4dbd-b9f8-37c9d3206fac");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "91420ac4-3a51-4cd1-b287-e461dd88576f");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "949d7c8e-eda7-4361-b827-0c5340a3d19c");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "b1cd121e-de5b-4dd3-a15c-6806673b3b6d");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "b61db9ec-9164-4c51-94ad-2c56603e0bba");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "bc3c52cd-2d79-4fe5-a3d8-1c6ecdf5cc67");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "c85ae46b-eb28-4915-86a4-abcd9aa72e79");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "c85b4e26-72cb-4c26-bb65-d79990523eb1");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "c93eec40-3469-4c8a-8c77-81f8b52aaf3b");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "f37a1582-586f-418c-b3aa-b383e80f5f98");

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
        }
    }
}
