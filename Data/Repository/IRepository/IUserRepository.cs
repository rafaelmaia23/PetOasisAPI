namespace PetOasisAPI.Data.Repository.IRepository
{
    public interface IUserRepository<T> : IRepository<T> where T : class
    {
        Task<T?> GetByEmailAsync(string email);
    }
}
