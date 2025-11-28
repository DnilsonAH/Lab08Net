using AutoMapper;
using Lab08_LINQ.Core.DTOs;
using Lab08_LINQ.Core.Entities;
using Lab08_LINQ.Core.Repositories.Interfaces;
using Lab08_LINQ.Core.Services.Interfaces;

namespace Lab08_LINQ.Core.Services;

public class ClienteService: GenericService<Cliente, ClienteDto>, IClienteService
{
    // Sobrescribimos _clienteRepository para poder acceder a los métodos específicos de IClientesRepository
    private readonly IClientesRepository _clienteRepository;
    
    public ClienteService(IClientesRepository repository, IMapper mapper) : base(repository , mapper)
    {
        // Asignamos el repositorio específico
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
    
    // --- IMPLEMENTACIÓN DE NUEVOS MÉTODOS ---

    public async Task<IEnumerable<ClienteOrdenDto>> GetClientesConOrdenesAsync()
    {
        var clientes = await _clienteRepository.GetClientesConOrdenesAsync();
        return _mapper.Map<IEnumerable<ClienteOrdenDto>>(clientes);
    }

    public async Task<IEnumerable<ClienteProductoCountDto>> GetClientesConTotalProductosAsync()
    {
        return await _clienteRepository.GetClientesConTotalProductosAsync();
    }
}