using Supermaket.Domain.Models;

namespace Supermaket.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> ListAsync();
        Task AddAsync(Product product);
    }
}
