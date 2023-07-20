using NicesleepingShop.Domain.Enum;

namespace NicesleepingShop.Domain.Entities.Orders;

public class Order:Auditable
{
    public long UserId { get; set; }

    public long ProductId { get; set; }

    public OrderStatus Status { get; set; }

    public string Description { get; set; } = string.Empty;

    public int Quantity { get; set; }

    public double Heigh { get; set; }

    public double Width { get; set; }

    public double TotalPrice { get; set; }

    public double DiscountPrice { get; set; }

    public double Price { get; set; }

    public PaymentType Payment { get; set; }

    public bool IsPaid { get; set; }
}
