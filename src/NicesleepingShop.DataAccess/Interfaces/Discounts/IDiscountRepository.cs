using NicesleepingShop.DataAccess.Common.Interfaces;
using NicesleepingShop.DataAccess.Utils;
using NicesleepingShop.Domain.Entities.Discounts;

namespace NicesleepingShop.DataAccess.Interfaces.Categories.Discounts;

public interface IDiscountRepository : IRepository<Discount, Discount>,
    IGetAll<Discount>
{
    //public Task<IList<Discount>> GetAllByDurationAsync(DateTime startAt, DateTime endAt, PaginationParams @params);
}
