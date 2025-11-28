namespace Lab08_LINQ.Core.DTOs;

// DTO para representar el conteo total de productos comprados por un cliente.
public class ClienteProductoCountDto
{
    public string NombreCliente { get; set; }
    public int TotalProductos { get; set; }
}