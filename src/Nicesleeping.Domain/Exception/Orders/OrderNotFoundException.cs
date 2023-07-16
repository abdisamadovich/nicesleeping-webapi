namespace NicesleepingShop.Domain.Exception.Orders;

public class OrderNotFoundException:NotFoundException
{
    public OrderNotFoundException()
    {
        this.TitleMessage = "Order not found!";
    }
}
