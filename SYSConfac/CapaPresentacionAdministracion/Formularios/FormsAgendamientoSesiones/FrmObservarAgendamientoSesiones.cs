using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;
using CapaPresentacionAdministracion.Formularios.FormsLecturas;
using CapaPresentacionAdministracion.Properties;

namespace CapaPresentacionAdministracion.Formularios.FormsAgendamientoSesiones
{
    public partial class FrmObservarAgendamientoSesiones : Form
    {
        PoperContainer container;
        public FrmObservarAgendamientoSesiones()
        {
            InitializeComponent();
            this.btnMes.Click += BtnMes_Click;
            
        }

        private void BuscarAgendamientos(string tipo_busqueda, string texto_busqueda1, string texto_busqueda2)
        {
            try
            {
                DataTable dtAgendamientos = 
                    EAgendamientoSesion.BuscarAgendamientosSesiones(tipo_busqueda, texto_busqueda1, texto_busqueda2, out string rpta);
                if (dtAgendamientos != null)
                {
                    this.panelSesiones.BackgroundImage = null;

                    List<UserControl> controls = new List<UserControl>();
                    foreach(DataRow row in dtAgendamientos.Rows)
                    {
                        EAgendamientoSesion eAgendamiento = new EAgendamientoSesion(row);
                        AgendamientoSesionSmall agendamientoSesionSmall = new AgendamientoSesionSmall();
                        agendamientoSesionSmall.OnBtnNext += BtnNext_Click;

                        agendamientoSesionSmall.AsignarDatos(eAgendamiento);
                        controls.Add(agendamientoSesionSmall);
                    }
                    this.panelSesiones.AddArrayControl(controls);
                }
                else
                {
                    this.panelSesiones.BackgroundImage = Resources.No_hay_resultados; 

                    if (!rpta.Equals("OK"))
                        throw new Exception(rpta);
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BuscarAgendamientos", 
                    "Hubo un error al buscar agendamientos", ex.Message);
            }
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            AgendamientoSesionSmall agendamientoSesionSmall = (AgendamientoSesionSmall)sender;
            if (IsEditar)
            {              
                FrmAgendarSesion frmAgendarSesion = new FrmAgendarSesion
                {
                    StartPosition = FormStartPosition.CenterScreen
                };
                frmAgendarSesion.AsignarDatos(agendamientoSesionSmall.EAgendamientoSesion);
                frmAgendarSesion.OnRefresh += FrmAgendarSesion_OnRefresh;
                frmAgendarSesion.ShowDialog();
            }
            else
            {
                OnBtnSesion?.Invoke(agendamientoSesionSmall.EAgendamientoSesion, e);
            }
        }

        private void FrmAgendarSesion_OnRefresh(object sender, EventArgs e)
        {
            ListaMeses_OnBtnMesClick(this.btnMes, e);
        }

        private void BtnMes_Click(object sender, EventArgs e)
        {
            ListaMeses listaMeses = new ListaMeses
            {
                MaxMonth = 12
            };
            listaMeses.OnBtnMesClick += ListaMeses_OnBtnMesClick;
            this.container = new PoperContainer(listaMeses);
            this.container.Show(this.btnMes);
        }

        private void ListaMeses_OnBtnMesClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (this.container != null)
                this.container.Close();
            this.btnMes.Text = btn.Text;
            int mes = Convert.ToInt32(btn.Tag);

            if (mes == DateTime.Now.Month + 1 | mes == DateTime.Now.Month)
            {
                int days = DateTime.DaysInMonth(DateTime.Now.Year, mes);
                DateTime fecha1 = new DateTime(DateTime.Now.Year, mes, 01);
                DateTime fecha2 = new DateTime(DateTime.Now.Year, mes, days);

                this.BuscarAgendamientos("FECHAS", fecha1.ToString("yyyy-MM-dd"), fecha2.ToString("yyyy-MM-dd"));
            }
        }

        public event EventHandler OnBtnSesion;

        private bool _isEditar;

        public bool IsEditar { get => _isEditar; set => _isEditar = value; }
    }
}
