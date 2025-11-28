using Lab08_LINQ.Core.DTOs;
using Lab08_LINQ.Core.Entities;

namespace Lab08_LINQ.Core.Repositories.Interfaces;

public interface IOrdenesRepository: IGenericRepository<Ordene>
{
    //3. Obtener el Producto Más Caro
    Task<Ordene> ObtenerOrdenProductoMasCaro();
    Task<IEnumerable<Ordene>> GetOrdersAfterDateAsync(DateTime fecha);
    
    // Ejercicio 9:
    Task<Cliente?> GetClienteConMasPedidosAsync();

    // Ejercicio 10:
    Task<IEnumerable<Detallesorden>> GetTodosLosDetallesDeOrdenesAsync();

    // Ejercicio 11:
    Task<IEnumerable<Producto>> GetProductosPorClienteAsync(int clienteId);
    
    
    // 2
    Task<IEnumerable<Ordene>> GetOrdenesConDetallesAsync();

    // 4
    Task<IEnumerable<ClienteVentasDto>> GetVentasPorClienteAsync();
}