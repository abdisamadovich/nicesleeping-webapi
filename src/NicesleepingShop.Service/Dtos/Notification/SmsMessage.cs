namespace NicesleepingShop.Service.Dtos.Notification;

public class SmsMessage
{
    public string PhoneNumber { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;
}
