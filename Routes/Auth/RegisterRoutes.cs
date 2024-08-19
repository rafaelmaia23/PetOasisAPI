using System.Net;
using PetOasisAPI.Attributes;
using PetOasisAPI.Models.Auth;
using PetOasisAPI.Models.Responses;
using PetOasisAPI.Services.IServices;

namespace PetOasisAPI.Routes.Auth;

public static class RegisterRoutes
{
    public static void MapRegisterRoutes(this IEndpointRouteBuilder app)
    {        
        app.MapPost("/registerTutor", [ModelType(typeof(RegisterTutorRequest))] async (RegisterTutorRequest request, IRegisterService service) =>
        {
            var result = await service.RegisterTutorAsync(request);

            return new APIResponse()
            {
                StatusCode = (HttpStatusCode)result.StatusCode,
                Success = true,
                Messages = result.Messages,
                Result = result.Data
            };
        });

        app.MapPost("/registerEmployee", [ModelType(typeof(RegisterEmployeeRequest))] async (RegisterEmployeeRequest request, IRegisterService service) =>
        {
            var result = await service.RegisterEmployeenAsync(request);

            return new APIResponse()
            {
                StatusCode = (HttpStatusCode)result.StatusCode,
                Success = true,
                Messages = result.Messages,
                Result = result.Data
            };
        });
    }

    
}
