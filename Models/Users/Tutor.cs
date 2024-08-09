
using PetOasisAPI.Models.Pets;

namespace PetOasisAPI.Models.Users;

public class Tutor : AppUser
{
    public IList<Pet> Pets { get; set; } = [];
}
