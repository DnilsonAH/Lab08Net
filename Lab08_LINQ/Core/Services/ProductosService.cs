using AutoMapper;
using Lab08_LINQ.Core.DTOs;
using Lab08_LINQ.Core.Entities;
using Lab08_LINQ.Core.Repositories.Interfaces;
using Lab08_LINQ.Core.Services.Interfaces;

namespace Lab08_LINQ.Core.Services;

public class ProductosService : GenericService<Producto, ProductoDto>, IProductosService
{
    private readonly IProductosRepository _productosRepository;

    public ProductosService(IProductosRepository repository, IMapper mapper)
        : base(repository, mapper)
    {
        _productosRepository = repository;
    }

    public async Task<IEnumerable<ProductoDto>> GetProductosPrecioMayorQue(decimal precio)
    {
        
        var productos = await _productosRepository.GetProductosPrecioMayorQue(precio);
        return _mapper.Map<IEnumerable<ProductoDto>>(productos);
    }

    // Ejercicio 5
    public async Task<ProductoDto> GetMostExpensiveProductAsync()
    {
        var producto = await _productosRepository.GetMostExpensiveProductAsync();
        return _mapper.Map<ProductoDto>(producto);
    }

    // Ejercicio 7
    public async Task<decimal> GetAverageProductPriceAsync()
    {
        var precioPromedio = await _productosRepository.GetAverageProductPriceAsync();
        return precioPromedio;
    }
    
    // Ejercicio 8
    public async Task<IEnumerable<ProductoDto>> GetProductWithDescriptionNullAsync()
    {
        var product = await _productosRepository.GetProductWithDescriptionNullAsync();
        return _mapper.Map<IEnumerable<ProductoDto>>(product);
    }
}