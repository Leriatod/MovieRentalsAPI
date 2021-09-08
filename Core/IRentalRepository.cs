using MovieRentalsAPI.Core.Models;

namespace MovieRentalsAPI.Core
{
    public interface IRentalRepository
    {
        void Add(Rental rental);
    }
}