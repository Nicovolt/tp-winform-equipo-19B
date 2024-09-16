using Dominio;
using Negocio;
using System;
using System.Collections;
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
    public partial class frmMarcaCategoria : Form
    {
        List<Marca> ListaMarca;
        List<Categoria> ListaCategorias;

        Marca marca = null;
        Categoria categoria = null;
        public frmMarcaCategoria()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            List<Marca> listaAux;

            try
            {
                if (marca == null) { marca = new Marca(); }

                //TODO VALIDACIONES DE QUE NO SE REPITA LA MARCA.
                if (string.IsNullOrEmpty(txtMarc.Text))
                {
                    MessageBox.Show("Para agregar complete el nombre de la marca");
                    return;
                }
                
                ListaMarca = marcaNegocio.listar();
                listaAux = ListaMarca.FindAll(x => x.Descripcion.ToUpper() == txtMarc.Text.ToUpper()).ToList();
                if (listaAux.Count > 0)
                {
                    MessageBox.Show("La marca que intentas agregar ya existe.");
                    return;
                }
                marca.Descripcion = txtMarc.Text;
                marcaNegocio.agregar(marca);
                MessageBox.Show("Agregado exitosamente");
            }
            catch (Exception ex)
            {

                throw ex;
            }

            cargar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            List<Categoria> listaAux;

            try
            {
                if (categoria == null) { categoria = new Categoria(); }

                if (string.IsNullOrEmpty(txtCat.Text))
                {
                    MessageBox.Show("Para agregar complete el nombre de la categoria");
                    return;
                }

                ListaCategorias = categoriaNegocio.listar();
                listaAux = ListaCategorias.FindAll(x => x.Descripcion.ToUpper() == txtCat.Text.ToUpper());
                if (listaAux.Count > 0)
                {
                    MessageBox.Show("La categoria que intentas agregar ya existe.");
                    return;
                }

                categoria.Descripcion = txtCat.Text;
                categoriaNegocio.agregarCategoria(categoria);
                MessageBox.Show("Agregado exitosamente");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            cargar();
        }


        private void frmMarcaCategoria_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void cargar()
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

            try
            {
                ListaMarca = marcaNegocio.listar();
                dgvMarcas.DataSource = ListaMarca;

                ListaCategorias = categoriaNegocio.listar();
                dgvCategorias.DataSource = ListaCategorias;

                txtCat.Text = "";
                txtMarc.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnModificarMarca_Click(object sender, EventArgs e)
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();


            try
            {
                if(dgvMarcas.SelectedRows.Count == 0)
                {
                    MessageBox.Show("No seleccionaste una marca del listado.");
                    return;
                }

                DataGridViewRow data = dgvMarcas.SelectedRows[0];

                int id = Convert.ToInt32(data.Cells[0].Value);
                string nueva_marca = txtMarc.Text;

                if (string.IsNullOrEmpty(nueva_marca))
                {
                    MessageBox.Show("No ingresaste una marca en el campo de texto.");
                    return;
                }

                Marca marca = new Marca();

                marca.IdMarca = id;
                marca.Descripcion = nueva_marca;

                marcaNegocio.modificar(marca);
                MessageBox.Show("Modificado exitosamente");

            }
            catch (Exception ex)
            {

                throw ex;
            }
            cargar();
        }

        private void btnEliminarMarca_Click(object sender, EventArgs e)
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();

            try
            {
                if (dgvMarcas.SelectedRows.Count == 0)
                {
                    MessageBox.Show("No seleccionaste una marca del listado.");
                    return;
                }

                DataGridViewRow data = dgvMarcas.SelectedRows[0];

                int id = Convert.ToInt32(data.Cells[0].Value);

                Marca marca = new Marca();

                marca.IdMarca = id;

                marcaNegocio.eliminar(marca);
                MessageBox.Show("Eliminado exitosamente");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            cargar();
        }

        private void btnModificarCategoria_Click(object sender, EventArgs e)
        {
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();


            try
            {
                if (dgvCategorias.SelectedRows.Count == 0)
                {
                    MessageBox.Show("No seleccionaste una categoria del listado.");
                    return;
                }

                DataGridViewRow data = dgvCategorias.SelectedRows[0];

                int id = Convert.ToInt32(data.Cells[0].Value);
                string nueva_categoria = txtCat.Text;

                if (string.IsNullOrEmpty(nueva_categoria))
                {
                    MessageBox.Show("No ingresaste una categoria en el campo de texto.");
                    return;
                }

                Categoria categoria = new Categoria();

                categoria.IdCategoria = id;
                categoria.Descripcion = nueva_categoria;

                categoriaNegocio.modificarCategoria(categoria);
                MessageBox.Show("Modificado exitosamente");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            cargar();
        }

        private void btnEliminarCategoria_Click(object sender, EventArgs e)
        {
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

            try
            {
                if (dgvCategorias.SelectedRows.Count == 0)
                {
                    MessageBox.Show("No seleccionaste una categoria del listado.");
                    return;
                }

                DataGridViewRow data = dgvCategorias.SelectedRows[0];

                int id = Convert.ToInt32(data.Cells[0].Value);

                Categoria categoria = new Categoria();

                categoria.IdCategoria = id;

                categoriaNegocio.eliminar(categoria);
                MessageBox.Show("Eliminado exitosamente");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            cargar();
        }
    }
}
