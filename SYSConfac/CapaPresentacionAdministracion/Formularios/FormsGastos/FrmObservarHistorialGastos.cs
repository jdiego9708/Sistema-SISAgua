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

namespace CapaPresentacionAdministracion.Formularios.FormsGastos
{
    public partial class FrmObservarHistorialGastos : Form
    {
        public FrmObservarHistorialGastos()
        {
            InitializeComponent();
            this.dateBusqueda.ValueChanged += DateBusqueda_ValueChanged;
            this.Load += FrmObservarHistorialGastos_Load;
        }

        private void FrmObservarHistorialGastos_Load(object sender, EventArgs e)
        {
            this.BuscarHistorialGastos("FECHA", DateTime.Now.ToString("yyyy-MM-dd"));
        }

        private void DateBusqueda_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker date = (DateTimePicker)sender;
            this.BuscarHistorialGastos("FECHA", date.Value.ToString("yyyy-MM-dd"));
        }

        private void BuscarHistorialGastos(string tipo_busqueda, string texto_busqueda)
        {
            try
            {
                DataTable dtHistorialGastos =
                    EHistorialGastos.BuscarHistorialGastos(tipo_busqueda, texto_busqueda, out string rpta);
                this.dgvHistorialGastos.clearDataSource();
                if (dtHistorialGastos != null)
                {
                    this.lblResultados.Text = "Se encontraron " + dtHistorialGastos.Rows.Count + " gastos.";

                    List<UserControl> controls = new List<UserControl>();
                    foreach(DataRow row in dtHistorialGastos.Rows)
                    {
                        EHistorialGastos eHistorialGasto = new EHistorialGastos(row);
                        HistorialGastoSmall historialGastoSmall = new HistorialGastoSmall();
                        historialGastoSmall.AsignarDatos(eHistorialGasto);
                        controls.Add(historialGastoSmall);
                    }

                    this.dgvHistorialGastos.AddArrayControl(controls);
                }
                else
                {
                    this.lblResultados.Text = "No se encontraron resultados";

                    if (!rpta.Equals("OK"))
                        throw new Exception(rpta);
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BuscarHistorialGastos",
                    "Hubo un error al buscar el historial de gastos", ex.Message);
            }
        }
    }
}
