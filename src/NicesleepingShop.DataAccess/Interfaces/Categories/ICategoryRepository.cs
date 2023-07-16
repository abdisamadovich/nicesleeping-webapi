using NicesleepingShop.DataAccess.Common.Interfaces;
using NicesleepingShop.Domain.Entities.Categories;

namespace NicesleepingShop.DataAccess.Interfaces.Categories;

public interface ICategoryRepository:IRepository<Category,Category>,
    IGetAll<Category>
{
}
