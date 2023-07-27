using Microsoft.Extensions.Configuration;
using NicesleepingShop.Domain.Entities.Users;
using NicesleepingShop.Service.Common.Helpers;
using NicesleepingShop.Service.Interfaces.Auth;
using System.Security.Claims;
using System.Text;

namespace NicesleepingShop.Service.Services.Auth;

public class TokenService 
{
    private readonly IConfiguration _config;
    public TokenService(IConfiguration configuration)
    {
        _config = configuration.GetSection("Jwt");
    }
   /* public string GenerateToken(User user)
    {
        var identityClaims = new Claim[]
        {
        new Claim("Id", user.Id.ToString()),
        new Claim("FirstName", user.FirstName),
        new Claim("Lastname", user.LastName),
        new Claim(ClaimTypes.MobilePhone, user.PhoneNumber),
        new Claim(ClaimTypes.Role user.RoleIdentity.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["SecurityKey"]!));
        var keyCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        int expiresHours = int.Parse(_config["Lifetime"]!);
        var token = new JwtSecurityToken(
            issuer: _config["Issuer"],
            audience: _config["Audience"],
            claims: identityClaims,
            expires: TimeHelper.GetDateTime().AddHours(expiresHours),
            signingCredentials: keyCredentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }*/
}
