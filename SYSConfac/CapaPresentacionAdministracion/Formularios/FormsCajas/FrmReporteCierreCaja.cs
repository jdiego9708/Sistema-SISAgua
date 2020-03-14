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

using CapaPresentacionAdministracion.Formularios.FormsCajas;
using Microsoft.Reporting.WinForms;
using CapaEntidades;
using CapaPresentacionAdministracion.Formularios.FormsExcedentes;

namespace CapaPresentacionAdministracion.Formularios.FormsCajas
{
    public partial class FrmReporteCierreCaja : Form
    {
        public FrmReporteCierreCaja()
        {
            InitializeComponent();
        }

        ControladorImpresion objImpresion = new ControladorImpresion();

        public void AsignarReporte(ECierre eCierre)
        {
            //Variables para construir el reporte
            string titulo = Convert.ToString(ConfigurationManager.AppSettings["Titulo"]);
            string nombre_reporte = "REPORTE DE CAJA";

            ReportParameter[] parameters = new ReportParameter[4];
            parameters[0] = new ReportParameter("Titulo", titulo);
            parameters[1] = new ReportParameter("Nombre_reporte", nombre_reporte);
            parameters[2] = new ReportParameter("Fecha", eCierre.Fecha_cierre.ToLongDateString());

            #region CALCULAR PAGOS Y ABONOS
            string rpta = "";

            //DataTable dtCuentas = new DataTable("dtCuentas");
            //dtCuentas.Columns.Add("Nombre_cliente", typeof(string));
            //dtCuentas.Columns.Add("Tipo_pago", typeof(string));
            //dtCuentas.Columns.Add("Fecha_pago", typeof(string));
            //dtCuentas.Columns.Add("Total_pago", typeof(string));

            DataTable dtPagos =
                    EPago_cuenta.BuscarPagoCuentas("FECHA CAJA", eCierre.Fecha_cierre.ToString("yyyy-MM-dd"), out rpta);
            decimal total_pagos = 0;
            if (dtPagos != null)
            {
                foreach (DataRow row in dtPagos.Rows)
                {
                    decimal recaudo = Convert.ToDecimal(row["Total_pagar"]);
                    total_pagos += recaudo;

                    //DataRow newRow = dtCuentas.NewRow();
                    //newRow["Nombre_cliente"] = Convert.ToString(row["Nombres"]) + Convert.ToString(row["Apellidos"]);
                    //newRow["Tipo_pago"] = "PAGO COMPLETO";
                    //newRow["Fecha_pago"] = Convert.ToString(row["Fecha_pago"]);
                    //newRow["Total_pago"] = "$" + recaudo.ToString("N2");
                    //dtCuentas.Rows.Add(newRow);
                }
            }

            decimal total_abonos = 0;
            DataTable dtAbonos =
                EDetalleAbonosCuentas.BuscarAbonos("FECHA ABONO", eCierre.Fecha_cierre.ToString("yyyy-MM-dd"), out rpta);
            if (dtAbonos != null)
            {
                foreach (DataRow row in dtAbonos.Rows)
                {
                    decimal recaudo = Convert.ToDecimal(row["Valor_abono"]);
                    total_abonos += recaudo;

                    //DataRow newRow = dtCuentas.NewRow();
                    //newRow["Nombre_cliente"] = Convert.ToString(row["Nombres"]) + Convert.ToString(row["Apellidos"]);
                    //newRow["Tipo_pago"] = "ABONO";
                    //newRow["Fecha_pago"] = Convert.ToString(row["Fecha_abono"]);
                    //newRow["Total_pago"] = "$" + recaudo.ToString("N2");
                    //dtCuentas.Rows.Add(newRow);
                }
            }

            decimal totalGastos = 0;
            DataTable dtGastos = EHistorialGastos.BuscarHistorialGastos("FECHA",
                eCierre.Fecha_cierre.ToString("yyyy-MM-dd"), out rpta);
            if (dtGastos != null)
            {
                foreach (DataRow row in dtGastos.Rows)
                {
                    EHistorialGastos eHistorial = new EHistorialGastos(row);

                    totalGastos += eHistorial.Valor_gasto;

                    //DataRow newRow = dtCuentas.NewRow();
                    //newRow["Nombre_cliente"] = eHistorial.EEmpleado.Nombre_completo;
                    //newRow["Tipo_pago"] = "GASTO";
                    //newRow["Fecha_pago"] = eHistorial.Fecha_gasto.ToString("yyyy-MM-dd");
                    //newRow["Total_pago"] = "$" + eHistorial.Valor_gasto.ToString("N2");
                    //dtCuentas.Rows.Add(newRow);
                }
            }

            decimal Valor_total_excedentes = 0;
            decimal Valor_total_x_base = 0;

            if (dtPagos != null)
            {
                foreach (DataRow row in dtPagos.Rows)
                {
                    int id_cuenta = Convert.ToInt32(row["Id_cuenta"]);
                    DataTable dtLecturaCuenta = ELecturas.BuscarLecturas("ID CUENTA", id_cuenta.ToString(), out rpta);
                    if (dtLecturaCuenta != null)
                    {
                        ELecturas eLectura = new ELecturas(dtLecturaCuenta, 0);
                        int consumo_excedido = eLectura.Consumo_excedido;
                        EDetalleTarifas eDetalleTarifa = eLectura.ETarifas.EDetalleTarifa;
                        CalculadoraExcedentes calculadora = new CalculadoraExcedentes();
                        calculadora.IsReporte = true;
                        calculadora.AsignarDatos(eDetalleTarifa, consumo_excedido);
                        if (consumo_excedido > 0)
                        {
                            Valor_total_excedentes += calculadora.Total_excedente;
                            Valor_total_x_base += eDetalleTarifa.Valor_base;
                        }
                        else
                            Valor_total_x_base += calculadora.Total_excedente;
                    }
                    else
                    {
                        if (!rpta.Equals("OK"))
                            throw new Exception(rpta);
                    }
                }
            }
            #endregion

            StringBuilder builder = new StringBuilder();
            builder.Append("Valor inicial: $").Append(eCierre.EApertura.Valor_inicial.ToString("N2"));
            builder.Append(Environment.NewLine);
            builder.Append("Total recaudado por base: $").Append(Valor_total_x_base.ToString("N2"));
            builder.Append(Environment.NewLine);
            builder.Append("Total recaudado por exceso: $").Append(Valor_total_excedentes.ToString("N2"));
            builder.Append(Environment.NewLine);
            builder.Append("Total de abonos: $").Append(total_abonos.ToString("N2"));
            builder.Append(Environment.NewLine);
            builder.Append("Total de pagos: $").Append(total_pagos.ToString("N2"));
            builder.Append(Environment.NewLine);
            builder.Append("Total de gastos: $").Append(totalGastos.ToString("N2"));
            builder.Append(Environment.NewLine);
            builder.Append("Total gastos - cobros: $").Append(((total_pagos + total_abonos)- totalGastos).ToString("N2"));
            builder.Append(Environment.NewLine);

            parameters[3] = new ReportParameter("Informacion", builder.ToString());

            this.reportViewer1.Dock = DockStyle.Fill;
            this.Controls.Add(this.reportViewer1);

            this.reportViewer1.LocalReport.ReportEmbeddedResource =
                "CapaPresentacionAdministracion.Formularios.FormsCajas.rptCierreCaja.rdlc";

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
