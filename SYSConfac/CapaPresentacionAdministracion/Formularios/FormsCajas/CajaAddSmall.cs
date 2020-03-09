using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;

namespace CapaPresentacionAdministracion.Formularios.FormsCajas
{
    public partial class CajaAddSmall : UserControl
    {
        public CajaAddSmall()
        {
            InitializeComponent();
            this.btnGuardar.Click += BtnGuardar_Click;
            this.txtCaja.KeyPress += Txt_onKeyPress;
        }

        private void Txt_onKeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                this.btnGuardar.PerformClick();
            }
        }

        public event EventHandler OnCajaSuccess;

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtCaja.Text.Equals(""))
                {
                    this.errorProvider1.SetError(this.txtCaja, "El nombre de la caja no puede estar vacío");
                    return;
                }

                ECaja eCaja = new ECaja
                {
                    Nombre_caja = this.txtCaja.Text,
                    Estado_caja = "CERRADA"
                };

                string rpta = ECaja.InsertarCaja(eCaja);
                if (rpta.Equals("OK"))
                {
                    OnCajaSuccess?.Invoke(eCaja, e);
                }
                else
                    throw new Exception(rpta);
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnGuardar_Click",
                    "Hubo un error guardando la caja", ex.Message);
            }
        }
    }
}
