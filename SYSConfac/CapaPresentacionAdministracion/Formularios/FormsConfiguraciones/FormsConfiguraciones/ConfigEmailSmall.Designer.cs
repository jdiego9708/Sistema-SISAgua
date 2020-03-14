namespace CapaPresentacionAdministracion.Formularios.FormsConfiguraciones.FormsConfiguraciones
{
    partial class ConfigEmailSmall
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigEmailSmall));
            this.gbCorreo = new System.Windows.Forms.GroupBox();
            this.gbContraseña = new System.Windows.Forms.GroupBox();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.btnPrueba = new System.Windows.Forms.Button();
            this.gbCorreoRecepcion = new System.Windows.Forms.GroupBox();
            this.txtCorreoRecepcion = new System.Windows.Forms.TextBox();
            this.gbPuerto = new System.Windows.Forms.GroupBox();
            this.txtPuerto = new System.Windows.Forms.TextBox();
            this.gbServidorSMTP = new System.Windows.Forms.GroupBox();
            this.txtServidorSMTP = new System.Windows.Forms.TextBox();
            this.gbCorreoEnvio = new System.Windows.Forms.GroupBox();
            this.txtCorreoEnvio = new System.Windows.Forms.TextBox();
            this.btnAyudaCorreo = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbCorreo.SuspendLayout();
            this.gbContraseña.SuspendLayout();
            this.gbCorreoRecepcion.SuspendLayout();
            this.gbPuerto.SuspendLayout();
            this.gbServidorSMTP.SuspendLayout();
            this.gbCorreoEnvio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbCorreo
            // 
            this.gbCorreo.Controls.Add(this.gbContraseña);
            this.gbCorreo.Controls.Add(this.btnPrueba);
            this.gbCorreo.Controls.Add(this.gbCorreoRecepcion);
            this.gbCorreo.Controls.Add(this.gbPuerto);
            this.gbCorreo.Controls.Add(this.gbServidorSMTP);
            this.gbCorreo.Controls.Add(this.gbCorreoEnvio);
            this.gbCorreo.Controls.Add(this.btnAyudaCorreo);
            this.gbCorreo.Location = new System.Drawing.Point(3, 3);
            this.gbCorreo.Name = "gbCorreo";
            this.gbCorreo.Size = new System.Drawing.Size(598, 136);
            this.gbCorreo.TabIndex = 8;
            this.gbCorreo.TabStop = false;
            this.gbCorreo.Text = "Envío de correo de errores*";
            // 
            // gbContraseña
            // 
            this.gbContraseña.Controls.Add(this.txtContraseña);
            this.gbContraseña.Location = new System.Drawing.Point(309, 19);
            this.gbContraseña.Name = "gbContraseña";
            this.gbContraseña.Size = new System.Drawing.Size(178, 52);
            this.gbContraseña.TabIndex = 13;
            this.gbContraseña.TabStop = false;
            this.gbContraseña.Text = "Contraseña*";
            // 
            // txtContraseña
            // 
            this.txtContraseña.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContraseña.BackColor = System.Drawing.Color.White;
            this.txtContraseña.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtContraseña.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContraseña.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtContraseña.Location = new System.Drawing.Point(6, 20);
            this.txtContraseña.MaxLength = 15;
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.PasswordChar = '*';
            this.txtContraseña.Size = new System.Drawing.Size(150, 20);
            this.txtContraseña.TabIndex = 2;
            this.txtContraseña.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtContraseña.UseSystemPasswordChar = true;
            // 
            // btnPrueba
            // 
            this.btnPrueba.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPrueba.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrueba.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPrueba.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPrueba.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPrueba.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrueba.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrueba.Image = ((System.Drawing.Image)(resources.GetObject("btnPrueba.Image")));
            this.btnPrueba.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPrueba.Location = new System.Drawing.Point(524, 19);
            this.btnPrueba.Name = "btnPrueba";
            this.btnPrueba.Size = new System.Drawing.Size(65, 68);
            this.btnPrueba.TabIndex = 11;
            this.btnPrueba.Text = "Prueba de envío";
            this.btnPrueba.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPrueba.UseVisualStyleBackColor = false;
            // 
            // gbCorreoRecepcion
            // 
            this.gbCorreoRecepcion.Controls.Add(this.txtCorreoRecepcion);
            this.gbCorreoRecepcion.Location = new System.Drawing.Point(9, 74);
            this.gbCorreoRecepcion.Name = "gbCorreoRecepcion";
            this.gbCorreoRecepcion.Size = new System.Drawing.Size(294, 52);
            this.gbCorreoRecepcion.TabIndex = 10;
            this.gbCorreoRecepcion.TabStop = false;
            this.gbCorreoRecepcion.Text = "Correo electrónico de recepción*";
            // 
            // txtCorreoRecepcion
            // 
            this.txtCorreoRecepcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCorreoRecepcion.BackColor = System.Drawing.Color.White;
            this.txtCorreoRecepcion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCorreoRecepcion.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorreoRecepcion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCorreoRecepcion.Location = new System.Drawing.Point(6, 22);
            this.txtCorreoRecepcion.MaxLength = 50;
            this.txtCorreoRecepcion.Name = "txtCorreoRecepcion";
            this.txtCorreoRecepcion.Size = new System.Drawing.Size(262, 18);
            this.txtCorreoRecepcion.TabIndex = 2;
            this.txtCorreoRecepcion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gbPuerto
            // 
            this.gbPuerto.Controls.Add(this.txtPuerto);
            this.gbPuerto.Location = new System.Drawing.Point(441, 74);
            this.gbPuerto.Name = "gbPuerto";
            this.gbPuerto.Size = new System.Drawing.Size(66, 52);
            this.gbPuerto.TabIndex = 9;
            this.gbPuerto.TabStop = false;
            this.gbPuerto.Text = "Puerto*";
            // 
            // txtPuerto
            // 
            this.txtPuerto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPuerto.BackColor = System.Drawing.Color.White;
            this.txtPuerto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPuerto.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPuerto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPuerto.Location = new System.Drawing.Point(6, 20);
            this.txtPuerto.MaxLength = 4;
            this.txtPuerto.Name = "txtPuerto";
            this.txtPuerto.Size = new System.Drawing.Size(40, 20);
            this.txtPuerto.TabIndex = 2;
            this.txtPuerto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gbServidorSMTP
            // 
            this.gbServidorSMTP.Controls.Add(this.txtServidorSMTP);
            this.gbServidorSMTP.Location = new System.Drawing.Point(309, 74);
            this.gbServidorSMTP.Name = "gbServidorSMTP";
            this.gbServidorSMTP.Size = new System.Drawing.Size(126, 52);
            this.gbServidorSMTP.TabIndex = 8;
            this.gbServidorSMTP.TabStop = false;
            this.gbServidorSMTP.Text = "Servidor SMTP*";
            // 
            // txtServidorSMTP
            // 
            this.txtServidorSMTP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServidorSMTP.BackColor = System.Drawing.Color.White;
            this.txtServidorSMTP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtServidorSMTP.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServidorSMTP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtServidorSMTP.Location = new System.Drawing.Point(6, 23);
            this.txtServidorSMTP.MaxLength = 15;
            this.txtServidorSMTP.Name = "txtServidorSMTP";
            this.txtServidorSMTP.Size = new System.Drawing.Size(102, 18);
            this.txtServidorSMTP.TabIndex = 2;
            this.txtServidorSMTP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gbCorreoEnvio
            // 
            this.gbCorreoEnvio.Controls.Add(this.txtCorreoEnvio);
            this.gbCorreoEnvio.Location = new System.Drawing.Point(9, 19);
            this.gbCorreoEnvio.Name = "gbCorreoEnvio";
            this.gbCorreoEnvio.Size = new System.Drawing.Size(294, 52);
            this.gbCorreoEnvio.TabIndex = 7;
            this.gbCorreoEnvio.TabStop = false;
            this.gbCorreoEnvio.Text = "Correo electrónico de envío*";
            // 
            // txtCorreoEnvio
            // 
            this.txtCorreoEnvio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCorreoEnvio.BackColor = System.Drawing.Color.White;
            this.txtCorreoEnvio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCorreoEnvio.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorreoEnvio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCorreoEnvio.Location = new System.Drawing.Point(6, 22);
            this.txtCorreoEnvio.MaxLength = 50;
            this.txtCorreoEnvio.Name = "txtCorreoEnvio";
            this.txtCorreoEnvio.Size = new System.Drawing.Size(262, 18);
            this.txtCorreoEnvio.TabIndex = 2;
            this.txtCorreoEnvio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnAyudaCorreo
            // 
            this.btnAyudaCorreo.BackColor = System.Drawing.Color.Transparent;
            this.btnAyudaCorreo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAyudaCorreo.BackgroundImage")));
            this.btnAyudaCorreo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAyudaCorreo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAyudaCorreo.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAyudaCorreo.FlatAppearance.BorderSize = 0;
            this.btnAyudaCorreo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAyudaCorreo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnAyudaCorreo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAyudaCorreo.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAyudaCorreo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAyudaCorreo.Location = new System.Drawing.Point(493, 37);
            this.btnAyudaCorreo.Name = "btnAyudaCorreo";
            this.btnAyudaCorreo.Size = new System.Drawing.Size(25, 25);
            this.btnAyudaCorreo.TabIndex = 6;
            this.btnAyudaCorreo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAyudaCorreo.UseVisualStyleBackColor = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ConfigEmailSmall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbCorreo);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ConfigEmailSmall";
            this.Size = new System.Drawing.Size(612, 144);
            this.gbCorreo.ResumeLayout(false);
            this.gbContraseña.ResumeLayout(false);
            this.gbContraseña.PerformLayout();
            this.gbCorreoRecepcion.ResumeLayout(false);
            this.gbCorreoRecepcion.PerformLayout();
            this.gbPuerto.ResumeLayout(false);
            this.gbPuerto.PerformLayout();
            this.gbServidorSMTP.ResumeLayout(false);
            this.gbServidorSMTP.PerformLayout();
            this.gbCorreoEnvio.ResumeLayout(false);
            this.gbCorreoEnvio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCorreo;
        private System.Windows.Forms.Button btnPrueba;
        private System.Windows.Forms.GroupBox gbCorreoRecepcion;
        private System.Windows.Forms.GroupBox gbPuerto;
        private System.Windows.Forms.GroupBox gbServidorSMTP;
        private System.Windows.Forms.GroupBox gbCorreoEnvio;
        private System.Windows.Forms.Button btnAyudaCorreo;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox gbContraseña;
        public System.Windows.Forms.TextBox txtCorreoRecepcion;
        public System.Windows.Forms.TextBox txtPuerto;
        public System.Windows.Forms.TextBox txtServidorSMTP;
        public System.Windows.Forms.TextBox txtCorreoEnvio;
        public System.Windows.Forms.TextBox txtContraseña;
    }
}
