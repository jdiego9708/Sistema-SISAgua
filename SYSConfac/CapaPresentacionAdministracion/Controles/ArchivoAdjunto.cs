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
using System.Diagnostics;
using System.Configuration;

namespace CapaPresentacionAdministracion.Controles
{
    public partial class ArchivoAdjunto : UserControl
    {
        public ArchivoAdjunto()
        {
            InitializeComponent();
            this.btnSeleccionar.Click += BtnSeleccionar_Click;
            this.btnVer.Click += BtnVer_Click;
        }

        private void BtnVer_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.txtArchivo.Text.Equals("SIN ADJUNTO") &&
                    !this.txtArchivo.Text.Equals(""))
                {
                    Process.Start(Convert.ToString(this.txtArchivo.Tag));
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnVer_Click",
                    "Hubo un error al abrir el archivo adjunto",
                    ex.Message + " RUTA: " + this.txtArchivo.Tag);
            }
        }

        private string tipoAdjunto;
        public string TipoAdjunto { get => tipoAdjunto; set => tipoAdjunto = value; }

        private string rutaOrigen = "";

        public string GuardarArchivo()
        {
            string rpta = "OK";
            try
            {
                bool guardar_archivo = true;

                if (Convert.ToString(this.txtArchivo.Tag).Equals(this.rutaOrigen))
                {
                    guardar_archivo = false;
                }
                else if (Convert.ToString(this.txtArchivo.Tag).Equals(""))
                {
                    guardar_archivo = false;
                }
                else if (Convert.ToString(this.txtArchivo.Tag).Equals("SIN ADJUNTO"))
                {
                    guardar_archivo = false;
                }
                else if (Convert.ToString(this.txtArchivo.Tag).Equals("SIN MANUAL"))
                {
                    guardar_archivo = false;
                }
                else if (Convert.ToString(this.txtArchivo.Tag).Equals("SIN FACTURA"))
                {
                    guardar_archivo = false;
                }

                if (guardar_archivo)
                {
                    DirectoryInfo DirectoryInfo = new DirectoryInfo(ObtenerRutaDestino(tipoAdjunto, out rpta));
                    if (rpta.Equals("OK"))
                    {
                        string nombreArchivo = string.Concat(tipoAdjunto, this.txtArchivo.Text);
                        string destino = Path.Combine(DirectoryInfo.ToString(), nombreArchivo);
                        File.Copy(Convert.ToString(this.txtArchivo.Tag), destino, true);
                    }
                    else
                    {
                        throw new Exception(rpta);
                    }
                }
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            return rpta;
        }

        public void AsignarDatosArchivo(string nombre_archivo, bool editar)
        {
            bool obtener = true;
            if (nombre_archivo.Equals(""))
            {
                obtener = false;
            }
            else if (nombre_archivo.Equals("SIN ADJUNTO"))
            {
                obtener = false;
            }

            if (obtener)
            {
                string rpta;
                string rutaCompleta = ObtenerRutaDestino(this.TipoAdjunto, out rpta) + nombre_archivo;
                this.rutaOrigen = rutaCompleta;
                this.txtArchivo.Tag = rutaCompleta;
                this.txtArchivo.Text = nombre_archivo;
                if (editar)
                {
                    this.btnVer.Visible = true;
                }
                else
                {
                    this.btnVer.Visible = false;
                }
            }
            else
            {
                if (this.TipoAdjunto.Equals("FACCOMPRA"))
                {
                    this.txtArchivo.Tag = "SIN FACTURA";
                    this.txtArchivo.Text = "SIN FACTURA";
                }
                else
                {
                    this.txtArchivo.Tag = "SIN MANUAL";
                    this.txtArchivo.Text = "SIN MANUAL";
                }
            }
        }

        public static string ObtenerRutaDestino(string tipo, out string rpta)
        {
            //Creo dos variables una para almacenar la ruta y otra para almacenar las configuraciones
            string ruta = "";
            var appSettings = ConfigurationManager.AppSettings;
            rpta = "OK";
            try
            {
                if (tipo.Equals("OPERADOR"))
                {
                    ruta = appSettings["RutaManualOperador"].ToString();
                }
                else if (tipo.Equals("SERVICIO"))
                {
                    ruta = appSettings["RutaManualServicio"].ToString();
                }
                else if (tipo.Equals("FACCOMPRA"))
                {
                    ruta = appSettings["RutaFacturaCompraEquipo"].ToString();
                }
                else if (tipo.Equals("MANTENIMIENTO"))
                {
                    ruta = appSettings["RutaMantenimiento"].ToString();
                }
                else if (tipo.Equals("PRESTAMO"))
                {
                    ruta = appSettings["RutaRetirarEquipo"].ToString();
                }
                else if (tipo.Equals("IMAGENES EQUIPO"))
                {
                    ruta = appSettings["RutaImagenesEquipo"].ToString();
                }
                else if (tipo.Equals("IMAGENES USUARIO"))
                {
                    ruta = appSettings["RutaImagenesUsuario"].ToString();
                }
                else
                {
                    throw new Exception("No se encuentra la ruta para el tipo " + tipo);
                }
            }
            catch (ConfigurationErrorsException ex)
            {
                rpta = ex.Message;
                ruta = "";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
                ruta = "";
            }

            return ruta;
        }

        public string ObtenerRutaOrigen()
        {
            string archivo = "";
            if (this.txtArchivo.Tag != null)
            {
                archivo = Convert.ToString(this.txtArchivo.Tag);
            }
            else
            {
                archivo = "SIN ADJUNTO";
            }
            return archivo;
        }

        public string ObtenerNombreArchivo()
        {
            string archivo = "";
            if (this.txtArchivo.Tag != null)
            {
                archivo = this.txtArchivo.Text;
            }
            else
            {
                archivo = "SIN ADJUNTO";
            }
            return archivo;
        }

        private void BtnSeleccionar_Click(object sender, EventArgs e)
        {
            //Creo un objeto de tipo OpenFileDialog y lo instancio
            OpenFileDialog archivo = new OpenFileDialog();
            //Esta linea es para que solo se puedan visualizar los archivos con esta extension
            archivo.Filter = "Documentos válidos|*.doc;*.xls;*.ppt;*.pdf";
            //Lo abro como un Dialog
            DialogResult result = archivo.ShowDialog();

            if (result == DialogResult.OK)
            {
                //Asignamos el nombre del archivo a la caja de texto
                this.txtArchivo.Text = archivo.SafeFileName;
                //Asignamos a la propiedad tag del textbox la ruta completa del archivo
                this.txtArchivo.Tag = archivo.FileName;
            }
        }
    }
}
