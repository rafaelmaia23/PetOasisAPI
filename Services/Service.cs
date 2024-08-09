using AutoMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using PetOasisAPI.Data.Repository.IRepository;
using PetOasisAPI.Services.IServices;

namespace PetOasisAPI.Services;

public abstract class Service<T, TReadDto, TCreateDto, TUpdateDto> :
    IService<T, TReadDto, TCreateDto, TUpdateDto> 
    where T : class 
    where TReadDto : class 
    where TCreateDto : class
    where TUpdateDto : class 
{
    protected readonly IRepository<T> _repository;
    protected readonly IMapper _mapper;

    protected Service(IRepository<T> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<TReadDto>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<TReadDto>>(entities);
    }

    public async Task<TReadDto> GetByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return _mapper.Map<TReadDto>(entity);
    }

    public async Task<TReadDto> CreateAsync(TCreateDto dto)
    {
        var entity = _mapper.Map<T>(dto);
        await _repository.CreateAsync(entity);
        return _mapper.Map<TReadDto>(entity);
    }
    public async Task<TReadDto?> UpdateAsync(int id, TUpdateDto dto)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
        {
            return null;
        }
        _mapper.Map(dto, entity);
        await _repository.UpdateAsync(entity);
        return _mapper.Map<TReadDto>(entity);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
        {
            return false;
        }
        await _repository.DeleteAsync(entity);
        return true;
    }

}
