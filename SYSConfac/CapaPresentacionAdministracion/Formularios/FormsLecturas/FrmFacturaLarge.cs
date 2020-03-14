using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;
using CapaPresentacionAdministracion.Formularios.FormsCuentas;
using CapaPresentacionAdministracion.Formularios.FormsLecturas;
using Microsoft.Reporting.WinForms;

namespace CapaPresentacionAdministracion.Formularios.FormsLecturas
{
    public partial class FrmFacturaLarge : Form
    {
        public FrmFacturaLarge()
        {
            InitializeComponent();
            this.Load += FrmFacturaLarge_Load;
        }

        private void FrmFacturaLarge_Load(object sender, EventArgs e)
        {
            this.reportViewer1.Refresh();
            this.reportViewer1.RefreshReport();
            this.Activate();
        }

        ControladorImpresion objImpresion = new ControladorImpresion();

        public string MonthName(int month)
        {
            DateTimeFormatInfo dtinfo = new CultureInfo("es-ES", false).DateTimeFormat;
            return dtinfo.GetMonthName(month);
        }

        public void AsignarReporte(FrmTerminarCuenta frmTerminarCuenta)
        {
            ECuentas eCuenta = frmTerminarCuenta.ECuenta;
            string titulo_planilla = Convert.ToString(ConfigurationManager.AppSettings["Titulo"]);
            ReportParameter[] parameters = new ReportParameter[18];
            parameters[0] = new ReportParameter("Id_pago", eCuenta.Id_cuenta.ToString());
            parameters[1] = new ReportParameter("Fecha_hora", DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString());
            parameters[2] = new ReportParameter("Nombre_usuario", eCuenta.ECliente.Nombres + " " +
                eCuenta.ECliente.Apellidos);
            parameters[3] = new ReportParameter("Direccion", eCuenta.EMedidor.DireccionCliente.Direccion);
            parameters[4] = new ReportParameter("Identificacion", eCuenta.ECliente.Identificacion);
            parameters[5] = new ReportParameter("Medidor", eCuenta.EMedidor.Medidor);
            parameters[6] = new ReportParameter("Lectura_anterior", frmTerminarCuenta.lecturaSmall.ELecturaAnterior.Valor_lectura.ToString());
            parameters[7] = new ReportParameter("Lectura_actual", frmTerminarCuenta.lecturaSmall.ELectura.Valor_lectura.ToString());
            parameters[8] = new ReportParameter("M3_consumidos", frmTerminarCuenta.ELectura.Total_consumo + " M3");
            parameters[9] = new ReportParameter("Tarifa", frmTerminarCuenta.ECuenta.ETarifa.Descripcion);
            parameters[10] = new ReportParameter("M3_base", frmTerminarCuenta.ECuenta.ETarifa.EDetalleTarifa.Consumo_minimo + "/" +
                frmTerminarCuenta.ECuenta.ETarifa.EDetalleTarifa.Consumo_maximo);
            parameters[11] = new ReportParameter("Valor_base", "$" + frmTerminarCuenta.ECuenta.ETarifa.EDetalleTarifa.Valor_base.ToString("N2"));
            parameters[12] = new ReportParameter("Titulo", titulo_planilla);
            parameters[13] = new ReportParameter("Exceso_M3", frmTerminarCuenta.calculadoraExcedentes.Cantidad_excedente + " M3");
            parameters[14] = new ReportParameter("Tipo", "VIVIENDA");
            parameters[15] = new ReportParameter("Mes_de_consumo", this.MonthName(eCuenta.Fecha_cuenta.Month));
            parameters[16] = new ReportParameter("Total_pagar", "$" + eCuenta.Total_pagar.ToString("N2"));
            parameters[17] = new ReportParameter("InformacionPago", "Subtotal: " + eCuenta.Total_lectura.ToString("N2") + Environment.NewLine + 
                                                                    "IVA: " + eCuenta.Iva * 100 + "%" + Environment.NewLine);

            this.reportViewer1.Dock = DockStyle.Fill;
            this.Controls.Add(this.reportViewer1);

            this.reportViewer1.LocalReport.ReportEmbeddedResource =
                "CapaPresentacionAdministracion.Formularios.FormsLecturas.FacturaLarge.rdlc";

            this.reportViewer1.LocalReport.SetParameters(parameters);

            bool valor_base = false;
            DataTable dtValoresExcedentes = frmTerminarCuenta.calculadoraExcedentes.dtValoresExcedentes;
            foreach (DataRow row in dtValoresExcedentes.Rows)
            {
                if (Convert.ToString(row["Nombre"]).Equals("Valor base"))
                {
                    valor_base = true;
                    break;
                }
            }

            if (valor_base == false)
            {
                DataRow newRow = dtValoresExcedentes.NewRow();
                newRow["Nombre"] = "Valor base";
                newRow["Valor"] = "$" + frmTerminarCuenta.ECuenta.ETarifa.EDetalleTarifa.Valor_base.ToString("N2");
                dtValoresExcedentes.Rows.Add(newRow);
            }

            ReportDataSource dsTarifaExcedente = new ReportDataSource("dsTarifaExcedente", frmTerminarCuenta.calculadoraExcedentes.dtExcedentes);
            reportViewer1.LocalReport.DataSources.Add(dsTarifaExcedente);

            ReportDataSource dsValores = new ReportDataSource("dsValores", dtValoresExcedentes);
            reportViewer1.LocalReport.DataSources.Add(dsValores);

            this.reportViewer1.Refresh();
            this.reportViewer1.RefreshReport();
        }

