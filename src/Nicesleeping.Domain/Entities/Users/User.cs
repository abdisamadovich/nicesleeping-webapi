using System.ComponentModel.DataAnnotations;

namespace NicesleepingShop.Domain.Entities.Users;

public class User:Auditable
{
    [MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [MaxLength(50)]
    public string LastName { get; set; } = string.Empty;

    [MaxLength(13)]
    public string PhoneNumber { get; set; } = string.Empty;

    public bool PhoneNumberConfirmed { get; set; }

    public string Address { get; set; } = string.Empty; 

    public string PasswordHash { get; set; } = string.Empty;

    public string Salt { get; set; } = string.Empty;

}
