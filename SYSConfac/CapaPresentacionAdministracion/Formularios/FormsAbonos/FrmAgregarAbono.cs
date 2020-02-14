using CapaEntidades;
using System;
using System.Data;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacionAdministracion.Formularios.FormsAbonos
{
    public partial class FrmAgregarAbono : Form
    {
        public FrmAgregarAbono()
        {
            InitializeComponent();
            this.txtAbono.Click += TxtAbono_Click;
            this.txtAbono.GotFocus += TxtValorUsuario_GotFocus;
            this.txtAbono.LostFocus += TxtValorUsuario_LostFocus;
            this.txtAbono.KeyPress += TxtValorUsuario_KeyPress;
            this.rdPagoCompleto.CheckedChanged += RdPagoCompleto_CheckedChanged;
            this.rdAbono.CheckedChanged += RdPagoCompleto_CheckedChanged;
            this.btnTerminar.Click += BtnTerminar_Click;
            this.btnAbonos.Click += BtnAbonos_Click;
        }

        private void TxtAbono_Click(object sender, EventArgs e)
        {
            this.txtAbono.SelectAll();
        }

        private void BtnAbonos_Click(object sender, EventArgs e)
        {
        
        }

        public event EventHandler OnBtnTerminarClick;

        private void BtnTerminar_Click(object sender, EventArgs e)
        {
            OnBtnTerminarClick?.Invoke(this, e);
            this.Close();
        }

        private void RdPagoCompleto_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rd = (RadioButton)sender;
            if (rd.Checked)
            {
                if (rd.Name.Equals("rdPagoCompleto"))
                {
                    this.gbAbono.Enabled = false;
                }
                else
                {
                    this.gbAbono.Enabled = true;
                }
            }
        }

        private void TxtValorUsuario_KeyPress(object sender, KeyPressEventArgs e)
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
                    this.Calcular();
                    return;
                }
                e.Handled = true;
            }
        }

        private void TxtValorUsuario_LostFocus(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (txt.Equals(""))
                txt.Text = "0";
        }

        private void TxtValorUsuario_GotFocus(object sender, EventArgs e)
        {
            this.txtAbono.SelectAll();
        }

        private void Calcular()
        {
            if (this.ECuenta != null)
            {
                decimal valorTotal = this.ECuenta.Total_pagar;

                if (Convert.ToInt32(this.Total_abonos) != 0)
                    valorTotal = this.ECuenta.Total_pagar - this.Total_abonos;

                if (this.rdAbono.Checked)
                {
                    if (decimal.TryParse(this.txtAbono.Text, out decimal valor_abono))
                    {                       
                        if (valor_abono > valorTotal)
                        {
                            Mensajes.MensajeInformacion("El abono ingresado no puede ser mayor que el total a pagar", "Entendido");
                            return;
                        }
                        else if (valor_abono == valorTotal)
                        {
                            Mensajes.MensajeInformacion("El abono ingresado es igual que el total a pagar, se cambiará a pago completo", "Entendido");
                            this.rdPagoCompleto.Checked = true;
                            return;
                        }
                        else
                        {
                            decimal restante = valorTotal - valor_abono;
                            this.lblRestante.Text = "Resta por pagar: $" + restante.ToString("N2");
                            this.Valor_restante = restante;
                            this.calculadoraVueltos1.Valor_abono = valor_abono;
                            this.calculadoraVueltos1.Calcular();
                            this.Abono = valor_abono;
                        }
                    }
                    else
                    {
                        Mensajes.MensajeErrorForm("Verifique la cantidad de abono ingresada");
                    }
                }
                else
                {
                    this.calculadoraVueltos1.Valor_abono = valorTotal;
                    this.calculadoraVueltos1.Calcular();
                }
            }
        }

        public ECuentas ECuenta;

        public void AsignarDatos(ECuentas eCuenta)
        {
            if (eCuenta != null)
            {
                this.ECuenta = eCuenta;

                FrmObservarAbonos observarAbonos = new FrmObservarAbonos
                {
                    FormBorderStyle = FormBorderStyle.None,
                    TopLevel = false,
                    Dock = DockStyle.Fill
                };

                decimal total_abonos = 0;
                DataTable dtAbonos =
                   EDetalleAbonosCuentas.BuscarAbonos("COMPLETO ID CUENTA", eCuenta.Id_cuenta.ToString(), out string rpta);
                if (dtAbonos != null)
                {                  
                    foreach (DataRow row in dtAbonos.Rows)
                    {
                        decimal abono = Convert.ToDecimal(row["Valor_abono"]);
                        total_abonos += abono;
                    }
                }

                if (total_abonos > 0)
                {
                    this.btnAbonos.Enabled = true;
                    this.lblTotalAbonos.Visible = true;
                    this.lblTotalAbonos.Text = "Total en abonos: $" + total_abonos.ToString("N2");
                    this.Total_abonos = total_abonos;
                    
                    //this.container = new PoperContainer(observarAbonos);
                }
                else
                {
                    this.btnAbonos.Enabled = false;
                    this.lblTotalAbonos.Visible = false;
                }

                this.lblTotal.Text = "Total cuenta: $" + eCuenta.Total_pagar.ToString("N2");
                this.Calcular();
            }
        }

        private decimal _valor_restante;
        private decimal _abono;
        private decimal _total_abonos;

        public decimal Valor_restante { get => _valor_restante; set => _valor_restante = value; }
        public decimal Abono { get => _abono; set => _abono = value; }
        public decimal Total_abonos { get => _total_abonos; set => _total_abonos = value; }
    }
}
