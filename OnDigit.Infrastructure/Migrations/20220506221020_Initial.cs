using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnDigit.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false, defaultValue: 0f),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    StockPackageId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Number = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateOrder = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "Processing")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Number);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ResetToken",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResetToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResetToken_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MACHINE_KEY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsCanceledInAdvance = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersLoginHistory",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateLogined = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersLoginHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersLoginHistory_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stars = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BookId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StockPackages",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    StockId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockPackages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockPackages_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockPackages_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFavorites",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BookId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFavorites", x => new { x.UserId, x.BookId });
                    table.ForeignKey(
                        name: "FK_UserFavorites_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFavorites_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdersBooks",
                columns: table => new
                {
                    OrderNumber = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersBooks", x => new { x.OrderNumber, x.BookId });
                    table.ForeignKey(
                        name: "FK_OrdersBooks_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdersBooks_Orders_OrderNumber",
                        column: x => x.OrderNumber,
                        principalTable: "Orders",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Detective" },
                    { 2, "Fantasy" },
                    { 3, "Adventures" },
                    { 4, "Novel" },
                    { 5, "Scientific Book" },
                    { 6, "Folklore" },
                    { 7, "Humor" },
                    { 8, "Poetry" },
                    { 9, "Prose" },
                    { 10, "Children's Books" },
                    { 11, "Documentary Literature" },
                    { 12, "Education Book" },
                    { 13, "Equipment" },
                    { 14, "Business Literature" },
                    { 15, "Religious Literature" }
                });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "City", "Street" },
                values: new object[,]
                {
                    { 1, "Khmelnytskyi", "Institutska 11/3" },
                    { 2, "Polonne", "Gerasymchuka 12" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Description", "GenreId", "ImageUri", "Name", "Price", "StockPackageId" },
                values: new object[,]
                {
                    { "04d6a1d0-2371-4ac1-b02b-1c3d6235a1ca", "Book description18", 14, "pack://application:,,,/Images/willbook.jpg", "Book18", 9.99m, null },
                    { "055c86ee-226d-47a9-99a3-f33a846a11ac", "Book description16", 1, "pack://application:,,,/Images/willbook.jpg", "Book16", 9.99m, null },
                    { "0acfe7e3-4386-4d86-a4bd-a7ab92b69752", "Book description13", 5, "pack://application:,,,/Images/willbook.jpg", "Book13", 9.99m, null },
                    { "17018893-e88b-4395-969e-5bf0c0729dfd", "Book description5", 11, "pack://application:,,,/Images/willbook.jpg", "Book5", 9.99m, null },
                    { "315a7f9c-038b-4189-9096-56ec0a8a7d6d", "Book description9", 5, "pack://application:,,,/Images/willbook.jpg", "Book9", 9.99m, null },
                    { "336f32a5-ed86-458a-8a3f-123737f6becb", "Book description6", 13, "pack://application:,,,/Images/willbook.jpg", "Book6", 9.99m, null },
                    { "3e5f4b04-f71b-449c-bfba-15e83eb9ab13", "Book description2", 9, "pack://application:,,,/Images/willbook.jpg", "Book2", 9.99m, null },
                    { "42d90b2a-f63d-4f11-bb0d-16feaf7152f2", "Book description3", 9, "pack://application:,,,/Images/willbook.jpg", "Book3", 9.99m, null },
                    { "486b0b35-ca79-42d3-aa1e-016ee05acc72", "Book description19", 12, "pack://application:,,,/Images/willbook.jpg", "Book19", 9.99m, null },
                    { "63af3195-bb7a-43c5-8cda-0f92115b0831", "Book description17", 7, "pack://application:,,,/Images/willbook.jpg", "Book17", 9.99m, null },
                    { "68cbca3f-7cba-4713-9677-33fdafaa3d48", "Book description1", 1, "pack://application:,,,/Images/willbook.jpg", "Book1", 9.99m, null },
                    { "80597f36-d7ca-4d01-a801-9443643cc2b2", "Book description11", 13, "pack://application:,,,/Images/willbook.jpg", "Book11", 9.99m, null },
                    { "83ddc51b-85ed-4974-8942-1ccf4cedf691", "Book description15", 9, "pack://application:,,,/Images/willbook.jpg", "Book15", 9.99m, null },
                    { "8cf43f33-0230-4819-b22a-496cd8ed69b1", "Book description8", 13, "pack://application:,,,/Images/willbook.jpg", "Book8", 9.99m, null },
                    { "8d08172a-6577-4ea3-a0b8-a5643ab80391", "Book description14", 1, "pack://application:,,,/Images/willbook.jpg", "Book14", 9.99m, null },
                    { "967569be-5358-4274-886d-43cc52751e67", "Book description7", 6, "pack://application:,,,/Images/willbook.jpg", "Book7", 9.99m, null },
                    { "b5d2c12b-aa6b-4257-bdcd-5236d7d12388", "Book description10", 6, "pack://application:,,,/Images/willbook.jpg", "Book10", 9.99m, null },
                    { "cb9d22a0-e3ab-44ee-a093-330dd05e1f16", "Book description12", 6, "pack://application:,,,/Images/willbook.jpg", "Book12", 9.99m, null },
                    { "e169d412-f8af-4770-8aa7-8fe5d6c5a89f", "Book description4", 8, "pack://application:,,,/Images/willbook.jpg", "Book4", 9.99m, null },
                    { "fca422fb-c417-46a4-b7cb-da0f48fd8447", "Book description20", 4, "pack://application:,,,/Images/willbook.jpg", "Book20", 9.99m, null }
                });

            migrationBuilder.InsertData(
                table: "StockPackages",
                columns: new[] { "Id", "BookId", "Quantity", "StockId" },
                values: new object[,]
                {
                    { "100ecedc-d5e2-4f1b-a375-6c0fdd1d9d07", "cb9d22a0-e3ab-44ee-a093-330dd05e1f16", 875, 2 },
                    { "13358875-9baf-4891-910e-ae2e6ecd314d", "b5d2c12b-aa6b-4257-bdcd-5236d7d12388", 1809, 2 },
                    { "155e97d3-2a2b-4eee-9687-0db4970c68c7", "e169d412-f8af-4770-8aa7-8fe5d6c5a89f", 29, 2 },
                    { "1d176b50-5ea8-438b-8d46-0253171efd9e", "967569be-5358-4274-886d-43cc52751e67", 1524, 1 },
                    { "219df57d-2c7b-4afe-aea4-75b5bb93ef76", "486b0b35-ca79-42d3-aa1e-016ee05acc72", 1077, 1 },
                    { "3ff51c29-e942-4422-b58a-dd3a2c1b1be1", "fca422fb-c417-46a4-b7cb-da0f48fd8447", 605, 1 },
                    { "492b0ae6-556b-4b77-8047-3459e5773c5e", "68cbca3f-7cba-4713-9677-33fdafaa3d48", 1007, 1 },
                    { "4a8111fc-ee67-4abc-aee1-2503f7c4be98", "0acfe7e3-4386-4d86-a4bd-a7ab92b69752", 545, 1 },
                    { "4c30ada8-2723-4295-bd8c-9e0ce3c49b90", "17018893-e88b-4395-969e-5bf0c0729dfd", 1093, 1 },
                    { "641f5546-105f-42a5-af28-1007d55cbdad", "8cf43f33-0230-4819-b22a-496cd8ed69b1", 156, 1 },
                    { "6475268c-e5ee-47c1-9c77-64ebabf0e0e3", "80597f36-d7ca-4d01-a801-9443643cc2b2", 1055, 1 },
                    { "6c79ff3a-d322-4413-a0f5-886c9d71a2d2", "055c86ee-226d-47a9-99a3-f33a846a11ac", 760, 1 },
                    { "765aa234-25fc-45c7-abbd-fae34706c559", "83ddc51b-85ed-4974-8942-1ccf4cedf691", 1682, 2 },
                    { "a0af9e2d-a4f6-4806-9ff7-cb7f4bfe34a1", "315a7f9c-038b-4189-9096-56ec0a8a7d6d", 1150, 1 },
                    { "b3550b46-f3ae-4e56-a397-a039dea53ce2", "3e5f4b04-f71b-449c-bfba-15e83eb9ab13", 757, 2 },
                    { "bf94de80-ae6a-4787-aa91-ec5b5a586d8f", "42d90b2a-f63d-4f11-bb0d-16feaf7152f2", 1979, 1 },
                    { "cc7de689-6eb0-46bc-bfae-01b4f9ec7960", "8d08172a-6577-4ea3-a0b8-a5643ab80391", 1156, 1 },
                    { "e84fbf17-ca4d-4d3f-a11f-9b6f32b81201", "63af3195-bb7a-43c5-8cda-0f92115b0831", 803, 2 },
                    { "f12e68aa-036f-455b-9e4f-c640202bceaa", "336f32a5-ed86-458a-8a3f-123737f6becb", 1987, 1 },
                    { "f415fbb9-0053-49b6-b1d9-2e2876ff9d6f", "04d6a1d0-2371-4ac1-b02b-1c3d6235a1ca", 1455, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_GenreId",
                table: "Books",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersBooks_BookId",
                table: "OrdersBooks",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_ResetToken_UserId",
                table: "ResetToken",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_BookId",
                table: "Reviews",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_UserId",
                table: "Sessions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StockPackages_BookId",
                table: "StockPackages",
                column: "BookId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockPackages_StockId",
                table: "StockPackages",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavorites_BookId",
                table: "UserFavorites",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersLoginHistory_UserId",
                table: "UsersLoginHistory",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdersBooks");

            migrationBuilder.DropTable(
                name: "ResetToken");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "StockPackages");

            migrationBuilder.DropTable(
                name: "UserFavorites");

            migrationBuilder.DropTable(
                name: "UsersLoginHistory");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
