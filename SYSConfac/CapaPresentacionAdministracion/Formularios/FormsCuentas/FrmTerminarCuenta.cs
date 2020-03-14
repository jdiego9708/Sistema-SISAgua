using CapaEntidades;
using CapaPresentacionAdministracion.Formularios.FormsAbonos;
using CapaPresentacionAdministracion.Formularios.FormsExcedentes;
using CapaPresentacionAdministracion.Formularios.FormsLecturas;
using CapaPresentacionAdministracion.Formularios.FormsPrincipales;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacionAdministracion.Formularios.FormsCuentas
{
    public partial class FrmTerminarCuenta : Form
    {
        PoperContainer container;
        public LecturaSmall lecturaSmall;
        public FrmTerminarCuenta()
        {
            InitializeComponent();
            this.btnTerminar.Click += BtnTerminar_Click;
            this.btnObservarLectura.Click += BtnObservarLectura_Click;
            this.Load += FrmTerminarCuenta_Load;

            this.rdNinguna.CheckedChanged += RdNinguna_CheckedChanged;
            this.btnImprimir.Click += BtnImprimir_Click;
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            if (rdVistaPrevia.Checked)
            {
                MensajeEspera.ShowWait("Imprimiendo...");
                if (this.IsLectura)
                {
                    FrmFacturaLarge frmFacturaLarge = new FrmFacturaLarge
                    {
                        WindowState = FormWindowState.Maximized
                    };
                    frmFacturaLarge.AsignarReporte(this);
                    frmFacturaLarge.Show();
                    frmFacturaLarge.Activate();
                }
                else
                {
                    FrmFacturaSmall frmFacturaSmall = new FrmFacturaSmall
                    {
                        WindowState = FormWindowState.Maximized
                    };
                    frmFacturaSmall.AsignarReporte(this);
                    frmFacturaSmall.Show();
                    frmFacturaSmall.Activate();
                }
                MensajeEspera.CloseForm();
            }
            else if (rdImpresionDirecta.Checked)
            {
                MensajeEspera.ShowWait("Imprimiendo...");
                if (this.IsLectura)
                {
                    FrmFacturaLarge frmFacturaLarge = new FrmFacturaLarge
                    {
                        WindowState = FormWindowState.Maximized
                    };
                    frmFacturaLarge.Imprimir(this);
                }
                else
                {
                    FrmFacturaSmall frmFacturaSmall = new FrmFacturaSmall
                    {
                        WindowState = FormWindowState.Maximized
                    };
                    frmFacturaSmall.AsignarReporte(this);
                    frmFacturaSmall.Imprimir();
                }
                MensajeEspera.CloseForm();
            }
        }

        private void RdNinguna_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rd = (RadioButton)sender;
            if (rd.Checked)
            {
                this.btnImprimir.Enabled = false;
            }
            else
            {
                this.btnImprimir.Enabled = true;
            }
        }

        private void FrmTerminarCuenta_Load(object sender, EventArgs e)
        {
            DatosInicioSesion datosInicioSesion = DatosInicioSesion.GetInstancia();
            if (datosInicioSesion.ECaja == null)
            {
                Mensajes.MensajeInformacion("El módulo de caja no está abierto, intentelo de nuevo", "Entendido");
                this.Close();
                return;
            }
            this.Id_caja = datosInicioSesion.ECaja.Id_caja;
            this.Show();
            this.btnTerminar.Focus();
        }

        private void BtnObservarLectura_Click(object sender, EventArgs e)
        {
            if (this.container != null)
                this.container.Show(this.btnObservarLectura);
        }

        private void BtnTerminar_Click(object sender, EventArgs e)
        {
            try
            {
                FrmAgregarAbono frmAgregarAbono = new FrmAgregarAbono
                {
                    StartPosition = FormStartPosition.CenterScreen
                };
                frmAgregarAbono.OnBtnTerminarClick += FrmAgregarAbono_OnBtnTerminarClick;
                frmAgregarAbono.AsignarDatos(this.ECuenta);
                frmAgregarAbono.ShowDialog();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnTerminar_Click",
                    "Hubo un error al terminar la cuenta, intentelo de nuevo", ex.Message);
            }
        }

        private void FrmAgregarAbono_OnBtnTerminarClick(object sender, EventArgs e)
        {
            FrmAgregarAbono frmAgregarAbono = (FrmAgregarAbono)sender;

            bool pagoCompleto = false;

            if (Convert.ToInt32(frmAgregarAbono.Valor_restante) == 0)
                pagoCompleto = true;
            else if (frmAgregarAbono.rdPagoCompleto.Checked)
                pagoCompleto = true;

            this.PagoCompleto = pagoCompleto;
            if (pagoCompleto)
            {
                EPago_cuenta ePago = new EPago_cuenta
                {
                    ECuenta = new ECuentas()
                    {
                        Id_cuenta = this.ECuenta.Id_cuenta
                    },
                    ECaja = new ECaja
                    {
                        Id_caja = this.Id_caja
                    },
                    Fecha_pago = DateTime.Now,
                    Hora_pago = DateTime.Now.ToString("HH:mm"),
                    Observaciones_pago = this.txtObservaciones.Text
                };

                string rpta =
                    EPago_cuenta.InsertarPagoCuenta(ePago, out int id_pago);

                if (rpta.Equals("OK"))
                {
                    ePago.Id_pago = id_pago;
                    this.EPago = ePago;
                    Mensajes.MensajeInformacion("Se realizó el pago correctamente", "Entendido");                                       
                    OnCuentasRefresh?.Invoke(ePago, e);
                }
                else
                {
                    throw new Exception(rpta);
                }
            }
            else
            {
                EDetalleAbonosCuentas eAbono = new EDetalleAbonosCuentas
                {
                    ECuenta = frmAgregarAbono.ECuenta,
                    Fecha_abono = DateTime.Now,
                    Hora_abono = DateTime.Now.ToString("HH:mm"),
                    Valor_abono = frmAgregarAbono.Abono,
                    Valor_restante = frmAgregarAbono.Valor_restante,
                    Observaciones = this.txtObservaciones.Text
                };

                string rpta =
                    EDetalleAbonosCuentas.InsertarAbono(eAbono, out int id_abono);
                if (rpta.Equals("OK"))
                {
                    Mensajes.MensajeInformacion("Se realizó el abono correctamente", "Entendido");
                    eAbono.Id_abono = id_abono;
                    this.EAbono = eAbono;
                    OnAbonoRefresh?.Invoke(eAbono, e);
                }
                else
                {
                    throw new Exception(rpta);
                }
            }

            if (rdVistaPrevia.Checked)
            {
                try
                {
                    if (this.IsLectura)
                    {
                        FrmFacturaLarge frmFacturaLarge = new FrmFacturaLarge
                        {
                            WindowState = FormWindowState.Maximized
                        };
                        frmFacturaLarge.AsignarReporte(this);
                        frmFacturaLarge.Show();
                        frmFacturaLarge.Activate();
                    }
                    else
                    {
                        FrmFacturaSmall frmFacturaSmall = new FrmFacturaSmall
                        {
                            WindowState = FormWindowState.Maximized
                        };
                        frmFacturaSmall.AsignarReporte(this);
                        frmFacturaSmall.Show();
                        frmFacturaSmall.Activate();
                    }
                }
                catch (Exception ex)
                {
                    Mensajes.MensajeErrorCompleto(this.Name, "FrmAgregarAbono_OnBtnTerminarClick",
                        "Hubo un error con la impresión de vista previa", ex.Message);
                }   
                
                
            }
            else if (rdImpresionDirecta.Checked)
            {
                try
                {
                    if (this.IsLectura)
                    {
                        FrmFacturaLarge frmFacturaLarge = new FrmFacturaLarge
                        {
                            WindowState = FormWindowState.Maximized
                        };
                        frmFacturaLarge.AsignarReporte(this);
                        frmFacturaLarge.Imprimir(this);
                    }
                    else
                    {
                        FrmFacturaSmall frmFacturaSmall = new FrmFacturaSmall
                        {
                            WindowState = FormWindowState.Maximized
                        };
                        frmFacturaSmall.AsignarReporte(this);
                        frmFacturaSmall.Imprimir();

                    }
                }
                catch (Exception ex)
                {
                    Mensajes.MensajeErrorCompleto(this.Name, "FrmAgregarAbono_OnBtnTerminarClick",
                                            "Hubo un error con la impresión directa", ex.Message);
                }             
            }
            this.Close();
        }

        public ECuentas ECuenta;
        public EPago_cuenta EPago;
        public EDetalleAbonosCuentas EAbono;
        private bool pagoCompleto = true;
        private int _id_caja;
        private bool isLectura;

        public int Id_caja { get => _id_caja; set => _id_caja = value; }
        public bool IsLectura { get => isLectura; set => isLectura = value; }
        public bool PagoCompleto { get => pagoCompleto; set => pagoCompleto = value; }

        public void AsignarDatos(ECuentas cuenta)
        {
            if (cuenta != null)
            {
                this.ECuenta = cuenta;

                decimal Total_pagar = cuenta.Total_pagar;
                DataTable dtAbonos =
                   EDetalleAbonosCuentas.BuscarAbonos("COMPLETO ID CUENTA", cuenta.Id_cuenta.ToString(), out string rpta);
                if (dtAbonos != null)
                {
                    decimal total_abonos = 0;
                    foreach (DataRow row in dtAbonos.Rows)
                    {
                        decimal abono = Convert.ToDecimal(row["Valor_abono"]);
                        total_abonos += abono;
                    }
                    Total_pagar -= total_abonos;
                }

                this.txtNombre.Text = cuenta.ECliente.Nombres + " " +
                    cuenta.ECliente.Apellidos;
                this.txtCelular.Text = cuenta.ECliente.Celular;
                this.txtIdentificacion.Text = cuenta.ECliente.Identificacion;
                this.txtCorreo.Text = cuenta.ECliente.Correo;
 
                this.tarifaSmall1.AsignarDatos(cuenta.ETarifa);

                if (this.tarifaSmall1.ETarifas.Tipo_tarifa.Equals("UNICA"))
                {
                    this.btnObservarLectura.Visible = false;
                }
                else
                {
                    this.btnObservarLectura.Visible = true;
                    DataTable dtLectura =
                        ELecturas.BuscarLecturas("ID CUENTA", this.ECuenta.Id_cuenta.ToString(), out rpta);
                    if (dtLectura != null)
                    {
                        this.IsLectura = true;
                        ELecturas lectura = new ELecturas(dtLectura, 0);
                        this.ELectura = lectura;
                        this.lecturaSmall = new LecturaSmall();
                        lecturaSmall.AsignarDatos(lectura);

                        calculadoraExcedentes = new CalculadoraExcedentes();
                        calculadoraExcedentes.AsignarDatos(lectura.ETarifas.EDetalleTarifa, lecturaSmall.Total_excedente);
                      
                        this.container = new PoperContainer(lecturaSmall);
                    }
                    else
                    {
                        if (!rpta.Equals("OK"))
                            Mensajes.MensajeInformacion("No se pudo encontrar la lectura ligada a esta cuenta", "Entendido");
                    }
                }

                //decimal descuentoTotal = 
                this.lblDescuentos.Text = cuenta.Descuento == 0 ? "No aplica ningún descuento" :
                    "Descuento: " + Convert.ToInt32(cuenta.Descuento * 100).ToString() + "%";
                this.lblIva.Text = "IVA: " + Convert.ToInt32((cuenta.Iva * 100)).ToString() + "%";
                this.lblTotalPagar.Text = "Total a pagar: $" + Total_pagar.ToString("N2");

                if (cuenta.Estado_cuenta.Equals("TERMINADO"))
                {
                    this.gbFacturacion.Visible = false;
                    this.btnTerminar.Visible = false;
                    this.gbObservaciones.Visible = false;
                }
            }
        }

        public ELecturas ELectura;
        public CalculadoraExcedentes calculadoraExcedentes;
        public event EventHandler OnCuentasRefresh;
        public event EventHandler OnAbonoRefresh;
    }
}
