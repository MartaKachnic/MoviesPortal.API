using MoviesPortal.API.DataModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesPortal.API.Repositories
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetMoviesAsync();

        Task<Movie> GetMovieAsync(Guid movieId);
        Task<List<Genre>> GetGenresAsync();
        Task<bool> Exists(Guid movieId);
        Task<Movie> UpdateMovie(Guid movieId, Movie request);
        Task<Movie> DeleteMovie(Guid movieId);
        Task<Movie> AddMovie(Movie request);
    }
}
