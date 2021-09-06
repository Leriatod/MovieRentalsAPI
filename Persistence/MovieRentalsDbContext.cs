using Microsoft.EntityFrameworkCore;
using MovieRentalsAPI.Core.Models;

namespace MovieRentalsAPI.Persistence
{
    public class MovieRentalsContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public MovieRentalsContext(DbContextOptions<MovieRentalsContext> options) 
            : base(options) {}
    }
}