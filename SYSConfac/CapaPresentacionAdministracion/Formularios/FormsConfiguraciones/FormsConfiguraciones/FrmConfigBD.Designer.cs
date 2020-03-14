namespace CapaPresentacionAdministracion.Formularios.FormsConfiguraciones.FormsConfiguraciones
{
    partial class FrmConfigBD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfigBD));
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.gbBaseDatos = new System.Windows.Forms.GroupBox();
            this.btnAyudaArchivoBD = new System.Windows.Forms.Button();
            this.btnSeleccionarBD = new System.Windows.Forms.Button();
            this.gbConexion = new System.Windows.Forms.GroupBox();
            this.btnAyudaConexion = new System.Windows.Forms.Button();
            this.txtConexion = new System.Windows.Forms.TextBox();
            this.btnAtras = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.gbBackups = new System.Windows.Forms.GroupBox();
            this.gbFrecuencia = new System.Windows.Forms.GroupBox();
            this.numericFrecuencia = new System.Windows.Forms.NumericUpDown();
            this.btnAyudaDias = new System.Windows.Forms.Button();
            this.gbRutaDestino = new System.Windows.Forms.GroupBox();
            this.btnRutaBackup = new System.Windows.Forms.Button();
            this.btnAyudaRuta = new System.Windows.Forms.Button();
            this.rdAutomaticas = new System.Windows.Forms.RadioButton();
            this.rdManuales = new System.Windows.Forms.RadioButton();
            this.gbMotorBD = new System.Windows.Forms.GroupBox();
            this.rdSqlserver = new System.Windows.Forms.RadioButton();
            this.rdSqlite = new System.Windows.Forms.RadioButton();
            this.btnAyudaMotorBD = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.gbBaseDatos.SuspendLayout();
            this.gbConexion.SuspendLayout();
            this.gbBackups.SuspendLayout();
            this.gbFrecuencia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericFrecuencia)).BeginInit();
            this.gbRutaDestino.SuspendLayout();
            this.gbMotorBD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(138)))), ((int)(((byte)(249)))));
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(578, 62);
            this.panel1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(138)))), ((int)(((byte)(249)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(1, 17);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(575, 26);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Conexión a base de datos";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gbBaseDatos
            // 
            this.gbBaseDatos.Controls.Add(this.btnAyudaArchivoBD);
            this.gbBaseDatos.Controls.Add(this.btnSeleccionarBD);
            this.gbBaseDatos.Location = new System.Drawing.Point(9, 125);
            this.gbBaseDatos.Name = "gbBaseDatos";
            this.gbBaseDatos.Size = new System.Drawing.Size(541, 65);
            this.gbBaseDatos.TabIndex = 1;
            this.gbBaseDatos.TabStop = false;
            this.gbBaseDatos.Text = "Seleccione la base de datos a conectar*";
            // 
            // btnAyudaArchivoBD
            // 
            this.btnAyudaArchivoBD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAyudaArchivoBD.BackColor = System.Drawing.Color.Transparent;
            this.btnAyudaArchivoBD.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAyudaArchivoBD.BackgroundImage")));
            this.btnAyudaArchivoBD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAyudaArchivoBD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAyudaArchivoBD.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAyudaArchivoBD.FlatAppearance.BorderSize = 0;
            this.btnAyudaArchivoBD.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAyudaArchivoBD.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnAyudaArchivoBD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAyudaArchivoBD.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAyudaArchivoBD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAyudaArchivoBD.Location = new System.Drawing.Point(508, 29);
            this.btnAyudaArchivoBD.Name = "btnAyudaArchivoBD";
            this.btnAyudaArchivoBD.Size = new System.Drawing.Size(25, 25);
            this.btnAyudaArchivoBD.TabIndex = 6;
            this.btnAyudaArchivoBD.Tag = "BASE DE DATOS";
            this.btnAyudaArchivoBD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAyudaArchivoBD.UseVisualStyleBackColor = false;
            // 
            // btnSeleccionarBD
            // 
            this.btnSeleccionarBD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSeleccionarBD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnSeleccionarBD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeleccionarBD.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnSeleccionarBD.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnSeleccionarBD.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnSeleccionarBD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionarBD.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionarBD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeleccionarBD.Location = new System.Drawing.Point(6, 22);
            this.btnSeleccionarBD.Name = "btnSeleccionarBD";
            this.btnSeleccionarBD.Size = new System.Drawing.Size(496, 35);
            this.btnSeleccionarBD.TabIndex = 5;
            this.btnSeleccionarBD.Text = "Seleccionar archivo";
            this.btnSeleccionarBD.UseVisualStyleBackColor = false;
            // 
            // gbConexion
            // 
            this.gbConexion.Controls.Add(this.btnAyudaConexion);
            this.gbConexion.Controls.Add(this.txtConexion);
            this.gbConexion.Location = new System.Drawing.Point(9, 196);
            this.gbConexion.Name = "gbConexion";
            this.gbConexion.Size = new System.Drawing.Size(541, 65);
            this.gbConexion.TabIndex = 3;
            this.gbConexion.TabStop = false;
            this.gbConexion.Text = "Nombre de la conexión";
            // 
            // btnAyudaConexion
            // 
            this.btnAyudaConexion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAyudaConexion.BackColor = System.Drawing.Color.Transparent;
            this.btnAyudaConexion.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAyudaConexion.BackgroundImage")));
            this.btnAyudaConexion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAyudaConexion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAyudaConexion.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAyudaConexion.FlatAppearance.BorderSize = 0;
            this.btnAyudaConexion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAyudaConexion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnAyudaConexion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAyudaConexion.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAyudaConexion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAyudaConexion.Location = new System.Drawing.Point(508, 25);
            this.btnAyudaConexion.Name = "btnAyudaConexion";
            this.btnAyudaConexion.Size = new System.Drawing.Size(25, 25);
            this.btnAyudaConexion.TabIndex = 7;
            this.btnAyudaConexion.Tag = "CONEXION";
            this.btnAyudaConexion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAyudaConexion.UseVisualStyleBackColor = false;
            // 
            // txtConexion
            // 
            this.txtConexion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConexion.BackColor = System.Drawing.Color.White;
            this.txtConexion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtConexion.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConexion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtConexion.Location = new System.Drawing.Point(9, 28);
            this.txtConexion.Name = "txtConexion";
            this.txtConexion.Size = new System.Drawing.Size(493, 20);
            this.txtConexion.TabIndex = 1;
            this.txtConexion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnAtras
            // 
            this.btnAtras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAtras.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAtras.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAtras.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAtras.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnAtras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtras.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtras.Image = ((System.Drawing.Image)(resources.GetObject("btnAtras.Image")));
            this.btnAtras.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAtras.Location = new System.Drawing.Point(9, 420);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(125, 53);
            this.btnAtras.TabIndex = 4;
            this.btnAtras.Text = "Atras";
            this.btnAtras.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAtras.UseVisualStyleBackColor = false;
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSiguiente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSiguiente.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSiguiente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSiguiente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSiguiente.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSiguiente.Image = ((System.Drawing.Image)(resources.GetObject("btnSiguiente.Image")));
            this.btnSiguiente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSiguiente.Location = new System.Drawing.Point(442, 420);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(125, 53);
            this.btnSiguiente.TabIndex = 5;
            this.btnSiguiente.Text = "Siguiente";
            this.btnSiguiente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSiguiente.UseVisualStyleBackColor = false;
            // 
            // gbBackups
            // 
            this.gbBackups.Controls.Add(this.gbFrecuencia);
            this.gbBackups.Controls.Add(this.gbRutaDestino);
            this.gbBackups.Controls.Add(this.rdAutomaticas);
            this.gbBackups.Controls.Add(this.rdManuales);
            this.gbBackups.Location = new System.Drawing.Point(9, 267);
            this.gbBackups.Name = "gbBackups";
            this.gbBackups.Size = new System.Drawing.Size(558, 147);
            this.gbBackups.TabIndex = 6;
            this.gbBackups.TabStop = false;
            this.gbBackups.Text = "Copias de seguridad*";
            // 
            // gbFrecuencia
            // 
            this.gbFrecuencia.Controls.Add(this.numericFrecuencia);
            this.gbFrecuencia.Controls.Add(this.btnAyudaDias);
            this.gbFrecuencia.Location = new System.Drawing.Point(221, 14);
            this.gbFrecuencia.Name = "gbFrecuencia";
            this.gbFrecuencia.Size = new System.Drawing.Size(144, 60);
            this.gbFrecuencia.TabIndex = 11;
            this.gbFrecuencia.TabStop = false;
            this.gbFrecuencia.Text = "Frecuencia (Días)";
            this.gbFrecuencia.Visible = false;
            // 
            // numericFrecuencia
            // 
            this.numericFrecuencia.BackColor = System.Drawing.Color.White;
            this.numericFrecuencia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericFrecuencia.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericFrecuencia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericFrecuencia.Location = new System.Drawing.Point(6, 25);
            this.numericFrecuencia.Name = "numericFrecuencia";
            this.numericFrecuencia.Size = new System.Drawing.Size(100, 25);
            this.numericFrecuencia.TabIndex = 9;
            this.numericFrecuencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericFrecuencia.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // btnAyudaDias
            // 
            this.btnAyudaDias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAyudaDias.BackColor = System.Drawing.Color.Transparent;
            this.btnAyudaDias.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAyudaDias.BackgroundImage")));
            this.btnAyudaDias.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAyudaDias.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAyudaDias.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAyudaDias.FlatAppearance.BorderSize = 0;
            this.btnAyudaDias.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAyudaDias.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnAyudaDias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAyudaDias.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAyudaDias.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAyudaDias.Location = new System.Drawing.Point(113, 24);
            this.btnAyudaDias.Name = "btnAyudaDias";
            this.btnAyudaDias.Size = new System.Drawing.Size(25, 25);
            this.btnAyudaDias.TabIndex = 8;
            this.btnAyudaDias.Tag = "FRECUENCIA";
            this.btnAyudaDias.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAyudaDias.UseVisualStyleBackColor = false;
            // 
            // gbRutaDestino
            // 
            this.gbRutaDestino.Controls.Add(this.btnRutaBackup);
            this.gbRutaDestino.Controls.Add(this.btnAyudaRuta);
            this.gbRutaDestino.Location = new System.Drawing.Point(9, 80);
            this.gbRutaDestino.Name = "gbRutaDestino";
            this.gbRutaDestino.Size = new System.Drawing.Size(532, 60);
            this.gbRutaDestino.TabIndex = 10;
            this.gbRutaDestino.TabStop = false;
            this.gbRutaDestino.Text = "Ruta de destino*";
            // 
            // btnRutaBackup
            // 
            this.btnRutaBackup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRutaBackup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnRutaBackup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRutaBackup.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnRutaBackup.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnRutaBackup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnRutaBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRutaBackup.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRutaBackup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRutaBackup.Location = new System.Drawing.Point(6, 18);
            this.btnRutaBackup.Name = "btnRutaBackup";
            this.btnRutaBackup.Size = new System.Drawing.Size(489, 35);
            this.btnRutaBackup.TabIndex = 6;
            this.btnRutaBackup.Text = "Seleccionar una ruta";
            this.btnRutaBackup.UseVisualStyleBackColor = false;
            // 
            // btnAyudaRuta
            // 
            this.btnAyudaRuta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAyudaRuta.BackColor = System.Drawing.Color.Transparent;
            this.btnAyudaRuta.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAyudaRuta.BackgroundImage")));
            this.btnAyudaRuta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAyudaRuta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAyudaRuta.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAyudaRuta.FlatAppearance.BorderSize = 0;
            this.btnAyudaRuta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAyudaRuta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnAyudaRuta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAyudaRuta.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAyudaRuta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAyudaRuta.Location = new System.Drawing.Point(501, 24);
            this.btnAyudaRuta.Name = "btnAyudaRuta";
            this.btnAyudaRuta.Size = new System.Drawing.Size(25, 25);
            this.btnAyudaRuta.TabIndex = 7;
            this.btnAyudaRuta.Tag = "RUTA DESTINO";
            this.btnAyudaRuta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAyudaRuta.UseVisualStyleBackColor = false;
            // 
            // rdAutomaticas
            // 
            this.rdAutomaticas.AutoSize = true;
            this.rdAutomaticas.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdAutomaticas.Location = new System.Drawing.Point(105, 35);
            this.rdAutomaticas.Name = "rdAutomaticas";
            this.rdAutomaticas.Size = new System.Drawing.Size(110, 24);
            this.rdAutomaticas.TabIndex = 9;
            this.rdAutomaticas.Text = "Automáticas";
            this.rdAutomaticas.UseVisualStyleBackColor = true;
            this.rdAutomaticas.Visible = false;
            // 
            // rdManuales
            // 
            this.rdManuales.AutoSize = true;
            this.rdManuales.Checked = true;
            this.rdManuales.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdManuales.Location = new System.Drawing.Point(9, 35);
            this.rdManuales.Name = "rdManuales";
            this.rdManuales.Size = new System.Drawing.Size(90, 24);
            this.rdManuales.TabIndex = 8;
            this.rdManuales.TabStop = true;
            this.rdManuales.Text = "Manuales";
            this.rdManuales.UseVisualStyleBackColor = true;
            // 
            // gbMotorBD
            // 
            this.gbMotorBD.Controls.Add(this.rdSqlserver);
            this.gbMotorBD.Controls.Add(this.rdSqlite);
            this.gbMotorBD.Controls.Add(this.btnAyudaMotorBD);
            this.gbMotorBD.Location = new System.Drawing.Point(9, 64);
            this.gbMotorBD.Name = "gbMotorBD";
            this.gbMotorBD.Size = new System.Drawing.Size(541, 55);
            this.gbMotorBD.TabIndex = 7;
            this.gbMotorBD.TabStop = false;
            this.gbMotorBD.Text = "Motor de base de datos*";
            // 
            // rdSqlserver
            // 
            this.rdSqlserver.AutoSize = true;
            this.rdSqlserver.Enabled = false;
            this.rdSqlserver.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdSqlserver.Location = new System.Drawing.Point(85, 22);
            this.rdSqlserver.Name = "rdSqlserver";
            this.rdSqlserver.Size = new System.Drawing.Size(102, 24);
            this.rdSqlserver.TabIndex = 11;
            this.rdSqlserver.Text = "SQL Server";
            this.rdSqlserver.UseVisualStyleBackColor = true;
            // 
            // rdSqlite
            // 
            this.rdSqlite.AutoSize = true;
            this.rdSqlite.Checked = true;
            this.rdSqlite.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdSqlite.Location = new System.Drawing.Point(9, 22);
            this.rdSqlite.Name = "rdSqlite";
            this.rdSqlite.Size = new System.Drawing.Size(70, 24);
            this.rdSqlite.TabIndex = 10;
            this.rdSqlite.TabStop = true;
            this.rdSqlite.Text = "SQLite";
            this.rdSqlite.UseVisualStyleBackColor = true;
            // 
            // btnAyudaMotorBD
            // 
            this.btnAyudaMotorBD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAyudaMotorBD.BackColor = System.Drawing.Color.Transparent;
            this.btnAyudaMotorBD.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAyudaMotorBD.BackgroundImage")));
            this.btnAyudaMotorBD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAyudaMotorBD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAyudaMotorBD.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAyudaMotorBD.FlatAppearance.BorderSize = 0;
            this.btnAyudaMotorBD.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAyudaMotorBD.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnAyudaMotorBD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAyudaMotorBD.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAyudaMotorBD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAyudaMotorBD.Location = new System.Drawing.Point(508, 21);
            this.btnAyudaMotorBD.Name = "btnAyudaMotorBD";
            this.btnAyudaMotorBD.Size = new System.Drawing.Size(25, 25);
            this.btnAyudaMotorBD.TabIndex = 6;
            this.btnAyudaMotorBD.Tag = "MOTOR";
            this.btnAyudaMotorBD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAyudaMotorBD.UseVisualStyleBackColor = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 417);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 22;
            this.label2.Tag = "";
            this.label2.Text = "* (Obligatorio)";
            // 
            // FrmConfigBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(579, 484);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gbMotorBD);
            this.Controls.Add(this.gbBackups);
            this.Controls.Add(this.btnSiguiente);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.gbConexion);
            this.Controls.Add(this.gbBaseDatos);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmConfigBD";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbBaseDatos.ResumeLayout(false);
            this.gbConexion.ResumeLayout(false);
            this.gbConexion.PerformLayout();
            this.gbBackups.ResumeLayout(false);
            this.gbBackups.PerformLayout();
            this.gbFrecuencia.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericFrecuencia)).EndInit();
            this.gbRutaDestino.ResumeLayout(false);
            this.gbMotorBD.ResumeLayout(false);
            this.gbMotorBD.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox gbBaseDatos;
        private System.Windows.Forms.GroupBox gbConexion;
        private System.Windows.Forms.TextBox txtConexion;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Button btnSeleccionarBD;
        private System.Windows.Forms.Button btnAyudaArchivoBD;
        private System.Windows.Forms.Button btnAyudaConexion;
        private System.Windows.Forms.GroupBox gbBackups;
        private System.Windows.Forms.Button btnAyudaRuta;
        private System.Windows.Forms.RadioButton rdAutomaticas;
        private System.Windows.Forms.RadioButton rdManuales;
        private System.Windows.Forms.GroupBox gbRutaDestino;
        private System.Windows.Forms.Button btnRutaBackup;
        private System.Windows.Forms.GroupBox gbMotorBD;
        private System.Windows.Forms.Button btnAyudaMotorBD;
        private System.Windows.Forms.RadioButton rdSqlserver;
        private System.Windows.Forms.RadioButton rdSqlite;
        private System.Windows.Forms.GroupBox gbFrecuencia;
        private System.Windows.Forms.Button btnAyudaDias;
        private System.Windows.Forms.NumericUpDown numericFrecuencia;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label2;
    }
}