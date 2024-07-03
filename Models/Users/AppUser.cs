﻿using Microsoft.AspNetCore.Identity;

namespace PetOasisAPI.Models.Users;

public class AppUser : IdentityUser
{
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
}
