using Microsoft.EntityFrameworkCore;
using OnDigit.Core.Models.BookModel;
using OnDigit.Core.Models.GenreModel;
using OnDigit.Core.Models.UserModel;
using OnDigit.Core.Models.WarehouseModel;
using System;
using System.Collections.Generic;

namespace OnDigit.Infrastructure.Data
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder builder)
        {
            var books = new List<Book>();
            var packages = new List<Package>();
            var random = new Random();

            var warehouses = new List<Warehouse>()
            {
                new Warehouse()
                {
                    Id = 1,
                    City = "Khmelnytskyi",
                    Street = "Institutska 11/3"
                },
                new Warehouse()
                {
                    Id = 2,
                    City = "Polonne",
                    Street = "Gerasymchuka 12"
                }
            };

            for (int i = 1; i <= 20; i++)
            {
                books.Add(new Book()
                {
                    Name = "Book" + i,
                    Description = "Book description" + i,
                    Price = 9.99m,
                    GenreId = random.Next(1, 16),
                    Discount = random.Next(0, 2) > 0 ? random.Next(1, 100) + (decimal)random.NextDouble() : 0,
                    ImageUri = "pack://application:,,,/Images/willbook.jpg"
                });
                packages.Add(new Package()
                {
                    BookId = books[^1].Id,
                    Quantity = random.Next(0, 500),
                    WarehouseId = warehouses[random.Next(0, 2)].Id
                });
                books[^1].IsAvailable = packages[^1].Quantity > 0 ? true : false;
            }

            builder.Entity<Warehouse>().HasData(warehouses);
            builder.Entity<Book>().HasData(books);
            builder.Entity<Package>().HasData(packages);
            builder.Entity<Genre>().HasData(
                new Genre()
                {
                    Id = (int)Genres.Detective,
                    Name = Genres.Detective.ToString()
                },
                new Genre()
                {
                    Id = (int)Genres.Fantasy,
                    Name = Genres.Fantasy.ToString()
                },
                new Genre()
                {
                    Id = (int)Genres.Adventures,
                    Name = Genres.Adventures.ToString()
                },
                new Genre()
                {
                    Id = (int)Genres.Novel,
                    Name = Genres.Novel.ToString()
                },
                new Genre()
                {
                    Id = (int)Genres.Scientific_book,
                    Name = Genres.Scientific_book.ToString().Replace("_", " ")
                },
                new Genre()
                {
                    Id = (int)Genres.Folklore,
                    Name = Genres.Folklore.ToString()
                },
                new Genre()
                {
                    Id = (int)Genres.Humor,
                    Name = Genres.Humor.ToString()
                },
                new Genre()
                {
                    Id = (int)Genres.Poetry,
                    Name = Genres.Poetry.ToString()
                },
                new Genre()
                {
                    Id = (int)Genres.Prose,
                    Name = Genres.Prose.ToString()
                },
                new Genre()
                {
                    Id = (int)Genres.Childrens_book,
                    Name = Genres.Childrens_book.ToString().Replace("_", " ")
                },
                new Genre()
                {
                    Id = (int)Genres.Documentary_literature,
                    Name = Genres.Documentary_literature.ToString().Replace("_", " ")
                },
                new Genre()
                {
                    Id = (int)Genres.Education_book,
                    Name = Genres.Education_book.ToString().Replace("_", " ")
                },
                new Genre()
                {
                    Id = (int)Genres.Equipment,
                    Name = Genres.Equipment.ToString()
                },
                new Genre()
                {
                    Id = (int)Genres.Business_literature,
                    Name = Genres.Business_literature.ToString().Replace("_", " ")
                },
                new Genre()
                {
                    Id = (int)Genres.Religious_literature,
                    Name = Genres.Religious_literature.ToString().Replace("_", " ")
                });
        }
    }
}
