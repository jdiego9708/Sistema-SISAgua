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

namespace CapaPresentacionAdministracion.Formularios.FormsAgendamientoSesiones
{
    public partial class AgendamientoSesionSmall : UserControl
    {
        public AgendamientoSesionSmall()
        {
            InitializeComponent();
            this.btnNext.Click += BtnNext_Click;
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            OnBtnNext?.Invoke(this, e);
        }

        public event EventHandler OnBtnNext;

        public EAgendamientoSesion EAgendamientoSesion;

        public void AsignarDatos(EAgendamientoSesion eAgendamiento)
        {
            this.EAgendamientoSesion = eAgendamiento;
            this.txtFechaHora.Text = eAgendamiento.Fecha.ToLongDateString() + " - " + eAgendamiento.Hora;
            this.txtDescripcion.Text = eAgendamiento.Titulo;
        }
    }
}
