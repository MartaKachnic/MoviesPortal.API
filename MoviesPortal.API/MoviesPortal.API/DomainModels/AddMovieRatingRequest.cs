using System;

namespace MoviesPortal.API.DomainModels
{
    public class AddMovieRatingRequest
    {

       // public Guid UserId { get; set; }
       // public Guid MovieId { get; set; }
        public int Rating { get; set; }
        public DateTime PublishDate { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
    }
}
