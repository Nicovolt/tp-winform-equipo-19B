using Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> listar()
        {
            List<Categoria> lista = new List<Categoria>();
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearConsulta("select Id,Descripcion FROM CATEGORIAS");
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Categoria categoria = new Categoria();
                    categoria.IdCategoria = (int)accesoDatos.Lector["Id"];
                    categoria.Descripcion = (string)accesoDatos.Lector["Descripcion"];

                    lista.Add(categoria);
                }

                return lista;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                accesoDatos.cerrarConexion();

            }
        }

        public int obtener(string id)
        {
            int marcaID;
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader = null;

            try
            {

                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("SELECT * FROM [dbo].[CATEGORIAS] WHERE Descripcion = @desc\"");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();



                if (reader.Read())
                {

                    marcaID = (int)reader["Id"];
                }
                else
                {
                    marcaID = 0;
                }

                return marcaID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }

                connection.Close();
            }
        }


    }
}
