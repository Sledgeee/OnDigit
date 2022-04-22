using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnDigit.Infrastructure.Migrations
{
    public partial class init : Migration
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
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
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
                name: "Editions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false, defaultValue: 0f),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    ImageUri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Editions_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Number = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateOrder = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Number);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
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
                    EditionId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Editions_EditionId",
                        column: x => x.EditionId,
                        principalTable: "Editions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserFavorites",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EditionId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFavorites", x => new { x.UserId, x.EditionId });
                    table.ForeignKey(
                        name: "FK_UserFavorites_Editions_EditionId",
                        column: x => x.EditionId,
                        principalTable: "Editions",
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
                name: "OrderEditions",
                columns: table => new
                {
                    OrderNumber = table.Column<int>(type: "int", nullable: false),
                    EditionId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderEditions", x => new { x.OrderNumber, x.EditionId });
                    table.ForeignKey(
                        name: "FK_OrderEditions_Editions_EditionId",
                        column: x => x.EditionId,
                        principalTable: "Editions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderEditions_Orders_OrderNumber",
                        column: x => x.OrderNumber,
                        principalTable: "Orders",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Restrict);
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
                table: "Editions",
                columns: new[] { "Id", "Description", "GenreId", "ImageUri", "Name", "Price" },
                values: new object[,]
                {
                    { "3261e41e-1c64-49e4-8147-739e4a011596", "Book1", 1, "pack://application:,,,/Images/willbook.jpg", "Book1", 9.99m },
                    { "2c0986a1-8e48-4592-b59a-27afe5d9e769", "Book2", 2, "pack://application:,,,/Images/willbook.jpg", "Book2", 9.99m },
                    { "cbbd23f9-1cbc-4867-98fa-870bf3d88241", "Book3", 3, "pack://application:,,,/Images/willbook.jpg", "Book3", 9.99m },
                    { "7c7406c2-9ab2-4b0f-9869-b866116afb78", "Book4", 4, "pack://application:,,,/Images/willbook.jpg", "Book4", 9.99m },
                    { "a6017e8e-70e0-4691-b5ca-aea15dbde775", "Book5", 5, "pack://application:,,,/Images/willbook.jpg", "Book5", 9.99m },
                    { "9177ac87-6f30-4591-a709-a27d9798f40a", "Book6", 6, "pack://application:,,,/Images/willbook.jpg", "Book6", 9.99m },
                    { "ed3bbf05-c76a-4046-b1e5-ebea06f4dd65", "Book7", 7, "pack://application:,,,/Images/willbook.jpg", "Book7", 9.99m },
                    { "7efa693b-6481-449c-bc73-30baa71e29e1", "Book8", 8, "pack://application:,,,/Images/willbook.jpg", "Book8", 9.99m },
                    { "8335b6b5-30bc-45f8-9a6d-87230f09083e", "Book9", 9, "pack://application:,,,/Images/willbook.jpg", "Book9", 9.99m },
                    { "9e3809fc-1a39-4d43-a697-57971492c221", "Book10", 10, "pack://application:,,,/Images/willbook.jpg", "Book10", 9.99m },
                    { "e616523b-cfb6-47f3-ac1e-fc318ecd90e7", "Book11", 11, "pack://application:,,,/Images/willbook.jpg", "Book11", 9.99m },
                    { "8b730119-4e7c-4c34-99fc-74e47fdffbb9", "Book12", 12, "pack://application:,,,/Images/willbook.jpg", "Book12", 9.99m },
                    { "4e519fe6-89c1-4ea7-b587-4250343c77e5", "Book13", 13, "pack://application:,,,/Images/willbook.jpg", "Book13", 9.99m },
                    { "6e59d3d7-248a-472f-8404-8783d7bc7b35", "Book14", 14, "pack://application:,,,/Images/willbook.jpg", "Book14", 9.99m },
                    { "4e90558a-3374-4b1c-8549-90048b207a10", "Book15", 15, "pack://application:,,,/Images/willbook.jpg", "Book15", 9.99m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Editions_GenreId",
                table: "Editions",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderEditions_EditionId",
                table: "OrderEditions",
                column: "EditionId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ResetToken_UserId",
                table: "ResetToken",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_EditionId",
                table: "Reviews",
                column: "EditionId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_UserId",
                table: "Sessions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavorites_EditionId",
                table: "UserFavorites",
                column: "EditionId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersLoginHistory_UserId",
                table: "UsersLoginHistory",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderEditions");

            migrationBuilder.DropTable(
                name: "ResetToken");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "UserFavorites");

            migrationBuilder.DropTable(
                name: "UsersLoginHistory");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Editions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
