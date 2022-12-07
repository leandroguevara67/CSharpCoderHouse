using Microsoft.AspNetCore.Mvc;
using SistemaVentaCoder.ADO.NET;
using SistemaVentaCoder.Models;
using System.Data.SqlClient;

namespace SistemaVentaCoder.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("Api/[controller]")]
    public class ProductoController : ControllerBase
    {
        /// <summary>
        /// The handler
        /// </summary>
        private ProductoHandler handler = new ProductoHandler();

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
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
        [HttpPost]
        public void Create([FromBody] Producto producto)
        {
            SqlCommand("Insert INTO Producto Values=@producto")
        }
    }
}
