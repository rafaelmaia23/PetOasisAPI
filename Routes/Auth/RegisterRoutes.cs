namespace PetOasisAPI.Routes.Auth;

public static class RegisterRoutes
{
    public static void MapRegisterRoutes(this IEndpointRouteBuilder app)
    {
        app.MapPost("/register", async (RegisterRequest registerRequest, RegisterService registerService) =>
        {
            //validação model

            //call service

            //return response
        });
    }
}
