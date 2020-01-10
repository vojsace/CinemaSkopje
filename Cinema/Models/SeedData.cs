using Cinema.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CinemaContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<CinemaContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Image = "https://resizing.flixster.com/t1FwiRY3Si5W6wVqBxhYDuOyyqc=/fit-in/200x296.2962962962963/v1.bTsxMzIzMTg2MztqOzE4MzMzOzEyMDA7NjA3Mjs5MDAw",
                        Title = "Jumanji: The Next Level",
                        ReleaseDate = DateTime.Parse("13/12/2019"),
                        Genre = "Fantasy Comedy",
                        Rating = 9
                    },
                     new Movie
                     {
                         Image = "https://resizing.flixster.com/uXhQPMKSFUVZlDckNlAR8s5zBZY=/fit-in/200x296.2962962962963/v1.bTsxMzIwMzIxODtqOzE4MzMyOzEyMDA7NTQwOzgxMA",
                         Title = "Frozen II",
                         ReleaseDate = DateTime.Parse("21/11/2019"),
                         Genre = "Animation",
                         Rating = 7
                     }


                );
                context.SaveChanges();
            }
        }
    }
}
