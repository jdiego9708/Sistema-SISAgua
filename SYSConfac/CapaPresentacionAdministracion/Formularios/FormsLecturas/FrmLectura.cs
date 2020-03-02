using CapaEntidades;
using CapaPresentacionAdministracion.Formularios.FormsCuentas;
using CapaPresentacionAdministracion.Formularios.FormsPrincipales;
using System;
using System.Data;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacionAdministracion.Formularios.FormsLecturas
{
    public partial class FrmLectura : Form
    {
        PoperContainer containerLecturaAnterior;
        public FrmLectura()
        {
            InitializeComponent();

            this.txtLecturaAnterior.MouseEnter += TxtLecturaAnterior_MouseEnter;
            this.txtLecturaAnterior.MouseLeave += TxtLecturaAnterior_MouseLeave;

            this.txtLecturaAnterior.KeyPress += Txt_KeyPress;
            this.txtLecturaAnterior.LostFocus += Txt_LostFocus;
            this.txtLecturaAnterior.Click += Txt_Click;

            this.txtLecturaActual.KeyPress += Txt_KeyPress;
            this.txtLecturaActual.LostFocus += Txt_LostFocus;
            this.txtLecturaActual.Click += Txt_Click;

            this.btnTerminar.Click += BtnTerminar_Click;

            this.Load += FrmLectura_Load;
            this.btnRefresh.Click += BtnRefresh_Click;
        }

        private void BtnTerminar_Click(object sender, EventArgs e)
        {
            if (this.ComprobacionesLectura())
            {
                FrmNuevaCuenta frmNuevaCuenta = new FrmNuevaCuenta
                {
                    StartPosition = FormStartPosition.CenterScreen
                };

                if (this.IsEditar)
                    frmNuevaCuenta.ECuenta = this.ECuenta;

                frmNuevaCuenta.AsignarDatosLectura(this.EMedidor, this.ECliente, this.Total, this.IsEditar);
                frmNuevaCuenta.OnCuentaSuccess += FrmNuevaCuenta_OnCuentaSuccess;
                frmNuevaCuenta.ShowDialog();
            }
        }

        public ELecturas ELectura;

        private void FrmNuevaCuenta_OnCuentaSuccess(object sender, EventArgs e)
        {
            ECuentas eCuentas = (ECuentas)sender;
            this.ECuenta = eCuentas;
            try
            {
                if (this.ECuenta != null)
                {
                    if (this.Tag != null)
                    {
                        DataGridViewRow row = (DataGridViewRow)this.Tag;
                        row.Cells["Lectura_actual"].Value = this.txtLecturaActual.Text;
                        row.Cells["Lectura_anterior"].Value = this.txtLecturaAnterior.Text;
                        if (this.IsEditar)
                        {
                            row.Cells["Total_consumo"].Value = Convert.ToInt32(this.txtLecturaActual.Text) - Convert.ToInt32(this.txtLecturaAnterior.Text);
                            row.Cells["Consumo_excedido"].Value = calculadoraExcedentes1.Total_excedente;
                        }
                    }

                    DatosInicioSesion datosInicioSesion = DatosInicioSesion.GetInstancia();

                    if (this.IsEditar)
                    {
                        if (this.ELecturaAnterior != null)
                        {
                            if (this.ELecturaAnterior.Valor_lectura != Convert.ToInt32(this.txtLecturaAnterior.Text))
                            {
                                this.ELecturaAnterior.Valor_lectura = Convert.ToInt32(this.txtLecturaAnterior.Text);
                                string respuesta = ELecturas.EditarLectura(this.ELecturaAnterior.Id_lectura, ELecturaAnterior);
                                if (!respuesta.Equals("OK"))
                                    Mensajes.MensajeInformacion("No se pudo actualizar la lectura anterior, detalles: " + respuesta,
                                        "Entendido");
                            }
                        }


                        ELecturas eLectura = new ELecturas
                        {
                            ECliente = this.ECliente,
                            ETarifas = this.EDetalleTarifa.ETarifa,
                            EMedidor = this.EMedidor,
                            EEmpleado = datosInicioSesion.EEmpleado,
                            ECuenta = this.ECuenta,
                            Valor_lectura = Convert.ToInt32(this.txtLecturaActual.Text),
                            Mes_lectura = this.txtMes.Text.ToUpper(),
                            Fecha_lectura = this.ECuenta.Fecha_cuenta.ToString("yyyy-MM-dd"),
                            Hora_lectura = DateTime.Now.ToString("HH:mm"),
                            Total_consumo = Convert.ToInt32(this.txtLecturaActual.Text) - Convert.ToInt32(this.txtLecturaAnterior.Text),
                            Consumo_excedido = this.calculadoraExcedentes1.Cantidad_excedente,
                            EMedida = this.EDetalleTarifa.EMedida
                        };

                        string rpta = ELecturas.EditarLectura(this.ELecturaEditar.Id_lectura, eLectura);
                        if (rpta.Equals("OK"))
                        {
                            this.ELectura = eLectura;
                            Mensajes.MensajeOkForm("Se actualizó la lectura correctamente");

                            #region IMPRIMIR

                            if (this.chkImprimir.Checked)
                            {
                                MensajeEspera.ShowWait("Finalizando");
                                FrmFacturaLarge frmFacturaLarge = new FrmFacturaLarge
                                {
                                    WindowState = FormWindowState.Maximized
                                };
                                frmFacturaLarge.AsignarReporte(this);
                                frmFacturaLarge.Show();
                                frmFacturaLarge.Activate();
                                MensajeEspera.CloseForm();
                                this.Close();
                            }
                            else
                            {
                                this.Close();
                            }
                            #endregion

                            this.Close();
                        }
                        else
                        {
                            throw new Exception("Hubo un error al actualizar la lectura, detalles: " + rpta);
                        }
                    }
                    else
                    {
                        ELecturas eLectura = new ELecturas
                        {
                            ECliente = this.ECliente,
                            ETarifas = this.EDetalleTarifa.ETarifa,
                            EMedidor = this.EMedidor,
                            EEmpleado = datosInicioSesion.EEmpleado,
                            ECuenta = this.ECuenta,
                            Valor_lectura = Convert.ToInt32(this.txtLecturaActual.Text),
                            Mes_lectura = this.txtMes.Text.ToUpper(),
                            Fecha_lectura = DateTime.Now.ToString("yyyy-MM-dd"),
                            Hora_lectura = DateTime.Now.ToString("HH:mm"),
                            Total_consumo = Convert.ToInt32(this.txtLecturaActual.Text) - Convert.ToInt32(this.txtLecturaAnterior.Text),
                            Consumo_excedido = this.calculadoraExcedentes1.Cantidad_excedente,
                            EMedida = this.EDetalleTarifa.EMedida
                        };

                        string rpta = "";

                        if (this.ELecturaAnterior == null)
                        {
                            eLectura.Mes_lectura = MonthName(DateTime.Now.Month - 1).ToUpper();
                            eLectura.Valor_lectura = Convert.ToInt32(this.txtLecturaAnterior.Text);

                            rpta = ELecturas.InsertarLectura(out int id_lectura_anterior, eLectura);
                            if (!rpta.Equals("OK"))
                                Mensajes.MensajeInformacion("Hubo un error insertando la lectura anterior", "Entendido");

                            eLectura.Mes_lectura = MonthName(DateTime.Now.Month);
                            eLectura.Valor_lectura = Convert.ToInt32(this.txtLecturaActual.Text);
                        }

                        rpta = ELecturas.InsertarLectura(out int id_lectura, eLectura);
                        if (rpta.Equals("OK"))
                        {
                            eLectura.Id_lectura = id_lectura;
                            this.ELectura = eLectura;
                            this.lblRespuesta.Visible = true;
                            this.lblRespuesta.Text = "Se guardó la lectura correctamente";
                            //Mensajes.MensajeOkForm("Se guardó la lectura correctamente");

                            #region IMPRIMIR

                            if (this.chkImprimir.Checked)
                            {
                                MensajeEspera.ShowWait("Finalizando");
                                FrmFacturaLarge frmFacturaLarge = new FrmFacturaLarge
                                {
                                    WindowState = FormWindowState.Maximized
                                };
                                frmFacturaLarge.AsignarReporte(this);
                                frmFacturaLarge.Show();
                                frmFacturaLarge.Activate();
                                MensajeEspera.CloseForm();
                                this.Close();
                            }
                            else
                            {
                                this.Close();
                            }
                            #endregion

                            this.Close();
                        }
                        else
                        {
                            throw new Exception("Hubo un error al insertar la lectura, detalles: " + rpta);
                        }
                    }                   
                }
                else
                {
                    Mensajes.MensajeInformacion("Debe configurar la cuenta de cobro antes de terminar la lectura", "Entendido");
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "private void BtnTerminar_Click(object sender, EventArgs e)",
                    "Hubo un error al terminar la lectura", ex.Message);
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            this.ComprobacionesLectura();
        }

        private void FrmLectura_Load(object sender, EventArgs e)
        {
            if (this._isEnabled)
            {
                DataTable dtTarifas = 
                    ETarifas.BuscarTarifas("CONSUMO", "CONSUMO", out string rpta);
                if (dtTarifas != null)
                {
                    ETarifas eTarifa = new ETarifas(dtTarifas, 0);
                    this.ETarifa = eTarifa;

                    DataTable dtDetalleTarifa =
                        EDetalleTarifas.BuscarDetalleTarifa("ID TARIFA", eTarifa.Id_tarifa.ToString(), out rpta);
                    if (dtDetalleTarifa != null)
                    {
                        this.EDetalleTarifa = new EDetalleTarifas(dtDetalleTarifa, 0);
                    }
                    else
                    {
                        Mensajes.MensajeInformacion("No se pudo encontrar el detalle de la tarifa ligada a la tarifa, " +
                                                "no se puede realizar la lectura", "Entendido");

                        foreach (Control control in this.Controls)
                        {
                            control.Enabled = false;
                        }
                    }
                }
                else
                {
                    Mensajes.MensajeInformacion("No se pudo encontrar la tarifa ligada al consumo, " +
                        "no se puede realizar la lectura", "Entendido");

                    foreach (Control control in this.Controls)
                    {
                        control.Enabled = false;
                    }
                }
            }
            else
            {
                foreach (Control control in this.Controls)
                {
                    control.Enabled = false;
                }
            }
        }

        public string MonthName(int month)
        {
            DateTimeFormatInfo dtinfo = new CultureInfo("es-ES", false).DateTimeFormat;
            return dtinfo.GetMonthName(month);
        }

        private bool ComprobacionesLectura()
        {
            if (int.TryParse(this.txtLecturaAnterior.Text, out int lectura_anterior))
            {
                if (int.TryParse(this.txtLecturaActual.Text, out int lectura_actual))
                {
                    if (lectura_anterior > lectura_actual)
                    {
                        Mensajes.MensajeInformacion("Verifique la lectura actual", "Entendido");
                        return false;
                    }
                    else
                    {
                        //Consumo del mes es la cantidad actual ingresada - la cantidad anterior
                        int consumo_mes = lectura_actual - lectura_anterior;
                        int cantidad_sobrepasada = 0;
                        int consumo_base = this.EDetalleTarifa.Consumo_maximo;

                        if (consumo_mes > consumo_base)
                        {
                            //Cantidad sobrepasada
                            cantidad_sobrepasada = consumo_mes - consumo_base;
                        }

                        this.calculadoraExcedentes1.AsignarDatos(this.EDetalleTarifa, cantidad_sobrepasada);

                        this.Total = this.calculadoraExcedentes1.Total_excedente;

                        return true;
                    }
                }
                else
                {
                    Mensajes.MensajeInformacion("Verifique la lectura actual", "Entendido");
                    return false;
                }
            }
            else
            {
                Mensajes.MensajeInformacion("Verifique la lectura anterior", "Entendido");
                return false;
            }
        }

        private void Txt_Click(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.SelectAll();
        }

        private void Txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            CultureInfo cc = Thread.CurrentThread.CurrentCulture;
            if (e.KeyChar.ToString() == cc.NumberFormat.NumberDecimalSeparator ||
                char.IsDigit(e.KeyChar) ||
                (int)e.KeyChar == (int)Keys.Back)
            {
                e.Handled = false;
            }
            else
            {
                if ((int)e.KeyChar == (int)Keys.Enter)
                {
                    e.Handled = false;
                    this.ComprobacionesLectura();
                }
                else
                    e.Handled = true;
            }
        }

        private void Txt_LostFocus(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (txt.Text.Equals(""))
                txt.Text = "0";
        }

        public void AsignarDatos(EMedidor eMedidor, ECliente eCliente, int mes)
        {
            this.EMedidor = eMedidor;
            this.ECliente = eCliente;

            this.txtCliente.Text = eCliente.Nombres + " " + eCliente.Apellidos + " - Medidor: " + eMedidor.Medidor;
            this.txtMes.Text = MonthName(mes).ToUpper();
            this.txtFechaProximaLectura.Text = DateTime.Now.AddMonths(1).ToLongDateString();

            DataTable dtLecturaAnterior = ELecturas.BuscarLecturas("LECTURA ANTERIOR ID MEDIDOR",
               eMedidor.Id_medidor.ToString(), out string rpta);
            if (dtLecturaAnterior != null)
            {
                ELecturas eLectura = new ELecturas(dtLecturaAnterior, 0);

                if (eLectura.Mes_lectura.ToUpper() == MonthName(DateTime.Now.Month).ToUpper())
                {
                    Mensajes.MensajeInformacion("El cliente no está habilitado para realizar lectura", "Entendido");
                    this._isEnabled = false;
                    return;
                }

                this.txtLecturaAnterior.Text = eLectura.Valor_lectura.ToString();
                LecturaSmall lecturaSmall = new LecturaSmall();
                lecturaSmall.AsignarDatos(eLectura);
                this.ELecturaAnterior = eLectura;
                containerLecturaAnterior = new PoperContainer(lecturaSmall);
                txtLecturaAnterior.ReadOnly = true;
            }
            else
            {
                containerLecturaAnterior = null;
                this.ELecturaAnterior = null;

                txtLecturaAnterior.ReadOnly = false;
                txtLecturaAnterior.Text = "0";

                if (!rpta.Equals("OK"))
                    Mensajes.MensajeErrorCompleto(this.Name, "public void AsignarDatos(ECliente eCliente)",
                        "Hubo un error al buscar la lectura anterior", rpta);
            }
        }

        public void AsignarDatos(int id_lectura)
        {
            try
            {
                DataTable dtLectura = ELecturas.BuscarLecturas("ID LECTURA", id_lectura.ToString(), 
                    out string rpta);
                if (dtLectura != null)
                {
                    ELecturas eLectura = new ELecturas(dtLectura, 0);
                    this.ELecturaEditar = eLectura;
                    this.IsEditar = true;

                    this.ECliente = eLectura.ECliente;
                    this.EMedidor = eLectura.EMedidor;

                    this.txtCliente.Text = this.ECliente.Nombres + " " + this.ECliente.Apellidos + " - Medidor: " + this.EMedidor.Medidor;
                    this.txtMes.Text = eLectura.Mes_lectura.ToUpper();
                    this.gbProximaLectura.Visible = false;

                    this.txtLecturaActual.Text = eLectura.Valor_lectura.ToString();
                    this.txtMedida.Text = eLectura.EMedida.Alias_medida;

                    this.ECuenta = eLectura.ECuenta;

                    this.EDetalleTarifa = eLectura.ETarifas.EDetalleTarifa;

                    //Obtener lectura anterior
                    DataTable dtLecturaAnterior = ELecturas.BuscarLecturas("COMPLETO ID MEDIDOR", eLectura.EMedidor.Id_medidor.ToString(),
                    out rpta);
                    if (dtLecturaAnterior != null)
                    {
                        ELecturas eLecturaAnterior;

                        if (dtLecturaAnterior.Rows.Count > 1)
                            eLecturaAnterior = new ELecturas(dtLecturaAnterior, 1);
                        else
                            eLecturaAnterior = new ELecturas(dtLecturaAnterior, 0);

                        this.txtLecturaAnterior.Text = eLecturaAnterior.Valor_lectura.ToString();
                        LecturaSmall lecturaSmall = new LecturaSmall();
                        lecturaSmall.AsignarDatos(eLecturaAnterior);
                        this.ELecturaAnterior = eLecturaAnterior;
                        containerLecturaAnterior = new PoperContainer(lecturaSmall);
                        txtLecturaAnterior.ReadOnly = false;

                        this.ComprobacionesLectura();
                    }
                    else
                    {
                        Mensajes.MensajeInformacion("No se pudo encontrar la lectura anterior", "Entendido");
                        this._isEnabled = false;

                        if (!rpta.Equals("OK"))
                            throw new Exception(rpta);
                    }
                }
                else
                {
                    if (!rpta.Equals("OK"))
                        throw new Exception(rpta);
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "public void AsignarDatos(int id_lectura)",
                    "Hubo un error al asignar los datos de la lectura", ex.Message);
            }
        }

        ELecturas ELecturaAnterior;

        private void TxtLecturaAnterior_MouseLeave(object sender, EventArgs e)
        {
            if (containerLecturaAnterior != null)
                containerLecturaAnterior.Close();
        }

        private void TxtLecturaAnterior_MouseEnter(object sender, EventArgs e)
        {
            if (containerLecturaAnterior != null)
                containerLecturaAnterior.Show(txtLecturaAnterior);
        }

        private decimal _total;

        public decimal Total { get => _total; set => _total = value; }
        public bool IsEditar { get => _isEditar; set => _isEditar = value; }

        private bool _isEnabled = true;
        private bool _isEditar = false;

        private ELecturas ELecturaEditar;
        public ECliente ECliente;
        public EMedidor EMedidor;
        public EDetalleTarifas EDetalleTarifa;
        public ECuentas ECuenta;
        public ETarifas ETarifa;

        
    }
}
