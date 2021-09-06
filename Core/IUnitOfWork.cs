using System.Threading.Tasks;

namespace MovieRentalsAPI.Core
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}