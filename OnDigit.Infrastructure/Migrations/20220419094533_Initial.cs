using System;
using Microsoft.EntityFrameworkCore.Migrations;

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
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Editions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false, defaultValue: 0f),
                    RatingCount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    ImageUri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
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
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Baskets",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Baskets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateOrder = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
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
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stars = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
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
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MACHINE_KEY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EndDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
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
                name: "UsersLoginHistory",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateLogined = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
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
                name: "CartEdition",
                columns: table => new
                {
                    BasketsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EditionsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartEdition", x => new { x.BasketsId, x.EditionsId });
                    table.ForeignKey(
                        name: "FK_CartEdition_Baskets_BasketsId",
                        column: x => x.BasketsId,
                        principalTable: "Baskets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartEdition_Editions_EditionsId",
                        column: x => x.EditionsId,
                        principalTable: "Editions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderEditions",
                columns: table => new
                {
                    OrderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EditionId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderEditions", x => new { x.OrderId, x.EditionId });
                    table.ForeignKey(
                        name: "FK_OrderEditions_Editions_EditionId",
                        column: x => x.EditionId,
                        principalTable: "Editions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderEditions_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Detective" },
                    { 15, "Religious Literature" },
                    { 14, "Business Literature" },
                    { 13, "Equipment" },
                    { 12, "Education Book" },
                    { 11, "Documentary Literature" },
                    { 10, "Children's Books" },
                    { 9, "Prose" },
                    { 7, "Humor" },
                    { 6, "Folklore" },
                    { 5, "Scientific Book" },
                    { 4, "Novel" },
                    { 3, "Adventures" },
                    { 2, "Fantasy" },
                    { 8, "Poetry" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 2, "Administrator" },
                    { 1, "Owner" },
                    { 3, "Customer" }
                });

            migrationBuilder.InsertData(
                table: "Editions",
                columns: new[] { "Id", "Description", "GenreId", "ImageUri", "Name", "Price", "Rating" },
                values: new object[,]
                {
                    { "939ce2f4-d728-4b13-8526-c585d8bc748f", "Book1", 1, null, "Book1", 9.99m, 5f },
                    { "f3ca30a5-16af-4567-a551-85f553c9b311", "Book2", 2, null, "Book2", 9.99m, 4.4f },
                    { "d29dd343-4852-4e91-8056-282f9d619993", "Book3", 3, null, "Book3", 9.99m, 3.2f },
                    { "b1e9f6ca-1d0e-4bd0-874f-85d56cca81d1", "Book4", 4, null, "Book4", 9.99m, 3f },
                    { "97c588df-7921-43a6-918c-bfc274416f28", "Book5", 5, null, "Book5", 9.99m, 2f },
                    { "aa2fa016-7ecb-4b0f-b0c9-f027c66aefa4", "Book6", 6, null, "Book6", 9.99m, 1f },
                    { "3d210498-e9f8-4453-b7e0-7a1a38081fea", "Book7", 7, null, "Book7", 9.99m, 0.6f }
                });

            migrationBuilder.InsertData(
                table: "Editions",
                columns: new[] { "Id", "Description", "GenreId", "ImageUri", "Name", "Price" },
                values: new object[,]
                {
                    { "65cfe07b-47ff-40b0-9571-2a1448ef1143", "Book8", 8, null, "Book8", 9.99m },
                    { "43b0383d-49c0-43db-ba20-e49b8058e8e6", "Book9", 9, null, "Book9", 9.99m },
                    { "16308c41-07ba-48f7-b4d0-6044c6cfe81a", "Book10", 10, null, "Book10", 9.99m },
                    { "124f0507-8fb9-4393-b61f-789bbfab5e4b", "Book11", 11, null, "Book11", 9.99m },
                    { "ed8ff430-fa8d-4ad8-91de-2d9e3b81ac42", "Book12", 12, null, "Book12", 9.99m },
                    { "abf186ce-40c0-4b90-9403-8c0009de8cd8", "Book13", 13, null, "Book13", 9.99m },
                    { "233555e0-8d9b-497d-bac7-bb947eca5479", "Book14", 14, null, "Book14", 9.99m },
                    { "430bc4b5-2848-4b1a-945c-6460c027eda1", "Book15", 15, null, "Book15", 9.99m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_UserId",
                table: "Baskets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CartEdition_EditionsId",
                table: "CartEdition",
                column: "EditionsId");

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
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersLoginHistory_UserId",
                table: "UsersLoginHistory",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartEdition");

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
                name: "Baskets");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Editions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
