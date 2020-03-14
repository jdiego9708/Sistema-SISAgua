using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacionAdministracion.Formularios.FormsConfiguraciones.FormsConfiguraciones
{
    public partial class FrmConfigCorreos : Form
    {
        public FrmConfigCorreos()
        {
            InitializeComponent();
            this.btnAtras.Click += BtnAtras_Click;
            this.btnSiguiente.Click += BtnSiguiente_Click;
        }

        public bool AsignarDatos()
        {
            bool result = this.emailErrores.AsignarDatos();
            if (result)
            {
                result = this.emailReportes.AsignarDatos();
                if (!result)
                    return false;
            }
            else
                return false;

            return true;
        }

        public string GuardarDatos()
        {
            string rpta = "OK";
            try
            {
                if (this.Comprobaciones())
                {
                    ConfigEmail.Default.Email_errores = this.emailErrores.txtCorreoEnvio.Text;
                    ConfigEmail.Default.Password_email_errores = this.emailErrores.txtContraseña.Text;
                    ConfigEmail.Default.Email_recepcion_errores = this.emailErrores.txtCorreoRecepcion.Text;
                    ConfigEmail.Default.Server_smtp_errores = this.emailErrores.txtServidorSMTP.Text;
                    ConfigEmail.Default.Port_server_errores = this.emailErrores.txtPuerto.Text;
                    ConfigEmail.Default.Email_reportes = this.emailReportes.txtCorreoEnvio.Text;
                    ConfigEmail.Default.Password_email_reportes = this.emailReportes.txtContraseña.Text;
                    ConfigEmail.Default.Email_recepcion_reportes = this.emailReportes.txtCorreoRecepcion.Text;
                    ConfigEmail.Default.Server_smtp_reportes = this.emailReportes.txtServidorSMTP.Text;
                    ConfigEmail.Default.Port_server_reportes = this.emailReportes.txtPuerto.Text;
                    ConfigEmail.Default.Save();
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
            if (!this.emailErrores.Comprobaciones())
            {
                return false;
            }

            if (!this.emailReportes.Comprobaciones())
            {
                return false;
            }

            return true;
        }

        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            if (this.Comprobaciones())
                this.OnBtnSiguienteClick?.Invoke(this, e);
        }

        private void BtnAtras_Click(object sender, EventArgs e)
        {
            this.OnBtnAtrasClick?.Invoke(this, e);
        }

        public event EventHandler OnBtnSiguienteClick;
        public event EventHandler OnBtnAtrasClick;
    }
}
