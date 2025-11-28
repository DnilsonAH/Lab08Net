using Lab08_LINQ.Core.DTOs;
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

    /// 2
    public async Task<IEnumerable<Ordene>> GetOrdenesConDetallesAsync()
    {
        return await _dbContext.Ordenes
            .Include(orden => orden.Detallesordens)
                .ThenInclude(detalle => detalle.Producto)
            .AsNoTracking()
            .ToListAsync();
    }

    /// 4
    public async Task<IEnumerable<ClienteVentasDto>> GetVentasPorClienteAsync()
    {
        return await _dbContext.Ordenes
            .AsNoTracking()
            .GroupBy(orden => orden.ClienteId) 
            .Select(grupo => new ClienteVentasDto
            {
                NombreCliente = _dbContext.Clientes.FirstOrDefault(c => c.ClienteId == grupo.Key).Nombre,
                VentasTotales = grupo.SelectMany(orden => orden.Detallesordens)
                                     .Sum(detalle => detalle.Cantidad * detalle.Precio)
            })
            .OrderByDescending(ventas => ventas.VentasTotales) 
            .ToListAsync();
    }
}
