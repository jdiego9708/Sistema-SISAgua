using CapaEntidades;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacionAdministracion.Formularios.FormsCuentas
{
    public partial class CuentaLarge : UserControl
    {
        public CuentaLarge()
        {
            InitializeComponent();
            this.btnDetalles.Click += BtnDetalles_Click;
            this.btnEditar.Click += BtnEditar_Click;
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (this.IsEditar)
            {
                if (this.IsLectura)
                {
                    Mensajes.MensajeInformacion("La cuenta que trata de modificar es una lectura, para poder realizar la actualización " +
                        "de esta cuenta debe modificar la lectura", "Entendido");
                }
                else
                {
                    FrmNuevaCuenta frmNuevaCuenta = new FrmNuevaCuenta
                    {
                        StartPosition = FormStartPosition.CenterScreen,
                        IsEditar = true
                    };
                    frmNuevaCuenta.AsignarDatosEditar(this.ECuenta);
                    frmNuevaCuenta.OnCuentaSuccess += FrmNuevaCuenta_OnCuentaSuccess;
                    frmNuevaCuenta.ShowDialog();
                }
            }
        }

        private void FrmNuevaCuenta_OnCuentaSuccess(object sender, EventArgs e)
        {
            ECuentas eCuenta = (ECuentas)sender;
            this.AsignarDatos(eCuenta);
        }

        public event EventHandler OnCuentasRefresh;
        public event EventHandler OnAbonoRefresh;

        private void BtnDetalles_Click(object sender, EventArgs e)
        {
            if (this.IsCaja)
            {
                FrmTerminarCuenta frmTerminarCuenta = new FrmTerminarCuenta
                {
                    StartPosition = FormStartPosition.CenterScreen
                };
                frmTerminarCuenta.AsignarDatos(this.ECuenta);
                frmTerminarCuenta.OnCuentasRefresh += FrmTerminarCuenta_OnCuentasRefresh;
                frmTerminarCuenta.OnAbonoRefresh += FrmTerminarCuenta_OnAbonoRefresh;
                frmTerminarCuenta.ShowDialog();
            }
            else
            {
                Mensajes.MensajeInformacion("La caja está cerrada, debe abrir la caja para poder realizar movimientos de dinero",
                    "Entendido");
            }
        }

        private void FrmTerminarCuenta_OnAbonoRefresh(object sender, EventArgs e)
        {
            try
            {
                EDetalleAbonosCuentas eAbono = (EDetalleAbonosCuentas)sender;
                this.Total_pagar -= eAbono.Valor_abono;
                this.AsignarDatos(this.ECuenta);
                OnAbonoRefresh?.Invoke(eAbono, e);
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "FrmTerminarCuenta_OnCuentasRefresh",
                    "Hubo un error al refrescar la cuenta de un abono", ex.Message);
            }
        }

        private void FrmTerminarCuenta_OnCuentasRefresh(object sender, EventArgs e)
        {
            try
            {
                EPago_cuenta ePago = (EPago_cuenta)sender;
                ePago.ECuenta = this.ECuenta;
                this.AsignarDatos(this.ECuenta);
                OnCuentasRefresh?.Invoke(ePago, e);
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "FrmTerminarCuenta_OnCuentasRefresh",
                    "Hubo un error al refrescar la cuenta de un pago completo", ex.Message);
            }
 
        }

        public ECuentas ECuenta;

        public void AsignarDatos(ECuentas eCuenta)
        {
            if (eCuenta != null)
            {
                if (this.IsEditar)
                    this.btnEditar.Visible = true;
                else
                    this.btnEditar.Visible = false;

                this.ECuenta = eCuenta;
                this.txtCliente.Text = eCuenta.ECliente.Nombres + " " +
                    eCuenta.ECliente.Apellidos;
                this.txtEstado.Text = eCuenta.Estado_cuenta;
                if (eCuenta.Estado_cuenta.Equals("PENDIENTE DE PAGO"))
                    this.txtEstado.ForeColor = Color.Red;
                else
                    this.txtEstado.ForeColor = Color.FromArgb(64, 64, 64);

                this.tarifaSmall1.AsignarDatos(eCuenta.ETarifa);

                this.txtFechaPago.Text = eCuenta.Fecha_pago.ToLongDateString();

                decimal total_pagar = eCuenta.Total_pagar;
                DataTable dtAbonos = 
                    EDetalleAbonosCuentas.BuscarAbonos("COMPLETO ID CUENTA", eCuenta.Id_cuenta.ToString(), out string rpta);
                if (dtAbonos != null)
                {
                    decimal total_abonos = 0;
                    foreach (DataRow row in dtAbonos.Rows)
                    {
                        decimal abono = Convert.ToDecimal(row["Valor_abono"]);
                        total_abonos += abono;
                    }
                    total_pagar -= total_abonos;
                    this.Total_pagar = total_pagar;
                }  
                else
                    this.Total_pagar = total_pagar;

                this.txtValorPagar.Text = "Valor a pagar: $" + Total_pagar.ToString("N2");
            }
        }

        private decimal Total_pagar;
        private bool _isCaja;
        private bool _isLectura;
        private bool _isEditar;
        public bool IsCaja { get => _isCaja; set => _isCaja = value; }
        public bool IsLectura { get => _isLectura; set => _isLectura = value; }
        public bool IsEditar { get => _isEditar; set => _isEditar = value; }
    }
}
