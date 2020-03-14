namespace CapaPresentacionAdministracion.Formularios.FormsConfiguraciones.FormsTarifas
{
    partial class FrmConfiguracionTarifas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfiguracionTarifas));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTarifaSesion = new System.Windows.Forms.Button();
            this.tarifaSmallSesion = new CapaPresentacionAdministracion.Formularios.FormsTarifas.TarifaSmall();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tarifaSmallLectura = new CapaPresentacionAdministracion.Formularios.FormsTarifas.TarifaSmall();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTarifaLectura = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnTarifaSesion);
            this.groupBox1.Controls.Add(this.tarifaSmallSesion);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(464, 200);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tarifa predeterminada de sesión";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(439, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Seleccione una tarifa que esté previamente agregada en la base de datos";
            // 
            // btnTarifaSesion
            // 
            this.btnTarifaSesion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTarifaSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTarifaSesion.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnTarifaSesion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnTarifaSesion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnTarifaSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTarifaSesion.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTarifaSesion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnTarifaSesion.Image = ((System.Drawing.Image)(resources.GetObject("btnTarifaSesion.Image")));
            this.btnTarifaSesion.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTarifaSesion.Location = new System.Drawing.Point(6, 41);
            this.btnTarifaSesion.Name = "btnTarifaSesion";
            this.btnTarifaSesion.Size = new System.Drawing.Size(452, 42);
            this.btnTarifaSesion.TabIndex = 11;
            this.btnTarifaSesion.Text = "Seleccione una tarifa";
            this.btnTarifaSesion.UseVisualStyleBackColor = true;
            // 
            // tarifaSmallSesion
            // 
            this.tarifaSmallSesion.BackColor = System.Drawing.Color.White;
            this.tarifaSmallSesion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tarifaSmallSesion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tarifaSmallSesion.Location = new System.Drawing.Point(101, 38);
            this.tarifaSmallSesion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tarifaSmallSesion.Name = "tarifaSmallSesion";
            this.tarifaSmallSesion.Size = new System.Drawing.Size(272, 155);
            this.tarifaSmallSesion.TabIndex = 13;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tarifaSmallLectura);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnTarifaLectura);
            this.groupBox2.Location = new System.Drawing.Point(12, 212);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(464, 254);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tarifa predeterminada de lectura";
            // 
            // tarifaSmallLectura
            // 
            this.tarifaSmallLectura.BackColor = System.Drawing.Color.White;
            this.tarifaSmallLectura.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tarifaSmallLectura.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tarifaSmallLectura.Location = new System.Drawing.Point(101, 90);
            this.tarifaSmallLectura.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tarifaSmallLectura.Name = "tarifaSmallLectura";
            this.tarifaSmallLectura.Size = new System.Drawing.Size(272, 155);
            this.tarifaSmallLectura.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(439, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Seleccione una tarifa que esté previamente agregada en la base de datos";
            // 
            // btnTarifaLectura
            // 
            this.btnTarifaLectura.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTarifaLectura.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTarifaLectura.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnTarifaLectura.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnTarifaLectura.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnTarifaLectura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTarifaLectura.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTarifaLectura.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnTarifaLectura.Image = ((System.Drawing.Image)(resources.GetObject("btnTarifaLectura.Image")));
            this.btnTarifaLectura.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTarifaLectura.Location = new System.Drawing.Point(6, 41);
            this.btnTarifaLectura.Name = "btnTarifaLectura";
            this.btnTarifaLectura.Size = new System.Drawing.Size(452, 42);
            this.btnTarifaLectura.TabIndex = 11;
            this.btnTarifaLectura.Tag = "0";
            this.btnTarifaLectura.Text = "Seleccione una tarifa";
            this.btnTarifaLectura.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(172, 472);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(140, 56);
            this.btnGuardar.TabIndex = 17;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // FrmConfiguracionTarifas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(488, 540);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmConfiguracionTarifas";
            this.Text = "Configuración de tarifas";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTarifaSesion;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTarifaLectura;
        private Formularios.FormsTarifas.TarifaSmall tarifaSmallSesion;
        private Formularios.FormsTarifas.TarifaSmall tarifaSmallLectura;
        private System.Windows.Forms.Button btnGuardar;
    }
}