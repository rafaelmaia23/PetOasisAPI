namespace PetOasisAPI.Models.Auth;

public record UserSession
(   string Id,
    string UserName,
    string Email,
    string Role
);
