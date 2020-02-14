using CapaEntidades;
using CapaPresentacionAdministracion.Formularios.FormsBarrios;
using Microsoft.Reporting.WinForms;
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacionAdministracion.Formularios.FormsLecturas
{
    public partial class FrmReportePlanilla : Form
    {
        public FrmReportePlanilla()
        {
            InitializeComponent();
            this.btnBarrio.Click += BtnBarrio_Click;
            this.Load += FrmReportePlanilla_Load;
            this.rdCompleto.CheckedChanged += RadioButton1_CheckedChanged;
            this.rdBarrios.CheckedChanged += RadioButton1_CheckedChanged;
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rd = (RadioButton)sender;
            if (rd.Checked)
            {
                if (rd.Text.ToUpper().Equals("BARRIOS"))
                    this.btnBarrio.Visible = true;
                else
                    this.btnBarrio.Visible = false;
            }
        }

        private void FrmReportePlanilla_Load(object sender, EventArgs e)
        {
            this.reportViewer1.Refresh();
            this.reportViewer1.RefreshReport();
            this.Activate();
        }

        DataTable DtPlanilla;
        string Mes;

        public void AsignarReporte(string mes, DataTable dtPlanilla)
        {
            Mes = mes;
            dtPlanilla.TableName = "dtPlanilla";
            this.reportViewer1.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(this.reportViewer1);

            this.DtPlanilla = dtPlanilla;
            this.reportViewer1.LocalReport.ReportEmbeddedResource =
                "CapaPresentacionAdministracion.Formularios.FormsLecturas.rptPlanilla.rdlc";

            string titulo_planilla = Convert.ToString(ConfigurationManager.AppSettings["Titulo"]);

            ReportParameter[] reportParameters = new ReportParameter[2];
            reportParameters[0] = new ReportParameter("Titulo", titulo_planilla);
            reportParameters[1] = new ReportParameter("Mes_lectura", mes);
            this.reportViewer1.LocalReport.SetParameters(reportParameters);

            ReportDataSource dsClientes = new ReportDataSource("dsClientes", dtPlanilla);
            reportViewer1.LocalReport.DataSources.Add(dsClientes);
        }

        private void BtnBarrio_Click(object sender, EventArgs e)
        {
            FrmObservarBarrios frmObservarBarrios = new FrmObservarBarrios
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            frmObservarBarrios.OnDgvDoubleClick += FrmObservarBarrios_OnDgvDoubleClick;
            frmObservarBarrios.ShowDialog();
        }

        private void FrmObservarBarrios_OnDgvDoubleClick(object sender, EventArgs e)
        {
            
        }

    }
}
