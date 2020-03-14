using CapaEntidades;
//using CapaPresentacionAdministracion.Formularios.FormsDireccionClientes;
using System;
using System.Windows.Forms;

namespace CapaPresentacionAdministracion.Formularios.FormsClientes
{
    public partial class FrmDireccionesCliente : Form
    {
        public FrmDireccionesCliente()
        {
            InitializeComponent();
        }

        public ECliente ECliente;
        public void AsignarDatos(ECliente eCliente)
        {
            this.ECliente = eCliente;

            this.direccionesCliente1.IsLectura = this.IsLectura;
            this.direccionesCliente1.IsObservarLectura = this.IsObservarLectura;
            this.direccionesCliente1.AsignarDatos(eCliente);
            this.direccionesCliente1.OnBtnNextClick += DireccionesCliente1_OnBtnNextClick;
        }

        private void DireccionesCliente1_OnBtnNextClick(object sender, EventArgs e)
        {
            OnBtnNextClick?.Invoke(sender, e);
            if (this.IsLectura)
                this.Close();
        }

        public event EventHandler OnBtnNextClick;

        private bool _isLectura = false;
        private bool _isObservarLectura = false;
        public bool IsLectura { get => _isLectura; set => _isLectura = value; }
        public bool IsObservarLectura { get => _isObservarLectura; set => _isObservarLectura = value; }
    }
}
