using System.Collections.Generic;
using System.Threading.Tasks;
using MovieRentalsAPI.Core.Models;

namespace MovieRentalsAPI.Core
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetAll();
    }
}