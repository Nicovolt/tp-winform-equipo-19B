using Dominio;
using System;
using System.Collections.Generic;
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
    }
}
