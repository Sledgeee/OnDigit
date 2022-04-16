using Microsoft.EntityFrameworkCore.Migrations;

namespace OnDigit.Infrastructure.Migrations
{
    public partial class UpdateUserLoginHistoryColumnDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "00ccf23e-ed85-43bc-904f-dac593dadfc2");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "1c251f3b-fab7-42e2-a254-0869840e0e21");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "235c13dd-9bd0-437c-991b-563166730db8");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "33315d76-367f-48b6-8cc9-729c2609a9b0");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "3b158b3d-4eb5-40df-9962-94b851fde246");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "4094d7d3-fef7-4163-bb58-2327ff79e304");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "490c1641-04de-4b5c-abd3-89602af716f4");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "7c977be4-a8d6-4cdb-ae88-c643dceda08d");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "811f3329-50f8-462b-825d-5bc49b450810");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "969afe8b-69ec-45d8-9db9-fc1863237228");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "9acddcb8-d03a-46e8-b214-f917ddde3f79");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "eb225b1b-247b-45cc-bdaa-507f2ac60e2f");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "f04d394c-f86d-4bbd-b358-180e4857a846");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "f0b18ca6-acf7-4ca3-8556-13d761d48b2b");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "f7eaf08d-9bb2-4ce0-8ac3-0595f062ece9");

            migrationBuilder.RenameColumn(
                name: "DateLogin",
                table: "UsersLoginHistory",
                newName: "DateLogined");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "DateLogined",
                table: "UsersLoginHistory",
                newName: "DateLogin");

            migrationBuilder.InsertData(
                table: "Editions",
                columns: new[] { "Id", "AverageStars", "Description", "GenreId", "ImageLink", "Name", "Price" },
                values: new object[,]
                {
                    { "235c13dd-9bd0-437c-991b-563166730db8", 5f, "Book1", 1, null, "Book1", 9.99m },
                    { "7c977be4-a8d6-4cdb-ae88-c643dceda08d", 4.4f, "Book2", 2, null, "Book2", 9.99m },
                    { "4094d7d3-fef7-4163-bb58-2327ff79e304", 3.2f, "Book3", 3, null, "Book3", 9.99m },
                    { "f7eaf08d-9bb2-4ce0-8ac3-0595f062ece9", 3f, "Book4", 4, null, "Book4", 9.99m },
                    { "3b158b3d-4eb5-40df-9962-94b851fde246", 2f, "Book5", 5, null, "Book5", 9.99m },
                    { "811f3329-50f8-462b-825d-5bc49b450810", 1f, "Book6", 6, null, "Book6", 9.99m },
                    { "f04d394c-f86d-4bbd-b358-180e4857a846", 0.6f, "Book7", 7, null, "Book7", 9.99m }
                });

            migrationBuilder.InsertData(
                table: "Editions",
                columns: new[] { "Id", "Description", "GenreId", "ImageLink", "Name", "Price" },
                values: new object[,]
                {
                    { "490c1641-04de-4b5c-abd3-89602af716f4", "Book8", 8, null, "Book8", 9.99m },
                    { "33315d76-367f-48b6-8cc9-729c2609a9b0", "Book9", 9, null, "Book9", 9.99m },
                    { "f0b18ca6-acf7-4ca3-8556-13d761d48b2b", "Book10", 10, null, "Book10", 9.99m },
                    { "1c251f3b-fab7-42e2-a254-0869840e0e21", "Book11", 11, null, "Book11", 9.99m },
                    { "969afe8b-69ec-45d8-9db9-fc1863237228", "Book12", 12, null, "Book12", 9.99m },
                    { "9acddcb8-d03a-46e8-b214-f917ddde3f79", "Book13", 13, null, "Book13", 9.99m },
                    { "eb225b1b-247b-45cc-bdaa-507f2ac60e2f", "Book14", 14, null, "Book14", 9.99m },
                    { "00ccf23e-ed85-43bc-904f-dac593dadfc2", "Book15", 15, null, "Book15", 9.99m }
                });
        }
    }
}
