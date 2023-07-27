using NicesleepingShop.DataAccess.Utils;
using NicesleepingShop.Domain.Entities.Discounts;
using NicesleepingShop.Service.Dtos.Discounts;

namespace NicesleepingShop.Service.Interfaces.Discounts
{
    public interface IDiscountService
    {
        public Task<bool> CreateAsync(DiscountCreateDto dto);

        public Task<IList<Discount>> GetAllAsync(PaginationParams @params);

        public Task<bool> DeleteAsync(long discountId);

        public Task<Discount> GetByIdAsync(long discountId);
    }
}
