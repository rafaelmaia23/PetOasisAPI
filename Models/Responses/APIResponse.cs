using System.Net;

namespace PetOasisAPI.Models.Responses;

public class APIResponse
{
    public APIResponse()
    {
        Messages = new List<string>();
    }
    public HttpStatusCode StatusCode { get; set; }
    public bool Success { get; set; }
    public List<string> Messages { get; set; }
    public object Result { get; set; }
}