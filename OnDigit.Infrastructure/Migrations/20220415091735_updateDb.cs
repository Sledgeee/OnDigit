using Microsoft.EntityFrameworkCore.Migrations;

namespace OnDigit.Infrastructure.Migrations
{
    public partial class updateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "015b9648-1a2c-4f56-9356-349e9289389d");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "078c0501-cd69-46b5-bc7f-f2cc05965932");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "1668a7d4-c355-46f6-b6c5-7a7020fe1bd8");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "173d13a6-a845-4a1b-b39e-a736418d191a");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "2132e74d-d3d4-47a1-974d-2a6c34797ca2");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "23e041ee-d240-4a81-88a0-c2580e6ec513");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "36221964-2a4f-4727-a406-02a25a898d5e");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "40d3f3c6-a1ce-476f-957e-6147e7f976fc");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "4ac57bcc-2ea8-468e-9ce6-6040915302da");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "4d7afb3d-24ab-4546-a143-f900d9f6ef69");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "7dac9b51-db4d-4770-aa4d-30a86fbbb95c");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "acb41d83-d741-4ea9-8ccd-959a9ecfb71d");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "d398008b-a9a0-4425-a49f-09888c470b79");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "e268df1c-28b0-452b-b681-45c028282491");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "f00eafb5-7670-4825-b730-70fb53384ad1");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "Id", "Description", "GenreId", "ImageLink", "Name", "Price" },
                values: new object[,]
                {
                    { "40d3f3c6-a1ce-476f-957e-6147e7f976fc", "Book1", 1, null, "Book1", 9.99m },
                    { "23e041ee-d240-4a81-88a0-c2580e6ec513", "Book2", 2, null, "Book2", 9.99m },
                    { "f00eafb5-7670-4825-b730-70fb53384ad1", "Book3", 3, null, "Book3", 9.99m },
                    { "078c0501-cd69-46b5-bc7f-f2cc05965932", "Book4", 4, null, "Book4", 9.99m },
                    { "4ac57bcc-2ea8-468e-9ce6-6040915302da", "Book5", 5, null, "Book5", 9.99m },
                    { "e268df1c-28b0-452b-b681-45c028282491", "Book6", 6, null, "Book6", 9.99m },
                    { "1668a7d4-c355-46f6-b6c5-7a7020fe1bd8", "Book7", 7, null, "Book7", 9.99m },
                    { "4d7afb3d-24ab-4546-a143-f900d9f6ef69", "Book8", 8, null, "Book8", 9.99m },
                    { "2132e74d-d3d4-47a1-974d-2a6c34797ca2", "Book9", 9, null, "Book9", 9.99m },
                    { "d398008b-a9a0-4425-a49f-09888c470b79", "Book10", 10, null, "Book10", 9.99m },
                    { "015b9648-1a2c-4f56-9356-349e9289389d", "Book11", 11, null, "Book11", 9.99m },
                    { "36221964-2a4f-4727-a406-02a25a898d5e", "Book12", 12, null, "Book12", 9.99m },
                    { "7dac9b51-db4d-4770-aa4d-30a86fbbb95c", "Book13", 13, null, "Book13", 9.99m },
                    { "173d13a6-a845-4a1b-b39e-a736418d191a", "Book14", 14, null, "Book14", 9.99m },
                    { "acb41d83-d741-4ea9-8ccd-959a9ecfb71d", "Book15", 15, null, "Book15", 9.99m }
                });
        }
    }
}
