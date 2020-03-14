using CapaEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacionAdministracion.Formularios.FormsCajas
{
    public partial class FrmVerificacion : Form
    {
        public FrmVerificacion()
        {
            InitializeComponent();
            this.btnIngresar.Click += BtnIngresar_Click;
            this.txtClave.KeyPress += TxtClave_KeyPress;
            this.btnCancelar.Click += BtnCancelar_Click;
            this.Load += FrmVerificacion_Load;
        }

        private void FrmVerificacion_Load(object sender, EventArgs e)
        {
            this.txtClave.Focus();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                this.btnIngresar.PerformClick();
            }
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            DataTable tabla = EEmpleado.Login(this.EEmpleado.Nombre_completo,
                this.txtClave.Text, out string rpta);
            if (tabla != null)
            {
                OnLogin?.Invoke(new EEmpleado(tabla, 0), e);
                this.Close();
            }
            else
            {
                if (!rpta.Equals("OK"))
                    Mensajes.MensajeInformacion("Hubo un error al buscar el empleado " + rpta, "Entendido");

                Mensajes.MensajeInformacion("No se encontró el usuario, intentelo de nuevo", "Entendido");
            }
        }

        EEmpleado EEmpleado;

        public void AsignarDatos(EEmpleado eEmpleado)
        {
            this.EEmpleado = eEmpleado;
            this.txtEmpleado.Text = "Por favor escriba la clave para el usuario " +
                eEmpleado.Nombre_completo;
        }

        public event EventHandler OnLogin;
    }
}
