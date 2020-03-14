using CapaPresentacionAdministracion.Properties;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace CapaPresentacionAdministracion.Controles
{
    public partial class ViewArchive : UserControl
    {
        public ViewArchive()
        {
            InitializeComponent();
            this.px1.Click += Px1_Click;
        }

        private void Px1_Click(object sender, EventArgs e)
        {
            if (this.px1.Enabled)
            {
                try
                {
                    MensajeEspera.ShowWait("Abriendo...");
                    string rutaCompleta =
                        Path.Combine(this.Ruta_archivo);
                    Process.Start(rutaCompleta);
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

        public void AsignarDatos()
        {
            try
            {
                if (this.Nombre_archivo == null)
                    return;

                if (this.Tipo_archivo == null)
                    return;

                if (this.Ruta_archivo == null)
                    return;

                this.txtArchive.Text = this.Nombre_archivo;

                string extension = "";
                int posicionExtension =
                    this.Nombre_archivo.LastIndexOf('.', this.Nombre_archivo.Length - 1);
                if (posicionExtension > 0)
                {
                    extension = this.Nombre_archivo.Substring(posicionExtension);
                    this.px1.Enabled = true;
                    switch (extension)
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
                    this.px1.Cursor = Cursors.Default;
                    this.px1.Enabled = false;

                    if (this.Nombre_archivo.Equals("SIN ADJUNTO") |
                        this.Nombre_archivo.Equals("SIN FACTURA") |
                        this.Nombre_archivo.Equals("SIN MANUAL"))
                        return;

                    throw new Exception("No se pudo encontrar la extensión del archivo en cuestión");
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "AsignarDatos()",
                    "Hubo un error al asignar un archivo", ex.Message);
            }
        }

        private string _nombre_archivo;
        private string _ruta_archivo;
        private string _tipo_archivo;

        public string Nombre_archivo { get => _nombre_archivo; set => _nombre_archivo = value; }
        public string Tipo_archivo { get => _tipo_archivo; set => _tipo_archivo = value; }
        public string Ruta_archivo { get => _ruta_archivo; set => _ruta_archivo = value; }
    }
}
