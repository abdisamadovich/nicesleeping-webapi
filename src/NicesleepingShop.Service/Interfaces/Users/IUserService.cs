using NicesleepingShop.DataAccess.Utils;
using NicesleepingShop.Domain.Entities.Products;
using NicesleepingShop.Domain.Entities.Users;
using NicesleepingShop.Service.Dtos.Users;

namespace NicesleepingShop.Service.Interfaces.Users
{
    public interface IUserService
    {
        /*public Task<long> CreateAsync(UserCreateDto userCreateDto);*/

        public Task<bool> DeleteAsync(long id);

        public Task<long> CountAsync();

        public Task<IList<User>> GetAllAsync(PaginationParams @params);

        public Task<User> GetByIdAsync(long userId);

        public Task<bool> UpdateAsync(long id, UserUpdateDto userUpdateDto);

    }
}

