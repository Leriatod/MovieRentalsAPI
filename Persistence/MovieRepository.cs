using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieRentalsAPI.Core;
using MovieRentalsAPI.Core.Models;

namespace MovieRentalsAPI.Persistence
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieRentalsDbContext _context;

        public MovieRepository(MovieRentalsDbContext context)
        {
            _context = context;
        }

        public async Task<Movie> Get(int id)
        {
            return await _context.Movies.FindAsync(id);
        }

        public async Task<IEnumerable<Movie>> GetAll()
        {
            return await _context.Movies.ToListAsync();
        }
    }
}