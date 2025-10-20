namespace Lab08_LINQ.Core.DTOs;

public class ProductoDto
{
    public string Nombre { get; set; } = null!;
    public string Descripcion { get; set; }
    public decimal Precio { get; set; }
    public int Stock { get; set; }
    public int CategoriaId { get; set; }
}