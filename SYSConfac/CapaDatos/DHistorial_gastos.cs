using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DHistorial_gastos
    {
        public DHistorial_gastos() { }

        public static string InsertarHistorialGasto(out int id_historial_gasto, List<string> variables)
        {
            string consulta = "INSERT INTO Historial_gastos (Fecha_gasto, Hora_gasto, Id_gasto, " +
                "Id_empleado, Valor_gasto) " +
                "VALUES('" + variables[0] + "','" + variables[1] + "','" + variables[2] + "','" + variables[3] + "','" + variables[4] + "'); " +
                "SELECT last_insert_rowid() ";
            string rpta = DConexion.EjecutarConsultaCadena(consulta, true);
            id_historial_gasto = DConexion.Id_autogenerado;
            return rpta;
        }

        public static string ModificarHistorialGasto(int id_historial_gasto, List<string> variables)
        {
            string consulta = "UPDATE Historial_gastos SET " +
                "Fecha_gasto ='" + variables[0] + "', " +
                "Hora_gasto ='" + variables[1] + "', " +
                "Id_gasto ='" + variables[2] + "', " +
                "Id_empleado ='" + variables[3] + "', " +
                "Valor_gasto = '" + variables[4] + "' " +
                "WHERE Id_historial_gasto = '" + id_historial_gasto + "'";
            return DConexion.EjecutarConsultaCadena(consulta, false);
        }

        public static DataTable BuscarHistorialGastos(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            rpta = "OK";
            StringBuilder consulta = new StringBuilder();
            try
            {
                consulta.Append("SELECT * FROM Historial_gastos hg INNER JOIN Gastos gas ON hg.Id_gasto = gas.Id_gasto " +
                    "INNER JOIN Empleados em ON hg.Id_empleado = em.Id_empleado ");

                if (tipo_busqueda.Equals("FECHA"))
                {
                    consulta.Append("WHERE Fecha_gasto like '" + texto_busqueda + "' ");
                }
                else if (tipo_busqueda.Equals("ID GASTO"))
                {
                    consulta.Append("WHERE Id_gasto = '" + texto_busqueda + "' ");
                }
                else if (tipo_busqueda.Equals("ID EMPLEADO"))
                {
                    consulta.Append("WHERE Id_empleado = '" + texto_busqueda + "' ");
                }
                else if (tipo_busqueda.Equals("MES"))
                {
                    int mes = Convert.ToInt32(texto_busqueda);
                    DateTime date1 = new DateTime(DateTime.Now.Year, mes, 01);
                    DateTime date2 = new DateTime(DateTime.Now.Year, mes,
                        DateTime.DaysInMonth(DateTime.Now.Year, mes));

                    consulta.Append("WHERE Fecha_gasto between '" + date1.ToString("yyyy-MM-dd") + "' and '" +
                        date2.ToString("yyyy-MM-dd") + "' ");
                }
                consulta.Append("ORDER BY Id_historial_gasto DESC");
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
