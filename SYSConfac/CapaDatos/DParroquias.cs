using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DParroquias
    {
        public DParroquias() { }

        public static string InsertarParroquia(List<string> variables)
        {
            string consulta = "INSERT INTO Parroquias (Id_canton, Nombre, Descripcion) " +
                "VALUES('" + variables[0] + "','" + variables[1] + "','" + variables[2] + "')";
            return DConexion.EjecutarConsultaCadena(consulta, false);
        }

        public static string ModificarParroquia(int id_parroquia, List<string> variables)
        {
            string consulta = "UPDATE Parroquias SET " +
                "Id_canton ='" + variables[0] + "', " +
                "Nombre ='" + variables[1] + "', " +
                "Descripcion ='" + variables[2] + "' " +
                "WHERE Id_parroquia = '" + id_parroquia + "'";
            return DConexion.EjecutarConsultaCadena(consulta, false);
        }

        public static DataTable BuscarParroquia(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            rpta = "OK";
            StringBuilder consulta = new StringBuilder();
            try
            {
                consulta.Append("SELECT * FROM Parroquias ");

                if (tipo_busqueda.Equals("NOMBRE"))
                {
                    consulta.Append("WHERE Nombre like '" + texto_busqueda + "%'");
                }
                else if (tipo_busqueda.Equals("NOMBRE EXACTO"))
                {
                    consulta.Append("WHERE Nombre like '" + texto_busqueda + "'");
                }
                else if (tipo_busqueda.Equals("ID"))
                {
                    consulta.Append("WHERE Id_parroquia = '" + texto_busqueda + "' ");
                }
                consulta.Append("ORDER BY Id_parroquia DESC");
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
