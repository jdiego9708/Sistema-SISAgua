using CapaEntidades;
using CapaPresentacionAdministracion.Formularios.FormsConfiguraciones.FormsConfiguraciones;
using CapaPresentacionAdministracion.Formularios.FormsMedidores;
using System;
using System.Data;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacionAdministracion.Formularios.FormsCuentas
{
    public partial class FrmNuevaCuenta : Form
    {
        public FrmNuevaCuenta()
        {
            InitializeComponent();
            this.Load += FrmNuevaCuenta_Load;
            this.btnTerminar.Click += BtnTerminar_Click;
            this.chkValorManual.CheckedChanged += ChkValorMnaual_CheckedChanged;
            this.txtValorManual.KeyPress += TxtValorManual_KeyPress;
            this.txtValorManual.LostFocus += TxtValorManual_LostFocus;
            this.btnRefresh.Click += BtnRefresh_Click;
            this.btnMedidor.Click += BtnMedidor_Click;

            this.listaTarifas.SelectedIndexChanged += ListaTarifas_SelectedIndexChanged;
        }

        private void ListaTarifas_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (int.TryParse(Convert.ToString(cb.SelectedValue), out int id_tarifa))
            {
                if (!this.chkValorManual.Checked)
                {
                    this.tarifaSmall1.AsignarDatos(new ETarifas(id_tarifa));
                }
            }
        }

        private void BtnMedidor_Click(object sender, EventArgs e)
        {
            FrmObservarMedidores frmObservarMedidores = new FrmObservarMedidores
            {
                StartPosition = FormStartPosition.CenterScreen,
                Id_cliente = this.ECliente.Id_cliente
            };
            frmObservarMedidores.OnBtnMedidorSmallSiguiente += FrmObservarMedidores_OnBtnMedidorSmallSiguiente;
            frmObservarMedidores.ShowDialog();
        }

        private void FrmObservarMedidores_OnBtnMedidorSmallSiguiente(object sender, EventArgs e)
        {
            EMedidor eMedidor = (EMedidor)sender;
            this.btnMedidor.Text = eMedidor.Medidor;
            this.btnMedidor.Tag = eMedidor;
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            this.Calcular();
        }

        private void TxtValorManual_LostFocus(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (txt.Text.Equals(""))
                txt.Text = "0";
        }

        private void TxtValorManual_KeyPress(object sender, KeyPressEventArgs e)
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
                    this.Calcular();
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void ChkValorMnaual_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            if (chk.Checked)
            {
                this.tarifaSmall1.Visible = false;
                this.gbValorManual.Visible = true;

                this.ListaTarifas(true);
            }
            else
            {
                this.tarifaSmall1.Visible = true;
                this.gbValorManual.Visible = false;
                this.ListaTarifas(false);

            }
        }

        private void BtnTerminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.btnMedidor.Tag == null)
                {
                    Mensajes.MensajeInformacion("Por favor seleccione un medidor", "Entendido");
                    return;
                }

                this.Calcular();

                ECuentas eCuenta = new ECuentas
                {
                    ECliente = this.ECliente,
                    ETarifa = this.tarifaSmall1.ETarifas
                };

                if (decimal.TryParse(listaIva.SelectedValue.ToString(), out decimal iva))
                {
                    eCuenta.Iva = iva;
                }
                else
                {
                    eCuenta.Iva = 0;
                }

                if (decimal.TryParse(listDescuentos.SelectedValue.ToString(), out decimal descuento))
                {
                    eCuenta.Descuento = descuento;
                }
                else
                {
                    eCuenta.Descuento = 0;
                }

                eCuenta.Total_pagar = this.Total_cuenta;
                eCuenta.Motivo_descuento = "";
                eCuenta.Estado_cuenta = "PENDIENTE DE PAGO";
                eCuenta.Fecha_cuenta = DateTime.Now;
                eCuenta.Fecha_pago = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 1);

                EMedidor eMedidor = (EMedidor)this.btnMedidor.Tag;
                eCuenta.EMedidor = eMedidor;

                if (this.IsEditar)
                {
                    eCuenta.Estado_cuenta = this.ECuenta.Estado_cuenta;
                    eCuenta.Fecha_cuenta = this.ECuenta.Fecha_cuenta;
                    eCuenta.Fecha_pago = this.ECuenta.Fecha_pago;

                    string rpta = ECuentas.EditarCuenta(eCuenta, this.ECuenta.Id_cuenta);
                    if (rpta.Equals("OK"))
                    {
                        eCuenta.Id_cuenta = this.ECuenta.Id_cuenta;
                        MensajeEspera.CloseForm();
                        Mensajes.MensajeInformacion("¡Se actualizó la lectura correctamente!, Por favor verificar la información", "Continuar");
                        OnCuentaSuccess?.Invoke(eCuenta, e);
                        this.Close();
                    }
                }
                else
                {
                    string rpta = ECuentas.InsertarCuenta(eCuenta, out int id_cuenta);
                    if (rpta.Equals("OK"))
                    {
                        MensajeEspera.CloseForm();

                        if (!this.IsEditar & !this.IsLectura)
                            Mensajes.MensajeInformacion("Cuenta de cobro pendiente" +
                                " registrada bajo el número: " + id_cuenta.ToString(), "Continuar");

                        eCuenta.Id_cuenta = id_cuenta;
                        OnCuentaSuccess?.Invoke(eCuenta, e);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "private void BtnTerminar_Click(object sender, EventArgs e)",
                    "Hubo un error al guardar una cuenta", ex.Message);
            }
        }

        private void Calcular()
        {
            decimal total = 0;

            if (this.IsLectura)
                total = this.Total_lectura;

            if (this.chkValorManual.Checked)
            {
                if (decimal.TryParse(this.txtValorManual.Text, out decimal valor_manual))
                {
                    if (valor_manual == 0)
                    {
                        Mensajes.MensajeInformacion("El valor manual no puede ser 0", "Entendido");
                        return;
                    }
                    total = valor_manual;
                }
                else
                {
                    Mensajes.MensajeInformacion("Por favor verifique el valor manual", "Entendido");
                    return;
                }
            }
            else
            {
                if (this.tarifaSmall1.ETarifas != null & !this.IsLectura)
                    total = this.tarifaSmall1.ETarifas.Valor_tarifa;
            }

            bool resultIva = decimal.TryParse(Convert.ToString(this.listaIva.SelectedValue), out decimal iva);
            if (resultIva)
            {
                decimal costoIva = total * iva;
                total += costoIva;
                if (costoIva == 0)
                    resultIva = false;
            }

            bool resultDescuento = decimal.TryParse(Convert.ToString(this.listDescuentos.SelectedValue), out decimal descuento);
            decimal total_descuento = 0;
            if (resultDescuento)
            {
                //descuento = descuento / 100;
                if (Convert.ToString(this.listDescuentos.Text).Equals("100%"))
                    total_descuento = total;
                else
                    total_descuento = total * descuento;

                if (total_descuento == 0)
                    resultDescuento = false;
            }

            total = (total - total_descuento);
            this.Total_cuenta = total;

            this.lblTotal.Text = "Total a pagar: " + Environment.NewLine +
                "$" + total.ToString("N2");
        }

        public void AsignarDatosEditar(ECuentas eCuenta, bool isLectura)
        {
            this.ECuenta = eCuenta;
            EMedidor eMedidor = eCuenta.EMedidor;
            ECliente eCliente = eCuenta.ECliente;
            this.Total_cuenta = eCuenta.Total_pagar;
            this.Total_lectura = eCuenta.Total_lectura;

            this.txtCliente.Text = eCliente.Nombres + " " + eCliente.Apellidos;
            this.txtFecha.Text = DateTime.Now.ToLongDateString();
            this.ECliente = eCliente;

            this.IsLectura = isLectura;
            this.btnMedidor.Enabled = false;

            this.btnMedidor.Text = eMedidor.Medidor;
            this.btnMedidor.Tag = eMedidor;

            this.ListaTarifas(false);
            this.ListaDescuentos();
            this.ListaIva();

            this.listaTarifas.SelectedValue = this.ECuenta.ETarifa.Id_tarifa;
            this.txtFecha.Text = this.ECuenta.Fecha_cuenta.ToLongDateString();
            this.listDescuentos.SelectedValue = this.ECuenta.Descuento;
            this.listaIva.SelectedValue = this.ECuenta.Iva;

            this.Calcular();
        }

        public void AsignarDatos(ECliente eCliente)
        {
            this.txtCliente.Text = eCliente.Nombres + " " + eCliente.Apellidos;
            this.txtFecha.Text = DateTime.Now.ToLongDateString();
            this.ECliente = eCliente;
            this.IsLectura = false;
        }

        public void AsignarDatosLectura(EMedidor eMedidor, ECliente eCliente, decimal total, bool isEditar)
        {
            this.txtCliente.Text = eCliente.Nombres + " " + eCliente.Apellidos;
            this.txtFecha.Text = DateTime.Now.ToLongDateString();
            this.ECliente = eCliente;
            this.Total_lectura = total;
            this.IsLectura = true;
            this.btnMedidor.Text = eMedidor.Medidor;
            this.btnMedidor.Tag = eMedidor;
            this.chkValorManual.Visible = false;
            this.ListaTarifas(false);
            this.btnMedidor.Enabled = false;
            this.IsEditar = isEditar;
            if (isEditar)
            {
                if (this.ECuenta != null)
                {
                    this.ListaDescuentos();
                    this.ListaIva();

                    this.listaTarifas.SelectedValue = this.ECuenta.ETarifa.Id_tarifa;
                    this.txtFecha.Text = this.ECuenta.Fecha_cuenta.ToLongDateString();
                    this.listDescuentos.SelectedValue = this.ECuenta.Descuento;
                    this.listaIva.SelectedValue = this.ECuenta.Iva;

                }
            }
            else
            {
                this.ListaDescuentos();
                this.ListaIva();
            }

            this.Calcular();
        }

        private void ListaTarifas(bool isManual)
        {
            DataTable dtTarifas = ETarifas.BuscarTarifas("COMPLETO", "", out _);

            if (isManual)
            {
                this.listaTarifas.Enabled = true;
                ETarifas eTarifas = new ETarifas(dtTarifas, 0);
                this.tarifaSmall1.AsignarDatos(eTarifas);
            }
            else
            {
                if (this.IsLectura)
                {
                    this.listaTarifas.Enabled = false;
                    int id_tarifa_default = ConfigTarifas.Default.Id_tarifa_lectura;
                    if (dtTarifas != null)
                    {
                        DataRow[] row = dtTarifas.Select(string.Format("Id_tarifa = {0}", id_tarifa_default));
                        if (row.Length > 0)
                        {
                            this.tarifaSmall1.AsignarDatos(new ETarifas(row[0]));
                        }
                    }
                }
                else
                {
                    this.listaTarifas.Enabled = true;
                    this.tarifaSmall1.AsignarDatos(new ETarifas(dtTarifas, 0));
                }
            }

            this.listaTarifas.DataSource = dtTarifas;            
            this.listaTarifas.ValueMember = "Id_tarifa";
            this.listaTarifas.DisplayMember = "Descripcion";
        }

        private void ListaIva()
        {
            DataTable dtIva = new DataTable("IVA");
            dtIva.Columns.Add("num_iva", typeof(decimal));
            dtIva.Columns.Add("text_iva", typeof(string));

            DataRow row1 = dtIva.NewRow();
            row1["num_iva"] = 0.0;
            row1["text_iva"] = "0%";
            dtIva.Rows.Add(row1);

            DataRow row = dtIva.NewRow();
            row["num_iva"] = 0.12;
            row["text_iva"] = "12%";
            dtIva.Rows.Add(row);

            this.listaIva.DataSource = dtIva;
            this.listaIva.ValueMember = "num_iva";
            this.listaIva.DisplayMember = "text_iva";
            this.listaIva.SelectedIndexChanged += ListaIva_SelectedIndexChanged;
        }

        private void ListaIva_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listaIva.DataSource != null)
            {
                this.Calcular();
            }
        }

        private void ListaDescuentos()
        {
            DataTable TablaDescuentos = new DataTable();
            TablaDescuentos.Columns.Add("descuento_texto", typeof(string));
            TablaDescuentos.Columns.Add("descuento_decimal", typeof(decimal));
            TablaDescuentos.Columns.Add("descuento_entero", typeof(int));
            int contador = 0;
            while (contador <= 100)
            {
                decimal des = (decimal)contador / (decimal)100;
                DataRow row = TablaDescuentos.NewRow();
                row["descuento_decimal"] = des;
                row["descuento_entero"] = contador;
                row["descuento_texto"] = contador + "%";

                TablaDescuentos.Rows.Add(row);
                contador += 5;
            }
            this.listDescuentos.DataSource = TablaDescuentos;
            this.listDescuentos.ValueMember = "descuento_decimal";
            this.listDescuentos.DisplayMember = "descuento_texto";
            this.listDescuentos.SelectedIndexChanged += ListDescuentos_SelectedIndexChanged;
        }

        private void ListDescuentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listDescuentos.DataSource != null)
            {
                this.Calcular();
            }
        }

        private void FrmNuevaCuenta_Load(object sender, EventArgs e)
        {
            if (!IsEditar && !IsLectura)
            {
                this.ListaDescuentos();
                this.ListaIva();
                this.ListaTarifas(false);
            }

            if (!this.IsLectura)
                this.Calcular();

            this.Show();
            this.btnTerminar.Focus();
        }

        public event EventHandler OnCuentaSuccess;

        public ECuentas ECuenta;
        private ECliente ECliente;
        private bool _isEditar;
        private bool _isLectura;
        private decimal _total_lectura;
        private decimal _total_cuenta;

        public bool IsLectura { get => _isLectura; set => _isLectura = value; }
        public decimal Total_lectura { get => _total_lectura; set => _total_lectura = value; }
        public decimal Total_cuenta { get => _total_cuenta; set => _total_cuenta = value; }
        public bool IsEditar { get => _isEditar; set => _isEditar = value; }
    }
}
