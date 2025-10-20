using Lab08_LINQ.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lab08_LINQ.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DetallesOrdenController : ControllerBase
{
    private readonly IDetallesOrdenService _detallesOrdenService;

    public DetallesOrdenController(IDetallesOrdenService detallesOrdenService)
    {
        _detallesOrdenService = detallesOrdenService;
    }

    // Ejercicio 3
    [HttpGet("orden/{ordenId}")]
    public async Task<IActionResult> GetProductosEnOrden(int ordenId)
    {
        try
        {
            var detalles = await _detallesOrdenService.GetAllOrdersWithProductDetailsAsync(ordenId);
            if (!detalles.Any())
            {
                return NotFound($"No se encontraron productos para la orden {ordenId}");
            }
            return Ok(detalles);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error interno del servidor: {ex.Message}");
        }
    }

    // Ejercicio 4
    [HttpGet("orden/{ordenId}/total-productos")]
    public async Task<IActionResult> GetTotalProductsInOrder(int ordenId)
    {
        try
        {
            var total = await _detallesOrdenService.GetTotalProductsInOrderAsync(ordenId);
            return Ok(new { OrdenId = ordenId, CantidadTotal = total });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error interno del servidor: {ex.Message}");
        }
    }
}
