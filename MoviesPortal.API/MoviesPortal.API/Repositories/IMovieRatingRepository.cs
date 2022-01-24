using Microsoft.AspNetCore.Identity;
using MoviesPortal.API.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MoviesPortal.API.Repositories
{
    public interface IMovieRatingRepository
    {
        Task<List<MovieRating>> GetMovieRatingsAsync(Guid movieId);

        Task<MovieRating> GetMovieRatingAsync(Guid movieId, Guid movieRatingId);

        Task<bool> Exists(Guid movieRatingId);
       // Task<Movie> UpdateMovieRating(Guid studentId, MovieRating request);
       // Task<Movie> DeleteMovieRating(Guid studentId);
        Task<MovieRating> AddMovieRating(MovieRating request, Guid movieId);
    }
}
