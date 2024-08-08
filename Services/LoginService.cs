using Microsoft.AspNetCore.Identity;
using PetOasisAPI.Data.Repository;
using PetOasisAPI.Models.Auth;
using PetOasisAPI.Models.Responses;
using PetOasisAPI.Models.Users;
using PetOasisAPI.Services.IServices;

namespace PetOasisAPI.Services;

public class LoginService : ILoginService
{
    private readonly UserRepository _userRepository;

    public LoginService(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<LoginResponse> LoginAsync(LoginRequest dto)
    {
        var appUser = await _userRepository.GetByEmailAsync(dto.Email);
        if(appUser == null)
        {
            return new LoginResponse
            {
                Success = false,
                StatusCode = StatusCodes.Status500InternalServerError,
                Messages = new List<string> {"User Email not found!"}
            };
        }

        var response = await _userRepository.SignInAsync(appUser, dto.Password);

        if(!response.Succeeded)
        {
            return new LoginResponse
            {
                Success = false,
                StatusCode = StatusCodes.Status400BadRequest,
                Messages = new List<string> {"Login Failed! Email or password invalid."}
            };
        }

        return new LoginResponse
        {
            Success = true,
            StatusCode = StatusCodes.Status200OK,
            Messages = new List<string> {"Login Succeded!"},
            Data = appUser,
            Token = "Token here"
        };
    }
}
