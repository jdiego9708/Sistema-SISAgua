namespace CapaPresentacionAdministracion.Formularios.FormsGastos
{
    partial class FrmAgregarHistorialGasto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAgregarHistorialGasto));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSeleccionarTipoGasto = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtFechaHora = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtValorHistorialGasto = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.gbFacturacion = new System.Windows.Forms.GroupBox();
            this.rdNinguna = new System.Windows.Forms.RadioButton();
            this.rdImpresionDirecta = new System.Windows.Forms.RadioButton();
            this.rdVistaPrevia = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbFacturacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSeleccionarTipoGasto);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(434, 64);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Concepto";
            // 
            // btnSeleccionarTipoGasto
            // 
            this.btnSeleccionarTipoGasto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(209)))), ((int)(((byte)(218)))));
            this.btnSeleccionarTipoGasto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeleccionarTipoGasto.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(209)))), ((int)(((byte)(218)))));
            this.btnSeleccionarTipoGasto.FlatAppearance.BorderSize = 0;
            this.btnSeleccionarTipoGasto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(209)))), ((int)(((byte)(218)))));
            this.btnSeleccionarTipoGasto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(218)))), ((int)(((byte)(236)))));
            this.btnSeleccionarTipoGasto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionarTipoGasto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionarTipoGasto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSeleccionarTipoGasto.Image = ((System.Drawing.Image)(resources.GetObject("btnSeleccionarTipoGasto.Image")));
            this.btnSeleccionarTipoGasto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeleccionarTipoGasto.Location = new System.Drawing.Point(6, 19);
            this.btnSeleccionarTipoGasto.Name = "btnSeleccionarTipoGasto";
            this.btnSeleccionarTipoGasto.Size = new System.Drawing.Size(422, 39);
            this.btnSeleccionarTipoGasto.TabIndex = 1;
            this.btnSeleccionarTipoGasto.Text = "Seleccionar tipo de gasto";
            this.btnSeleccionarTipoGasto.UseVisualStyleBackColor = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtFechaHora);
            this.groupBox2.Location = new System.Drawing.Point(12, 82);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(434, 59);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fecha y hora";
            // 
            // txtFechaHora
            // 
            this.txtFechaHora.BackColor = System.Drawing.Color.White;
            this.txtFechaHora.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFechaHora.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFechaHora.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaHora.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtFechaHora.Location = new System.Drawing.Point(6, 25);
            this.txtFechaHora.MaxLength = 50;
            this.txtFechaHora.Name = "txtFechaHora";
            this.txtFechaHora.ReadOnly = true;
            this.txtFechaHora.Size = new System.Drawing.Size(422, 20);
            this.txtFechaHora.TabIndex = 0;
            this.txtFechaHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtValorHistorialGasto);
            this.groupBox3.Location = new System.Drawing.Point(221, 147);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(225, 73);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Valor";
            // 
            // txtValorHistorialGasto
            // 
            this.txtValorHistorialGasto.BackColor = System.Drawing.Color.White;
            this.txtValorHistorialGasto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtValorHistorialGasto.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorHistorialGasto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtValorHistorialGasto.Location = new System.Drawing.Point(39, 22);
            this.txtValorHistorialGasto.MaxLength = 50;
            this.txtValorHistorialGasto.Name = "txtValorHistorialGasto";
            this.txtValorHistorialGasto.Size = new System.Drawing.Size(135, 39);
            this.txtValorHistorialGasto.TabIndex = 0;
            this.txtValorHistorialGasto.Tag = "0";
            this.txtValorHistorialGasto.Text = "0";
            this.txtValorHistorialGasto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(260, 226);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(117, 41);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // gbFacturacion
            // 
            this.gbFacturacion.Controls.Add(this.rdNinguna);
            this.gbFacturacion.Controls.Add(this.rdImpresionDirecta);
            this.gbFacturacion.Controls.Add(this.rdVistaPrevia);
            this.gbFacturacion.Location = new System.Drawing.Point(12, 147);
            this.gbFacturacion.Name = "gbFacturacion";
            this.gbFacturacion.Size = new System.Drawing.Size(145, 108);
            this.gbFacturacion.TabIndex = 19;
            this.gbFacturacion.TabStop = false;
            this.gbFacturacion.Text = "Impresión";
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
            // FrmAgregarHistorialGasto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(458, 279);
            this.Controls.Add(this.gbFacturacion);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAgregarHistorialGasto";
            this.Text = "Nuevo gasto";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gbFacturacion.ResumeLayout(false);
            this.gbFacturacion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSeleccionarTipoGasto;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtFechaHora;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtValorHistorialGasto;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.GroupBox gbFacturacion;
        private System.Windows.Forms.RadioButton rdNinguna;
        private System.Windows.Forms.RadioButton rdImpresionDirecta;
        private System.Windows.Forms.RadioButton rdVistaPrevia;
    }
}