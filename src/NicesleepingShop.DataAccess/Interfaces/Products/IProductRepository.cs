using NicesleepingShop.DataAccess.Common.Interfaces;
using NicesleepingShop.DataAccess.ViewModels.Products;
using NicesleepingShop.Domain.Entities.Products;

namespace NicesleepingShop.DataAccess.Interfaces.Products;

public interface IProductRepository : IRepository<Product, ProductViewModel>,
    IGetAll<Product>, ISearchable<ProductViewModel>
{
}
