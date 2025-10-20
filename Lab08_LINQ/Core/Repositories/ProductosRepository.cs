using Lab08_LINQ.Core.Entities;
using Lab08_LINQ.Core.Repositories.Interfaces;
using Lab08_LINQ.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Lab08_LINQ.Core.Repositories;

public class ProductosRepository : GenericRepository<Producto>, IProductosRepository
{
    public ProductosRepository(TiendadbDbContext context) : base(context)
    {
    }
    
    //2. metodo GetProductosPrecioMayorQue
    public async Task<IEnumerable<Producto>> GetProductosPrecioMayorQue(decimal precio)
    {
        return await _dbContext.Productos
            .Where(p => p.Precio > precio)
            .ToListAsync();
    }

    // Ejercicio 5
    public async Task<Producto> GetMostExpensiveProductAsync()
    {
        return await _dbContext.Productos
            .OrderByDescending(p => p.Precio)
            .FirstOrDefaultAsync();
    }

    // Ejercicio 7
    public async Task<decimal> GetAverageProductPriceAsync()
    {
        return await _dbContext.Productos
            .AverageAsync(p => p.Precio);
    }
    
    public async Task<IEnumerable<Producto>> GetProductWithDescriptionNullAsync()
    {
        return await _dbContext.Productos
            .Where(p => p.Descripcion == null)
            .ToListAsync();
    }
}