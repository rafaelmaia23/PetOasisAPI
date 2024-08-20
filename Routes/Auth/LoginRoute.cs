using System.Net;
using PetOasisAPI.Attributes;
using PetOasisAPI.Models.Auth;
using PetOasisAPI.Models.Responses;
using PetOasisAPI.Services.IServices;

namespace PetOasisAPI.Routes.Auth;

public static class LoginRoute
{
    public static void MapLoginRoutes(this IEndpointRouteBuilder app)
    {
        app.MapPost("/login", [ModelType(typeof(LoginRequest))] async (LoginRequest loginRequest, ILoginService loginService) =>
        {
            var result = await loginService.LoginAsync(loginRequest);

            var response = new APIResponse
            {
                Success = result.Success,
                StatusCode = (HttpStatusCode)result.StatusCode,
                Messages = result.Messages,
                Result = result.Token
            };
            

            if (!response.Success)
            {
                if(result.StatusCode == 400) return Results.BadRequest(response);
                if(result.StatusCode == 404) return Results.NotFound(response);
            }

            return Results.Ok(response);
        });
    }
}
