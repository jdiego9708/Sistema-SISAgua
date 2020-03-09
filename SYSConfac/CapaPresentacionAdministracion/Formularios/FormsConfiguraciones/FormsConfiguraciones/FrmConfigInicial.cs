using CapaPresentacionAdministracion.Servicios;
using System;
using System.Windows.Forms;

namespace CapaPresentacionAdministracion.Formularios.FormsConfiguraciones.FormsConfiguraciones
{
    public partial class FrmConfigInicial : Form
    {
        public FrmConfigInicial()
        {
            InitializeComponent();
            this.Load += FrmConfigInicial_Load;
            this.btnCancelar.Click += BtnCancelar_Click;
            this.btnSiguiente.Click += BtnSiguiente_Click;
        }

        public string GuardarDatos()
        {
            string rpta = "OK";
            try
            {
                if (this.Comprobaciones())
                {
                    ConfigGeneral.Default.Nombre_empresa = this.txtEmpresa.Text;
                    ConfigGeneral.Default.Nombre_presidente = this.txtPresidente.Text;     
                    ConfigGeneral.Default.Correo_presidente = this.txtCorreo.Text;
                    ConfigGeneral.Default.Telefono_empresa = this.txtTeléfono.Text;
                    ConfigGeneral.Default.Direccion_empresa = this.txtDireccion.Text;
                    ConfigGeneral.Default.Ciudad_empresa = this.txtCiudad.Text;
                    ConfigGeneral.Default.Save();
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

        private bool Comprobaciones()
        {
            if (this.txtEmpresa.Text.Equals(""))
            {
                this.errorProvider1.SetError(this.txtEmpresa, "El campo no puede estar vacío");
                return false;
            }

            if (this.txtDireccion.Text.Equals(""))
            {
                this.errorProvider1.SetError(this.txtDireccion, "El campo no puede estar vacío");
                return false;
            }

            if (this.txtCiudad.Text.Equals(""))
            {
                this.errorProvider1.SetError(this.txtCiudad, "El campo no puede estar vacío");
                return false;
            }

            if (this.txtTeléfono.Text.Equals(""))
            {
                this.errorProvider1.SetError(this.txtTeléfono, "El campo no puede estar vacío");
                return false;
            }

            if (!HelperMail.Email_comprobation(this.txtCorreo.Text))
            {
                this.errorProvider1.SetError(this.txtCorreo, "Verifique el formato del correo electrónico");
                return false;
            }

            return true;
        }

        public event EventHandler OnBtnCancelarClick;
        public event EventHandler OnBtnSiguienteClick;

        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            if (this.Comprobaciones())
                OnBtnSiguienteClick?.Invoke(this, e);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            OnBtnCancelarClick?.Invoke(this, e);
        }

        private void FrmConfigInicial_Load(object sender, EventArgs e)
        {
            this.AsignarDatos();
        }

        private void AsignarDatos()
        {
            this.txtEmpresa.Text = ConfigGeneral.Default.Nombre_empresa;
            this.txtPresidente.Text = ConfigGeneral.Default.Nombre_presidente;
            this.txtCorreo.Text = ConfigGeneral.Default.Correo_presidente;
            this.txtDireccion.Text = ConfigGeneral.Default.Direccion_empresa;
            this.txtCiudad.Text = ConfigGeneral.Default.Ciudad_empresa;
            this.txtTeléfono.Text = ConfigGeneral.Default.Telefono_empresa;
        }
    }
}
