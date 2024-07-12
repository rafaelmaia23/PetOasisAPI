using Microsoft.AspNetCore.Identity;
using PetOasisAPI.Data.Repository.IRepository;
using PetOasisAPI.Models.Users;

namespace PetOasisAPI.Data.Repository
{
    public class UserRepository : Repository<AppUser>, IUserRepository<AppUser>
    {
        private readonly AppDbContext _appDbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public UserRepository(AppDbContext appDbContext, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) : base(appDbContext)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<AppUser?> GetByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<SignInResult> SignInAsync(AppUser appUser, string password)
        {
            return await _signInManager.PasswordSignInAsync(appUser, password, false, false);
        }
    }
}
