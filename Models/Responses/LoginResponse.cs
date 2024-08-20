using PetOasisAPI.Models.Dtos.Users;

namespace PetOasisAPI.Models.Responses
{
    public class LoginResponse : IBaseServiceResponse<AppUserDto>
    {        
        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public List<string>? Messages { get; set; }
        public AppUserDto? Data { get; set; }
        public string Token { get; set; } = null!;
    }
}
