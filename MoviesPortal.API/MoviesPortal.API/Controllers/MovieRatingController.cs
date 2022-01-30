using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MoviesPortal.API.DomainModels;
using MoviesPortal.API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MoviesPortal.API.Controllers
{
    [ApiController]
    public class MovieRatingController: Controller
    {
        private readonly IMovieRatingRepository movieRatingRepository;
        private readonly IMapper mapper;

        public MovieRatingController(IMovieRatingRepository movieRatingRepository, IMapper mapper)
        {
            this.movieRatingRepository = movieRatingRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        [Route("api/movies/{movieId:guid}/rating")]
        public async Task<IActionResult> GetAllMovieRatingsAsync([FromRoute] Guid movieId)
        {
            var movieRatings = await movieRatingRepository.GetMovieRatingsAsync(movieId);
            if (movieRatings == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<List<MovieRating>>(movieRatings));
        }

        [HttpGet]
        [Route("[controller]/{movieId:guid}/{movieRatingId:guid}"), ActionName("GetMovieRatingAsync")]
        public async Task<IActionResult> GetMovieRatingAsync([FromRoute] Guid movieId,[FromRoute] Guid movieRatingId)
        {
            var movieRating = await movieRatingRepository.GetMovieRatingAsync(movieId, movieRatingId);

            if (movieRating == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<MovieRating>(movieRating));
        }

        [HttpPost]
        [Route("movies/{movieId:guid}/comment")]
        public async Task<IActionResult> AddMovieRatingAsync([FromBody] AddMovieRatingRequest request, [FromRoute] Guid movieId)
        {
            request.PublishDate = DateTime.Now;
            
            var movieRating = await movieRatingRepository.AddMovieRating(mapper.Map<DataModels.MovieRating>(request), movieId);
            return CreatedAtAction(nameof(GetMovieRatingAsync), new { movieId = movieRating.MovieId, movieRatingId = movieRating.Id },
                mapper.Map<MovieRating>(movieRating));
        }

        
    }
}
