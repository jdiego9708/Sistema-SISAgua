using CapaEntidades;
using CapaPresentacionAdministracion.Formularios.FormsCuentas;
using System.Windows.Forms;

namespace CapaPresentacionAdministracion.Formularios.FormsReportes
{
    public partial class ReporteSmall : UserControl
    {
        public ReporteSmall()
        {
            InitializeComponent();
            this.btnOpciones.Click += BtnOpciones_Click;
        }

        private void BtnOpciones_Click(object sender, System.EventArgs e)
        {
            if (this.EPago != null)
            {
                FrmTerminarCuenta frmTerminarCuenta = new FrmTerminarCuenta
                {
                    StartPosition = FormStartPosition.CenterScreen
                };
                frmTerminarCuenta.AsignarDatos(this.EPago.ECuenta);
                frmTerminarCuenta.ShowDialog();
            }
        }

        public EPago_cuenta EPago;
        public EDetalleAbonosCuentas EAbono;

        public void AsignarDatos(EPago_cuenta ePago)
        {
            this.EPago = ePago;

            this.txtCliente.Text = ePago.ECuenta.ECliente.Nombres + " " +
                ePago.ECuenta.ECliente.Apellidos + " - C.I: " + ePago.ECuenta.ECliente.Identificacion;
            this.txtFechaPago.Text = ePago.Fecha_pago.ToLongDateString();
            this.txtValorPagado.Text = "$" + ePago.ECuenta.Total_pagar.ToString("N2");
            this.btnOpciones.Visible = true;
        }

        public void AsignarDatos(EDetalleAbonosCuentas eAbono)
        {
            this.EAbono = eAbono;

            this.txtCliente.Text = eAbono.ECuenta.ECliente.Nombres + " " +
                eAbono.ECuenta.ECliente.Apellidos + " - C.I: " + eAbono.ECuenta.ECliente.Identificacion;
            this.txtFechaPago.Text = eAbono.Fecha_abono.ToLongDateString();
            this.txtValorPagado.Text = "$" + eAbono.Valor_abono.ToString("N2");
            this.btnOpciones.Visible = false;
        }
    }
}
