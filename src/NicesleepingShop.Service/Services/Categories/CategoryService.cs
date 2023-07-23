using NicesleepingShop.DataAccess.Interfaces.Categories;
using NicesleepingShop.DataAccess.Utils;
using NicesleepingShop.Domain.Entities.Categories;
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

    public Task<bool> UpdateAsync(CategoryCreateDto dto)
    {
        throw new NotImplementedException();
    }

}
