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

namespace CapaPresentacionAdministracion.Formularios.FormsReportes
{
    public partial class FrmImpresionReporte : Form
    {
        public FrmImpresionReporte()
        {
            InitializeComponent();
        }

        ControladorImpresion objImpresion = new ControladorImpresion();

        public void AsignarReporte(DateTime fecha, string informacion)
        {
            string titulo_planilla = Convert.ToString(ConfigurationManager.AppSettings["Titulo"]);

            ReportParameter[] parameters = new ReportParameter[3];
            parameters[0] = new ReportParameter("Titulo", titulo_planilla);
            parameters[1] = new ReportParameter("Fecha", fecha.ToLongDateString());
            parameters[2] = new ReportParameter("Informacion", informacion);

            this.reportViewer1.Dock = DockStyle.Fill;
            this.Controls.Add(this.reportViewer1);

            this.reportViewer1.LocalReport.ReportEmbeddedResource =
                "CapaPresentacionAdministracion.Formularios.FormsReportes.rptReporte.rdlc";

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
