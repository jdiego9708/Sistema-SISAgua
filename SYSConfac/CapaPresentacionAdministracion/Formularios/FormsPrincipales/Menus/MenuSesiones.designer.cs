namespace CapaPresentacionAdministracion.Formularios.FormsPrincipales
{
    partial class MenuSesiones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuSesiones));
            this.btnCambiarFechaSesion = new System.Windows.Forms.Button();
            this.btnObservarAgendamiento = new System.Windows.Forms.Button();
            this.btnAgendarSesion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCambiarFechaSesion
            // 
            this.btnCambiarFechaSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCambiarFechaSesion.FlatAppearance.BorderSize = 0;
            this.btnCambiarFechaSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCambiarFechaSesion.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCambiarFechaSesion.ForeColor = System.Drawing.Color.White;
            this.btnCambiarFechaSesion.Image = ((System.Drawing.Image)(resources.GetObject("btnCambiarFechaSesion.Image")));
            this.btnCambiarFechaSesion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCambiarFechaSesion.Location = new System.Drawing.Point(0, 52);
            this.btnCambiarFechaSesion.Name = "btnCambiarFechaSesion";
            this.btnCambiarFechaSesion.Size = new System.Drawing.Size(141, 49);
            this.btnCambiarFechaSesion.TabIndex = 2;
            this.btnCambiarFechaSesion.Text = "Cambiar fecha \r\nde sesion";
            this.btnCambiarFechaSesion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCambiarFechaSesion.UseVisualStyleBackColor = true;
            // 
            // btnObservarAgendamiento
            // 
            this.btnObservarAgendamiento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnObservarAgendamiento.FlatAppearance.BorderSize = 0;
            this.btnObservarAgendamiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnObservarAgendamiento.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnObservarAgendamiento.ForeColor = System.Drawing.Color.White;
            this.btnObservarAgendamiento.Image = ((System.Drawing.Image)(resources.GetObject("btnObservarAgendamiento.Image")));
            this.btnObservarAgendamiento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnObservarAgendamiento.Location = new System.Drawing.Point(0, 104);
            this.btnObservarAgendamiento.Name = "btnObservarAgendamiento";
            this.btnObservarAgendamiento.Size = new System.Drawing.Size(141, 49);
            this.btnObservarAgendamiento.TabIndex = 3;
            this.btnObservarAgendamiento.Text = "Observar agendamientos";
            this.btnObservarAgendamiento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnObservarAgendamiento.UseVisualStyleBackColor = true;
            // 
            // btnAgendarSesion
            // 
            this.btnAgendarSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgendarSesion.FlatAppearance.BorderSize = 0;
            this.btnAgendarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgendarSesion.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgendarSesion.ForeColor = System.Drawing.Color.White;
            this.btnAgendarSesion.Image = ((System.Drawing.Image)(resources.GetObject("btnAgendarSesion.Image")));
            this.btnAgendarSesion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgendarSesion.Location = new System.Drawing.Point(1, 1);
            this.btnAgendarSesion.Name = "btnAgendarSesion";
            this.btnAgendarSesion.Size = new System.Drawing.Size(141, 49);
            this.btnAgendarSesion.TabIndex = 4;
            this.btnAgendarSesion.Text = "Agendar una\r\n sesión";
            this.btnAgendarSesion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgendarSesion.UseVisualStyleBackColor = true;
            // 
            // MenuSesiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(152)))), ((int)(((byte)(202)))));
            this.Controls.Add(this.btnAgendarSesion);
            this.Controls.Add(this.btnObservarAgendamiento);
            this.Controls.Add(this.btnCambiarFechaSesion);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MenuSesiones";
            this.Size = new System.Drawing.Size(141, 157);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Button btnCambiarFechaSesion;
        public System.Windows.Forms.Button btnObservarAgendamiento;
        public System.Windows.Forms.Button btnAgendarSesion;
    }
}
