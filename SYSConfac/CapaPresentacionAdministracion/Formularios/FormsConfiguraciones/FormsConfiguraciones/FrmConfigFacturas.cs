using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacionAdministracion.Formularios.FormsConfiguraciones.FormsConfiguraciones
{
    public partial class FrmConfigFacturas : Form
    {
        public FrmConfigFacturas()
        {
            InitializeComponent();
            this.btnSiguiente.Click += BtnSiguiente_Click;
            this.btnAtras.Click += BtnAtras_Click;
            this.Load += FrmConfigFacturas_Load;

        }

        public string GuardarDatos()
        {
            string rpta = "OK";
            try
            {
                if (this.Comprobaciones())
                {
                    ConfigFacturas.Default.Titulo_reporte = this.txtTitulo.Text;
                    ConfigFacturas.Default.Medida_default = this.listaMedida.Text;
                    ConfigFacturas.Default.Ancho = Convert.ToDecimal(this.txtAncho.Text);
                    ConfigFacturas.Default.Alto = Convert.ToDecimal(this.txtAlto.Text);
                    ConfigFacturas.Default.MargenArriba = Convert.ToDecimal(this.txtArriba.Text);
                    ConfigFacturas.Default.MargenAbajo = Convert.ToDecimal(this.txtBajo.Text);
                    ConfigFacturas.Default.MargenDerecha = Convert.ToDecimal(this.txtDerecha.Text);
                    ConfigFacturas.Default.MargenIzquierda = Convert.ToDecimal(this.txtIzquierda.Text);
                    ConfigFacturas.Default.Save();                  
                }
                else
                    throw new Exception("No se pudo realizar la comprobación");
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            return rpta;
        }

        private void LlenarListasMedidas()
        {
            this.listaMedida.Items.Clear();
            this.listaMedida.Items.Add("CENTIMETROS");
        }

        private void FrmConfigFacturas_Load(object sender, EventArgs e)
        {
            this.AsignarEventos();
            this.LlenarListasMedidas();
        }

        private void AsignarEventos()
        {
            this.txtAncho.KeyPress += OnlyNumbers_KeyPress;
            this.txtAlto.KeyPress += OnlyNumbers_KeyPress;
            this.txtArriba.KeyPress += OnlyNumbers_KeyPress;
            this.txtBajo.KeyPress += OnlyNumbers_KeyPress;
            this.txtDerecha.KeyPress += OnlyNumbers_KeyPress;
            this.txtIzquierda.KeyPress += OnlyNumbers_KeyPress;
        }

        private void OnlyNumbers_KeyPress(object sender, KeyPressEventArgs e)
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

        private bool Comprobaciones()
        {
            if (this.txtTitulo.Text.Equals(""))
            {
                this.errorProvider1.SetError(this.txtTitulo, "El campo no puede estar vacío");
                return false;
            }

            if (this.txtAncho.Text.Equals(""))
            {
                this.errorProvider1.SetError(this.txtAncho, "El campo no puede estar vacío");
                return false;
            }
            else
            {
                if (!decimal.TryParse(this.txtAncho.Text, out decimal _))
                {
                    this.errorProvider1.SetError(this.txtAncho, "Verifique el campo, debe ser un número decimal");
                    return false;
                }
            }

            if (this.txtAlto.Text.Equals(""))
            {
                this.errorProvider1.SetError(this.txtAlto, "El campo no puede estar vacío");
                return false;
            }
            else
            {
                if (!decimal.TryParse(this.txtAlto.Text, out decimal _))
                {
                    this.errorProvider1.SetError(this.txtAlto, "Verifique el campo, debe ser un número decimal");
                    return false;
                }
            }

            if (this.txtArriba.Text.Equals(""))
            {
                this.errorProvider1.SetError(this.txtArriba, "El campo no puede estar vacío");
                return false;
            }
            else
            {
                if (!decimal.TryParse(this.txtArriba.Text, out decimal _))
                {
                    this.errorProvider1.SetError(this.txtArriba, "Verifique el campo, debe ser un número decimal");
                    return false;
                }
            }

            if (this.txtBajo.Text.Equals(""))
            {
                this.errorProvider1.SetError(this.txtBajo, "El campo no puede estar vacío");
                return false;
            }
            else
            {
                if (!decimal.TryParse(this.txtBajo.Text, out decimal _))
                {
                    this.errorProvider1.SetError(this.txtBajo, "Verifique el campo, debe ser un número decimal");
                    return false;
                }
            }

            if (this.txtDerecha.Text.Equals(""))
            {
                this.errorProvider1.SetError(this.txtDerecha, "El campo no puede estar vacío");
                return false;
            }
            else
            {
                if (!decimal.TryParse(this.txtDerecha.Text, out decimal _))
                {
                    this.errorProvider1.SetError(this.txtDerecha, "Verifique el campo, debe ser un número decimal");
                    return false;
                }
            }

            if (this.txtIzquierda.Text.Equals(""))
            {
                this.errorProvider1.SetError(this.txtIzquierda, "El campo no puede estar vacío");
                return false;
            }
            else
            {
                if (!decimal.TryParse(this.txtIzquierda.Text, out decimal _))
                {
                    this.errorProvider1.SetError(this.txtIzquierda, "Verifique el campo, debe ser un número decimal");
                    return false;
                }
            }

            if (this.listaMedida.Text.Equals(""))
            {
                this.errorProvider1.SetError(this.listaMedida, "El campo no puede estar vacío");
                return false;
            }
            else
            {
                //if (!int.TryParse(Convert.ToString(this.listaMedida.SelectedValue), out int _))
                //{
                //    this.errorProvider1.SetError(this.listaMedida, "Verifique el campo la medida seleccionada");
                //    return false;
                //}
            }

            return true;
        }

        private void BtnAtras_Click(object sender, EventArgs e)
        {
            OnBtnAtrasClick?.Invoke(this, e);
        }

        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            if (this.Comprobaciones())
                this.OnBtnSiguienteClick?.Invoke(this, e);
        }

        public event EventHandler OnBtnSiguienteClick;
        public event EventHandler OnBtnAtrasClick;
    }
}
