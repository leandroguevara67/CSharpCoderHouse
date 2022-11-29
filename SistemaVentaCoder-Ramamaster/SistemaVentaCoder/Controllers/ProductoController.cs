using Microsoft.AspNetCore.Mvc;
using SistemaVentaCoder.ADO.NET;
using SistemaVentaCoder.Models;
using System.Data.SqlClient;

namespace SistemaVentaCoder.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private ProductoHandler handler = new ProductoHandler();

        [HttpGet]
        public ActionResult<List<Producto>> Get()
        {
            try
            {
                List<Producto> lista = handler.GetProductos();
                return Ok(lista);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }
    }
}