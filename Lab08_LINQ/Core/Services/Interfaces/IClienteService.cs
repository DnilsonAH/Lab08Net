using Lab08_LINQ.Core.DTOs;

namespace Lab08_LINQ.Core.Services.Interfaces;

public interface IClienteService : IGenericService<ClienteDto>
{
    Task<IEnumerable<ClienteDto>> GetClientesConZAsync(string letra);
    Task<IEnumerable<ClienteDto>> GetClientesPorProductoAsync(int productoId);
    

    Task<IEnumerable<ClienteOrdenDto>> GetClientesConOrdenesAsync();
    Task<IEnumerable<ClienteProductoCountDto>> GetClientesConTotalProductosAsync();
}