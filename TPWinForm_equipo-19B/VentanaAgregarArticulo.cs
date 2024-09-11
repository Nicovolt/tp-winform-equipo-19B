using Dominio;
using Negocio;
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
    public partial class frmVentanaAgregarArticulo : Form
    {
        private Articulo articulo = null;
        public frmVentanaAgregarArticulo()
        {
            InitializeComponent();
        }

        public frmVentanaAgregarArticulo(Articulo item)
        {
            InitializeComponent();
            this.articulo = item;
            Text = "Modificar Articulo";
            btnAceptarArticulo.Text = "Actualizar";
        }

        private void btnCancelarArticulo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmVentanaAgregarArticulo_Load(object sender, EventArgs e)
        {
            cargaAgregar();
            addCategoria();
        }

        private void addCategoria() { 
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            cbxCategoria.DataSource = categoriaNegocio.Listar();
        }
 
        private void cargaAgregar()
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();


            //TO DO Categoria negocio, agregarlo a la funcion y descomentar la linea.

            try
            {
                modificacionComboBox(cbxMarca);
                modificacionComboBox(cbxCategoria);

                cbxMarca.DataSource = marcaNegocio.listar();
                cbxMarca.ValueMember = "IdMarca";
                cbxMarca.DisplayMember = "Descripcion";
                cbxMarca.SelectedItem = null;

                if (articulo != null)
                {
                    tbxCodigo.Text = articulo.Codigo;
                    tbxNombre.Text = articulo.Nombre;
                    tbxDescripcion.Text = articulo.Descripcion;
                   // cbxMarca.SelectedIndex = articulo.Marca;
                    //cbxCategoria.SelectedIndex = articulo.Categoria;
                    tbxUrlImagen.Text = articulo.ImagenUrl.Url;
                    cargarImagen(articulo.ImagenUrl.Url);
                    tbxPrecio.Text = articulo.Precio.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void modificacionComboBox(System.Windows.Forms.ComboBox item)
        {
            item.DataSource = null;
            item.Items.Clear();
            item.Text = string.Empty;
        }
        private void cargarImagen(string imagen)
        {
            try
            {
                pbxImagenArticulo.Load(imagen);
            }
            catch (Exception)
            {
                pbxImagenArticulo.Load("https://uning.es/wp-content/uploads/2016/08/ef3-placeholder-image.jpg");
            }
        }
    }
}
