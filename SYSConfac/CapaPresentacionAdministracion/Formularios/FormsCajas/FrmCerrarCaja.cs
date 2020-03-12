using CapaEntidades;
using CapaPresentacionAdministracion.Formularios.FormsPrincipales;
using CapaPresentacionAdministracion.Servicios;
using System;
using System.Data;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacionAdministracion.Formularios.FormsCajas
{
    public partial class FrmCerrarCaja : Form
    {
        public FrmCerrarCaja()
        {
            InitializeComponent();
            this.btnCerrarCaja.Click += BtnCerrarCaja_Click;
            this.btnVerDetalles.Click += BtnVerDetalles_Click;
            this.rdRetirarTodo.CheckedChanged += RdRetirarTodo_CheckedChanged;
            this.rdDejarDeposito.CheckedChanged += RdRetirarTodo_CheckedChanged;
            this.rdDejarTodo.CheckedChanged += RdRetirarTodo_CheckedChanged;
            this.Load += FrmCerrarCaja_Load;

            this.btnImprimir.Click += BtnImprimir_Click;
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            if (this.Comprobaciones(out ECierre eCierre))
            {
                if (rdVistaPrevia.Checked)
                {
                    MensajeEspera.ShowWait("Imprimiendo...");

                    FrmReporteCierreCaja FrmReporteCierreCaja = new FrmReporteCierreCaja
                    {
                        WindowState = FormWindowState.Maximized
                    };
                    FrmReporteCierreCaja.AsignarReporte(eCierre);
                    FrmReporteCierreCaja.Show();
                    FrmReporteCierreCaja.Activate();

                    MensajeEspera.CloseForm();
                }
                else if (rdImpresionDirecta.Checked)
                {
                    MensajeEspera.ShowWait("Imprimiendo...");
                    FrmReporteCierreCaja FrmReporteCierreCaja = new FrmReporteCierreCaja
                    {
                        WindowState = FormWindowState.Maximized
                    };
                    FrmReporteCierreCaja.AsignarReporte(eCierre);
                    FrmReporteCierreCaja.Imprimir();

                    MensajeEspera.CloseForm();
                }
            }
        }

        private void FrmCerrarCaja_Load(object sender, EventArgs e)
        {
            DatosInicioSesion datosInicioSesion = DatosInicioSesion.GetInstancia();

            FrmVerificacion frmVerificacion = new FrmVerificacion
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            frmVerificacion.AsignarDatos(datosInicioSesion.EEmpleado);
            frmVerificacion.OnLogin += FrmVerificacion_OnLogin;
            frmVerificacion.ShowDialog();

            if (this.txtEmpleado.Tag == null)
            {
                Mensajes.MensajeInformacion("No se pudo comprobar la identidad del empleado, no se puede cerrar la caja", "Entendido");
                this.Close();
            }
        }

        private void FrmVerificacion_OnLogin(object sender, EventArgs e)
        {
            EEmpleado eEmpleado = (EEmpleado)sender;
            this.txtEmpleado.Text = eEmpleado.Nombre_completo;
            this.txtEmpleado.Tag = eEmpleado.Id_empleado;
        }

        private void RdRetirarTodo_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rd = (RadioButton)sender;
            if (rd.Checked)
            {
                if (rd.Name.Equals("rdRetirarTodo"))
                {
                    this.gbDeposito.Visible = false;
                    this.txtValorRetirar.Text = "$" + this.Total_caja.ToString("N2");
                }
                else if (rd.Name.Equals("rdDejarDeposito"))
                {
                    this.txtDeposito.KeyPress += TxtDeposito_KeyPress;
                    this.txtDeposito.GotFocus += TxtDeposito_GotFocus;
                    this.txtDeposito.LostFocus += TxtDeposito_LostFocus;
                    this.txtDeposito.Click += TxtDeposito_Click;
                    this.gbDeposito.Visible = true;
                    this.txtDeposito.Text = "0";
                    this.txtDeposito.SelectAll();
                }
                else
                {
                    this.gbDeposito.Visible = false;
                    this.txtValorRetirar.Text = "$0";
                }
            }
        }

        private bool ComprobacionDeposito()
        {
            if (this.rdDejarTodo.Checked)
            {
                this.txtValorRetirar.Text = "$0";
                this.Deposito = this.Total_caja;
                return true;
            }

            if (rdRetirarTodo.Checked)
            {
                this.txtValorRetirar.Text = "$" + this.Total_caja.ToString("N2");
                this.Deposito = 0;
                return true;
            }

            if (rdDejarDeposito.Checked)
            {
                if (decimal.TryParse(this.txtDeposito.Text, out decimal valor_deposito))
                {
                    if ((int)valor_deposito == 0)
                    {
                        Mensajes.MensajeInformacion("El deposito a realizar debe ser mayor que 0", "Entendido");
                        this.txtDeposito.SelectAll();
                        return false;
                    }
                    else
                    {
                        if (valor_deposito > this.Total_caja)
                        {
                            Mensajes.MensajeInformacion("El deposito a realizar debe ser menor que la cantidad en caja",
                                "Entendido");
                            this.txtDeposito.SelectAll();
                            return false;
                        }
                        else
                        {
                            decimal retirarCaja = this.Total_caja - valor_deposito;
                            this.txtValorRetirar.Text = "$" + retirarCaja.ToString("N2");
                            this.Deposito = valor_deposito;
                            return true;
                        }
                    }
                }
                else
                {
                    this.txtDeposito.SelectAll();
                    return false;
                }
            }

            return true;
        }

        private void TxtDeposito_Click(object sender, EventArgs e)
        {
            this.txtValorInicial.SelectAll();
        }

        private void TxtDeposito_LostFocus(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (txt.Text.Equals(""))
                txt.Text = "0";
        }

        private void TxtDeposito_GotFocus(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.SelectAll();
        }

        private void TxtDeposito_KeyPress(object sender, KeyPressEventArgs e)
        {
            CultureInfo cc = Thread.CurrentThread.CurrentCulture;
            if (e.KeyChar.ToString() == cc.NumberFormat.NumberDecimalSeparator ||
                char.IsDigit(e.KeyChar) ||
                (int)e.KeyChar == (int)Keys.Back)
            {
                if ((int)e.KeyChar == (int)Keys.Enter)
                    this.ComprobacionDeposito();
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void BtnVerDetalles_Click(object sender, EventArgs e)
        {
            FrmDetallesDia frmDetallesDia = new FrmDetallesDia
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            frmDetallesDia.BuscarDetalles(dtPagos, dtAbonos, dtGastos);
            frmDetallesDia.ShowDialog();
        }

        public event EventHandler OnCajaModified;

        private bool Comprobaciones(out ECierre eCierre)
        {
            eCierre = new ECierre();
            if (this.ComprobacionDeposito())
            {
                eCierre.EEmpleado = new EEmpleado
                {
                    Id_empleado = Convert.ToInt32(this.txtEmpleado.Tag)
                };
                eCierre.EApertura = this.EApertura;
                eCierre.Fecha_cierre = DateTime.Now;
                eCierre.Hora_cierre = DateTime.Now.ToString("HH:mm");
                eCierre.Deposito = this.Deposito;
                eCierre.Observaciones = "";
                return true;
            }
            return false;

        }

        private void BtnCerrarCaja_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Comprobaciones(out ECierre eCierre))
                {
                    string rpta = ECierre.InsertarCierre(eCierre);
                    if (rpta.Equals("OK"))
                    {
                        Mensajes.MensajeOkForm("Se cerró la caja correctamente");
                        OnCajaModified?.Invoke(eCierre, e);

                        if (rdVistaPrevia.Checked)
                        {
                            MensajeEspera.ShowWait("Imprimiendo...");

                            FrmReporteCierreCaja FrmReporteCierreCaja = new FrmReporteCierreCaja
                            {
                                WindowState = FormWindowState.Maximized
                            };
                            FrmReporteCierreCaja.AsignarReporte(eCierre);
                            FrmReporteCierreCaja.Show();
                            FrmReporteCierreCaja.Activate();
                        }
                        else if (rdImpresionDirecta.Checked)
                        {
                            MensajeEspera.ShowWait("Imprimiendo...");
                            FrmReporteCierreCaja FrmReporteCierreCaja = new FrmReporteCierreCaja
                            {
                                WindowState = FormWindowState.Maximized
                            };
                            FrmReporteCierreCaja.AsignarReporte(eCierre);
                            FrmReporteCierreCaja.Imprimir();
                        }

                        if (chkCorreo.Checked)
                        {
                            HelperMail helperMail = new HelperMail();
                            helperMail.SendEmailCierreCaja("Cierre de caja " + DateTime.Now.ToLongDateString() +
                                " - Hora: " + DateTime.Now.ToLongTimeString(), this.InformacionCaja, out rpta);
                            if (rpta.Equals("OK"))
                            {
                                Mensajes.MensajeOkForm("¡Se envió el reporte de caja correctamente!");
                            }
                            else
                                throw new Exception(rpta);
                        }
                        MensajeEspera.CloseForm();
                        this.Close();
                    }
                    else
                        throw new Exception(rpta);
                }
                else
                    Mensajes.MensajeInformacion("Hubo un error, por favor verifique los datos", "Entendido");
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnCerrarCaja_Click",
                    "Hubo un error al cerrar la caja", ex.Message);
            }
        }

        public void AsignarDatos(ECierre eCierre)
        {
            ECaja eCaja = eCierre.EApertura.ECaja;
            this.txtCaja.Text = eCaja.Nombre_caja;
            this.txtCaja.Tag = eCaja.Id_caja;

            this.txtFechaHora.Text = eCierre.Fecha_cierre.ToLongDateString();

            DataTable dtCaja =
                EApertura.BuscarAperturas("ID CAJA", eCaja.Id_caja.ToString(), out string rpta);
            if (dtCaja != null)
            {
                EApertura eApertura = new EApertura(dtCaja, 0);
                this.EApertura = eApertura;
                this.txtValorInicial.Text = "$" + eApertura.Valor_inicial.ToString("N2");
                DataTable dtPagos =
                    EPago_cuenta.BuscarPagoCuentas("FECHA CAJA", DateTime.Now.ToString("yyyy-MM-dd"), out rpta);
                decimal total_recaudo = 0;

                if (dtPagos != null)
                {
                    this.dtPagos = dtPagos;
                    foreach (DataRow row in dtPagos.Rows)
                    {
                        decimal recaudo = Convert.ToDecimal(row["Total_pagar"]);
                        total_recaudo += recaudo;
                    }
                }

                DataTable dtAbonos =
                    EDetalleAbonosCuentas.BuscarAbonos("FECHA ABONO", eApertura.Fecha.ToString("yyyy-MM-dd"), out rpta);
                if (dtAbonos != null)
                {
                    this.dtAbonos = dtAbonos;
                    foreach (DataRow row in dtAbonos.Rows)
                    {
                        decimal recaudo = Convert.ToDecimal(row["Valor_abono"]);
                        total_recaudo += recaudo;
                    }
                }

                decimal totalGastos = 0;
                DataTable dtGastos = EHistorialGastos.BuscarHistorialGastos("FECHA",
                    eCierre.Fecha_cierre.ToString("yyyy-MM-dd"), out rpta);
                if (dtGastos != null)
                {
                    foreach (DataRow row in dtGastos.Rows)
                    {
                        totalGastos += Convert.ToDecimal(row["Valor_gasto"]);
                    }
                }

                this.txtGastos.Text = "$" + totalGastos.ToString("N2");

                total_recaudo -= totalGastos;

                this.Total_recaudo = total_recaudo;
                this.txtValorRecaudo.Text = "$" + total_recaudo.ToString("N2");

                this.txtTotalCaja.Text = "$" + (total_recaudo + eApertura.Valor_inicial).ToString("N2");
                this.Total_caja = total_recaudo + eApertura.Valor_inicial;

                this.rdDejarTodo.Checked = true;
                this.gbDeposito.Visible = false;
                this.txtValorRetirar.Text = "$0";


                this.btnCerrarCaja.Visible = false;
                this.groupBox6.Enabled = false;
                this.gbValorRetirar.Visible = false;
            }
            else
            {
                Mensajes.MensajeErrorForm("No se encontró ninguna caja a cerrar");
            }
        }

        public void AsignarDatos(ECaja eCaja)
        {
            this.txtCaja.Text = eCaja.Nombre_caja;
            this.txtCaja.Tag = eCaja.Id_caja;

            this.txtFechaHora.Text = DateTime.Now.ToLongDateString() + " - " +
                DateTime.Now.ToLongTimeString();

            DataTable dtCaja =
                EApertura.BuscarAperturas("ID CAJA", eCaja.Id_caja.ToString(), out string rpta);
            if (dtCaja != null)
            {
                EApertura eApertura = new EApertura(dtCaja, 0);
                this.EApertura = eApertura;
                this.txtValorInicial.Text = "$" + eApertura.Valor_inicial.ToString("N2");
                DataTable dtPagos =
                    EPago_cuenta.BuscarPagoCuentas("FECHA CAJA", DateTime.Now.ToString("yyyy-MM-dd"), out rpta);
                decimal total_recaudo = 0;

                if (dtPagos != null)
                {
                    this.dtPagos = dtPagos;
                    foreach (DataRow row in dtPagos.Rows)
                    {
                        decimal recaudo = Convert.ToDecimal(row["Total_pagar"]);
                        total_recaudo += recaudo;
                    }
                }

                DataTable dtAbonos =
                    EDetalleAbonosCuentas.BuscarAbonos("FECHA ABONO", eApertura.Fecha.ToString("yyyy-MM-dd"), out rpta);
                if (dtAbonos != null)
                {
                    this.dtAbonos = dtAbonos;
                    foreach (DataRow row in dtAbonos.Rows)
                    {
                        decimal recaudo = Convert.ToDecimal(row["Valor_abono"]);
                        total_recaudo += recaudo;
                    }
                }

                decimal totalGastos = 0;
                DataTable dtGastos = EHistorialGastos.BuscarHistorialGastos("FECHA",
                    eApertura.Fecha.ToString("yyyy-MM-dd"), out rpta);
                if (dtGastos != null)
                {
                    this.dtGastos = dtGastos;
                    foreach (DataRow row in dtGastos.Rows)
                    {
                        totalGastos += Convert.ToDecimal(row["Valor_gasto"]);
                    }
                }

                this.txtGastos.Text = "$" + totalGastos.ToString("N2");

                total_recaudo -= totalGastos;

                this.Total_recaudo = total_recaudo;
                this.txtValorRecaudo.Text = "$" + total_recaudo.ToString("N2");

                this.txtTotalCaja.Text = "$" + (total_recaudo + eApertura.Valor_inicial).ToString("N2");
                this.Total_caja = total_recaudo + eApertura.Valor_inicial;

                this.rdDejarTodo.Checked = true;
                this.gbDeposito.Visible = false;
                this.txtValorRetirar.Text = "$0";
            }
            else
            {
                Mensajes.MensajeErrorForm("No se encontró ninguna caja a cerrar");
            }
        }

        private bool _isObservar;
        private decimal _total_recaudo;
        private decimal _total_caja;
        private decimal _deposito;
        private EApertura _eApertura;
        private string _informacionCaja;

        DataTable dtGastos = null;
        DataTable dtPagos = null;
        DataTable dtAbonos = null;

        public decimal Total_recaudo { get => _total_recaudo; set => _total_recaudo = value; }
        public decimal Total_caja { get => _total_caja; set => _total_caja = value; }
        public EApertura EApertura { get => _eApertura; set => _eApertura = value; }
        public decimal Deposito { get => _deposito; set => _deposito = value; }
        public bool IsObservar { get => _isObservar; set => _isObservar = value; }
        public string InformacionCaja
        {
            get => _informacionCaja;
            set
            {
                _informacionCaja = value.Replace("\r\n", "<br />");
            }
        }
    }
}
