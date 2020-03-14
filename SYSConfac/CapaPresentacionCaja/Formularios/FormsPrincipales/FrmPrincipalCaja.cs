using CapaEntidades;
using CapaPresentacionAdministracion;
using CapaPresentacionAdministracion.Formularios.FormsCajas;
using CapaPresentacionAdministracion.Formularios.FormsClientes;
using CapaPresentacionAdministracion.Formularios.FormsCuentas;
using CapaPresentacionAdministracion.Formularios.FormsGastos;
using CapaPresentacionAdministracion.Formularios.FormsPrincipales;
using CapaPresentacionCaja.Properties;
using System;
using System.Data;
using System.Windows.Forms;
using CapaPresentacionAdministracion.Formularios.FormsConfiguraciones.FormsConfiguraciones;
using System.Text;
using CapaPresentacionAdministracion.Servicios;

namespace CapaPresentacionCaja.Formularios.FormsPrincipales
{
    public partial class FrmPrincipalCaja : Form
    {
        public FrmPrincipalCaja()
        {
            InitializeComponent();
            this.Load += FrmPrincipalCaja_Load;
            this.btnAgregarCuenta.Click += BtnAgregarCuenta_Click;
            this.btnHistorialCuentas.Click += BtnHistorialCuentas_Click;
            this.btnCuentasPendientes.Click += BtnCuentasPendientes_Click;
            this.btnLock.Click += BtnLock_Click;
            this.btnAgregarGasto.Click += BtnAgregarGasto_Click;
            this.btnObservarGastosHoy.Click += BtnObservarGastosHoy_Click;
            this.btnObservarPagosHoy.Click += BtnObservarPagosHoy_Click;

            this.txtBusqueda.OnPxClick += TxtBusqueda_onPxClick;
            this.txtBusqueda.OnCustomKeyPress += TxtBusqueda_onKeyPress;

            this.btnHome.Click += BtnHome_Click;
            this.FormClosing += FrmPrincipalCaja_FormClosing;
            this.btnCorreo.Click += BtnCorreo_Click;
        }

        private void BtnCorreo_Click(object sender, EventArgs e)
        {
            HelperMail helperMail = new HelperMail();

            string info = this.txtInformacionCaja.Text;

            info = info.Replace("\r\n", "<br />");

            //StringBuilder info1 = new StringBuilder();
            //foreach (string c in info.Split('\r\n'))
            //{
            //    info1.Append(c).Append("<br />");
            //}

            //info = info1.ToString();

            helperMail.SendEmailCierreCaja("Cierre de caja " + DateTime.Now.ToLongDateString() +
                " - Hora: " + DateTime.Now.ToLongTimeString(), info, out string rpta);
            if (rpta.Equals("OK"))
            {
                Mensajes.MensajeOkForm("¡Se envió el reporte de caja correctamente!");
            }
            else
                throw new Exception(rpta);
        }

        private void BtnObservarPagosHoy_Click(object sender, EventArgs e)
        {
            DataTable dtPagos =
                   EPago_cuenta.BuscarPagoCuentas("FECHA CAJA", DateTime.Now.ToString("yyyy-MM-dd"), out string rpta);
            decimal total_recaudo = 0;

            if (dtPagos != null)
            {
                foreach (DataRow row in dtPagos.Rows)
                {
                    decimal recaudo = Convert.ToDecimal(row["Total_pagar"]);
                    total_recaudo += recaudo;
                }
            }

            DataTable dtAbonos =
                EDetalleAbonosCuentas.BuscarAbonos("FECHA ABONO", DateTime.Now.ToString("yyyy-MM-dd"), out rpta);
            if (dtAbonos != null)
            {
                foreach (DataRow row in dtAbonos.Rows)
                {
                    decimal recaudo = Convert.ToDecimal(row["Valor_abono"]);
                    total_recaudo += recaudo;
                }
            }

            decimal totalGastos = 0;
            DataTable dtGastos = EHistorialGastos.BuscarHistorialGastos("FECHA",
                DateTime.Now.ToString("yyyy-MM-dd"), out rpta);
            if (dtGastos != null)
            {
                foreach (DataRow row in dtGastos.Rows)
                {
                    totalGastos += Convert.ToDecimal(row["Valor_gasto"]);
                }
            }

            FrmDetallesDia frmDetallesDia = new FrmDetallesDia
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            frmDetallesDia.BuscarDetalles(dtPagos, dtAbonos, dtGastos);
            frmDetallesDia.ShowDialog();
        }

