using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace TPWinForm_equipo_19B
{
    public partial class Form1 : Form
    {
        private List<Articulo> Lista;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargar();
        }

       

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmVentanaAgregarArticulo agregar = new frmVentanaAgregarArticulo();
            agregar.ShowDialog();
            cargar();
        }

        private void dvgArticulo_SelectionChanged(object sender, EventArgs e)
        {
            ArticuloNegocio articulo = new ArticuloNegocio();   
            Lista = articulo.listar();

            Articulo Seleccionado = (Articulo)dvgArticulo.CurrentRow.DataBoundItem;
            CargarImagen(Seleccionado.ImagenUrl.Url);

        }

        private void CargarImagen(string imagen)
        {
            try
            {
                pbImagen.Load(imagen);
            }
            catch (Exception)
            {

                pbImagen.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRLEoaTsWQuPn6bW-_n6hqZvmy5Lh64qwETLg&s");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Articulo seleccionado;
            

            try
            {
                DialogResult respuesta = MessageBox.Show("¿Estas seguro que queres eliminar?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    seleccionado = (Articulo)dvgArticulo.CurrentRow.DataBoundItem;
                    eliminarArticulos(seleccionado.ID);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void eliminarArticulos(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("delete from ARTICULOS where id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
                cargar();



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }
        private void cargar()
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            try
            {
                Lista = articuloNegocio.listar();
                dvgArticulo.DataSource = Lista;
                CargarImagen(Lista[0].ImagenUrl.Url.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<Articulo> listaBusqueda;

            string busqueda = txtId.Text;

            if (busqueda != "")
            {
                listaBusqueda = Lista.FindAll(art => art.ID.ToString().ToUpper().Contains(busqueda.ToUpper()) || art.Nombre.ToUpper().Contains(busqueda.ToUpper())
                || art.Descripcion.ToUpper().Contains(busqueda.ToUpper()) ||
                art.Codigo.ToString().ToUpper().Contains(busqueda.ToUpper()));
            }
            else
            {
                listaBusqueda = Lista;
            }


            dvgArticulo.DataSource = null;
            dvgArticulo.DataSource = listaBusqueda;

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dvgArticulo.CurrentRow == null)
            {
                MessageBox.Show("No seleccionaste un producto");
                return;
            }
            Articulo selected = (Articulo)dvgArticulo.CurrentRow.DataBoundItem;

            frmVentanaAgregarArticulo modificar = new frmVentanaAgregarArticulo(selected);
            modificar.ShowDialog();
            cargar();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
           
                List<Articulo> listaFiltrada;

                string filtroMarca = txtFiltroMarc.Text;
                string filtroCategoria = txtFiltroCat.Text;


                if (filtroMarca != "" && filtroCategoria != "" && txtPrecio.Text != "")
                {

                    listaFiltrada = Lista.FindAll(x => x.Marca.ToString() == filtroMarca && x.Categoria.ToString() == filtroCategoria && x.Precio <= decimal.Parse(txtPrecio.Text));
                }

                else if (filtroMarca != "" && filtroCategoria != "")
                {
                    listaFiltrada = Lista.FindAll(x => x.Marca.ToString() == filtroMarca && x.Categoria.ToString() == filtroCategoria);
                }
                else if (filtroMarca != "" && txtPrecio.Text != "")
                {
                    listaFiltrada = Lista.FindAll(x => x.Marca.ToString() == filtroMarca && x.Precio <= decimal.Parse(txtPrecio.Text));
                }
                else if (filtroCategoria != "" && txtPrecio.Text != "")
                {
                    listaFiltrada = Lista.FindAll(x => x.Categoria.ToString() == filtroCategoria && x.Precio <= decimal.Parse(txtPrecio.Text));
                }
                else if (filtroMarca != "")
                {
                    listaFiltrada = Lista.FindAll(x => x.Marca.ToString() == filtroMarca);
                }
                else if (filtroCategoria != "")
                {
                    listaFiltrada = Lista.FindAll(x => x.Categoria.ToString() == filtroCategoria);
                }
                else if (txtPrecio.Text != "")
                {
                    listaFiltrada = Lista.FindAll(x => x.Precio <= decimal.Parse(txtPrecio.Text));
                }

                else
                {
                    listaFiltrada = Lista;
                }


            dvgArticulo.DataSource = null;
            dvgArticulo.DataSource = listaFiltrada;
            dvgArticulo.Columns["Codigo"].Visible = false;
            
        }
    }
}
