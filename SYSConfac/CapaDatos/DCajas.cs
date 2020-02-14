using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DCajas
    {
        public DCajas() { }

        public static string InsertarCajas(List<string> variables)
        {
            string consulta = "INSERT INTO Cajas (Id_caja, Nombre_caja, Estado_caja) " +
                "VALUES('" + variables[0] + "','" + variables[1] + "','" + variables[2] + "')";
            return DConexion.EjecutarConsultaCadena(consulta, false);
        }

        public static string ModificarCajas(int id_caja, List<string> variables)
        {
            string consulta = "UPDATE Cajas SET " +
                "Nombre_caja ='" + variables[0] + "', " +
                "Estado_caja ='" + variables[1] + "' " +
                "WHERE Id_caja = '" + id_caja + "'";
            return DConexion.EjecutarConsultaCadena(consulta, false);
        }

        public static DataTable BuscarCajas(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            rpta = "OK";
            StringBuilder consulta = new StringBuilder();
            try
            {
                consulta.Append("SELECT * FROM Cajas ");

                if (tipo_busqueda.Equals("NOMBRE"))
                {
                    consulta.Append("WHERE Nombre_caja like '" + texto_busqueda + "%'");
                }
                else if (tipo_busqueda.Equals("NOMBRE EXACTO"))
                {
                    consulta.Append("WHERE Nombre like '" + texto_busqueda + "'");
                }
                else if (tipo_busqueda.Equals("ID CAJA"))
                {
                    consulta.Append("WHERE Id_caja = '" + texto_busqueda + "' ");
                }
                consulta.Append("ORDER BY Id_caja DESC");
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
