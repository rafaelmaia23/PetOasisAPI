namespace PetOasisAPI.Models.Responses;

public interface IBaseResponse<T>
{
    bool Success { get; set; }
    int StatusCode { get; set; }
    string? Message { get; set; }
    T? Data { get; set; }
}
