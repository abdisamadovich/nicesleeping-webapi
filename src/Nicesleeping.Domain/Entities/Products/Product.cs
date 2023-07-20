using NicesleepingShop.Domain.Enum;

namespace NicesleepingShop.Domain.Entities.Products;

public class Product :Auditable
{
    public long CategoryId { get; set; }

    public string Name { get; set; } = string.Empty;

    public MaterialStatus Status { get; set; }
    
    public string ImagePath { get; set; } = string.Empty;

    public double UnitPrice { get; set; }

    public string Description { get; set; } = string.Empty; 
}
