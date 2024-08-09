using System.ComponentModel.DataAnnotations;

namespace PetOasisAPI.Models.Users;

public class Employee : AppUser
{
    [Required]
    public string EmployeeNumber { get; set; } = null!;
    [Required]
    public string Position { get; set; } = null!;
}
