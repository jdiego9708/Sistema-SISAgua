namespace CapaPresentacionAdministracion.Formularios.FormsGastos
{
    partial class FrmObservarHistorialGastos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmObservarHistorialGastos));
            this.gbBusqueda = new System.Windows.Forms.GroupBox();
            this.dateBusqueda = new System.Windows.Forms.DateTimePicker();
            this.lblResultados = new System.Windows.Forms.Label();
            this.dgvHistorialGastos = new CapaPresentacionAdministracion.Controles.CustomGridPanel();
            this.gbBusqueda.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbBusqueda
            // 
            this.gbBusqueda.Controls.Add(this.dateBusqueda);
            this.gbBusqueda.Location = new System.Drawing.Point(12, 12);
            this.gbBusqueda.Name = "gbBusqueda";
            this.gbBusqueda.Size = new System.Drawing.Size(739, 65);
            this.gbBusqueda.TabIndex = 0;
            this.gbBusqueda.TabStop = false;
            this.gbBusqueda.Text = "Búsqueda";
            // 
            // dateBusqueda
            // 
            this.dateBusqueda.CalendarFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateBusqueda.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dateBusqueda.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dateBusqueda.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateBusqueda.Location = new System.Drawing.Point(161, 24);
            this.dateBusqueda.Name = "dateBusqueda";
            this.dateBusqueda.Size = new System.Drawing.Size(403, 29);
            this.dateBusqueda.TabIndex = 0;
            // 
            // lblResultados
            // 
            this.lblResultados.AutoSize = true;
            this.lblResultados.Location = new System.Drawing.Point(12, 80);
            this.lblResultados.Name = "lblResultados";
            this.lblResultados.Size = new System.Drawing.Size(72, 17);
            this.lblResultados.TabIndex = 8;
            this.lblResultados.Text = "Resultados";
            // 
            // dgvHistorialGastos
            // 
            this.dgvHistorialGastos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHistorialGastos.AutoScroll = true;
            this.dgvHistorialGastos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvHistorialGastos.Location = new System.Drawing.Point(12, 100);
            this.dgvHistorialGastos.Name = "dgvHistorialGastos";
            this.dgvHistorialGastos.PageSize = 10;
            this.dgvHistorialGastos.Size = new System.Drawing.Size(739, 289);
            this.dgvHistorialGastos.TabIndex = 9;
            // 
            // FrmObservarHistorialGastos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 401);
            this.Controls.Add(this.dgvHistorialGastos);
            this.Controls.Add(this.lblResultados);
            this.Controls.Add(this.gbBusqueda);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmObservarHistorialGastos";
            this.Text = "Observar historial de gastos";
            this.gbBusqueda.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbBusqueda;
        private System.Windows.Forms.DateTimePicker dateBusqueda;
        private System.Windows.Forms.Label lblResultados;
        private Controles.CustomGridPanel dgvHistorialGastos;
    }
}