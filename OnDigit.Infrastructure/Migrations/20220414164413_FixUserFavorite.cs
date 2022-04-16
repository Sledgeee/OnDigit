using Microsoft.EntityFrameworkCore.Migrations;

namespace OnDigit.Infrastructure.Migrations
{
    public partial class FixUserFavorite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserFavorites");

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

            migrationBuilder.CreateIndex(
                name: "IX_UserFavorites_EditionId",
                table: "UserFavorites",
                column: "EditionId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavorites_Editions_EditionId",
                table: "UserFavorites",
                column: "EditionId",
                principalTable: "Editions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavorites_Users_UserId",
                table: "UserFavorites",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFavorites_Editions_EditionId",
                table: "UserFavorites");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavorites_Users_UserId",
                table: "UserFavorites");

            migrationBuilder.DropIndex(
                name: "IX_UserFavorites_EditionId",
                table: "UserFavorites");

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

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "UserFavorites",
                type: "nvarchar(max)",
                nullable: true);

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
    }
}
