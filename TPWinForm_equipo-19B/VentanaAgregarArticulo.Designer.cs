using System.Drawing;
using System.Reflection.Emit;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace TPWinForm_equipo_19B
{
    partial class frmVentanaAgregarArticulo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblCodigo = new System.Windows.Forms.Label();
            this.tbxCodigo = new System.Windows.Forms.TextBox();
            this.tbxNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.tbxDescripcion = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblMarca = new System.Windows.Forms.Label();
            this.cbxMarca = new System.Windows.Forms.ComboBox();
            this.cbxCategoria = new System.Windows.Forms.ComboBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.tbxPrecio = new System.Windows.Forms.TextBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.tbxUrlImagen = new System.Windows.Forms.TextBox();
            this.lblUrlImagen = new System.Windows.Forms.Label();
            this.btnAceptarArticulo = new System.Windows.Forms.Button();
            this.btnCancelarArticulo = new System.Windows.Forms.Button();
            this.pbxImagenArticulo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImagenArticulo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Arial", 10F);
            this.lblCodigo.ForeColor = System.Drawing.Color.Black;
            this.lblCodigo.Location = new System.Drawing.Point(55, 50);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(56, 16);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Codigo:";
            // 
            // tbxCodigo
            // 
            this.tbxCodigo.Font = new System.Drawing.Font("Arial", 10F);
            this.tbxCodigo.Location = new System.Drawing.Point(117, 47);
            this.tbxCodigo.Name = "tbxCodigo";
            this.tbxCodigo.Size = new System.Drawing.Size(177, 23);
            this.tbxCodigo.TabIndex = 0;
            // 
            // tbxNombre
            // 
            this.tbxNombre.Font = new System.Drawing.Font("Arial", 10F);
            this.tbxNombre.Location = new System.Drawing.Point(117, 88);
            this.tbxNombre.Name = "tbxNombre";
            this.tbxNombre.Size = new System.Drawing.Size(177, 23);
            this.tbxNombre.TabIndex = 2;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Arial", 10F);
            this.lblNombre.ForeColor = System.Drawing.Color.Black;
            this.lblNombre.Location = new System.Drawing.Point(51, 91);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(60, 16);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre:";
            // 
            // tbxDescripcion
            // 
            this.tbxDescripcion.Font = new System.Drawing.Font("Arial", 10F);
            this.tbxDescripcion.Location = new System.Drawing.Point(117, 131);
            this.tbxDescripcion.Multiline = true;
            this.tbxDescripcion.Name = "tbxDescripcion";
            this.tbxDescripcion.Size = new System.Drawing.Size(177, 51);
            this.tbxDescripcion.TabIndex = 3;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Arial", 10F);
            this.lblDescripcion.ForeColor = System.Drawing.Color.Black;
            this.lblDescripcion.Location = new System.Drawing.Point(26, 134);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(85, 16);
            this.lblDescripcion.TabIndex = 4;
            this.lblDescripcion.Text = "Descripcion:";
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Font = new System.Drawing.Font("Arial", 10F);
            this.lblMarca.ForeColor = System.Drawing.Color.Black;
            this.lblMarca.Location = new System.Drawing.Point(61, 211);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(50, 16);
            this.lblMarca.TabIndex = 6;
            this.lblMarca.Text = "Marca:";
            // 
            // cbxMarca
            // 
            this.cbxMarca.BackColor = System.Drawing.Color.White;
            this.cbxMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMarca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxMarca.Font = new System.Drawing.Font("Arial", 10F);
            this.cbxMarca.ForeColor = System.Drawing.Color.Black;
            this.cbxMarca.FormattingEnabled = true;
            this.cbxMarca.Location = new System.Drawing.Point(117, 208);
            this.cbxMarca.Name = "cbxMarca";
            this.cbxMarca.Size = new System.Drawing.Size(177, 24);
            this.cbxMarca.TabIndex = 4;
            // 
            // cbxCategoria
            // 
            this.cbxCategoria.BackColor = System.Drawing.Color.White;
            this.cbxCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxCategoria.Font = new System.Drawing.Font("Arial", 10F);
            this.cbxCategoria.ForeColor = System.Drawing.Color.Black;
            this.cbxCategoria.FormattingEnabled = true;
            this.cbxCategoria.Location = new System.Drawing.Point(117, 248);
            this.cbxCategoria.Name = "cbxCategoria";
            this.cbxCategoria.Size = new System.Drawing.Size(177, 24);
            this.cbxCategoria.TabIndex = 5;
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Font = new System.Drawing.Font("Arial", 10F);
            this.lblCategoria.ForeColor = System.Drawing.Color.Black;
            this.lblCategoria.Location = new System.Drawing.Point(38, 251);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(73, 16);
            this.lblCategoria.TabIndex = 8;
            this.lblCategoria.Text = "Categoria:";
            // 
            // tbxPrecio
            // 
            this.tbxPrecio.Font = new System.Drawing.Font("Arial", 10F);
            this.tbxPrecio.Location = new System.Drawing.Point(117, 287);
            this.tbxPrecio.Name = "tbxPrecio";
            this.tbxPrecio.Size = new System.Drawing.Size(177, 23);
            this.tbxPrecio.TabIndex = 6;
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Arial", 10F);
            this.lblPrecio.ForeColor = System.Drawing.Color.Black;
            this.lblPrecio.Location = new System.Drawing.Point(61, 290);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(51, 16);
            this.lblPrecio.TabIndex = 10;
            this.lblPrecio.Text = "Precio:";
            // 
            // tbxUrlImagen
            // 
            this.tbxUrlImagen.Font = new System.Drawing.Font("Arial", 10F);
            this.tbxUrlImagen.Location = new System.Drawing.Point(117, 321);
            this.tbxUrlImagen.Name = "tbxUrlImagen";
            this.tbxUrlImagen.Size = new System.Drawing.Size(350, 23);
            this.tbxUrlImagen.TabIndex = 7;
            this.tbxUrlImagen.Leave += new System.EventHandler(this.tbxUrlImagen_Leave);
            // 
            // lblUrlImagen
            // 
            this.lblUrlImagen.AutoSize = true;
            this.lblUrlImagen.Font = new System.Drawing.Font("Arial", 10F);
            this.lblUrlImagen.ForeColor = System.Drawing.Color.Black;
            this.lblUrlImagen.Location = new System.Drawing.Point(33, 324);
            this.lblUrlImagen.Name = "lblUrlImagen";
            this.lblUrlImagen.Size = new System.Drawing.Size(78, 16);
            this.lblUrlImagen.TabIndex = 12;
            this.lblUrlImagen.Text = "Url Imagen:";
            // 
            // btnAceptarArticulo
            // 
            this.btnAceptarArticulo.Location = new System.Drawing.Point(402, 370);
            this.btnAceptarArticulo.Name = "btnAceptarArticulo";
            this.btnAceptarArticulo.Size = new System.Drawing.Size(141, 27);
            this.btnAceptarArticulo.TabIndex = 9;
            this.btnAceptarArticulo.Text = "Agregar";
            this.btnAceptarArticulo.UseVisualStyleBackColor = true;
            this.btnAceptarArticulo.Click += new System.EventHandler(this.btnAceptarArticulo_Click);
            this.btnAceptarArticulo.FlatStyle = FlatStyle.Flat;
            this.btnAceptarArticulo.BackColor = Color.LightBlue;
            this.btnAceptarArticulo.ForeColor = Color.White;
            this.btnAceptarArticulo.Font = new Font("Arial", 10, FontStyle.Bold);
            // 
            // btnCancelarArticulo
            // 
            this.btnCancelarArticulo.Location = new System.Drawing.Point(12, 370);
            this.btnCancelarArticulo.Name = "btnCancelarArticulo";
            this.btnCancelarArticulo.Size = new System.Drawing.Size(141, 27);
            this.btnCancelarArticulo.TabIndex = 8;
            this.btnCancelarArticulo.Text = "Cancelar";
            this.btnCancelarArticulo.UseVisualStyleBackColor = true;
            this.btnCancelarArticulo.Click += new System.EventHandler(this.btnCancelarArticulo_Click);
            this.btnCancelarArticulo.FlatStyle = FlatStyle.Flat;
            this.btnCancelarArticulo.BackColor = Color.LightBlue;
            this.btnCancelarArticulo.ForeColor = Color.White;
            this.btnCancelarArticulo.Font = new Font("Arial", 10, FontStyle.Bold);
            // 
            // pbxImagenArticulo
            // 
            this.pbxImagenArticulo.Location = new System.Drawing.Point(320, 47);
            this.pbxImagenArticulo.Name = "pbxImagenArticulo";
            this.pbxImagenArticulo.Size = new System.Drawing.Size(223, 256);
            this.pbxImagenArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxImagenArticulo.TabIndex = 16;
            this.pbxImagenArticulo.TabStop = false;
            this.pbxImagenArticulo.BorderStyle = BorderStyle.FixedSingle;
            // 
            // frmVentanaAgregarArticulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 424);
            this.Controls.Add(this.pbxImagenArticulo);
            this.Controls.Add(this.btnCancelarArticulo);
            this.Controls.Add(this.btnAceptarArticulo);
            this.Controls.Add(this.tbxUrlImagen);
            this.Controls.Add(this.lblUrlImagen);
            this.Controls.Add(this.tbxPrecio);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.cbxCategoria);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.cbxMarca);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.tbxDescripcion);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.tbxNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.tbxCodigo);
            this.Controls.Add(this.lblCodigo);
            this.Name = "frmVentanaAgregarArticulo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar articulo";
            this.Load += new System.EventHandler(this.frmVentanaAgregarArticulo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxImagenArticulo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
            this.BackColor = Color.CadetBlue;

        }

        #endregion

        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox tbxCodigo;
        private System.Windows.Forms.TextBox tbxNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox tbxDescripcion;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.ComboBox cbxMarca;
        private System.Windows.Forms.ComboBox cbxCategoria;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.TextBox tbxPrecio;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.TextBox tbxUrlImagen;
        private System.Windows.Forms.Label lblUrlImagen;
        private System.Windows.Forms.Button btnAceptarArticulo;
        private System.Windows.Forms.Button btnCancelarArticulo;
        private System.Windows.Forms.PictureBox pbxImagenArticulo;
    }
}