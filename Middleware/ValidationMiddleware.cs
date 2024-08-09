using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using PetOasisAPI.Attributes;

namespace PetOasisAPI.Middleware;

public class ValidationMiddleware
{
    private readonly RequestDelegate _next;

    public ValidationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.ContentLength > 0 && context.Request.Method == HttpMethods.Post || context.Request.Method == HttpMethods.Put) 
        {
            context.Request.EnableBuffering();

            using var reader = new StreamReader(context.Request.Body, leaveOpen: true);
            var body = await reader.ReadToEndAsync();
            context.Request.Body.Position = 0;

            var endpoint = context.GetEndpoint();
            var modelTypeAttribute = endpoint?.Metadata.GetMetadata<ModelTypeAttribute>();
            var modelType = modelTypeAttribute?.ModelType;

            if(modelType != null)
            {
                var model = JsonSerializer.Deserialize(body, modelType, new JsonSerializerOptions 
                {
                    PropertyNameCaseInsensitive = true,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                });
                if (model != null)
                {
                    var validationContext = new ValidationContext(model);
                    var validationResults = new List<ValidationResult>();

                    if (!Validator.TryValidateObject(model, validationContext, validationResults, true))
                    {
                        var errors = new Dictionary<string, string>();
                        foreach (var validationResult in validationResults)
                        {
                            foreach (var memberName in validationResult.MemberNames)
                            {
                                errors[memberName] = validationResult.ErrorMessage!;
                            }
                        }

                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        context.Response.ContentType = "application/json";
                        await JsonSerializer.SerializeAsync(context.Response.Body, errors);

                        return;
                    }
                }
            }
        }
        await _next(context);
    }
}
