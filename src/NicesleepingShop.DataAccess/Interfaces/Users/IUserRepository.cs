using NicesleepingShop.DataAccess.Common.Interfaces;
using NicesleepingShop.DataAccess.ViewModels.Users;
using NicesleepingShop.Domain.Entities.Users;

namespace NicesleepingShop.DataAccess.Interfaces.Users;

public interface IUserRepository : IRepository<User, User>, IGetAll<User>, 
    ISearchable<UserViewModel>
{
    public Task<User?> GetByPhoneAsync(string phone);
}