        private void FrmPrincipalCaja_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.btnHome.PerformClick();
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            OnBtnHome?.Invoke(this, e);
        }

        public event EventHandler OnBtnHome;

        private void FrmPrincipalCaja_Load(object sender, EventArgs e)
        {
            VerificarCaja();
            this.txtBusqueda.txtBusqueda.Focus();
        }

        private void BuscarCobros(string texto_busqueda)
        {
            if (!texto_busqueda.Equals(""))
            {
                string tipo_busqueda;
                if (rdIdentificacion.Checked)
                {
                    tipo_busqueda = "IDENTIFICACION";

                    if (texto_busqueda.Length < 10 || texto_busqueda.Length > 14)
                    {
                        Mensajes.MensajeInformacion("La identificación debe ser entre 10 y 13 caractéres", "Entendido");
                        return;
                    }

                    FrmObservarCuentas frmObservarCuentas = new FrmObservarCuentas
                    {
                        WindowState = FormWindowState.Maximized,
                        IsCaja = this.IsCaja,
                        IsEditar = false
                    };
                    frmObservarCuentas.BuscarCuentas("IDENTIFICACION CLIENTE", texto_busqueda, "");
                    frmObservarCuentas.OnCuentaSuccess += FrmObservarCuentas_OnCuentaSuccess;
                    frmObservarCuentas.ShowDialog();

                }
                else if (rdMedidor.Checked)
                {
                    tipo_busqueda = "MEDIDOR";
                    FrmObservarCuentas frmObservarCuentas = new FrmObservarCuentas
                    {
                        WindowState = FormWindowState.Maximized,
                        IsCaja = this.IsCaja,
                        IsEditar = false
                    };
                    frmObservarCuentas.BuscarCuentas(tipo_busqueda, texto_busqueda, "");
                    frmObservarCuentas.OnCuentaSuccess += FrmObservarCuentas_OnCuentaSuccess;
                    frmObservarCuentas.ShowDialog();
                }
                else if (rdNombres.Checked)
                {
                    tipo_busqueda = "NOMBRE";
                    FrmObservarCuentas frmObservarCuentas = new FrmObservarCuentas
                    {
                        WindowState = FormWindowState.Maximized,
                        IsCaja = this.IsCaja,
                        IsEditar = false
                    };
                    frmObservarCuentas.BuscarCuentas(tipo_busqueda, texto_busqueda, "");
                    frmObservarCuentas.OnCuentaSuccess += FrmObservarCuentas_OnCuentaSuccess;
                    frmObservarCuentas.ShowDialog();
                }
            }
        }

        private void FrmObservarCuentas_OnCuentaSuccess(object sender, EventArgs e)
        {
            if (this.ECaja != null)
                this.ComprobarInformacion(this.ECaja.Id_caja);
        }

