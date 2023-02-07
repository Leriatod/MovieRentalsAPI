using MovieRentalsAPI.Core;
using MovieRentalsAPI.Core.Models;

namespace MovieRentalsAPI.Persistence
{
    public class RentalRepository : IRentalRepository
    {
        private readonly MovieRentalsDbContext _context;

        public RentalRepository(MovieRentalsDbContext context)
        {
            _context = context;
        }

        public void Add(Rental rental)
        {
            _context.Rentals.Add(rental);
        }
    }
}