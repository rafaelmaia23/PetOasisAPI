namespace PetOasisAPI.Services.IServices;

public interface IGenerateEmployeeNumberService
{
    Task<string> Generate();
}