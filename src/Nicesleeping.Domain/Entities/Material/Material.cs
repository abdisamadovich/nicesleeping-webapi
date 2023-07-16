using System.ComponentModel.DataAnnotations;

namespace NicesleepingShop.Domain.Entities.Material;

public class Material:Auditable
{
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
}
