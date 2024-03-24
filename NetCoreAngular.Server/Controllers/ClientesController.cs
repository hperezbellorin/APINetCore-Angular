using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreAngular.Server.Models;
using NetCoreAngular.Server.Models.ViewModels;
using NetCoreAngular.Server.Servicios;
using System.Text;

namespace NetCoreAngular.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClientesController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly ILogger<ClientesController> log;
        private IClientes clientesServicio;
        public ClientesController(ILogger<ClientesController> l, IClientes clientesServicio)
        {
            this.log = l;
            this.clientesServicio = clientesServicio;
        }

        [HttpGet]
        public IActionResult DameClientes()
        {
            Resultado res = new Resultado();
            try
            {
                var lista = clientesServicio.DameClientes();
                res.ObjetoGenerico = lista;
            }
            catch (Exception ex)
            {
                res.Error = "Se produjo un error al obtener los clientes " + ex.Message;
                res.Texto = "Se produjo un error al obtener los clientes";
                log.LogError("Se produjo un error al obtener los clientes" + ex.ToString());
            }

            return Ok(res);

        }

        [HttpPost]
        public IActionResult AgregarCliente(ClienteViewmodel c)
        {
            Resultado res = new Resultado();
            try
            {
                clientesServicio.AgregarCliente(c);
            }
            catch (Exception ex)
            {
                res.Error = "Se produjo un error al obtener al dar el alta: " + ex.ToString();
                res.Texto = "Se produjo un error al dar de alta. Intentalo de nuevo: ";
                log.LogError("Se produjo un error al obtener al dar el alta: " + ex.ToString());
            }

            return Ok(res);
        }

        [HttpPut]
        public IActionResult EditarCliente(ClienteViewmodel c)
        {
            Resultado res = new Resultado();
            try
            {
                clientesServicio.EditarCliente(c);
            }
            catch (Exception ex)
            {
                res.Error = "Se produjo un error al modificar un cliente " + ex.Message;
                res.Texto = "Se produjo un error al modificar un cliente ";
                log.LogError("Se produjo un error al modificar un cliente: " + ex.ToString());
            }

            return Ok(res);
        }

        [HttpDelete("{Email}")]
        public IActionResult BorrarCliente(String Email)
        {
            Resultado res = new Resultado();
            try
            {

                clientesServicio.BorrarCliente(Email);
            }
            catch (Exception ex)
            {
                res.Error = "Se produjo un error al borrar un cliente " + ex.Message;
                res.Texto = "Se produjo un error al borrar un cliente ";
                log.LogError("Se produjo un error al borrar un cliente " + ex.ToString());
            }

            return Ok(res);
        }
        [HttpPost("Login")]
        public IActionResult Login(ClienteViewmodel c)
        {
            Resultado res = new Resultado();
            try
            {
                byte[] keyBbyte = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
                Util util = new Util(keyBbyte);
                ClienteViewmodel cliente = clientesServicio.Login(c);
                res.ObjetoGenerico = cliente;

            }
            catch (Exception ex)
            {
                res.Error = "Se produjo un error al inicar sesión " + ex.ToString();
                res.Texto = "Usuario o password incorrecta";
                log.LogError("Se produjo un error al inicar sesión" + ex.ToString());
            }

            return Ok(res);
        }
        [HttpPost("Cliente")]
        public IActionResult DameCliente(ClienteViewmodel c)
        {
            Resultado res = new Resultado();
            try
            {
                ClienteViewmodel aux = new ClienteViewmodel();
                var cliente = clientesServicio.DameCliente(c);
                aux.email = cliente.Email;
                aux.nombre = cliente.Nombre;
                res.ObjetoGenerico = aux;
            }
            catch (Exception ex)
            {
                res.Error = "Se produjo un error al obtener los datos del cliente " + ex.Message;
                res.Texto = "Se produjo un error al obtener los datos del cliente";
                log.LogError("Se produjo un error al obtener los datos del cliente" + ex.ToString());
            }
            return Ok(res);
        }


    }
}

