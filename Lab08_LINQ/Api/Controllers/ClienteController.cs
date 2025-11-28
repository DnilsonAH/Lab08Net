using Lab08_LINQ.Core.DTOs;
using Lab08_LINQ.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lab08_LINQ.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClienteController : ControllerBase
{
    private readonly IClienteService _clienteService;
    public ClienteController(IClienteService clienteService)
    {
        _clienteService = clienteService;
    }
    
    //1. metodo GetClientesConZAsync
    [HttpGet("GetWithLetra/{letra}")]
    public async Task<ActionResult<IEnumerable<ClienteDto>>> GetClientesConZAsync(string letra)
    {
        var clientesDto = await _clienteService.GetClientesConZAsync(letra);
        return Ok(clientesDto);
    }
    
    //Ejercicio 12: Clientes que compraron un producto específico
    [HttpGet("por-producto/{productoId}")]
    public async Task<ActionResult<IEnumerable<ClienteDto>>> GetClientesPorProducto(int productoId)
    {
        var clientes = await _clienteService.GetClientesPorProductoAsync(productoId);
        if (!clientes.Any())
        {
            return NotFound($"No se encontraron clientes que hayan comprado el producto con ID {productoId}.");
        }
        return Ok(clientes);
    }
    
    // --- NUEVOS ENDPOINTS DEL LABORATORIO ---

    [HttpGet("con-ordenes")]
    public async Task<IActionResult> GetClientesConOrdenes()
    {
        var clientes = await _clienteService.GetClientesConOrdenesAsync();
        return Ok(clientes);
    }

    [HttpGet("con-total-productos")]
    public async Task<IActionResult> GetClientesConTotalProductos()
    {
        var clientes = await _clienteService.GetClientesConTotalProductosAsync();
        return Ok(clientes);
    }
}