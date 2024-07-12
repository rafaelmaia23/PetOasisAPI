using PetOasisAPI.Models.Users;

namespace PetOasisAPI.Models.Responses;

public class RegisterResponse : IBaseResponse<AppUser>
{
    public bool Success { get; set; }
    public int StatusCode { get; set; }
    public string? Message { get; set; }
    public AppUser? Data { get; set; }
}
