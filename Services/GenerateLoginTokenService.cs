using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using PetOasisAPI.Models.Auth;
using PetOasisAPI.Services.IServices;

namespace PetOasisAPI.Services;

public class GenerateLoginTokenService(IConfiguration config) : IGenerateLoginTokenService
{
    private readonly IConfiguration _config = config;

    public string GenerateToken(UserSession userSession)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:key"]!));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var userClaims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, userSession.Id),
            new Claim(ClaimTypes.Name, userSession.UserName),
            new Claim(ClaimTypes.Email, userSession.Email),
            new Claim(ClaimTypes.Role, userSession.Role)
        };
        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: userClaims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: credentials
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
