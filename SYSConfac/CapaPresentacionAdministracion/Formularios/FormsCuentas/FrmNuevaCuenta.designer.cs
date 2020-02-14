namespace CapaPresentacionAdministracion.Formularios.FormsCuentas
{
    partial class FrmNuevaCuenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNuevaCuenta));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.listaIva = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.listDescuentos = new System.Windows.Forms.ComboBox();
            this.btnTerminar = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.listaTarifas = new System.Windows.Forms.ComboBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.chkValorManual = new System.Windows.Forms.CheckBox();
            this.gbValorManual = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtValorManual = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.tarifaSmall1 = new CapaPresentacionAdministracion.Formularios.FormsTarifas.TarifaSmall();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnMedidor = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.gbValorManual.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCliente);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(350, 55);
            this.groupBox1.TabIndex = 2;
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
            this.txtCliente.Size = new System.Drawing.Size(338, 22);
            this.txtCliente.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtFecha);
            this.groupBox3.Location = new System.Drawing.Point(12, 406);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(350, 55);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Fecha";
            // 
            // txtFecha
            // 
            this.txtFecha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFecha.BackColor = System.Drawing.Color.White;
            this.txtFecha.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFecha.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtFecha.Location = new System.Drawing.Point(6, 24);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.ReadOnly = true;
            this.txtFecha.Size = new System.Drawing.Size(338, 22);
            this.txtFecha.TabIndex = 0;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.listaIva);
            this.groupBox7.Location = new System.Drawing.Point(248, 465);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(114, 59);
            this.groupBox7.TabIndex = 6;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "IVA";
            // 
            // listaIva
            // 
            this.listaIva.BackColor = System.Drawing.SystemColors.Control;
            this.listaIva.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listaIva.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listaIva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.listaIva.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listaIva.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.listaIva.FormattingEnabled = true;
            this.listaIva.Location = new System.Drawing.Point(6, 24);
            this.listaIva.Name = "listaIva";
            this.listaIva.Size = new System.Drawing.Size(96, 28);
            this.listaIva.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.listDescuentos);
            this.groupBox4.Location = new System.Drawing.Point(12, 465);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(114, 59);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Descuento";
            // 
            // listDescuentos
            // 
            this.listDescuentos.BackColor = System.Drawing.SystemColors.Control;
            this.listDescuentos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listDescuentos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listDescuentos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.listDescuentos.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listDescuentos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.listDescuentos.FormattingEnabled = true;
            this.listDescuentos.Location = new System.Drawing.Point(6, 24);
            this.listDescuentos.Name = "listDescuentos";
            this.listDescuentos.Size = new System.Drawing.Size(96, 28);
            this.listDescuentos.TabIndex = 0;
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
            this.btnTerminar.Location = new System.Drawing.Point(238, 571);
            this.btnTerminar.Name = "btnTerminar";
            this.btnTerminar.Size = new System.Drawing.Size(124, 56);
            this.btnTerminar.TabIndex = 15;
            this.btnTerminar.Text = "Terminar";
            this.btnTerminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTerminar.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.listaTarifas);
            this.groupBox5.Location = new System.Drawing.Point(12, 134);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(350, 59);
            this.groupBox5.TabIndex = 16;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Tarifa";
            // 
            // listaTarifas
            // 
            this.listaTarifas.BackColor = System.Drawing.SystemColors.Control;
            this.listaTarifas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listaTarifas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listaTarifas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.listaTarifas.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listaTarifas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.listaTarifas.FormattingEnabled = true;
            this.listaTarifas.Location = new System.Drawing.Point(6, 24);
            this.listaTarifas.Name = "listaTarifas";
            this.listaTarifas.Size = new System.Drawing.Size(332, 28);
            this.listaTarifas.TabIndex = 0;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(13, 539);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(122, 25);
            this.lblTotal.TabIndex = 17;
            this.lblTotal.Text = "Total a pagar";
            // 
            // chkValorManual
            // 
            this.chkValorManual.AutoSize = true;
            this.chkValorManual.Location = new System.Drawing.Point(12, 195);
            this.chkValorManual.Name = "chkValorManual";
            this.chkValorManual.Size = new System.Drawing.Size(103, 21);
            this.chkValorManual.TabIndex = 18;
            this.chkValorManual.Text = "Valor manual";
            this.chkValorManual.UseVisualStyleBackColor = true;
            // 
            // gbValorManual
            // 
            this.gbValorManual.Controls.Add(this.label1);
            this.gbValorManual.Controls.Add(this.txtValorManual);
            this.gbValorManual.Location = new System.Drawing.Point(109, 258);
            this.gbValorManual.Name = "gbValorManual";
            this.gbValorManual.Size = new System.Drawing.Size(152, 63);
            this.gbValorManual.TabIndex = 5;
            this.gbValorManual.TabStop = false;
            this.gbValorManual.Text = "Valor";
            this.gbValorManual.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "$";
            // 
            // txtValorManual
            // 
            this.txtValorManual.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValorManual.BackColor = System.Drawing.Color.White;
            this.txtValorManual.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtValorManual.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorManual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtValorManual.Location = new System.Drawing.Point(34, 24);
            this.txtValorManual.MaxLength = 8;
            this.txtValorManual.Name = "txtValorManual";
            this.txtValorManual.Size = new System.Drawing.Size(88, 28);
            this.txtValorManual.TabIndex = 0;
            this.txtValorManual.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.btnRefresh.Location = new System.Drawing.Point(164, 373);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(35, 32);
            this.btnRefresh.TabIndex = 19;
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // tarifaSmall1
            // 
            this.tarifaSmall1.BackColor = System.Drawing.Color.White;
            this.tarifaSmall1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tarifaSmall1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tarifaSmall1.Location = new System.Drawing.Point(54, 219);
            this.tarifaSmall1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tarifaSmall1.Name = "tarifaSmall1";
            this.tarifaSmall1.Size = new System.Drawing.Size(272, 155);
            this.tarifaSmall1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnMedidor);
            this.groupBox2.Location = new System.Drawing.Point(12, 73);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(350, 55);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Medidor";
            // 
            // btnMedidor
            // 
            this.btnMedidor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMedidor.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnMedidor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnMedidor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnMedidor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMedidor.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMedidor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMedidor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMedidor.Location = new System.Drawing.Point(8, 23);
            this.btnMedidor.Name = "btnMedidor";
            this.btnMedidor.Size = new System.Drawing.Size(330, 26);
            this.btnMedidor.TabIndex = 15;
            this.btnMedidor.Text = "Seleccionar medidor";
            this.btnMedidor.UseVisualStyleBackColor = true;
            // 
            // FrmNuevaCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(374, 679);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.chkValorManual);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.btnTerminar);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbValorManual);
            this.Controls.Add(this.tarifaSmall1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmNuevaCuenta";
            this.Text = "Nueva cuenta de cobro";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.gbValorManual.ResumeLayout(false);
            this.gbValorManual.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCliente;
        private FormsTarifas.TarifaSmall tarifaSmall1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.ComboBox listaIva;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox listDescuentos;
        private System.Windows.Forms.Button btnTerminar;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox listaTarifas;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.CheckBox chkValorManual;
        private System.Windows.Forms.GroupBox gbValorManual;
        private System.Windows.Forms.TextBox txtValorManual;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnMedidor;
    }
}