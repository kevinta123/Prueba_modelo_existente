using System;
using System.Collections.Generic;

namespace Prueba_modelo_existente.Models;

public partial class Vendedor
{
    public int VendedorId { get; set; }

    public string? VendedorNombre { get; set; }

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();
}
