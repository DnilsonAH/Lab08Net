using System;
using System.Collections.Generic;

namespace Lab08_LINQ.Core.Entities;

public partial class Ordene
{
    public int OrdenId { get; set; }

    public int ClienteId { get; set; }

    public DateTime? FechaOrden { get; set; }

    public decimal Total { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual ICollection<Detallesorden> Detallesordens { get; set; } = new List<Detallesorden>();

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}
