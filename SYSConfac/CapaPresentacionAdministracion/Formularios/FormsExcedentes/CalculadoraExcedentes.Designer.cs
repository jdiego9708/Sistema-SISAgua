namespace CapaPresentacionAdministracion.Formularios.FormsExcedentes
{
    partial class CalculadoraExcedentes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTotalExceso = new System.Windows.Forms.Label();
            this.lblMedidaBase = new System.Windows.Forms.Label();
            this.lblValorBase = new System.Windows.Forms.Label();
            this.dgvTarifasExcesos = new CapaPresentacionAdministracion.CustomDataGridView();
            this.lblCostoBase = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelExcedentes = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTarifasExcesos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTotalExceso
            // 
            this.lblTotalExceso.AutoSize = true;
            this.lblTotalExceso.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalExceso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTotalExceso.Location = new System.Drawing.Point(5, 5);
            this.lblTotalExceso.Name = "lblTotalExceso";
            this.lblTotalExceso.Size = new System.Drawing.Size(132, 21);
            this.lblTotalExceso.TabIndex = 0;
            this.lblTotalExceso.Text = "Total exceso M3:";
            // 
            // lblMedidaBase
            // 
            this.lblMedidaBase.AutoSize = true;
            this.lblMedidaBase.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMedidaBase.Location = new System.Drawing.Point(5, 30);
            this.lblMedidaBase.Name = "lblMedidaBase";
            this.lblMedidaBase.Size = new System.Drawing.Size(111, 17);
            this.lblMedidaBase.TabIndex = 2;
            this.lblMedidaBase.Text = "Medida base M3:";
            // 
            // lblValorBase
            // 
            this.lblValorBase.AutoSize = true;
            this.lblValorBase.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorBase.Location = new System.Drawing.Point(5, 50);
            this.lblValorBase.Name = "lblValorBase";
            this.lblValorBase.Size = new System.Drawing.Size(89, 17);
            this.lblValorBase.TabIndex = 3;
            this.lblValorBase.Text = "Costo base $:";
            // 
            // dgvTarifasExcesos
            // 
            this.dgvTarifasExcesos.AllowUserToAddRows = false;
            this.dgvTarifasExcesos.AllowUserToDeleteRows = false;
            this.dgvTarifasExcesos.AllowUserToResizeColumns = false;
            this.dgvTarifasExcesos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            this.dgvTarifasExcesos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTarifasExcesos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTarifasExcesos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvTarifasExcesos.BackgroundColor = System.Drawing.Color.White;
            this.dgvTarifasExcesos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvTarifasExcesos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvTarifasExcesos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Bisque;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTarifasExcesos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTarifasExcesos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTarifasExcesos.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTarifasExcesos.Location = new System.Drawing.Point(9, 70);
            this.dgvTarifasExcesos.Name = "dgvTarifasExcesos";
            this.dgvTarifasExcesos.PageSize = 10;
            this.dgvTarifasExcesos.ReadOnly = true;
            this.dgvTarifasExcesos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvTarifasExcesos.RowHeadersVisible = false;
            this.dgvTarifasExcesos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Bisque;
            this.dgvTarifasExcesos.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTarifasExcesos.RowTemplate.Height = 30;
            this.dgvTarifasExcesos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvTarifasExcesos.Size = new System.Drawing.Size(217, 159);
            this.dgvTarifasExcesos.TabIndex = 7;
            // 
            // lblCostoBase
            // 
            this.lblCostoBase.AutoSize = true;
            this.lblCostoBase.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCostoBase.Location = new System.Drawing.Point(232, 89);
            this.lblCostoBase.Name = "lblCostoBase";
            this.lblCostoBase.Size = new System.Drawing.Size(89, 17);
            this.lblCostoBase.TabIndex = 9;
            this.lblCostoBase.Text = "Costo base $:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(232, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Valores:";
            // 
            // panelExcedentes
            // 
            this.panelExcedentes.Location = new System.Drawing.Point(235, 109);
            this.panelExcedentes.Name = "panelExcedentes";
            this.panelExcedentes.Size = new System.Drawing.Size(273, 120);
            this.panelExcedentes.TabIndex = 11;
            // 
            // CalculadoraExcedentes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelExcedentes);
            this.Controls.Add(this.lblCostoBase);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvTarifasExcesos);
            this.Controls.Add(this.lblValorBase);
            this.Controls.Add(this.lblMedidaBase);
            this.Controls.Add(this.lblTotalExceso);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CalculadoraExcedentes";
            this.Size = new System.Drawing.Size(511, 235);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTarifasExcesos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTotalExceso;
        private System.Windows.Forms.Label lblMedidaBase;
        private System.Windows.Forms.Label lblValorBase;
        private CustomDataGridView dgvTarifasExcesos;
        private System.Windows.Forms.Label lblCostoBase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelExcedentes;
    }
}
