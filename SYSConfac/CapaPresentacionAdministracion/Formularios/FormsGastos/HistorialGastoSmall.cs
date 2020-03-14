using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;

namespace CapaPresentacionAdministracion.Formularios.FormsGastos
{
    public partial class HistorialGastoSmall : UserControl
    {
        public HistorialGastoSmall()
        {
            InitializeComponent();
            this.btnImprimir.Click += BtnOpciones_Click;
        }

        private void BtnOpciones_Click(object sender, EventArgs e)
        {
            FrmFacturaGastos frmFactura = new FrmFacturaGastos();
            frmFactura.AsignarReporte(this.EHistorial);
            frmFactura.Imprimir();
        }

        EHistorialGastos EHistorial;

        public void AsignarDatos(EHistorialGastos eHistorial)
        {
            this.toolTip1.SetToolTip(this.btnImprimir, "Imprimir");

            this.EHistorial = eHistorial;
            this.txtGasto.Text = eHistorial.EGasto.Titulo_gasto;
            this.txtFecha.Text = eHistorial.Fecha_gasto.ToLongDateString();
            this.txtValorGasto.Text = "$"+eHistorial.Valor_gasto.ToString("N2");
            this.txtEmpleado.Text = eHistorial.EEmpleado.Nombre_completo;
        }
    }
}
