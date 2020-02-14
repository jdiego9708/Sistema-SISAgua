namespace CapaPresentacionAdministracion.Formularios.FormsPrincipales
{
    partial class MenuTarifas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuTarifas));
            this.btnAgregarTarifa = new System.Windows.Forms.Button();
            this.btnEditarTarifa = new System.Windows.Forms.Button();
            this.btnObservarTarifas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAgregarTarifa
            // 
            this.btnAgregarTarifa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarTarifa.FlatAppearance.BorderSize = 0;
            this.btnAgregarTarifa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarTarifa.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarTarifa.ForeColor = System.Drawing.Color.White;
            this.btnAgregarTarifa.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarTarifa.Image")));
            this.btnAgregarTarifa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarTarifa.Location = new System.Drawing.Point(0, 0);
            this.btnAgregarTarifa.Name = "btnAgregarTarifa";
            this.btnAgregarTarifa.Size = new System.Drawing.Size(141, 49);
            this.btnAgregarTarifa.TabIndex = 1;
            this.btnAgregarTarifa.Text = "Agregar\r\n tarifa";
            this.btnAgregarTarifa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarTarifa.UseVisualStyleBackColor = true;
            // 
            // btnEditarTarifa
            // 
            this.btnEditarTarifa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditarTarifa.FlatAppearance.BorderSize = 0;
            this.btnEditarTarifa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarTarifa.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarTarifa.ForeColor = System.Drawing.Color.White;
            this.btnEditarTarifa.Image = ((System.Drawing.Image)(resources.GetObject("btnEditarTarifa.Image")));
            this.btnEditarTarifa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditarTarifa.Location = new System.Drawing.Point(0, 52);
            this.btnEditarTarifa.Name = "btnEditarTarifa";
            this.btnEditarTarifa.Size = new System.Drawing.Size(141, 49);
            this.btnEditarTarifa.TabIndex = 2;
            this.btnEditarTarifa.Text = "Editar datos ";
            this.btnEditarTarifa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditarTarifa.UseVisualStyleBackColor = true;
            // 
            // btnObservarTarifas
            // 
            this.btnObservarTarifas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnObservarTarifas.FlatAppearance.BorderSize = 0;
            this.btnObservarTarifas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnObservarTarifas.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnObservarTarifas.ForeColor = System.Drawing.Color.White;
            this.btnObservarTarifas.Image = ((System.Drawing.Image)(resources.GetObject("btnObservarTarifas.Image")));
            this.btnObservarTarifas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnObservarTarifas.Location = new System.Drawing.Point(0, 104);
            this.btnObservarTarifas.Name = "btnObservarTarifas";
            this.btnObservarTarifas.Size = new System.Drawing.Size(141, 49);
            this.btnObservarTarifas.TabIndex = 3;
            this.btnObservarTarifas.Text = "Observar\rtarifas";
            this.btnObservarTarifas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnObservarTarifas.UseVisualStyleBackColor = true;
            // 
            // MenuTarifas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(152)))), ((int)(((byte)(202)))));
            this.Controls.Add(this.btnObservarTarifas);
            this.Controls.Add(this.btnEditarTarifa);
            this.Controls.Add(this.btnAgregarTarifa);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MenuTarifas";
            this.Size = new System.Drawing.Size(141, 157);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button btnAgregarTarifa;
        public System.Windows.Forms.Button btnEditarTarifa;
        public System.Windows.Forms.Button btnObservarTarifas;
    }
}
