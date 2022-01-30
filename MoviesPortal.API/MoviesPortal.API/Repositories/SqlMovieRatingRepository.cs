
using Microsoft.EntityFrameworkCore;
using MoviesPortal.API.DataModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using MoviesPortal.API.Exceptions;

namespace MoviesPortal.API.Repositories
{
    public class SqlMovieRatingRepository : IMovieRatingRepository
    {
        private readonly MoviesContext context;
        private readonly ILogger<SqlMovieRatingRepository> logger;
        private readonly IAuthorizationService authorizationService;
        private readonly IUserContextService userContextService;

        public SqlMovieRatingRepository(MoviesContext context, ILogger<SqlMovieRatingRepository> logger, IAuthorizationService authorizationService, IUserContextService userContextService)
        {
            this.context = context;
            this.logger = logger;
            this.authorizationService = authorizationService;
            this.userContextService = userContextService;
        }

        public async Task<MovieRating> AddMovieRating(MovieRating request, Guid movieId)
        {
            var movie = await GetMovieAsyncById(movieId);
           
            request.MovieId = movieId;
            request.UserId = userContextService.GetUserId;
            var movieRating = await context.MovieRating.AddAsync(request);
            await context.SaveChangesAsync();
            var average =  context.MovieRating.Where(x => x.MovieId == movieId).Average(r => r.Rating);
            
            movie.AverageRating = Convert.ToDecimal(Math.Round(average, 2));
            
            await context.SaveChangesAsync();
            return movieRating.Entity;
        }
        private static decimal CalculateAverageRating(List<MovieRating> ratings)
        {
            if (ratings.Count == 0) return 0.00M;
            var count = ratings.Count();
            decimal sum = 0.00M;
            foreach (var item in ratings)
            {
                sum = sum + item.Rating;
            }

            var avg = sum / count;
            return Math.Round(avg * 2) / 2;
        }



        public async Task<bool> Exists(Guid movieRatingId)
        {
            return await context.MovieRating.AnyAsync(x => x.Id == movieRatingId);
        }

        public async Task<MovieRating> GetMovieRatingAsync(Guid movieId, Guid movieRatingId)
        {
            var movie = await GetMovieAsyncById(movieId);
            var movieRating = context.MovieRating.FirstOrDefault(d => d.Id == movieRatingId);
            if (movieRating is null || movieRating.MovieId != movieId)
            {
                throw new NotFoundException("Movie not found");
            }
            return movieRating;

        }
        public async Task<Movie> GetMovieAsyncById(Guid movieId)
        {
            var movie = await context.Movie.Include(nameof(Genre)).Include(r => r.MovieRatings).FirstOrDefaultAsync(x => x.Id == movieId);
           
            if (movie is null)
                throw new NotFoundException("Movie not found");

            return movie;
        }
        public async Task<List<MovieRating>> GetMovieRatingsAsync(Guid movieId)
        {
            var movieRatings = await context.MovieRating.Include(nameof(User)).Where(x => x.MovieId == movieId).ToListAsync();

            return movieRatings;
        }

    }
}
