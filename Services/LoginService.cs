using AutoMapper;
using PetOasisAPI.Data.Repository.IRepository;
using PetOasisAPI.Models.Auth;
using PetOasisAPI.Models.Dtos.Users;
using PetOasisAPI.Models.Responses;
using PetOasisAPI.Models.Users;
using PetOasisAPI.Services.IServices;

namespace PetOasisAPI.Services;

public class LoginService : ILoginService
{
    private readonly IUserRepository<AppUser> _userRepository;
    private readonly IMapper _mapper;
    private readonly IGenerateLoginTokenService _generateLoginTokenService;

    public LoginService(IUserRepository<AppUser> userRepository, IMapper mapper, IGenerateLoginTokenService generateLoginTokenService)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _generateLoginTokenService = generateLoginTokenService;
    }
    public async Task<LoginResponse> LoginAsync(LoginRequest request)
    {
        var appUser = await _userRepository.GetByEmailAsync(request.Email);
        if(appUser == null)
        {
            return new LoginResponse
            {
                Success = false,
                StatusCode = StatusCodes.Status404NotFound,
                Messages = new List<string> {"User Email not found!"}
            };
        }

        var response = await _userRepository.CheckPasswordAsync(appUser, request.Password);

        if(!response)
        {
            return new LoginResponse
            {
                Success = false,
                StatusCode = StatusCodes.Status400BadRequest,
                Messages = new List<string> {"Login Failed! Password invalid."}
            };
        }
        
        var userRoles = await _userRepository.GetRolesAsync(appUser);
        var userSession = new UserSession(appUser.Id, appUser.UserName!, appUser.Email!, userRoles.First());

        var token =  _generateLoginTokenService.GenerateToken(userSession);

        return new LoginResponse
        {
            Success = true,
            StatusCode = StatusCodes.Status200OK,
            Messages = new List<string> {"Login Succeded!"},
            Data = _mapper.Map<AppUserDto>(appUser),
            Token = token
        };
    }
}
