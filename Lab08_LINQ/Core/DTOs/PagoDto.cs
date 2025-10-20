namespace Lab08_LINQ.Core.DTOs;

public class PagoDto
{
    public int OrdenId { get; set; }
    public decimal Monto { get; set; }
    public string MetodoPagoId { get; set; } = null!;
}