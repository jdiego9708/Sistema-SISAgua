namespace CapaPresentacionCaja.Formularios.FormsPrincipales
{
    partial class FrmPrincipalCaja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipalCaja));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnLock = new System.Windows.Forms.Button();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnObservarPagosHoy = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdMedidor = new System.Windows.Forms.RadioButton();
            this.rdNombres = new System.Windows.Forms.RadioButton();
            this.rdIdentificacion = new System.Windows.Forms.RadioButton();
            this.txtBusqueda = new CapaPresentacionAdministracion.CustomTextBox();
            this.btnObservarGastosHoy = new System.Windows.Forms.Button();
            this.btnAgregarGasto = new System.Windows.Forms.Button();
            this.btnCuentasPendientes = new System.Windows.Forms.Button();
            this.btnHistorialCuentas = new System.Windows.Forms.Button();
            this.btnAgregarCuenta = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtInformacionCaja = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(175)))), ((int)(((byte)(194)))));
            this.panel1.Controls.Add(this.btnHome);
            this.panel1.Controls.Add(this.btnLock);
            this.panel1.Controls.Add(this.txtTitulo);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(602, 55);
            this.panel1.TabIndex = 0;
            // 
            // btnHome
            // 
            this.btnHome.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHome.BackgroundImage")));
            this.btnHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.Color.White;
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.Location = new System.Drawing.Point(5, 10);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(38, 34);
            this.btnHome.TabIndex = 22;
            this.btnHome.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHome.UseVisualStyleBackColor = true;
            // 
            // btnLock
            // 
            this.btnLock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(175)))), ((int)(((byte)(194)))));
            this.btnLock.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLock.BackgroundImage")));
            this.btnLock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLock.FlatAppearance.BorderSize = 0;
            this.btnLock.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(95)))), ((int)(((byte)(112)))));
            this.btnLock.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(162)))), ((int)(((byte)(175)))));
            this.btnLock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLock.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLock.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLock.Location = new System.Drawing.Point(555, 10);
            this.btnLock.Name = "btnLock";
            this.btnLock.Size = new System.Drawing.Size(34, 35);
            this.btnLock.TabIndex = 5;
            this.btnLock.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLock.UseVisualStyleBackColor = false;
            // 
            // txtTitulo
            // 
            this.txtTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(175)))), ((int)(((byte)(194)))));
            this.txtTitulo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTitulo.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.txtTitulo.Location = new System.Drawing.Point(49, 11);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(500, 32);
            this.txtTitulo.TabIndex = 0;
            this.txtTitulo.Text = "Módulo de caja 1 (Caja cerrada)";
            this.txtTitulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnObservarPagosHoy);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btnObservarGastosHoy);
            this.groupBox1.Controls.Add(this.btnAgregarGasto);
            this.groupBox1.Controls.Add(this.btnCuentasPendientes);
            this.groupBox1.Controls.Add(this.btnHistorialCuentas);
            this.groupBox1.Controls.Add(this.btnAgregarCuenta);
            this.groupBox1.Location = new System.Drawing.Point(12, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(572, 230);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opciones disponibles";
            // 
            // btnObservarPagosHoy
            // 
            this.btnObservarPagosHoy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(175)))), ((int)(((byte)(194)))));
            this.btnObservarPagosHoy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnObservarPagosHoy.FlatAppearance.BorderSize = 0;
            this.btnObservarPagosHoy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnObservarPagosHoy.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnObservarPagosHoy.ForeColor = System.Drawing.Color.White;
            this.btnObservarPagosHoy.Image = ((System.Drawing.Image)(resources.GetObject("btnObservarPagosHoy.Image")));
            this.btnObservarPagosHoy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnObservarPagosHoy.Location = new System.Drawing.Point(363, 66);
            this.btnObservarPagosHoy.Name = "btnObservarPagosHoy";
            this.btnObservarPagosHoy.Size = new System.Drawing.Size(188, 41);
            this.btnObservarPagosHoy.TabIndex = 11;
            this.btnObservarPagosHoy.Text = "Observar pagos de hoy";
            this.btnObservarPagosHoy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnObservarPagosHoy.UseVisualStyleBackColor = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdMedidor);
            this.groupBox2.Controls.Add(this.rdNombres);
            this.groupBox2.Controls.Add(this.rdIdentificacion);
            this.groupBox2.Controls.Add(this.txtBusqueda);
            this.groupBox2.Location = new System.Drawing.Point(17, 114);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(534, 109);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Búsqueda de cobros";
            // 
            // rdMedidor
            // 
            this.rdMedidor.AutoSize = true;
            this.rdMedidor.Location = new System.Drawing.Point(201, 24);
            this.rdMedidor.Name = "rdMedidor";
            this.rdMedidor.Size = new System.Drawing.Size(77, 21);
            this.rdMedidor.TabIndex = 3;
            this.rdMedidor.TabStop = true;
            this.rdMedidor.Text = "Medidor";
            this.rdMedidor.UseVisualStyleBackColor = true;
            // 
            // rdNombres
            // 
            this.rdNombres.AutoSize = true;
            this.rdNombres.Location = new System.Drawing.Point(114, 24);
            this.rdNombres.Name = "rdNombres";
            this.rdNombres.Size = new System.Drawing.Size(81, 21);
            this.rdNombres.TabIndex = 2;
            this.rdNombres.TabStop = true;
            this.rdNombres.Text = "Nombres";
            this.rdNombres.UseVisualStyleBackColor = true;
            // 
            // rdIdentificacion
            // 
            this.rdIdentificacion.AutoSize = true;
            this.rdIdentificacion.Checked = true;
            this.rdIdentificacion.Location = new System.Drawing.Point(6, 24);
            this.rdIdentificacion.Name = "rdIdentificacion";
            this.rdIdentificacion.Size = new System.Drawing.Size(102, 21);
            this.rdIdentificacion.TabIndex = 1;
            this.rdIdentificacion.TabStop = true;
            this.rdIdentificacion.Text = "Identificación";
            this.rdIdentificacion.UseVisualStyleBackColor = true;
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.txtBusqueda.BackColor = System.Drawing.Color.White;
            this.txtBusqueda.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusqueda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBusqueda.Imagen = null;
            this.txtBusqueda.Location = new System.Drawing.Point(6, 59);
            this.txtBusqueda.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBusqueda.MaxLenght = 0;
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(522, 20);
            this.txtBusqueda.TabIndex = 0;
            this.txtBusqueda.Texto = "Iniciar búsqueda";
            this.txtBusqueda.Texto_inicial = "Iniciar búsqueda";
            this.txtBusqueda.Tipo_txt = null;
            this.toolTip1.SetToolTip(this.txtBusqueda, "Buscar cobros");
            this.txtBusqueda.Visible_px = true;
            // 
            // btnObservarGastosHoy
            // 
            this.btnObservarGastosHoy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(175)))), ((int)(((byte)(194)))));
            this.btnObservarGastosHoy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnObservarGastosHoy.FlatAppearance.BorderSize = 0;
            this.btnObservarGastosHoy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnObservarGastosHoy.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnObservarGastosHoy.ForeColor = System.Drawing.Color.White;
            this.btnObservarGastosHoy.Image = ((System.Drawing.Image)(resources.GetObject("btnObservarGastosHoy.Image")));
            this.btnObservarGastosHoy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnObservarGastosHoy.Location = new System.Drawing.Point(174, 66);
            this.btnObservarGastosHoy.Name = "btnObservarGastosHoy";
            this.btnObservarGastosHoy.Size = new System.Drawing.Size(188, 41);
            this.btnObservarGastosHoy.TabIndex = 8;
            this.btnObservarGastosHoy.Text = "Observar gastos de hoy";
            this.btnObservarGastosHoy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnObservarGastosHoy.UseVisualStyleBackColor = false;
            // 
            // btnAgregarGasto
            // 
            this.btnAgregarGasto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(175)))), ((int)(((byte)(194)))));
            this.btnAgregarGasto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarGasto.FlatAppearance.BorderSize = 0;
            this.btnAgregarGasto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarGasto.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarGasto.ForeColor = System.Drawing.Color.White;
            this.btnAgregarGasto.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarGasto.Image")));
            this.btnAgregarGasto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarGasto.Location = new System.Drawing.Point(17, 66);
            this.btnAgregarGasto.Name = "btnAgregarGasto";
            this.btnAgregarGasto.Size = new System.Drawing.Size(156, 41);
            this.btnAgregarGasto.TabIndex = 7;
            this.btnAgregarGasto.Text = "Agregar gasto";
            this.btnAgregarGasto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarGasto.UseVisualStyleBackColor = false;
            // 
            // btnCuentasPendientes
            // 
            this.btnCuentasPendientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(175)))), ((int)(((byte)(194)))));
            this.btnCuentasPendientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCuentasPendientes.FlatAppearance.BorderSize = 0;
            this.btnCuentasPendientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCuentasPendientes.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCuentasPendientes.ForeColor = System.Drawing.Color.White;
            this.btnCuentasPendientes.Image = ((System.Drawing.Image)(resources.GetObject("btnCuentasPendientes.Image")));
            this.btnCuentasPendientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCuentasPendientes.Location = new System.Drawing.Point(363, 24);
            this.btnCuentasPendientes.Name = "btnCuentasPendientes";
            this.btnCuentasPendientes.Size = new System.Drawing.Size(188, 41);
            this.btnCuentasPendientes.TabIndex = 6;
            this.btnCuentasPendientes.Text = "Cuentas pendientes";
            this.btnCuentasPendientes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCuentasPendientes.UseVisualStyleBackColor = false;
            // 
            // btnHistorialCuentas
            // 
            this.btnHistorialCuentas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(175)))), ((int)(((byte)(194)))));
            this.btnHistorialCuentas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHistorialCuentas.FlatAppearance.BorderSize = 0;
            this.btnHistorialCuentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistorialCuentas.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistorialCuentas.ForeColor = System.Drawing.Color.White;
            this.btnHistorialCuentas.Image = ((System.Drawing.Image)(resources.GetObject("btnHistorialCuentas.Image")));
            this.btnHistorialCuentas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHistorialCuentas.Location = new System.Drawing.Point(174, 24);
            this.btnHistorialCuentas.Name = "btnHistorialCuentas";
            this.btnHistorialCuentas.Size = new System.Drawing.Size(188, 41);
            this.btnHistorialCuentas.TabIndex = 5;
            this.btnHistorialCuentas.Text = "Historial de cuentas";
            this.btnHistorialCuentas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHistorialCuentas.UseVisualStyleBackColor = false;
            // 
            // btnAgregarCuenta
            // 
            this.btnAgregarCuenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(175)))), ((int)(((byte)(194)))));
            this.btnAgregarCuenta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarCuenta.FlatAppearance.BorderSize = 0;
            this.btnAgregarCuenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarCuenta.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarCuenta.ForeColor = System.Drawing.Color.White;
            this.btnAgregarCuenta.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarCuenta.Image")));
            this.btnAgregarCuenta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarCuenta.Location = new System.Drawing.Point(17, 24);
            this.btnAgregarCuenta.Name = "btnAgregarCuenta";
            this.btnAgregarCuenta.Size = new System.Drawing.Size(156, 41);
            this.btnAgregarCuenta.TabIndex = 4;
            this.btnAgregarCuenta.Text = "Agregar cuenta";
            this.btnAgregarCuenta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarCuenta.UseVisualStyleBackColor = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtInformacionCaja);
            this.groupBox3.Location = new System.Drawing.Point(12, 306);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(572, 388);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Información de caja";
            // 
            // txtInformacionCaja
            // 
            this.txtInformacionCaja.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInformacionCaja.BackColor = System.Drawing.Color.White;
            this.txtInformacionCaja.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInformacionCaja.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtInformacionCaja.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInformacionCaja.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtInformacionCaja.Location = new System.Drawing.Point(6, 24);
            this.txtInformacionCaja.Multiline = true;
            this.txtInformacionCaja.Name = "txtInformacionCaja";
            this.txtInformacionCaja.ReadOnly = true;
            this.txtInformacionCaja.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInformacionCaja.Size = new System.Drawing.Size(560, 351);
            this.txtInformacionCaja.TabIndex = 3;
            this.txtInformacionCaja.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FrmPrincipalCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(601, 706);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPrincipalCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Caja";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLock;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnAgregarCuenta;
        private System.Windows.Forms.Button btnHistorialCuentas;
        private System.Windows.Forms.Button btnCuentasPendientes;
        private System.Windows.Forms.Button btnAgregarGasto;
        private System.Windows.Forms.Button btnObservarGastosHoy;
        private System.Windows.Forms.GroupBox groupBox2;
        private CapaPresentacionAdministracion.CustomTextBox txtBusqueda;
        private System.Windows.Forms.RadioButton rdIdentificacion;
        private System.Windows.Forms.RadioButton rdNombres;
        private System.Windows.Forms.RadioButton rdMedidor;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnObservarPagosHoy;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtInformacionCaja;
    }
}