using NicesleepingShop.Service.Dtos.Notification;
using NicesleepingShop.Service.Interfaces.Notification;

namespace NicesleepingShop.Service.Services.Notification;

public class SmsSender : ISmsSender
{
    public Task<bool> SendAsync(SmsMessage smsMessage)
    {
        throw new NotImplementedException();
    }
}
