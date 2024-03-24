using System;
using System.Collections.Generic;

namespace NetCoreAngular.Server.Models;

public partial class Pedido
{
    public int Id { get; set; }

    public int IdCliente { get; set; }

    public decimal Total { get; set; }

    public DateTime FechaPedido { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual ICollection<Lineaspedido> Lineaspedidos { get; set; } = new List<Lineaspedido>();
}
