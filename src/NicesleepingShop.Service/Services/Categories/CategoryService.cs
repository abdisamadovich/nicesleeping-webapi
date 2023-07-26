using NicesleepingShop.DataAccess.Interfaces.Categories;
using NicesleepingShop.DataAccess.Utils;
using NicesleepingShop.Domain.Entities.Categories;
using NicesleepingShop.Domain.Exception.Categories;
using NicesleepingShop.Service.Common.Helpers;
using NicesleepingShop.Service.Dtos.Categories;
using NicesleepingShop.Service.Interfaces.Categories;

namespace NicesleepingShop.Service.Services.Categories;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository category)
    {
        this._categoryRepository = category;
    }
        
    public async Task<long> CountAsync()
    {
        return await _categoryRepository.CountAsync();
    }

    public async Task<bool> CreateAsync(CategoryCreateDto dto)
    {
        var category = new Category();
        category.Name = dto.Name;
        category.Description = dto.Description;
        category.CreatedAt = category.UpdatedAt = TimeHelper.GetDateTime();
        var result = await _categoryRepository.CreateAsync(category);
        return result > 0;
    }

    public async Task<object?> DeleteAsync(long categoryId)
    {
        var dbResult = await _categoryRepository.DeleteAsync(categoryId);
        return dbResult > 0;
    }

    public async Task<IList<Category>> GetAllAsync(PaginationParams @params)
    {
        var category = await _categoryRepository.GetAllAsync(@params);
        return category;
    }

    public async Task<Category> GetByIdAsync(long categoryId)
    {
        var category = await _categoryRepository.GetByIdAsync(categoryId);
        if (category is null) throw new CategoryNotFoundException();
        else return category;
    }

    public async Task<bool> UpdateAsync(long categoryId, CategoryUpdateDto dto)
    {
        var category = await _categoryRepository.GetByIdAsync(categoryId);
        if (category is null) throw new CategoryNotFoundException();

        //Parse new items to category
        category.Name = dto.Name;
        category.Description = dto.Description;
        category.UpdatedAt = TimeHelper.GetDateTime();

        var dbResult = await _categoryRepository.UpdateAsync(categoryId, category);
        return dbResult > 0;
    }
}
