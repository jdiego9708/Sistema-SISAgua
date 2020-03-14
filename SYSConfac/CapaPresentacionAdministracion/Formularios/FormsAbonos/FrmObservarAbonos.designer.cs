namespace CapaPresentacionAdministracion.Formularios.FormsAbonos
{
    partial class FrmObservarAbonos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmObservarAbonos));
            this.panelAbono = new CapaPresentacionAdministracion.Controles.CustomGridPanel();
            this.lblResultados = new System.Windows.Forms.Label();
            this.lblTotalAbonos = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panelAbono
            // 
            this.panelAbono.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelAbono.AutoScroll = true;
            this.panelAbono.Location = new System.Drawing.Point(3, 45);
            this.panelAbono.Name = "panelAbono";
            this.panelAbono.Size = new System.Drawing.Size(405, 333);
            this.panelAbono.TabIndex = 0;
            // 
            // lblResultados
            // 
            this.lblResultados.AutoSize = true;
            this.lblResultados.Location = new System.Drawing.Point(3, 3);
            this.lblResultados.Name = "lblResultados";
            this.lblResultados.Size = new System.Drawing.Size(72, 17);
            this.lblResultados.TabIndex = 1;
            this.lblResultados.Text = "Resultados";
            // 
            // lblTotalAbonos
            // 
            this.lblTotalAbonos.AutoSize = true;
            this.lblTotalAbonos.Location = new System.Drawing.Point(3, 24);
            this.lblTotalAbonos.Name = "lblTotalAbonos";
            this.lblTotalAbonos.Size = new System.Drawing.Size(87, 17);
            this.lblTotalAbonos.TabIndex = 2;
            this.lblTotalAbonos.Text = "Total abonos:";
            // 
            // FrmObservarAbonos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(410, 390);
            this.Controls.Add(this.lblTotalAbonos);
            this.Controls.Add(this.lblResultados);
            this.Controls.Add(this.panelAbono);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmObservarAbonos";
            this.Text = "Observar abonos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CapaPresentacionAdministracion.Controles.CustomGridPanel panelAbono;
        private System.Windows.Forms.Label lblResultados;
        private System.Windows.Forms.Label lblTotalAbonos;
    }
}