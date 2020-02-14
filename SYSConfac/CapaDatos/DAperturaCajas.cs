using System;
using System.Collections.Generic;

using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CapaDatos
{
    public class DAperturaCajas
    {
        public DAperturaCajas() { }

        public static string InsertarAperturaCaja(List<string> variables)
        {
            string consulta = "INSERT INTO Aperturas_caja (Id_empleado, Id_caja, Fecha_apertura, Hora_apertura, Valor_inicial) " +
                "VALUES('" + variables[0] + "','" + variables[1] + "','" + variables[2] + "','" + variables[3] + "','"+ variables[4] + "'); " +
                "UPDATE Cajas " +
                "SET Estado_caja = 'ABIERTA' " +
                "WHERE Id_caja = '"+ variables[1] + "' ";
            return DConexion.EjecutarConsultaCadena(consulta, false);
        }

        public static string ModificarAperturaCaja(int id_apertura, List<string> variables)
        {
            string consulta = "UPDATE Aperturas_caja SET " +
                "Id_caja ='" + variables[0] + "', " +
                "Fecha_apertura ='" + variables[1] + "', " +
                "Hora_apertura ='" + variables[2] + "', " +
                "Valor_inicial ='" + variables[3] + "' " +
                "WHERE Id_apertura = '" + id_apertura + "'";
            return DConexion.EjecutarConsultaCadena(consulta, false);
        }

        public static DataTable BuscarAperturaCajas(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            rpta = "OK";
            StringBuilder consulta = new StringBuilder();
            try
            {
                consulta.Append("SELECT * " +
                "FROM Aperturas_caja ac " +
                "INNER JOIN Empleados em " +
                "ON ac.Id_empleado = em.Id_empleado " +
                "INNER JOIN Cajas ca " +
                "ON ac.Id_caja = ca.Id_caja ");

                if (tipo_busqueda.Equals("ID EMPLEADO"))
                {
                    consulta.Append("WHERE ac.Id_empleado = " + texto_busqueda + " ");
                }
                else if (tipo_busqueda.Equals("ID CAJA"))
                {
                    consulta.Append("WHERE ac.Id_Caja = " + texto_busqueda + " ");
                }
                consulta.Append("ORDER BY ac.Id_apertura DESC");
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
