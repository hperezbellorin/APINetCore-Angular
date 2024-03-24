using NetCoreAngular.Server.Models.ViewModels;
using NetCoreAngular.Server.Models;

namespace NetCoreAngular.Server.Servicios
{
    public interface IClientes
    {
        public Cliente DameCliente(ClienteViewmodel c);
        public List<Cliente> DameClientes();
        public void AgregarCliente(ClienteViewmodel c);
        public void EditarCliente(ClienteViewmodel c);
        public void BorrarCliente(String Email);
        public ClienteViewmodel Login(ClienteViewmodel c);
    }
}
