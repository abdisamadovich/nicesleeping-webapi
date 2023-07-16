namespace NicesleepingShop.Domain.Exception.Users;

public class UserNotFoundException:NotFoundException
{
    public UserNotFoundException()
    {
        this.TitleMessage = "User not found!";
    }
}
