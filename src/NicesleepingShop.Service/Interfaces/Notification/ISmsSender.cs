using NicesleepingShop.Service.Dtos.Notification;

namespace NicesleepingShop.Service.Interfaces.Notification;

public interface ISmsSender
{
    public Task<bool> SendAsync(SmsMessage smsMessage);

}
