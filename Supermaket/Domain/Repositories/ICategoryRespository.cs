
using Supermaket.Domain.Models;

namespace Supermaket.Domain.Repositories
{
    public interface ICategoryRespository
    {
        
        Task<IEnumerable<Category>> ListAsync();
        Task AddAsync(Category category);
        Task<Category> FindByIdAsync(int id);
        void Update(Category category);
        void Remove(Category category);
       
        
    }
}
