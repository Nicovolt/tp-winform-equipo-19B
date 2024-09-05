using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TPWinForm_equipo_19B
{
    internal class ArticuloNegocio
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
                cmd.CommandText = "select Codigo, Id, Nombre, Descripcion, IdMarca, IdCategoria, Precio FROM ARTICULOS\r\n";
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
                    aux.Marca = (int)lector["IdMarca"];
                    aux.Categoria = (int)lector["idCategoria"];
                    aux.Precio = (decimal)lector["Precio"];

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
    }
}
