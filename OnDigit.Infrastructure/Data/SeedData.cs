using Microsoft.EntityFrameworkCore;
using OnDigit.Core.Genres;
using OnDigit.Core.Models.EditionModel;
using OnDigit.Core.Models.GenreModel;
using OnDigit.Core.Models.RoleModel;
using OnDigit.Core.Roles;

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
                    Id = (int)Genres.DetectiveId,
                    Name = "Detective"
                },
                new Genre()
                {
                    Id = (int)Genres.FantasyId,
                    Name = "Fantasy"
                }, 
                new Genre()
                {
                    Id = (int)Genres.AdventuresId,
                    Name = "Adventures"
                },
                new Genre()
                {
                    Id = (int)Genres.NovelId,
                    Name = "Novel"
                },
                new Genre()
                {
                    Id = (int)Genres.ScientificBookId,
                    Name = "Scientific Book"
                },
                new Genre()
                {
                    Id = (int)Genres.FolkloreId,
                    Name = "Folklore"
                },
                new Genre()
                {
                    Id = (int)Genres.HumorId,
                    Name = "Humor"
                },
                new Genre()
                {
                    Id = (int)Genres.PoetryId,
                    Name = "Poetry"
                },
                new Genre()
                {
                    Id = (int)Genres.ProseId,
                    Name = "Prose"
                },
                new Genre()
                {
                    Id = (int)Genres.ChildrensBooksId,
                    Name = "Children's Books"
                },
                new Genre()
                {
                    Id = (int)Genres.DocumentaryLiteratureId,
                    Name = "Documentary Literature"
                },
                new Genre()
                {
                    Id = (int)Genres.EducationBookId,
                    Name = "Education Book"
                },
                new Genre()
                {
                    Id = (int)Genres.EquipmentId,
                    Name = "Equipment"
                },
                new Genre()
                {
                    Id = (int)Genres.BusinessLiteratureId,
                    Name = "Business Literature"
                },
                new Genre()
                {
                    Id = (int)Genres.ReligiousLiteratureId,
                    Name = "Religious Literature"
                });

        public static void SeedEditions(ModelBuilder builder) =>
            builder.Entity<Edition>().HasData(
                new Edition()
                { 
                    Name = "Book1",
                    Description = "Book1",
                    Price = 9.99m,
                    AverageStars = 5,
                    GenreId = (int)Genres.DetectiveId
                },
                new Edition()
                {
                    Name = "Book2",
                    Description = "Book2",
                    Price = 9.99m,
                    AverageStars = 4.4f,
                    GenreId = (int)Genres.FantasyId
                },
                new Edition()
                {
                    Name = "Book3",
                    Description = "Book3",
                    Price = 9.99m,
                    AverageStars = 3.2f,
                    GenreId = (int)Genres.AdventuresId
                },
                new Edition()
                {
                    Name = "Book4",
                    Description = "Book4",
                    Price = 9.99m,
                    AverageStars = 3,
                    GenreId = (int)Genres.NovelId
                },
                new Edition()
                {
                    Name = "Book5",
                    Description = "Book5",
                    Price = 9.99m,
                    AverageStars = 2,
                    GenreId = (int)Genres.ScientificBookId
                },
                new Edition()
                {
                    Name = "Book6",
                    Description = "Book6",
                    Price = 9.99m,
                    AverageStars = 1,
                    GenreId = (int)Genres.FolkloreId
                },
                new Edition()
                {
                    Name = "Book7",
                    Description = "Book7",
                    Price = 9.99m,
                    AverageStars = 0.6f,
                    GenreId = (int)Genres.HumorId
                },
                new Edition()
                {
                    Name = "Book8",
                    Description = "Book8",
                    Price = 9.99m,
                    AverageStars = 0,
                    GenreId = (int)Genres.PoetryId
                },
                new Edition()
                {
                    Name = "Book9",
                    Description = "Book9",
                    Price = 9.99m,
                    AverageStars = 0,
                    GenreId = (int)Genres.ProseId
                },
                new Edition()
                {
                    Name = "Book10",
                    Description = "Book10",
                    Price = 9.99m,
                    AverageStars = 0,
                    GenreId = (int)Genres.ChildrensBooksId
                },
                new Edition()
                {
                    Name = "Book11",
                    Description = "Book11",
                    Price = 9.99m,
                    AverageStars = 0,
                    GenreId = (int)Genres.DocumentaryLiteratureId
                },
                new Edition()
                {
                    Name = "Book12",
                    Description = "Book12",
                    Price = 9.99m,
                    AverageStars = 0,
                    GenreId = (int)Genres.EducationBookId
                },
                new Edition()
                {
                    Name = "Book13",
                    Description = "Book13",
                    Price = 9.99m,
                    AverageStars = 0,
                    GenreId = (int)Genres.EquipmentId
                },
                new Edition()
                {
                    Name = "Book14",
                    Description = "Book14",
                    Price = 9.99m,
                    AverageStars = 0,
                    GenreId = (int)Genres.BusinessLiteratureId
                },
                new Edition()
                {
                    Name = "Book15",
                    Description = "Book15",
                    Price = 9.99m,
                    AverageStars = 0,
                    GenreId = (int)Genres.ReligiousLiteratureId
                });
    }
}
