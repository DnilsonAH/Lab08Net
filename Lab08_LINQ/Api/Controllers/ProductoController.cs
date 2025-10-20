using Lab08_LINQ.Core.DTOs;
using Lab08_LINQ.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lab08_LINQ.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductoController : ControllerBase
{
    private readonly IProductosService _productosService;

    public ProductoController(IProductosService productosService)
    {
        _productosService = productosService;
    }

    // Ejercicio 2
    [HttpGet("precio-mayor-que/{precio}")]
    public async Task<IActionResult> GetProductosPrecioMayorQue(decimal precio)
    {
        var productos = await _productosService.GetProductosPrecioMayorQue(precio);
        return Ok(productos);
    }

    // Ejercicio 5
    [HttpGet("mas-caro")]
    public async Task<IActionResult> GetMostExpensiveProduct()
    {
        try
        {
            var producto = await _productosService.GetMostExpensiveProductAsync();
            if (producto == null)
            {
                return NotFound("No se encontraron productos");
            }
            return Ok(producto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error interno del servidor: {ex.Message}");
        }
    }

    // Ejercicio 7
    [HttpGet("precio-promedio")]
    public async Task<IActionResult> GetAveragePrice()
    {
        try
        {
            var promedio = await _productosService.GetAverageProductPriceAsync();
            return Ok(new { PrecioPromedio = promedio });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error interno del servidor: {ex.Message}");
        }
    }
    
    // Ejercicio 8
    [HttpGet("descripcion-nula")]
    public async Task<IActionResult> GetProductsWithNullDescription()
    {
        var productos = await _productosService.GetProductWithDescriptionNullAsync();
        return Ok(productos);
    }
}