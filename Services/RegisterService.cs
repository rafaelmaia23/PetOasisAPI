using PetOasisAPI.Data.Repository.IRepository;
using PetOasisAPI.Models.Auth;
using PetOasisAPI.Models.Responses;
using PetOasisAPI.Models.Users;
using PetOasisAPI.Services.IServices;

namespace PetOasisAPI.Services;

public class RegisterService : IRegisterService
{
    private readonly IUserRepository<AppUser> _userRepository;
    private readonly IGenerateEmployeeNumberService _generateEmployeeNumberService;

    public RegisterService(IUserRepository<AppUser> userRepository, IGenerateEmployeeNumberService generateEmployeeNumberService)
    {
        _userRepository = userRepository;
        _generateEmployeeNumberService = generateEmployeeNumberService;
    }

    private async Task<RegisterResponse> RegisterAsync(AppUser newUser, string password, string role)
    {
        if (await _userRepository.GetByEmailAsync(newUser.Email!) is not null)
        {
            return new RegisterResponse()
            {
                Success = false,
                StatusCode = StatusCodes.Status400BadRequest,
                Messages = new List<string> {"Email already registered"},
                Data = null,     
            };
        }

        var result = await _userRepository.RegisterAsync(newUser, password, role);

        return new RegisterResponse()
        {
            Success = result.Succeeded,
            StatusCode = result.Succeeded ? StatusCodes.Status200OK : StatusCodes.Status400BadRequest,
            Messages = result.Succeeded ? new List<string> {"User created"} : result.Errors.Select(e => e.Description).ToList(),
            Data = result.Succeeded ? newUser : null
        };
    }

    public async Task<RegisterResponse> RegisterEmployeenAsync(RegisterEmployeeRequest request)
    {
        string userRole = request.IsAdmin ? "admin" : "employee";

        var newUser = new Employee()
        {
            Name = request.Name,
            Surname = request.Surname,
            Email = request.Email,
            UserName = request.Email,
            PasswordHash = request.Password,
            Position = request.Position,
            EmployeeNumber = await _generateEmployeeNumberService.Generate(),
        };

        return await RegisterAsync(newUser, request.Password, userRole);
    }

    public async Task<RegisterResponse> RegisterTutorAsync(RegisterTutorRequest request)
    {
        string userRole = "tutor";

        var newUser = new Tutor()
        {
            Name = request.Name,
            Surname = request.Surname,
            Email = request.Email,
            UserName = request.Email,
            PasswordHash = request.Password
        };

        return await RegisterAsync(newUser, request.Password, userRole);
    }
}
