using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DAgendamientoLecturas
    {
        public DAgendamientoLecturas() { }

        public static string InsertarAgendamiento(out int id_agendamiento, List<string> variables)
        {
            string consulta = "INSERT INTO Agendamiento_lecturas (Mes_agendamiento, Estado_agendamiento) " +
                "VALUES('" + variables[0] + "','" + variables[1] + "'); " +
                "SELECT last_insert_rowid() ";
            string rpta = DConexion.EjecutarConsultaCadena(consulta, true);
            id_agendamiento = DConexion.Id_autogenerado;
            return rpta;
        }

        public static DataTable BuscarAgendamientos(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            rpta = "OK";
            StringBuilder consulta = new StringBuilder();
            try
            {
                consulta.Append("SELECT * FROM Agendamiento_lecturas ");

                if (tipo_busqueda.Equals("ID AGENDAMIENTO"))
                {
                    consulta.Append("WHERE Id_agendamiento_lectura = '" + texto_busqueda + "' ");
                }
                else if (tipo_busqueda.Equals("MES"))
                {
                    consulta.Append("WHERE Mes_agendamiento like '" + texto_busqueda + "' and " +
                        "Estado_agendamiento = 'PENDIENTE' ");
                }
                consulta.Append("ORDER BY Id_agendamiento_lectura DESC");
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
