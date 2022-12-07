using Microsoft.AspNetCore.Mvc;
using SistemaVentaCoder.ADO.NET;
using SistemaVentaCoder.Models;
using System.Data.SqlClient;

namespace SistemaVentaCoder.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class VentaController : ControllerBase
    {
        private VentaHandler handler = new VentaHandler();

        [HttpGet]
        public ActionResult<List<Venta>> Get()
        {
            try
            {
                List<Venta> lista = handler.GetVenta();
                return Ok(lista);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }
        private List<Venta> GetVenta()
        {
         throw new NotImplementedException();
        [HttpPost]
        public ActionResult Post([FromBody] Venta venta)
        {
         try
        }
    }
}
