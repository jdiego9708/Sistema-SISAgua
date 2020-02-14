using CapaEntidades;
using System;
using System.Data;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacionAdministracion.Formularios.FormsCajas
{
    public partial class FrmAbrirCaja : Form
    {
        public FrmAbrirCaja()
        {
            InitializeComponent();
            this.txtValorInicial.KeyPress += TxtValorInicial_KeyPress;
            this.txtValorInicial.GotFocus += TxtValorInicial_GotFocus;
            this.txtValorInicial.LostFocus += TxtValorInicial_LostFocus;
            this.txtValorInicial.Click += TxtValorInicial_Click;
            this.btnAbrirCaja.Click += BtnAbrirCaja_Click;
        }

        public event EventHandler OnCajaModified;

        private bool Comprobaciones(out EApertura eApertura)
        {
            eApertura = new EApertura();
            if (decimal.TryParse(this.txtValorInicial.Text, out decimal valor_inicial))
            {
                if (Convert.ToInt32(valor_inicial) == 0)
                {
                    if (Convert.ToInt32(this.Deposito) == 0)
                    {
                        Mensajes.MensajeInformacion("No hay deposito y el valor inicial es 0, " +
                            "por favor ingrese un valor inicial superior a 0", "Entendido");
                        return false;
                    }

                    Mensajes.MensajePregunta("¿Seguro que desea abrir la caja solo con el deposito anterior?",
                        "ABRIR", "CANCELAR", out DialogResult dialog);
                    if (dialog == DialogResult.No)
                    {
                        Mensajes.MensajeInformacion("El valor inicial debe ser diferente de 0", "Entendido");
                        return false;
                    }
                    valor_inicial += this.Deposito;
                }
                else
                {
                    valor_inicial += this.Deposito;
                }

                if (decimal.TryParse(this.txtDepositoAnterior.Text, out decimal deposito_anterior))
                {
                    valor_inicial += deposito_anterior;
                }

                eApertura.EEmpleado = new EEmpleado
                {
                    Id_empleado = Convert.ToInt32(this.txtEmpleado.Tag)
                };
                eApertura.ECaja = new ECaja
                {
                    Id_caja = Convert.ToInt32(this.txtCaja.Tag)
                };
                eApertura.Fecha = DateTime.Now;
                eApertura.Hora = DateTime.Now.ToShortTimeString();
                eApertura.Valor_inicial = valor_inicial;
                return true;
            }
            else
            {
                Mensajes.MensajeInformacion("Verifique el valor", "Entendido");
                return false;
            }
        }

        private void BtnAbrirCaja_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Comprobaciones(out EApertura eApertura))
                {
                    string rpta =
                        EApertura.InsertarApertura(eApertura);
                    if (rpta.Equals("OK"))
                    {
                        Mensajes.MensajeOkForm("Se abrió la caja correctamente");
                        OnCajaModified?.Invoke(eApertura, e);
                        this.Close();
                    }
                    else
                    {
                        throw new Exception(rpta);
                    }
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnAbrirCaja_Click",
                    "Hubo un error al abrir la caja", ex.Message);
            }
        }

        private void TxtValorInicial_Click(object sender, EventArgs e)
        {
            this.txtValorInicial.SelectAll();
        }

        private void TxtValorInicial_LostFocus(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (txt.Text.Equals(""))
                txt.Text = "0";
        }

        private void TxtValorInicial_GotFocus(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.SelectAll();
        }

        private void TxtValorInicial_KeyPress(object sender, KeyPressEventArgs e)
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
                e.Handled = true;
            }
        }

        public void AsignarDatos(ECaja eCaja, EEmpleado eEmpleado)
        {
            this.eCaja = eCaja;
            this.txtCaja.Text = eCaja.Nombre_caja;
            this.txtCaja.Tag = eCaja.Id_caja;

            this.txtEmpleado.Text = eEmpleado.Nombre_completo;
            this.txtEmpleado.Tag = eEmpleado.Id_empleado;

            this.txtFechaHora.Text = DateTime.Now.ToLongDateString() + " - " +
                DateTime.Now.ToLongTimeString();

            DataTable dtCierre = 
                ECierre.BuscarCierres("ID CAJA", eCaja.Id_caja.ToString(), out string rpta);
            if (dtCierre != null)
            {
                ECierre cierre = new ECierre(dtCierre, 0);
                this.Deposito = cierre.Deposito;
                this.txtDepositoAnterior.Text = cierre.Deposito.ToString("N2");
            }
            else
            {
                if (!rpta.Equals("OK"))
                    Mensajes.MensajeInformacion("No se pudo encontrar el cierre anterior " +
                        "con el deposito debido a un error inesperado", "Entendido");
            }
        }

        private ECaja eCaja;
        private decimal Deposito;
    }
}
