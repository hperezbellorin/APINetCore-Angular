using NetCoreAngular.Server.Models.ViewModels;
using NetCoreAngular.Server.Models;

namespace NetCoreAngular.Server.Servicios
{
    public interface IProductos
    {
        public List<Producto> DameProductos();
        public void AgregarPedido(PedidoViewModel p);
        public List<PedidoDetalleViewModel> PedidosClientes(ClienteViewmodel c);
    }
}
