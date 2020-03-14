namespace CapaPresentacionAdministracion.Formularios.FormsPrincipales
{
    partial class MenuGastos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuGastos));
            this.btnEditarGasto = new System.Windows.Forms.Button();
            this.btnObservarGastos = new System.Windows.Forms.Button();
            this.btnAgregarGasto = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEditarGasto
            // 
            this.btnEditarGasto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditarGasto.FlatAppearance.BorderSize = 0;
            this.btnEditarGasto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarGasto.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarGasto.ForeColor = System.Drawing.Color.White;
            this.btnEditarGasto.Image = ((System.Drawing.Image)(resources.GetObject("btnEditarGasto.Image")));
            this.btnEditarGasto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditarGasto.Location = new System.Drawing.Point(0, 52);
            this.btnEditarGasto.Name = "btnEditarGasto";
            this.btnEditarGasto.Size = new System.Drawing.Size(141, 49);
            this.btnEditarGasto.TabIndex = 2;
            this.btnEditarGasto.Text = "Editar datos ";
            this.btnEditarGasto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditarGasto.UseVisualStyleBackColor = true;
            // 
            // btnObservarGastos
            // 
            this.btnObservarGastos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnObservarGastos.FlatAppearance.BorderSize = 0;
            this.btnObservarGastos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnObservarGastos.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnObservarGastos.ForeColor = System.Drawing.Color.White;
            this.btnObservarGastos.Image = ((System.Drawing.Image)(resources.GetObject("btnObservarGastos.Image")));
            this.btnObservarGastos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnObservarGastos.Location = new System.Drawing.Point(0, 104);
            this.btnObservarGastos.Name = "btnObservarGastos";
            this.btnObservarGastos.Size = new System.Drawing.Size(141, 49);
            this.btnObservarGastos.TabIndex = 3;
            this.btnObservarGastos.Text = "Observar tipos \r\nde gastos";
            this.btnObservarGastos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnObservarGastos.UseVisualStyleBackColor = true;
            // 
            // btnAgregarGasto
            // 
            this.btnAgregarGasto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarGasto.FlatAppearance.BorderSize = 0;
            this.btnAgregarGasto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarGasto.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarGasto.ForeColor = System.Drawing.Color.White;
            this.btnAgregarGasto.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarGasto.Image")));
            this.btnAgregarGasto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarGasto.Location = new System.Drawing.Point(1, 1);
            this.btnAgregarGasto.Name = "btnAgregarGasto";
            this.btnAgregarGasto.Size = new System.Drawing.Size(141, 49);
            this.btnAgregarGasto.TabIndex = 4;
            this.btnAgregarGasto.Text = "Agregar un \r\ntipo de gasto";
            this.btnAgregarGasto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarGasto.UseVisualStyleBackColor = true;
            // 
            // MenuGastos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(152)))), ((int)(((byte)(202)))));
            this.Controls.Add(this.btnAgregarGasto);
            this.Controls.Add(this.btnObservarGastos);
            this.Controls.Add(this.btnEditarGasto);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MenuGastos";
            this.Size = new System.Drawing.Size(141, 157);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Button btnEditarGasto;
        public System.Windows.Forms.Button btnObservarGastos;
        public System.Windows.Forms.Button btnAgregarGasto;
    }
}
