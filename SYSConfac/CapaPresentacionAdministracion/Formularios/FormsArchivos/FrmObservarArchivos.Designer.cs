namespace CapaPresentacionAdministracion.Formularios.FormsArchivos
{
    partial class FrmObservarArchivos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmObservarArchivos));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panelArchivos = new CapaPresentacionAdministracion.Controles.CustomGridPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAgregarArchivo = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.panelArchivos);
            this.groupBox2.Location = new System.Drawing.Point(12, 86);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(819, 544);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Archivos";
            // 
            // panelArchivos
            // 
            this.panelArchivos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelArchivos.AutoScroll = true;
            this.panelArchivos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelArchivos.Location = new System.Drawing.Point(6, 24);
            this.panelArchivos.Name = "panelArchivos";
            this.panelArchivos.PageSize = 10;
            this.panelArchivos.Size = new System.Drawing.Size(807, 514);
            this.panelArchivos.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnAgregarArchivo);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(819, 68);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opciones";
            // 
            // btnAgregarArchivo
            // 
            this.btnAgregarArchivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(209)))), ((int)(((byte)(218)))));
            this.btnAgregarArchivo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarArchivo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(209)))), ((int)(((byte)(218)))));
            this.btnAgregarArchivo.FlatAppearance.BorderSize = 0;
            this.btnAgregarArchivo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(209)))), ((int)(((byte)(218)))));
            this.btnAgregarArchivo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(218)))), ((int)(((byte)(236)))));
            this.btnAgregarArchivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarArchivo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarArchivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAgregarArchivo.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarArchivo.Image")));
            this.btnAgregarArchivo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarArchivo.Location = new System.Drawing.Point(9, 21);
            this.btnAgregarArchivo.Name = "btnAgregarArchivo";
            this.btnAgregarArchivo.Size = new System.Drawing.Size(154, 39);
            this.btnAgregarArchivo.TabIndex = 1;
            this.btnAgregarArchivo.Text = "Agregar archivo";
            this.btnAgregarArchivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarArchivo.UseVisualStyleBackColor = false;
            // 
            // FrmObservarArchivos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(837, 634);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmObservarArchivos";
            this.Text = "Archivos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controles.CustomGridPanel panelArchivos;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAgregarArchivo;
    }
}