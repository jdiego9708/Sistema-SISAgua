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
    public partial class FrmHistorialCierreCaja : Form
    {
        public FrmHistorialCierreCaja()
        {
            InitializeComponent();
            this.dateTimePicker1.ValueChanged += DateTimePicker1_ValueChanged;
            this.Load += FrmHistorialCierreCaja_Load;
        }

        private void FrmHistorialCierreCaja_Load(object sender, EventArgs e)
        {
            this.BuscarCierres("FECHA", DateTime.Now.ToString("yyyy-MM-dd"));
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            this.BuscarCierres("FECHA", this.dateTimePicker1.Value.ToString("yyyy-MM-dd"));
        }

        private void BuscarCierres(string tipo_busqueda, string texto_busqueda)
        {
            try
            {
                DataTable dtCierres = ECierre.BuscarCierres(tipo_busqueda, texto_busqueda, out string rpta);
                this.panel1.clearDataSource();
                if (dtCierres != null)
                {
                    this.lblResultados.Text = "Se encontraron " + dtCierres.Rows.Count + " cierres.";
                    List<UserControl> controls = new List<UserControl>();
                    foreach(DataRow row in dtCierres.Rows)
                    {
                        CierreSmall cierreSmall = new CierreSmall();
                        ECierre eCierre = new ECierre(row);
                        cierreSmall.AsignarDatos(eCierre);
                        controls.Add(cierreSmall);
                    }
                    this.panel1.AddArrayControl(controls);
                }
                else
                {
                    this.lblResultados.Text = "No se encontraron cierres.";
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BuscarCierres",
                    "Hubo un error al buscar el historial de cierres", ex.Message);
            }
        }
    }
}
