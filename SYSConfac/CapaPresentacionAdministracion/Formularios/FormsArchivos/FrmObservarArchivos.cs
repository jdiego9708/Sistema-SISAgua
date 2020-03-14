using CapaEntidades;
using CapaPresentacionAdministracion.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacionAdministracion.Formularios.FormsArchivos
{
    public partial class FrmObservarArchivos : Form
    {
        public FrmObservarArchivos()
        {
            InitializeComponent();
            this.btnAgregarArchivo.Click += BtnAgregarArchivo_Click;
            this.Load += FrmObservarArchivos_Load;
        }

        private void FrmObservarArchivos_Load(object sender, EventArgs e)
        {
            this.BuscarArchivos("COMPLETO", "");
        }

        private void BtnAgregarArchivo_Click(object sender, EventArgs e)
        {
            FrmAgregarArchivo frmAgregarArchivo = new FrmAgregarArchivo
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            frmAgregarArchivo.OnRefresh += FrmAgregarArchivo_OnRefresh;
            frmAgregarArchivo.Show();
        }

        private void FrmAgregarArchivo_OnRefresh(object sender, EventArgs e)
        {
            this.BuscarArchivos("COMPLETO", "");
        }

        private void BuscarArchivos(string tipo_busqueda, string texto_busqueda)
        {
            try
            {
                DataTable dtArchivos = 
                    EArchivosSistema.BuscarArchivos(tipo_busqueda, texto_busqueda, out string rpta);
                this.panelArchivos.clearDataSource();
                if (dtArchivos != null)
                {
                    this.panelArchivos.BackgroundImage = null;

                    List<UserControl> controls = new List<UserControl>();
                    foreach (DataRow row in dtArchivos.Rows)
                    {
                        EArchivosSistema eArchivosSistema = new EArchivosSistema(row);
                        ArchivoSmall archivoSmall = new ArchivoSmall();
                        archivoSmall.OnRefresh += ArchivoSmall_OnRefresh;
                        archivoSmall.AsignarDatos(eArchivosSistema);
                        controls.Add(archivoSmall);
                    }
                    this.panelArchivos.AddArrayControl(controls);
                }
                else
                {
                    this.panelArchivos.BackgroundImage = Resources.No_hay_archivos;

                    if (!rpta.Equals("OK"))
                        throw new Exception(rpta);
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BuscarArchivos",
                    "Hubo un error al observar los archivos", ex.Message);
            }
        }

        private void ArchivoSmall_OnRefresh(object sender, EventArgs e)
        {
            this.BuscarArchivos("COMPLETO", "");
        }
    }
}
