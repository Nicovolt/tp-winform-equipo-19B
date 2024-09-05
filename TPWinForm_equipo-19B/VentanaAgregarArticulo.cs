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
        public frmVentanaAgregarArticulo()
        {
            InitializeComponent();
        }

        private void btnCancelarArticulo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
