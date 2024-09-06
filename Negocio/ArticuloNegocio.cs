 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;
namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            SqlConnection sqlConnection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader lector;



            try
            {
                sqlConnection.ConnectionString = "server= .\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "SELECT A.Id, Codigo, Nombre, A.Descripcion, M.Descripcion, C.Descripcion, Precio, I.ImagenUrl FROM ARTICULOS A, IMAGENES I, CATEGORIAS C, MARCAS M where A.Id = I.IdArticulo AND A.IdMarca = M.Id AND A.IdCategoria = C.Id\r\n";
                cmd.Connection = sqlConnection;

                sqlConnection.Open();

                lector = cmd.ExecuteReader();

                while (lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Codigo = (string)lector["Codigo"];
                    aux.ID = (int)lector["Id"];
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = (string)lector["Descripcion"];
                    aux.Precio = (decimal)lector["Precio"];

                    aux.ImagenUrl = new Imagen();
                    aux.ImagenUrl.Url = (string)lector["ImagenUrl"];

                    lista.Add(aux);


                }


                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }

        }

        public void eliminar() 
        {
            try
            {
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
