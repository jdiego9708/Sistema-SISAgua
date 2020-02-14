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
    public partial class DiaSmall : UserControl
    {
        public DiaSmall()
        {
            InitializeComponent();
        }

        public EPago_cuenta EPago_Cuenta;
        public EDetalleAbonosCuentas EAbono;
        public EHistorialGastos EHistorialGasto;

        public void AsignarDatos(EHistorialGastos eHistorial)
        {
            this.EHistorialGasto = eHistorial;
            groupBox1.Text = "Empleado que realiza el gasto";
            this.txtCliente.Text = eHistorial.EEmpleado.Nombre_completo;
            groupBox2.Text = "Titulo del gasto";
            this.txtTarifa.Text = eHistorial.EGasto.Titulo_gasto;
            this.txtValorPagado.Text = "$" + eHistorial.Valor_gasto.ToString("N2");
        }

        public void AsignarDatos(EPago_cuenta ePago_Cuenta)
        {
            this.EPago_Cuenta = ePago_Cuenta;
            this.txtCliente.Text = ePago_Cuenta.ECuenta.ECliente.Nombres + " " +
                ePago_Cuenta.ECuenta.ECliente.Apellidos + " - " +
                ePago_Cuenta.ECuenta.ECliente.Identificacion;
            this.txtTarifa.Text = ePago_Cuenta.ECuenta.ETarifa.Descripcion;
            this.txtValorPagado.Text = "$" + ePago_Cuenta.ECuenta.Total_pagar.ToString("N2");
        }

        public void AsignarDatos(EDetalleAbonosCuentas eAbonos)
        {
            this.EAbono = eAbonos;
            this.txtCliente.Text = eAbonos.ECuenta.ECliente.Nombres + " " +
                eAbonos.ECuenta.ECliente.Apellidos + " - " +
                eAbonos.ECuenta.ECliente.Identificacion;
            this.txtTarifa.Text = "ABONO";
            this.txtValorPagado.Text = "$" + eAbonos.Valor_abono.ToString("N2");
        }
    }
}
