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
    public partial class Editar_marca_articulo : Form
    {
        public Editar_marca_articulo()
        {
            InitializeComponent();
        }

        private void btnModMarc_Click(object sender, EventArgs e)
        {
            Marca reg = new Marca();
            MarcaNegocio marcaN = new MarcaNegocio();
            ArticuloNegocio articuloN = new ArticuloNegocio();
            try
            {

                reg.Descripcion = txtNuevoNombreMarc.Text;
                reg.IdMarca = int.Parse(txtMarcEdit.Text);


                articuloN.modificarMarca(reg);
                MessageBox.Show("Editado correctamente");

                Close();



            }
            catch (Exception)
            {

                throw;
            }

        }

        private void btnModCat_Click(object sender, EventArgs e)
        {
            Categoria reg = new Categoria();
            CategoriaNegocio categoriaN = new CategoriaNegocio();
            ArticuloNegocio articuloN = new ArticuloNegocio();


            try
            {

                reg.Descripcion = txtNuevoNombreCat.Text;
                reg.IdCategoria = int.Parse(txtCatEdit.Text);


                articuloN.modificarCategoria(reg);
                MessageBox.Show("Editado correctamente");

                Close();



            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
