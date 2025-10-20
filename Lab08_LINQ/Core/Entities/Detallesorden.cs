using System;
using System.Collections.Generic;

namespace Lab08_LINQ.Core.Entities;

public partial class Detallesorden
{
    public int DetalleId { get; set; }

    public int OrdenId { get; set; }

    public int ProductoId { get; set; }

    public int Cantidad { get; set; }

    public decimal Precio { get; set; }

    public virtual Ordene Orden { get; set; } = null!;

    public virtual Producto Producto { get; set; } = null!;
}
