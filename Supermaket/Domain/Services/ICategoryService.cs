
using Supermaket.Domain.Models;
using Supermaket.Domain.Services.Communication;
using Supermaket.Resources;

namespace Supermaket.Domain.Services
{
    public interface ICategoryService
    {
        
        Task<IEnumerable<Category>> ListAsync();
        Task<CategoryResponse> SaveAsync(Category category);
        Task<CategoryResponse> UpdateAsync(int id, Category category);
        Task<CategoryResponse> DeleteAsync(int id);
    }
}
