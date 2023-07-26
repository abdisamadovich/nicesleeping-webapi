using NicesleepingShop.Service.Dtos.Products;

namespace NicesleepingShop.Service.Interfaces.Products;

public interface IProductService
{
    public Task<bool> CreateAsync(ProductCreateDto dto);

}
