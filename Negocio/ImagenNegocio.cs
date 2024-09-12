using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ImagenNegocio
    {
        public List<Imagen> listar()
        {
            List<Imagen> lista = new List<Imagen>();
            AccesoDatos data = new AccesoDatos();

            try
            {
                data.setearConsulta("SELECT i.IdArticulo, i.ImagenUrl FROM IMAGENES i;");
                data.ejecutarLectura();

                while (data.Lector.Read())
                {
                    Imagen aux = new Imagen();
                    aux.IdArticulo = (int)data.Lector["i.IdArticulo"];
                    aux.Url = (string)data.Lector["i.ImagenUrl"];

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
        public void agregar(Imagen item)
        {
            AccesoDatos data = new AccesoDatos();
            try
            {
                data.setearConsulta("INSERT INTO IMAGENES (IdArticulo,ImagenUrl) VALUES (@IdArticulo@,@Url@)");
                data.setearParametro("@IdArticulo@", item.IdArticulo);
                data.setearParametro("@Url@", item.Url);
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
        public void editar(Imagen item)
        {
            AccesoDatos data = new AccesoDatos();
            try
            {
                data.setearConsulta("UPDATE IMAGENES SET ImagenUrl = @Url@ WHERE IdArticulo = @Id@");
                data.setearParametro("@Url@",item.Url);
                data.setearParametro("@Id@", item.IdArticulo);
                data.ejecutarAccion();
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
    }
}
