using System.Collections.Generic;
using System.Threading.Tasks;
using Supermaket.Domain.Services;
using Supermaket.Domain.Models;
using Supermaket.Domain.Repositories;
using Supermaket.Resources;
using Supermaket.Domain.Services.Communication;

namespace Supermaket.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRespository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(ICategoryRespository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _categoryRepository.ListAsync();
        }

        public async Task<CategoryResponse> SaveAsync(Category category)
        {
            try
            {
                await _categoryRepository.AddAsync(category);
                await _unitOfWork.CompleteAsync();
                return new CategoryResponse(category);
            }
            catch (Exception ex)
            {
                return new CategoryResponse($"Error{ex.Message}");
            }
        }

        public async Task<CategoryResponse> UpdateAsync(int id, Category category)
        {
            var existingCategory = await _categoryRepository.FindByIdAsync(id);
            if (existingCategory == null)
            {
                return new CategoryResponse("Category not found.");
            }
            existingCategory.Name = category.Name;
            try
            {
                _categoryRepository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();
                return new CategoryResponse(existingCategory);
            }
            catch (Exception ex)
            {
                return new CategoryResponse($"error{ex.Message}");
            }
        }

        public async Task<CategoryResponse> DeleteAsync(int id)
        {
            var existingcategory = await _categoryRepository.FindByIdAsync(id);
            if(existingcategory == null)
            {
                return new CategoryResponse("Category not fiund.");
            }
            try
            {
                _categoryRepository.Remove(existingcategory);
                await _unitOfWork.CompleteAsync();
                return new CategoryResponse(existingcategory);
            }
            catch (Exception ex)
            {
                return new CategoryResponse($"Error {ex.Message}");
            }
        }
    }
}
