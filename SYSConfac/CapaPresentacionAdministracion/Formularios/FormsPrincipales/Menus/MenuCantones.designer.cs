namespace CapaPresentacionAdministracion.Formularios.FormsPrincipales
{
    partial class MenuCantones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuCantones));
            this.btnAgregarCanton = new System.Windows.Forms.Button();
            this.btnEditarCanton = new System.Windows.Forms.Button();
            this.btnObservarCantones = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAgregarCanton
            // 
            this.btnAgregarCanton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarCanton.FlatAppearance.BorderSize = 0;
            this.btnAgregarCanton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarCanton.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarCanton.ForeColor = System.Drawing.Color.White;
            this.btnAgregarCanton.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarCanton.Image")));
            this.btnAgregarCanton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarCanton.Location = new System.Drawing.Point(0, 0);
            this.btnAgregarCanton.Name = "btnAgregarCanton";
            this.btnAgregarCanton.Size = new System.Drawing.Size(141, 49);
            this.btnAgregarCanton.TabIndex = 1;
            this.btnAgregarCanton.Text = "Agregar un \r\ncantón";
            this.btnAgregarCanton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarCanton.UseVisualStyleBackColor = true;
            // 
            // btnEditarCanton
            // 
            this.btnEditarCanton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditarCanton.FlatAppearance.BorderSize = 0;
            this.btnEditarCanton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarCanton.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarCanton.ForeColor = System.Drawing.Color.White;
            this.btnEditarCanton.Image = ((System.Drawing.Image)(resources.GetObject("btnEditarCanton.Image")));
            this.btnEditarCanton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditarCanton.Location = new System.Drawing.Point(0, 52);
            this.btnEditarCanton.Name = "btnEditarCanton";
            this.btnEditarCanton.Size = new System.Drawing.Size(141, 49);
            this.btnEditarCanton.TabIndex = 2;
            this.btnEditarCanton.Text = "Editar datos ";
            this.btnEditarCanton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditarCanton.UseVisualStyleBackColor = true;
            // 
            // btnObservarCantones
            // 
            this.btnObservarCantones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnObservarCantones.FlatAppearance.BorderSize = 0;
            this.btnObservarCantones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnObservarCantones.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnObservarCantones.ForeColor = System.Drawing.Color.White;
            this.btnObservarCantones.Image = ((System.Drawing.Image)(resources.GetObject("btnObservarCantones.Image")));
            this.btnObservarCantones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnObservarCantones.Location = new System.Drawing.Point(0, 104);
            this.btnObservarCantones.Name = "btnObservarCantones";
            this.btnObservarCantones.Size = new System.Drawing.Size(141, 49);
            this.btnObservarCantones.TabIndex = 3;
            this.btnObservarCantones.Text = "Observar\r\ncantones\r\n";
            this.btnObservarCantones.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnObservarCantones.UseVisualStyleBackColor = true;
            // 
            // MenuCantones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(152)))), ((int)(((byte)(202)))));
            this.Controls.Add(this.btnObservarCantones);
            this.Controls.Add(this.btnEditarCanton);
            this.Controls.Add(this.btnAgregarCanton);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MenuCantones";
            this.Size = new System.Drawing.Size(141, 157);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button btnAgregarCanton;
        public System.Windows.Forms.Button btnEditarCanton;
        public System.Windows.Forms.Button btnObservarCantones;
    }
}
