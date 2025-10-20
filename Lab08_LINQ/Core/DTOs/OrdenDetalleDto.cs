namespace Lab08_LINQ.Core.DTOs;

public class OrdenDetalleDto
{
    public int OrdenId { get; set; }
    public string NombreProducto { get; set; } = null!;
    public int Cantidad { get; set; }
}