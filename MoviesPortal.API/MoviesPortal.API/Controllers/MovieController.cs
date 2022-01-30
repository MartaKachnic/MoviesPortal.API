using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesPortal.API.DomainModels;
using MoviesPortal.API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesPortal.API.Controllers
{
    [ApiController]
    public class MovieController : Controller
    {
        private readonly IMovieRepository movieRepository;
        private readonly IMapper mapper;

        public MovieController(IMovieRepository movieRepository, IMapper mapper)
        {
            this.movieRepository = movieRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        [Route("movies")]
        public async Task<IActionResult> GetAllMoviesAsync()
        {
            var movies = await movieRepository.GetMoviesAsync();

            return Ok(mapper.Map<List<Movie>>(movies));
        }

        [HttpGet]
        [Route("movies/{movieId:guid}"), ActionName("GetMovieAsync")]
        public async Task<IActionResult> GetMovieAsync([FromRoute] Guid movieId)
        {
            var movie = await movieRepository.GetMovieAsync(movieId);

            if (movie == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<Movie>(movie));
        }
        [HttpPut]
        [Route("movies/{movieId:guid}")]
        public async Task<IActionResult> UpdateMovieAsync([FromRoute] Guid movieId, [FromBody] UpdateMovieRequest request)
        {

            if (await movieRepository.Exists(movieId))
            {
                var updatedMovie = await movieRepository.UpdateMovie(movieId, mapper.Map<DataModels.Movie>(request));
                if (updatedMovie != null)
                {
                    return Ok(mapper.Map<Movie>(updatedMovie));
                }
            }
            return NotFound();

        }
        [HttpDelete]
        [Route("movies/{movieId:guid}")]
        public async Task<IActionResult> DeleteMovieAsync([FromRoute] Guid movieId)
        {
            if (await movieRepository.Exists(movieId))
            {
                var movie = await movieRepository.DeleteMovie(movieId);
                return Ok(mapper.Map<Movie>(movie));
            }
            return NotFound();
        }

        [HttpPost]
        [Route("movies/Add")]
        public async Task<IActionResult> AddMovieAsync([FromBody] AddMovieRequest request)
        {
            var movie = await movieRepository.AddMovie(mapper.Map<DataModels.Movie>(request));
            return CreatedAtAction(nameof(GetMovieAsync), new { movieId = movie.Id },
                mapper.Map<Movie>(movie));
        }
      
    }
}
