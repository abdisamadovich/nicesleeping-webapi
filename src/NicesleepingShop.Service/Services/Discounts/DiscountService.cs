using NicesleepingShop.DataAccess.Interfaces.Categories.Discounts;
using NicesleepingShop.DataAccess.Utils;
using NicesleepingShop.Domain.Entities.Discounts;
using NicesleepingShop.Domain.Exception.Categories;
using NicesleepingShop.Domain.Exception.Discounts;
using NicesleepingShop.Service.Common.Helpers;
using NicesleepingShop.Service.Dtos.Discounts;
using NicesleepingShop.Service.Interfaces.Discounts;

namespace NicesleepingShop.Service.Services.Discounts
{
    public class DiscountService : IDiscountService
    {
        private readonly IDiscountRepository _repository;

        public DiscountService(IDiscountRepository repository)
        {
            this._repository = repository;
        }
        public async Task<bool> CreateAsync(DiscountCreateDto dto)
        {
            var dis = new Discount();
            dis.Name = dto.Name;
            dis.Description = dto.Description;
            dis.Percentage = dto.Percentage;
            dis.StartAt = dto.StartAt;
            dis.EndAt = dto.EndAt;
            dis.CreatedAt = dis.UpdatedAt = TimeHelper.GetDateTime();
            var res = await _repository.CreateAsync(dis);
            return res > 0;
        }
        public async Task<bool> DeleteAsync(long discountId)
        {
            var res = await _repository.DeleteAsync(discountId);
            return res > 0;            
        }
        public async Task<IList<Discount>> GetAllAsync(PaginationParams @params)
        {
            var disc = await _repository.GetAllAsync(@params);
            return disc;
        }
        public async Task<Discount> GetByIdAsync(long discountId)
        {
            var disc = await _repository.GetByIdAsync(discountId);
            if (disc is null) throw new DiscountNotFoundException();
            else return disc;
        }
    }
}
