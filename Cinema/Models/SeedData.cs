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
                if (context.Movies.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movies.AddRange(
                    new Movie
                    {
                        Image = "https://resizing.flixster.com/t1FwiRY3Si5W6wVqBxhYDuOyyqc=/fit-in/200x296.2962962962963/v1.bTsxMzIzMTg2MztqOzE4MzMzOzEyMDA7NjA3Mjs5MDAw",
                        Title = "Jumanji: The Next Level",
                        ReleaseDate = DateTime.Parse("13/12/2019"),
                        Genre = "Fantasy Comedy",
                        Rating = 9,
                        Description = " In Jumanji: The Next Level, the gang is back but the game has changed. As they return to Jumanji to rescue one of their own, they discover that nothing is as they expect. The players will have to brave parts unknown and unexplored, from the arid deserts to the snowy mountains, in order to escape the world's most dangerous game.",
                        Video = "https://www.youtube.com/watch?v=rBxcF-r9Ibs"
                    },
                     new Movie
                     {
                         Image = "https://resizing.flixster.com/uXhQPMKSFUVZlDckNlAR8s5zBZY=/fit-in/200x296.2962962962963/v1.bTsxMzIwMzIxODtqOzE4MzMyOzEyMDA7NTQwOzgxMA",
                         Title = "Frozen II",
                         ReleaseDate = DateTime.Parse("21/11/2019"),
                         Genre = "Animation",
                         Rating = 7,
                         Description = "Why was Elsa born with magical powers? The answer is calling her and threatening her kingdom. Together with Anna, Kristoff, Olaf and Sven, she'll set out on a dangerous but remarkable journey. In Frozen, Elsa feared her powers were too much for the world. In 'Frozen 2' she must hope they are enough. ",
                         Video = "https://www.youtube.com/watch?v=nVW9QOIeqQg"
                     },
                      new Movie
                      {
                          Image = "https://resizing.flixster.com/ZgauG4x91nIiP4-f9WoVka-eQcI=/fit-in/200x296.2962962962963/v1.bTsxMzIyMjU4NztqOzE4MzMzOzEyMDA7NjAwOzg4OQ",
                          Title = "Star Wars: The Rise Of Skywalker",
                          ReleaseDate = DateTime.Parse("20/12/2019"),
                          Genre = "Adventure",
                          Rating = 9,
                          Description = "No one's ever really gone... Rey's journey continues and the Skywalker saga concludes in Star Wars: The Rise of Skywalker, coming December 2019. ",
                          Video = "https://www.youtube.com/watch?v=8Qn_spdM5Zg"
                      }


                );
                context.SaveChanges();

                if (context.Halls.Any())
                {
                    return;   // DB has been seeded
                }

            context.Halls.AddRange(
            new Hall
            {
                HallName = "Hall 1",
                NumSeats = 50
            },
            new Hall
            {
                HallName = "Hall 2",
                NumSeats = 75
            },
            new Hall
            {
                HallName = "Hall 3",
                NumSeats = 85
            },
            new Hall
            {
                HallName = "Hall 4",
                NumSeats = 100
            }
                );
                context.SaveChanges();
            }
        }
    }
}
