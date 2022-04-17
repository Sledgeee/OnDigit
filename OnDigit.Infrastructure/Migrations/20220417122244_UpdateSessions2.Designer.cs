﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnDigit.Infrastructure.Data;

namespace OnDigit.Infrastructure.Migrations
{
    [DbContext(typeof(OnDigitDbContext))]
    [Migration("20220417122244_UpdateSessions2")]
    partial class UpdateSessions2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CartEdition", b =>
                {
                    b.Property<string>("BasketsId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EditionsId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("BasketsId", "EditionsId");

                    b.HasIndex("EditionsId");

                    b.ToTable("CartEdition");
                });

            modelBuilder.Entity("OnDigit.Core.Models.CartModel.Cart", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Baskets");
                });

            modelBuilder.Entity("OnDigit.Core.Models.EditionModel.Edition", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("AverageStars")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("real")
                        .HasDefaultValue(0f);

                    b.Property<DateTimeOffset>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<string>("ImageLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.ToTable("Editions");

                    b.HasData(
                        new
                        {
                            Id = "28c04436-0bbe-4974-9a00-199ef8372e93",
                            AverageStars = 5f,
                            DateCreated = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "Book1",
                            GenreId = 1,
                            Name = "Book1",
                            Price = 9.99m
                        },
                        new
                        {
                            Id = "7a3388b1-e75f-42c9-ac09-2e4a1f7f475e",
                            AverageStars = 4.4f,
                            DateCreated = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "Book2",
                            GenreId = 2,
                            Name = "Book2",
                            Price = 9.99m
                        },
                        new
                        {
                            Id = "312cf01c-4f98-425f-9332-c3b022407670",
                            AverageStars = 3.2f,
                            DateCreated = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "Book3",
                            GenreId = 3,
                            Name = "Book3",
                            Price = 9.99m
                        },
                        new
                        {
                            Id = "2d7ec608-54db-4a71-a741-bcd3cccd468d",
                            AverageStars = 3f,
                            DateCreated = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "Book4",
                            GenreId = 4,
                            Name = "Book4",
                            Price = 9.99m
                        },
                        new
                        {
                            Id = "d7f37df5-9058-4862-aedb-032e6842dd32",
                            AverageStars = 2f,
                            DateCreated = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "Book5",
                            GenreId = 5,
                            Name = "Book5",
                            Price = 9.99m
                        },
                        new
                        {
                            Id = "00ff68b5-6b62-4064-ae86-efa2b6637f55",
                            AverageStars = 1f,
                            DateCreated = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "Book6",
                            GenreId = 6,
                            Name = "Book6",
                            Price = 9.99m
                        },
                        new
                        {
                            Id = "2db6e9e2-e500-4036-9dc8-a0f54e8ac562",
                            AverageStars = 0.6f,
                            DateCreated = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "Book7",
                            GenreId = 7,
                            Name = "Book7",
                            Price = 9.99m
                        },
                        new
                        {
                            Id = "da0b2053-fb21-40a8-a78b-b771cce26590",
                            AverageStars = 0f,
                            DateCreated = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "Book8",
                            GenreId = 8,
                            Name = "Book8",
                            Price = 9.99m
                        },
                        new
                        {
                            Id = "51e0de5e-12cf-483c-810e-0fa87ef6cee3",
                            AverageStars = 0f,
                            DateCreated = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "Book9",
                            GenreId = 9,
                            Name = "Book9",
                            Price = 9.99m
                        },
                        new
                        {
                            Id = "802cd5b6-3a0e-45d0-9b5f-a6888d23f0f8",
                            AverageStars = 0f,
                            DateCreated = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "Book10",
                            GenreId = 10,
                            Name = "Book10",
                            Price = 9.99m
                        },
                        new
                        {
                            Id = "e68b1a07-e57e-46ff-9f0a-d1b6b2566935",
                            AverageStars = 0f,
                            DateCreated = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "Book11",
                            GenreId = 11,
                            Name = "Book11",
                            Price = 9.99m
                        },
                        new
                        {
                            Id = "3ffd2363-272f-4219-9a74-2cb6e843d1d9",
                            AverageStars = 0f,
                            DateCreated = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "Book12",
                            GenreId = 12,
                            Name = "Book12",
                            Price = 9.99m
                        },
                        new
                        {
                            Id = "88f5b3a8-584e-4bad-9278-825fcebb844d",
                            AverageStars = 0f,
                            DateCreated = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "Book13",
                            GenreId = 13,
                            Name = "Book13",
                            Price = 9.99m
                        },
                        new
                        {
                            Id = "c5722fd7-2a01-4ef2-a23e-d7d0cd5901b5",
                            AverageStars = 0f,
                            DateCreated = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "Book14",
                            GenreId = 14,
                            Name = "Book14",
                            Price = 9.99m
                        },
                        new
                        {
                            Id = "bbcb76c3-27a1-4563-a823-4f9beced223d",
                            AverageStars = 0f,
                            DateCreated = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "Book15",
                            GenreId = 15,
                            Name = "Book15",
                            Price = 9.99m
                        });
                });

            modelBuilder.Entity("OnDigit.Core.Models.GenreModel.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Detective"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Fantasy"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Adventures"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Novel"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Scientific Book"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Folklore"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Humor"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Poetry"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Prose"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Children's Books"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Documentary Literature"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Education Book"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Equipment"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Business Literature"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Religious Literature"
                        });
                });

            modelBuilder.Entity("OnDigit.Core.Models.OrderEditionModel.OrderEdition", b =>
                {
                    b.Property<string>("OrderId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EditionId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("OrderId", "EditionId");

                    b.HasIndex("EditionId");

                    b.ToTable("OrderEditions");
                });

            modelBuilder.Entity("OnDigit.Core.Models.OrderModel.Order", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset>("DateOrder")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("OnDigit.Core.Models.ResetTokenModel.ResetToken", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ResetToken");
                });

            modelBuilder.Entity("OnDigit.Core.Models.ReviewModel.Review", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("EditionId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Stars")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("EditionId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("OnDigit.Core.Models.RoleModel.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Owner"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Administrator"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Customer"
                        });
                });

            modelBuilder.Entity("OnDigit.Core.Models.SessionModel.Session", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset>("EndDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsCanceledInAdvance")
                        .HasColumnType("bit");

                    b.Property<string>("MACHINE_KEY")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("StartDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("OnDigit.Core.Models.UserFavoritesModel.UserFavorites", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EditionId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "EditionId");

                    b.HasIndex("EditionId");

                    b.ToTable("UserFavorites");
                });

            modelBuilder.Entity("OnDigit.Core.Models.UserLoginHistoryModel.UserLoginHistory", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset>("DateLogined")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UsersLoginHistory");
                });

            modelBuilder.Entity("OnDigit.Core.Models.UserModel.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Balance")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18,2)")
                        .HasDefaultValue(0m);

                    b.Property<DateTimeOffset>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<bool>("SessionCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CartEdition", b =>
                {
                    b.HasOne("OnDigit.Core.Models.CartModel.Cart", null)
                        .WithMany()
                        .HasForeignKey("BasketsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnDigit.Core.Models.EditionModel.Edition", null)
                        .WithMany()
                        .HasForeignKey("EditionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnDigit.Core.Models.CartModel.Cart", b =>
                {
                    b.HasOne("OnDigit.Core.Models.UserModel.User", "User")
                        .WithMany("Baskets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("OnDigit.Core.Models.EditionModel.Edition", b =>
                {
                    b.HasOne("OnDigit.Core.Models.GenreModel.Genre", "Genre")
                        .WithMany("Editions")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("OnDigit.Core.Models.OrderEditionModel.OrderEdition", b =>
                {
                    b.HasOne("OnDigit.Core.Models.EditionModel.Edition", "Edition")
                        .WithMany("OrdersEditions")
                        .HasForeignKey("EditionId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("OnDigit.Core.Models.OrderModel.Order", "Order")
                        .WithMany("OrdersEditions")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Edition");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("OnDigit.Core.Models.OrderModel.Order", b =>
                {
                    b.HasOne("OnDigit.Core.Models.UserModel.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientCascade);

                    b.Navigation("User");
                });

            modelBuilder.Entity("OnDigit.Core.Models.ResetTokenModel.ResetToken", b =>
                {
                    b.HasOne("OnDigit.Core.Models.UserModel.User", "User")
                        .WithMany("ResetTokens")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OnDigit.Core.Models.ReviewModel.Review", b =>
                {
                    b.HasOne("OnDigit.Core.Models.EditionModel.Edition", "Edition")
                        .WithMany("Reviews")
                        .HasForeignKey("EditionId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("OnDigit.Core.Models.UserModel.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Edition");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OnDigit.Core.Models.SessionModel.Session", b =>
                {
                    b.HasOne("OnDigit.Core.Models.UserModel.User", "User")
                        .WithMany("Sessions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("OnDigit.Core.Models.UserFavoritesModel.UserFavorites", b =>
                {
                    b.HasOne("OnDigit.Core.Models.EditionModel.Edition", "Edition")
                        .WithMany("UserFavorites")
                        .HasForeignKey("EditionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnDigit.Core.Models.UserModel.User", "User")
                        .WithMany("UserFavorites")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Edition");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OnDigit.Core.Models.UserLoginHistoryModel.UserLoginHistory", b =>
                {
                    b.HasOne("OnDigit.Core.Models.UserModel.User", "User")
                        .WithMany("UserLogins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("OnDigit.Core.Models.UserModel.User", b =>
                {
                    b.HasOne("OnDigit.Core.Models.RoleModel.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("OnDigit.Core.Models.EditionModel.Edition", b =>
                {
                    b.Navigation("OrdersEditions");

                    b.Navigation("Reviews");

                    b.Navigation("UserFavorites");
                });

            modelBuilder.Entity("OnDigit.Core.Models.GenreModel.Genre", b =>
                {
                    b.Navigation("Editions");
                });

            modelBuilder.Entity("OnDigit.Core.Models.OrderModel.Order", b =>
                {
                    b.Navigation("OrdersEditions");
                });

            modelBuilder.Entity("OnDigit.Core.Models.RoleModel.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("OnDigit.Core.Models.UserModel.User", b =>
                {
                    b.Navigation("Baskets");

                    b.Navigation("Orders");

                    b.Navigation("ResetTokens");

                    b.Navigation("Reviews");

                    b.Navigation("Sessions");

                    b.Navigation("UserFavorites");

                    b.Navigation("UserLogins");
                });
#pragma warning restore 612, 618
        }
    }
}
