using Microsoft.AspNetCore.Http;
using NicesleepingShop.Domain.Enum;

namespace NicesleepingShop.Service.Dtos.Products;

public class ProductUpdateDto
{
    public long categoryId { get; set; }

    public string Name { get; set; } = string.Empty;

    public MaterialStatus status { get; set; }
    
    public IFormFile? Image { get; set; }

    public double UnitPrice { get; set; }

    public string Description { get; set; } = string.Empty;

    
}
