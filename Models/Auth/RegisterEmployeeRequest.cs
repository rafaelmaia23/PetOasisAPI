using System.ComponentModel.DataAnnotations;

namespace PetOasisAPI.Models.Auth;

public class RegisterEmployeeRequest
{
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public string Surname { get; set; } = null!;
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;
    [Required]
    [DataType(DataType.Password)]
    [Compare(nameof(Password))]
    public string ConfirmPassword { get; set; } = null!;
    [Required]
    public string Position { get; set; } = null!;
    public bool IsAdmin { get; set ;} = false;
}