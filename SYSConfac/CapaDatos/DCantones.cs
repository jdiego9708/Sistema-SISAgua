using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace CapaDatos
{
    public class DCantones
    {
        public DCantones() { }

        public static string InsertarCanton(List<string> variables)
        {
            string consulta = "INSERT INTO Cantones (Nombre, Descripcion) " +
                "VALUES('" + variables[0] + "','" + variables[1] + "')";
            return DConexion.EjecutarConsultaCadena(consulta, false);
        }

        public static string ModificarCanton(int id_canton, List<string> variables)
        {
            string consulta = "UPDATE Cantones SET " +
                "Nombre ='" + variables[0] + "', " +
                "Descripcion ='" + variables[1] + "' " +
                "WHERE Id_canton = '" + id_canton + "'";
            return DConexion.EjecutarConsultaCadena(consulta, false);
        }

        public static DataTable BuscarCantones(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            rpta = "OK";
            StringBuilder consulta = new StringBuilder();
            try
            {
                consulta.Append("SELECT * FROM Cantones ");

                if (tipo_busqueda.Equals("NOMBRE"))
                {
                    consulta.Append("WHERE Nombre like '" + texto_busqueda + "%' ");
                }
                else if (tipo_busqueda.Equals("NOMBRE EXACTO"))
                {
                    consulta.Append("WHERE Nombre = '" + texto_busqueda + "' ");
                }
                else if (tipo_busqueda.Equals("ID"))
                {
                    consulta.Append("WHERE Id_canton = '" + texto_busqueda + "' ");
                }
                consulta.Append("ORDER BY Id_canton DESC ");
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
