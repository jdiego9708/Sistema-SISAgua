using CapaEntidades;
using CapaPresentacionAdministracion.Controles;
using CapaPresentacionAdministracion.Servicios;
using System;
using System.Data;
using System.IO;
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

            this.btnAtras.Click += BtnAtras_Click;
            this.btnSiguiente.Click += BtnSiguiente_Click;
            this.Load += FrmConfigGeneral_Load;
        }

        private void FrmConfigGeneral_Load(object sender, EventArgs e)
        {
            this.AsignarDatos();
        }

        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            if (this.Comprobaciones())
                OnBtnSiguienteClick?.Invoke(this, e);
        }

        private void BtnAtras_Click(object sender, EventArgs e)
        {
            OnBtnAtrasClick?.Invoke(this, e);
        }

        private bool Comprobaciones()
        {
            if (this.btnRuta.Tag == null)
            {
                this.errorProvider1.SetError(this.gbRuta, "Debe seleccionar una ruta predeterminada");
                return false;
            }

            string ruta = Convert.ToString(this.btnRuta.Tag);
            DirectoryInfo directory = new DirectoryInfo(ruta);
            if (string.IsNullOrEmpty(ruta))
            {
                this.errorProvider1.SetError(this.gbRuta, "Debe seleccionar una ruta predeterminada");
                return false;
            }

            if (!HelperFiles.DirectoryExists(directory))
            {
                this.errorProvider1.SetError(this.gbRuta, "Verifique la carpeta seleccionada al parecer no existe");
                return false;
            }

            if (!HelperFiles.DirectoryAuthorization(directory, out string rpta))
            {
                Mensajes.MensajeInformacion("Hay un error con los permisos de la carpeta seleccionada por favor verifique, detalles: " +
                    rpta, "Entendido");
                this.errorProvider1.SetError(this.gbRuta, "Verifique la carpeta seleccionada al parecer no existe");
                return false;
            }

            if (!int.TryParse(Convert.ToString(this.listaCajas.SelectedValue), out int id_caja))
            {
                this.errorProvider1.SetError(this.gbCaja, "Verifique la caja seleccionada");
                return false;
            }
          
            if (this.numericMesesAlerta.Value > this.numericMesesCorte.Value)
            {
                this.errorProvider1.SetError(this.gbMesesAlerta, "El mes de alerta debe ser menor que el mes de corte");
                this.errorProvider1.SetIconAlignment(this.gbMesesAlerta, ErrorIconAlignment.BottomRight);
                return false;
            }

            if (this.numericMesesAlerta.Value == 0 || 
                this.numericMesesCorte.Value == 0)
            {
                this.errorProvider1.SetIconAlignment(this.gbMesesAlerta, ErrorIconAlignment.BottomRight);
                this.errorProvider1.SetIconAlignment(this.gbMesesCorte, ErrorIconAlignment.BottomRight);
                this.errorProvider1.SetError(this.gbMesesAlerta, "El mes de alerta no puede ser cero");
                this.errorProvider1.SetError(this.gbMesesCorte, "El mes de corte no pude ser cero");
                return false;
            }

            return true;
        }

        public event EventHandler OnBtnSiguienteClick;
        public event EventHandler OnBtnAtrasClick;

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
                this.btnRuta.Text = "Seleccione una ruta";
                this.btnRuta.Tag = null;
            }
            else
            {
                DirectoryInfo directory = new DirectoryInfo(rutaArchivo);
                if (HelperFiles.DirectoryExists(directory))
                {
                    this.btnRuta.Text = rutaArchivo;
                    this.btnRuta.Tag = rutaArchivo;

                    if (HelperFiles.DirectoryAuthorization(directory, out string rpta1))
                    {
                        this.btnRuta.Text = rutaArchivo;
                        this.btnRuta.Tag = rutaArchivo;
                    }
                    else
                        this.errorProvider1.SetError(this.gbRuta, "Verifique los permisos sobre la carpeta " + rpta1);
                }
                else
                    this.errorProvider1.SetError(this.gbRuta, "El directorio no existe");
            }

            int id_caja = ConfigGeneral.Default.Id_caja_principal;
            DataTable dtCajas = ECaja.BuscarCajas("COMPLETO", "", out string rpta);

            if (dtCajas != null)
            {
                this.listaCajas.DataSource = dtCajas;
                this.listaCajas.DisplayMember = "Nombre_caja";
                this.listaCajas.ValueMember = "Id_caja";

                if (id_caja != 0)
                {
                    DataRow[] rows = dtCajas.Select(string.Format("Id_caja = {0}", id_caja));
                    if (rows.Length > 0)
                        this.listaCajas.SelectedValue = id_caja;
                    else
                        this.errorProvider1.SetError(this.gbCaja, "No se encontró la caja guardada en la lista de cajas");
                }
            }

            this.numericMesesAlerta.Value = ConfigGeneral.Default.Meses_alerta_corte;
            this.numericMesesCorte.Value = ConfigGeneral.Default.Meses_corte;
        }
    }
}
