using System;

namespace MoviesPortal.API.DomainModels
{
    public class AddMovieRatingRequest
    {
        public int Rating { get; set; }
        public DateTime PublishDate { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
    }
}
