using AutoMapper;
using Microsoft.AspNetCore.Http;
using MoviesPortal.API.DomainModels;
using System;


namespace MoviesPortal.API.Profiles.AfterMaps
{
    public class AddMovieRatingRequestAfterMap : IMappingAction<AddMovieRatingRequest, DataModels.MovieRating>
    {

        public void Process(AddMovieRatingRequest source, DataModels.MovieRating destination, ResolutionContext context)
        {
            destination.Id = Guid.NewGuid();
        }
    }
}
