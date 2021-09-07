using Microsoft.EntityFrameworkCore;
using MovieRentalsAPI.Core.Models;

namespace MovieRentalsAPI.Persistence
{
    public class MovieRentalsDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public MovieRentalsDbContext(DbContextOptions<MovieRentalsDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rental>().HasKey(r => new { r.CustomerId, r.MovieId });
        }
    }
}