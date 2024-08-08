using PetOasisAPI.Models.Auth;
using PetOasisAPI.Services;
using System.ComponentModel.DataAnnotations;

namespace PetOasisAPI.Routes.Auth;

public static class LoginRoute
{
    public static void MapLoginRoutes(this IEndpointRouteBuilder app)
    {
        // app.MapPost("/login", async (LoginRequest loginRequestDto, LoginService loginService) =>
        // {
        //     var result = await loginService.LoginAsync(loginRequestDto);

        //     if (!result.Success)
        //     {
        //         if(result.StatusCode == 400) return Results.BadRequest(result.Message);
        //         if(result.StatusCode == 404) return Results.NotFound(result.Message);
        //         if(result.StatusCode == 500) return Results.StatusCode(StatusCodes.Status500InternalServerError);
        //     }

        //     return Results.Ok(result.Message);
        // });
    }
}
