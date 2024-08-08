using PetOasisAPI.Models.Auth;
using PetOasisAPI.Models.Responses;

namespace PetOasisAPI.Services.IServices;

public interface IRegisterService
{
    Task<RegisterResponse> RegisterTutorAsync(RegisterTutorRequest request);
    Task<RegisterResponse> RegisterEmployeenAsync(RegisterEmployeeRequest request);
}