using System;
using System.Collections.Generic;

namespace NetCoreAngular.Server.Models;

public partial class Producto
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public decimal? Precio { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Lineaspedido> Lineaspedidos { get; set; } = new List<Lineaspedido>();
}
