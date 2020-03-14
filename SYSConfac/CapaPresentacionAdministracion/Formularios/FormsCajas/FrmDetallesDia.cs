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
    public partial class FrmDetallesDia : Form
    {
        public FrmDetallesDia()
        {
            InitializeComponent();
        }

        public void BuscarDetalles(DataTable dtPagos, DataTable dtAbonos, DataTable dtGastos)
        {
            List<UserControl> controls = new List<UserControl>();

            if (dtPagos != null)
            {
                foreach (DataRow row in dtPagos.Rows)
                {
                    EPago_cuenta ePago_Cuenta = new EPago_cuenta(row);
                    DiaSmall diaSmall = new DiaSmall();
                    diaSmall.AsignarDatos(ePago_Cuenta);
                    controls.Add(diaSmall);
                }
            }

            if (dtAbonos != null)
            {
                foreach (DataRow row in dtAbonos.Rows)
                {
                    EDetalleAbonosCuentas eAbonos = new EDetalleAbonosCuentas(row);
                    DiaSmall diaSmall = new DiaSmall();
                    diaSmall.AsignarDatos(eAbonos);
                    controls.Add(diaSmall);
                }
            }

            if (dtGastos != null)
            {
                foreach (DataRow row in dtGastos.Rows)
                {
                    EHistorialGastos eHistorialGasto = new EHistorialGastos(row);
                    DiaSmall diaSmall = new DiaSmall();
                    diaSmall.AsignarDatos(eHistorialGasto);
                    controls.Add(diaSmall);
                }
            }

            if (controls.Count > 0)
            {
                this.panel1.AddArrayControl(controls);
                this.lblResultados.Text = "Se encontraron " + panel1.controls.Count + " movimientos de caja";
            }
            else
            {
                this.lblResultados.Text = "No se encontraron movimientos de caja";
            }
        }
    }
}
