using NicesleepingShop.Domain.Entities.Users;

namespace NicesleepingShop.Service.Interfaces.Auth;

public interface ITokenService
{
    public string GenerateToken(User user);
}
