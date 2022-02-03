//Connection to Database

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace Mission04Assignment.Models
{
    public class MovieContext : DbContext
    {
        //Constructor
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
            //Leave Blank for now
        }

        public DbSet<AddMovieResponse> Responses { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            //Seeding Database
            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Action/Adventure"},
                new Category { CategoryId = 2, CategoryName = "Comedy"},
                new Category { CategoryId = 3, CategoryName = "Drama"},
                new Category { CategoryId = 4, CategoryName = "Family"},
                new Category { CategoryId = 5, CategoryName = "Horror/Suspense"},
                new Category { CategoryId = 6, CategoryName = "Miscellaneous"}
            );

            mb.Entity<AddMovieResponse>().HasData(
                    //Seeding Database
                    new AddMovieResponse
                    {
                        MovieId = 1,
                        CategoryId = 1,
                        Title = "Back to the Future",
                        Year = 1985,
                        Director = "Robert Zemeckis",
                        Rating = "PG"
                    },
                    new AddMovieResponse
                    {
                        MovieId = 2,
                        CategoryId = 6,
                        Title = "Little Shop of Horrors",
                        Year = 1986,
                        Director = "Frank Oz",
                        Rating = "PG-13"
                    },
                    new AddMovieResponse
                    {
                        MovieId = 3,
                        CategoryId = 5,
                        Title = "Halloween",
                        Year = 1978,
                        Director = "John Carpenter",
                        Rating = "R",
                        Edited = true
                    }
                );
        }
    }
}
