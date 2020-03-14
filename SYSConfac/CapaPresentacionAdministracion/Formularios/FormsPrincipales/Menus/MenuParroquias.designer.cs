namespace CapaPresentacionAdministracion.Formularios.FormsPrincipales
{
    partial class MenuParroquias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuParroquias));
            this.btnAgregarParroquia = new System.Windows.Forms.Button();
            this.btnEditarParroquia = new System.Windows.Forms.Button();
            this.btnObservarParroquias = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAgregarParroquia
            // 
            this.btnAgregarParroquia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarParroquia.FlatAppearance.BorderSize = 0;
            this.btnAgregarParroquia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarParroquia.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarParroquia.ForeColor = System.Drawing.Color.White;
            this.btnAgregarParroquia.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarParroquia.Image")));
            this.btnAgregarParroquia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarParroquia.Location = new System.Drawing.Point(0, 0);
            this.btnAgregarParroquia.Name = "btnAgregarParroquia";
            this.btnAgregarParroquia.Size = new System.Drawing.Size(141, 49);
            this.btnAgregarParroquia.TabIndex = 1;
            this.btnAgregarParroquia.Text = "Agregar\r\n parroquia";
            this.btnAgregarParroquia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarParroquia.UseVisualStyleBackColor = true;
            // 
            // btnEditarParroquia
            // 
            this.btnEditarParroquia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditarParroquia.FlatAppearance.BorderSize = 0;
            this.btnEditarParroquia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarParroquia.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarParroquia.ForeColor = System.Drawing.Color.White;
            this.btnEditarParroquia.Image = ((System.Drawing.Image)(resources.GetObject("btnEditarParroquia.Image")));
            this.btnEditarParroquia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditarParroquia.Location = new System.Drawing.Point(0, 52);
            this.btnEditarParroquia.Name = "btnEditarParroquia";
            this.btnEditarParroquia.Size = new System.Drawing.Size(141, 49);
            this.btnEditarParroquia.TabIndex = 2;
            this.btnEditarParroquia.Text = "Editar datos ";
            this.btnEditarParroquia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditarParroquia.UseVisualStyleBackColor = true;
            // 
            // btnObservarParroquias
            // 
            this.btnObservarParroquias.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnObservarParroquias.FlatAppearance.BorderSize = 0;
            this.btnObservarParroquias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnObservarParroquias.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnObservarParroquias.ForeColor = System.Drawing.Color.White;
            this.btnObservarParroquias.Image = ((System.Drawing.Image)(resources.GetObject("btnObservarParroquias.Image")));
            this.btnObservarParroquias.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnObservarParroquias.Location = new System.Drawing.Point(0, 104);
            this.btnObservarParroquias.Name = "btnObservarParroquias";
            this.btnObservarParroquias.Size = new System.Drawing.Size(141, 49);
            this.btnObservarParroquias.TabIndex = 3;
            this.btnObservarParroquias.Text = "Observar\rparroquias\r\n";
            this.btnObservarParroquias.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnObservarParroquias.UseVisualStyleBackColor = true;
            // 
            // MenuParroquias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(152)))), ((int)(((byte)(202)))));
            this.Controls.Add(this.btnObservarParroquias);
            this.Controls.Add(this.btnEditarParroquia);
            this.Controls.Add(this.btnAgregarParroquia);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MenuParroquias";
            this.Size = new System.Drawing.Size(141, 157);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button btnAgregarParroquia;
        public System.Windows.Forms.Button btnEditarParroquia;
        public System.Windows.Forms.Button btnObservarParroquias;
    }
}
