﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnDigit.Infrastructure.Data;

namespace OnDigit.Infrastructure.Migrations
{
    [DbContext(typeof(OnDigitDbContext))]
    partial class OnDigitDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OnDigit.Core.Models.EditionModel.Edition", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 4, 20, 21, 17, 12, 14, DateTimeKind.Utc).AddTicks(2314));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUri")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<float>("Rating")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("real")
                        .HasDefaultValue(0f);

                    b.Property<int>("RatingCount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.ToTable("Editions");

                    b.HasData(
                        new
                        {
                            Id = "5322e304-d018-4fb5-a8b3-ba31b4756ac1",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Book1",
                            GenreId = 1,
                            Name = "Book1",
                            Price = 9.99m,
                            Rating = 5f,
                            RatingCount = 0
                        },
                        new
                        {
                            Id = "93d0ec50-7492-4adf-9c0e-4079e6a44227",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Book2",
                            GenreId = 2,
                            Name = "Book2",
                            Price = 9.99m,
                            Rating = 4.4f,
                            RatingCount = 0
                        },
                        new
                        {
                            Id = "390aeaf6-e289-4691-8351-db1967907bcf",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Book3",
                            GenreId = 3,
                            Name = "Book3",
                            Price = 9.99m,
                            Rating = 3.2f,
                            RatingCount = 0
                        },
                        new
                        {
                            Id = "f2ea90fb-3776-46ce-9f67-3a3e82e0a548",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Book4",
                            GenreId = 4,
                            Name = "Book4",
                            Price = 9.99m,
                            Rating = 3f,
                            RatingCount = 0
                        },
                        new
                        {
                            Id = "1ac27b96-4169-491a-b9e6-8c9ef9b15959",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Book5",
                            GenreId = 5,
                            Name = "Book5",
                            Price = 9.99m,
                            Rating = 2f,
                            RatingCount = 0
                        },
                        new
                        {
                            Id = "f2620030-9947-48db-9d25-5e91dfa913a3",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Book6",
                            GenreId = 6,
                            Name = "Book6",
                            Price = 9.99m,
                            Rating = 1f,
                            RatingCount = 0
                        },
                        new
                        {
                            Id = "7b4195d5-bd71-497a-9da0-99847addce7b",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Book7",
                            GenreId = 7,
                            Name = "Book7",
                            Price = 9.99m,
                            Rating = 0.6f,
                            RatingCount = 0
                        },
                        new
                        {
                            Id = "ab864b95-a41d-4bea-96fb-5c072abd8ffe",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Book8",
                            GenreId = 8,
                            Name = "Book8",
                            Price = 9.99m,
                            Rating = 0f,
                            RatingCount = 0
                        },
                        new
                        {
                            Id = "aed4bb17-1dab-4e38-bdb4-79a76f1d4736",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Book9",
                            GenreId = 9,
                            Name = "Book9",
                            Price = 9.99m,
                            Rating = 0f,
                            RatingCount = 0
                        },
                        new
                        {
                            Id = "2e7e40a8-0371-46eb-8272-d61b9e05649e",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Book10",
                            GenreId = 10,
                            Name = "Book10",
                            Price = 9.99m,
                            Rating = 0f,
                            RatingCount = 0
                        },
                        new
                        {
                            Id = "020b8a2a-bd02-4caf-87e7-d10e609ce2a6",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Book11",
                            GenreId = 11,
                            Name = "Book11",
                            Price = 9.99m,
                            Rating = 0f,
                            RatingCount = 0
                        },
                        new
                        {
                            Id = "81189d8e-89fb-4f2c-9339-055664e781db",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Book12",
                            GenreId = 12,
                            Name = "Book12",
                            Price = 9.99m,
                            Rating = 0f,
                            RatingCount = 0
                        },
                        new
                        {
                            Id = "3d66cce9-4e88-4194-bce2-24989b9be23c",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Book13",
                            GenreId = 13,
                            Name = "Book13",
                            Price = 9.99m,
                            Rating = 0f,
                            RatingCount = 0
                        },
                        new
                        {
                            Id = "22ddfaca-68e4-4c73-8d82-dbabc514b911",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Book14",
                            GenreId = 14,
                            Name = "Book14",
                            Price = 9.99m,
                            Rating = 0f,
                            RatingCount = 0
                        },
                        new
                        {
                            Id = "2e19783f-8c32-4e87-990f-8eaae4e5da2a",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Book15",
                            GenreId = 15,
                            Name = "Book15",
                            Price = 9.99m,
                            Rating = 0f,
                            RatingCount = 0
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
                    b.Property<int>("OrderNumber")
                        .HasColumnType("int");

                    b.Property<string>("EditionId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("OrderNumber", "EditionId");

                    b.HasIndex("EditionId");

                    b.ToTable("OrderEditions");
                });

            modelBuilder.Entity("OnDigit.Core.Models.OrderModel.Order", b =>
                {
                    b.Property<int>("Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOrder")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 4, 20, 21, 17, 12, 23, DateTimeKind.Utc).AddTicks(2271));

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Number");

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

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 4, 20, 21, 17, 12, 30, DateTimeKind.Utc).AddTicks(8847));

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

            modelBuilder.Entity("OnDigit.Core.Models.SessionModel.Session", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsCanceledInAdvance")
                        .HasColumnType("bit");

                    b.Property<string>("MACHINE_KEY")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("OnDigit.Core.Models.UserFavoriteModel.UserFavorite", b =>
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

                    b.Property<DateTime>("DateLogined")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 4, 20, 21, 17, 12, 33, DateTimeKind.Utc).AddTicks(3819));

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

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 4, 20, 21, 17, 12, 32, DateTimeKind.Utc).AddTicks(4586));

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

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");
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
                        .HasForeignKey("OrderNumber")
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

            modelBuilder.Entity("OnDigit.Core.Models.UserFavoriteModel.UserFavorite", b =>
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

            modelBuilder.Entity("OnDigit.Core.Models.UserModel.User", b =>
                {
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
