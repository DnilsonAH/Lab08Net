using Lab08_LINQ.Core.Entities;
using Lab08_LINQ.Core.Repositories.Interfaces;
using Lab08_LINQ.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Lab08_LINQ.Core.Repositories;

public class ClientesRepository: GenericRepository<Cliente>, IClientesRepository
{
    //Contructor
    public ClientesRepository(TiendadbDbContext dbContext) : base(dbContext)
    {
    }
    
    public async Task<IEnumerable<Cliente>> GetClientesConZAsync(string letra) 
    {
        if (string.IsNullOrEmpty(letra)) return Enumerable.Empty<Cliente>();
        string filtro = letra.ToLower(); 
        return await _dbContext.Clientes
            .Where(c => c.Nombre.ToLower().Contains(filtro))
            .ToListAsync();
    }
    
    // Ejercicio 12
    public async Task<IEnumerable<Cliente>> GetClientesPorProductoAsync(int productoId)
    {
        return await _dbContext.Detallesordens
            .Where(d => d.ProductoId == productoId) 
            .Select(d => d.Orden.Cliente)    
            .Distinct()   
            .ToListAsync();
    }
    
}