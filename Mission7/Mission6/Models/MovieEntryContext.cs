using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6.Models
{
    public class MovieEntryContext : DbContext
    {
        public MovieEntryContext(DbContextOptions<MovieEntryContext> options) : base(options) //contructor only runs the first time a class runs
        {
            //leave blank for now
        }
        public DbSet<EntryResponse> Responses { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb) //seeding the db
        {
            mb.Entity<EntryResponse>().HasData(
                new EntryResponse
                {
                    MovieId = 1,
                    movieTitle = "How To Lose A Guy In Ten Days",
                    categoryID = 3,
                    Year=2003,
                    directorName="Donald Petrie",
                    Rating="PG-13",
                    Edited=true,
                    lentTo=""
                },
                new EntryResponse
                {
                    MovieId = 2,
                    movieTitle = "The Lego Batman Movie",
                    categoryID = 5,
                    Year = 2017,
                    directorName = "Chris McKay",
                    Rating = "PG",
                    Edited = true,
                    lentTo = ""
                },
                new EntryResponse
                {
                    MovieId = 3,
                    movieTitle = "It's A Wonderful Life",
                    categoryID = 4,
                    Year = 1946,
                    directorName = "Frank Capra",
                    Rating = "PG",
                    Edited = true,
                    lentTo = ""
                }

            );
            //The Category Pre-Seeded Info
            mb.Entity<Category>().HasData(
                new Category { categoryID = 1, categoryName = "Romance" },
                new Category { categoryID = 2, categoryName = "Comedy" },
                new Category { categoryID = 3, categoryName = "Romantic Comedy" },
                new Category { categoryID = 4, categoryName = "Drama" },
                new Category { categoryID = 5, categoryName = "Action/Adventure" },
                new Category { categoryID = 6, categoryName = "Horror" },
                new Category { categoryID = 7, categoryName = "Science Fiction" },
                new Category { categoryID = 8, categoryName = "Documentary" },
                new Category { categoryID = 9, categoryName = "Fantasy" },
                new Category { categoryID = 10, categoryName = "Historical Fiction" },
                new Category { categoryID = 11, categoryName = "Musical" },
                new Category { categoryID = 12, categoryName = "Murder Mystery" }
                );
        }
    }
}
