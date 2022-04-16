using Microsoft.EntityFrameworkCore.Migrations;

namespace OnDigit.Infrastructure.Migrations
{
    public partial class refresh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "01ba416d-bc9d-4a40-95fa-f552271b5a77");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "16346ce3-69d9-4cfc-95b4-5bcf6f8bc21c");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "180acba7-7db1-495b-84a5-486f4787c4b3");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "4636383c-3b74-4e93-bcbf-d2f8f99550fa");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "59dd1499-74de-45b8-a829-38429e53c23d");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "9482ed57-0949-4e90-b2e8-a5233e7139b0");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "94a58e9c-93e1-4bcc-b2cc-a176ec05a2d7");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "95e6c087-a434-47f4-9907-fcc362fbd358");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "9c811f5c-5680-472c-a90d-e151d2298344");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "9ce4f821-e276-4cde-9cf0-52b7d7edc48d");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "b6d91c31-4e8f-4344-80fb-0a01cc7cc68f");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "bc9ed4b3-1af8-44ba-b15a-33270b87b393");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "c6b7bd34-59b1-46ee-80cf-2d82b681f28a");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "df5d2bfc-a92e-452b-9d75-5797e6e39ffb");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "e14e9775-1c71-43fb-9e79-6d9c10d17366");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Editions",
                columns: new[] { "Id", "Description", "GenreId", "ImageLink", "Name", "Price" },
                values: new object[,]
                {
                    { "95e6c087-a434-47f4-9907-fcc362fbd358", "Book1", 1, null, "Book1", 9.99m },
                    { "bc9ed4b3-1af8-44ba-b15a-33270b87b393", "Book2", 2, null, "Book2", 9.99m },
                    { "e14e9775-1c71-43fb-9e79-6d9c10d17366", "Book3", 3, null, "Book3", 9.99m },
                    { "4636383c-3b74-4e93-bcbf-d2f8f99550fa", "Book4", 4, null, "Book4", 9.99m },
                    { "df5d2bfc-a92e-452b-9d75-5797e6e39ffb", "Book5", 5, null, "Book5", 9.99m },
                    { "9ce4f821-e276-4cde-9cf0-52b7d7edc48d", "Book6", 6, null, "Book6", 9.99m },
                    { "c6b7bd34-59b1-46ee-80cf-2d82b681f28a", "Book7", 7, null, "Book7", 9.99m },
                    { "16346ce3-69d9-4cfc-95b4-5bcf6f8bc21c", "Book8", 8, null, "Book8", 9.99m },
                    { "b6d91c31-4e8f-4344-80fb-0a01cc7cc68f", "Book9", 9, null, "Book9", 9.99m },
                    { "9c811f5c-5680-472c-a90d-e151d2298344", "Book10", 10, null, "Book10", 9.99m },
                    { "180acba7-7db1-495b-84a5-486f4787c4b3", "Book11", 11, null, "Book11", 9.99m },
                    { "9482ed57-0949-4e90-b2e8-a5233e7139b0", "Book12", 12, null, "Book12", 9.99m },
                    { "01ba416d-bc9d-4a40-95fa-f552271b5a77", "Book13", 13, null, "Book13", 9.99m },
                    { "59dd1499-74de-45b8-a829-38429e53c23d", "Book14", 14, null, "Book14", 9.99m },
                    { "94a58e9c-93e1-4bcc-b2cc-a176ec05a2d7", "Book15", 15, null, "Book15", 9.99m }
                });
        }
    }
}
