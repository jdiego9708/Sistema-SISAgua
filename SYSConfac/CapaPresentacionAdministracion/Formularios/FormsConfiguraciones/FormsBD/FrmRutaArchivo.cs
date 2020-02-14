using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacionAdministracion.Formularios.FormsConfiguraciones.FormsBD
{
    public partial class FrmRutaArchivo : Form
    {
        public FrmRutaArchivo()
        {
            InitializeComponent();
            this.Load += FrmRutaArchivo_Load;
            this.txtRutaArchivos.Click += TxtRutaArchivos_Click;
            this.btnGuardar.Click += BtnGuardar_Click;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.txtRutaArchivos.Text.Equals(""))
                {
                    Configuration config1 = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    config1.AppSettings.Settings["RutaDestinoArchivos"].Value = this.txtRutaArchivos.Text;
                    config1.Save(ConfigurationSaveMode.Modified, true);
                    ConfigurationManager.RefreshSection("appSettings");
                    Mensajes.MensajeOkForm("Se guardó la ruta correctamente");
                }
                else
                    Mensajes.MensajeInformacion("Por favor seleccione una ruta válida", "Entendido");
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnGuardar_Click",
                    "Hubo un error al guardar la ruta de los archivos", ex.Message);
            }
        }

        private void TxtRutaArchivos_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string folderName = fbd.SelectedPath;
                    this.txtRutaArchivos.Text = folderName;
                }
                else
                {
                    this.txtRutaArchivos.Text = "";
                }
            }
        }

        private void ObtenerRutaArchivos()
        {
            this.txtRutaArchivos.Text = Convert.ToString(ConfigurationManager.AppSettings["RutaDestinoArchivos"]);
        }

        private void FrmRutaArchivo_Load(object sender, EventArgs e)
        {
            this.ObtenerRutaArchivos();
        }
    }
}
