namespace CapaPresentacionAdministracion.Formularios.FormsCuentas
{
    partial class FrmTerminarCuenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTerminarCuenta));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtIdentificacion = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtCelular = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.tarifaSmall1 = new CapaPresentacionAdministracion.Formularios.FormsTarifas.TarifaSmall();
            this.lblDescuentos = new System.Windows.Forms.Label();
            this.lblIva = new System.Windows.Forms.Label();
            this.lblTotalPagar = new System.Windows.Forms.Label();
            this.btnTerminar = new System.Windows.Forms.Button();
            this.gbFacturacion = new System.Windows.Forms.GroupBox();
            this.rdNinguna = new System.Windows.Forms.RadioButton();
            this.rdImpresionDirecta = new System.Windows.Forms.RadioButton();
            this.rdVistaPrevia = new System.Windows.Forms.RadioButton();
            this.gbObservaciones = new System.Windows.Forms.GroupBox();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.btnObservarLectura = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbFacturacion.SuspendLayout();
            this.gbObservaciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(558, 135);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del cliente";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtCorreo);
            this.groupBox5.Location = new System.Drawing.Point(315, 75);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(237, 51);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Correo electrónico";
            // 
            // txtCorreo
            // 
            this.txtCorreo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCorreo.BackColor = System.Drawing.Color.White;
            this.txtCorreo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCorreo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCorreo.Location = new System.Drawing.Point(6, 21);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.ReadOnly = true;
            this.txtCorreo.Size = new System.Drawing.Size(225, 18);
            this.txtCorreo.TabIndex = 0;
            this.txtCorreo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtIdentificacion);
            this.groupBox4.Location = new System.Drawing.Point(151, 75);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(158, 51);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Identificación";
            // 
            // txtIdentificacion
            // 
            this.txtIdentificacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIdentificacion.BackColor = System.Drawing.Color.White;
            this.txtIdentificacion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIdentificacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtIdentificacion.Location = new System.Drawing.Point(6, 21);
            this.txtIdentificacion.Name = "txtIdentificacion";
            this.txtIdentificacion.ReadOnly = true;
            this.txtIdentificacion.Size = new System.Drawing.Size(146, 18);
            this.txtIdentificacion.TabIndex = 0;
            this.txtIdentificacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtCelular);
            this.groupBox3.Location = new System.Drawing.Point(6, 75);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(139, 51);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Celular";
            // 
            // txtCelular
            // 
            this.txtCelular.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCelular.BackColor = System.Drawing.Color.White;
            this.txtCelular.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCelular.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCelular.Location = new System.Drawing.Point(6, 21);
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.ReadOnly = true;
            this.txtCelular.Size = new System.Drawing.Size(127, 18);
            this.txtCelular.TabIndex = 0;
            this.txtCelular.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtNombre);
            this.groupBox2.Location = new System.Drawing.Point(6, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(546, 51);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombre.BackColor = System.Drawing.Color.White;
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtNombre.Location = new System.Drawing.Point(6, 21);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(534, 18);
            this.txtNombre.TabIndex = 0;
            this.txtNombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tarifaSmall1
            // 
            this.tarifaSmall1.BackColor = System.Drawing.Color.White;
            this.tarifaSmall1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tarifaSmall1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tarifaSmall1.Location = new System.Drawing.Point(126, 154);
            this.tarifaSmall1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tarifaSmall1.Name = "tarifaSmall1";
            this.tarifaSmall1.Size = new System.Drawing.Size(272, 155);
            this.tarifaSmall1.TabIndex = 3;
            // 
            // lblDescuentos
            // 
            this.lblDescuentos.AutoSize = true;
            this.lblDescuentos.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescuentos.Location = new System.Drawing.Point(17, 310);
            this.lblDescuentos.Name = "lblDescuentos";
            this.lblDescuentos.Size = new System.Drawing.Size(78, 17);
            this.lblDescuentos.TabIndex = 4;
            this.lblDescuentos.Text = "Descuentos:";
            // 
            // lblIva
            // 
            this.lblIva.AutoSize = true;
            this.lblIva.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIva.Location = new System.Drawing.Point(18, 346);
            this.lblIva.Name = "lblIva";
            this.lblIva.Size = new System.Drawing.Size(36, 21);
            this.lblIva.TabIndex = 5;
            this.lblIva.Text = "IVA:";
            // 
            // lblTotalPagar
            // 
            this.lblTotalPagar.AutoSize = true;
            this.lblTotalPagar.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPagar.Location = new System.Drawing.Point(199, 340);
            this.lblTotalPagar.Name = "lblTotalPagar";
            this.lblTotalPagar.Size = new System.Drawing.Size(138, 30);
            this.lblTotalPagar.TabIndex = 6;
            this.lblTotalPagar.Text = "Total a pagar:";
            // 
            // btnTerminar
            // 
            this.btnTerminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(236)))), ((int)(((byte)(191)))));
            this.btnTerminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTerminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(236)))), ((int)(((byte)(191)))));
            this.btnTerminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnTerminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnTerminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTerminar.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTerminar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnTerminar.Image = ((System.Drawing.Image)(resources.GetObject("btnTerminar.Image")));
            this.btnTerminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTerminar.Location = new System.Drawing.Point(193, 431);
            this.btnTerminar.Name = "btnTerminar";
            this.btnTerminar.Size = new System.Drawing.Size(167, 73);
            this.btnTerminar.TabIndex = 8;
            this.btnTerminar.Text = "Terminar y \r\nfacturar";
            this.btnTerminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTerminar.UseVisualStyleBackColor = false;
            // 
            // gbFacturacion
            // 
            this.gbFacturacion.Controls.Add(this.rdNinguna);
            this.gbFacturacion.Controls.Add(this.rdImpresionDirecta);
            this.gbFacturacion.Controls.Add(this.rdVistaPrevia);
            this.gbFacturacion.Location = new System.Drawing.Point(12, 396);
            this.gbFacturacion.Name = "gbFacturacion";
            this.gbFacturacion.Size = new System.Drawing.Size(145, 108);
            this.gbFacturacion.TabIndex = 9;
            this.gbFacturacion.TabStop = false;
            this.gbFacturacion.Text = "Facturación";
            // 
            // rdNinguna
            // 
            this.rdNinguna.AutoSize = true;
            this.rdNinguna.Location = new System.Drawing.Point(6, 78);
            this.rdNinguna.Name = "rdNinguna";
            this.rdNinguna.Size = new System.Drawing.Size(75, 21);
            this.rdNinguna.TabIndex = 2;
            this.rdNinguna.Text = "Ninguna";
            this.rdNinguna.UseVisualStyleBackColor = true;
            // 
            // rdImpresionDirecta
            // 
            this.rdImpresionDirecta.AutoSize = true;
            this.rdImpresionDirecta.Checked = true;
            this.rdImpresionDirecta.Location = new System.Drawing.Point(6, 51);
            this.rdImpresionDirecta.Name = "rdImpresionDirecta";
            this.rdImpresionDirecta.Size = new System.Drawing.Size(128, 21);
            this.rdImpresionDirecta.TabIndex = 1;
            this.rdImpresionDirecta.TabStop = true;
            this.rdImpresionDirecta.Text = "Impresión directa";
            this.rdImpresionDirecta.UseVisualStyleBackColor = true;
            // 
            // rdVistaPrevia
            // 
            this.rdVistaPrevia.AutoSize = true;
            this.rdVistaPrevia.Location = new System.Drawing.Point(6, 24);
            this.rdVistaPrevia.Name = "rdVistaPrevia";
            this.rdVistaPrevia.Size = new System.Drawing.Size(94, 21);
            this.rdVistaPrevia.TabIndex = 0;
            this.rdVistaPrevia.Text = "Vista previa";
            this.rdVistaPrevia.UseVisualStyleBackColor = true;
            // 
            // gbObservaciones
            // 
            this.gbObservaciones.Controls.Add(this.txtObservaciones);
            this.gbObservaciones.Location = new System.Drawing.Point(384, 405);
            this.gbObservaciones.Name = "gbObservaciones";
            this.gbObservaciones.Size = new System.Drawing.Size(186, 76);
            this.gbObservaciones.TabIndex = 10;
            this.gbObservaciones.TabStop = false;
            this.gbObservaciones.Text = "Observaciones";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObservaciones.BackColor = System.Drawing.Color.White;
            this.txtObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObservaciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtObservaciones.Location = new System.Drawing.Point(6, 21);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservaciones.Size = new System.Drawing.Size(174, 49);
            this.txtObservaciones.TabIndex = 0;
            this.txtObservaciones.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnObservarLectura
            // 
            this.btnObservarLectura.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(236)))), ((int)(((byte)(191)))));
            this.btnObservarLectura.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnObservarLectura.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(236)))), ((int)(((byte)(191)))));
            this.btnObservarLectura.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnObservarLectura.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnObservarLectura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnObservarLectura.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnObservarLectura.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnObservarLectura.Image = ((System.Drawing.Image)(resources.GetObject("btnObservarLectura.Image")));
            this.btnObservarLectura.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnObservarLectura.Location = new System.Drawing.Point(404, 154);
            this.btnObservarLectura.Name = "btnObservarLectura";
            this.btnObservarLectura.Size = new System.Drawing.Size(151, 36);
            this.btnObservarLectura.TabIndex = 11;
            this.btnObservarLectura.Text = "Observar lectura";
            this.btnObservarLectura.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnObservarLectura.UseVisualStyleBackColor = false;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(236)))), ((int)(((byte)(191)))));
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(236)))), ((int)(((byte)(191)))));
            this.btnImprimir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnImprimir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.Location = new System.Drawing.Point(193, 387);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(167, 38);
            this.btnImprimir.TabIndex = 12;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.UseVisualStyleBackColor = false;
            // 
            // FrmTerminarCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(581, 516);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnObservarLectura);
            this.Controls.Add(this.gbObservaciones);
            this.Controls.Add(this.gbFacturacion);
            this.Controls.Add(this.btnTerminar);
            this.Controls.Add(this.lblTotalPagar);
            this.Controls.Add(this.lblIva);
            this.Controls.Add(this.lblDescuentos);
            this.Controls.Add(this.tarifaSmall1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTerminarCuenta";
            this.Text = "Pagar una cuenta pendiente";
            this.groupBox1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbFacturacion.ResumeLayout(false);
            this.gbFacturacion.PerformLayout();
            this.gbObservaciones.ResumeLayout(false);
            this.gbObservaciones.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtCelular;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtIdentificacion;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtCorreo;
        private FormsTarifas.TarifaSmall tarifaSmall1;
        private System.Windows.Forms.Label lblDescuentos;
        private System.Windows.Forms.Label lblIva;
        private System.Windows.Forms.Label lblTotalPagar;
        private System.Windows.Forms.Button btnTerminar;
        private System.Windows.Forms.GroupBox gbFacturacion;
        private System.Windows.Forms.GroupBox gbObservaciones;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Button btnObservarLectura;
        private System.Windows.Forms.RadioButton rdNinguna;
        private System.Windows.Forms.RadioButton rdImpresionDirecta;
        private System.Windows.Forms.RadioButton rdVistaPrevia;
        private System.Windows.Forms.Button btnImprimir;
    }
}