using AutoMapper;
using PetOasisAPI.Models.Dtos.Users;
using PetOasisAPI.Models.Users;

namespace PetOasisAPI.Profiles;

public class AppUserProfile : Profile
{   
    public AppUserProfile()
    {
        CreateMap<AppUser, AppUserDto>().ReverseMap();
    }
}
