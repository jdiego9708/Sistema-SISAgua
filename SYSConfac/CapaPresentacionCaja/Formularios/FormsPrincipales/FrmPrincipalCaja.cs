using CapaEntidades;
using CapaPresentacionAdministracion;
using CapaPresentacionAdministracion.Formularios.FormsCajas;
using CapaPresentacionAdministracion.Formularios.FormsClientes;
using CapaPresentacionAdministracion.Formularios.FormsCuentas;
using CapaPresentacionAdministracion.Formularios.FormsGastos;
using CapaPresentacionAdministracion.Formularios.FormsPrincipales;
using CapaPresentacionCaja.Properties;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

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
            Decimal valor = (Decimal)sender;
            this.SumarValor(valor);
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

        public void RestarValor(decimal value)
        {
            this.Saldo_caja -= value;
        }

        public void SumarValor(decimal value)
        {
            this.Saldo_caja += value;
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
            EHistorialGastos eHistorial = (EHistorialGastos)sender;
            this.RestarValor(eHistorial.Valor_gasto);
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
                        StartPosition = FormStartPosition.CenterScreen
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
                this.Saldo_caja = eCierre.Deposito;

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
                IsEditar = false
            };
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
            frmNuevaCuenta.AsignarDatos(eCliente);
            frmNuevaCuenta.ShowDialog();
        }

        ECaja ECaja;
        ECierre ECierre;
        EApertura EApertura;

        private void VerificarCaja()
        {
            try
            {
                int id_caja_principal = Convert.ToInt32(ConfigurationManager.AppSettings["IdCajaPrincipal"]);
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
                        DataTable dtApertura = EApertura.BuscarAperturas("ID CAJA", eCaja.Id_caja.ToString(),
                            out rpta);
                        if (dtApertura != null)
                        {
                            EApertura eApertura = new EApertura(dtApertura, 0);
                            if (eApertura.Fecha.ToString("yyyy-MM-dd") ==
                                    DateTime.Now.ToString("yyyy-MM-dd"))
                            {
                                this.Saldo_caja += eApertura.Valor_inicial;
                            }
                        }
    
                        this.btnLock.Image = Resources.lock_32px;
                        this.txtTitulo.Text = "Módulo de " + eCaja.Nombre_caja + " (Caja abierta)";
                        this.groupBox1.Enabled = true;
                        this.toolTip1.SetToolTip(btnLock, "Cerrar caja");
                        this.IsCaja = true;                        
                    }

                    DataTable dtHistorialCierres =
                         ECierre.BuscarCierres("ID CAJA", eCaja.Id_caja.ToString(), out rpta);
                    if (dtHistorialCierres != null)
                    {
                        //Obtener el último cierre realizado
                        ECierre eCierre = new ECierre(dtHistorialCierres, 0);
                        if (eCierre.Fecha_cierre.ToString("yyyy-MM-dd") ==
                            DateTime.Now.ToString("yyyy-MM-dd"))
                        {
                            this.Saldo_caja += eCierre.Deposito;
                        }
                        else
                        {
                            this.ComprobarSaldoCaja(eCaja.Id_caja);
                        }
                        this.lblUltimaApertura.Text = "Última apertura " + eCierre.Fecha_cierre.ToLongDateString();
                        this.ECierre = eCierre;
                    }
                    else
                    {
                        this.lblUltimaApertura.Text = "No hay aperturas anteriores";
                        this.lblSaldoCaja.Text = "Saldo en caja: " + this.Saldo_caja.ToString("N2");

                        if (!rpta.Equals("OK"))
                            throw new Exception(rpta);
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

        private void ComprobarSaldoCaja(int id_caja)
        {
            DataTable dtPagos =
               EPago_cuenta.BuscarPagoCuentas("ID CAJA FECHA", id_caja.ToString(), out string rpta);
            if (dtPagos != null)
            {
                List<EPago_cuenta> listPagos = new List<EPago_cuenta>();
                foreach (DataRow row in dtPagos.Rows)
                {
                    EPago_cuenta ePago = new EPago_cuenta(row);
                    this.Saldo_caja += ePago.ECuenta.Total_pagar;
                    listPagos.Add(ePago);
                }
                
            }

            DataTable dtAbonos =
            EDetalleAbonosCuentas.BuscarAbonos("FECHA ABONO", DateTime.Now.ToString("yyyy-MM-dd"), out rpta);
            if (dtAbonos != null)
            {
                foreach (DataRow row in dtAbonos.Rows)
                {
                    decimal recaudo = Convert.ToDecimal(row["Valor_abono"]);
                    this.Saldo_caja += recaudo;
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
            this.Saldo_caja -= totalGastos;

            if (totalGastos > 0)
                this.lblSaldoCaja.Text = "Saldo actual en caja: $" + this.Saldo_caja.ToString("N2");
            else
                this.lblSaldoCaja.Text = "Sin saldo actual";
            
        }

        private decimal saldo_caja;
        private bool _isCaja;
        public decimal Saldo_caja
        {
            get => saldo_caja;
            set
            {
                this.lblSaldoCaja.Text = "Saldo en caja $" + value.ToString("N2");
                saldo_caja = value;
            }
        }

        public bool IsCaja { get => _isCaja; set => _isCaja = value; }
    }
}
