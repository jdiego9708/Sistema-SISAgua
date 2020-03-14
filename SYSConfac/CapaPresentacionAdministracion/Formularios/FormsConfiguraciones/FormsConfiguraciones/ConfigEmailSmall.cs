using System;
using System.Windows.Forms;
using CapaPresentacionAdministracion.Controles;
using System.Globalization;
using System.Threading;
using CapaPresentacionAdministracion.Servicios;

namespace CapaPresentacionAdministracion.Formularios.FormsConfiguraciones.FormsConfiguraciones
{
    public partial class ConfigEmailSmall : UserControl
    {
        PoperContainer container;
        HelpToolTip helpToolTip;
        public ConfigEmailSmall()
        {
            InitializeComponent();
            this.btnAyudaCorreo.MouseEnter += BtnAyudaCorreo_MouseEnter;
            this.btnAyudaCorreo.MouseLeave += BtnAyudaCorreo_MouseLeave;
            this.txtPuerto.KeyPress += OnlyNumbers_KeyPress;
            this.txtCorreoEnvio.LostFocus += TxtCorreoEnvio_LostFocus;
            this.btnPrueba.Click += BtnPrueba_Click;
        }

        private void BtnPrueba_Click(object sender, EventArgs e)
        {
            if (this.Comprobaciones())
            {
                HelperMail helperMail = new HelperMail();
                if (helperMail.SendEmailTest(this.txtCorreoEnvio.Text, this.txtCorreoRecepcion.Text, this.txtServidorSMTP.Text,
                    int.Parse(this.txtPuerto.Text), this.txtContraseña.Text, this.Tipo_email, out string rpta))
                {
                    Mensajes.MensajeOkForm("¡Se envió el correo de prueba correctamente!");
                }
                else
                {
                    Mensajes.MensajeInformacion("Hubo un error al enviar el correo electrónico de prueba, detalles: " +
                        rpta, "Entendido");
                }
            }
        }

        public bool AsignarDatos()
        {
            bool result = false;
            if (this.Tipo_email != null)
            {
                result = true;
                if (this.Tipo_email.Equals("ERRORES"))
                {
                    this.txtCorreoEnvio.Text = ConfigEmail.Default.Email_errores;
                    this.txtContraseña.Text = ConfigEmail.Default.Password_email_errores;
                    this.txtCorreoRecepcion.Text = ConfigEmail.Default.Email_recepcion_errores;
                    this.txtServidorSMTP.Text = ConfigEmail.Default.Server_smtp_errores;
                    this.txtPuerto.Text = ConfigEmail.Default.Port_server_errores;

                    if (string.IsNullOrWhiteSpace(this.txtCorreoEnvio.Text))
                        result = false;

                    if (string.IsNullOrWhiteSpace(this.txtContraseña.Text))
                        result = false;

                    if (string.IsNullOrWhiteSpace(this.txtCorreoRecepcion.Text))
                        result = false;

                    if (string.IsNullOrWhiteSpace(this.txtServidorSMTP.Text))
                        result = false;

                    if (string.IsNullOrWhiteSpace(this.txtPuerto.Text))
                        result = false;

                    if (!HelperMail.Email_comprobation(this.txtCorreoEnvio.Text))                  
                        result = false;

                    if (!HelperMail.Email_comprobation(this.txtCorreoRecepcion.Text))
                        result = false;
                }

                if (this.Tipo_email.Equals("REPORTES"))
                {
                    this.txtCorreoEnvio.Text = ConfigEmail.Default.Email_reportes;
                    this.txtContraseña.Text = ConfigEmail.Default.Password_email_reportes;
                    this.txtCorreoRecepcion.Text = ConfigEmail.Default.Email_recepcion_reportes;
                    this.txtServidorSMTP.Text = ConfigEmail.Default.Server_smtp_reportes;
                    this.txtPuerto.Text = ConfigEmail.Default.Port_server_reportes;

                    if (string.IsNullOrWhiteSpace(this.txtCorreoEnvio.Text))
                        result = false;

                    if (string.IsNullOrWhiteSpace(this.txtContraseña.Text))
                        result = false;

                    if (string.IsNullOrWhiteSpace(this.txtCorreoRecepcion.Text))
                        result = false;

                    if (string.IsNullOrWhiteSpace(this.txtServidorSMTP.Text))
                        result = false;

                    if (string.IsNullOrWhiteSpace(this.txtPuerto.Text))
                        result = false;

                    if (!HelperMail.Email_comprobation(this.txtCorreoEnvio.Text))
                        result = false;

                    if (!HelperMail.Email_comprobation(this.txtCorreoRecepcion.Text))
                        result = false;
                }
            }
            return result;
        }

        public bool Comprobaciones()
        {
            if (!HelperMail.Email_comprobation(this.txtCorreoEnvio.Text))
            {
                this.errorProvider1.SetError(this.txtCorreoEnvio, "Verifique el formato del correo electrónico");
                return false;
            }

            if (!HelperMail.Email_comprobation(this.txtCorreoRecepcion.Text))
            {
                this.errorProvider1.SetError(this.txtCorreoRecepcion, "Verifique el formato del correo electrónico");
                return false;
            }

            if (!int.TryParse(this.txtPuerto.Text, out int _))
            {
                this.errorProvider1.SetError(this.txtPuerto, "Verifique el formato del correo electrónico");
                return false;
            }

            if (string.IsNullOrEmpty(this.txtContraseña.Text))
            {
                this.errorProvider1.SetError(this.txtContraseña, "Verifique la contraseña");
                return false;
            }

            return true;
        }

        private void TxtCorreoEnvio_LostFocus(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (!HelperMail.Email_comprobation(txt.Text))
            {
                this.errorProvider1.SetError(txt, "Verifique el formato del correo electrónico");
            }
        }

        private void OnlyNumbers_KeyPress(object sender, KeyPressEventArgs e)
        {
            CultureInfo cc = Thread.CurrentThread.CurrentCulture;
            if (char.IsDigit(e.KeyChar) || (int)e.KeyChar == (int)Keys.Back)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void BtnAyudaCorreo_MouseLeave(object sender, EventArgs e)
        {
            if (this.container != null)
                this.container.Close();
        }

        private void BtnAyudaCorreo_MouseEnter(object sender, EventArgs e)
        {
            if (this.helpToolTip != null)
            {
                this.container = new PoperContainer(this.helpToolTip);
                this.container.Show(this.btnAyudaCorreo);
            }
        }

        private void AsignarDatos(string tipo)
        {
            if (tipo.Equals("ERRORES"))
            {
                this.gbCorreo.Text = "Envío de correo de errores";
                this.helpToolTip = new HelpToolTip
                {
                    Texto = "Se trata del correo electrónico usado para enviar los tickets de los errores que aparezcan en el sistema"
                };
                return;
            }

            if (tipo.Equals("REPORTES"))
            {
                this.gbCorreo.Text = "Envío de correo de reportes";
                this.helpToolTip = new HelpToolTip
                {
                    Texto = "Se trata del correo electrónico usado para enviar los reportes del sistema"
                };
                return;
            }
        }

        private string _tipo_email;

        public string Tipo_email
        {
            get => _tipo_email;
            set
            {
                _tipo_email = value;
                this.AsignarDatos(value);
                this.AsignarDatos();
            }
        }
    }
}
