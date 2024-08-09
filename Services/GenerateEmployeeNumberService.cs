using PetOasisAPI.Data.Repository.IRepository;
using PetOasisAPI.Models.Users;
using PetOasisAPI.Services.IServices;

namespace PetOasisAPI.Services;

public class GenerateEmployeeNumberService : IGenerateEmployeeNumberService
{
    private readonly IUserRepository<AppUser> _userRepository;

    public GenerateEmployeeNumberService(IUserRepository<AppUser> userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<string> Generate()
    {
        return $"{DateTime.Now.Year}{await _userRepository.GetNumberOfEmployeeUsersAsync():D3}";
    }
}