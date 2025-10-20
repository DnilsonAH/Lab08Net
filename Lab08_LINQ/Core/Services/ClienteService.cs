using AutoMapper;
using Lab08_LINQ.Core.DTOs;
using Lab08_LINQ.Core.Entities;
using Lab08_LINQ.Core.Repositories.Interfaces;
using Lab08_LINQ.Core.Services.Interfaces;

namespace Lab08_LINQ.Core.Services;

public class ClienteService: GenericService<Cliente, ClienteDto>, IClienteService
{
    protected readonly IClientesRepository _clienteRepository;
    public ClienteService(IClientesRepository repository, IMapper mapper) : base(repository , mapper)
    {
        _clienteRepository = repository;
    }
    //1. método GetClientesConZAsync
    public async Task<IEnumerable<ClienteDto>> GetClientesConZAsync(string letra)
    {
        var clientesConZ = await _clienteRepository.GetClientesConZAsync(letra);
        var clientesDto = _mapper.Map<IEnumerable<ClienteDto>>(clientesConZ);
        return clientesDto;
    }
    
    /// Ejercicio 12: Clientes que compraron un producto específico
    public async Task<IEnumerable<ClienteDto>> GetClientesPorProductoAsync(int productoId)
    {
        var clientes = await _clienteRepository.GetClientesPorProductoAsync(productoId);
        return _mapper.Map<IEnumerable<ClienteDto>>(clientes);
    }
}