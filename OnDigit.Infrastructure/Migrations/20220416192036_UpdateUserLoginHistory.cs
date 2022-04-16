using Microsoft.EntityFrameworkCore.Migrations;

namespace OnDigit.Infrastructure.Migrations
{
    public partial class UpdateUserLoginHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "26e2f8c4-9876-463e-a6c8-d1547d0cd0e0");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "353fd52b-0882-47bd-96c7-60a9fa4da1aa");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "37345090-a9c6-4c1a-8a09-f87b76c32ce8");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "4b0ce521-39ce-41e8-bee2-e66ae2f4ad02");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "53e68540-dcdc-4df8-8a0f-464ce4ee472a");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "5866b1a5-b6c9-4add-887e-26504a8be6af");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "65f0f0b8-7200-4b01-9f88-ca4fa01755c5");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "6edddbba-bf8c-4d2e-b8fc-c98d91418d7e");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "86371ea7-803c-45c1-bd8d-2ff8d532d13a");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "a1515ef0-8dcb-47b2-964f-b5c31748f069");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "a4bebeef-5f65-473f-8759-f78b8d752498");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "be687152-da2b-4660-ac72-9cde3e337cc7");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "caed13cc-cebe-48b5-be92-059f362c1b71");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "e68c4027-1981-4b76-bba1-96bd487c6ecf");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "f10a95d9-d75f-44ed-bc21-41a3317fecb4");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                    { "5866b1a5-b6c9-4add-887e-26504a8be6af", 5f, "Book1", 1, null, "Book1", 9.99m },
                    { "a1515ef0-8dcb-47b2-964f-b5c31748f069", 4.4f, "Book2", 2, null, "Book2", 9.99m },
                    { "65f0f0b8-7200-4b01-9f88-ca4fa01755c5", 3.2f, "Book3", 3, null, "Book3", 9.99m },
                    { "be687152-da2b-4660-ac72-9cde3e337cc7", 3f, "Book4", 4, null, "Book4", 9.99m },
                    { "4b0ce521-39ce-41e8-bee2-e66ae2f4ad02", 2f, "Book5", 5, null, "Book5", 9.99m },
                    { "a4bebeef-5f65-473f-8759-f78b8d752498", 1f, "Book6", 6, null, "Book6", 9.99m },
                    { "353fd52b-0882-47bd-96c7-60a9fa4da1aa", 0.6f, "Book7", 7, null, "Book7", 9.99m }
                });

            migrationBuilder.InsertData(
                table: "Editions",
                columns: new[] { "Id", "Description", "GenreId", "ImageLink", "Name", "Price" },
                values: new object[,]
                {
                    { "26e2f8c4-9876-463e-a6c8-d1547d0cd0e0", "Book8", 8, null, "Book8", 9.99m },
                    { "caed13cc-cebe-48b5-be92-059f362c1b71", "Book9", 9, null, "Book9", 9.99m },
                    { "86371ea7-803c-45c1-bd8d-2ff8d532d13a", "Book10", 10, null, "Book10", 9.99m },
                    { "37345090-a9c6-4c1a-8a09-f87b76c32ce8", "Book11", 11, null, "Book11", 9.99m },
                    { "e68c4027-1981-4b76-bba1-96bd487c6ecf", "Book12", 12, null, "Book12", 9.99m },
                    { "53e68540-dcdc-4df8-8a0f-464ce4ee472a", "Book13", 13, null, "Book13", 9.99m },
                    { "f10a95d9-d75f-44ed-bc21-41a3317fecb4", "Book14", 14, null, "Book14", 9.99m },
                    { "6edddbba-bf8c-4d2e-b8fc-c98d91418d7e", "Book15", 15, null, "Book15", 9.99m }
                });
        }
    }
}
