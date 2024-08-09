using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PetOasisAPI.Data.Repository.IRepository;
using PetOasisAPI.Models.Users;

namespace PetOasisAPI.Data.Repository;

public class UserRepository(AppDbContext appDbContext, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager) : Repository<AppUser>(appDbContext), IUserRepository<AppUser>
{
    private readonly AppDbContext _appDbContext = appDbContext;
    private readonly UserManager<AppUser> _userManager = userManager;
    private readonly RoleManager<IdentityRole> _roleManager = roleManager;
    private readonly SignInManager<AppUser> _signInManager = signInManager;

    public async Task<AppUser?> GetByEmailAsync(string email)
    {
        return await _userManager.FindByEmailAsync(email);
    }

    public async Task<IdentityResult> RegisterAsync(AppUser appUser, string password, string userRole = "tutor")
    {
        IdentityResult createUserResult = await _userManager.CreateAsync(appUser, password);

        if(!createUserResult.Succeeded) return createUserResult;

        IdentityResult addRoleResult = await AsignRoleAsync(appUser, userRole);

        return addRoleResult;
    }

    public async Task<IdentityResult> AsignRoleAsync(AppUser appUser, string role)
    {
        IdentityRole? roleFromDb = await _roleManager.FindByNameAsync(role);

        if(roleFromDb is null) 
        {
            await _roleManager.CreateAsync(new IdentityRole() { Name = role});
        }
        return await _userManager.AddToRoleAsync(appUser, role);
    }
    public async Task<SignInResult> SignInAsync(AppUser appUser, string password)
    {
        return await _signInManager.PasswordSignInAsync(appUser, password, false, false);
    }

    public async Task<int> GetNumberOfEmployeeUsersAsync()
    {        
        return await _appDbContext.AppUsers.Where(x => x is Employee).CountAsync();
    }
}
