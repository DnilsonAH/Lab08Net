using Lab08_LINQ.Core.DTOs;
using Lab08_LINQ.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lab08_LINQ.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdenesController : ControllerBase
{
    private readonly IOrdenesService _ordenesService;

    public OrdenesController(IOrdenesService ordenesService)
    {
        _ordenesService = ordenesService;
    }

    // Ejercicio 6
    [HttpGet("despues-de/{fecha}")]
    public async Task<IActionResult> GetOrdersAfterDate(DateTime fecha)
    {
        try
        {
            var ordenes = await _ordenesService.GetOrdersAfterDateAsync(fecha);
            if (!ordenes.Any())
            {
                return NotFound($"No se encontraron órdenes después de {fecha:yyyy-MM-dd}");
            }
            return Ok(ordenes);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error interno del servidor: {ex.Message}");
        }
    }

    /// Ejercicio 9:
    [HttpGet("cliente-con-mas-pedidos")]
    public async Task<ActionResult<ClienteDto>> GetClienteConMasPedidos()
    {
        var cliente = await _ordenesService.GetClienteConMasPedidosAsync();
        if (cliente == null)
        {
            return NotFound("No se encontraron clientes con pedidos.");
        }
        return Ok(cliente);
    }

    /// Ejercicio 10:
    [HttpGet("detalles-completos")]
    public async Task<ActionResult<IEnumerable<OrdenDetalleDto>>> GetTodosLosDetalles()
    {
        var detalles = await _ordenesService.GetTodosLosDetallesDeOrdenesAsync();
        return Ok(detalles);
    }

    /// Ejercicio 11:
    [HttpGet("cliente/{clienteId}/productos")]
    public async Task<ActionResult<IEnumerable<ProductoDto>>> GetProductosPorCliente(int clienteId)
    {
        var productos = await _ordenesService.GetProductosPorClienteAsync(clienteId);
        if (!productos.Any())
        {
            return NotFound($"No se encontraron productos para el cliente con ID {clienteId}.");
        }
        return Ok(productos);
    }
}
