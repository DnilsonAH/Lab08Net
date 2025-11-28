namespace Lab08_LINQ.Core.DTOs;

// DTO para representar los detalles de un producto dentro de una orden.
public class ProductoDetalleDto
{
    public string NombreProducto { get; set; }
    public int Cantidad { get; set; }
    public decimal Precio { get; set; }
}