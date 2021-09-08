using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieRentalsAPI.Core;
using MovieRentalsAPI.Core.Models;

namespace MovieRentalsAPI.Persistence
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly MovieRentalsDbContext _context;
        public CustomerRepository(MovieRentalsDbContext context)
        {
            _context = context;
        }

        public void Add(Customer customer)
        {
            _context.Add(customer);
        }

        public void Delete(Customer customer)
        {
            _context.Customers.Remove(customer);
        }

        public async Task<Customer> Get(int id)
        {
            return await _context.Customers
                .Include(c => c.Rentals)
                    .ThenInclude(r => r.Movie)
                .SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _context.Customers.ToListAsync();
        }
    }
}