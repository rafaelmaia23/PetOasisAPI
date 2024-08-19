﻿namespace PetOasisAPI.Models.Responses;

public interface IBaseServiceResponse<T>
{
    bool Success { get; set; }
    int StatusCode { get; set; }
    List<string>? Messages { get; set; }
    T? Data { get; set; }
}
