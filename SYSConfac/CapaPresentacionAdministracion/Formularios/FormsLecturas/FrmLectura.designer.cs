namespace CapaPresentacionAdministracion.Formularios.FormsLecturas
{
    partial class FrmLectura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLectura));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtLecturaAnterior = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtLecturaActual = new System.Windows.Forms.TextBox();
            this.gbMedida = new System.Windows.Forms.GroupBox();
            this.txtMedida = new System.Windows.Forms.TextBox();
            this.gbProximaLectura = new System.Windows.Forms.GroupBox();
            this.txtFechaProximaLectura = new System.Windows.Forms.TextBox();
            this.btnTerminar = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtMes = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.chkImprimir = new System.Windows.Forms.CheckBox();
            this.calculadoraExcedentes1 = new CapaPresentacionAdministracion.Formularios.FormsExcedentes.CalculadoraExcedentes();
            this.lblRespuesta = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbMedida.SuspendLayout();
            this.gbProximaLectura.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCliente);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(541, 55);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cliente";
            // 
            // txtCliente
            // 
            this.txtCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCliente.BackColor = System.Drawing.Color.White;
            this.txtCliente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCliente.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCliente.Location = new System.Drawing.Point(6, 24);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(529, 22);
            this.txtCliente.TabIndex = 0;
            this.txtCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtLecturaAnterior);
            this.groupBox2.Location = new System.Drawing.Point(12, 73);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(126, 55);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lectura anterior";
            // 
            // txtLecturaAnterior
            // 
            this.txtLecturaAnterior.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLecturaAnterior.BackColor = System.Drawing.Color.White;
            this.txtLecturaAnterior.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLecturaAnterior.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLecturaAnterior.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtLecturaAnterior.Location = new System.Drawing.Point(6, 24);
            this.txtLecturaAnterior.MaxLength = 10;
            this.txtLecturaAnterior.Name = "txtLecturaAnterior";
            this.txtLecturaAnterior.Size = new System.Drawing.Size(93, 22);
            this.txtLecturaAnterior.TabIndex = 0;
            this.txtLecturaAnterior.Text = "0";
            this.txtLecturaAnterior.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnRefresh);
            this.groupBox3.Controls.Add(this.txtLecturaActual);
            this.groupBox3.Location = new System.Drawing.Point(144, 73);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(126, 55);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Lectura actual";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRefresh.BackgroundImage")));
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(93, 22);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(27, 25);
            this.btnRefresh.TabIndex = 12;
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // txtLecturaActual
            // 
            this.txtLecturaActual.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLecturaActual.BackColor = System.Drawing.Color.White;
            this.txtLecturaActual.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLecturaActual.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLecturaActual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtLecturaActual.Location = new System.Drawing.Point(6, 24);
            this.txtLecturaActual.MaxLength = 10;
            this.txtLecturaActual.Name = "txtLecturaActual";
            this.txtLecturaActual.Size = new System.Drawing.Size(72, 22);
            this.txtLecturaActual.TabIndex = 0;
            this.txtLecturaActual.Text = "0";
            this.txtLecturaActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gbMedida
            // 
            this.gbMedida.Controls.Add(this.txtMedida);
            this.gbMedida.Location = new System.Drawing.Point(276, 74);
            this.gbMedida.Name = "gbMedida";
            this.gbMedida.Size = new System.Drawing.Size(146, 54);
            this.gbMedida.TabIndex = 5;
            this.gbMedida.TabStop = false;
            this.gbMedida.Text = "Medida";
            // 
            // txtMedida
            // 
            this.txtMedida.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMedida.BackColor = System.Drawing.Color.White;
            this.txtMedida.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtMedida.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtMedida.Location = new System.Drawing.Point(6, 24);
            this.txtMedida.Name = "txtMedida";
            this.txtMedida.ReadOnly = true;
            this.txtMedida.Size = new System.Drawing.Size(136, 25);
            this.txtMedida.TabIndex = 1;
            this.txtMedida.Text = "Metros cúbicos (M3)";
            this.txtMedida.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gbProximaLectura
            // 
            this.gbProximaLectura.Controls.Add(this.txtFechaProximaLectura);
            this.gbProximaLectura.Location = new System.Drawing.Point(12, 134);
            this.gbProximaLectura.Name = "gbProximaLectura";
            this.gbProximaLectura.Size = new System.Drawing.Size(258, 52);
            this.gbProximaLectura.TabIndex = 13;
            this.gbProximaLectura.TabStop = false;
            this.gbProximaLectura.Text = "Próxima lectura";
            // 
            // txtFechaProximaLectura
            // 
            this.txtFechaProximaLectura.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFechaProximaLectura.BackColor = System.Drawing.Color.White;
            this.txtFechaProximaLectura.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFechaProximaLectura.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaProximaLectura.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtFechaProximaLectura.Location = new System.Drawing.Point(6, 24);
            this.txtFechaProximaLectura.Name = "txtFechaProximaLectura";
            this.txtFechaProximaLectura.ReadOnly = true;
            this.txtFechaProximaLectura.Size = new System.Drawing.Size(246, 22);
            this.txtFechaProximaLectura.TabIndex = 1;
            this.txtFechaProximaLectura.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnTerminar
            // 
            this.btnTerminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTerminar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnTerminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnTerminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnTerminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTerminar.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTerminar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnTerminar.Image = ((System.Drawing.Image)(resources.GetObject("btnTerminar.Image")));
            this.btnTerminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTerminar.Location = new System.Drawing.Point(429, 130);
            this.btnTerminar.Name = "btnTerminar";
            this.btnTerminar.Size = new System.Drawing.Size(117, 56);
            this.btnTerminar.TabIndex = 14;
            this.btnTerminar.Text = "Terminar";
            this.btnTerminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTerminar.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtMes);
            this.groupBox4.Location = new System.Drawing.Point(276, 134);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(146, 52);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Mes de lectura";
            // 
            // txtMes
            // 
            this.txtMes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMes.BackColor = System.Drawing.Color.White;
            this.txtMes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtMes.Location = new System.Drawing.Point(6, 24);
            this.txtMes.Name = "txtMes";
            this.txtMes.ReadOnly = true;
            this.txtMes.Size = new System.Drawing.Size(134, 22);
            this.txtMes.TabIndex = 0;
            this.txtMes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // chkImprimir
            // 
            this.chkImprimir.AutoSize = true;
            this.chkImprimir.Location = new System.Drawing.Point(451, 95);
            this.chkImprimir.Name = "chkImprimir";
            this.chkImprimir.Size = new System.Drawing.Size(76, 21);
            this.chkImprimir.TabIndex = 20;
            this.chkImprimir.Text = "Imprimir";
            this.chkImprimir.UseVisualStyleBackColor = true;
            this.chkImprimir.Visible = false;
            // 
            // calculadoraExcedentes1
            // 
            this.calculadoraExcedentes1.BackColor = System.Drawing.Color.White;
            this.calculadoraExcedentes1.Cantidad_excedente = 0;
            this.calculadoraExcedentes1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calculadoraExcedentes1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.calculadoraExcedentes1.IsReporte = false;
            this.calculadoraExcedentes1.Location = new System.Drawing.Point(12, 187);
            this.calculadoraExcedentes1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.calculadoraExcedentes1.Name = "calculadoraExcedentes1";
            this.calculadoraExcedentes1.Size = new System.Drawing.Size(515, 235);
            this.calculadoraExcedentes1.TabIndex = 21;
            this.calculadoraExcedentes1.Total_excedente = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // lblRespuesta
            // 
            this.lblRespuesta.AutoSize = true;
            this.lblRespuesta.Location = new System.Drawing.Point(15, 426);
            this.lblRespuesta.Name = "lblRespuesta";
            this.lblRespuesta.Size = new System.Drawing.Size(68, 17);
            this.lblRespuesta.TabIndex = 22;
            this.lblRespuesta.Text = "Respuesta";
            this.lblRespuesta.Visible = false;
            // 
            // FrmLectura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(558, 451);
            this.Controls.Add(this.lblRespuesta);
            this.Controls.Add(this.chkImprimir);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnTerminar);
            this.Controls.Add(this.gbProximaLectura);
            this.Controls.Add(this.gbMedida);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.calculadoraExcedentes1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLectura";
            this.Text = "Lectura";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gbMedida.ResumeLayout(false);
            this.gbMedida.PerformLayout();
            this.gbProximaLectura.ResumeLayout(false);
            this.gbProximaLectura.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtLecturaActual;
        private System.Windows.Forms.GroupBox gbMedida;
        private System.Windows.Forms.TextBox txtMedida;
        private System.Windows.Forms.GroupBox gbProximaLectura;
        private System.Windows.Forms.Button btnTerminar;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtMes;
        private System.Windows.Forms.TextBox txtFechaProximaLectura;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.CheckBox chkImprimir;
        public System.Windows.Forms.TextBox txtLecturaAnterior;
        public FormsExcedentes.CalculadoraExcedentes calculadoraExcedentes1;
        private System.Windows.Forms.Label lblRespuesta;
    }
}