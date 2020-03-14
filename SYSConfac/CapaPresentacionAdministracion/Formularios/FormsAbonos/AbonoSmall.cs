using CapaEntidades;
using System;
using System.Windows.Forms;

namespace CapaPresentacionAdministracion.Formularios.FormsAbonos
{
    public partial class AbonoSmall : UserControl
    {
        public AbonoSmall()
        {
            InitializeComponent();
        }

        public EDetalleAbonosCuentas EAbono;

        public void AsignarDatos(EDetalleAbonosCuentas abono)
        {
            if (abono != null)
            {
                this.EAbono = abono;
                this.txtFechaHora.Text = abono.Fecha_abono.ToLongDateString() + " - " +
                    Convert.ToDateTime(abono.Hora_abono).ToLongTimeString();
                this.txtValor.Text = "$" + abono.Valor_abono.ToString("N2");
                this.lblValorEstante.Text = "Valor restante: $" + abono.Valor_restante.ToString("N2");
                this.toolTip1.SetToolTip(this.lblObservaciones, abono.Observaciones);
            }
        }
    }
}
