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
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT A.Id, Codigo, A.Nombre ,A.Descripcion AS ArticuloDescripcion, A.IdMarca ,M.Descripcion AS MarcaDescripcion, A.IdCategoria, C.Descripcion AS CategoriaDescripcion, Precio, I.ImagenUrl FROM ARTICULOS A, IMAGENES I, CATEGORIAS C, MARCAS M WHERE A.Id = I.IdArticulo AND A.IdMarca = M.Id AND A.IdCategoria = C.Id;");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.ID = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["ArticuloDescripcion"];
                    aux.Precio = (decimal)datos.Lector["Precio"];

                    aux.Categoria = new Categoria();
                    aux.Categoria.IdCategoria = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["CategoriaDescripcion"];

                    aux.Marca = new Marca();
                    aux.Marca.IdMarca = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["MarcaDescripcion"];

                    aux.ImagenUrl = new Imagen();
                    aux.ImagenUrl.Url = (string)datos.Lector["ImagenUrl"];
                    aux.ImagenUrl.IdArticulo = (int)datos.Lector["Id"];

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
                datos.cerrarConexion();
            }

        }

        public void modificarArticulo(Articulo item)
        {
            AccesoDatos data = new AccesoDatos();

            try
            {
                data.setearConsulta("UPDATE articulos SET codigo = @Codigo@, nombre = @Nombre@, descripcion = @Descripcion@, idMarca = @Marca@, idCategoria = @Categoria@, precio = @Precio@ WHERE Id = @ID@;");
                data.setearParametro("@ID@", item.ID);
                data.setearParametro("@codigo@", item.Codigo);
                data.setearParametro("@nombre@", item.Nombre);
                data.setearParametro("@descripcion@", item.Descripcion);
                data.setearParametro("@marca@", item.Marca.IdMarca);
                data.setearParametro("@categoria@", item.Categoria.IdCategoria);
                data.setearParametro("@precio@", item.Precio);

                data.ejecutarAccion();
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                data.cerrarConexion();
            }
        }

        public void agregarArticulo(Articulo item)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) VALUES (@codigo@, @nombre@, @descripcion@, @idmarca@, @idcategoria@, @precio@);");

                datos.setearParametro("@codigo@",item.Codigo);
                datos.setearParametro("@nombre@",item.Nombre);
                datos.setearParametro("@descripcion@",item.Descripcion);
                datos.setearParametro("@idmarca@",item.Marca.IdMarca);
                datos.setearParametro("@idcategoria@",item.Categoria.IdCategoria);
                datos.setearParametro("@precio@",item.Precio);

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
        public int obtenerUltimoId()
        {
            AccesoDatos datos = new AccesoDatos();
            int id;
            try
            {
                datos.setearConsulta("SELECT TOP(1) Id FROM ARTICULOS ORDER BY Id DESC");
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    id = (int)datos.Lector["Id"];
                }
                else
                {
                    id = 0;
                }

                return id;
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
    }
}
