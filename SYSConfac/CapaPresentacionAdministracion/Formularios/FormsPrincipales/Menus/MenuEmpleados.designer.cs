namespace CapaPresentacionAdministracion.Formularios.FormsPrincipales
{
    partial class MenuEmpleados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuEmpleados));
            this.btnEditarEmpleado = new System.Windows.Forms.Button();
            this.btnObservarEmpleados = new System.Windows.Forms.Button();
            this.btnAgregarEmpleado = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEditarEmpleado
            // 
            this.btnEditarEmpleado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditarEmpleado.FlatAppearance.BorderSize = 0;
            this.btnEditarEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarEmpleado.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarEmpleado.ForeColor = System.Drawing.Color.White;
            this.btnEditarEmpleado.Image = ((System.Drawing.Image)(resources.GetObject("btnEditarEmpleado.Image")));
            this.btnEditarEmpleado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditarEmpleado.Location = new System.Drawing.Point(0, 52);
            this.btnEditarEmpleado.Name = "btnEditarEmpleado";
            this.btnEditarEmpleado.Size = new System.Drawing.Size(141, 49);
            this.btnEditarEmpleado.TabIndex = 2;
            this.btnEditarEmpleado.Text = "Editar datos";
            this.btnEditarEmpleado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditarEmpleado.UseVisualStyleBackColor = true;
            // 
            // btnObservarEmpleados
            // 
            this.btnObservarEmpleados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnObservarEmpleados.FlatAppearance.BorderSize = 0;
            this.btnObservarEmpleados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnObservarEmpleados.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnObservarEmpleados.ForeColor = System.Drawing.Color.White;
            this.btnObservarEmpleados.Image = ((System.Drawing.Image)(resources.GetObject("btnObservarEmpleados.Image")));
            this.btnObservarEmpleados.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnObservarEmpleados.Location = new System.Drawing.Point(0, 104);
            this.btnObservarEmpleados.Name = "btnObservarEmpleados";
            this.btnObservarEmpleados.Size = new System.Drawing.Size(141, 49);
            this.btnObservarEmpleados.TabIndex = 3;
            this.btnObservarEmpleados.Text = "Observar\r\nempleados";
            this.btnObservarEmpleados.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnObservarEmpleados.UseVisualStyleBackColor = true;
            // 
            // btnAgregarEmpleado
            // 
            this.btnAgregarEmpleado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarEmpleado.FlatAppearance.BorderSize = 0;
            this.btnAgregarEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarEmpleado.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarEmpleado.ForeColor = System.Drawing.Color.White;
            this.btnAgregarEmpleado.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarEmpleado.Image")));
            this.btnAgregarEmpleado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarEmpleado.Location = new System.Drawing.Point(1, 1);
            this.btnAgregarEmpleado.Name = "btnAgregarEmpleado";
            this.btnAgregarEmpleado.Size = new System.Drawing.Size(141, 49);
            this.btnAgregarEmpleado.TabIndex = 4;
            this.btnAgregarEmpleado.Text = "Agregar un \rempleado";
            this.btnAgregarEmpleado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarEmpleado.UseVisualStyleBackColor = true;
            // 
            // MenuEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(152)))), ((int)(((byte)(202)))));
            this.Controls.Add(this.btnAgregarEmpleado);
            this.Controls.Add(this.btnObservarEmpleados);
            this.Controls.Add(this.btnEditarEmpleado);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MenuEmpleados";
            this.Size = new System.Drawing.Size(141, 157);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Button btnEditarEmpleado;
        public System.Windows.Forms.Button btnObservarEmpleados;
        public System.Windows.Forms.Button btnAgregarEmpleado;
    }
}
