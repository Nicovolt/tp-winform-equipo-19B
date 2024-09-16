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

        public void agregarCategoria(Categoria nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into CATEGORIAS (Descripcion) values (@Descripcion@);");
                datos.setearParametro("@Descripcion@", nuevo.Descripcion);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            { 
                datos.cerrarConexion(); 
            }
        }

        public void modificarCategoria(Categoria reg)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearConsulta("update CATEGORIAS set Descripcion = @descripcion@ WHERE id = @id_categoria@;");
                accesoDatos.setearParametro("@descripcion@", reg.Descripcion);
                accesoDatos.setearParametro("@id_categoria@", reg.IdCategoria);
                accesoDatos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }

        public void eliminar(Categoria reg)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearConsulta("DELETE FROM CATEGORIAS WHERE Id=@id_categoria@;");
                accesoDatos.setearParametro("@id_categoria@", reg.IdCategoria);
                accesoDatos.ejecutarAccion();
            }
            catch (Exception)
            {


            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }

    }
}
