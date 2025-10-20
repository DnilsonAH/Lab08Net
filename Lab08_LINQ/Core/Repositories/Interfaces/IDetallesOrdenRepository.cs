using Lab08_LINQ.Core.Entities;

namespace Lab08_LINQ.Core.Repositories.Interfaces;

public interface IDetallesOrdenRepository : IGenericRepository<Detallesorden>
{
    // Ejercicio 3
    Task<IEnumerable<object>> GetAllOrdersWithProductDetailsAsync(int ordenId);
    
    // Ejercicio 4
    Task<int> GetTotalProductsInOrderAsync(int ordenId);
}