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

        private bool Comprobaciones()
        {
            if (this.txtEmpresa.Text.Equals(""))
            {
                this.errorProvider1.SetError(this.txtEmpresa, "El campo no puede estar vacío");
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
            OnBtnCancelarClick?.Invoke(sender, e);
        }

        private void FrmConfigInicial_Load(object sender, EventArgs e)
        {
            this.AsignarDatos();
        }

        private void AsignarDatos()
        {
            this.txtEmpresa.Text = ConfigGeneral.Default.Nombre_empresa;
            this.txtPresidente.Text = ConfigGeneral.Default.Nombre_presidente;
        }
    }
}
