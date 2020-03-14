namespace CapaPresentacionAdministracion.Formularios.FormsAgendamientoSesiones
{
    partial class FrmObservarAgendamientoSesiones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmObservarAgendamientoSesiones));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnMes = new System.Windows.Forms.Button();
            this.panelSesiones = new CapaPresentacionAdministracion.Controles.CustomGridPanel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnMes);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(196, 422);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Búsqueda";
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
            this.btnMes.Location = new System.Drawing.Point(6, 21);
            this.btnMes.Name = "btnMes";
            this.btnMes.Size = new System.Drawing.Size(177, 48);
            this.btnMes.TabIndex = 10;
            this.btnMes.Text = "Seleccionar mes";
            this.btnMes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMes.UseVisualStyleBackColor = true;
            // 
            // panelSesiones
            // 
            this.panelSesiones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSesiones.AutoScroll = true;
            this.panelSesiones.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelSesiones.BackgroundImage")));
            this.panelSesiones.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelSesiones.Location = new System.Drawing.Point(214, 23);
            this.panelSesiones.Name = "panelSesiones";
            this.panelSesiones.PageSize = 10;
            this.panelSesiones.Size = new System.Drawing.Size(489, 411);
            this.panelSesiones.TabIndex = 1;
            // 
            // FrmObservarAgendamientoSesiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(715, 446);
            this.Controls.Add(this.panelSesiones);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmObservarAgendamientoSesiones";
            this.Text = "Observar agendamientos de sesiones";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnMes;
        private Controles.CustomGridPanel panelSesiones;
    }
}