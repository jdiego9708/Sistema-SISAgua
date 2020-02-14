using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DMedidas
    {
        public DMedidas() { }

        public static string InsertarMedida(List<string> variables)
        {
            string consulta = "INSERT INTO Medidas (Descripcion_medida, Alias_medida) " +
                "VALUES('" + variables[0] + "','" + variables[1] + "') ";
            return DConexion.EjecutarConsultaCadena(consulta, false);
        }

        public static string ModificarMedida(int id_medida, List<string> variables)
        {
            string consulta = "UPDATE Medidas SET " +
                "Descripcion_medida ='" + variables[0] + "', " +
                "Alias_medida = '" + variables[1] + "' " +         
                "WHERE Id_medida = '" + id_medida + "'";
            return DConexion.EjecutarConsultaCadena(consulta, false);
        }

        public static DataTable BuscarMedidas(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            rpta = "OK";
            StringBuilder consulta = new StringBuilder();
            try
            {
                consulta.Append("SELECT * FROM Medidas ");

                if (tipo_busqueda.Equals("DESCRIPCION"))
                {
                    consulta.Append("WHERE Descripcion_medida like '" + texto_busqueda + "%' ");
                }
                else if (tipo_busqueda.Equals("NOMBRE EXACTO"))
                {
                    consulta.Append("WHERE Descripcion_medida like '" + texto_busqueda + "' ");
                }
                consulta.Append("ORDER BY Id_medida DESC");
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
