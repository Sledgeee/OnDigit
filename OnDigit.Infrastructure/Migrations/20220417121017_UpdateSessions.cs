using Microsoft.EntityFrameworkCore.Migrations;

namespace OnDigit.Infrastructure.Migrations
{
    public partial class UpdateSessions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Sessions");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Sessions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MACHINE_KEY",
                table: "Sessions",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "IsCanceledInAdvance",
                table: "Sessions",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "IsCanceledInAdvance",
                table: "Sessions");

            migrationBuilder.AlterColumn<string>(
                name: "MACHINE_KEY",
                table: "Sessions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Sessions",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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
                name: "IX_Sessions_UserId",
                table: "Sessions",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }
    }
}
