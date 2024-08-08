
using PetOasisAPI.Models.Pets;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetOasisAPI.Models.Users;

public class Tutor : AppUser
{
    public IList<Pet> Pets { get; set; } = [];
}
