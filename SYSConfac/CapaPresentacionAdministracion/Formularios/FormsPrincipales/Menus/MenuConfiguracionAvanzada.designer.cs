namespace CapaPresentacionAdministracion.Formularios.FormsPrincipales
{
    partial class MenuConfiguracionAvanzada
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuConfiguracionAvanzada));
            this.btnConfiguracionAvanzada = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnConfiguracionAvanzada
            // 
            this.btnConfiguracionAvanzada.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfiguracionAvanzada.FlatAppearance.BorderSize = 0;
            this.btnConfiguracionAvanzada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfiguracionAvanzada.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfiguracionAvanzada.ForeColor = System.Drawing.Color.White;
            this.btnConfiguracionAvanzada.Image = ((System.Drawing.Image)(resources.GetObject("btnConfiguracionAvanzada.Image")));
            this.btnConfiguracionAvanzada.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfiguracionAvanzada.Location = new System.Drawing.Point(1, 1);
            this.btnConfiguracionAvanzada.Name = "btnConfiguracionAvanzada";
            this.btnConfiguracionAvanzada.Size = new System.Drawing.Size(141, 49);
            this.btnConfiguracionAvanzada.TabIndex = 4;
            this.btnConfiguracionAvanzada.Text = "Configuración avanzada";
            this.btnConfiguracionAvanzada.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfiguracionAvanzada.UseVisualStyleBackColor = true;
            // 
            // MenuConfiguracionAvanzada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(152)))), ((int)(((byte)(202)))));
            this.Controls.Add(this.btnConfiguracionAvanzada);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MenuConfiguracionAvanzada";
            this.Size = new System.Drawing.Size(141, 55);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Button btnConfiguracionAvanzada;
    }
}
