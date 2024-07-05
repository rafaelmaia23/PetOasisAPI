using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetOasisAPI.Models.Pets;
using PetOasisAPI.Models.Users;

namespace PetOasisAPI.Data;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {        
    }

    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Tutor> Tutors { get; set; }
    public DbSet<Pet> Pets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure inheritance for AppUser, Employee, and Tutor
        modelBuilder.Entity<AppUser>()
            .HasDiscriminator<string>("UserType")
            .HasValue<AppUser>("AppUser")
            .HasValue<Employee>("Employee")
            .HasValue<Tutor>("Tutor");

        modelBuilder.Entity<Tutor>()
            .HasMany(t => t.Pets)
            .WithOne(p => p.Tutor)
            .HasForeignKey(p => p.TutorId);
    }

}