        private void TxtBusqueda_onKeyPress(object sender, KeyPressEventArgs e)
        {
            CustomTextBox txt = (CustomTextBox)sender;
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (!txt.Texto.Equals("") || !txt.Texto.Equals(txt.Texto_inicial))
                {
                    this.BuscarCobros(txt.Texto);
                }
            }
        }

        private void TxtBusqueda_onPxClick(object sender, EventArgs e)
        {
            CustomTextBox txt = (CustomTextBox)sender;
            if (!txt.Texto.Equals("") || !txt.Texto.Equals(txt.Texto_inicial))
            {
                this.BuscarCobros(txt.Texto);
            }
        }

        private void BtnObservarGastosHoy_Click(object sender, EventArgs e)
        {
            FrmObservarHistorialGastos FrmObservarHistorialGastos = new FrmObservarHistorialGastos
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            FrmObservarHistorialGastos.ShowDialog();
        }

        private void BtnAgregarGasto_Click(object sender, EventArgs e)
        {
            FrmAgregarHistorialGasto frmAgregarGasto = new FrmAgregarHistorialGasto
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            frmAgregarGasto.OnGastoSuccess += FrmAgregarGasto_OnGastoSuccess;
            frmAgregarGasto.ShowDialog();
        }

        private void FrmAgregarGasto_OnGastoSuccess(object sender, EventArgs e)
        {
            if (this.ECaja != null)
                this.ComprobarInformacion(this.ECaja.Id_caja);
        }

        private void BtnLock_Click(object sender, EventArgs e)
        {
            if (this.ECaja != null)
            {
                DatosInicioSesion datosInicio = DatosInicioSesion.GetInstancia();

                if (ECaja.Estado_caja.Equals("CERRADA"))
                {
                    FrmAbrirCaja frmAbrirCaja = new FrmAbrirCaja
                    {
                        StartPosition = FormStartPosition.CenterScreen
                    };
                    frmAbrirCaja.OnCajaModified += Frm_OnCajaModified;
                    frmAbrirCaja.AsignarDatos(this.ECaja, datosInicio.EEmpleado);
                    frmAbrirCaja.ShowDialog();
                }
                else
                {
                    FrmCerrarCaja frmCerrarCaja = new FrmCerrarCaja
                    {
                        StartPosition = FormStartPosition.CenterScreen,
                        InformacionCaja = this.txtInformacionCaja.Text
                    };
                    frmCerrarCaja.AsignarDatos(this.ECaja);
                    frmCerrarCaja.OnCajaModified += Frm_OnCajaModified;
                    frmCerrarCaja.ShowDialog();
                }
            }
            else
            {
                Mensajes.MensajeInformacion("No se pudo encontrar la caja a abrir, inicia nuevamente la aplicación", "Entendido");
            }
        }

        private void Frm_OnCajaModified(object sender, EventArgs e)
        {
            if (ECaja.Estado_caja.Equals("CERRADA"))
            {
                EApertura eApertura = (EApertura)sender;
                this.EApertura = eApertura;
                //this.SumarValor(eApertura.Valor_inicial);
                VerificarCaja();
            }
            else
            {
                ECierre eCierre = (ECierre)sender;
                if (this.ECaja != null)
                    this.ComprobarInformacion(this.ECaja.Id_caja);

                this.txtTitulo.Text = "Módulo de " + eCierre.EApertura.ECaja.Nombre_caja + " (Caja cerrada)";
                this.groupBox1.Enabled = false;
                this.btnLock.Image = Resources.unlock_32px;
                this.toolTip1.SetToolTip(btnLock, "Abrir caja");
                this.IsCaja = false;

                this.ECierre = eCierre;
            }
        }

        private void BtnCuentasPendientes_Click(object sender, EventArgs e)
        {
            FrmObservarCuentas frmObservarCuentas = new FrmObservarCuentas
            {
                WindowState = FormWindowState.Maximized,
                IsEditar = false,
                IsCaja = this.IsCaja
            };
            frmObservarCuentas.OnCuentaSuccess += FrmNuevaCuenta_OnCuentaSuccess;
            frmObservarCuentas.BuscarCuentas("PENDIENTE DE PAGO HOY", DateTime.Now.ToString("yyyy-MM-dd"), "");
            frmObservarCuentas.gbBusqueda.Visible = false;
            frmObservarCuentas.Show();
        }

        private void BtnHistorialCuentas_Click(object sender, EventArgs e)
        {
            FrmObservarCuentas frmObservarCuentas = new FrmObservarCuentas
            {
                WindowState = FormWindowState.Maximized,
                IsCaja = this.IsCaja,
                IsEditar = false
            };
            frmObservarCuentas.OnCuentaSuccess += FrmObservarCuentas_OnCuentaSuccess;
            frmObservarCuentas.Show();
        }

        private void BtnAgregarCuenta_Click(object sender, EventArgs e)
        {
            FrmObservarClientes frmObservarClientes = new FrmObservarClientes
            {
                StartPosition = FormStartPosition.CenterScreen,
                IsLectura = false
            };
            frmObservarClientes.OnDgvDoubleClick += FrmObservarClientes_OnDgvDoubleClick;
            frmObservarClientes.ShowDialog();
        }

        private void FrmObservarClientes_OnDgvDoubleClick(object sender, EventArgs e)
        {
            ECliente eCliente = (ECliente)sender;
            FrmNuevaCuenta frmNuevaCuenta = new FrmNuevaCuenta
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            frmNuevaCuenta.OnCuentaSuccess += FrmNuevaCuenta_OnCuentaSuccess;
            frmNuevaCuenta.AsignarDatos(eCliente);
            frmNuevaCuenta.ShowDialog();
        }

        private void FrmNuevaCuenta_OnCuentaSuccess(object sender, EventArgs e)
        {
            if (this.ECaja != null)
                this.ComprobarInformacion(this.ECaja.Id_caja);
        }

        ECaja ECaja;
        ECierre ECierre;
        EApertura EApertura;

        private void VerificarCaja()
        {
            try
            {
                int id_caja_principal = ConfigGeneral.Default.Id_caja_principal;
                DataTable dtCajas =
                    ECaja.BuscarCajas("ID CAJA", id_caja_principal.ToString(), out string rpta);
                if (dtCajas != null)
                {
                    ECaja eCaja = new ECaja(dtCajas, 0);
                    this.ECaja = eCaja;

                    if (eCaja.Estado_caja.Equals("CERRADA"))
                    {
                        this.txtTitulo.Text = "Módulo de " + eCaja.Nombre_caja + " (Caja cerrada)";
                        this.groupBox1.Enabled = false;
                        this.btnLock.Image = Resources.unlock_32px;
                        this.toolTip1.SetToolTip(btnLock, "Abrir caja");
                        this.IsCaja = false;
                    }
                    else
                    {
                        this.btnLock.Image = Resources.lock_32px;
                        this.txtTitulo.Text = "Módulo de " + eCaja.Nombre_caja + " (Caja abierta)";
                        this.groupBox1.Enabled = true;
                        this.toolTip1.SetToolTip(btnLock, "Cerrar caja");
                        this.IsCaja = true;

                        if (this.ECaja != null)
                            this.ComprobarInformacion(this.ECaja.Id_caja);
                    }

                    DatosInicioSesion datosInicioSesion = DatosInicioSesion.GetInstancia();
                    datosInicioSesion.ECaja = eCaja;
                }
                else
                {
                    if (!rpta.Equals("OK"))
                        throw new Exception(rpta);
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "VerificarCaja()",
                    "Hubo un error al buscar o recuperar las cajas de la base de datos, por favor seleccionela manualmente",
                    ex.Message);
                this.txtTitulo.Text = "Módulo de CAJA DESCONOCIDA (Caja cerrada)";
                this.groupBox1.Enabled = false;
                this.btnLock.Image = Resources.unlock_45px;
                this.toolTip1.SetToolTip(btnLock, "Abrir caja");
            }
        }

        private void ComprobarInformacion(int id_caja)
        {
            //Obtener última apertura para extraer su valor inicial
            DataTable dtApertura = EApertura.BuscarAperturas("ID CAJA", id_caja.ToString(), out string rpta);
            //Variable para almacenar el valor inicial de la apertura
            decimal valor_inicial = 0;
            EApertura eApertura = new EApertura();
            if (dtApertura != null)
            {
                eApertura = new EApertura(dtApertura, 0);
                if (eApertura.Fecha.ToString("yyyy-MM-dd") ==
                        DateTime.Now.ToString("yyyy-MM-dd"))
                {
                    valor_inicial = eApertura.Valor_inicial;
                }
            }
            else
                eApertura = null;
            //Variable para almacenar las cuentas de hoy
            decimal saldo_caja_hoy = valor_inicial;
            //Obtener último cierre
            DataTable dtHistorialCierres =
                         ECierre.BuscarCierres("ID CAJA", id_caja.ToString(), out rpta);
            ECierre eCierre = new ECierre();
            if (dtHistorialCierres != null)
            {
                //Obtener el último cierre realizado
                eCierre = new ECierre(dtHistorialCierres, 0);
                saldo_caja_hoy += eCierre.Deposito;
            }
            else
                eCierre = null;

            //Obtener gastos del mes
            DataTable dtGastos =
                         EHistorialGastos.BuscarHistorialGastos("MES", DateTime.Now.Month.ToString(), out rpta);
            decimal total_gastos = 0;
            int cantidad_gastos = 0;
            int cantidad_gastos_hoy = 0;
            decimal total_gastos_hoy = 0;
            if (dtGastos != null)
            {
                cantidad_gastos = dtGastos.Rows.Count;
                foreach (DataRow row in dtGastos.Rows)
                {
                    EHistorialGastos eHistorial = new EHistorialGastos(row);
                    total_gastos += eHistorial.Valor_gasto;

                    if (eHistorial.Fecha_gasto.ToString("yyyy-MM-dd").Equals(DateTime.Now.ToString("yyyy-MM-dd")))
                    {
                        cantidad_gastos_hoy += 1;
                        total_gastos_hoy += 1;
                    }
                }
            }

            //Obtener los pagos realizados hoy
            DataTable dtPagos =
                EPago_cuenta.BuscarPagoCuentas("ID CAJA FECHA", this.ECaja.Id_caja.ToString(), out rpta);
            decimal total_recaudado_hoy = 0;
            if (dtPagos != null)
            {
                foreach (DataRow row in dtPagos.Rows)
                {
                    decimal recaudo = Convert.ToDecimal(row["Total_pagar"]);
                    total_recaudado_hoy += recaudo;
                }
            }

            //Obtenemos la fecha de inicio y de fin del mes en el que estamos
            DateTime fechaInicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime fechaFin = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            //Buscar cuentas en el mes actual
            DataTable dtCuentas =
                ECuentas.BuscarCuentas("FECHAS", fechaInicio.ToString("yyyy-MM-dd"),
                fechaFin.ToString("yyyy-MM-dd"), out rpta);
            //Variable para almacenar el total que debemos cobrar en el mes
            decimal total_recaudar_mes = 0;
            //Variable para almacenar el total que llevamos cobrado en el mes
            decimal total_recaudado_mes = 0;
            //Si la cuentas es diferente de null
            if (dtCuentas != null)
            {
                //Obtener todos los abonos del sistema
                DataTable dtAbonos =
                EDetalleAbonosCuentas.BuscarAbonos("COMPLETO", "", out rpta);
                //Variable para almacenar el total de abonos para cada cuenta
                decimal total_abonos = 0;
                //Recorremos las cuentas
                foreach (DataRow row in dtCuentas.Rows)
                {
                    //Asignamos el total de la cuenta
                    decimal total_cuenta = Convert.ToDecimal(row["Total_pagar"]);
                    //Sumamos el total de la cuenta a el total a cobrar
                    total_recaudar_mes += total_cuenta;
                    //Asignamos el estado de la cuenta
                    string estado_cuenta = Convert.ToString(row["Estado_cuenta"]);
                    //Si el estado de la cuenta es terminado entonces sumaremos este valor al total que ya cobramos
                    //pero recordemos que hay cuentas que están en pendientes pero que tienen abonos
                    if (estado_cuenta.Equals("TERMINADO"))
                        total_recaudado_mes += total_cuenta;
                    else
                    {
                        //Obtenemos el id de la cuenta
                        int id_cuenta = Convert.ToInt32(row["Id_cuenta"]);
                        if (dtAbonos != null)
                        {
                            //Buscamos en todos los abonos el id de la cuenta que estamos recorriendo
                            DataRow[] rows = dtAbonos.Select(string.Format("Id_cuenta = {0}", id_cuenta));
                            if (rows.Length > 0)
                            {
                                //Recorremos los abonos
                                foreach (DataRow rowAbono in rows)
                                {
                                    //Asignamos el valor del abono
                                    decimal valorAbono = Convert.ToDecimal(rowAbono["Valor_abono"]);
                                    //Sumamos al total de abonos
                                    total_abonos += valorAbono;
                                }
                            }
                        }
                    }

                    //El total recaudado del mes se le suma el total de abonos
                    total_recaudado_mes += total_abonos;

                    if (dtAbonos != null)
                    {
                        //Buscamos en todos los abonos el id de la cuenta que estamos recorriendo
                        DataRow[] rows = dtAbonos.Select(string.Format("Fecha_abono = {0}", DateTime.Now.ToString("yyyy-MM-dd")));
                        if (rows.Length > 0)
                        {
                            //Recorremos los abonos
                            foreach (DataRow rowAbono in rows)
                            {
                                //Asignamos el valor del abono
                                decimal valorAbono = Convert.ToDecimal(rowAbono["Valor_abono"]);
                                //Sumamos al total de abonos
                                total_recaudado_hoy += valorAbono;
                            }
                        }
                    }
                }
                //Variable para almacenar lo que queda del total que debemos cobrar y lo que ya cobramos
                //El saldo recaudado es lo que falta por cobrar, por lo tanto es la renta de lo que hay que cobrar con lo cobrado
                decimal saldo_recaudado_mes = total_recaudar_mes - total_recaudado_mes;

                //Saldo en caja inicial
                decimal saldo_inicial = valor_inicial;
                //Variable para almacenar la información
                StringBuilder info = new StringBuilder();
                //Información del último cierre
                if (eCierre != null)
                {
                    info.Append("Último cierre ").Append(eCierre.Fecha_cierre.ToLongDateString()).Append(Environment.NewLine);
                    info.Append("Depósito ").Append(eCierre.Deposito.ToString("N2"));
                    saldo_inicial += eCierre.Deposito;
                }
                else
                    info.Append("No se encontró el último cierre");

                info.Append(Environment.NewLine);
                info.Append(" ");
                info.Append(Environment.NewLine);

                //Información del total a recaudar
                if (total_recaudar_mes != 0)
                    info.Append("Total a cobrar en el mes $").Append(total_recaudar_mes.ToString("N2"));
                else
                    info.Append("No hay dinero para cobrar este mes");
                info.Append(Environment.NewLine);
                //Información del total a recaudado
                if (total_recaudado_mes != 0)
                    info.Append("Total cobrado $").Append(total_recaudado_mes.ToString("N2"));
                else
                    info.Append("No se a cobrado dinero este mes");
                info.Append(Environment.NewLine);
                //Información del saldo total del mes
                if (total_recaudado_mes != 0)
                {
                    info.Append("Falta por cobrar $").Append(saldo_recaudado_mes.ToString("N2"));
                    info.Append(Environment.NewLine);
                }

                info.Append(" ");
                info.Append(Environment.NewLine);

                //Información de la apertura
                if (eApertura != null)
                    info.Append("Se abrió la caja el ").Append(eApertura.Fecha.ToLongDateString());
                else
                    info.Append("No se encontró la apertura de la caja");
                info.Append(Environment.NewLine);
                //Información del valor inicial
                if (valor_inicial != 0)
                    info.Append("Valor inicial $").Append(valor_inicial.ToString("N2"));
                else
                    info.Append("No se ingresó un valor inicial");
                info.Append(Environment.NewLine);
                //Saldo en caja inicial
                if (saldo_inicial != 0)
                    info.Append("La caja empieza con $").Append(saldo_inicial.ToString("N2"));
                else
                    info.Append("La caja empieza sin dinero");

                info.Append(Environment.NewLine);
                info.Append(" ");
                info.Append(Environment.NewLine);

                //Gastos del mes
                if (cantidad_gastos != 0)
                {
                    info.Append("En el mes se han registrado ").Append(cantidad_gastos).Append(" gastos");
                    info.Append(Environment.NewLine);
                    info.Append("Total de gastos este mes ").Append(total_gastos.ToString("N2"));
                }
                else
                    info.Append("No hay gastos este mes");
                info.Append(Environment.NewLine);
                //Gastos de hoy
                if (cantidad_gastos_hoy != 0)
                {
                    info.Append("Hoy se ha registrado ").Append(cantidad_gastos_hoy).Append(" gastos");
                    info.Append(Environment.NewLine);
                    info.Append("Total de gastos hoy ").Append(total_gastos_hoy.ToString("N2"));
                }
                else
                    info.Append("No hay gastos el día de hoy");

                info.Append(Environment.NewLine);
                info.Append(" ");
                info.Append(Environment.NewLine);

                //Total recaudado hoy
                if (total_recaudado_hoy != 0)
                    info.Append("Hoy se a cobrado $").Append(total_recaudado_hoy.ToString("N2"));
                else
                    info.Append("No se a recaudado dinero hoy");
                info.Append(Environment.NewLine);
                saldo_caja_hoy = saldo_caja_hoy + total_recaudado_hoy;
                //Saldo en caja hoy
                if (saldo_caja_hoy != 0)
                {
                    info.Append("Total en caja $").Append(saldo_caja_hoy.ToString("N2"));
                    if (cantidad_gastos != 0)
                    {
                        info.Append(Environment.NewLine);
                        info.Append("Total en caja restando los gastos $").Append((saldo_caja_hoy - total_gastos_hoy).ToString("N2"));
                    }
                }
                else
                    info.Append("No hay dinero en la caja");

                info.Append(Environment.NewLine);
                info.Append(" ");
                info.Append(Environment.NewLine);
                this.txtInformacionCaja.Text = info.ToString();
            }
        }

        private decimal saldo_caja;
        private bool _isCaja;
        public decimal Saldo_caja
        {
            get => saldo_caja;
            set
            {
                saldo_caja = value;
            }
        }

        public bool IsCaja { get => _isCaja; set => _isCaja = value; }
    }
}
