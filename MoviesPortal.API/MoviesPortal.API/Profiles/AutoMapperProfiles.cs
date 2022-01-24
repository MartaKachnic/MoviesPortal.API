using AutoMapper;
using MoviesPortal.API.DomainModels;
using DataModels = MoviesPortal.API.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoviesPortal.API.Profiles.AfterMaps;

namespace MoviesPortal.API.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
             CreateMap<DataModels.Movie, Movie>()
                .ReverseMap();

            CreateMap<DataModels.MovieRating, MovieRating>()
                .ReverseMap();

            CreateMap<DataModels.Genre, Genre>()
                .ReverseMap();


            CreateMap<UpdateMovieRequest, DataModels.Movie>()
                .AfterMap<UpdateMovieRequestAfterMap>();

            CreateMap<AddMovieRequest, DataModels.Movie>()
                .AfterMap<AddMovieRequestAfterMap>();

            CreateMap<AddMovieRatingRequest, DataModels.MovieRating>()
                .AfterMap<AddMovieRatingRequestAfterMap>();
                
        }
    }
}
