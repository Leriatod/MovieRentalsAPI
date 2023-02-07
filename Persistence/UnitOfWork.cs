using System.Threading.Tasks;
using MovieRentalsAPI.Core;

namespace MovieRentalsAPI.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MovieRentalsDbContext _context;

        public UnitOfWork(MovieRentalsDbContext context)
        {
            _context = context;
        }

        public async Task Complete()
        {
            await _context.SaveChangesAsync();
        }
    }
}