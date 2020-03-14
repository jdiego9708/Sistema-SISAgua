using CapaEntidades;
using Microsoft.Reporting.WinForms;
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacionAdministracion.Formularios.FormsCuentas
{
    public partial class FrmFacturaSmall : Form
    {
        public FrmFacturaSmall()
        {
            InitializeComponent();
            this.Load += FrmFacturaSmall_Load;
        }

        ControladorImpresion objImpresion = new ControladorImpresion();

        private void FrmFacturaSmall_Load(object sender, EventArgs e)
        {
            this.reportViewer1.Refresh();
            this.reportViewer1.RefreshReport();
            this.Activate();
        }

        public void AsignarReporte(FrmTerminarCuenta frmTerminarCuenta)
        {
            ECuentas eCuenta = frmTerminarCuenta.ECuenta;
            EPago_cuenta ePago = frmTerminarCuenta.EPago;
            EDetalleAbonosCuentas eAbono = frmTerminarCuenta.EAbono;

            decimal Total_pagar = eCuenta.Total_pagar;
            decimal total_abonos = 0;
            if (eAbono != null)
            {
                DataTable dtAbonos =
                   EDetalleAbonosCuentas.BuscarAbonos("COMPLETO ID CUENTA", eCuenta.Id_cuenta.ToString(), out string rpta);
                if (dtAbonos != null)
                {
                    foreach (DataRow row in dtAbonos.Rows)
                    {
                        if (Convert.ToInt32(row["Id_abono"]) != eAbono.Id_abono)
                        {
                            decimal abono = Convert.ToDecimal(row["Valor_abono"]);
                            total_abonos += abono;
                        }
                    }
                    total_abonos += eAbono.Valor_abono;

                    Total_pagar -= total_abonos;
                }
            }
            string titulo_planilla = Convert.ToString(ConfigurationManager.AppSettings["Titulo"]);

            ReportParameter[] parameters = new ReportParameter[12];
            parameters[0] = new ReportParameter("Id_pago", eCuenta.Id_cuenta.ToString());
            parameters[1] = new ReportParameter("Fecha_hora", DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString());
            parameters[2] = new ReportParameter("Nombre_usuario", eCuenta.ECliente.Nombres + " " +
                eCuenta.ECliente.Apellidos);
            parameters[3] = new ReportParameter("Direccion", eCuenta.EMedidor.DireccionCliente.Direccion);
            parameters[4] = new ReportParameter("Identificacion", eCuenta.ECliente.Identificacion);
            parameters[5] = new ReportParameter("Medidor", eCuenta.EMedidor.Medidor);
            parameters[6] = new ReportParameter("Tarifa", eCuenta.ETarifa.Descripcion);

            if (frmTerminarCuenta.PagoCompleto == false)
            {
                if (total_abonos > 0)
                {
                    parameters[7] = new ReportParameter("Costo",
                        "Valor cuenta: $" + eCuenta.Total_pagar.ToString("N2") +
                        Environment.NewLine +
                        "Total de abonos: $" + total_abonos.ToString("N2") +
                        Environment.NewLine +
                        "Abono: $" + eAbono.Valor_abono.ToString("N2"));
                    Total_pagar = eAbono.Valor_abono;
                }
                else
                {
                    parameters[7] = new ReportParameter("Costo",
                           "Valor cuenta: $" + eCuenta.Total_pagar.ToString("N2") +
                           Environment.NewLine +
                           "Abono: $" + eAbono.Valor_abono.ToString("N2"));
                    Total_pagar = eAbono.Valor_abono;
                }
            }
            else
            {
                if (eCuenta.ETarifa.Descripcion.Equals("MANUAL"))
                    parameters[7] = new ReportParameter("Costo", "");
                else
                {
                    if (eCuenta.Total_pagar.ToString("N2") != eCuenta.ETarifa.Valor_tarifa.ToString("N2"))
                        parameters[7] = new ReportParameter("Costo", "");
                    else
                        parameters[7] = new ReportParameter("Costo", "Costo tarifa: $" + eCuenta.ETarifa.Valor_tarifa.ToString("N2"));
                }
            }

            parameters[8] = new ReportParameter("Descuento", "$" + eCuenta.Descuento.ToString("N2"));
            parameters[9] = new ReportParameter("Iva", eCuenta.Iva.ToString("N2"));
            parameters[10] = new ReportParameter("Total_pagar", "$" + Total_pagar.ToString("N2"));
            parameters[11] = new ReportParameter("Titulo", titulo_planilla);

            this.reportViewer1.Dock = DockStyle.Fill;
            this.Controls.Add(this.reportViewer1);

            this.reportViewer1.LocalReport.ReportEmbeddedResource =
                "CapaPresentacionAdministracion.Formularios.FormsCuentas.FacturaSmall.rdlc";

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
