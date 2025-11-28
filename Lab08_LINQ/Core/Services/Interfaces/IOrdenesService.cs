using Lab08_LINQ.Core.DTOs;
using Lab08_LINQ.Core.Entities;

namespace Lab08_LINQ.Core.Services.Interfaces;

public interface IOrdenesService : IGenericService<OrdeneDto>
{
    Task<Ordene> ObtenerOrdenProductoMasCaro();
    
    // Ejercicio 6
    Task<IEnumerable<Ordene>> GetOrdersAfterDateAsync(DateTime fecha);
    
    // Ejercicio 9
    Task<ClienteDto?> GetClienteConMasPedidosAsync();
    // Ejercicio 10
    Task<IEnumerable<OrdenDetalleDto>> GetTodosLosDetallesDeOrdenesAsync();
    // Ejercicio 11
    Task<IEnumerable<ProductoDto>> GetProductosPorClienteAsync(int clienteId);
    

    Task<IEnumerable<OrdenConDetallesDto>> GetOrdenesConDetallesAsync();
    Task<IEnumerable<ClienteVentasDto>> GetVentasPorClienteAsync();
}