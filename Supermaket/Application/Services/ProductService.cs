using Supermaket.Domain.Models;
using Supermaket.Domain.Repositories;
using Supermaket.Domain.Services;
using Supermaket.Domain.Services.Communication;
using Supermaket.Persistence.Repositories;
using Supermaket.Resources;

namespace Supermaket.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IProductRepository productRepository , IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await _productRepository.ListAsync();
        }
        public async Task<ProductResponse> SaveAsync(Product product)
        {
            try
            {
                await _productRepository.AddAsync(product);
                await _unitOfWork.CompleteAsync();
                return new ProductResponse(product);
            }
            catch (Exception ex)
            {
                return new ProductResponse($"Error{ex.Message}");
            }
        }
    }
}
