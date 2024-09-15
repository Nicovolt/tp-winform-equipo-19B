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
    public partial class Marca_Categoria : Form
    {
        public Marca_Categoria()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MarcaNegocio marcaN = new MarcaNegocio();

            CategoriaNegocio categoriaN = new CategoriaNegocio();
            ArticuloNegocio articuloN = new ArticuloNegocio();
            Marca aux = new Marca();



            aux.Descripcion = txtMarc.Text;
            aux.IdMarca = marcaN.obtener(aux.Descripcion);



            articuloN.agregarMarca(aux);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MarcaNegocio marcaN = new MarcaNegocio();

            CategoriaNegocio categoriaN = new CategoriaNegocio();
            ArticuloNegocio articuloN = new ArticuloNegocio();
            Categoria aux = new Categoria();

            aux.Descripcion = txtMarc.Text;
            aux.IdCategoria = categoriaN.obtener(aux.Descripcion);
            articuloN.agregarCategoria(aux);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string Descripcion = txtMarc.Text;
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("delete from MARCAS where Descripcion = @Descripcion");
                datos.setearParametro("@Descripcion", Descripcion);
                datos.ejecutarAccion();




            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string Descripcion = txtCat.Text;
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("delete from CATEGORIAS where Descripcion = @Descripcion");
                datos.setearParametro("@Descripcion", Descripcion);
                datos.ejecutarAccion();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Editar_marca_articulo modificar = new Editar_marca_articulo();
            modificar.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Editar_marca_articulo modificar = new Editar_marca_articulo();
            modificar.ShowDialog();

        }
    }
}
