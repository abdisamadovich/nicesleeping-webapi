﻿using NicesleepingShop.Service.Dtos.Auth;

namespace NicesleepingShop.Service.Interfaces.Auth;

public interface IAuthService
{
    public Task<(bool Result,int CachedMinutes)> RegisterAsync(RegisterDto dto);

    public Task<(bool Result, int CachedVerificationMinutes)> SendCodeForRegisterAsync(string phone);

    public Task<(bool Result, string Token)> VerifyRegisterAsync(string phone,int code);   
}
