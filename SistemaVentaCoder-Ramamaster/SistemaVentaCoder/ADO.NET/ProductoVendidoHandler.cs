using SistemaVentaCoder.Models;
using System.Data;
using System.Data.SqlClient;

namespace SistemaVentaCoder.ADO.NET
{
    public class ProdVendidoHandler
    {
        private SqlConnection conexion;
        private string CadenaConexion = "Server=sql.bsite.net\\MSSQL2016;" +
            "Database=LeandroEmanuel_SistemaVentaCoder;" +
            "User Id=LeandroEmanuel_SistemaVentaCoder;" +
            "Password=puyuta67;";

        public ProdVendidoHandler() 
        {
            try
            {
                conexion = new SqlConnection(CadenaConexion);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ProductoVendido> GetProductosVendidos() 
        {
            List<ProductoVendido> listaProductosVendidos = new List<ProductoVendido>();
            if (CadenaConexion == null)
            {
                throw new Exception("Conexión no realizada");
            }
            try
            {
                using (SqlCommand command = new SqlCommand ("select * from ProductoVendido", conexion))
                {conexion.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {  if (reader.HasRows)
                        {  while (reader.Read())
                            {
                                ProductoVendido productoVendido = new ProductoVendido();
                                productoVendido.Id = Convert.ToInt32(reader["Id"].ToString());
                                productoVendido.Stock = Convert.ToInt32(reader["Stock"].ToString());
                                productoVendido.IdProducto = Convert.ToInt32(reader["IdProducto"].ToString());
                                productoVendido.IdVenta = Convert.ToInt32(reader["IdVenta"].ToString());
                                listaProductosVendidos.Add(productoVendido);
                            }
                        }
                    }
                }
                conexion.Close();
            }
            catch (Exception)
            {throw;}
            return listaProductosVendidos;
        }
    }
}
