namespace SYSConfac
{
    partial class FrmInicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInicio));
            this.btnCaja = new System.Windows.Forms.Button();
            this.btnAdministracion = new System.Windows.Forms.Button();
            this.btnLecturas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCaja
            // 
            this.btnCaja.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCaja.FlatAppearance.BorderSize = 0;
            this.btnCaja.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(95)))), ((int)(((byte)(112)))));
            this.btnCaja.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(162)))), ((int)(((byte)(175)))));
            this.btnCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCaja.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCaja.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(227)))), ((int)(((byte)(229)))));
            this.btnCaja.Image = ((System.Drawing.Image)(resources.GetObject("btnCaja.Image")));
            this.btnCaja.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCaja.Location = new System.Drawing.Point(-3, 0);
            this.btnCaja.Name = "btnCaja";
            this.btnCaja.Size = new System.Drawing.Size(193, 181);
            this.btnCaja.TabIndex = 0;
            this.btnCaja.Text = "Módulo de \r\ncaja";
            this.btnCaja.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCaja.UseVisualStyleBackColor = true;
            // 
            // btnAdministracion
            // 
            this.btnAdministracion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdministracion.FlatAppearance.BorderSize = 0;
            this.btnAdministracion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(95)))), ((int)(((byte)(112)))));
            this.btnAdministracion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(162)))), ((int)(((byte)(175)))));
            this.btnAdministracion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdministracion.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdministracion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(227)))), ((int)(((byte)(229)))));
            this.btnAdministracion.Image = ((System.Drawing.Image)(resources.GetObject("btnAdministracion.Image")));
            this.btnAdministracion.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAdministracion.Location = new System.Drawing.Point(194, 0);
            this.btnAdministracion.Name = "btnAdministracion";
            this.btnAdministracion.Size = new System.Drawing.Size(188, 181);
            this.btnAdministracion.TabIndex = 1;
            this.btnAdministracion.Text = "Módulo de administración";
            this.btnAdministracion.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAdministracion.UseVisualStyleBackColor = true;
            // 
            // btnLecturas
            // 
            this.btnLecturas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLecturas.FlatAppearance.BorderSize = 0;
            this.btnLecturas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(95)))), ((int)(((byte)(112)))));
            this.btnLecturas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(162)))), ((int)(((byte)(175)))));
            this.btnLecturas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLecturas.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLecturas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(227)))), ((int)(((byte)(229)))));
            this.btnLecturas.Image = ((System.Drawing.Image)(resources.GetObject("btnLecturas.Image")));
            this.btnLecturas.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLecturas.Location = new System.Drawing.Point(385, 0);
            this.btnLecturas.Name = "btnLecturas";
            this.btnLecturas.Size = new System.Drawing.Size(188, 181);
            this.btnLecturas.TabIndex = 2;
            this.btnLecturas.Text = "Módulo de lecturas";
            this.btnLecturas.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLecturas.UseVisualStyleBackColor = true;
            // 
            // FrmInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(581, 187);
            this.Controls.Add(this.btnLecturas);
            this.Controls.Add(this.btnAdministracion);
            this.Controls.Add(this.btnCaja);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmInicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Módulos SIS-AGUA";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCaja;
        private System.Windows.Forms.Button btnAdministracion;
        private System.Windows.Forms.Button btnLecturas;
    }
}

