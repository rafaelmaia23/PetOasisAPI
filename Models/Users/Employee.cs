namespace PetOasisAPI.Models.Users;

public class Employee : AppUser
{
    public int EmployeeNumber { get; set; }
    public string Position { get; set; } = null!;
}
