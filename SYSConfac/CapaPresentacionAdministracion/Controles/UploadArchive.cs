using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using CapaPresentacionAdministracion.Properties;
using System.Diagnostics;

namespace CapaPresentacionAdministracion.Controles
{
    public partial class UploadArchive : UserControl
    {
        public UploadArchive()
        {
            InitializeComponent();
            this.btnUpload.Click += BtnUpload_Click;
            this.px1.Click += Px1_Click;
            this.btnQuitar.Click += BtnQuitar_Click;
        }

        public void AsignarDatos(string nombre_archivo, string ruta_archivo)
        {
            this.Nombre_archivo = nombre_archivo;
            this.Ruta_origen_archivo = ruta_archivo;

            this.txtArchive.Text = nombre_archivo;
            this.txtArchive.Tag = ruta_archivo;
        }

        private void BtnQuitar_Click(object sender, EventArgs e)
        {
            this.px1.Image = Resources.SIN_IMAGENES;
            this.px1.Enabled = false;
            this.txtArchive.Tag = null;
            this.txtArchive.Text = string.Empty;

            this.Nombre_archivo = null;
            this.Ruta_origen_archivo = null;
        }

        private void Px1_Click(object sender, EventArgs e)
        {
            if (this.px1.Enabled)
            {
                try
                {
                    MensajeEspera.ShowWait("Abriendo...");
                    Process.Start(Path.Combine(this.Ruta_origen_archivo));
                    MensajeEspera.CloseForm();
                }
                catch (Exception ex)
                {
                    MensajeEspera.CloseForm();
                    Mensajes.MensajeErrorCompleto("ViewArchive.cs", "Px1_Click",
                        "Hubo un error al abrir el archivo adjunto", ex.Message);
                }
            }
        }

        private void BtnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog archivo = new OpenFileDialog();
            archivo.Filter = "Documentos válidos|*.doc;*.xls;*.ppt;*.pdf";
            DialogResult result = archivo.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.px1.Enabled = true;

                this.Nombre_archivo = archivo.SafeFileName;
                this.Ruta_origen_archivo = archivo.FileName;

                this.txtArchive.Text = archivo.SafeFileName;
                this.txtArchive.Tag = archivo.FileName;

                string ext = Path.GetExtension(archivo.FileName);
                switch (ext)
                {
                    case ".pdf":
                        this.px1.Image = Resources.pdf;
                        this.toolTip1.SetToolTip(this.px1, "Abrir archivo PDF");
                        break;
                    case ".ppt":
                        this.px1.Image = Resources.powerpoint;
                        this.toolTip1.SetToolTip(this.px1, "Abrir presentación de Power Point");
                        break;
                    case ".xls":
                        this.px1.Image = Resources.excel;
                        this.toolTip1.SetToolTip(this.px1, "Abrir libro de excel");
                        break;
                    case ".doc":
                        this.px1.Image = Resources.word;
                        this.toolTip1.SetToolTip(this.px1, "Abrir documento de Word");
                        break;
                    default:
                        this.px1.Image = Resources.not_file;
                        this.toolTip1.SetToolTip(this.px1, "No se reconoce la extensión del archivo");
                        this.px1.Cursor = Cursors.Default;
                        this.px1.Enabled = false;
                        break;
                }
            }
            else
            {
                this.px1.Enabled = false;
            }
        }

        private string _nombre_archivo;
        private string _ruta_origen_archivo;
        private string _tipo_archivo;
        private bool _isEditar;

        public string Nombre_archivo { get => _nombre_archivo; set => _nombre_archivo = value; }
        public string Tipo_archivo { get => _tipo_archivo; set => _tipo_archivo = value; }
        public string Ruta_origen_archivo { get => _ruta_origen_archivo; set => _ruta_origen_archivo = value; }
        public bool IsEditar { get => _isEditar; set => _isEditar = value; }
    }
}
