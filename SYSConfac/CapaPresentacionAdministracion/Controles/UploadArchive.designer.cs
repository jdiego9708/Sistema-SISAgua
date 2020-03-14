namespace CapaPresentacionAdministracion.Controles
{
    partial class UploadArchive
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UploadArchive));
            this.txtArchive = new System.Windows.Forms.TextBox();
            this.px1 = new System.Windows.Forms.PictureBox();
            this.btnUpload = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnQuitar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.px1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtArchive
            // 
            this.txtArchive.BackColor = System.Drawing.Color.White;
            this.txtArchive.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtArchive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtArchive.Location = new System.Drawing.Point(71, 3);
            this.txtArchive.Multiline = true;
            this.txtArchive.Name = "txtArchive";
            this.txtArchive.ReadOnly = true;
            this.txtArchive.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtArchive.Size = new System.Drawing.Size(185, 52);
            this.txtArchive.TabIndex = 3;
            // 
            // px1
            // 
            this.px1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("px1.BackgroundImage")));
            this.px1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.px1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.px1.Enabled = false;
            this.px1.Location = new System.Drawing.Point(3, 3);
            this.px1.Name = "px1";
            this.px1.Size = new System.Drawing.Size(62, 52);
            this.px1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.px1.TabIndex = 2;
            this.px1.TabStop = false;
            // 
            // btnUpload
            // 
            this.btnUpload.BackColor = System.Drawing.Color.White;
            this.btnUpload.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUpload.BackgroundImage")));
            this.btnUpload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUpload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpload.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnUpload.FlatAppearance.BorderSize = 0;
            this.btnUpload.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnUpload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpload.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpload.ForeColor = System.Drawing.Color.Gray;
            this.btnUpload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpload.Location = new System.Drawing.Point(266, 13);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(34, 34);
            this.btnUpload.TabIndex = 14;
            this.btnUpload.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpload.UseVisualStyleBackColor = false;
            // 
            // btnQuitar
            // 
            this.btnQuitar.BackColor = System.Drawing.Color.White;
            this.btnQuitar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuitar.BackgroundImage")));
            this.btnQuitar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnQuitar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuitar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnQuitar.FlatAppearance.BorderSize = 0;
            this.btnQuitar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnQuitar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnQuitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitar.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitar.ForeColor = System.Drawing.Color.Gray;
            this.btnQuitar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuitar.Location = new System.Drawing.Point(306, 13);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(34, 34);
            this.btnQuitar.TabIndex = 15;
            this.btnQuitar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnQuitar, "Quitar archivo");
            this.btnQuitar.UseVisualStyleBackColor = false;
            // 
            // UploadArchive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.txtArchive);
            this.Controls.Add(this.px1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UploadArchive";
            this.Size = new System.Drawing.Size(345, 58);
            ((System.ComponentModel.ISupportInitialize)(this.px1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtArchive;
        private System.Windows.Forms.PictureBox px1;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnQuitar;
    }
}
