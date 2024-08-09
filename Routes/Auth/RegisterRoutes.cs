using PetOasisAPI.Attributes;
using PetOasisAPI.Models.Auth;
using PetOasisAPI.Services.IServices;

namespace PetOasisAPI.Routes.Auth;

public static class RegisterRoutes
{
    public static void MapRegisterRoutes(this IEndpointRouteBuilder app)
    {        
        app.MapPost("/registerTutor", [ModelType(typeof(RegisterTutorRequest))] async (RegisterTutorRequest request, IRegisterService service) =>
        {
            var result = await service.RegisterTutorAsync(request);

            if (!result.Success)
            {
                if(result.StatusCode == 400) return Results.BadRequest(result.Messages);
                if(result.StatusCode == 500) return Results.StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Results.Ok(result.Messages);
        });

        app.MapPost("/registerEmployee", [ModelType(typeof(RegisterEmployeeRequest))] async (RegisterEmployeeRequest request, IRegisterService service) =>
        {
            var result = await service.RegisterEmployeenAsync(request);

            if (!result.Success)
            {
                if(result.StatusCode == 400) return Results.BadRequest(result.Messages);
                if(result.StatusCode == 500) return Results.StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Results.Ok(result.Messages);
        });
    }

    
}
