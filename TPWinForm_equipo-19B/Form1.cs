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
        private List<Articulo> Lista = new List<Articulo>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();

            Lista = articuloNegocio.listar();

            dvgArticulo.DataSource = Lista;
      

        }

       

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmVentanaAgregarArticulo agregar = new frmVentanaAgregarArticulo();
            agregar.Show();
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
            ArticuloNegocio negArt = new ArticuloNegocio();
            Lista = negArt.listar();
            dvgArticulo.DataSource = Lista;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<Articulo> listaBusqueda;

            string busqueda = txtId.Text;

            if (busqueda != "")
            {
                listaBusqueda = Lista.FindAll(art => art.ID == int.Parse(busqueda));
            }
            else
            {
                listaBusqueda = Lista;
            }


            dvgArticulo.DataSource = null;
            dvgArticulo.DataSource = listaBusqueda;

        }
    }
}
