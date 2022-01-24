using AutoMapper;
using MoviesPortal.API.DomainModels;
using DataModels = MoviesPortal.API.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesPortal.API.Profiles.AfterMaps
{
    public class UpdateMovieRequestAfterMap : IMappingAction<UpdateMovieRequest, DataModels.Movie>
    {
        public void Process(UpdateMovieRequest source, DataModels.Movie destination, ResolutionContext context)
        {
                      

        }
    }
}
