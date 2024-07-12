namespace PetOasisAPI.Services.IServices
{
    public interface IService<T, TReadDto, TCreateDto, TUpdateDto>
        where T : class
        where TReadDto : class
        where TCreateDto : class
        where TUpdateDto : class
    {
        Task<IEnumerable<TReadDto>> GetAllAsync();
        Task<TReadDto> GetByIdAsync(int id);
        Task<TReadDto> CreateAsync(TCreateDto dto);
        Task<TReadDto> UpdateAsync(int id, TUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
