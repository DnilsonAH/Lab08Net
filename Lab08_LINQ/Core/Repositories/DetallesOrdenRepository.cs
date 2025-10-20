using Lab08_LINQ.Core.Entities;
using Lab08_LINQ.Core.Repositories.Interfaces;
using Lab08_LINQ.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Lab08_LINQ.Core.Repositories;

public class DetallesOrdenRepository: GenericRepository<Detallesorden>, IDetallesOrdenRepository
{
    //Constructor
    public DetallesOrdenRepository(TiendadbDbContext dbContext) : base(dbContext)
    {
    }
    
    public async Task<IEnumerable<object>> GetAllOrdersWithProductDetailsAsync(int ordenId)
    {
        return await _dbContext.Detallesordens
            .Include(d => d.Producto)
            .Where(d => d.OrdenId == ordenId)
            .Select(d => new
            {
                d.Producto.Nombre,
                d.Cantidad,
                PrecioUnitario = d.Precio,
                Total = d.Cantidad * d.Precio
            })
            .ToListAsync();
    }

    public async Task<int> GetTotalProductsInOrderAsync(int ordenId)
    {
        return await _dbContext.Detallesordens
            .Where(d => d.OrdenId == ordenId)
            .SumAsync(d => d.Cantidad);
    }
}