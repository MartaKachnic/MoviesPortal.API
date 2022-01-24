using Microsoft.EntityFrameworkCore;


namespace MoviesPortal.API.DataModels
{
    public class MoviesContext : DbContext
    {
        public MoviesContext(DbContextOptions<MoviesContext> options) : base(options)
        {

        }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<MovieRating> MovieRating { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Movie>()
                .Property(b => b.AverageRating)
                .HasPrecision(3, 1);
        }
        
        }
}
