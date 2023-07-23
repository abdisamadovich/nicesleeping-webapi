using NicesleepingShop.DataAccess.Utils;
using NicesleepingShop.Domain.Entities.Categories;
using NicesleepingShop.Service.Dtos.Categories;

namespace NicesleepingShop.Service.Interfaces.Categories;

public interface ICategoryService
{
    public Task<bool> CreateAsync(CategoryCreateDto dto);
    public Task<bool> UpdateAsync(CategoryCreateDto dto);

    public Task<IList<Category>> GetAllAsync(PaginationParams @params);
    public Task<object?> DeleteAsync(long categoryId);

    public Task<long> CountAsync();
}
