﻿using Microsoft.EntityFrameworkCore;
using OnDigit.Core.Genres;
using OnDigit.Core.Models.EditionModel;
using OnDigit.Core.Models.GenreModel;
using OnDigit.Core.Models.RoleModel;
using OnDigit.Core.Roles;
using System;

namespace OnDigit.Infrastructure.Data
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder builder)
        {
            SeedUserRoles(builder);
            SeedGenres(builder);
            SeedEditions(builder);
        }

        public static void SeedUserRoles(ModelBuilder builder) =>
            builder.Entity<Role>().HasData(
                new Role()
                {
                    Id = (int)Roles.OwnerId,
                    Name = "Owner"
                },
                new Role()
                {
                    Id = (int)Roles.AdministratorId,
                    Name = "Administrator"
                },
                new Role()
                {
                    Id = (int)Roles.CustomerId,
                    Name = "Customer"
                });

        public static void SeedGenres(ModelBuilder builder) =>
            builder.Entity<Genre>().HasData(
                new Genre()
                {
                    Id = (int)Genres.Detective,
                    Name = "Detective"
                },
                new Genre()
                {
                    Id = (int)Genres.Fantasy,
                    Name = "Fantasy"
                }, 
                new Genre()
                {
                    Id = (int)Genres.Adventures,
                    Name = "Adventures"
                },
                new Genre()
                {
                    Id = (int)Genres.Novel,
                    Name = "Novel"
                },
                new Genre()
                {
                    Id = (int)Genres.Scientific_book,
                    Name = "Scientific Book"
                },
                new Genre()
                {
                    Id = (int)Genres.Folklore,
                    Name = "Folklore"
                },
                new Genre()
                {
                    Id = (int)Genres.Humor,
                    Name = "Humor"
                },
                new Genre()
                {
                    Id = (int)Genres.Poetry,
                    Name = "Poetry"
                },
                new Genre()
                {
                    Id = (int)Genres.Prose,
                    Name = "Prose"
                },
                new Genre()
                {
                    Id = (int)Genres.Childrens_book,
                    Name = "Children's Books"
                },
                new Genre()
                {
                    Id = (int)Genres.Documentary_literature,
                    Name = "Documentary Literature"
                },
                new Genre()
                {
                    Id = (int)Genres.Education_book,
                    Name = "Education Book"
                },
                new Genre()
                {
                    Id = (int)Genres.Equipment,
                    Name = "Equipment"
                },
                new Genre()
                {
                    Id = (int)Genres.Business_literature,
                    Name = "Business Literature"
                },
                new Genre()
                {
                    Id = (int)Genres.Religious_literature,
                    Name = "Religious Literature"
                });

        public static void SeedEditions(ModelBuilder builder)
        {
            builder.Entity<Edition>().HasData(new Edition()
                {
                    Name = "Book1",
                    Description = "Book1",
                    Price = 9.99m,
                    Rating = 5,
                    GenreId = (int)Genres.Detective
                },
                new Edition()
                {
                    Name = "Book2",
                    Description = "Book2",
                    Price = 9.99m,
                    Rating = 4.4f,
                    GenreId = (int)Genres.Fantasy
                },
                new Edition()
                {
                    Name = "Book3",
                    Description = "Book3",
                    Price = 9.99m,
                    Rating = 3.2f,
                    GenreId = (int)Genres.Adventures
                },
                new Edition()
                {
                    Name = "Book4",
                    Description = "Book4",
                    Price = 9.99m,
                    Rating = 3,
                    GenreId = (int)Genres.Novel
                },
                new Edition()
                {
                    Name = "Book5",
                    Description = "Book5",
                    Price = 9.99m,
                    Rating = 2,
                    GenreId = (int)Genres.Scientific_book
                },
                new Edition()
                {
                    Name = "Book6",
                    Description = "Book6",
                    Price = 9.99m,
                    Rating = 1,
                    GenreId = (int)Genres.Folklore
                },
                new Edition()
                {
                    Name = "Book7",
                    Description = "Book7",
                    Price = 9.99m,
                    Rating = 0.6f,
                    GenreId = (int)Genres.Humor
                },
                new Edition()
                {
                    Name = "Book8",
                    Description = "Book8",
                    Price = 9.99m,
                    Rating = 0,
                    GenreId = (int)Genres.Poetry
                },
                new Edition()
                {
                    Name = "Book9",
                    Description = "Book9",
                    Price = 9.99m,
                    Rating = 0,
                    GenreId = (int)Genres.Prose
                },
                new Edition()
                {
                    Name = "Book10",
                    Description = "Book10",
                    Price = 9.99m,
                    Rating = 0,
                    GenreId = (int)Genres.Childrens_book
                },
                new Edition()
                {
                    Name = "Book11",
                    Description = "Book11",
                    Price = 9.99m,
                    Rating = 0,
                    GenreId = (int)Genres.Documentary_literature
                },
                new Edition()
                {
                    Name = "Book12",
                    Description = "Book12",
                    Price = 9.99m,
                    Rating = 0,
                    GenreId = (int)Genres.Education_book
                },
                new Edition()
                {
                    Name = "Book13",
                    Description = "Book13",
                    Price = 9.99m,
                    Rating = 0,
                    GenreId = (int)Genres.Equipment
                },
                new Edition()
                {
                    Name = "Book14",
                    Description = "Book14",
                    Price = 9.99m,
                    Rating = 0,
                    GenreId = (int)Genres.Business_literature
                },
                new Edition()
                {
                    Name = "Book15",
                    Description = "Book15",
                    Price = 9.99m,
                    Rating = 0,
                    GenreId = (int)Genres.Religious_literature
                });
        } 
    }
}
