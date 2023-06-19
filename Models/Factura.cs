using System;
using System.Collections.Generic;

namespace Prueba_modelo_existente.Models;

public partial class Factura
{
    public int FacturaId { get; set; }

    public DateTime? Fecha { get; set; }

    public int? ClienteId { get; set; }

    public int? VendedorId { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual ICollection<Detalle> Detalles { get; set; } = new List<Detalle>();

    public virtual Vendedor? Vendedor { get; set; }
}
