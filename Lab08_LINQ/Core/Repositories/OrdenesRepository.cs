using Lab08_LINQ.Core.Entities;
using Lab08_LINQ.Core.Repositories.Interfaces;
using Lab08_LINQ.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Lab08_LINQ.Core.Repositories;

public class OrdenesRepository: GenericRepository<Ordene>, IOrdenesRepository
{
    public OrdenesRepository(TiendadbDbContext context) : base(context)
    {
    }
    //3. Obtener el Producto Más Caro
    public async Task<Ordene> ObtenerOrdenProductoMasCaro()
    {
        var ordenConProductoMasCaro = await _dbContext.Ordenes
            .OrderByDescending(o => o.Total)
            .FirstOrDefaultAsync();
        return ordenConProductoMasCaro;
    }

    // Ejercicio 6
    public async Task<IEnumerable<Ordene>> GetOrdersAfterDateAsync(DateTime fecha)
    {
        return await _dbContext.Ordenes
            .Where(o => o.FechaOrden > fecha)
            .ToListAsync();
    }
    
    
    // Ejercicio 9:
    public async Task<Cliente?> GetClienteConMasPedidosAsync()
    {
        var clienteConMasPedidos = await _dbContext.Ordenes
            .GroupBy(o => o.ClienteId) 
            .Select(g => new { ClienteId = g.Key, CantidadPedidos = g.Count() }) 
            .OrderByDescending(x => x.CantidadPedidos) 
            .FirstOrDefaultAsync(); 

        if (clienteConMasPedidos == null) return null;

        return await _dbContext.Clientes.FindAsync(clienteConMasPedidos.ClienteId);
    }

    /// Ejercicio 10:
    public async Task<IEnumerable<Detallesorden>> GetTodosLosDetallesDeOrdenesAsync()
    {
        return await _dbContext.Detallesordens
            .Include(d => d.Producto) 
            .ToListAsync();
    }
    /// Ejercicio 11:
    public async Task<IEnumerable<Producto>> GetProductosPorClienteAsync(int clienteId)
    {
        return await _dbContext.Ordenes
            .Where(o => o.ClienteId == clienteId) 
            .SelectMany(o => o.Detallesordens)
            .Select(d => d.Producto) 
            .Distinct() 
            .ToListAsync();
    }
}