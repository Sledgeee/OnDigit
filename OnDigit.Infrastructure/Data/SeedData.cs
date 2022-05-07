using Microsoft.EntityFrameworkCore;
using OnDigit.Core.Genres;
using OnDigit.Core.Models.BookModel;
using OnDigit.Core.Models.GenreModel;
using OnDigit.Core.Models.OrderBookModel;
using OnDigit.Core.Models.OrderModel;
using OnDigit.Core.Models.StockModel;
using System;
using System.Collections.Generic;

namespace OnDigit.Infrastructure.Data
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder builder)
        {
            SeedAll(builder);
        }
            

        public static void SeedAll(ModelBuilder builder)
        {
            var books = new List<Book>();
            var packages = new List<StockPackage>();
            var random = new Random();

            var stocks = new List<Stock>()
            {
                new Stock()
                {
                    Id = 1,
                    City = "Khmelnytskyi",
                    Street = "Institutska 11/3"
                },
                new Stock()
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
                    GenreId = random.Next(1, 15),
                    ImageUri = "pack://application:,,,/Images/willbook.jpg"
                });
                packages.Add(new StockPackage()
                {
                    BookId = books[^1].Id,
                    Quantity = random.Next(1, 2000),
                    StockId = stocks[random.Next(0, 2)].Id
                });
            }

            builder.Entity<Stock>().HasData(stocks);
            builder.Entity<Book>().HasData(books);
            builder.Entity<StockPackage>().HasData(packages);
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
        } 
    }
}
