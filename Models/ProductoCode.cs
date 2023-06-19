using System;
using System.Collections.Generic;

namespace Prueba_modelo_existente.Models;

public partial class ProductoCode
{
    public int ProductoId { get; set; }

    public string Codigo { get; set; } = null!;

    public virtual Producto Producto { get; set; } = null!;
}
