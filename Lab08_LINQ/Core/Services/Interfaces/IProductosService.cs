using Lab08_LINQ.Core.DTOs;
using Lab08_LINQ.Core.Entities;

namespace Lab08_LINQ.Core.Services.Interfaces;

public interface IProductosService : IGenericService<ProductoDto>
{
    Task<IEnumerable<ProductoDto>> GetProductosPrecioMayorQue(decimal precio);
    
    // Ejercicio 5
    Task<ProductoDto> GetMostExpensiveProductAsync();
    
    // Ejercicio 7
    Task<decimal> GetAverageProductPriceAsync();
    
    // Ejercicio 8
    Task<IEnumerable<ProductoDto>> GetProductWithDescriptionNullAsync();
}