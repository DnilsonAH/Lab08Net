using AutoMapper;
using Lab08_LINQ.Core.Repositories.Interfaces;
using Lab08_LINQ.Core.Services.Interfaces;

namespace Lab08_LINQ.Core.Services;

public class GenericService<Tentity, Tdto> : IGenericService<Tdto> where Tentity : class where Tdto : class
{
    //inyecto el repositorio y el mapper
    protected readonly IGenericRepository<Tentity> _repository;
    protected readonly IMapper _mapper;
    public GenericService(IGenericRepository<Tentity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;

    }
    
    //Con uso de Dto resuelvo el problema de hacer mucho codigo repetido para el CRUD
    public virtual async Task<IEnumerable<Tdto>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();
        var dtos = _mapper.Map<IEnumerable<Tdto>>(entities);
        return dtos;
    }
    
    public virtual async Task<Tdto?> GetByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null) return null;
        var dto = _mapper.Map<Tdto>(entity);
        return dto;
    }
    public virtual async Task AddAsync(Tdto dto)
    {
        var entity = _mapper.Map<Tentity>(dto);
        _repository.AddAsync(entity);
    }
    public virtual async Task UpdateAsync(Tdto dto)
    {
        var entity = _mapper.Map<Tentity>(dto);
        _repository.UpdateAsync(entity);
    }

    public virtual async Task DeleteAsync(int id)
    {
        _repository.DeleteAsync(id);
    }

}