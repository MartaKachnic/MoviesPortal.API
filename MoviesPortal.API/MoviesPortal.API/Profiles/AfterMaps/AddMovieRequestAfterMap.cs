using AutoMapper;
using MoviesPortal.API.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesPortal.API.Profiles.AfterMaps
{
    public class AddMovieRequestAfterMap : IMappingAction<AddMovieRequest, DataModels.Movie>
    {
        public void Process(AddMovieRequest source, DataModels.Movie destination, ResolutionContext context)
        {
            destination.Id = Guid.NewGuid();

        }
    }
}
