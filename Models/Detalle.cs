using System;
using System.Collections.Generic;

namespace Prueba_modelo_existente.Models;

public partial class Detalle
{
    public int DetalleId { get; set; }

    public int? FacturaId { get; set; }

    public int? ProductoId { get; set; }

    public int? Cantidad { get; set; }

    public virtual Factura? Factura { get; set; }

    public virtual Producto? Producto { get; set; }
}
