using PetOasisAPI.Models.Users;

namespace PetOasisAPI.Models.Pets;

public class Pet
{
    public string Name { get; set; } = null!;
    public string? Sex { get; set; }
    public Species Species { get; set; }
    public string? Breed { get; set; }
    public int Age { get; set; }
    public DateOnly? Birthday { get; set; }
    public double? Weight { get; set; }
    public int TutorId { get; set; }
    public Tutor Tutor { get; set; } = null!;
}
