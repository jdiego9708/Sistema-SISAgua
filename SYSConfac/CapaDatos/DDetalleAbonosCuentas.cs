using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DDetalleAbonosCuentas
    {
        public DDetalleAbonosCuentas() { }

        public static string InsertarAbono(out int id_abono, List<string> variables)
        {
            string consulta = "INSERT INTO Detalle_abonos_cuentas (Id_cuenta, Fecha_abono, Hora_abono, Valor_abono, Valor_restante, Observaciones) " +
                "VALUES('" + variables[0] + "','" + variables[1] + "','" + variables[2] + "','" + variables[3] + "','" + variables[4] + "','"
                + variables[5] + "'); " +
                "SELECT last_insert_rowid() ";
            string rpta = DConexion.EjecutarConsultaCadena(consulta, true);
            id_abono = DConexion.Id_autogenerado;
            return rpta;
        }

        public static string ModificarAbono(int id_abono, List<string> variables)
        {
            string consulta = "UPDATE Detalle_abonos_cuentas SET " +
                "Fecha_abono ='" + variables[0] + "', " +
                "Hora_abono ='" + variables[1] + "', " +
                "Valor_abono ='" + variables[2] + "', " +
                "Valor_restante ='" + variables[3] + "'" +
                "Observaciones ='" + variables[4] + "'" +
                "WHERE Id_abono = '" + id_abono + "'";
            return DConexion.EjecutarConsultaCadena(consulta, false);
        }

        public static DataTable BuscarAbonos(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            rpta = "OK";
            StringBuilder consulta = new StringBuilder();
            try
            {
                consulta.Append("SELECT * " +
                    "FROM Detalle_abonos_cuentas dac " +
                    "INNER JOIN Cuentas_cliente ccl " +
                    "ON dac.Id_cuenta = ccl.Id_cuenta " +
                    "INNER JOIN Clientes cl " +
                    "ON ccl.Id_cliente = cl.Id_cliente ");

                if (tipo_busqueda.Equals("COMPLETO ID CUENTA"))
                {
                    consulta.Append("WHERE dac.Id_cuenta = '" + texto_busqueda + "' ");
                }
                else if (tipo_busqueda.Equals("FECHA ABONO"))
                {
                    consulta.Append("WHERE Fecha_abono = '" + texto_busqueda + "' ");
                }
                consulta.Append("ORDER BY Id_abono DESC");
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
