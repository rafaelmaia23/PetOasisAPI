using PetOasisAPI.Routes.Auth;

namespace PetOasisAPI.Routes;

public static class ConfigRoutes
{
    public static void MapRoutes(this IEndpointRouteBuilder app)
    {
        app.MapRegisterRoutes();
        app.MapLoginRoutes();
    }
    
}
