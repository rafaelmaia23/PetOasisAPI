using PetOasisAPI.Models.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetOasisAPI.Models.Pets;

public class Pet
{
    [Key]
    public string Id { get; set; } = null!;
    [Required]
    public string Name { get; set; } = null!;
    public string? Sex { get; set; }
    [Required]
    public Species Species { get; set; }
    public string? Breed { get; set; }
    [Required]
    public int Age { get; set; }
    public DateOnly? Birthday { get; set; }
    public double? Weight { get; set; }
    [Required]
    public string TutorId { get; set; } = null!;
    [ForeignKey(nameof(TutorId))]
    public Tutor Tutor { get; set; } = null!;
}
