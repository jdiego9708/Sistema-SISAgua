namespace CapaPresentacionAdministracion.Formularios.FormsTarifas
{
    partial class FrmAgregarTarifa
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAgregarTarifa));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.gbValorBase = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtValorBase = new System.Windows.Forms.TextBox();
            this.gbConsumoMinimo = new System.Windows.Forms.GroupBox();
            this.txtConsumoMinimo = new System.Windows.Forms.TextBox();
            this.gbConsumoMaximo = new System.Windows.Forms.GroupBox();
            this.txtConsumoMaximo = new System.Windows.Forms.TextBox();
            this.gbMedida = new System.Windows.Forms.GroupBox();
            this.btnMedida = new System.Windows.Forms.Button();
            this.gbCostoExcedente = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCostoExcedente = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.rdTarifaUnica = new System.Windows.Forms.RadioButton();
            this.rdTarifaDetallada = new System.Windows.Forms.RadioButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox2.SuspendLayout();
            this.gbValorBase.SuspendLayout();
            this.gbConsumoMinimo.SuspendLayout();
            this.gbConsumoMaximo.SuspendLayout();
            this.gbMedida.SuspendLayout();
            this.gbCostoExcedente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDescripcion);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(328, 59);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Descripción tarifa";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescripcion.BackColor = System.Drawing.Color.White;
            this.txtDescripcion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtDescripcion.Location = new System.Drawing.Point(6, 24);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(316, 25);
            this.txtDescripcion.TabIndex = 0;
            this.txtDescripcion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gbValorBase
            // 
            this.gbValorBase.Controls.Add(this.label1);
            this.gbValorBase.Controls.Add(this.txtValorBase);
            this.gbValorBase.Location = new System.Drawing.Point(12, 199);
            this.gbValorBase.Name = "gbValorBase";
            this.gbValorBase.Size = new System.Drawing.Size(160, 59);
            this.gbValorBase.TabIndex = 2;
            this.gbValorBase.TabStop = false;
            this.gbValorBase.Text = "Valor base";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "US$";
            // 
            // txtValorBase
            // 
            this.txtValorBase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValorBase.BackColor = System.Drawing.Color.White;
            this.txtValorBase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtValorBase.Location = new System.Drawing.Point(45, 24);
            this.txtValorBase.Name = "txtValorBase";
            this.txtValorBase.Size = new System.Drawing.Size(70, 25);
            this.txtValorBase.TabIndex = 0;
            this.txtValorBase.Text = "0";
            this.txtValorBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gbConsumoMinimo
            // 
            this.gbConsumoMinimo.Controls.Add(this.txtConsumoMinimo);
            this.gbConsumoMinimo.Location = new System.Drawing.Point(12, 134);
            this.gbConsumoMinimo.Name = "gbConsumoMinimo";
            this.gbConsumoMinimo.Size = new System.Drawing.Size(160, 59);
            this.gbConsumoMinimo.TabIndex = 3;
            this.gbConsumoMinimo.TabStop = false;
            this.gbConsumoMinimo.Text = "Consumo mínimo base";
            // 
            // txtConsumoMinimo
            // 
            this.txtConsumoMinimo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConsumoMinimo.BackColor = System.Drawing.Color.White;
            this.txtConsumoMinimo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtConsumoMinimo.Location = new System.Drawing.Point(45, 24);
            this.txtConsumoMinimo.Name = "txtConsumoMinimo";
            this.txtConsumoMinimo.Size = new System.Drawing.Size(70, 25);
            this.txtConsumoMinimo.TabIndex = 0;
            this.txtConsumoMinimo.Text = "0";
            this.txtConsumoMinimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gbConsumoMaximo
            // 
            this.gbConsumoMaximo.Controls.Add(this.txtConsumoMaximo);
            this.gbConsumoMaximo.Location = new System.Drawing.Point(178, 134);
            this.gbConsumoMaximo.Name = "gbConsumoMaximo";
            this.gbConsumoMaximo.Size = new System.Drawing.Size(162, 59);
            this.gbConsumoMaximo.TabIndex = 3;
            this.gbConsumoMaximo.TabStop = false;
            this.gbConsumoMaximo.Text = "Consumo máximo base";
            // 
            // txtConsumoMaximo
            // 
            this.txtConsumoMaximo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConsumoMaximo.BackColor = System.Drawing.Color.White;
            this.txtConsumoMaximo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtConsumoMaximo.Location = new System.Drawing.Point(44, 24);
            this.txtConsumoMaximo.Name = "txtConsumoMaximo";
            this.txtConsumoMaximo.Size = new System.Drawing.Size(69, 25);
            this.txtConsumoMaximo.TabIndex = 0;
            this.txtConsumoMaximo.Text = "0";
            this.txtConsumoMaximo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gbMedida
            // 
            this.gbMedida.Controls.Add(this.btnMedida);
            this.gbMedida.Location = new System.Drawing.Point(178, 199);
            this.gbMedida.Name = "gbMedida";
            this.gbMedida.Size = new System.Drawing.Size(160, 67);
            this.gbMedida.TabIndex = 3;
            this.gbMedida.TabStop = false;
            this.gbMedida.Text = "Medida";
            // 
            // btnMedida
            // 
            this.btnMedida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(209)))), ((int)(((byte)(218)))));
            this.btnMedida.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMedida.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(209)))), ((int)(((byte)(218)))));
            this.btnMedida.FlatAppearance.BorderSize = 0;
            this.btnMedida.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(209)))), ((int)(((byte)(218)))));
            this.btnMedida.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(218)))), ((int)(((byte)(236)))));
            this.btnMedida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMedida.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMedida.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMedida.Image = ((System.Drawing.Image)(resources.GetObject("btnMedida.Image")));
            this.btnMedida.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMedida.Location = new System.Drawing.Point(9, 20);
            this.btnMedida.Name = "btnMedida";
            this.btnMedida.Size = new System.Drawing.Size(107, 39);
            this.btnMedida.TabIndex = 0;
            this.btnMedida.Text = "Seleccionar medida";
            this.btnMedida.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMedida.UseVisualStyleBackColor = false;
            // 
            // gbCostoExcedente
            // 
            this.gbCostoExcedente.Controls.Add(this.label2);
            this.gbCostoExcedente.Controls.Add(this.txtCostoExcedente);
            this.gbCostoExcedente.Location = new System.Drawing.Point(12, 264);
            this.gbCostoExcedente.Name = "gbCostoExcedente";
            this.gbCostoExcedente.Size = new System.Drawing.Size(160, 59);
            this.gbCostoExcedente.TabIndex = 3;
            this.gbCostoExcedente.TabStop = false;
            this.gbCostoExcedente.Text = "Costo excedente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "US$";
            // 
            // txtCostoExcedente
            // 
            this.txtCostoExcedente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCostoExcedente.BackColor = System.Drawing.Color.White;
            this.txtCostoExcedente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCostoExcedente.Location = new System.Drawing.Point(45, 24);
            this.txtCostoExcedente.Name = "txtCostoExcedente";
            this.txtCostoExcedente.Size = new System.Drawing.Size(70, 25);
            this.txtCostoExcedente.TabIndex = 0;
            this.txtCostoExcedente.Text = "0";
            this.txtCostoExcedente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.btnGuardar.Location = new System.Drawing.Point(117, 329);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(117, 41);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.rdTarifaUnica);
            this.groupBox7.Controls.Add(this.rdTarifaDetallada);
            this.groupBox7.Location = new System.Drawing.Point(12, 78);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(328, 50);
            this.groupBox7.TabIndex = 8;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Tipo";
            // 
            // rdTarifaUnica
            // 
            this.rdTarifaUnica.AutoSize = true;
            this.rdTarifaUnica.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdTarifaUnica.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdTarifaUnica.Location = new System.Drawing.Point(198, 20);
            this.rdTarifaUnica.Name = "rdTarifaUnica";
            this.rdTarifaUnica.Size = new System.Drawing.Size(102, 24);
            this.rdTarifaUnica.TabIndex = 1;
            this.rdTarifaUnica.TabStop = true;
            this.rdTarifaUnica.Text = "Tarifa única";
            this.toolTip1.SetToolTip(this.rdTarifaUnica, "Tipo de tarifa que tienen un único valor");
            this.rdTarifaUnica.UseVisualStyleBackColor = true;
            // 
            // rdTarifaDetallada
            // 
            this.rdTarifaDetallada.AutoSize = true;
            this.rdTarifaDetallada.Checked = true;
            this.rdTarifaDetallada.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdTarifaDetallada.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdTarifaDetallada.Location = new System.Drawing.Point(7, 20);
            this.rdTarifaDetallada.Name = "rdTarifaDetallada";
            this.rdTarifaDetallada.Size = new System.Drawing.Size(130, 24);
            this.rdTarifaDetallada.TabIndex = 0;
            this.rdTarifaDetallada.TabStop = true;
            this.rdTarifaDetallada.Text = "Tarifa detallada";
            this.toolTip1.SetToolTip(this.rdTarifaDetallada, "Tipo de tarifa que tiene los datos de consumo mínimo, máximo y costo excedente");
            this.rdTarifaDetallada.UseVisualStyleBackColor = true;
            // 
            // FrmAgregarTarifa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(346, 384);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.gbCostoExcedente);
            this.Controls.Add(this.gbMedida);
            this.Controls.Add(this.gbConsumoMaximo);
            this.Controls.Add(this.gbConsumoMinimo);
            this.Controls.Add(this.gbValorBase);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FrmAgregarTarifa";
            this.Text = "Agregar una tarifa";
            this.toolTip1.SetToolTip(this, "0");
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbValorBase.ResumeLayout(false);
            this.gbValorBase.PerformLayout();
            this.gbConsumoMinimo.ResumeLayout(false);
            this.gbConsumoMinimo.PerformLayout();
            this.gbConsumoMaximo.ResumeLayout(false);
            this.gbConsumoMaximo.PerformLayout();
            this.gbMedida.ResumeLayout(false);
            this.gbCostoExcedente.ResumeLayout(false);
            this.gbCostoExcedente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.GroupBox gbValorBase;
        private System.Windows.Forms.GroupBox gbConsumoMinimo;
        private System.Windows.Forms.TextBox txtConsumoMinimo;
        private System.Windows.Forms.GroupBox gbConsumoMaximo;
        private System.Windows.Forms.TextBox txtConsumoMaximo;
        private System.Windows.Forms.TextBox txtValorBase;
        private System.Windows.Forms.GroupBox gbMedida;
        private System.Windows.Forms.GroupBox gbCostoExcedente;
        private System.Windows.Forms.TextBox txtCostoExcedente;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.RadioButton rdTarifaDetallada;
        private System.Windows.Forms.RadioButton rdTarifaUnica;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnMedida;
    }
}