using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaEntidades;

namespace CapaPresentacionAdministracion.Formularios.FormsArchivos
{
    public partial class FrmAgregarArchivo : Form
    {
        public FrmAgregarArchivo()
        {
            InitializeComponent();
            this.btnGuardar.Click += BtnGuardar_Click;
        }

        EArchivosSistema EArchivosSistema;

        public void AsignarDatos(EArchivosSistema eArchivo)
        {
            this.Text = "Editar archivo";
            this.btnGuardar.Text = "Actualizar";
            this.IsEditar = true;
            this.EArchivosSistema = eArchivo;
            this.txtTitulo.Text = eArchivo.Titulo;
            this.txtDescripcion.Text = eArchivo.Descripcion;
            this.uploadArchive1.AsignarDatos(eArchivo.Nombre_archivo, eArchivo.Ruta_archivo);
        }

        private bool Comprobaciones(out EArchivosSistema eArchivosSistema)
        {
            eArchivosSistema = new EArchivosSistema();

            if (this.txtTitulo.Text.Equals(""))
            {
                Mensajes.MensajeInformacion("El campo titulo es necesario", "Entendido");
                return false;
            }

            if (this.uploadArchive1.Nombre_archivo != null)
            {
                if (this.uploadArchive1.Nombre_archivo.Equals(""))
                {
                    Mensajes.MensajeInformacion("Debe de seleccionar un archivo", "Entendido");
                    return false;
                }
            }
            else
            {
                Mensajes.MensajeInformacion("Debe de seleccionar un archivo", "Entendido");
                return false;
            }

            eArchivosSistema.Fecha_ingreso = DateTime.Now;
            eArchivosSistema.Ruta_archivo = 
                Path.Combine(ArchivosAdjuntos.ObtenerRutaDestino("RutaDestinoArchivos"), this.uploadArchive1.Nombre_archivo);
            eArchivosSistema.Nombre_archivo = this.uploadArchive1.Nombre_archivo;
            eArchivosSistema.Titulo = this.txtTitulo.Text;
            eArchivosSistema.Descripcion = this.txtDescripcion.Text;
            eArchivosSistema.Estado = "ACTIVO";
            return true;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Comprobaciones(out EArchivosSistema eArchivo))
                {
                    string rpta = "";
                    string mensaje = "";

                    if (this.IsEditar)
                    {
                        rpta = EArchivosSistema.EditarArchivo(this.EArchivosSistema.Id_archivo, eArchivo);
                        mensaje = "Se actualizó correctamente el archivo";
                    }
                    else
                    {
                        rpta = EArchivosSistema.InsertarArchivo(eArchivo);
                        mensaje = "Se agregó correctamente el archivo";
                    }

                    if (rpta.Equals("OK"))
                    {
                        rpta =
                            ArchivosAdjuntos.GuardarArchivo("RutaDestinoArchivos", eArchivo.Nombre_archivo, this.uploadArchive1.Ruta_origen_archivo);
                        if (!rpta.Equals("OK"))
                        {
                            Mensajes.MensajeInformacion("Se guardó correctamente el registro en " +
                            "la base de datos pero no se cargó el archivo a la carpeta", "Entendido");
                        }

                        OnRefresh?.Invoke(sender, e);
                        Mensajes.MensajeOkForm(mensaje);
                        this.Close();
                    }
                    else
                        throw new Exception(rpta);
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnGuardar_Click",
                    "Hubo un error al agregar o actualizar un archivo", ex.Message);
            }
        }

        private bool _isEditar;

        public bool IsEditar { get => _isEditar; set => _isEditar = value; }

        public event EventHandler OnRefresh;
    }
}
