using CapaEntidades;
using CapaPresentacionAdministracion.Formularios.FormsClientes;
using CapaPresentacionAdministracion.Servicios;
using System;
using System.Windows.Forms;

namespace CapaPresentacionAdministracion.Formularios.FormsCorreos
{
    public partial class FrmEnvioEmail : Form
    {
        public FrmEnvioEmail()
        {
            InitializeComponent();
            this.chkManual.CheckedChanged += ChkManual_CheckedChanged;
            this.btnCliente.Click += BtnCliente_Click;
            this.btnEnviar.Click += BtnEnviar_Click;
        }

        private bool Comprobaciones()
        {
            if (this.chkManual.Checked)
            {
                if (!HelperMail.Email_comprobation(this.txtCorreo.Text))
                {
                    Mensajes.MensajeInformacion("El correo electrónico no tiene un formato correcto", "Entendido");
                    return false;
                }
            }
            else
            {
                if (this.btnCliente.Tag == null)
                {
                    Mensajes.MensajeInformacion("Seleccione un cliente", "Entendido");
                    return false;
                }
            }

            if (string.IsNullOrWhiteSpace(this.txtAsunto.Text))
            {
                Mensajes.MensajeInformacion("El asunto no puede estar vacío", "Entendido");
                return false;
            }

            if (string.IsNullOrWhiteSpace(this.txtMensaje.Text))
            {
                Mensajes.MensajeInformacion("El mensaje no puede estar vacío", "Entendido");
                return false;
            }
            return true;
        }

        private void BtnEnviar_Click(object sender, EventArgs e)
        {
            if (this.Comprobaciones())
            {
                HelperMail helperMail = new HelperMail();
                bool result = helperMail.SendEmailGeneral(this.txtAsunto.Text, this.txtMensaje.Text, this.txtCorreo.Text,
                    out string rpta);
                if (result)
                {
                    Mensajes.MensajeOkForm("¡Correo electrónico enviado correctamente!");
                    this.Close();
                }
                else
                {
                    Mensajes.MensajeErrorCompleto(this.Name, "BtnEnviar_Click",
                        "Hubo un error enviando el correo electrónico", rpta);
                }
            }
        }

        private void BtnCliente_Click(object sender, EventArgs e)
        {
            FrmObservarClientes frmObservarClientes = new FrmObservarClientes
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            frmObservarClientes.OnDgvDoubleClick += FrmObservarClientes_OnDgvDoubleClick;
            frmObservarClientes.ShowDialog();
        }

        private void FrmObservarClientes_OnDgvDoubleClick(object sender, EventArgs e)
        {
            ECliente eCliente = (ECliente)sender;
            this.btnCliente.Text = eCliente.Nombres;
            this.btnCliente.Tag = eCliente;
            this.txtCorreo.Text = eCliente.Correo;
        }

        private void ChkManual_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            if (chk.Checked)
            {
                this.gbCliente.Enabled = false;
                this.txtCorreo.Focus();
            }
            else
            {
                this.gbCliente.Enabled = true;
                this.btnCliente.Focus();
            }
        }
    }
}
