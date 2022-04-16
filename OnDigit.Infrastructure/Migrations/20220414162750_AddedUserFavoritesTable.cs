using Microsoft.EntityFrameworkCore.Migrations;

namespace OnDigit.Infrastructure.Migrations
{
    public partial class AddedUserFavoritesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "02c20983-3472-47f5-8c39-8be57c4828ea");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "3bdc50c5-831a-48b7-8b08-656d96b3bbda");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "5222199a-1ce5-4418-9023-882732eda11e");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "676f1946-755e-461b-8821-9a7bcc96036a");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "79d8f265-3c95-4efd-8bcd-8fdcb1f27852");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "82cbc862-f729-4838-b631-c1b9cac23bde");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "88bc5fb9-9e29-41cc-95fc-c68395d6b760");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "9833a619-0ec1-4bd9-873d-f256a11d97dd");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "9972e4a9-af8a-4d9f-98fd-236f554fe97d");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "9ea744f4-13b5-4149-8476-d72ccb4e8329");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "b5e11470-e70f-40d9-b957-f9b004010f3b");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "dae98619-931b-4485-89ea-7a5414277994");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "e45794b7-5c47-4171-be1d-b0cd90ee1249");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "ea018c02-77b3-4e13-9823-4346cd093ec6");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "edfb2820-8a69-4b28-824b-bd06f8eb454e");

            migrationBuilder.CreateTable(
                name: "UserFavorites",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EditionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFavorites", x => new { x.UserId, x.EditionId });
                });

            migrationBuilder.InsertData(
                table: "Editions",
                columns: new[] { "Id", "Description", "GenreId", "ImageLink", "Name", "Price" },
                values: new object[,]
                {
                    { "788752d7-7338-4287-8d16-432d910543f4", "Book1", 1, null, "Book1", 9.99m },
                    { "3193ed81-0ab5-4df7-a89c-90d06f351ff2", "Book2", 2, null, "Book2", 9.99m },
                    { "568bfd92-6312-4348-b2d6-061bd66e5526", "Book3", 3, null, "Book3", 9.99m },
                    { "3a11e000-dfe1-4f35-947f-fceab6625e1d", "Book4", 4, null, "Book4", 9.99m },
                    { "5b2f650a-e72c-43e9-bf30-649139a3af38", "Book5", 5, null, "Book5", 9.99m },
                    { "804bb7c2-ff82-4469-b41d-d50ebe3a76ac", "Book6", 6, null, "Book6", 9.99m },
                    { "51095e10-72ca-40e7-b0c8-30a363e4ee86", "Book7", 7, null, "Book7", 9.99m },
                    { "70e4832b-ebd9-4251-a585-2b7233520818", "Book8", 8, null, "Book8", 9.99m },
                    { "73b325be-94e1-48a2-bd49-1009cac0bc3d", "Book9", 9, null, "Book9", 9.99m },
                    { "32b2b2c8-c446-4f50-b63d-3d46bbd890e8", "Book10", 10, null, "Book10", 9.99m },
                    { "a92c210f-57c8-4f2c-aafa-1929e22e6c8d", "Book11", 11, null, "Book11", 9.99m },
                    { "4a44225c-b88e-4792-9ff2-28e92a37dbb0", "Book12", 12, null, "Book12", 9.99m },
                    { "6b2fcbc2-f82d-4bd4-bcd6-a7d9fdcecf4f", "Book13", 13, null, "Book13", 9.99m },
                    { "51ea9e4c-3da0-4803-a293-573492864e47", "Book14", 14, null, "Book14", 9.99m },
                    { "b5633c35-f00b-46ef-97af-f694f578ccfc", "Book15", 15, null, "Book15", 9.99m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserFavorites");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "3193ed81-0ab5-4df7-a89c-90d06f351ff2");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "32b2b2c8-c446-4f50-b63d-3d46bbd890e8");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "3a11e000-dfe1-4f35-947f-fceab6625e1d");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "4a44225c-b88e-4792-9ff2-28e92a37dbb0");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "51095e10-72ca-40e7-b0c8-30a363e4ee86");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "51ea9e4c-3da0-4803-a293-573492864e47");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "568bfd92-6312-4348-b2d6-061bd66e5526");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "5b2f650a-e72c-43e9-bf30-649139a3af38");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "6b2fcbc2-f82d-4bd4-bcd6-a7d9fdcecf4f");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "70e4832b-ebd9-4251-a585-2b7233520818");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "73b325be-94e1-48a2-bd49-1009cac0bc3d");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "788752d7-7338-4287-8d16-432d910543f4");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "804bb7c2-ff82-4469-b41d-d50ebe3a76ac");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "a92c210f-57c8-4f2c-aafa-1929e22e6c8d");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "b5633c35-f00b-46ef-97af-f694f578ccfc");

            migrationBuilder.InsertData(
                table: "Editions",
                columns: new[] { "Id", "Description", "GenreId", "ImageLink", "Name", "Price" },
                values: new object[,]
                {
                    { "edfb2820-8a69-4b28-824b-bd06f8eb454e", "Book1", 1, null, "Book1", 9.99m },
                    { "676f1946-755e-461b-8821-9a7bcc96036a", "Book2", 2, null, "Book2", 9.99m },
                    { "88bc5fb9-9e29-41cc-95fc-c68395d6b760", "Book3", 3, null, "Book3", 9.99m },
                    { "5222199a-1ce5-4418-9023-882732eda11e", "Book4", 4, null, "Book4", 9.99m },
                    { "ea018c02-77b3-4e13-9823-4346cd093ec6", "Book5", 5, null, "Book5", 9.99m },
                    { "02c20983-3472-47f5-8c39-8be57c4828ea", "Book6", 6, null, "Book6", 9.99m },
                    { "9ea744f4-13b5-4149-8476-d72ccb4e8329", "Book7", 7, null, "Book7", 9.99m },
                    { "dae98619-931b-4485-89ea-7a5414277994", "Book8", 8, null, "Book8", 9.99m },
                    { "b5e11470-e70f-40d9-b957-f9b004010f3b", "Book9", 9, null, "Book9", 9.99m },
                    { "9972e4a9-af8a-4d9f-98fd-236f554fe97d", "Book10", 10, null, "Book10", 9.99m },
                    { "9833a619-0ec1-4bd9-873d-f256a11d97dd", "Book11", 11, null, "Book11", 9.99m },
                    { "79d8f265-3c95-4efd-8bcd-8fdcb1f27852", "Book12", 12, null, "Book12", 9.99m },
                    { "e45794b7-5c47-4171-be1d-b0cd90ee1249", "Book13", 13, null, "Book13", 9.99m },
                    { "82cbc862-f729-4838-b631-c1b9cac23bde", "Book14", 14, null, "Book14", 9.99m },
                    { "3bdc50c5-831a-48b7-8b08-656d96b3bbda", "Book15", 15, null, "Book15", 9.99m }
                });
        }
    }
}
