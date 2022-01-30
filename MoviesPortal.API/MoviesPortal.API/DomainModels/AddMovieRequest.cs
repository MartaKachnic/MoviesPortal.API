using System;

namespace MoviesPortal.API.DomainModels
{
    public class AddMovieRequest
    {
        public string Title { get; set; }
        public string Director { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Poster { get; set; }
        public Guid GenreId { get; set; }
    
    }
}
