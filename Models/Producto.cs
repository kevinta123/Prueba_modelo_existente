using System;
using System.Collections.Generic;

namespace Prueba_modelo_existente.Models;

public partial class Producto
{
    public int ProductoId { get; set; }

    public string? ProductoNombre { get; set; }

    public int? CategoriaId { get; set; }

    public virtual Categorium? Categoria { get; set; }

    public virtual ICollection<Detalle> Detalles { get; set; } = new List<Detalle>();

    public virtual ICollection<ProductoCode> ProductoCodes { get; set; } = new List<ProductoCode>();
}
