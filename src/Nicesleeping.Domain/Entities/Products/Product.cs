namespace NicesleepingShop.Domain.Entities.Products;

public class Product :Auditable
{
    public long DiscountId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string ImagePath { get; set; } = string.Empty;

    public double UnitPrice { get; set; }

    public string Description { get; set; } = string.Empty; 
}
