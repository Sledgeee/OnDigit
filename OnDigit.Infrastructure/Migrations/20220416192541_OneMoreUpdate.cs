using Microsoft.EntityFrameworkCore.Migrations;

namespace OnDigit.Infrastructure.Migrations
{
    public partial class OneMoreUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UsersLoginHistory_UserId",
                table: "UsersLoginHistory");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "1ad7e7e0-f432-4d61-bad5-8fe61440cd29");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "27ceb2d3-fea0-4c83-af61-2b28964d2ed8");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "42c9086e-41cc-4c80-a42c-025dfcaa4895");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "4b1c46c7-2d5b-4641-8d56-8c930854f5cd");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "69d899cd-98ed-450c-a122-d9df34d75d90");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "73e86c42-ced1-4795-9910-bf84b847f541");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "7b2703a6-a7bc-494a-82f9-68e36d72def8");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "82eb787e-7920-4e50-968b-756ca8ca4f44");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "90651d95-7c6f-4770-8e00-c56dab54fe82");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "a8aa1d34-5b8b-4f5e-9298-e0b855b55a1a");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "de085531-25f2-47ff-a56b-ae79d3f3de04");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "e3ff6895-0dea-4a35-bf08-adbe6e4fc4c2");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "e5ce5165-f7b6-498b-99d3-17a3f5612995");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "f96ffffc-f586-48dc-a353-ed25ae236ebb");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "fdc0b1dd-a29a-421b-b660-4655122ca7cf");

            migrationBuilder.InsertData(
                table: "Editions",
                columns: new[] { "Id", "AverageStars", "Description", "GenreId", "ImageLink", "Name", "Price" },
                values: new object[,]
                {
                    { "64e201a7-8ce8-462d-aac4-469e62dae388", 5f, "Book1", 1, null, "Book1", 9.99m },
                    { "eba41b2b-4ff5-4c89-b3d1-e990e69ef10a", 4.4f, "Book2", 2, null, "Book2", 9.99m },
                    { "46e3ba56-dc0f-4662-80c0-e25c7dbcc349", 3.2f, "Book3", 3, null, "Book3", 9.99m },
                    { "7f249b76-a713-48fa-873a-d615312e6e96", 3f, "Book4", 4, null, "Book4", 9.99m },
                    { "24a636f4-c01b-4ea2-9d2c-66d501bcf92e", 2f, "Book5", 5, null, "Book5", 9.99m },
                    { "835a97f6-58fa-4096-9910-59bd9be03a91", 1f, "Book6", 6, null, "Book6", 9.99m },
                    { "db2130d4-9360-45df-a73a-5b99bc214f05", 0.6f, "Book7", 7, null, "Book7", 9.99m }
                });

            migrationBuilder.InsertData(
                table: "Editions",
                columns: new[] { "Id", "Description", "GenreId", "ImageLink", "Name", "Price" },
                values: new object[,]
                {
                    { "347f1d1f-f4c7-47bc-a343-8b547f9689b8", "Book8", 8, null, "Book8", 9.99m },
                    { "8d441473-b71c-495b-9bee-9a0daa749f33", "Book9", 9, null, "Book9", 9.99m },
                    { "c55a9e6f-3e64-4abf-9f63-79e28d6c4759", "Book10", 10, null, "Book10", 9.99m },
                    { "58deb5c0-c044-4ce8-8f0a-15dbaf8d3ef5", "Book11", 11, null, "Book11", 9.99m },
                    { "132bc017-64a3-4247-b5ea-f96900977591", "Book12", 12, null, "Book12", 9.99m },
                    { "bdda7c39-5b95-4aad-9e11-50cedabfe408", "Book13", 13, null, "Book13", 9.99m },
                    { "4a70b7b3-9f35-4720-9969-7b43132602d7", "Book14", 14, null, "Book14", 9.99m },
                    { "f45f11db-5fb7-4eb9-9f89-da181558fe79", "Book15", 15, null, "Book15", 9.99m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersLoginHistory_UserId",
                table: "UsersLoginHistory",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UsersLoginHistory_UserId",
                table: "UsersLoginHistory");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "132bc017-64a3-4247-b5ea-f96900977591");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "24a636f4-c01b-4ea2-9d2c-66d501bcf92e");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "347f1d1f-f4c7-47bc-a343-8b547f9689b8");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "46e3ba56-dc0f-4662-80c0-e25c7dbcc349");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "4a70b7b3-9f35-4720-9969-7b43132602d7");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "58deb5c0-c044-4ce8-8f0a-15dbaf8d3ef5");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "64e201a7-8ce8-462d-aac4-469e62dae388");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "7f249b76-a713-48fa-873a-d615312e6e96");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "835a97f6-58fa-4096-9910-59bd9be03a91");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "8d441473-b71c-495b-9bee-9a0daa749f33");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "bdda7c39-5b95-4aad-9e11-50cedabfe408");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "c55a9e6f-3e64-4abf-9f63-79e28d6c4759");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "db2130d4-9360-45df-a73a-5b99bc214f05");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "eba41b2b-4ff5-4c89-b3d1-e990e69ef10a");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "f45f11db-5fb7-4eb9-9f89-da181558fe79");

            migrationBuilder.InsertData(
                table: "Editions",
                columns: new[] { "Id", "AverageStars", "Description", "GenreId", "ImageLink", "Name", "Price" },
                values: new object[,]
                {
                    { "69d899cd-98ed-450c-a122-d9df34d75d90", 5f, "Book1", 1, null, "Book1", 9.99m },
                    { "e3ff6895-0dea-4a35-bf08-adbe6e4fc4c2", 4.4f, "Book2", 2, null, "Book2", 9.99m },
                    { "4b1c46c7-2d5b-4641-8d56-8c930854f5cd", 3.2f, "Book3", 3, null, "Book3", 9.99m },
                    { "a8aa1d34-5b8b-4f5e-9298-e0b855b55a1a", 3f, "Book4", 4, null, "Book4", 9.99m },
                    { "fdc0b1dd-a29a-421b-b660-4655122ca7cf", 2f, "Book5", 5, null, "Book5", 9.99m },
                    { "73e86c42-ced1-4795-9910-bf84b847f541", 1f, "Book6", 6, null, "Book6", 9.99m },
                    { "42c9086e-41cc-4c80-a42c-025dfcaa4895", 0.6f, "Book7", 7, null, "Book7", 9.99m }
                });

            migrationBuilder.InsertData(
                table: "Editions",
                columns: new[] { "Id", "Description", "GenreId", "ImageLink", "Name", "Price" },
                values: new object[,]
                {
                    { "e5ce5165-f7b6-498b-99d3-17a3f5612995", "Book8", 8, null, "Book8", 9.99m },
                    { "90651d95-7c6f-4770-8e00-c56dab54fe82", "Book9", 9, null, "Book9", 9.99m },
                    { "1ad7e7e0-f432-4d61-bad5-8fe61440cd29", "Book10", 10, null, "Book10", 9.99m },
                    { "de085531-25f2-47ff-a56b-ae79d3f3de04", "Book11", 11, null, "Book11", 9.99m },
                    { "27ceb2d3-fea0-4c83-af61-2b28964d2ed8", "Book12", 12, null, "Book12", 9.99m },
                    { "f96ffffc-f586-48dc-a353-ed25ae236ebb", "Book13", 13, null, "Book13", 9.99m },
                    { "82eb787e-7920-4e50-968b-756ca8ca4f44", "Book14", 14, null, "Book14", 9.99m },
                    { "7b2703a6-a7bc-494a-82f9-68e36d72def8", "Book15", 15, null, "Book15", 9.99m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersLoginHistory_UserId",
                table: "UsersLoginHistory",
                column: "UserId",
                unique: true);
        }
    }
}
