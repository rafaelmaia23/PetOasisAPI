
using PetOasisAPI.Models.Pets;

namespace PetOasisAPI.Models.Users;

public class Tutor : AppUser
{
    public IEnumerable<Pet>? Pets { get; set; }
}
