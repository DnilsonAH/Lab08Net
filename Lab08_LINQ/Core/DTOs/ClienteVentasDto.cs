namespace Lab08_LINQ.Core.DTOs;

// DTO para representar las ventas totales generadas por un cliente.
public class ClienteVentasDto
{
    public string NombreCliente { get; set; }
    public decimal VentasTotales { get; set; }
}