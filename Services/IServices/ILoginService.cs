using PetOasisAPI.Models.Auth;
using PetOasisAPI.Models.Responses;

namespace PetOasisAPI.Services.IServices;

public interface ILoginService
{
    Task<LoginResponse> LoginAsync(LoginRequest dto);
}