        public void AsignarReporte(FrmLectura frmLectura)
        {
            ELecturas eLectura = frmLectura.ELectura;

            ReportParameter[] parameters = new ReportParameter[16];
            parameters[0] = new ReportParameter("Id_pago", frmLectura.ECuenta.Id_cuenta.ToString());
            parameters[1] = new ReportParameter("Fecha_hora", DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString());
            parameters[2] = new ReportParameter("Nombre_usuario", frmLectura.ECliente.Nombres + " " + frmLectura.ECliente.Apellidos);
            parameters[3] = new ReportParameter("Direccion", frmLectura.EMedidor.DireccionCliente.Direccion);
            parameters[4] = new ReportParameter("Identificacion", frmLectura.ECliente.Identificacion);
            parameters[5] = new ReportParameter("Medidor", frmLectura.EMedidor.Medidor);
            parameters[6] = new ReportParameter("Lectura_anterior", frmLectura.txtLecturaAnterior.Text);
            parameters[7] = new ReportParameter("Lectura_actual", eLectura.Valor_lectura.ToString());
            parameters[8] = new ReportParameter("M3_consumidos", eLectura.Total_consumo + " M3");
            parameters[9] = new ReportParameter("Tarifa", frmLectura.ETarifa.Descripcion);
            parameters[10] = new ReportParameter("M3_base", frmLectura.EDetalleTarifa.Consumo_minimo + "/" +
                frmLectura.EDetalleTarifa.Consumo_maximo);
            parameters[11] = new ReportParameter("Valor_base", "$" + frmLectura.EDetalleTarifa.Valor_base.ToString("N2"));
            parameters[12] = new ReportParameter("Titulo", "");
            parameters[13] = new ReportParameter("Exceso_M3", frmLectura.calculadoraExcedentes1.Cantidad_excedente + " M3");
            parameters[14] = new ReportParameter("Tipo", "VIVIENDA");
            parameters[15] = new ReportParameter("Mes_de_consumo", eLectura.Mes_lectura);

            this.reportViewer1.Dock = DockStyle.Fill;
            this.Controls.Add(this.reportViewer1);

            this.reportViewer1.LocalReport.ReportEmbeddedResource =
                "CapaPresentacionAdministracion.Formularios.FormsLecturas.FacturaLarge.rdlc";

            this.reportViewer1.LocalReport.SetParameters(parameters);

            bool valor_base = false;
            DataTable dtValoresExcedentes = frmLectura.calculadoraExcedentes1.dtValoresExcedentes;
            foreach (DataRow row in dtValoresExcedentes.Rows)
            {
                if (Convert.ToString(row["Nombre"]).Equals("Valor base"))
                {
                    valor_base = true;
                    break;
                }
            }

            if (valor_base == false)
            {
                DataRow newRow = dtValoresExcedentes.NewRow();
                newRow["Nombre"] = "Valor base";
                newRow["Valor"] = "$" + frmLectura.ECuenta.ETarifa.EDetalleTarifa.Valor_base.ToString("N2");
                dtValoresExcedentes.Rows.Add(newRow);
            }

            ReportDataSource dsTarifaExcedente = new ReportDataSource("dsTarifaExcedente", frmLectura.calculadoraExcedentes1.dtExcedentes);
            reportViewer1.LocalReport.DataSources.Add(dsTarifaExcedente);

            ReportDataSource dsValores = new ReportDataSource("dsValores", dtValoresExcedentes);
            reportViewer1.LocalReport.DataSources.Add(dsValores);

            this.reportViewer1.Refresh();
            this.reportViewer1.RefreshReport();
        }

        public void Imprimir(FrmTerminarCuenta frmTerminarCuenta)
        {
            this.AsignarReporte(frmTerminarCuenta);

            objImpresion.Imprimir(reportViewer1.LocalReport);
            objImpresion.Dispose();
        }
    }
}
