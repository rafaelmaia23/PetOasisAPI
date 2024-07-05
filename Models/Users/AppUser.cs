using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PetOasisAPI.Models.Users;

public class AppUser : IdentityUser
{
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public string Surname { get; set; } = null!;
}
