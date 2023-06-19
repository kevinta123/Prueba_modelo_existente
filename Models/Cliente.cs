using System;
using System.Collections.Generic;

namespace Prueba_modelo_existente.Models;

public partial class Cliente
{
    public int ClienteId { get; set; }

    public string? ClienteNombre { get; set; }

    public string? ClienteDireccion { get; set; }

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();
}
