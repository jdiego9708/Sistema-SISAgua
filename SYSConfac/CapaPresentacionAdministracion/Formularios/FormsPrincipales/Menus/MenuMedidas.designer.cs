namespace CapaPresentacionAdministracion.Formularios.FormsPrincipales
{
    partial class MenuMedidas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuMedidas));
            this.btnEditarMedida = new System.Windows.Forms.Button();
            this.btnObservarMedidas = new System.Windows.Forms.Button();
            this.btnAgregarMedida = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEditarMedida
            // 
            this.btnEditarMedida.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditarMedida.FlatAppearance.BorderSize = 0;
            this.btnEditarMedida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarMedida.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarMedida.ForeColor = System.Drawing.Color.White;
            this.btnEditarMedida.Image = ((System.Drawing.Image)(resources.GetObject("btnEditarMedida.Image")));
            this.btnEditarMedida.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditarMedida.Location = new System.Drawing.Point(0, 52);
            this.btnEditarMedida.Name = "btnEditarMedida";
            this.btnEditarMedida.Size = new System.Drawing.Size(141, 49);
            this.btnEditarMedida.TabIndex = 2;
            this.btnEditarMedida.Text = "Editar datos ";
            this.btnEditarMedida.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditarMedida.UseVisualStyleBackColor = true;
            // 
            // btnObservarMedidas
            // 
            this.btnObservarMedidas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnObservarMedidas.FlatAppearance.BorderSize = 0;
            this.btnObservarMedidas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnObservarMedidas.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnObservarMedidas.ForeColor = System.Drawing.Color.White;
            this.btnObservarMedidas.Image = ((System.Drawing.Image)(resources.GetObject("btnObservarMedidas.Image")));
            this.btnObservarMedidas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnObservarMedidas.Location = new System.Drawing.Point(0, 104);
            this.btnObservarMedidas.Name = "btnObservarMedidas";
            this.btnObservarMedidas.Size = new System.Drawing.Size(141, 49);
            this.btnObservarMedidas.TabIndex = 3;
            this.btnObservarMedidas.Text = "Observar\r\nmedidas";
            this.btnObservarMedidas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnObservarMedidas.UseVisualStyleBackColor = true;
            // 
            // btnAgregarMedida
            // 
            this.btnAgregarMedida.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarMedida.FlatAppearance.BorderSize = 0;
            this.btnAgregarMedida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarMedida.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarMedida.ForeColor = System.Drawing.Color.White;
            this.btnAgregarMedida.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarMedida.Image")));
            this.btnAgregarMedida.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarMedida.Location = new System.Drawing.Point(1, 1);
            this.btnAgregarMedida.Name = "btnAgregarMedida";
            this.btnAgregarMedida.Size = new System.Drawing.Size(141, 49);
            this.btnAgregarMedida.TabIndex = 4;
            this.btnAgregarMedida.Text = "Agregar una \r\nmedida";
            this.btnAgregarMedida.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarMedida.UseVisualStyleBackColor = true;
            // 
            // MenuMedidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(152)))), ((int)(((byte)(202)))));
            this.Controls.Add(this.btnAgregarMedida);
            this.Controls.Add(this.btnObservarMedidas);
            this.Controls.Add(this.btnEditarMedida);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MenuMedidas";
            this.Size = new System.Drawing.Size(141, 157);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Button btnEditarMedida;
        public System.Windows.Forms.Button btnObservarMedidas;
        public System.Windows.Forms.Button btnAgregarMedida;
    }
}
