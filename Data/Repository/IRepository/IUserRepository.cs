using Microsoft.AspNetCore.Identity;
using PetOasisAPI.Models.Users;

namespace PetOasisAPI.Data.Repository.IRepository;

public interface IUserRepository<T> : IRepository<T> where T : class
{
    Task<T?> GetByEmailAsync(string email);
    Task<SignInResult> SignInAsync(AppUser appUser, string password);
    //mudar retorno e parametros
    Task<IdentityResult> RegisterAsync(AppUser appUser, string password, string userRole = "tutor");
    Task<IdentityResult> AsignRoleAsync(AppUser appUser, string role);
    Task<bool> CheckPasswordAsync(AppUser appUser, string password);
    Task<int> GetNumberOfEmployeeUsersAsync();
    Task<IList<string>> GetRolesAsync(AppUser appUser);
}
