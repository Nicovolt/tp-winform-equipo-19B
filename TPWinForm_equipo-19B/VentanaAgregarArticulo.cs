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
            pbxImagenArticulo.BorderStyle = System.Windows.Forms.BorderStyle.None;
        }

        private void btnCancelarArticulo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmVentanaAgregarArticulo_Load(object sender, EventArgs e)
        {
            cargaAgregar();
        }

        private void cargaAgregar()
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

            //TO DO Categoria negocio, agregarlo a la funcion y descomentar la linea.

            try
            {
                modificacionComboBox(cbxMarca);
                modificacionComboBox(cbxCategoria);

                cbxMarca.DataSource = marcaNegocio.listar();
                cbxMarca.ValueMember = "IdMarca";
                cbxMarca.DisplayMember = "Descripcion";
                cbxMarca.SelectedItem = null;

                cbxCategoria.DataSource = categoriaNegocio.listar();
                cbxCategoria.ValueMember = "IdCategoria";
                cbxCategoria.DisplayMember = "Descripcion";
                cbxCategoria.SelectedItem = null;

                if (articulo != null)
                {
                    tbxCodigo.Text = articulo.Codigo;
                    tbxNombre.Text = articulo.Nombre;
                    tbxDescripcion.Text = articulo.Descripcion;
                    cbxMarca.SelectedValue = articulo.Marca.IdMarca;
                    cbxCategoria.SelectedValue = articulo.Categoria.IdCategoria;
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

        private void btnAceptarArticulo_Click(object sender, EventArgs e)
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            ImagenNegocio imagenNegocio = new ImagenNegocio();

            try
            {
                if (articulo == null) { articulo = new Articulo(); }

                if (!validarMaximoCincuentaCaracteres(tbxCodigo) || !validarMaximoCincuentaCaracteres(tbxNombre) || !validarMaximoCientoCincuentaCaracteres(tbxDescripcion) || !validarMaximoMilCaracteres(tbxUrlImagen) || !validarSoloNumeros(tbxPrecio)) return;
                if (!validarSeleccionComboBox(cbxMarca) || !validarSeleccionComboBox(cbxCategoria)) return;

                articulo.Codigo = tbxCodigo.Text;
                articulo.Nombre = tbxNombre.Text;
                articulo.Descripcion = tbxDescripcion.Text;
                articulo.Marca = (Marca)cbxMarca.SelectedItem;
                articulo.Categoria = (Categoria)cbxCategoria.SelectedItem;
                articulo.Precio = Convert.ToDecimal(tbxPrecio.Text);
                articulo.ImagenUrl.Url = tbxUrlImagen.Text;
                

                if (articulo.ID != 0)
                {
                    articuloNegocio.modificarArticulo(articulo);
                    articulo.ImagenUrl.IdArticulo = articulo.ID;
                    imagenNegocio.editar(articulo.ImagenUrl);
                    MessageBox.Show("Modificado exitosamente");
                }
                else
                {
                    articuloNegocio.agregarArticulo(articulo);
                    articulo.ImagenUrl.IdArticulo = articuloNegocio.obtenerUltimoId();
                    imagenNegocio.agregar(articulo.ImagenUrl);
                    MessageBox.Show("Agregado exitosamente");
                }

                Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private bool validarMaximoCincuentaCaracteres(TextBox item)
        {
            if (item.Text.Length > 50 || string.IsNullOrEmpty(item.Text))
            {
                MessageBox.Show("Uno de los campos tiene un limite de 50 caracteres o esta vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private bool validarMaximoCientoCincuentaCaracteres(TextBox item)
        {
            if (item.Text.Length > 150 || string.IsNullOrEmpty(item.Text))
            {
                MessageBox.Show("Uno de los campos tiene un limite de 150 caracteres o esta vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private bool validarMaximoMilCaracteres(TextBox item)
        {
            if (item.Text.Length > 1000 || string.IsNullOrEmpty(item.Text))
            {
                MessageBox.Show("El campo Imagen tiene un limite de 1000 caracteres o esta vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private bool validarSoloNumeros(TextBox item)
        {
            if (!decimal.TryParse(item.Text, out decimal resultado) || string.IsNullOrEmpty(item.Text))
            {
                MessageBox.Show("El campo Precio solo admite numeros o esta vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private bool validarSeleccionComboBox(ComboBox item)
        {
            if (item.SelectedIndex == -1)
            {
                MessageBox.Show("No complestaste uno de los desplegables", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnVerImagen_Click(object sender, EventArgs e)
        {
            cargarImagen(tbxUrlImagen.Text);
        }
    }
}
