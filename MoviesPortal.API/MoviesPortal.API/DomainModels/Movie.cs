using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoviesPortal.API.DomainModels
{
    public class Movie
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal AverageRating { get; set; }
        public string Poster { get; set; }
        public Guid GenreId { get; set; }
        public Genre Genre { get; set; }
        public List<MovieRating> MovieRatings { get; set; }
       
    }

}
