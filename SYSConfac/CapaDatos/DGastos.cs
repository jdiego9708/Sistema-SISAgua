using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DGastos
    {
        public DGastos() { }

        public static string InsertarGasto(List<string> variables)
        {
            string consulta = "INSERT INTO Gastos (Titulo_gasto, Descripcion_gasto, Estado_gasto) " +
                "VALUES('" + variables[0] + "','" + variables[1] + "','" + variables[2] + "') ";
            return DConexion.EjecutarConsultaCadena(consulta, false);
        }

        public static string ModificarGasto(int id_gasto, List<string> variables)
        {
            string consulta = "UPDATE Gastos SET " +
                "Titulo_gasto ='" + variables[0] + "', " +
                "Descripcion_gasto ='" + variables[1] + "', " +
                "Estado_gasto ='" + variables[2] + "' " +
                "WHERE Id_gasto = '" + id_gasto + "'";
            return DConexion.EjecutarConsultaCadena(consulta, false);
        }

        public static DataTable BuscarGastos(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            rpta = "OK";
            StringBuilder consulta = new StringBuilder();
            try
            {
                consulta.Append("SELECT * FROM Gastos ");

                if (tipo_busqueda.Equals("TITULO"))
                {
                    consulta.Append("WHERE Titulo_gasto like '" + texto_busqueda + "%' ");
                }
                else if (tipo_busqueda.Equals("ESTADO"))
                {
                    consulta.Append("WHERE Estado_gasto = '" + texto_busqueda + "' ");
                }
                consulta.Append("ORDER BY Id_gasto DESC");
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
