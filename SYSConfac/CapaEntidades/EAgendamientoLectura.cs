using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaEntidades
{
    public class EAgendamientoLectura
    {
        public EAgendamientoLectura()
        {

        }

        public EAgendamientoLectura(DataRow row)
        {
            try
            {
                this.Id_agendamiento = Convert.ToInt32(row["Id_agendamiento_lectura"]);
                this.Mes_agendamiento = Convert.ToString(row["Mes_agendamiento"]);
                this.Estado_agendamiento = Convert.ToString(row["Estado_agendamiento"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public EAgendamientoLectura(DataTable dt, int fila)
        {
            try
            {
                this.Id_agendamiento = Convert.ToInt32(dt.Rows[fila]["Id_agendamiento_lectura"]);
                this.Mes_agendamiento = Convert.ToString(dt.Rows[fila]["Mes_agendamiento"]);
                this.Estado_agendamiento = Convert.ToString(dt.Rows[fila]["Estado_agendamiento"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public EAgendamientoLectura(int id_agendamiento)
        {
            try
            {
                DataTable dt =
                    DAgendamientoLecturas.BuscarAgendamientos("ID AGENDAMIENTO", id_agendamiento.ToString(),
                    out string rpta);
                if (dt != null)
                {
                    this.Id_agendamiento = Convert.ToInt32(dt.Rows[0]["Id_agendamiento_lectura"]);
                    this.Mes_agendamiento = Convert.ToString(dt.Rows[0]["Mes_agendamiento"]);
                    this.Estado_agendamiento = Convert.ToString(dt.Rows[0]["Estado_agendamiento"]);
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

        public static DataTable BuscarAgendamientos(string tipo_busqueda,
            string texto_busqueda, out string rpta)
        {
            return DAgendamientoLecturas.BuscarAgendamientos(tipo_busqueda, texto_busqueda, out rpta);
        }

        public static string InsertarAgendamiento(EAgendamientoLectura agendamiento, out int id_agendamiento)
        {
            List<string> vs = new List<string>
            {
                agendamiento.Mes_agendamiento,
                agendamiento.Estado_agendamiento
            };
            return DAgendamientoLecturas.InsertarAgendamiento(out id_agendamiento, vs);
        }


        public event EventHandler OnError;
        private int _id_agendamiento;
        private string _mes_agendamiento;
        private string _estado_agendamiento;

        public int Id_agendamiento { get => _id_agendamiento; set => _id_agendamiento = value; }
        public string Mes_agendamiento { get => _mes_agendamiento; set => _mes_agendamiento = value; }
        public string Estado_agendamiento { get => _estado_agendamiento; set => _estado_agendamiento = value; }
    }
}
