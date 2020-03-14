using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaEntidades
{
    public class EAgendamientoSesion
    {
        public EAgendamientoSesion()
        {

        }

        public EAgendamientoSesion(DataRow row)
        {
            try
            {
                this.Id_agendamiento = Convert.ToInt32(row["Id_agendamiento"]);
                this.Titulo = Convert.ToString(row["Titulo_agendamiento_sesion"]);
                this.Fecha = Convert.ToDateTime(row["Fecha_agendamiento_sesion"]);
                this.Hora = Convert.ToString(row["Hora_agendamiento_sesion"]);
                this.Estado = Convert.ToString(row["Estado_agendamiento_sesion"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public EAgendamientoSesion(DataTable dt, int fila)
        {
            try
            {
                this.Id_agendamiento = Convert.ToInt32(dt.Rows[fila]["Id_agendamiento"]);
                this.Titulo = Convert.ToString(dt.Rows[fila]["Titulo_agendamiento_sesion"]);
                this.Fecha = Convert.ToDateTime(dt.Rows[fila]["Fecha_agendamiento_sesion"]);
                this.Hora = Convert.ToString(dt.Rows[fila]["Hora_agendamiento_sesion"]);
                this.Estado = Convert.ToString(dt.Rows[fila]["Estado_agendamiento_sesion"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public EAgendamientoSesion(int id_agendamiento)
        {
            try
            {
                DataTable dt =
                    DAgendamientoLecturas.BuscarAgendamientos("ID AGENDAMIENTO", id_agendamiento.ToString(),
                    out string rpta);
                if (dt != null)
                {
                    this.Id_agendamiento = Convert.ToInt32(dt.Rows[0]["Id_agendamiento"]);
                    this.Titulo = Convert.ToString(dt.Rows[0]["Titulo_agendamiento_sesion"]);
                    this.Fecha = Convert.ToDateTime(dt.Rows[0]["Fecha_agendamiento_sesion"]);
                    this.Hora = Convert.ToString(dt.Rows[0]["Hora_agendamiento_sesion"]);
                    this.Estado = Convert.ToString(dt.Rows[0]["Estado_agendamiento_sesion"]);
                }
                else
                {
                    if (!rpta.Equals("OK"))
                        throw new Exception(rpta);
                }
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public static DataTable BuscarAgendamientosSesiones(string tipo_busqueda,
            string texto_busqueda1, string texto_busqueda2, out string rpta)
        {
            return DAgendamientoSesiones.BuscarAgendamientosSesion(tipo_busqueda, texto_busqueda1, texto_busqueda2, out rpta);
        }

        public static string InsertarAgendamientoSesion(EAgendamientoSesion agendamiento, out int id_agendamiento)
        {
            List<string> vs = new List<string>
            {
                agendamiento.Titulo,
                agendamiento.Fecha.ToString("yyyy-MM-dd"),
                agendamiento.Hora,
                agendamiento.Estado
            };
            return DAgendamientoSesiones.InsertarAgendamientoSesion(out id_agendamiento, vs);
        }

        public static string EditarAgendamiento(EAgendamientoSesion agendamiento, int id_agendamiento)
        {
            List<string> vs = new List<string>
            {
                agendamiento.Titulo,
                agendamiento.Fecha.ToString("yyyy-MM-dd"),
                agendamiento.Hora,
                agendamiento.Estado
            };
            return DAgendamientoSesiones.ModificarAgendamientoSesion(id_agendamiento, vs);
        }

        public event EventHandler OnError;
        private int _id_agendamiento;
        private string _titulo;
        private DateTime _fecha;
        private string _hora;
        private string _estado;

        public int Id_agendamiento { get => _id_agendamiento; set => _id_agendamiento = value; }
        public string Titulo { get => _titulo; set => _titulo = value; }
        public DateTime Fecha { get => _fecha; set => _fecha = value; }
        public string Hora { get => _hora; set => _hora = value; }
        public string Estado { get => _estado; set => _estado = value; }
    }
}
