using System.Collections.Generic;
using System.Threading.Tasks;
using MovieRentalsAPI.Core.Models;

namespace MovieRentalsAPI.Core
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAll();
    }
}