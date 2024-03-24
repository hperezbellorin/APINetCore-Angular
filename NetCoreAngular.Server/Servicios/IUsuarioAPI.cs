using NetCoreAngular.Server.Models.ViewModels;

namespace NetCoreAngular.Server.Servicios
{
    public interface IUsuarioAPI
    {
        public UsuarioAPIViewModel Autenticacion(AuthAPI authAPI);

    }
}
