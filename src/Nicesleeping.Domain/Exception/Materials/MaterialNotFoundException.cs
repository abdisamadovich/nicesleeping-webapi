namespace NicesleepingShop.Domain.Exception.Materials;

public class MaterialNotFoundException:NotFoundException
{
    public MaterialNotFoundException()
    {
        this.TitleMessage = "Material not found!";
    }
}
