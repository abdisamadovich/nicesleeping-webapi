using NicesleepingShop.DataAccess.Utils;
using NicesleepingShop.Domain.Entities.Products;
using NicesleepingShop.Service.Dtos.Products;

namespace NicesleepingShop.Service.Interfaces.Products;

public interface IProductService
{
    public Task<bool> CreateAsync(ProductCreateDto dto);

    public Task<bool> UpdateAsync(long ProductId, ProductUpdateDto dto);

    public Task<IList<Product>> GetAllAsync(PaginationParams @params);

    public Task<bool> DeleteAsync(long productId);

    public Task<long> CountAsync();

    public Task<Product> GetByIdAsync(long productId);
}
