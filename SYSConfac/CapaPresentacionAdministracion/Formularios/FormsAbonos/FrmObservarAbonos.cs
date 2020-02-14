using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacionAdministracion.Formularios.FormsAbonos
{
    public partial class FrmObservarAbonos : Form
    {
        public FrmObservarAbonos()
        {
            InitializeComponent();
        }

        public bool BuscarAbonos(string tipo_busqueda, string texto_busqueda)
        {
            bool result = true;
            try
            {
                DataTable dtAbonos = EDetalleAbonosCuentas.BuscarAbonos(tipo_busqueda, texto_busqueda, out string rpta);
                this.panelAbono.Limpiar();
                if (dtAbonos != null)
                {
                    this.lblResultados.Text = "Se han realizado " + dtAbonos.Rows.Count + " abonos";

                    decimal total_abonos = 0;

                    List<UserControl> controls = new List<UserControl>();
                    foreach (DataRow row in dtAbonos.Rows)
                    {
                        EDetalleAbonosCuentas abono = new EDetalleAbonosCuentas(row);
                        AbonoSmall abonoSmall = new AbonoSmall();
                        abonoSmall.AsignarDatos(abono);
                        controls.Add(abonoSmall);

                        total_abonos += abono.Valor_abono;
                    }
                    this.panelAbono.AddArrayControl(controls);

                    this.Total_abonos = total_abonos;
                    this.lblTotalAbonos.Text = "Total en abonos: $" + total_abonos.ToString("N2");
                }
                else
                {
                    this.lblResultados.Text = "No se encontraron abonos";
                    result = false;
                    if (!rpta.Equals("OK"))
                        throw new Exception(rpta);
                }
            }
            catch (Exception ex)
            {
                result = false;
                Mensajes.MensajeErrorCompleto(this.Name, "BuscarAbonos",
                    "Hubo un error al buscar abonos", ex.Message);
            }
            return result;
        }

        private decimal _total_abonos;

        public decimal Total_abonos { get => _total_abonos; set => _total_abonos = value; }
    }
}
