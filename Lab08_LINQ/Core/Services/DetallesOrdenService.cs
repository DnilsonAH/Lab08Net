using AutoMapper;
using Lab08_LINQ.Core.DTOs;
using Lab08_LINQ.Core.Entities;
using Lab08_LINQ.Core.Repositories.Interfaces;
using Lab08_LINQ.Core.Services.Interfaces;

namespace Lab08_LINQ.Core.Services;

public class DetallesOrdenService: GenericService<Detallesorden, DetallesOrdenDto>, IDetallesOrdenService
{
    protected readonly IDetallesOrdenRepository _detallesOrdenRepository;
    
    public DetallesOrdenService(IDetallesOrdenRepository repository, IMapper mapper): base(repository, mapper)
    {
        _detallesOrdenRepository = repository;
    }


    // Ejercicio 3: Obtener el Detalle de los Productos en una Orden
    public async Task<IEnumerable<object>> GetAllOrdersWithProductDetailsAsync(int ordenId)
    {
        return await _detallesOrdenRepository.GetAllOrdersWithProductDetailsAsync(ordenId);
    }

    // Ejercicio 4: Obtener la Cantidad Total de Productos por Orden
    public async Task<int> GetTotalProductsInOrderAsync(int ordenId)
    {
        return await _detallesOrdenRepository.GetTotalProductsInOrderAsync(ordenId);
    }
}