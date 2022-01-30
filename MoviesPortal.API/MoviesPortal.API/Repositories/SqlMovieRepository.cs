using Microsoft.EntityFrameworkCore;
using MoviesPortal.API.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesPortal.API.Repositories
{
    public class SqlMovieRepository : IMovieRepository
    {
        private readonly MoviesContext context;
        public SqlMovieRepository(MoviesContext context)
        {
            this.context = context;
        }
        public async Task<List<Movie>> GetMoviesAsync()
        {
           return await context.Movie.Include(nameof(Genre)).Include(r => r.MovieRatings).ToListAsync();
        }
        public async Task<Movie> GetMovieAsync(Guid movieId)
        {
            return await context.Movie.Include(nameof(Genre)).Include(r => r.MovieRatings).FirstOrDefaultAsync(x => x.Id == movieId);
        }

        public async Task<List<Genre>> GetGenresAsync()
        {
            return await context.Genre.ToListAsync();
        }

        public async Task<bool> Exists(Guid movieId)
        {
            return await context.Movie.AnyAsync(x => x.Id == movieId);
        }

        public async Task<Movie> UpdateMovie(Guid movieId, Movie request)
        {
            var existingMovie = await GetMovieAsync(movieId);
            if (existingMovie != null)
            {
                existingMovie.Title = request.Title;
                existingMovie.Director = request.Director;
                existingMovie.ReleaseDate = request.ReleaseDate;
                existingMovie.Description = request.Description;
                existingMovie.Poster = request.Poster;
                existingMovie.GenreId = request.GenreId;

             
               await context.SaveChangesAsync();
               return existingMovie;
            }
            return null;
        }

        public async Task<Movie> DeleteMovie(Guid movieId)
        {
            var movie = await GetMovieAsync(movieId);
            if (movie != null)
            {
                context.Movie.Remove(movie);
                await context.SaveChangesAsync();
            }
            return null;
        }

        public async Task<Movie> AddMovie(Movie request)
        {
           var movie = await context.Movie.AddAsync(request);
           await context.SaveChangesAsync();
            return movie.Entity;
        }
        
    }
}
