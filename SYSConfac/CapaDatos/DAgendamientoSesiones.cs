using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DAgendamientoSesiones
    {
        public DAgendamientoSesiones() { }

        public static string InsertarAgendamientoSesion(out int id_agendamiento, List<string> variables)
        {
            string consulta = "INSERT INTO Agendamiento_sesiones (Titulo_agendamiento_sesion, Fecha_agendamiento_sesion, " +
                "Hora_agendamiento_sesion, Estado_agendamiento) " +
                "VALUES('" + variables[0] + "','" + variables[1] + "','" + variables[2] + "','" + variables[3] + "'); " +
                "SELECT last_insert_rowid() ";
            string rpta = DConexion.EjecutarConsultaCadena(consulta, true);
            id_agendamiento = DConexion.Id_autogenerado;
            return rpta;
        }

        public static string ModificarAgendamientoSesion(int id_agendamiento, List<string> variables)
        {
            string consulta = "UPDATE Agendamiento_sesiones SET " +
                "Titulo_agendamiento_sesion ='" + variables[0] + "', " +
                "Fecha_agendamiento_sesion ='" + variables[1] + "', " +
                "Hora_agendamiento_sesion ='" + variables[2] + "', " +
                "Estado_agendamiento ='" + variables[3] + "' " +
                "WHERE Id_agendamiento = '" + id_agendamiento + "'";
            return DConexion.EjecutarConsultaCadena(consulta, false);
        }

        public static DataTable BuscarAgendamientosSesion(string tipo_busqueda, string texto_busqueda1, string texto_busqueda2, out string rpta)
        {
            rpta = "OK";
            StringBuilder consulta = new StringBuilder();
            try
            {
                consulta.Append("SELECT * FROM Agendamiento_sesiones ");

                if (tipo_busqueda.Equals("ID AGENDAMIENTO"))
                {
                    consulta.Append("WHERE Id_agendamiento = '" + texto_busqueda1 + "'");
                }
                else if (tipo_busqueda.Equals("FECHAS"))
                {
                    consulta.Append("WHERE Fecha_agendamiento_sesion between '" + texto_busqueda1 + "' and " +
                        "'" + texto_busqueda2 + "' and Estado_agendamiento = 'PENDIENTE' ");
                }
                consulta.Append("ORDER BY Id_agendamiento DESC");
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
                return null;
            }

            return DConexion.EjecutarConsultaDt(Convert.ToString(consulta), out rpta);
        }
    }
}
