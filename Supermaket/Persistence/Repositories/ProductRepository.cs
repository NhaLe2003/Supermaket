using Microsoft.EntityFrameworkCore;
using Supermaket.Domain.Models;
using Supermaket.Domain.Repositories;
using Supermaket.Persistence.Contexts;

namespace Supermaket.Persistence.Repositories
{
    public class ProductRepository : BaseRepository , IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context) { }
        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await _context.Products.ToListAsync();
        }
        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
        }
    }
}
