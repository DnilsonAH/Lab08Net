using Lab08_LINQ.Core.Entities;

namespace Lab08_LINQ.Core.Repositories.Interfaces;

public interface IClientesRepository: IGenericRepository<Cliente>
{
    // Ejejcicio 1
    Task<IEnumerable<Cliente>> GetClientesConZAsync(string letra);
    
    // Ejercicio 12: Clientes que compraron un producto específico
    Task<IEnumerable<Cliente>> GetClientesPorProductoAsync(int productoId);
}