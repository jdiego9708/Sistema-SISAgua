using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DCierreCaja
    {
        public DCierreCaja() { }

        public static string InsertarCierreCaja(List<string> variables)
        {
            string consulta = "INSERT INTO Cierres_caja (Id_empleado, Id_apertura, Fecha_cierre, Hora_cierre, Deposito, Observaciones) " +
                "VALUES('" + variables[0] + "','" + variables[1] + "','" + variables[2] + "','" + variables[3] + "','" + 
                variables[4] + "','" + variables[5] + "'); " +
                "UPDATE Cajas " +
                "SET Estado_caja = 'CERRADA' ";
            return DConexion.EjecutarConsultaCadena(consulta, false);
        }

        public static string ModificarCierreCaja(int id_cierre, List<string> variables)
        {
            string consulta = "UPDATE Cierres_caja SET " +
                "Id_empleado ='" + variables[0] + "', " +
                "Id_apertura ='" + variables[1] + "', " +
                "Fecha_cierre ='" + variables[2] + "', " +
                "Hora_cierre ='" + variables[3] + "', " +
                "Deposito = '" + variables[4] + "', " +
                "Observaciones ='" + variables[5] + "' " +
                "WHERE Id_cierre = '" + id_cierre + "'";
            return DConexion.EjecutarConsultaCadena(consulta, false);
        }

        public static DataTable BuscarCierre(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            rpta = "OK";
            StringBuilder consulta = new StringBuilder();
            try
            {
                consulta.Append("SELECT * " +
                                "FROM Cierres_caja cc " +
                                "INNER JOIN Empleados em " +
                                "ON cc.Id_empleado = em.Id_empleado " +
                                "INNER JOIN Aperturas_caja ac " +
                                "ON cc.Id_apertura = ac.Id_apertura " +
                                "INNER JOIN Cajas ca " +
                                "ON ac.Id_caja = ca.Id_caja ");

                if (tipo_busqueda.Equals("ID_EMPLEADO"))
                {
                    consulta.Append("WHERE cc.Id_empleado = '" + texto_busqueda + "'");
                }
                else if (tipo_busqueda.Equals("ID APERTURA"))
                {
                    consulta.Append("WHERE Id_apertura = '" + texto_busqueda + "'");
                }
                else if (tipo_busqueda.Equals("ID CAJA"))
                {
                    consulta.Append("WHERE ac.Id_caja = '" + texto_busqueda + "' ");
                }
                consulta.Append("ORDER BY Id_cierre DESC");
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
