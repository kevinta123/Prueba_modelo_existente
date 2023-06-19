using System;
using System.Collections.Generic;

namespace Prueba_modelo_existente.Models;

public partial class Categorium
{
    public int CategoriaId { get; set; }

    public string? CategoriaNombre { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
