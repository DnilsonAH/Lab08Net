namespace Lab08_LINQ.Core.DTOs;

// DTO para representar el nombre de un cliente y su lista de órdenes.
public class ClienteOrdenDto
{
    public string NombreCliente { get; set; }
    public List<OrdenSimpleDto> Ordenes { get; set; }
}