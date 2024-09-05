using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private void button3_Click(object sender, EventArgs e)
        {

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
    }
}
