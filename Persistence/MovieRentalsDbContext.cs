using Microsoft.EntityFrameworkCore;
using MovieRentalsAPI.Core.Models;

namespace MovieRentalsAPI.Persistence
{
    public class MovieRentalsDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public MovieRentalsDbContext(DbContextOptions<MovieRentalsDbContext> options)
            : base(options) { }
    }
}