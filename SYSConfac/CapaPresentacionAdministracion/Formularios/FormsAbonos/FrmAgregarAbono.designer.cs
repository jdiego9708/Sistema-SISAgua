namespace CapaPresentacionAdministracion.Formularios.FormsAbonos
{
    partial class FrmAgregarAbono
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAgregarAbono));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdAbono = new System.Windows.Forms.RadioButton();
            this.rdPagoCompleto = new System.Windows.Forms.RadioButton();
            this.gbAbono = new System.Windows.Forms.GroupBox();
            this.lblTotalAbonos = new System.Windows.Forms.Label();
            this.btnAbonos = new System.Windows.Forms.Button();
            this.lblRestante = new System.Windows.Forms.Label();
            this.txtAbono = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnTerminar = new System.Windows.Forms.Button();
            this.calculadoraVueltos1 = new CapaPresentacionAdministracion.Formularios.FormsAbonos.CalculadoraVueltos();
            this.groupBox1.SuspendLayout();
            this.gbAbono.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdAbono);
            this.groupBox1.Controls.Add(this.rdPagoCompleto);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(229, 65);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo de pago";
            // 
            // rdAbono
            // 
            this.rdAbono.AutoSize = true;
            this.rdAbono.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdAbono.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdAbono.Location = new System.Drawing.Point(143, 24);
            this.rdAbono.Name = "rdAbono";
            this.rdAbono.Size = new System.Drawing.Size(74, 25);
            this.rdAbono.TabIndex = 1;
            this.rdAbono.Text = "Abono";
            this.rdAbono.UseVisualStyleBackColor = true;
            // 
            // rdPagoCompleto
            // 
            this.rdPagoCompleto.AutoSize = true;
            this.rdPagoCompleto.Checked = true;
            this.rdPagoCompleto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdPagoCompleto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdPagoCompleto.Location = new System.Drawing.Point(6, 24);
            this.rdPagoCompleto.Name = "rdPagoCompleto";
            this.rdPagoCompleto.Size = new System.Drawing.Size(131, 25);
            this.rdPagoCompleto.TabIndex = 0;
            this.rdPagoCompleto.TabStop = true;
            this.rdPagoCompleto.Text = "Pago completo";
            this.rdPagoCompleto.UseVisualStyleBackColor = true;
            // 
            // gbAbono
            // 
            this.gbAbono.Controls.Add(this.lblRestante);
            this.gbAbono.Controls.Add(this.txtAbono);
            this.gbAbono.Controls.Add(this.label2);
            this.gbAbono.Controls.Add(this.label3);
            this.gbAbono.Enabled = false;
            this.gbAbono.Location = new System.Drawing.Point(12, 159);
            this.gbAbono.Name = "gbAbono";
            this.gbAbono.Size = new System.Drawing.Size(229, 131);
            this.gbAbono.TabIndex = 2;
            this.gbAbono.TabStop = false;
            this.gbAbono.Text = "Valor a pagar - Abono";
            // 
            // lblTotalAbonos
            // 
            this.lblTotalAbonos.AutoSize = true;
            this.lblTotalAbonos.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAbonos.Location = new System.Drawing.Point(12, 139);
            this.lblTotalAbonos.Name = "lblTotalAbonos";
            this.lblTotalAbonos.Size = new System.Drawing.Size(89, 17);
            this.lblTotalAbonos.TabIndex = 3;
            this.lblTotalAbonos.Text = "Total abonos:";
            // 
            // btnAbonos
            // 
            this.btnAbonos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(236)))), ((int)(((byte)(191)))));
            this.btnAbonos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbonos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(236)))), ((int)(((byte)(191)))));
            this.btnAbonos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAbonos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAbonos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbonos.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbonos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAbonos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAbonos.Location = new System.Drawing.Point(12, 104);
            this.btnAbonos.Name = "btnAbonos";
            this.btnAbonos.Size = new System.Drawing.Size(71, 29);
            this.btnAbonos.TabIndex = 10;
            this.btnAbonos.Text = "Abonos";
            this.btnAbonos.UseVisualStyleBackColor = false;
            // 
            // lblRestante
            // 
            this.lblRestante.AutoSize = true;
            this.lblRestante.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRestante.Location = new System.Drawing.Point(14, 88);
            this.lblRestante.Name = "lblRestante";
            this.lblRestante.Size = new System.Drawing.Size(78, 21);
            this.lblRestante.TabIndex = 3;
            this.lblRestante.Text = "Restante:";
            // 
            // txtAbono
            // 
            this.txtAbono.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAbono.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtAbono.Location = new System.Drawing.Point(71, 40);
            this.txtAbono.Name = "txtAbono";
            this.txtAbono.Size = new System.Drawing.Size(93, 29);
            this.txtAbono.TabIndex = 1;
            this.txtAbono.Text = "0";
            this.txtAbono.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(98, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Valor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(54, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "$";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(8, 80);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(103, 21);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "Total a pagar";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnTerminar);
            this.groupBox2.Controls.Add(this.calculadoraVueltos1);
            this.groupBox2.Location = new System.Drawing.Point(12, 296);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(229, 237);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Calculadora de vueltos";
            // 
            // btnTerminar
            // 
            this.btnTerminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(236)))), ((int)(((byte)(191)))));
            this.btnTerminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTerminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(236)))), ((int)(((byte)(191)))));
            this.btnTerminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnTerminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnTerminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTerminar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTerminar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnTerminar.Image = ((System.Drawing.Image)(resources.GetObject("btnTerminar.Image")));
            this.btnTerminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTerminar.Location = new System.Drawing.Point(46, 183);
            this.btnTerminar.Name = "btnTerminar";
            this.btnTerminar.Size = new System.Drawing.Size(131, 45);
            this.btnTerminar.TabIndex = 9;
            this.btnTerminar.Text = "Terminar ";
            this.btnTerminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTerminar.UseVisualStyleBackColor = false;
            // 
            // calculadoraVueltos1
            // 
            this.calculadoraVueltos1.BackColor = System.Drawing.Color.White;
            this.calculadoraVueltos1.Cambio = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.calculadoraVueltos1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calculadoraVueltos1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.calculadoraVueltos1.Location = new System.Drawing.Point(32, 25);
            this.calculadoraVueltos1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.calculadoraVueltos1.Name = "calculadoraVueltos1";
            this.calculadoraVueltos1.Size = new System.Drawing.Size(168, 148);
            this.calculadoraVueltos1.TabIndex = 0;
            this.calculadoraVueltos1.Valor_abono = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // FrmAgregarAbono
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(249, 538);
            this.Controls.Add(this.lblTotalAbonos);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbAbono);
            this.Controls.Add(this.btnAbonos);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAgregarAbono";
            this.Text = "Pago de cuenta";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbAbono.ResumeLayout(false);
            this.gbAbono.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gbAbono;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAbono;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRestante;
        private CalculadoraVueltos calculadoraVueltos1;
        private System.Windows.Forms.Button btnTerminar;
        public System.Windows.Forms.RadioButton rdPagoCompleto;
        public System.Windows.Forms.RadioButton rdAbono;
        private System.Windows.Forms.Button btnAbonos;
        private System.Windows.Forms.Label lblTotalAbonos;
    }
}