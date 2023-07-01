using Supermaket.Domain.Models;
using Supermaket.Domain.Services.Communication;

namespace Supermaket.Domain.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> ListAsync();
        Task<ProductResponse> SaveAsync(Product product);
    }
}
