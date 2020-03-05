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

        private event EventHandler OnBtnCancelarClick;
        private event EventHandler OnBtnSiguienteClick;

        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            OnBtnSiguienteClick?.Invoke(sender, e);
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
