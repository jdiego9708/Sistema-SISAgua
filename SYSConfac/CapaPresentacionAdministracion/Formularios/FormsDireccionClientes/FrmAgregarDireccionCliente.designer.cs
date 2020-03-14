namespace CapaPresentacionAdministracion.Formularios.FormsDireccionClientes
{
    partial class FrmAgregarDireccionCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAgregarDireccionCliente));
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbTipoEstablecimiento = new System.Windows.Forms.GroupBox();
            this.rdComercial = new System.Windows.Forms.RadioButton();
            this.rdVivienda = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.listaBarrios = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.listaParroquias = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listaCantones = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnCliente = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            this.gbTipoEstablecimiento.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gbTipoEstablecimiento);
            this.panel1.Controls.Add(this.groupBox5);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Location = new System.Drawing.Point(12, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(431, 223);
            this.panel1.TabIndex = 1;
            // 
            // gbTipoEstablecimiento
            // 
            this.gbTipoEstablecimiento.Controls.Add(this.rdComercial);
            this.gbTipoEstablecimiento.Controls.Add(this.rdVivienda);
            this.gbTipoEstablecimiento.Location = new System.Drawing.Point(221, 133);
            this.gbTipoEstablecimiento.Name = "gbTipoEstablecimiento";
            this.gbTipoEstablecimiento.Size = new System.Drawing.Size(204, 74);
            this.gbTipoEstablecimiento.TabIndex = 3;
            this.gbTipoEstablecimiento.TabStop = false;
            this.gbTipoEstablecimiento.Text = "Tipo establecimiento";
            // 
            // rdComercial
            // 
            this.rdComercial.AutoSize = true;
            this.rdComercial.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdComercial.Location = new System.Drawing.Point(6, 50);
            this.rdComercial.Name = "rdComercial";
            this.rdComercial.Size = new System.Drawing.Size(84, 21);
            this.rdComercial.TabIndex = 1;
            this.rdComercial.TabStop = true;
            this.rdComercial.Text = "Comercial";
            this.rdComercial.UseVisualStyleBackColor = true;
            // 
            // rdVivienda
            // 
            this.rdVivienda.AutoSize = true;
            this.rdVivienda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdVivienda.Location = new System.Drawing.Point(6, 24);
            this.rdVivienda.Name = "rdVivienda";
            this.rdVivienda.Size = new System.Drawing.Size(75, 21);
            this.rdVivienda.TabIndex = 0;
            this.rdVivienda.TabStop = true;
            this.rdVivienda.Text = "Vivienda";
            this.rdVivienda.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.listaBarrios);
            this.groupBox5.Location = new System.Drawing.Point(6, 133);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(204, 59);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Barrio";
            // 
            // listaBarrios
            // 
            this.listaBarrios.BackColor = System.Drawing.SystemColors.Control;
            this.listaBarrios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listaBarrios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listaBarrios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.listaBarrios.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listaBarrios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.listaBarrios.FormattingEnabled = true;
            this.listaBarrios.Location = new System.Drawing.Point(6, 24);
            this.listaBarrios.Name = "listaBarrios";
            this.listaBarrios.Size = new System.Drawing.Size(174, 28);
            this.listaBarrios.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.listaParroquias);
            this.groupBox4.Location = new System.Drawing.Point(221, 68);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(204, 59);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Parroquia";
            // 
            // listaParroquias
            // 
            this.listaParroquias.BackColor = System.Drawing.SystemColors.Control;
            this.listaParroquias.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listaParroquias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listaParroquias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.listaParroquias.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listaParroquias.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.listaParroquias.FormattingEnabled = true;
            this.listaParroquias.Location = new System.Drawing.Point(6, 22);
            this.listaParroquias.Name = "listaParroquias";
            this.listaParroquias.Size = new System.Drawing.Size(170, 28);
            this.listaParroquias.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listaCantones);
            this.groupBox3.Location = new System.Drawing.Point(6, 68);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(204, 59);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Cantón";
            // 
            // listaCantones
            // 
            this.listaCantones.BackColor = System.Drawing.SystemColors.Control;
            this.listaCantones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listaCantones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listaCantones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.listaCantones.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listaCantones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.listaCantones.FormattingEnabled = true;
            this.listaCantones.Location = new System.Drawing.Point(6, 24);
            this.listaCantones.Name = "listaCantones";
            this.listaCantones.Size = new System.Drawing.Size(174, 28);
            this.listaCantones.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDireccion);
            this.groupBox2.Location = new System.Drawing.Point(6, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(419, 59);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dirección";
            // 
            // txtDireccion
            // 
            this.txtDireccion.BackColor = System.Drawing.Color.White;
            this.txtDireccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtDireccion.Location = new System.Drawing.Point(6, 24);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(407, 25);
            this.txtDireccion.TabIndex = 0;
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
            this.btnGuardar.Location = new System.Drawing.Point(164, 299);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(117, 41);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnCliente
            // 
            this.btnCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCliente.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnCliente.FlatAppearance.BorderSize = 0;
            this.btnCliente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnCliente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCliente.Location = new System.Drawing.Point(6, 18);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(419, 29);
            this.btnCliente.TabIndex = 0;
            this.btnCliente.Text = "Seleccione";
            this.btnCliente.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCliente);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(431, 51);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cliente";
            // 
            // FrmAgregarDireccionCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(455, 352);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FrmAgregarDireccionCliente";
            this.Text = "Agregar dirección de un cliente";
            this.panel1.ResumeLayout(false);
            this.gbTipoEstablecimiento.ResumeLayout(false);
            this.gbTipoEstablecimiento.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox listaCantones;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox listaBarrios;
        private System.Windows.Forms.ComboBox listaParroquias;
        private System.Windows.Forms.GroupBox gbTipoEstablecimiento;
        private System.Windows.Forms.RadioButton rdComercial;
        private System.Windows.Forms.RadioButton rdVivienda;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Button btnCliente;
    }
}