using Lab08_LINQ.Core.Entities;

namespace Lab08_LINQ.Core.Repositories.Interfaces;

public interface IProductosRepository: IGenericRepository<Producto>
{
    //2. metodo GetProductosPrecioMayorQue
    Task<IEnumerable<Producto>> GetProductosPrecioMayorQue(decimal precio);
    Task<Producto> GetMostExpensiveProductAsync();
    Task<decimal> GetAverageProductPriceAsync();
    
    Task<IEnumerable<Producto>> GetProductWithDescriptionNullAsync();
}