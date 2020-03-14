using CapaEntidades;
using CapaPresentacionAdministracion.Formularios.FormsClientes;
using CapaPresentacionAdministracion.Formularios.FormsExcedentes;
using CapaPresentacionAdministracion.Formularios.FormsLecturas;
using CapaPresentacionAdministracion.Formularios.FormsTarifas;
using CapaPresentacionAdministracion.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacionAdministracion.Formularios.FormsReportes
{
    public partial class FrmReportes : Form
    {
        PoperContainer container;
        public FrmReportes()
        {
            InitializeComponent();
            this.btnMes.Click += BtnMes_Click;
            this.rdPagosCliente.CheckedChanged += RdPagosCliente_CheckedChanged;
            this.rdRecaudoTarifa.CheckedChanged += RdPagosCliente_CheckedChanged;
            this.rdTodo.CheckedChanged += RdPagosCliente_CheckedChanged;
            this.btnBuscar.Click += BtnBuscar_Click;
            this.btnSeleccionar.Click += BtnSeleccionar_Click;

            this.btnImprimirReporte.Click += BtnImprimirReporte_Click;

            this.rdConsumoAgua.CheckedChanged += RdConsumoAgua_CheckedChanged;
        }

        private void RdConsumoAgua_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rd = (RadioButton)sender;
            if (rd.Checked)
                this.btnSeleccionar.Enabled = false;
            else
                this.btnSeleccionar.Enabled = true;
        }

        private void BtnImprimirReporte_Click(object sender, EventArgs e)
        {
            if (this.panel1.Controls.Count > 0)
            {
                MensajeEspera.ShowWait("Imprimiendo...");
                FrmImpresionReporte frmImpresionReporte = new FrmImpresionReporte
                {
                    StartPosition = FormStartPosition.CenterScreen
                };
                frmImpresionReporte.AsignarReporte(DateTime.Now, this.txtResumen.Text);
                frmImpresionReporte.Imprimir();
                MensajeEspera.CloseForm();
            }
        }

        private void BtnSeleccionar_Click(object sender, EventArgs e)
        {
            string tipo_busqueda = this.ObtenerValorRadios(this.gbFiltros);
            if (tipo_busqueda.Equals("CLIENTE"))
            {
                FrmObservarClientes frmObservarClientes = new FrmObservarClientes
                {
                    StartPosition = FormStartPosition.CenterScreen
                };
                frmObservarClientes.OnDgvDoubleClick += FrmObservarClientes_OnDgvDoubleClick;
                frmObservarClientes.ShowDialog();
            }
            else if (tipo_busqueda.Equals("TARIFA"))
            {
                FrmObservarTarifas frmObservarTarifas = new FrmObservarTarifas
                {
                    StartPosition = FormStartPosition.CenterScreen
                };
                frmObservarTarifas.OnDgvDoubleClick += FrmObservarTarifas_OnDgvDoubleClick;
                frmObservarTarifas.ShowDialog();
            }
        }

        private void FrmObservarTarifas_OnDgvDoubleClick(object sender, EventArgs e)
        {
            ETarifas eTarifas = (ETarifas)sender;
            this.btnSeleccionar.Text = eTarifas.Descripcion;
            this.btnSeleccionar.Tag = eTarifas.Id_tarifa;
        }

        private void FrmObservarClientes_OnDgvDoubleClick(object sender, EventArgs e)
        {
            ECliente eCliente = (ECliente)sender;
            this.btnSeleccionar.Text = eCliente.Nombres + " " + eCliente.Apellidos;
            this.btnSeleccionar.Tag = eCliente.Id_cliente;
        }

        private string ObtenerValorRadios(GroupBox gb)
        {
            string tipo = "";
            foreach (Control control in gb.Controls)
            {
                if (control is RadioButton rd)
                {
                    if (rd.Checked)
                    {
                        tipo = Convert.ToString(rd.Tag).ToUpper();
                        break;
                    }
                }
            }
            return tipo;
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string tipo_busqueda = this.ObtenerValorRadios(this.gbFiltros);

                if (this.btnMes.Tag == null)
                {
                    Mensajes.MensajeInformacion("Seleccione un mes", "Entendido");
                    return;
                }

                int id_cliente = 0;
                if (tipo_busqueda.Equals("CLIENTE"))
                {
                    if (this.btnSeleccionar.Tag == null)
                    {
                        Mensajes.MensajeInformacion("Seleccione un cliente", "Entendido");
                        return;
                    }
                    else
                    {
                        id_cliente = Convert.ToInt32(this.btnSeleccionar.Tag);
                        this.BuscarPagos("PAGOS CLIENTE FECHA", id_cliente.ToString());
                        return;
                    }
                }

                int id_tarifa = 0;
                if (tipo_busqueda.Equals("TARIFA"))
                {
                    if (this.btnSeleccionar.Tag == null)
                    {
                        Mensajes.MensajeInformacion("Seleccione una tarifa", "Entendido");
                        return;
                    }
                    else
                    {
                        id_tarifa = Convert.ToInt32(this.btnSeleccionar.Tag);
                        this.BuscarPagos("PAGOS TARIFA FECHA", id_tarifa.ToString());
                        return;
                    }
                }

                if (tipo_busqueda.Equals("TODO"))
                {
                    this.BuscarPagos("TODO FECHA", "");
                    return;
                }

                if (tipo_busqueda.Equals("CONSUMO DE AGUA"))
                {
                    int numero_mes = Convert.ToInt32(this.btnMes.Tag);
                    this.BuscarPagos(tipo_busqueda, numero_mes.ToString());
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnBuscar_Click",
                    "Hubo un error al buscar reportes", ex.Message);
            }
        }

        private void RdPagosCliente_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rd = (RadioButton)sender;
            if (rd.Checked)
            {
                if (rd.Name.Equals("rdPagosCliente"))
                {
                    this.btnSeleccionar.Text = "Seleccionar cliente";
                    this.btnSeleccionar.Enabled = true;
                    this.btnSeleccionar.Image = Resources.BuscarUser34;
                }
                else if (rd.Name.Equals("rdRecaudoTarifa"))
                {
                    this.btnSeleccionar.Text = "Seleccionar tarifa";
                    this.btnSeleccionar.Enabled = true;
                    this.btnSeleccionar.Image = Resources.textx24;
                }
                else
                {
                    this.btnSeleccionar.Enabled = false;
                }
            }
        }

        private void BtnMes_Click(object sender, EventArgs e)
        {
            ListaMeses listaMeses = new ListaMeses
            {
                MaxMonth = 12
            };
            listaMeses.OnBtnMesClick += ListaMeses_OnBtnMesClick;
            this.container = new PoperContainer(listaMeses);
            this.container.Show(this.btnMes);
        }

        private int Mes_selected;

        private void ListaMeses_OnBtnMesClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            this.Mes_selected = Convert.ToInt32(btn.Tag);
            this.btnMes.Text = btn.Text;
            this.btnMes.Tag = this.Mes_selected;
        }

        int positionChanged = 1;

        private void BuscarPagos(string tipo_busqueda, string texto_busqueda1)
        {
            try
            {
                MensajeEspera.ShowWait("Cargando...");

                int mes = this.Mes_selected;

                DateTime fecha1 = new DateTime(DateTime.Now.Year, mes, 1);
                DateTime fecha2 = new DateTime(DateTime.Now.Year, mes,
                    DateTime.DaysInMonth(DateTime.Now.Year, mes));
                DataTable dtPagos = EPago_cuenta.BuscarReportes(tipo_busqueda,
                    texto_busqueda1, fecha1.ToString("yyyy-MM-dd"), fecha2.ToString("yyyy-MM-dd"),
                    out string rpta);
                this.panel1.clearDataSource();
                this.positionChanged = 1;
                if (dtPagos != null)
                {
                    DataTable dtReporte = new DataTable("Reporte");
                    dtReporte.Columns.Add("Id", typeof(string));
                    dtReporte.Columns.Add("Tipo", typeof(string));

                    decimal total = 0;
                    foreach (DataRow row in dtPagos.Rows)
                    {
                        EPago_cuenta pago = new EPago_cuenta(row);
                        DataRow addrow = dtReporte.NewRow();
                        addrow["Id"] = pago.Id_pago.ToString();
                        addrow["Tipo"] = "PAGO";
                        dtReporte.Rows.Add(addrow);

                        total += pago.ECuenta.Total_pagar;
                    }

                    decimal totalGastos = 0;
                    DataTable dtGastos = EHistorialGastos.BuscarHistorialGastos("MES", mes.ToString(), out rpta);
                    if (dtGastos != null)
                    {
                        foreach (DataRow row in dtGastos.Rows)
                        {
                            totalGastos += Convert.ToDecimal(row["Valor_gasto"]);
                        }
                    }

                    StringBuilder resumen = new StringBuilder();
                    if (tipo_busqueda.Equals("PAGOS CLIENTE FECHA"))
                    {
                        #region PAGOS CLIENTE FECHA
                        ECliente eCliente = new ECliente(Convert.ToInt32(texto_busqueda1));
                        DataTable dtAbonos = EDetalleAbonosCuentas.BuscarAbonos("ID CLIENTE",
                        texto_busqueda1, out rpta);
                        if (dtAbonos != null)
                        {
                            foreach (DataRow row in dtAbonos.Rows)
                            {
                                EDetalleAbonosCuentas eAbonos = new EDetalleAbonosCuentas(row);

                                DataRow addrow = dtReporte.NewRow();
                                addrow["Id"] = eAbonos.Id_abono.ToString();
                                addrow["Tipo"] = "ABONO";
                                dtReporte.Rows.Add(row);

                                total += eAbonos.Valor_abono;
                            }
                        }

                        resumen.Append("En el mes de " + this.btnMes.Text + " ");
                        resumen.Append("el cliente " + eCliente.Nombres + " " + eCliente.Apellidos + " ");

                        if (dtPagos.Rows.Count > 1)
                            resumen.Append("realizó " + dtPagos.Rows.Count + " pagos.");
                        else
                            resumen.Append("realizó un pago.");

                        resumen.Append(Environment.NewLine);

                        if (dtAbonos != null)
                        {
                            if (dtAbonos.Rows.Count > 1)
                                resumen.Append("Realizó " + dtAbonos.Rows.Count + " abonos. ");
                            else
                                resumen.Append("Realizó un abono. ");
                        }
                        else
                            resumen.Append("No se realizaron abonos a ninguna cuenta. ");

                        resumen.Append(Environment.NewLine);
                        resumen.Append("En total el cliente pagó $" + total.ToString("N2"));
                        #endregion
                    }
                    else if (tipo_busqueda.Equals("PAGOS TARIFA FECHA"))
                    {
                        ETarifas eTarifas = new ETarifas(Convert.ToInt32(texto_busqueda1));
                        resumen.Append("En el mes de " + this.btnMes.Text + " ");
                        resumen.Append("se realizaron " + dtPagos.Rows.Count + " pagos por concepto de ");
                        resumen.Append(eTarifas.Descripcion + ". ");
                        resumen.Append(Environment.NewLine);
                        resumen.Append("El total recaudado es de $" + total.ToString("N2"));
                        resumen.Append(Environment.NewLine);
                        resumen.Append("El total de gastos es de $" + totalGastos.ToString("N2"));
                    }
                    else if (tipo_busqueda.Equals("TODO FECHA"))
                    {
                        resumen.Append("En el mes de " + this.btnMes.Text + " ");
                        resumen.Append("se realizaron " + dtPagos.Rows.Count + " pagos. ");
                        resumen.Append(Environment.NewLine);
                        resumen.Append("El total recaudado es de $" + total.ToString("N2"));
                        resumen.Append(Environment.NewLine);
                        resumen.Append("El total de gastos es de $" + totalGastos.ToString("N2"));
                    }
                    else if (tipo_busqueda.Equals("CONSUMO DE AGUA"))
                    {
                        decimal Valor_total_excedentes = 0;
                        decimal Valor_total_x_base = 0;
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
                                calculadora.AsignarDatos(eDetalleTarifa, consumo_excedido);
                                if (consumo_excedido > 0)
                                    Valor_total_excedentes += calculadora.Total_excedente;
                                else
                                    Valor_total_x_base += calculadora.Total_excedente;
                            }
                            else
                            {
                                if (!rpta.Equals("OK"))
                                    throw new Exception(rpta);
                            }
                        }
                        resumen.Append("En el mes de " + this.btnMes.Text + " ");
                        resumen.Append("se realizaron " + dtPagos.Rows.Count + " pagos. ");
                        resumen.Append(Environment.NewLine);
                        resumen.Append("El total recaudado es de $" + total.ToString("N2"));
                        resumen.Append(Environment.NewLine);
                        resumen.Append("El total recaudado por excedentes es de $" + Valor_total_excedentes.ToString("N2"));
                        resumen.Append(Environment.NewLine);
                        resumen.Append("El total recaudado por base es de $" + Valor_total_x_base.ToString("N2"));
                        resumen.Append(Environment.NewLine);
                        resumen.Append("El total de gastos es de $" + totalGastos.ToString("N2"));
                    }

                    List<UserControl> controls = new List<UserControl>();
                    this.panel1.BackgroundImage = null;
                    this.panel1.PageSize = 30;
                    this.panel1.OnBsPositionChanged += Panel1_OnBsPositionChanged;
                    this.panel1.SetPagedDataSource(dtReporte, this.bindingNavigator1);
                    this.txtResumen.Text = Convert.ToString(resumen);
                }
                else
                {
                    this.txtResumen.Text = "No se encontró ninguna cuenta";
                    this.panel1.BackgroundImage = Resources.No_hay_cuentas_x2;

                    if (!rpta.Equals("OK"))
                        throw new Exception(rpta);
                }

                MensajeEspera.CloseForm();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BuscarPagos",
                    "Hubo un error al buscar pagos", ex.Message);
            }
        }

        private void Panel1_OnBsPositionChanged(object sender, EventArgs e)
        {
            if (positionChanged != this.panel1.bs.Position)
            {
                this.positionChanged = this.panel1.bs.Position;
                DataTable dtReporte = (DataTable)sender;
                List<UserControl> controls = new List<UserControl>();
                foreach (DataRow row in dtReporte.Rows)
                {
                    string tipo = Convert.ToString(row["Tipo"]);
                    int id = Convert.ToInt32(row["Id"]);
                    if (tipo.Equals("PAGO"))
                    {
                        EPago_cuenta ePago = new EPago_cuenta(id);
                        ReporteSmall reporteSmall = new ReporteSmall();
                        reporteSmall.AsignarDatos(ePago);
                        controls.Add(reporteSmall);
                    }
                    else
                    {
                        EDetalleAbonosCuentas eAbonos = new EDetalleAbonosCuentas(id);
                        ReporteSmall reporteSmall = new ReporteSmall();
                        reporteSmall.AsignarDatos(eAbonos);
                        controls.Add(reporteSmall);
                    }
                }
                this.panel1.AddArrayControl(controls);
            }
        }
    }
}
