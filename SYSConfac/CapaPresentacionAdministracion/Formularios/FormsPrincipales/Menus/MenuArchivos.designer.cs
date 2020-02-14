namespace CapaPresentacionAdministracion.Formularios.FormsPrincipales
{
    partial class MenuArchivos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuArchivos));
            this.btnEditarArchivos = new System.Windows.Forms.Button();
            this.btnObservarArchivos = new System.Windows.Forms.Button();
            this.btnAgregarArchivo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEditarArchivos
            // 
            this.btnEditarArchivos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditarArchivos.FlatAppearance.BorderSize = 0;
            this.btnEditarArchivos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarArchivos.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarArchivos.ForeColor = System.Drawing.Color.White;
            this.btnEditarArchivos.Image = ((System.Drawing.Image)(resources.GetObject("btnEditarArchivos.Image")));
            this.btnEditarArchivos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditarArchivos.Location = new System.Drawing.Point(0, 52);
            this.btnEditarArchivos.Name = "btnEditarArchivos";
            this.btnEditarArchivos.Size = new System.Drawing.Size(141, 49);
            this.btnEditarArchivos.TabIndex = 2;
            this.btnEditarArchivos.Text = "Editar datos \r\nde archivos";
            this.btnEditarArchivos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditarArchivos.UseVisualStyleBackColor = true;
            // 
            // btnObservarArchivos
            // 
            this.btnObservarArchivos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnObservarArchivos.FlatAppearance.BorderSize = 0;
            this.btnObservarArchivos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnObservarArchivos.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnObservarArchivos.ForeColor = System.Drawing.Color.White;
            this.btnObservarArchivos.Image = ((System.Drawing.Image)(resources.GetObject("btnObservarArchivos.Image")));
            this.btnObservarArchivos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnObservarArchivos.Location = new System.Drawing.Point(0, 104);
            this.btnObservarArchivos.Name = "btnObservarArchivos";
            this.btnObservarArchivos.Size = new System.Drawing.Size(141, 49);
            this.btnObservarArchivos.TabIndex = 3;
            this.btnObservarArchivos.Text = "Observar\rarchivos";
            this.btnObservarArchivos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnObservarArchivos.UseVisualStyleBackColor = true;
            // 
            // btnAgregarArchivo
            // 
            this.btnAgregarArchivo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarArchivo.FlatAppearance.BorderSize = 0;
            this.btnAgregarArchivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarArchivo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarArchivo.ForeColor = System.Drawing.Color.White;
            this.btnAgregarArchivo.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarArchivo.Image")));
            this.btnAgregarArchivo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarArchivo.Location = new System.Drawing.Point(1, 1);
            this.btnAgregarArchivo.Name = "btnAgregarArchivo";
            this.btnAgregarArchivo.Size = new System.Drawing.Size(141, 49);
            this.btnAgregarArchivo.TabIndex = 4;
            this.btnAgregarArchivo.Text = "Agregar un \rarchivo";
            this.btnAgregarArchivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarArchivo.UseVisualStyleBackColor = true;
            // 
            // MenuArchivos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(152)))), ((int)(((byte)(202)))));
            this.Controls.Add(this.btnAgregarArchivo);
            this.Controls.Add(this.btnObservarArchivos);
            this.Controls.Add(this.btnEditarArchivos);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MenuArchivos";
            this.Size = new System.Drawing.Size(141, 157);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Button btnEditarArchivos;
        public System.Windows.Forms.Button btnObservarArchivos;
        public System.Windows.Forms.Button btnAgregarArchivo;
    }
}
