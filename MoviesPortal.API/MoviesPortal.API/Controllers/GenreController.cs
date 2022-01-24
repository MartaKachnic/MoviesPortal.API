using AutoMapper;
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
    public class GenreController : Controller
    {
        private readonly IMovieRepository movieRepository;
        private readonly IMapper mapper;

        public GenreController(IMovieRepository movieRepository, IMapper mapper)
        {
            this.movieRepository = movieRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        [Route("genres")]
        public async Task<IActionResult> GetAllGenres()
        {
            var genreList = await movieRepository.GetGenresAsync();
            if (genreList == null || !genreList.Any())
            {
                return NotFound();
            }
            return Ok(mapper.Map<List<Genre>>(genreList));
        }
    }
}
