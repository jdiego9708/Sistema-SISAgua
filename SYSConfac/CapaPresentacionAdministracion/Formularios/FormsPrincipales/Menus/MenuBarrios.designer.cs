namespace CapaPresentacionAdministracion.Formularios.FormsPrincipales
{
    partial class MenuBarrios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuBarrios));
            this.btnEditarBarrio = new System.Windows.Forms.Button();
            this.btnObservarBarrios = new System.Windows.Forms.Button();
            this.btnAgregarBarrio = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEditarBarrio
            // 
            this.btnEditarBarrio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditarBarrio.FlatAppearance.BorderSize = 0;
            this.btnEditarBarrio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarBarrio.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarBarrio.ForeColor = System.Drawing.Color.White;
            this.btnEditarBarrio.Image = ((System.Drawing.Image)(resources.GetObject("btnEditarBarrio.Image")));
            this.btnEditarBarrio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditarBarrio.Location = new System.Drawing.Point(0, 52);
            this.btnEditarBarrio.Name = "btnEditarBarrio";
            this.btnEditarBarrio.Size = new System.Drawing.Size(141, 49);
            this.btnEditarBarrio.TabIndex = 2;
            this.btnEditarBarrio.Text = "Editar datos ";
            this.btnEditarBarrio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditarBarrio.UseVisualStyleBackColor = true;
            // 
            // btnObservarBarrios
            // 
            this.btnObservarBarrios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnObservarBarrios.FlatAppearance.BorderSize = 0;
            this.btnObservarBarrios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnObservarBarrios.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnObservarBarrios.ForeColor = System.Drawing.Color.White;
            this.btnObservarBarrios.Image = ((System.Drawing.Image)(resources.GetObject("btnObservarBarrios.Image")));
            this.btnObservarBarrios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnObservarBarrios.Location = new System.Drawing.Point(0, 104);
            this.btnObservarBarrios.Name = "btnObservarBarrios";
            this.btnObservarBarrios.Size = new System.Drawing.Size(141, 49);
            this.btnObservarBarrios.TabIndex = 3;
            this.btnObservarBarrios.Text = "Observar\r\nbarrios";
            this.btnObservarBarrios.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnObservarBarrios.UseVisualStyleBackColor = true;
            // 
            // btnAgregarBarrio
            // 
            this.btnAgregarBarrio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarBarrio.FlatAppearance.BorderSize = 0;
            this.btnAgregarBarrio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarBarrio.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarBarrio.ForeColor = System.Drawing.Color.White;
            this.btnAgregarBarrio.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarBarrio.Image")));
            this.btnAgregarBarrio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarBarrio.Location = new System.Drawing.Point(1, 1);
            this.btnAgregarBarrio.Name = "btnAgregarBarrio";
            this.btnAgregarBarrio.Size = new System.Drawing.Size(141, 49);
            this.btnAgregarBarrio.TabIndex = 4;
            this.btnAgregarBarrio.Text = "Agregar un \rbarrio";
            this.btnAgregarBarrio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarBarrio.UseVisualStyleBackColor = true;
            // 
            // MenuBarrios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(152)))), ((int)(((byte)(202)))));
            this.Controls.Add(this.btnAgregarBarrio);
            this.Controls.Add(this.btnObservarBarrios);
            this.Controls.Add(this.btnEditarBarrio);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MenuBarrios";
            this.Size = new System.Drawing.Size(141, 157);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Button btnEditarBarrio;
        public System.Windows.Forms.Button btnObservarBarrios;
        public System.Windows.Forms.Button btnAgregarBarrio;
    }
}
