using CapaEntidades;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacionAdministracion.Formularios.FormsGastos
{
    public partial class FrmFacturaGastos : Form
    {
        public FrmFacturaGastos()
        {
            InitializeComponent();
        }

        ControladorImpresion objImpresion = new ControladorImpresion();

        public void AsignarReporte(EHistorialGastos eHistorial)
        {
            ReportParameter[] parameters = new ReportParameter[3];
            parameters[0] = new ReportParameter("Id_comprobante", eHistorial.Id_historial_gasto.ToString());

            StringBuilder cadena = new StringBuilder();
            cadena.Append("Fecha: ").Append(eHistorial.Fecha_gasto);
            cadena.Append(Environment.NewLine);
            cadena.Append("A nombre de: ").Append(Environment.NewLine);
            cadena.Append(Environment.NewLine);
            cadena.Append("Rubro: ").Append(eHistorial.EGasto.Titulo_gasto);
            cadena.Append(Environment.NewLine);
            cadena.Append(Environment.NewLine);
            cadena.Append("Valor: $").Append(eHistorial.Valor_gasto.ToString("N2"));
            cadena.Append(Environment.NewLine);

            parameters[1] = new ReportParameter("Informacion", cadena.ToString());
            string titulo = Convert.ToString(ConfigurationManager.AppSettings["Titulo"]);
            parameters[2] = new ReportParameter("Titulo", titulo);

            this.reportViewer1.Dock = DockStyle.Fill;
            this.Controls.Add(this.reportViewer1);

            this.reportViewer1.LocalReport.ReportEmbeddedResource =
                "CapaPresentacionAdministracion.Formularios.FormsGastos.rptComprobanteGasto.rdlc";

            this.reportViewer1.LocalReport.SetParameters(parameters);
            this.reportViewer1.Refresh();
            this.reportViewer1.RefreshReport();
        }

        public void Imprimir()
        {
            this.reportViewer1.Refresh();
            this.reportViewer1.RefreshReport();

            objImpresion.Imprimir(reportViewer1.LocalReport);
            objImpresion.Dispose();
        }
    }
}
