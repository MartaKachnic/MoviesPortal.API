using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MoviesPortal.API.DataModels;

namespace MoviesPortal.API
{
    public class MoviesSeeder
    {
        private readonly MoviesContext _dbContext;

        public MoviesSeeder(MoviesContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                var pendingMigrations = _dbContext.Database.GetPendingMigrations();
                if(pendingMigrations != null && pendingMigrations.Any())
                {
                    _dbContext.Database.Migrate();
                }
                /*
                if (!_dbContext.Genre.Any())
                {
                    var genres = GetGenres();
                    _dbContext.Genre.AddRange(genres);
                    _dbContext.SaveChanges();
                }
                */
                if (!_dbContext.Movie.Any())
                {
                    var movies = GetMovies();
                    _dbContext.Movie.AddRange(movies);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Genre> GetGenres()
        {
            var genres = new List<Genre>()
            {
                new Genre()
                {
                    Name = "Animacja"
                },
            };

            return genres;
        }

        private IEnumerable<Movie> GetMovies()
        {
            var movies = new List<Movie>()
            {
                new Movie()
                {
                    Title = "Alvin i wiewiórki",
                    Director = "Tim Hill",
                    Description = "Do domu autora piosenek trafiają trzy muzycznie utalentowane wiewiórki. Mężczyzna postanawia pomóc im w karierze.",
                    ReleaseDate = DateTime.Parse("2007-12-13T16:26:30.17"),
                    AverageRating = 0,
                    GenreId = Guid.Parse("54182038-4ABF-42FF-B05A-0F4C414CBC8B"),
                    MovieRatings = new List<MovieRating>()
                    {
                        new MovieRating()
                        {
                            Title = "Super film",
                            Rating = 5,
                            Comment = "Polecam",
                            PublishDate = DateTime.Now,
                            UserId = Guid.Parse("F2D4E398-E237-4952-0316-08D9D9082E98"),
                        },

                        new MovieRating()
                        {
                            Title = "Przeciętny",
                            Rating = 3,
                            Comment = "Polecam dla dzieci",
                            PublishDate = DateTime.Now,
                            UserId = Guid.Parse("F2D4E398-E237-4952-0316-08D9D9082E98"),
                        },
                    },
                    
                },
                new Movie()
                {
                    Title = "La La Land",
                    Director = "Damien Chazelle",
                    Description = "Los Angeles. Pianista jazzowy zakochuje się w początkującej aktorce.",
                    ReleaseDate = DateTime.Parse("2016-08-31T09:30:53.704"),
                    AverageRating = 0,
                    GenreId = Guid.Parse("9a0f7aef-4de2-42d8-9269-c1cef418849a"),
                    MovieRatings = new List<MovieRating>()
                    {
                        new MovieRating()
                        {
                            Title = "Piękny musical",
                            Rating = 5,
                            Comment = "Polecam",
                            PublishDate = DateTime.Now,
                            UserId = Guid.Parse("F2D4E398-E237-4952-0316-08D9D9082E98"),
                        },

                        new MovieRating()
                        {
                            Title = "Taki sobie",
                            Rating = 3,
                            Comment = "Można zobaczyć",
                            PublishDate = DateTime.Now,
                            UserId = Guid.Parse("F2D4E398-E237-4952-0316-08D9D9082E98"),
                        },
                    },
                }
              
            };

            return movies;
        }
    }
}
