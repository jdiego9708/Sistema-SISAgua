namespace CapaPresentacionAdministracion.Formularios.FormsLecturas
{
    partial class FrmPlanillaLecturas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPlanillaLecturas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnMes = new System.Windows.Forms.Button();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnSincronizar = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnLecturasPendientes = new System.Windows.Forms.Button();
            this.btnLecturasRealizadas = new System.Windows.Forms.Button();
            this.btnClientesSinMedidor = new System.Windows.Forms.Button();
            this.lblOpcion = new System.Windows.Forms.Label();
            this.btnClientesProxCorte = new System.Windows.Forms.Button();
            this.btnClientesPendienteCortes = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.gbFiltros = new System.Windows.Forms.GroupBox();
            this.btnBarrio = new System.Windows.Forms.Button();
            this.rdBarrios = new System.Windows.Forms.RadioButton();
            this.rdCompleto = new System.Windows.Forms.RadioButton();
            this.gbBusqueda = new System.Windows.Forms.GroupBox();
            this.rdNombre = new System.Windows.Forms.RadioButton();
            this.rdMedidor = new System.Windows.Forms.RadioButton();
            this.rdNinguno = new System.Windows.Forms.RadioButton();
            this.txtBusqueda = new CapaPresentacionAdministracion.CustomTextBox();
            this.dgvLecturas = new CapaPresentacionAdministracion.CustomDataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.gbFiltros.SuspendLayout();
            this.gbBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLecturas)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnMes);
            this.groupBox1.Location = new System.Drawing.Point(12, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(196, 77);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mes";
            // 
            // btnMes
            // 
            this.btnMes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMes.FlatAppearance.BorderSize = 0;
            this.btnMes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMes.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMes.Image = ((System.Drawing.Image)(resources.GetObject("btnMes.Image")));
            this.btnMes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMes.Location = new System.Drawing.Point(8, 20);
            this.btnMes.Name = "btnMes";
            this.btnMes.Size = new System.Drawing.Size(177, 48);
            this.btnMes.TabIndex = 9;
            this.btnMes.Text = "Seleccionar mes";
            this.btnMes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMes.UseVisualStyleBackColor = true;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.None;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.bindingNavigator1.Location = new System.Drawing.Point(708, 186);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(205, 25);
            this.bindingNavigator1.TabIndex = 13;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(37, 22);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Número total de elementos";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Mover primero";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Mover anterior";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Posición";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Posición actual";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Mover siguiente";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Mover último";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.FlatAppearance.BorderSize = 0;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.Location = new System.Drawing.Point(269, 11);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(167, 37);
            this.btnImprimir.TabIndex = 10;
            this.btnImprimir.Text = "Imprimir planilla";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // btnSincronizar
            // 
            this.btnSincronizar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSincronizar.BackgroundImage")));
            this.btnSincronizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSincronizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSincronizar.FlatAppearance.BorderSize = 0;
            this.btnSincronizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSincronizar.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSincronizar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSincronizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSincronizar.Location = new System.Drawing.Point(219, 14);
            this.btnSincronizar.Name = "btnSincronizar";
            this.btnSincronizar.Size = new System.Drawing.Size(34, 33);
            this.btnSincronizar.TabIndex = 14;
            this.btnSincronizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnSincronizar, "Sincronizar lecturas");
            this.btnSincronizar.UseVisualStyleBackColor = true;
            // 
            // btnLecturasPendientes
            // 
            this.btnLecturasPendientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLecturasPendientes.FlatAppearance.BorderSize = 0;
            this.btnLecturasPendientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLecturasPendientes.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLecturasPendientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLecturasPendientes.Image = ((System.Drawing.Image)(resources.GetObject("btnLecturasPendientes.Image")));
            this.btnLecturasPendientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLecturasPendientes.Location = new System.Drawing.Point(4, 78);
            this.btnLecturasPendientes.Name = "btnLecturasPendientes";
            this.btnLecturasPendientes.Size = new System.Drawing.Size(143, 51);
            this.btnLecturasPendientes.TabIndex = 15;
            this.btnLecturasPendientes.Text = "Lecturas \r\npendientes";
            this.btnLecturasPendientes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLecturasPendientes.UseVisualStyleBackColor = true;
            // 
            // btnLecturasRealizadas
            // 
            this.btnLecturasRealizadas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLecturasRealizadas.FlatAppearance.BorderSize = 0;
            this.btnLecturasRealizadas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLecturasRealizadas.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLecturasRealizadas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLecturasRealizadas.Image = ((System.Drawing.Image)(resources.GetObject("btnLecturasRealizadas.Image")));
            this.btnLecturasRealizadas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLecturasRealizadas.Location = new System.Drawing.Point(153, 78);
            this.btnLecturasRealizadas.Name = "btnLecturasRealizadas";
            this.btnLecturasRealizadas.Size = new System.Drawing.Size(128, 51);
            this.btnLecturasRealizadas.TabIndex = 16;
            this.btnLecturasRealizadas.Text = "Lecturas \r\nrealizadas";
            this.btnLecturasRealizadas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLecturasRealizadas.UseVisualStyleBackColor = true;
            // 
            // btnClientesSinMedidor
            // 
            this.btnClientesSinMedidor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClientesSinMedidor.FlatAppearance.BorderSize = 0;
            this.btnClientesSinMedidor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientesSinMedidor.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientesSinMedidor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClientesSinMedidor.Image = ((System.Drawing.Image)(resources.GetObject("btnClientesSinMedidor.Image")));
            this.btnClientesSinMedidor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientesSinMedidor.Location = new System.Drawing.Point(287, 78);
            this.btnClientesSinMedidor.Name = "btnClientesSinMedidor";
            this.btnClientesSinMedidor.Size = new System.Drawing.Size(125, 51);
            this.btnClientesSinMedidor.TabIndex = 17;
            this.btnClientesSinMedidor.Text = "Clientes \r\nsin medidor";
            this.btnClientesSinMedidor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClientesSinMedidor.UseVisualStyleBackColor = true;
            // 
            // lblOpcion
            // 
            this.lblOpcion.AutoSize = true;
            this.lblOpcion.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpcion.Location = new System.Drawing.Point(1, 196);
            this.lblOpcion.Name = "lblOpcion";
            this.lblOpcion.Size = new System.Drawing.Size(0, 15);
            this.lblOpcion.TabIndex = 18;
            // 
            // btnClientesProxCorte
            // 
            this.btnClientesProxCorte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnClientesProxCorte.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClientesProxCorte.FlatAppearance.BorderSize = 0;
            this.btnClientesProxCorte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientesProxCorte.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientesProxCorte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClientesProxCorte.Image = ((System.Drawing.Image)(resources.GetObject("btnClientesProxCorte.Image")));
            this.btnClientesProxCorte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientesProxCorte.Location = new System.Drawing.Point(418, 79);
            this.btnClientesProxCorte.Name = "btnClientesProxCorte";
            this.btnClientesProxCorte.Size = new System.Drawing.Size(138, 51);
            this.btnClientesProxCorte.TabIndex = 19;
            this.btnClientesProxCorte.Text = "Clientes \r\npróximo de corte";
            this.btnClientesProxCorte.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClientesProxCorte.UseVisualStyleBackColor = false;
            // 
            // btnClientesPendienteCortes
            // 
            this.btnClientesPendienteCortes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnClientesPendienteCortes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClientesPendienteCortes.FlatAppearance.BorderSize = 0;
            this.btnClientesPendienteCortes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientesPendienteCortes.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientesPendienteCortes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClientesPendienteCortes.Image = ((System.Drawing.Image)(resources.GetObject("btnClientesPendienteCortes.Image")));
            this.btnClientesPendienteCortes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientesPendienteCortes.Location = new System.Drawing.Point(562, 79);
            this.btnClientesPendienteCortes.Name = "btnClientesPendienteCortes";
            this.btnClientesPendienteCortes.Size = new System.Drawing.Size(145, 51);
            this.btnClientesPendienteCortes.TabIndex = 20;
            this.btnClientesPendienteCortes.Text = "Clientes \r\npendiente de corte";
            this.btnClientesPendienteCortes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClientesPendienteCortes.UseVisualStyleBackColor = false;
            // 
            // btnHome
            // 
            this.btnHome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHome.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHome.BackgroundImage")));
            this.btnHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.Color.White;
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.Location = new System.Drawing.Point(880, 11);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(38, 34);
            this.btnHome.TabIndex = 21;
            this.btnHome.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHome.UseVisualStyleBackColor = true;
            // 
            // gbFiltros
            // 
            this.gbFiltros.Controls.Add(this.btnBarrio);
            this.gbFiltros.Controls.Add(this.rdBarrios);
            this.gbFiltros.Controls.Add(this.rdCompleto);
            this.gbFiltros.Location = new System.Drawing.Point(442, 1);
            this.gbFiltros.Name = "gbFiltros";
            this.gbFiltros.Size = new System.Drawing.Size(384, 50);
            this.gbFiltros.TabIndex = 22;
            this.gbFiltros.TabStop = false;
            this.gbFiltros.Text = "Filtros";
            this.gbFiltros.Visible = false;
            // 
            // btnBarrio
            // 
            this.btnBarrio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnBarrio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBarrio.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnBarrio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBarrio.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBarrio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnBarrio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBarrio.Location = new System.Drawing.Point(177, 14);
            this.btnBarrio.Name = "btnBarrio";
            this.btnBarrio.Size = new System.Drawing.Size(177, 30);
            this.btnBarrio.TabIndex = 18;
            this.btnBarrio.Text = "Generar";
            this.btnBarrio.UseVisualStyleBackColor = false;
            // 
            // rdBarrios
            // 
            this.rdBarrios.AutoSize = true;
            this.rdBarrios.Location = new System.Drawing.Point(104, 22);
            this.rdBarrios.Name = "rdBarrios";
            this.rdBarrios.Size = new System.Drawing.Size(67, 21);
            this.rdBarrios.TabIndex = 17;
            this.rdBarrios.Text = "Barrios";
            this.rdBarrios.UseVisualStyleBackColor = true;
            // 
            // rdCompleto
            // 
            this.rdCompleto.AutoSize = true;
            this.rdCompleto.Checked = true;
            this.rdCompleto.Location = new System.Drawing.Point(15, 22);
            this.rdCompleto.Name = "rdCompleto";
            this.rdCompleto.Size = new System.Drawing.Size(83, 21);
            this.rdCompleto.TabIndex = 16;
            this.rdCompleto.TabStop = true;
            this.rdCompleto.Text = "Completo";
            this.rdCompleto.UseVisualStyleBackColor = true;
            // 
            // gbBusqueda
            // 
            this.gbBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbBusqueda.Controls.Add(this.rdNombre);
            this.gbBusqueda.Controls.Add(this.rdMedidor);
            this.gbBusqueda.Controls.Add(this.rdNinguno);
            this.gbBusqueda.Controls.Add(this.txtBusqueda);
            this.gbBusqueda.Location = new System.Drawing.Point(12, 135);
            this.gbBusqueda.Name = "gbBusqueda";
            this.gbBusqueda.Size = new System.Drawing.Size(695, 44);
            this.gbBusqueda.TabIndex = 25;
            this.gbBusqueda.TabStop = false;
            this.gbBusqueda.Text = "Búsqueda";
            // 
            // rdNombre
            // 
            this.rdNombre.AutoSize = true;
            this.rdNombre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdNombre.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdNombre.Location = new System.Drawing.Point(159, 20);
            this.rdNombre.Name = "rdNombre";
            this.rdNombre.Size = new System.Drawing.Size(66, 17);
            this.rdNombre.TabIndex = 26;
            this.rdNombre.Tag = "NOMBRE";
            this.rdNombre.Text = "Nombre";
            this.rdNombre.UseVisualStyleBackColor = true;
            // 
            // rdMedidor
            // 
            this.rdMedidor.AutoSize = true;
            this.rdMedidor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdMedidor.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdMedidor.Location = new System.Drawing.Point(84, 20);
            this.rdMedidor.Name = "rdMedidor";
            this.rdMedidor.Size = new System.Drawing.Size(69, 17);
            this.rdMedidor.TabIndex = 25;
            this.rdMedidor.Tag = "MEDIDOR";
            this.rdMedidor.Text = "Medidor";
            this.rdMedidor.UseVisualStyleBackColor = true;
            // 
            // rdNinguno
            // 
            this.rdNinguno.AutoSize = true;
            this.rdNinguno.Checked = true;
            this.rdNinguno.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdNinguno.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdNinguno.Location = new System.Drawing.Point(7, 20);
            this.rdNinguno.Name = "rdNinguno";
            this.rdNinguno.Size = new System.Drawing.Size(71, 17);
            this.rdNinguno.TabIndex = 24;
            this.rdNinguno.TabStop = true;
            this.rdNinguno.Tag = "COMPLETO";
            this.rdNinguno.Text = "Ninguno";
            this.rdNinguno.UseVisualStyleBackColor = true;
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.txtBusqueda.BackColor = System.Drawing.Color.White;
            this.txtBusqueda.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusqueda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBusqueda.Imagen = null;
            this.txtBusqueda.Location = new System.Drawing.Point(231, 17);
            this.txtBusqueda.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBusqueda.MaxLenght = 0;
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(458, 20);
            this.txtBusqueda.TabIndex = 23;
            this.txtBusqueda.Texto = "Buscar lecturas";
            this.txtBusqueda.Texto_inicial = "Buscar lecturas";
            this.txtBusqueda.Tipo_txt = null;
            this.txtBusqueda.Visible_px = true;
            // 
            // dgvLecturas
            // 
            this.dgvLecturas.AllowUserToAddRows = false;
            this.dgvLecturas.AllowUserToDeleteRows = false;
            this.dgvLecturas.AllowUserToResizeColumns = false;
            this.dgvLecturas.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            this.dgvLecturas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLecturas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLecturas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvLecturas.BackgroundColor = System.Drawing.Color.White;
            this.dgvLecturas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvLecturas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvLecturas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Bisque;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLecturas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLecturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLecturas.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvLecturas.Location = new System.Drawing.Point(4, 223);
            this.dgvLecturas.Name = "dgvLecturas";
            this.dgvLecturas.PageSize = 10;
            this.dgvLecturas.ReadOnly = true;
            this.dgvLecturas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvLecturas.RowHeadersVisible = false;
            this.dgvLecturas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Bisque;
            this.dgvLecturas.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvLecturas.RowTemplate.Height = 30;
            this.dgvLecturas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvLecturas.Size = new System.Drawing.Size(909, 440);
            this.dgvLecturas.TabIndex = 7;
            // 
            // FrmPlanillaLecturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(925, 675);
            this.Controls.Add(this.gbBusqueda);
            this.Controls.Add(this.gbFiltros);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.btnClientesPendienteCortes);
            this.Controls.Add(this.btnClientesProxCorte);
            this.Controls.Add(this.lblOpcion);
            this.Controls.Add(this.btnClientesSinMedidor);
            this.Controls.Add(this.btnLecturasRealizadas);
            this.Controls.Add(this.btnLecturasPendientes);
            this.Controls.Add(this.btnSincronizar);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.bindingNavigator1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvLecturas);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmPlanillaLecturas";
            this.Text = "Planilla de lecturas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            this.gbBusqueda.ResumeLayout(false);
            this.gbBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLecturas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnMes;
        private CustomDataGridView dgvLecturas;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnSincronizar;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnLecturasPendientes;
        private System.Windows.Forms.Button btnLecturasRealizadas;
        private System.Windows.Forms.Button btnClientesSinMedidor;
        private System.Windows.Forms.Label lblOpcion;
        private System.Windows.Forms.Button btnClientesProxCorte;
        private System.Windows.Forms.Button btnClientesPendienteCortes;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.GroupBox gbFiltros;
        private System.Windows.Forms.RadioButton rdBarrios;
        private System.Windows.Forms.RadioButton rdCompleto;
        private System.Windows.Forms.Button btnBarrio;
        private CustomTextBox txtBusqueda;
        private System.Windows.Forms.GroupBox gbBusqueda;
        private System.Windows.Forms.RadioButton rdNombre;
        private System.Windows.Forms.RadioButton rdMedidor;
        private System.Windows.Forms.RadioButton rdNinguno;
    }
}