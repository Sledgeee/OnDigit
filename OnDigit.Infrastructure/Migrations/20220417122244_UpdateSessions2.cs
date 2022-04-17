using Microsoft.EntityFrameworkCore.Migrations;

namespace OnDigit.Infrastructure.Migrations
{
    public partial class UpdateSessions2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Sessions",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_MACHINE_KEY",
                table: "Sessions");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "0247839d-3f31-4962-9d5e-75f5f8632469");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "2a753e15-4b22-4bde-a7b9-aaa809ed4a3c");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "330d596d-720a-41e5-b8e1-689f67fbb862");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "399d1619-5310-491d-a78f-58c59a4b8dca");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "435ac46d-de3d-4d99-88d7-bffa5dbc4c8b");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "7c15864e-a9fc-41e6-9a21-0fbdbb3c4f48");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "85f65f5e-5ed5-4293-adae-e6c8de1581a9");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "a0565ab4-92c0-45de-ae85-f2808a3bd05a");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "c517b890-457f-449c-9f86-0e5729721883");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "c5487be7-490c-400c-8cf1-fd58517becca");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "c93c208f-378a-475f-bd40-2a04d2d02ef8");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "f6c61ea2-9492-47b5-8bd7-4cd5ffcec760");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "f70f6d1f-b852-479a-99ef-a340a09f7f70");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "fdbff924-da69-4c4a-aa11-762d8b049b5d");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "fe5e8f68-7c36-4274-9d94-a7f2c286d29c");

            migrationBuilder.AlterColumn<string>(
                name: "MACHINE_KEY",
                table: "Sessions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Sessions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sessions",
                table: "Sessions",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Editions",
                columns: new[] { "Id", "AverageStars", "Description", "GenreId", "ImageLink", "Name", "Price" },
                values: new object[,]
                {
                    { "28c04436-0bbe-4974-9a00-199ef8372e93", 5f, "Book1", 1, null, "Book1", 9.99m },
                    { "7a3388b1-e75f-42c9-ac09-2e4a1f7f475e", 4.4f, "Book2", 2, null, "Book2", 9.99m },
                    { "312cf01c-4f98-425f-9332-c3b022407670", 3.2f, "Book3", 3, null, "Book3", 9.99m },
                    { "2d7ec608-54db-4a71-a741-bcd3cccd468d", 3f, "Book4", 4, null, "Book4", 9.99m },
                    { "d7f37df5-9058-4862-aedb-032e6842dd32", 2f, "Book5", 5, null, "Book5", 9.99m },
                    { "00ff68b5-6b62-4064-ae86-efa2b6637f55", 1f, "Book6", 6, null, "Book6", 9.99m },
                    { "2db6e9e2-e500-4036-9dc8-a0f54e8ac562", 0.6f, "Book7", 7, null, "Book7", 9.99m }
                });

            migrationBuilder.InsertData(
                table: "Editions",
                columns: new[] { "Id", "Description", "GenreId", "ImageLink", "Name", "Price" },
                values: new object[,]
                {
                    { "da0b2053-fb21-40a8-a78b-b771cce26590", "Book8", 8, null, "Book8", 9.99m },
                    { "51e0de5e-12cf-483c-810e-0fa87ef6cee3", "Book9", 9, null, "Book9", 9.99m },
                    { "802cd5b6-3a0e-45d0-9b5f-a6888d23f0f8", "Book10", 10, null, "Book10", 9.99m },
                    { "e68b1a07-e57e-46ff-9f0a-d1b6b2566935", "Book11", 11, null, "Book11", 9.99m },
                    { "3ffd2363-272f-4219-9a74-2cb6e843d1d9", "Book12", 12, null, "Book12", 9.99m },
                    { "88f5b3a8-584e-4bad-9278-825fcebb844d", "Book13", 13, null, "Book13", 9.99m },
                    { "c5722fd7-2a01-4ef2-a23e-d7d0cd5901b5", "Book14", 14, null, "Book14", 9.99m },
                    { "bbcb76c3-27a1-4563-a823-4f9beced223d", "Book15", 15, null, "Book15", 9.99m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_UserId",
                table: "Sessions",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Sessions",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_UserId",
                table: "Sessions");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "00ff68b5-6b62-4064-ae86-efa2b6637f55");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "28c04436-0bbe-4974-9a00-199ef8372e93");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "2d7ec608-54db-4a71-a741-bcd3cccd468d");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "2db6e9e2-e500-4036-9dc8-a0f54e8ac562");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "312cf01c-4f98-425f-9332-c3b022407670");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "3ffd2363-272f-4219-9a74-2cb6e843d1d9");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "51e0de5e-12cf-483c-810e-0fa87ef6cee3");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "7a3388b1-e75f-42c9-ac09-2e4a1f7f475e");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "802cd5b6-3a0e-45d0-9b5f-a6888d23f0f8");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "88f5b3a8-584e-4bad-9278-825fcebb844d");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "bbcb76c3-27a1-4563-a823-4f9beced223d");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "c5722fd7-2a01-4ef2-a23e-d7d0cd5901b5");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "d7f37df5-9058-4862-aedb-032e6842dd32");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "da0b2053-fb21-40a8-a78b-b771cce26590");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "e68b1a07-e57e-46ff-9f0a-d1b6b2566935");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Sessions");

            migrationBuilder.AlterColumn<string>(
                name: "MACHINE_KEY",
                table: "Sessions",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sessions",
                table: "Sessions",
                column: "UserId");

            migrationBuilder.InsertData(
                table: "Editions",
                columns: new[] { "Id", "AverageStars", "Description", "GenreId", "ImageLink", "Name", "Price" },
                values: new object[,]
                {
                    { "fe5e8f68-7c36-4274-9d94-a7f2c286d29c", 5f, "Book1", 1, null, "Book1", 9.99m },
                    { "85f65f5e-5ed5-4293-adae-e6c8de1581a9", 4.4f, "Book2", 2, null, "Book2", 9.99m },
                    { "0247839d-3f31-4962-9d5e-75f5f8632469", 3.2f, "Book3", 3, null, "Book3", 9.99m },
                    { "c5487be7-490c-400c-8cf1-fd58517becca", 3f, "Book4", 4, null, "Book4", 9.99m },
                    { "fdbff924-da69-4c4a-aa11-762d8b049b5d", 2f, "Book5", 5, null, "Book5", 9.99m },
                    { "c93c208f-378a-475f-bd40-2a04d2d02ef8", 1f, "Book6", 6, null, "Book6", 9.99m },
                    { "f6c61ea2-9492-47b5-8bd7-4cd5ffcec760", 0.6f, "Book7", 7, null, "Book7", 9.99m }
                });

            migrationBuilder.InsertData(
                table: "Editions",
                columns: new[] { "Id", "Description", "GenreId", "ImageLink", "Name", "Price" },
                values: new object[,]
                {
                    { "435ac46d-de3d-4d99-88d7-bffa5dbc4c8b", "Book8", 8, null, "Book8", 9.99m },
                    { "f70f6d1f-b852-479a-99ef-a340a09f7f70", "Book9", 9, null, "Book9", 9.99m },
                    { "a0565ab4-92c0-45de-ae85-f2808a3bd05a", "Book10", 10, null, "Book10", 9.99m },
                    { "330d596d-720a-41e5-b8e1-689f67fbb862", "Book11", 11, null, "Book11", 9.99m },
                    { "2a753e15-4b22-4bde-a7b9-aaa809ed4a3c", "Book12", 12, null, "Book12", 9.99m },
                    { "c517b890-457f-449c-9f86-0e5729721883", "Book13", 13, null, "Book13", 9.99m },
                    { "7c15864e-a9fc-41e6-9a21-0fbdbb3c4f48", "Book14", 14, null, "Book14", 9.99m },
                    { "399d1619-5310-491d-a78f-58c59a4b8dca", "Book15", 15, null, "Book15", 9.99m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_MACHINE_KEY",
                table: "Sessions",
                column: "MACHINE_KEY",
                unique: true,
                filter: "[MACHINE_KEY] IS NOT NULL");
        }
    }
}
