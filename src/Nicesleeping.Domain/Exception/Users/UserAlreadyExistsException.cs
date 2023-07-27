namespace NicesleepingShop.Domain.Exception.Users;

public class UserAlreadyExistsException : AlreadyExistsException
{
    public UserAlreadyExistsException()
    {
        TitleMessage = "User is already exists";
    }
    public UserAlreadyExistsException(string phone)
    {
        TitleMessage = "This phone is already registered";
    }
}
