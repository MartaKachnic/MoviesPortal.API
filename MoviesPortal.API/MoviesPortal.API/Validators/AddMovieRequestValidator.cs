using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.AspNetCore;
using MoviesPortal.API.DomainModels;
using MoviesPortal.API.Repositories;

namespace MoviesPortal.API.Validators
{
    public class AddMovieRequestValidator : AbstractValidator<AddMovieRequest>
    {
        public AddMovieRequestValidator(IMovieRepository movieRepository)
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Director).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.ReleaseDate).NotEmpty();
            RuleFor(x => x.GenreId).NotEmpty().Must(id =>
            {
                var genre = movieRepository.GetGenresAsync().Result.ToList().FirstOrDefault(x => x.Id == id);

                if (genre != null)
                {
                    return true;
                }
                return false;
            }).WithMessage("Proszę wybierz gatunek");

        }
    }
}
