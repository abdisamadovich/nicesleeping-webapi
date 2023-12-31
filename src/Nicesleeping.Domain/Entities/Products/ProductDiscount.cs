﻿namespace NicesleepingShop.Domain.Entities.Products;

public class ProductDiscount:Auditable
{
    public long ProductId { get; set; }

    public long DiscountId { get; set;}

    public string Description { get; set; } = string.Empty;

    public short Percentage { get; set; }
    
    public DateTime StartAt { get; set; }

    public DateTime EndAt { get; set; }

}
