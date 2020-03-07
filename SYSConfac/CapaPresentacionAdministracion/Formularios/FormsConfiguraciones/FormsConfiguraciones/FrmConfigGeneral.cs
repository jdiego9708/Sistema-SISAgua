using CapaPresentacionAdministracion.Controles;
using CapaPresentacionAdministracion.Servicios;
using System;
using System.Windows.Forms;

namespace CapaPresentacionAdministracion.Formularios.FormsConfiguraciones.FormsConfiguraciones
{
    public partial class FrmConfigGeneral : Form
    {
        PoperContainer container;
        HelpToolTip helpToolTip;

        public FrmConfigGeneral()
        {
            InitializeComponent();
            this.btnRuta.Click += BtnRuta_Click;
            this.btnAyudaRuta.MouseEnter += BtnAyuda_MouseEnter;
            this.btnAyudaRuta.MouseLeave += BtnAyuda_MouseLeave;
            this.btnAyudaCaja.MouseEnter += BtnAyuda_MouseEnter;
            this.btnAyudaCaja.MouseLeave += BtnAyuda_MouseLeave;
            this.btnAyudaMesesAlerta.MouseEnter += BtnAyuda_MouseEnter;
            this.btnAyudaMesesAlerta.MouseLeave += BtnAyuda_MouseLeave;
            this.btnAyudaMesesCorte.MouseEnter += BtnAyuda_MouseEnter;
            this.btnAyudaMesesCorte.MouseLeave += BtnAyuda_MouseLeave;
        }

        private bool Comprobaciones()
        {
            if (this.btnRuta.Tag != null)
            {
                this.errorProvider1.SetError(this.gbRuta, "Debe seleccionar una ruta predeterminada");
                return false;
            }

            string ruta = Convert.ToString(this.btnRuta.Tag);

            if (string.IsNullOrEmpty(ruta))
            {
                this.errorProvider1.SetError(this.gbRuta, "Debe seleccionar una ruta predeterminada");
                return false;
            }

            if (!HelperFiles.DirectoryExists(ruta))
            {
                this.errorProvider1.SetError(this.gbRuta, "Verifique la carpeta seleccionada al parecer no existe");
                return false;
            }

            if (!HelperFiles.DirectoryAuthorization(ruta, out string rpta))
            {
                Mensajes.MensajeInformacion("Hay un error con los permisos de la carpeta seleccionada por favor verifique, detalles: " +
                    rpta, "Entendido");
                this.errorProvider1.SetError(this.gbRuta, "Verifique la carpeta seleccionada al parecer no existe");
                return false;
            }

            if (!int.TryParse(Convert.ToString(this.listaCajas.SelectedValue), out int id_caja))
            {
                this.errorProvider1.SetError(this.gbCaja, "Verifique la la caja seleccionada");
                return false;
            }

            return true;
        }

        public event EventHandler OnBtnSiguiente;
        public event EventHandler OnBtnAtras;

        private void BtnAyuda_MouseLeave(object sender, EventArgs e)
        {
            if (this.container != null)
                this.container.Close();
        }

        private void BtnAyuda_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (this.helpToolTip == null)
                this.helpToolTip = new HelpToolTip();

            string tipo = Convert.ToString(btn.Tag);
            switch (tipo)
            {
                case "RUTA":
                    this.helpToolTip.Texto = "Se trata de la ruta por defecto que tendrá el programa para guardar los archivos";
                    break;
                case "CAJA":
                    this.helpToolTip.Texto = "Se trata de la caja predeterminada que se tomará en el módulo de caja";
                    break;
                case "MESES ALERTA":
                    this.helpToolTip.Texto = "Indica del número de meses pendientes que debe tener una cuenta de cobro " +
                        "para mostrar una notificación de próximo corte. Debe ser menor que los meses de corte";
                    break;
                case "MESES CORTE":
                    this.helpToolTip.Texto = "Indica del número de meses pendientes que debe tener una cuenta de cobro " +
                        "para realizar el corte del servicio.";
                    break;
            }

            this.container = new PoperContainer(this.helpToolTip);
            this.container.Show(btn);
        }

        private void BtnRuta_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string folderName = fbd.SelectedPath;
                    this.btnRuta.Text = folderName;
                    this.btnRuta.Tag = folderName;
                }
                else
                {
                    this.btnRuta.Text = "Seleccionar ruta";
                }
            }
        }

        private void AsignarDatos()
        {
            string rutaArchivo = ConfigGeneral.Default.Ruta_archivos;
            if (string.IsNullOrEmpty(rutaArchivo))
            {

            }
        }
    }
}
