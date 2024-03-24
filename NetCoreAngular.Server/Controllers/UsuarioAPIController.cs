using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreAngular.Server.Models.ViewModels;
using NetCoreAngular.Server.Models;
using System.Text;
using NetCoreAngular.Server.Servicios;
using Microsoft.AspNetCore.Authorization;

namespace NetCoreAngular.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class UsuarioAPIController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private IUsuarioAPI usuarioAPIServicio;
       
        private readonly ILogger<UsuarioAPIController> log;
        public UsuarioAPIController(IConfiguration configuration, IUsuarioAPI usuarioAPIServicio, ILogger<UsuarioAPIController> log)
        {
            this.configuration = configuration;
            this.usuarioAPIServicio = usuarioAPIServicio;
            this.log = log;

        }
        [HttpPost]
        public IActionResult DameUsuarioAPI(AuthAPI auth)
        {
            Resultado res = new Resultado();
            try
            {
                res.ObjetoGenerico = usuarioAPIServicio.Autenticacion(auth);
            }
            catch (Exception ex)
            {
                res.Error = "Se produjo un error al obtener el usuario de api: " + ex.Message;
                log.LogError("Error al obtener nuestro usuario de API:" + ex.ToString());
            }

            return Ok(res);
        }




        // UTILIZADO DE FORMA TEMPORAL PARA EL ALTA
        [HttpPost("Alta")]
        public IActionResult AltaUsuario(AuthAPI usuarioAPI)
        {
            Resultado res = new Resultado();
            try
            {
                byte[] keyBbyte = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
                Util util = new Util(keyBbyte);



                using (CursoAngularNetCoreContext basedatos = new CursoAngularNetCoreContext())
                {
                    UsuariosApi api = new UsuariosApi();
                    api.Email = usuarioAPI.email;
                    api.Password = Encoding.ASCII.GetBytes(util.cifrar(usuarioAPI.password, configuration["ClaveCifrado"]));

                    api.FechaAlta = DateTime.Now;
                    api.FechaBaja = DateTime.Now;
                    basedatos.UsuariosApis.Add(api);
                    basedatos.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                res.Error = "Se produjo un error al obtener al dar el alta " + ex.ToString();
                res.Texto = "Se produjo un error al dar de alta. Intentalo de nuevo.";
            }

            return Ok(res);
        }

        //[HttpGet("{Email}/{Pass}")]
        //public IActionResult DameUsuarioAPI(string Email, string Pass)
        //{
        //    AuthAPI auth = new AuthAPI();
        //    Resultado res = new Resultado();
        //    try
        //    {
        //        byte[] keyBbyte = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
        //        Util util = new Util(keyBbyte);



        //        using (CursoAngularNetCoreContext basedatos = new CursoAngularNetCoreContext())
        //        {
        //            UsuariosApi cliente = basedatos.UsuariosApis.Single(usuario =>usuario.Email == Email);
        //            auth.password = util.desCifrar(Encoding.ASCII.GetString(cliente.Password), configuration["ClaveCifrado"]);
        //           auth.email = cliente.Email;
        //            if(Pass == auth.password)
        //            {
        //                res.ObjetoGenerico = auth;
        //            }
        //            else
        //            {
        //                throw new Exception("Usuario desconocido");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        res.Error = "Se produjo un error al obtener usuario api " + ex.Message;
        //    }

        //    return Ok(res);

        //}

    }
    
    


}
