using PetOasisAPI.Models.Auth.Dto;
using PetOasisAPI.Models.Responses;

namespace PetOasisAPI.Services.IServices;

public interface ILoginService
{
    Task<LoginResponse> LoginAsync(LoginRequestDto dto);
}
