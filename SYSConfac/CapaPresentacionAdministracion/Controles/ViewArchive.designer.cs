namespace CapaPresentacionAdministracion.Controles
{
    partial class ViewArchive
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewArchive));
            this.px1 = new System.Windows.Forms.PictureBox();
            this.txtArchive = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.px1)).BeginInit();
            this.SuspendLayout();
            // 
            // px1
            // 
            this.px1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("px1.BackgroundImage")));
            this.px1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.px1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.px1.Location = new System.Drawing.Point(3, 3);
            this.px1.Name = "px1";
            this.px1.Size = new System.Drawing.Size(62, 52);
            this.px1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.px1.TabIndex = 0;
            this.px1.TabStop = false;
            // 
            // txtArchive
            // 
            this.txtArchive.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtArchive.BackColor = System.Drawing.Color.White;
            this.txtArchive.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtArchive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtArchive.Location = new System.Drawing.Point(71, 3);
            this.txtArchive.Multiline = true;
            this.txtArchive.Name = "txtArchive";
            this.txtArchive.ReadOnly = true;
            this.txtArchive.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtArchive.Size = new System.Drawing.Size(165, 52);
            this.txtArchive.TabIndex = 1;
            // 
            // ViewArchive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.txtArchive);
            this.Controls.Add(this.px1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Name = "ViewArchive";
            this.Size = new System.Drawing.Size(240, 59);
            ((System.ComponentModel.ISupportInitialize)(this.px1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox px1;
        private System.Windows.Forms.TextBox txtArchive;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
