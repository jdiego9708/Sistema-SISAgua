using CapaEntidades;
using CapaPresentacionAdministracion.Formularios.FormsTarifas;
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

namespace CapaPresentacionAdministracion.Formularios.FormsConfiguraciones.FormsTarifas
{
    public partial class FrmConfiguracionTarifas : Form
    {
        public FrmConfiguracionTarifas()
        {
            InitializeComponent();
            this.Load += FrmConfiguracionTarifas_Load;
            this.btnTarifaSesion.Click += BtnTarifaSesion_Click;
            this.btnTarifaLectura.Click += BtnTarifaLectura_Click;
            this.btnGuardar.Click += BtnGuardar_Click;
        }

        private bool Comprobacion()
        {
            if (!int.TryParse(Convert.ToString(this.btnTarifaSesion.Tag), out int id_tarifa_sesion))
            {
                Mensajes.MensajeInformacion("Debe seleccionar una tarifa válida para la sesión", "Entendido");
                return false;
            }

            if (!int.TryParse(Convert.ToString(this.btnTarifaLectura.Tag), out int id_tarifa_lectura))
            {
                Mensajes.MensajeInformacion("Debe seleccionar una tarifa válida para la lectura", "Entendido");
                return false;
            }

            return true;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Comprobacion())
                {
                    Configuration config1 = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    config1.AppSettings.Settings["Id_tarifa_predeterminada_sesion"].Value = Convert.ToString(this.btnTarifaSesion.Tag);
                    config1.AppSettings.Settings["Id_tarifa_predeterminada_lectura"].Value = Convert.ToString(this.btnTarifaLectura.Tag);
                    config1.Save(ConfigurationSaveMode.Modified, true);
                    ConfigurationManager.RefreshSection("appSettings");
                    Mensajes.MensajeOkForm("Se guardó la información de las tarifas correctamente");
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnGuardar_Click",
                    "Hubo un error al configurar las tarifas predeterminadas", ex.Message);
            }
        }

        private void BtnTarifaLectura_Click(object sender, EventArgs e)
        {
            FrmObservarTarifas frmObservarTarifaLectura = new FrmObservarTarifas
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            frmObservarTarifaLectura.OnDgvDoubleClick += FrmObservarTarifaLectura_OnDgvDoubleClick;
            frmObservarTarifaLectura.ShowDialog();
        }

        private void FrmObservarTarifaLectura_OnDgvDoubleClick(object sender, EventArgs e)
        {
            ETarifas eTarifa = (ETarifas)sender;
            this.tarifaSmallLectura.AsignarDatos(eTarifa);
            this.btnTarifaLectura.Text = eTarifa.Descripcion;
            this.btnTarifaLectura.Tag = eTarifa.Id_tarifa;
        }

        private void BtnTarifaSesion_Click(object sender, EventArgs e)
        {
            FrmObservarTarifas frmObservarTarifasSesion = new FrmObservarTarifas
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            frmObservarTarifasSesion.OnDgvDoubleClick += FrmObservarTarifasSesion_OnDgvDoubleClick;
            frmObservarTarifasSesion.ShowDialog();
        }

        private void FrmObservarTarifasSesion_OnDgvDoubleClick(object sender, EventArgs e)
        {
            ETarifas eTarifa = (ETarifas)sender;
            this.tarifaSmallSesion.AsignarDatos(eTarifa);
            this.btnTarifaSesion.Text = eTarifa.Descripcion;
            this.btnTarifaSesion.Tag = eTarifa.Id_tarifa;
        }

        private void FrmConfiguracionTarifas_Load(object sender, EventArgs e)
        {
            this.ObtenerTarifaSesion();
            this.ObtenerTarifaLectura();
        }

        private void ObtenerTarifaSesion()
        {
            string id_tarifa = Convert.ToString(ConfigurationManager.AppSettings["Id_tarifa_predeterminada_sesion"]);
            if (int.TryParse(id_tarifa, out int id_tarifa_sesion))
            {
                ETarifas eTarifa = new ETarifas(id_tarifa_sesion);
                if (eTarifa.Id_tarifa != 0)
                {
                    this.tarifaSmallSesion.AsignarDatos(eTarifa);
                    this.btnTarifaSesion.Text = eTarifa.Descripcion;
                    this.btnTarifaSesion.Tag = eTarifa.Id_tarifa;
                }
                else
                    Mensajes.MensajeInformacion("No se encontró la tarifa de sesión en la base de datos, seleccione otra", "Entendido");
            }
            else
                Mensajes.MensajeInformacion("El id de tarifa de la sesión no está establecida " +
                    "en el archivo de configuracion o no tiene un formato correcto", "Entendido");
        }

        private void ObtenerTarifaLectura()
        {
            string id_tarifa = Convert.ToString(ConfigurationManager.AppSettings["Id_tarifa_predeterminada_lectura"]);
            if (int.TryParse(id_tarifa, out int id_tarifa_lectura))
            {
                ETarifas eTarifa = new ETarifas(id_tarifa_lectura);
                if (eTarifa.Id_tarifa != 0)
                {
                    this.tarifaSmallLectura.AsignarDatos(eTarifa);
                    this.btnTarifaLectura.Text = eTarifa.Descripcion;
                    this.btnTarifaLectura.Tag = eTarifa.Id_tarifa;
                }
                else
                    Mensajes.MensajeInformacion("No se encontró la tarifa de lectura en la base de datos, seleccione otra", "Entendido");
            }
            else
                Mensajes.MensajeInformacion("El id de tarifa de la lectura no está establecida " +
                    "en el archivo de configuracion o no tiene un formato correcto", "Entendido");
        }
    }
}
