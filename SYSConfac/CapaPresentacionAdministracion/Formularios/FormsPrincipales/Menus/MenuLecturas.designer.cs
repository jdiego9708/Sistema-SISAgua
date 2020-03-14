namespace CapaPresentacionAdministracion.Formularios.FormsPrincipales
{
    partial class MenuLecturas
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuLecturas));
            this.btnModificarLectura = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnModificarLectura
            // 
            this.btnModificarLectura.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificarLectura.FlatAppearance.BorderSize = 0;
            this.btnModificarLectura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarLectura.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarLectura.ForeColor = System.Drawing.Color.White;
            this.btnModificarLectura.Image = ((System.Drawing.Image)(resources.GetObject("btnModificarLectura.Image")));
            this.btnModificarLectura.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificarLectura.Location = new System.Drawing.Point(0, 1);
            this.btnModificarLectura.Name = "btnModificarLectura";
            this.btnModificarLectura.Size = new System.Drawing.Size(157, 49);
            this.btnModificarLectura.TabIndex = 4;
            this.btnModificarLectura.Text = "Modificar lectura";
            this.btnModificarLectura.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModificarLectura.UseVisualStyleBackColor = true;
            // 
            // MenuLecturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(152)))), ((int)(((byte)(202)))));
            this.Controls.Add(this.btnModificarLectura);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MenuLecturas";
            this.Size = new System.Drawing.Size(157, 53);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Button btnModificarLectura;
    }
}
