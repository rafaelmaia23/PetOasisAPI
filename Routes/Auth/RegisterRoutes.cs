using System.Net;
using Microsoft.AspNetCore.Mvc;
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

            var response = new APIResponse()
            {
                StatusCode = (HttpStatusCode)result.StatusCode,
                Success = true,
                Messages = result.Messages,
                Result = result.Data
            };

            if(!result.Success) return Results.BadRequest(response);
            return Results.Ok(response);
        })
        .WithMetadata(new ProducesResponseTypeAttribute(StatusCodes.Status200OK))
        .WithMetadata(new ProducesResponseTypeAttribute(StatusCodes.Status400BadRequest));

        app.MapPost("/registerEmployee", [ModelType(typeof(RegisterEmployeeRequest))] async (RegisterEmployeeRequest request, IRegisterService service) =>
        {
            var result = await service.RegisterEmployeenAsync(request);

            var response = new APIResponse()
            {
                StatusCode = (HttpStatusCode)result.StatusCode,
                Success = true,
                Messages = result.Messages,
                Result = result.Data
            };

            if(!result.Success) return Results.BadRequest(response);
            return Results.Ok(response);
        })
        .WithMetadata(new ProducesResponseTypeAttribute(StatusCodes.Status200OK))
        .WithMetadata(new ProducesResponseTypeAttribute(StatusCodes.Status400BadRequest))
        .WithMetadata(new ProducesResponseTypeAttribute(StatusCodes.Status401Unauthorized))
        .WithMetadata(new ProducesResponseTypeAttribute(StatusCodes.Status403Forbidden))
        .RequireAuthorization(policy => policy.RequireRole("admin"));
    }

    
}
