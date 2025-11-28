namespace Lab08_LINQ.Core.DTOs;

// DTO para representar una orden con todos sus productos detallados.
public class OrdenConDetallesDto
{
    public int OrdenId { get; set; }
    public DateTime? FechaOrden { get; set; }
    public List<ProductoDetalleDto> Productos { get; set; }
}