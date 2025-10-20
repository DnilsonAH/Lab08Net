using Lab08_LINQ.Core.DTOs;
using Lab08_LINQ.Core.Entities;

namespace Lab08_LINQ.Core.Services.Interfaces;

public interface IDetallesOrdenService : IGenericService<DetallesOrdenDto>
{
    // Ejercicio 3
    Task<IEnumerable<object>> GetAllOrdersWithProductDetailsAsync(int ordenId);
    
    // Ejercicio 4
    Task<int> GetTotalProductsInOrderAsync(int ordenId);
}
