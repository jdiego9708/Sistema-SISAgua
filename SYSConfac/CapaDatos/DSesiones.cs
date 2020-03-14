using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DSesiones
    {
        public DSesiones() { }

        public static string InsertarSesion(List<string> variables, out int id_sesion)
        {
            string consulta = "INSERT INTO Sesiones (Fecha_sesion, Hora_sesion, Titulo_sesion, Descripcion_sesion, Documento_adjunto) " +
                "VALUES('" + variables[0] + "','" + variables[1] + "','" + variables[2] + "','" + variables[3] + "','" + variables[4] + "'); " +
                "SELECT last_insert_rowid() ";
            string rpta = DConexion.EjecutarConsultaCadena(consulta, true);
            id_sesion = DConexion.Id_autogenerado;
            return rpta;
        }

        public static string ModificarSesion(int id_sesion, List<string> variables)
        {
            string consulta = "UPDATE Sesiones SET " +
                "Fecha_sesion ='" + variables[0] + "', " +
                "Hora_sesion ='" + variables[1] + "', " +
                "Titulo_sesion ='" + variables[2] + "', " +
                "Descripcion_sesion ='" + variables[3] + "', " +
                "Documento_adjunto ='" + variables[4] + "', " +
                "WHERE Id_sesion = '" + id_sesion + "'";
            return DConexion.EjecutarConsultaCadena(consulta, false);
        }

        public static DataTable BuscarSesiones(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            rpta = "OK";
            StringBuilder consulta = new StringBuilder();
            try
            {
                consulta.Append("SELECT * " +
                "FROM Sesiones se ");

                if (tipo_busqueda.Equals("FECHA SESION"))
                {
                    consulta.Append("WHERE se.Fecha_sesion = '" + texto_busqueda + "' ");
                }
                else if (tipo_busqueda.Equals("TITULO"))
                {
                    consulta.Append("WHERE se.Titulo_sesion = '" + texto_busqueda + "' ");
                }

                consulta.Append("ORDER BY se.Id_sesion DESC");
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
