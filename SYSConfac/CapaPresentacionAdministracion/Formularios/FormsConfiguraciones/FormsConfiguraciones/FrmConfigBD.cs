using CapaEntidades;
using CapaPresentacionAdministracion.Controles;
using CapaPresentacionAdministracion.Servicios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace CapaPresentacionAdministracion.Formularios.FormsConfiguraciones.FormsConfiguraciones
{
    public partial class FrmConfigBD : Form
    {
        PoperContainer container;
        HelpToolTip helpToolTip;
        public FrmConfigBD()
        {
            InitializeComponent();
            this.btnSiguiente.Click += BtnSiguiente_Click;
            this.btnAtras.Click += BtnAtras_Click;
            this.rdManuales.CheckedChanged += RdManuales_CheckedChanged;
            this.rdAutomaticas.CheckedChanged += RdAutomaticas_CheckedChanged;
            this.Load += FrmConfigBD_Load;
            this.btnSeleccionarBD.Click += BtnSeleccionarBD_Click;
            this.btnRutaBackup.Click += BtnRuta_Click;
        }
        public string GuardarDatos()
        {
            string rpta = "OK";
            try
            {
                if (this.Comprobaciones(out EConfigBD eConfigBD))
                {
                    List<string> configurations = new List<string>
                    {
                        eConfigBD.ConnectionDefault,
                        eConfigBD.MotorBD,
                        eConfigBD.TipoBackup,
                        eConfigBD.Frecuencia.ToString(),
                        eConfigBD.RutaDestinoBackup,
                        eConfigBD.FileName
                    };

                    rpta = EConfigBD.InsertarConfiguraciones(configurations, eConfigBD.ConnectionsStrings);
                    if (!rpta.Equals("OK"))
                        throw new Exception(rpta);
                }
                else
                    throw new Exception("No se pudo realizar la comprobación");
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            return rpta;
        }

        private void BtnSeleccionarBD_Click(object sender, EventArgs e)
        {
            if (this.rdSqlite.Checked)
            {
                OpenFileDialog archivo = new OpenFileDialog();
                archivo.Filter = "Documentos válidos|*.db";
                DialogResult result = archivo.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string connectionString = "Data Source=" + archivo.FileName;
                    if (EConfigBD.TestConnection(connectionString, out string rpta))
                    {
                        this.errorProvider1.Clear();
                        this.btnSeleccionarBD.Text = connectionString;
                        this.btnSeleccionarBD.Tag = archivo.FileName;
                        this.txtConexion.Text = connectionString;
                        this.toolTip1.SetToolTip(this.btnSeleccionarBD, connectionString);
                    }
                    else
                    {
                        Mensajes.MensajeInformacion("Hubo un error probando la conexión a la base de datos, detalles: " +
                            rpta, "Entendido");
                        this.btnSeleccionarBD.Text = "Seleccione base de datos";
                        this.btnSeleccionarBD.Tag = null;
                        this.txtConexion.Text = string.Empty;
                        this.toolTip1.SetToolTip(this.btnSeleccionarBD, "Seleccionar base de datos");
                    }
                }
            }
        }

        private void FrmConfigBD_Load(object sender, EventArgs e)
        {
            this.AsignarEventos();
            this.AsignarDatos();
        }

        private void AsignarEventos()
        {
            this.btnAyudaMotorBD.MouseEnter += BtnAyuda_MouseEnter;
            this.btnAyudaMotorBD.MouseLeave += BtnAyuda_MouseLeave;
            this.btnAyudaArchivoBD.MouseEnter += BtnAyuda_MouseEnter;
            this.btnAyudaArchivoBD.MouseLeave += BtnAyuda_MouseLeave;
            this.btnAyudaConexion.MouseEnter += BtnAyuda_MouseEnter;
            this.btnAyudaConexion.MouseLeave += BtnAyuda_MouseLeave;
            this.btnAyudaDias.MouseEnter += BtnAyuda_MouseEnter;
            this.btnAyudaDias.MouseLeave += BtnAyuda_MouseLeave;
            this.btnAyudaRuta.MouseEnter += BtnAyuda_MouseEnter;
            this.btnAyudaRuta.MouseLeave += BtnAyuda_MouseLeave;
        }

        private void RdAutomaticas_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rd = (RadioButton)sender;
            if (rd.Checked)
                this.gbFrecuencia.Visible = true;
        }

        private void RdManuales_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rd = (RadioButton)sender;
            if (rd.Checked)
                this.gbFrecuencia.Visible = false;
        }

        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            if (this.Comprobaciones(out _))
                OnBtnSiguienteClick?.Invoke(this, e);
        }

        private void BtnAtras_Click(object sender, EventArgs e)
        {
            OnBtnAtrasClick?.Invoke(this, e);
        }

        private bool Comprobaciones(out EConfigBD eConfigBD)
        {
            eConfigBD = new EConfigBD();

            if (this.rdSqlite.Checked)
                eConfigBD.MotorBD = "SQLITE";
            else
                eConfigBD.MotorBD = "SQLSERVER";

            if (this.btnSeleccionarBD.Tag == null)
            {
                this.errorProvider1.SetError(this.gbBaseDatos, "Debe seleccionar una base de datos válida");
                return false;
            }
            else
            {
                string rutaBD = Convert.ToString(this.btnSeleccionarBD.Tag);
                string connectionsString = Convert.ToString(this.btnSeleccionarBD.Text);
                DirectoryInfo directory = new DirectoryInfo(rutaBD);

                if (string.IsNullOrEmpty(rutaBD))
                {
                    this.errorProvider1.SetError(this.gbBaseDatos, "Debe seleccionar una base de datos");
                    return false;
                }

                if (!HelperFiles.ArchiveExists(directory.FullName))
                {
                    this.errorProvider1.SetError(this.gbBaseDatos, "Verifique el archivo seleccionado al parecer no existe");
                    return false;
                }
                else
                {
                    eConfigBD.ConnectionDefault = connectionsString;

                    if (this.EConfigBD != null)
                    {
                        eConfigBD.ConnectionsStrings = this.EConfigBD.ConnectionsStrings;
                        if (eConfigBD.ConnectionsStrings != null)
                        {
                            if (!eConfigBD.ConnectionsStrings.Contains(connectionsString))
                                eConfigBD.ConnectionsStrings.Add(connectionsString);
                        }
                        else
                        {
                            eConfigBD.ConnectionsStrings = new List<string>();
                            eConfigBD.ConnectionsStrings.Add(connectionsString);
                        }
                    }
                }

                if (!HelperFiles.BDAuthorization(directory, out string rpta1))
                {
                    Mensajes.MensajeInformacion("Hay un error con los permisos del archivo de base de datos seleccionaoa por favor verifique, detalles: " +
                        rpta1, "Entendido");
                    this.errorProvider1.SetError(this.gbBaseDatos, "Verifique el archivo de base de datos seleccionado");
                    return false;
                }
                else
                    eConfigBD.FileName = directory.FullName;

                if (!EConfigBD.TestConnection(connectionsString, out string rpta))
                {
                    Mensajes.MensajeInformacion("Hubo un error al tratar de conectarse a la base de datos, detalles: " +
                        rpta, "Entendido");
                    this.errorProvider1.SetError(this.gbBaseDatos, "Hubo un error al tratar de conectarse a la base de datos");
                    return false;
                }
            }

            if (this.btnRutaBackup.Tag == null)
            {
                this.errorProvider1.SetIconAlignment(this.gbRutaDestino, ErrorIconAlignment.TopRight);
                this.errorProvider1.SetError(this.gbRutaDestino, "Debe seleccionar una ruta de backup válida");
                return false;
            }
            else
            {
                string ruta = Convert.ToString(this.btnRutaBackup.Tag);
                DirectoryInfo directory = new DirectoryInfo(ruta);
                if (string.IsNullOrEmpty(ruta))
                {
                    this.errorProvider1.SetError(this.gbRutaDestino, "Debe seleccionar una ruta para guardar los backups predeterminada");
                    return false;
                }

                if (!HelperFiles.DirectoryExists(directory))
                {
                    this.errorProvider1.SetError(this.gbRutaDestino, "Verifique la carpeta seleccionada al parecer no existe");
                    return false;
                }

                if (!HelperFiles.DirectoryAuthorization(directory, out string rpta))
                {
                    Mensajes.MensajeInformacion("Hay un error con los permisos de la carpeta seleccionada por favor verifique, detalles: " +
                        rpta, "Entendido");
                    this.errorProvider1.SetError(this.gbRutaDestino, "Verifique la carpeta seleccionada al parecer no existe");
                    return false;
                }
            }

            if (this.rdAutomaticas.Checked)
            {
                if (this.numericFrecuencia.Value < 1)
                {
                    this.errorProvider1.SetError(this.gbFrecuencia, "La frecuencia de las copias de seguridad automáticas debe ser mayor que 0 días");
                    return false;
                }
                else
                {
                    eConfigBD.TipoBackup = "AUTOMATICO";
                    eConfigBD.Frecuencia = Convert.ToInt32(this.numericFrecuencia.Value);
                }
            }
            else
                eConfigBD.TipoBackup = "MANUAL";

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
                case "MOTOR":
                    this.helpToolTip.Texto = "Se trata del motor de base de datos que usa la aplicación";
                    break;
                case "BASE DE DATOS":
                    this.helpToolTip.Texto = "Para SQLite seleccionar el archivo .db compatible con Sqlite, " +
                        "para SQL Server realice la prueba de conexión, guarde la cadena y seleccionela";
                    break;
                case "CONEXION":
                    this.helpToolTip.Texto = "Indica el nombre de la conexión dentro de la aplicación";
                    break;
                case "FRECUENCIA":
                    this.helpToolTip.Texto = "Indica la frecuencia con la que el programa realizará las copias de seguridad";
                    break;
                case "RUTA DESTINO":
                    this.helpToolTip.Texto = "Ruta predeterminada donde se guardarán las copias de seguridad";
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
                    this.btnRutaBackup.Text = folderName;
                    this.btnRutaBackup.Tag = folderName;
                }
                else
                {
                    this.btnRutaBackup.Text = "Seleccionar ruta";
                }
            }
        }

        private void AsignarDatos()
        {
            EConfigBD eConfigBD = new EConfigBD();
            this.EConfigBD = eConfigBD;
            if (eConfigBD.MotorBD.Equals("SQLITE"))
                this.rdSqlite.Checked = true;
            else if (eConfigBD.MotorBD.Equals("SQL SERVER"))
                this.rdSqlserver.Checked = true;

            string connectionString = eConfigBD.ConnectionDefault;
            string rutaBD = eConfigBD.FileName;
            if (string.IsNullOrEmpty(connectionString))
            {
                this.btnSeleccionarBD.Text = "Seleccione una ruta";
                this.btnSeleccionarBD.Tag = null;
            }
            else
            {
                DirectoryInfo directory = new DirectoryInfo(rutaBD);
                if (HelperFiles.ArchiveExists(directory.FullName))
                {
                    this.btnSeleccionarBD.Text = connectionString;
                    this.btnSeleccionarBD.Tag = rutaBD;

                    this.errorProvider1.SetIconAlignment(this.gbBaseDatos, ErrorIconAlignment.TopRight);

                    if (HelperFiles.BDAuthorization(directory, out string rpta1))
                    {
                        this.btnSeleccionarBD.Text = connectionString;
                        this.btnSeleccionarBD.Tag = rutaBD;
                        this.toolTip1.SetToolTip(this.btnSeleccionarBD, connectionString);

                        if (!EConfigBD.TestConnection(connectionString, out string rpta))
                        {
                            Mensajes.MensajeInformacion("Hubo un error al tratar de conectarse a la base de datos, detalles: " +
                                rpta, "Entendido");
                            this.errorProvider1.SetError(this.gbBaseDatos, "Hubo un error al tratar de conectarse a la base de datos");
                        }
                    }
                    else
                        this.errorProvider1.SetError(this.gbBaseDatos, "Verifique los permisos sobre la base de datos " + rpta1);
                }
                else
                    this.errorProvider1.SetError(this.gbBaseDatos, "El directorio de base de datos no existe");
            }

            this.txtConexion.Text = eConfigBD.ConnectionDefault;

            if (eConfigBD.TipoBackup.Equals("MANUAL"))
            {
                this.rdManuales.Checked = true;
                this.gbFrecuencia.Visible = false;
            }
            else
            {
                this.rdAutomaticas.Checked = true;
                this.gbFrecuencia.Visible = true;
            }

            this.numericFrecuencia.Value = eConfigBD.Frecuencia;

            string rutaDestinoBackup = eConfigBD.RutaDestinoBackup;
            if (string.IsNullOrEmpty(rutaDestinoBackup))
            {
                this.btnRutaBackup.Text = "Seleccione una ruta";
                this.btnRutaBackup.Tag = null;
            }
            else
            {
                DirectoryInfo directory = new DirectoryInfo(rutaDestinoBackup);
                if (HelperFiles.DirectoryExists(directory))
                {
                    this.btnRutaBackup.Text = rutaDestinoBackup;
                    this.btnRutaBackup.Tag = rutaDestinoBackup;

                    this.errorProvider1.SetIconAlignment(this.gbRutaDestino, ErrorIconAlignment.TopRight);

                    if (HelperFiles.DirectoryAuthorization(directory, out string rpta1))
                    {
                        this.btnRutaBackup.Text = rutaDestinoBackup;
                        this.btnRutaBackup.Tag = rutaDestinoBackup;
                    }
                    else
                        this.errorProvider1.SetError(this.gbRutaDestino, "Verifique los permisos sobre la carpeta " + rpta1);
                }
                else
                    this.errorProvider1.SetError(this.gbRutaDestino, "El directorio no existe");
            }
        }

        private EConfigBD _eConfigBD;

        public EConfigBD EConfigBD { get => _eConfigBD; 
            set => _eConfigBD = value; }
    }
}
