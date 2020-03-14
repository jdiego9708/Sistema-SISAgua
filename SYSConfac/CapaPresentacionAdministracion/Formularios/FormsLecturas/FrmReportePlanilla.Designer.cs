namespace CapaPresentacionAdministracion.Formularios.FormsLecturas
{
    partial class FrmReportePlanilla
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReportePlanilla));
            this.gbFiltros = new System.Windows.Forms.GroupBox();
            this.rdBarrios = new System.Windows.Forms.RadioButton();
            this.rdCompleto = new System.Windows.Forms.RadioButton();
            this.btnBarrio = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFiltros
            // 
            this.gbFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFiltros.Controls.Add(this.rdBarrios);
            this.gbFiltros.Controls.Add(this.rdCompleto);
            this.gbFiltros.Controls.Add(this.btnBarrio);
            this.gbFiltros.Location = new System.Drawing.Point(12, 12);
            this.gbFiltros.Name = "gbFiltros";
            this.gbFiltros.Size = new System.Drawing.Size(901, 58);
            this.gbFiltros.TabIndex = 0;
            this.gbFiltros.TabStop = false;
            this.gbFiltros.Text = "Filtros";
            this.gbFiltros.Visible = false;
            // 
            // rdBarrios
            // 
            this.rdBarrios.AutoSize = true;
            this.rdBarrios.Location = new System.Drawing.Point(95, 20);
            this.rdBarrios.Name = "rdBarrios";
            this.rdBarrios.Size = new System.Drawing.Size(67, 21);
            this.rdBarrios.TabIndex = 15;
            this.rdBarrios.Text = "Barrios";
            this.rdBarrios.UseVisualStyleBackColor = true;
            // 
            // rdCompleto
            // 
            this.rdCompleto.AutoSize = true;
            this.rdCompleto.Checked = true;
            this.rdCompleto.Location = new System.Drawing.Point(6, 20);
            this.rdCompleto.Name = "rdCompleto";
            this.rdCompleto.Size = new System.Drawing.Size(83, 21);
            this.rdCompleto.TabIndex = 14;
            this.rdCompleto.TabStop = true;
            this.rdCompleto.Text = "Completo";
            this.rdCompleto.UseVisualStyleBackColor = true;
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
            this.btnBarrio.Location = new System.Drawing.Point(168, 16);
            this.btnBarrio.Name = "btnBarrio";
            this.btnBarrio.Size = new System.Drawing.Size(177, 30);
            this.btnBarrio.TabIndex = 11;
            this.btnBarrio.Text = "Seleccionar barrio";
            this.btnBarrio.UseVisualStyleBackColor = false;
            this.btnBarrio.Visible = false;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "ReportViewer";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(396, 246);
            this.reportViewer1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(12, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(901, 570);
            this.panel1.TabIndex = 1;
            // 
            // FrmReportePlanilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(933, 588);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gbFiltros);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmReportePlanilla";
            this.Text = "Planilla";
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFiltros;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBarrio;
        private System.Windows.Forms.RadioButton rdCompleto;
        private System.Windows.Forms.RadioButton rdBarrios;
    }
}