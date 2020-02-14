namespace CapaPresentacionAdministracion.Formularios.FormsPrincipales
{
    partial class MenuCuentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuCuentas));
            this.btnObservarCuentas = new System.Windows.Forms.Button();
            this.btnEditarCuentas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnObservarCuentas
            // 
            this.btnObservarCuentas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnObservarCuentas.FlatAppearance.BorderSize = 0;
            this.btnObservarCuentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnObservarCuentas.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnObservarCuentas.ForeColor = System.Drawing.Color.White;
            this.btnObservarCuentas.Image = ((System.Drawing.Image)(resources.GetObject("btnObservarCuentas.Image")));
            this.btnObservarCuentas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnObservarCuentas.Location = new System.Drawing.Point(0, 57);
            this.btnObservarCuentas.Name = "btnObservarCuentas";
            this.btnObservarCuentas.Size = new System.Drawing.Size(141, 49);
            this.btnObservarCuentas.TabIndex = 3;
            this.btnObservarCuentas.Text = "Observar\r\ncuentas";
            this.btnObservarCuentas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnObservarCuentas.UseVisualStyleBackColor = true;
            // 
            // btnEditarCuentas
            // 
            this.btnEditarCuentas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditarCuentas.FlatAppearance.BorderSize = 0;
            this.btnEditarCuentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarCuentas.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarCuentas.ForeColor = System.Drawing.Color.White;
            this.btnEditarCuentas.Image = ((System.Drawing.Image)(resources.GetObject("btnEditarCuentas.Image")));
            this.btnEditarCuentas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditarCuentas.Location = new System.Drawing.Point(0, 2);
            this.btnEditarCuentas.Name = "btnEditarCuentas";
            this.btnEditarCuentas.Size = new System.Drawing.Size(141, 49);
            this.btnEditarCuentas.TabIndex = 4;
            this.btnEditarCuentas.Text = "Editar\r\ncuentas";
            this.btnEditarCuentas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditarCuentas.UseVisualStyleBackColor = true;
            // 
            // MenuCuentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(152)))), ((int)(((byte)(202)))));
            this.Controls.Add(this.btnEditarCuentas);
            this.Controls.Add(this.btnObservarCuentas);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MenuCuentas";
            this.Size = new System.Drawing.Size(141, 110);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Button btnObservarCuentas;
        public System.Windows.Forms.Button btnEditarCuentas;
    }
}
