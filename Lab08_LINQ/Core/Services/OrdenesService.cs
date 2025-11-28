using AutoMapper;
using Lab08_LINQ.Core.DTOs;
using Lab08_LINQ.Core.Entities;
using Lab08_LINQ.Core.Repositories.Interfaces;
using Lab08_LINQ.Core.Services.Interfaces;

namespace Lab08_LINQ.Core.Services;

public class OrdenesService : GenericService<Ordene, OrdeneDto>, IOrdenesService
{
    // Sobrescribimos _ordenesRepository para acceder a métodos específicos
    private readonly IOrdenesRepository _ordenesRepository;

    public OrdenesService(IOrdenesRepository repository, IMapper mapper)
        : base(repository, mapper)
    {
        _ordenesRepository = repository;
    }

    public async Task<Ordene> ObtenerOrdenProductoMasCaro()
    {
        return await _ordenesRepository.ObtenerOrdenProductoMasCaro();
    }

    // Ejercicio 6
    public async Task<IEnumerable<Ordene>> GetOrdersAfterDateAsync(DateTime fecha)
    {
        return await _ordenesRepository.GetOrdersAfterDateAsync(fecha);
    }
    // Ejercicio 9
    public async Task<ClienteDto?> GetClienteConMasPedidosAsync()
    {
        var cliente = await _ordenesRepository.GetClienteConMasPedidosAsync();
        return _mapper.Map<ClienteDto>(cliente);
    }

    // Ejercicio 10
    public async Task<IEnumerable<OrdenDetalleDto>> GetTodosLosDetallesDeOrdenesAsync()
    {
        var detalles = await _ordenesRepository.GetTodosLosDetallesDeOrdenesAsync();
        return _mapper.Map<IEnumerable<OrdenDetalleDto>>(detalles);
    }

    // Ejercicio 11
    public async Task<IEnumerable<ProductoDto>> GetProductosPorClienteAsync(int clienteId)
    {
        var productos = await _ordenesRepository.GetProductosPorClienteAsync(clienteId);
        return _mapper.Map<IEnumerable<ProductoDto>>(productos);
    }
    
    // --- IMPLEMENTACIÓN DE NUEVOS MÉTODOS ---

    public async Task<IEnumerable<OrdenConDetallesDto>> GetOrdenesConDetallesAsync()
    {
        var ordenes = await _ordenesRepository.GetOrdenesConDetallesAsync();
        return _mapper.Map<IEnumerable<OrdenConDetallesDto>>(ordenes);
    }

    public async Task<IEnumerable<ClienteVentasDto>> GetVentasPorClienteAsync()
    {
        return await _ordenesRepository.GetVentasPorClienteAsync();
    }
}
