using System.ComponentModel.DataAnnotations;

namespace PetOasisAPI.Models.Users;

public class Employee : AppUser
{
    [Required]
    public int EmployeeNumber { get; set; }
    [Required]
    public string Position { get; set; } = null!;
}
