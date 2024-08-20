using PetOasisAPI.Models.Auth;

namespace PetOasisAPI.Services.IServices;

public interface IGenerateLoginTokenService
{
    string GenerateToken(UserSession userSession);
}
