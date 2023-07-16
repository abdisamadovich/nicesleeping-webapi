namespace NicesleepingShop.Domain.Exception.Discounts;

public class DiscountNotFoundException:NotFoundException
{
    public DiscountNotFoundException()
    {
        this.TitleMessage = "Discount not found!";
    }
}
