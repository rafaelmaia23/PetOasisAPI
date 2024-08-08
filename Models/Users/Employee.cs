using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using PetOasisAPI.Data;

namespace PetOasisAPI.Models.Users;

public class Employee : AppUser
{
    private static int _currentEmployeeNumber = 0;

    [Required]
    public string EmployeeNumber { get; set; }
    [Required]
    public string Position { get; set; } = null!;

    public Employee()
    {
        _currentEmployeeNumber++;
        EmployeeNumber = GenerateEmployeeNumber();
    }
    private string GenerateEmployeeNumber()
    {        
        return $"{DateTime.Now.Year}{_currentEmployeeNumber:D3}";
    }

    public static async Task InitializeEmployeeNumberAsync(AppDbContext context)
    {
        _currentEmployeeNumber = await context.Employees.CountAsync();
    }
}
