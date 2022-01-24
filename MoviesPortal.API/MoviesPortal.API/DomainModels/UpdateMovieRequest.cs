using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesPortal.API.DomainModels
{
    public class UpdateMovieRequest
    {

        public string Title { get; set; }
        public string Director { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        //public decimal AverageRating { get; set; }
        //public string Poster { get; set; }
        public Guid GenreId { get; set; }
        //  public List<MovieRating> MovieRatings { get; set; }
        /*
        public decimal AverageRatingForDisplay
        {
            get
            {
                if (AverageRating == 0)
                {
                    return 0m;
                }
                return Math.Round(AverageRating * 2, MidpointRounding.AwayFromZero) / 2;
            }
        }
        */
    }
}
