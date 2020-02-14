using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

namespace CapaPresentacionAdministracion.Formularios.FormsAbonos
{
    public partial class CalculadoraVueltos : UserControl
    {
        public CalculadoraVueltos()
        {
            InitializeComponent();
            this.txtValorUsuario.GotFocus += TxtValorUsuario_GotFocus;
            this.txtValorUsuario.LostFocus += TxtValorUsuario_LostFocus;
            this.txtValorUsuario.KeyPress += TxtValorUsuario_KeyPress;
            this.btnRefresh.Click += BtnRefresh_Click;
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            this.Calcular();
        }

        public void Calcular()
        {
            if (decimal.TryParse(this.txtValorUsuario.Text, out decimal valor_usuario))
            {
                if ((int)valor_usuario == 0)
                {
                    this.Cambio = 0;
                    this.lblCambio.Text = "Cambio: $" + 0;
                }
                else
                {
                    if (valor_usuario < this.Valor_abono)
                    {
                        Mensajes.MensajeInformacion("El valor ingresado no puede ser menor que el abono", "Entendido");
                        this.txtValorUsuario.SelectAll();
                        return;
                    }
                    else
                    {
                        this.Cambio = valor_usuario - this.Valor_abono;
                        this.lblCambio.Text = "Cambio: $" + this.Cambio.ToString("N2");
                    }
                }
            }
            else
            {
                Mensajes.MensajeErrorForm("Verifique la cantidad ingresada");
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
            this.txtValorUsuario.SelectAll();
        }

        private void ValorAbonoChanged(decimal abono)
        {
            this.lblValorAbono.Text = "$" + abono.ToString("N2");
        }

        private decimal _valor_abono;
        private decimal _cambio;

        public decimal Valor_abono
        {
            get => _valor_abono;
            set
            {
                _valor_abono = value;
                this.ValorAbonoChanged(value);
            }
        }
        public decimal Cambio { get => _cambio; set => _cambio = value; }
    }
}
