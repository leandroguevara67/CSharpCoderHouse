using Microsoft.AspNetCore.Mvc;
using SistemaVentaCoder.ADO.NET;
using SistemaVentaCoder.Models;
using System.Data.SqlClient;

namespace SistemaVentaCoder.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private UsuarioHandler handler = new UsuarioHandler();

        [HttpGet]
        public ActionResult<List<Usuario>> Get()
        {
            try
            {
                List<Usuario> lista = handler.GetUsuario();
                return Ok(lista);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }
    }
}