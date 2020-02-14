using System;
using System.Collections.Generic;

using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CapaDatos
{
    public class DBarrios
    {
        public DBarrios() { }

        public static string InsertarBarrios(List<string> variables)
        {
            string consulta = "INSERT INTO Barrios (Id_parroquia, Nombre, Descripcion) " +
                "VALUES('" + variables[0] + "','" + variables[1] + "','" + variables[2] + "')";
            return DConexion.EjecutarConsultaCadena(consulta, false);
        }

        public static string ModificarBarrios(int id_barrio, List<string> variables)
        {
            string consulta = "UPDATE Barrios SET " +
                "Id_parroquia ='" + variables[0] + "', " +
                "Nombre ='" + variables[1] + "', " +
                "Descripcion ='" + variables[2] + "' " +              
                "WHERE Id_barrio = '" + id_barrio + "'";
            return DConexion.EjecutarConsultaCadena(consulta, false);
        }

        public static DataTable BuscarBarrios(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            rpta = "OK";
            StringBuilder consulta = new StringBuilder();
            try
            {
                consulta.Append("SELECT * " +
                    "FROM Barrios ba " +
                    "INNER JOIN Parroquias pa ON ba.Id_parroquia = pa.Id_parroquia " +
                    "INNER JOIN Cantones can ON pa.Id_canton = can.Id_canton ");

                if (tipo_busqueda.Equals("NOMBRE"))
                {
                    consulta.Append("WHERE ba.Nombre like '%" + texto_busqueda + "%' ");
                }
                else if (tipo_busqueda.Equals("NOMBRE EXACTO"))
                {
                    consulta.Append("WHERE ba.Nombre like '" + texto_busqueda + "' ");
                }
                else if (tipo_busqueda.Equals("ID"))
                {
                    consulta.Append("WHERE ba.Id_barrio = '" + texto_busqueda + "' ");
                }
                consulta.Append("ORDER BY ba.Id_barrio DESC");
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
