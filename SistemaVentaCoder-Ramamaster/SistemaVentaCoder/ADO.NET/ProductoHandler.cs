using SistemaVentaCoder.Models;
using System.Data;
using System.Data.SqlClient;

namespace SistemaVentaCoder.ADO.NET
{
    public class ProductoHandler
    {
        private SqlConnection conexion;
        private string CadenaConexion = "Server=sql.bsite.net\\MSSQL2016;" +
            "Database=LeandroEmanuel_SistemaVentaCoder;" +
            "User Id=LeandroEmanuel_SistemaVentaCoder;" +
            "Password=puyuta67;";

        public ProdHandler() 
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

        public List<Producto> GetProductos() 
        {
            List<Producto> listaProductos = new List<Producto>();
            if (CadenaConexion == null)
            {
                throw new Exception("Conexion no realisada");
            }
            try
            {
                using (SqlCommand command = new SqlCommand ("select * from Producto", conexion))
                {
                    conexion.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Producto producto = new Producto();
                                producto.Id = Convert.ToInt32(reader["Id"].ToString());
                                producto.Descripciones = reader["Descripciones"].ToString();
                                producto.Costo = Convert.ToDecimal(reader["Costo"].ToString());
                                producto.PrecioVenta = Convert.ToDecimal(reader["PrecioVenta"].ToString());
                                producto.Stock = Convert.ToInt32(reader["Stock"].ToString());
                                producto.IdUsuario = Convert.ToInt32(reader["IdUsuario"].ToString());
                                listaProductos.Add(producto);
                            }
                        }
                    }
                }
                conexion.Close();
            }
            catch (Exception)
            {

                throw;
            }
            return listaProductos;
        }
    }
}
