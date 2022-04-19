using Microsoft.EntityFrameworkCore.Migrations;

namespace OnDigit.Infrastructure.Migrations
{
    public partial class UpdateEditionModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.RenameColumn(
                name: "AverageStars",
                table: "Editions",
                newName: "Rating");

            migrationBuilder.AddColumn<int>(
                name: "RatingCount",
                table: "Editions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Editions",
                columns: new[] { "Id", "Description", "GenreId", "ImageLink", "Name", "Price", "Rating" },
                values: new object[,]
                {
                    { "8a22555e-a4c4-40bf-b112-217b1a252fe7", "Book1", 1, null, "Book1", 9.99m, 5f },
                    { "8011c77e-c889-48db-a62f-8aaa40e56713", "Book2", 2, null, "Book2", 9.99m, 4.4f },
                    { "e0a1dd78-e4cb-4262-a8be-f2f6be7ea8a5", "Book3", 3, null, "Book3", 9.99m, 3.2f },
                    { "97bc4add-73e9-4049-b412-2d88848a77ae", "Book4", 4, null, "Book4", 9.99m, 3f },
                    { "1ce39d25-39ee-4170-9bb5-acd1fa2032d9", "Book5", 5, null, "Book5", 9.99m, 2f },
                    { "fb3ba684-3609-4ae6-ae1a-0897a75c8805", "Book6", 6, null, "Book6", 9.99m, 1f },
                    { "4b1b8187-e9f3-4415-ad2b-b198aed55d90", "Book7", 7, null, "Book7", 9.99m, 0.6f }
                });

            migrationBuilder.InsertData(
                table: "Editions",
                columns: new[] { "Id", "Description", "GenreId", "ImageLink", "Name", "Price" },
                values: new object[,]
                {
                    { "26a554b6-7d18-4ef7-9e8a-2b450cecc459", "Book8", 8, null, "Book8", 9.99m },
                    { "0d8bcbc0-52ec-494e-9047-db3692343be5", "Book9", 9, null, "Book9", 9.99m },
                    { "40188397-4998-458c-995f-6d738b9cffde", "Book10", 10, null, "Book10", 9.99m },
                    { "592dee1f-e7b7-4058-abe0-fdd7de5d9def", "Book11", 11, null, "Book11", 9.99m },
                    { "8231c7ce-bb13-4f11-9bb5-8894ff1b72cf", "Book12", 12, null, "Book12", 9.99m },
                    { "c447d421-640e-4f08-8e70-0a3c1e76645c", "Book13", 13, null, "Book13", 9.99m },
                    { "dee6fb46-fb37-47b2-84d5-1af33c22a548", "Book14", 14, null, "Book14", 9.99m },
                    { "73965ebe-6721-4c87-a466-3766ca16fa98", "Book15", 15, null, "Book15", 9.99m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "0d8bcbc0-52ec-494e-9047-db3692343be5");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "1ce39d25-39ee-4170-9bb5-acd1fa2032d9");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "26a554b6-7d18-4ef7-9e8a-2b450cecc459");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "40188397-4998-458c-995f-6d738b9cffde");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "4b1b8187-e9f3-4415-ad2b-b198aed55d90");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "592dee1f-e7b7-4058-abe0-fdd7de5d9def");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "73965ebe-6721-4c87-a466-3766ca16fa98");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "8011c77e-c889-48db-a62f-8aaa40e56713");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "8231c7ce-bb13-4f11-9bb5-8894ff1b72cf");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "8a22555e-a4c4-40bf-b112-217b1a252fe7");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "97bc4add-73e9-4049-b412-2d88848a77ae");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "c447d421-640e-4f08-8e70-0a3c1e76645c");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "dee6fb46-fb37-47b2-84d5-1af33c22a548");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "e0a1dd78-e4cb-4262-a8be-f2f6be7ea8a5");

            migrationBuilder.DeleteData(
                table: "Editions",
                keyColumn: "Id",
                keyValue: "fb3ba684-3609-4ae6-ae1a-0897a75c8805");

            migrationBuilder.DropColumn(
                name: "RatingCount",
                table: "Editions");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "Editions",
                newName: "AverageStars");

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
        }
    }
}
