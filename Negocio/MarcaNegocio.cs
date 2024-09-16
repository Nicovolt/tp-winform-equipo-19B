using Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class MarcaNegocio
    {
        public List<Marca> listar()
        {
            List<Marca> lista = new List<Marca>();
            AccesoDatos data = new AccesoDatos();

            try
            {
                data.setearConsulta("select Id, Descripcion from MARCAS");
                data.ejecutarLectura();

                while (data.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.IdMarca = (int)data.Lector["Id"];
                    aux.Descripcion = (string)data.Lector["Descripcion"];

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
                data.cerrarConexion();
            }
        }
        public void agregar(Marca item)
        {
            AccesoDatos data = new AccesoDatos();
            try
            {
                data.setearConsulta("Insert into MARCAS(Descripcion) values (@Descripcion@);");
                data.setearParametro("@Descripcion@", item.Descripcion);
                data.ejecutarAccion();
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
            finally
            {
                data.cerrarConexion();
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
                datos.setearConsulta("SELECT * FROM [dbo].[MARCAS] WHERE Descripcion = @desc\"");
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

        public void modificar(Marca reg)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearConsulta("update MARCAS set Descripcion = @descripcion@ WHERE id = @id_marca@;");
                accesoDatos.setearParametro("@descripcion@", reg.Descripcion);
                accesoDatos.setearParametro("@id_marca@", reg.IdMarca);
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

        public void eliminar(Marca reg)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearConsulta("DELETE FROM MARCAS WHERE Id=@id_marca@;");
                accesoDatos.setearParametro("@id_marca@", reg.IdMarca);
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
