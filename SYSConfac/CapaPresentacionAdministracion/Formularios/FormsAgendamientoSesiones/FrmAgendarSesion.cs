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

namespace CapaPresentacionAdministracion.Formularios.FormsAgendamientoSesiones
{
    public partial class FrmAgendarSesion : Form
    {
        public FrmAgendarSesion()
        {
            InitializeComponent();
            this.Load += FrmAgendarSesion_Load;
            this.btnGuardar.Click += BtnGuardar_Click;
        }

        EAgendamientoSesion EAgendamientoSesion;

        public void AsignarDatos(EAgendamientoSesion eAgendamiento)
        {
            this.IsEditar = true;
            this.EAgendamientoSesion = eAgendamiento;
            this.txtTitulo.Text = eAgendamiento.Titulo;
            this.dateFechaAgendamiento.Value = eAgendamiento.Fecha;
            this.listaHoraInicio =
                ListTools.ListaHoras(this.listaHoraInicio);
            this.listaHoraInicio.SelectedValue = eAgendamiento.Hora;
        }

        public event EventHandler OnRefresh;

        private bool Comprobaciones(out EAgendamientoSesion eAgendamiento)
        {
            eAgendamiento = new EAgendamientoSesion();
            if (this.txtTitulo.Text.Equals(""))
            {
                Mensajes.MensajeInformacion("El titulo no puede estar vacío", "Entendido");
                return false;
            }

            if (this.listaHoraInicio.Text.Equals(""))
            {
                Mensajes.MensajeInformacion("Debe seleccionar una hora", "Entendido");
                return false;
            }

            eAgendamiento.Titulo = this.txtTitulo.Text;
            eAgendamiento.Fecha = this.dateFechaAgendamiento.Value;
            eAgendamiento.Hora = Convert.ToString(this.listaHoraInicio.SelectedValue);
            eAgendamiento.Estado = "PENDIENTE";

            return true;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Comprobaciones(out EAgendamientoSesion eAgendamiento))
                {
                    string mensaje = "";
                    string rpta = "";

                    if (!IsEditar)
                    {
                        rpta = EAgendamientoSesion.InsertarAgendamientoSesion(eAgendamiento, out int id_agendamiento);
                        mensaje = "Se agendó correctamente la sesión";
                    }
                    else
                    {
                        rpta = EAgendamientoSesion.EditarAgendamiento(eAgendamiento, this.EAgendamientoSesion.Id_agendamiento);
                        mensaje = "Se actualizó correctamente la sesión";
                    }

                    if (rpta.Equals("OK"))
                    {
                        OnRefresh?.Invoke(sender, e);
                        Mensajes.MensajeOkForm(mensaje);
                        this.Close();
                    }
                    else
                    {
                        throw new Exception(rpta);
                    }
                }
            }
            catch (Exception ex)
            { 
                Mensajes.MensajeErrorCompleto(this.Name, "BtnGuardar_Click",
                    "Hubo un error al agendar una sesión", ex.Message);
            }
        }

        private void FrmAgendarSesion_Load(object sender, EventArgs e)
        {
            if (!IsEditar)
            {
                dateFechaAgendamiento.MinDate = DateTime.Now;
                dateFechaAgendamiento.MaxDate = DateTime.Now.AddMonths(+2);

                this.listaHoraInicio =
                    ListTools.ListaHoras(this.listaHoraInicio);
            }
        }

        private bool _isEditar;

        public bool IsEditar { get => _isEditar; set => _isEditar = value; }
    }
}
