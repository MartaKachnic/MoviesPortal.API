using MoviesPortal.API.DataModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace MoviesPortal.API.DomainModels
{
    public class MovieRating
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }
        public User User { get; set; }
        public DateTime PublishDate { get; set; }
        public int Rating { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
    }
}
