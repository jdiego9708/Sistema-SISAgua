using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaEntidades;

namespace CapaPresentacionAdministracion.Formularios.FormsArchivos
{
    public partial class ArchivoSmall : UserControl
    {
        public ArchivoSmall()
        {
            InitializeComponent();
            this.btnModificar.Click += BtnModificar_Click;
            this.btnEliminar.Click += BtnEliminar_Click;
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                this.EArchivosSistema.Estado = "INACTIVO";
                string rpta = 
                    EArchivosSistema.EditarArchivo(this.EArchivosSistema.Id_archivo, this.EArchivosSistema);
                if (rpta.Equals("OK"))
                {
                    Mensajes.MensajeOkForm("Se eliminó correctamente el archivo");
                    OnRefresh?.Invoke(sender, e);
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnEliminar_Click",
                    "Hubo un error al eliminar un archivo", ex.Message);
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            FrmAgregarArchivo frmAgregarArchivo = new FrmAgregarArchivo
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            frmAgregarArchivo.AsignarDatos(this.EArchivosSistema);
            frmAgregarArchivo.ShowDialog();
        }

        EArchivosSistema EArchivosSistema;

        public void AsignarDatos(EArchivosSistema eArchivo)
        {
            this.EArchivosSistema = eArchivo;
            this.txtTitulo.Text = eArchivo.Titulo;
            this.txtDescripcion.Text = eArchivo.Descripcion;

            this.viewArchive1.Nombre_archivo = eArchivo.Nombre_archivo;
            this.viewArchive1.Ruta_archivo = eArchivo.Ruta_archivo;
            this.viewArchive1.AsignarDatos();
        }

        public event EventHandler OnRefresh;
    }
}
