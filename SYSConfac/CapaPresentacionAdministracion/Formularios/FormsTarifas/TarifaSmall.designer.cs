namespace CapaPresentacionAdministracion.Formularios.FormsTarifas
{
    partial class TarifaSmall
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.gbConsMinimo = new System.Windows.Forms.GroupBox();
            this.txtConsumoMinimo = new System.Windows.Forms.TextBox();
            this.gbConsMaximo = new System.Windows.Forms.GroupBox();
            this.txtConsumoMaximo = new System.Windows.Forms.TextBox();
            this.gbMedida = new System.Windows.Forms.GroupBox();
            this.txtMedida = new System.Windows.Forms.TextBox();
            this.gbCostoExcedente = new System.Windows.Forms.GroupBox();
            this.txtCostoExcedente = new System.Windows.Forms.TextBox();
            this.gbCostoBase = new System.Windows.Forms.GroupBox();
            this.txtCostoBase = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.gbConsMinimo.SuspendLayout();
            this.gbConsMaximo.SuspendLayout();
            this.gbMedida.SuspendLayout();
            this.gbCostoExcedente.SuspendLayout();
            this.gbCostoBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtDescripcion);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(265, 43);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tarifa";
            this.toolTip1.SetToolTip(this.groupBox1, "Descripción e identificador de tarifa");
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescripcion.BackColor = System.Drawing.Color.White;
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescripcion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtDescripcion.Location = new System.Drawing.Point(6, 19);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ReadOnly = true;
            this.txtDescripcion.Size = new System.Drawing.Size(253, 18);
            this.txtDescripcion.TabIndex = 0;
            // 
            // gbConsMinimo
            // 
            this.gbConsMinimo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbConsMinimo.Controls.Add(this.txtConsumoMinimo);
            this.gbConsMinimo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbConsMinimo.Location = new System.Drawing.Point(4, 46);
            this.gbConsMinimo.Name = "gbConsMinimo";
            this.gbConsMinimo.Size = new System.Drawing.Size(78, 56);
            this.gbConsMinimo.TabIndex = 1;
            this.gbConsMinimo.TabStop = false;
            this.gbConsMinimo.Text = "Consumo mínimo";
            this.toolTip1.SetToolTip(this.gbConsMinimo, "Consumo mínimo en la medida especificada (Metros cúbicos)");
            // 
            // txtConsumoMinimo
            // 
            this.txtConsumoMinimo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConsumoMinimo.BackColor = System.Drawing.Color.White;
            this.txtConsumoMinimo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtConsumoMinimo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsumoMinimo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtConsumoMinimo.Location = new System.Drawing.Point(6, 32);
            this.txtConsumoMinimo.Name = "txtConsumoMinimo";
            this.txtConsumoMinimo.ReadOnly = true;
            this.txtConsumoMinimo.Size = new System.Drawing.Size(66, 18);
            this.txtConsumoMinimo.TabIndex = 0;
            this.txtConsumoMinimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gbConsMaximo
            // 
            this.gbConsMaximo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbConsMaximo.Controls.Add(this.txtConsumoMaximo);
            this.gbConsMaximo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbConsMaximo.Location = new System.Drawing.Point(85, 46);
            this.gbConsMaximo.Name = "gbConsMaximo";
            this.gbConsMaximo.Size = new System.Drawing.Size(83, 56);
            this.gbConsMaximo.TabIndex = 2;
            this.gbConsMaximo.TabStop = false;
            this.gbConsMaximo.Text = "Consumo máximo";
            this.toolTip1.SetToolTip(this.gbConsMaximo, "El consumo máximo base que se cubre en al tarifa");
            // 
            // txtConsumoMaximo
            // 
            this.txtConsumoMaximo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConsumoMaximo.BackColor = System.Drawing.Color.White;
            this.txtConsumoMaximo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtConsumoMaximo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsumoMaximo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtConsumoMaximo.Location = new System.Drawing.Point(6, 32);
            this.txtConsumoMaximo.Name = "txtConsumoMaximo";
            this.txtConsumoMaximo.ReadOnly = true;
            this.txtConsumoMaximo.Size = new System.Drawing.Size(71, 18);
            this.txtConsumoMaximo.TabIndex = 0;
            this.txtConsumoMaximo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gbMedida
            // 
            this.gbMedida.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMedida.Controls.Add(this.txtMedida);
            this.gbMedida.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMedida.Location = new System.Drawing.Point(4, 102);
            this.gbMedida.Name = "gbMedida";
            this.gbMedida.Size = new System.Drawing.Size(146, 43);
            this.gbMedida.TabIndex = 2;
            this.gbMedida.TabStop = false;
            this.gbMedida.Text = "Medida";
            this.toolTip1.SetToolTip(this.gbMedida, "Unidad de medida (Metros cúbicos)");
            // 
            // txtMedida
            // 
            this.txtMedida.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMedida.BackColor = System.Drawing.Color.White;
            this.txtMedida.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMedida.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMedida.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtMedida.Location = new System.Drawing.Point(6, 19);
            this.txtMedida.Name = "txtMedida";
            this.txtMedida.ReadOnly = true;
            this.txtMedida.Size = new System.Drawing.Size(134, 18);
            this.txtMedida.TabIndex = 0;
            this.txtMedida.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gbCostoExcedente
            // 
            this.gbCostoExcedente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCostoExcedente.Controls.Add(this.txtCostoExcedente);
            this.gbCostoExcedente.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCostoExcedente.Location = new System.Drawing.Point(156, 102);
            this.gbCostoExcedente.Name = "gbCostoExcedente";
            this.gbCostoExcedente.Size = new System.Drawing.Size(113, 43);
            this.gbCostoExcedente.TabIndex = 3;
            this.gbCostoExcedente.TabStop = false;
            this.gbCostoExcedente.Text = "Costo excedente";
            this.toolTip1.SetToolTip(this.gbCostoExcedente, "Costo en dólares por metro cúbico extra después del consumo máximo");
            // 
            // txtCostoExcedente
            // 
            this.txtCostoExcedente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCostoExcedente.BackColor = System.Drawing.Color.White;
            this.txtCostoExcedente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCostoExcedente.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCostoExcedente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCostoExcedente.Location = new System.Drawing.Point(6, 19);
            this.txtCostoExcedente.Name = "txtCostoExcedente";
            this.txtCostoExcedente.ReadOnly = true;
            this.txtCostoExcedente.Size = new System.Drawing.Size(101, 18);
            this.txtCostoExcedente.TabIndex = 0;
            this.txtCostoExcedente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gbCostoBase
            // 
            this.gbCostoBase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCostoBase.Controls.Add(this.txtCostoBase);
            this.gbCostoBase.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCostoBase.Location = new System.Drawing.Point(171, 46);
            this.gbCostoBase.Name = "gbCostoBase";
            this.gbCostoBase.Size = new System.Drawing.Size(98, 56);
            this.gbCostoBase.TabIndex = 4;
            this.gbCostoBase.TabStop = false;
            this.gbCostoBase.Text = "Costo base";
            this.toolTip1.SetToolTip(this.gbCostoBase, "Costo en dólares que cubre el consumo mínimo y máximo");
            // 
            // txtCostoBase
            // 
            this.txtCostoBase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCostoBase.BackColor = System.Drawing.Color.White;
            this.txtCostoBase.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCostoBase.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCostoBase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCostoBase.Location = new System.Drawing.Point(6, 25);
            this.txtCostoBase.Name = "txtCostoBase";
            this.txtCostoBase.ReadOnly = true;
            this.txtCostoBase.Size = new System.Drawing.Size(86, 18);
            this.txtCostoBase.TabIndex = 0;
            this.txtCostoBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TarifaSmall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbCostoBase);
            this.Controls.Add(this.gbConsMaximo);
            this.Controls.Add(this.gbCostoExcedente);
            this.Controls.Add(this.gbMedida);
            this.Controls.Add(this.gbConsMinimo);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "TarifaSmall";
            this.Size = new System.Drawing.Size(272, 155);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbConsMinimo.ResumeLayout(false);
            this.gbConsMinimo.PerformLayout();
            this.gbConsMaximo.ResumeLayout(false);
            this.gbConsMaximo.PerformLayout();
            this.gbMedida.ResumeLayout(false);
            this.gbMedida.PerformLayout();
            this.gbCostoExcedente.ResumeLayout(false);
            this.gbCostoExcedente.PerformLayout();
            this.gbCostoBase.ResumeLayout(false);
            this.gbCostoBase.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.GroupBox gbConsMinimo;
        private System.Windows.Forms.TextBox txtConsumoMinimo;
        private System.Windows.Forms.GroupBox gbConsMaximo;
        private System.Windows.Forms.TextBox txtConsumoMaximo;
        private System.Windows.Forms.GroupBox gbMedida;
        private System.Windows.Forms.TextBox txtMedida;
        private System.Windows.Forms.GroupBox gbCostoExcedente;
        private System.Windows.Forms.TextBox txtCostoExcedente;
        private System.Windows.Forms.GroupBox gbCostoBase;
        private System.Windows.Forms.TextBox txtCostoBase;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
