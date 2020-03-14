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
    public partial class CierreSmall : UserControl
    {
        public CierreSmall()
        {
            InitializeComponent();
            this.btnDetalles.Click += BtnDetalles_Click;
        }

        private void BtnDetalles_Click(object sender, EventArgs e)
        {
            FrmCerrarCaja frmCerrarCaja = new FrmCerrarCaja
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            frmCerrarCaja.AsignarDatos(this.ECierre);
            frmCerrarCaja.ShowDialog();
        }

        public ECierre ECierre;

        public void AsignarDatos(ECierre eCierre)
        {
            this.ECierre = eCierre;
            this.txtEmpleado.Text = eCierre.EEmpleado.Nombre_completo;
            this.txtFechaCierre.Text = eCierre.Fecha_cierre.ToLongDateString();
            this.txtDeposito.Text = "$" + eCierre.Deposito.ToString("N2");
        }
    }
}
