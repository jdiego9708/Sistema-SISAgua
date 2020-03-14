using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DEmpleados
    {
        public DEmpleados() { }

        public static string InsertarEmpleado(List<string> variables)
        {
            string consulta = "INSERT INTO Empleados (Nombre_completo, Celular, Correo_electronico, " +
                "Estado_empleado, Tipo_empleado, Clave, Permisos) " +
                "VALUES('" + variables[0] + "','" + variables[1] + "','" + variables[2] + "','" + variables[3] + "','" + 
                variables[4] + "','" + variables[5] + "','" + variables[6] + "') ";
            return DConexion.EjecutarConsultaCadena(consulta, false);
        }

        public static string ModificarEmpleado(int id_empleado, List<string> variables)
        {
            string consulta = "UPDATE Empleados SET " +
                "Nombre_completo ='" + variables[0] + "', " +
                "Celular ='" + variables[1] + "', " +
                "Correo_electronico ='" + variables[2] + "', " +
                "Estado_empleado ='" + variables[3] + "', " +
                "Tipo_empleado = '" + variables[4] + "', " +
                "Clave = '" + variables[5] + "', " + 
                "Permisos = '" + variables[6] + "' " +
                "WHERE Id_empleado = '" + id_empleado + "'";
            return DConexion.EjecutarConsultaCadena(consulta, false);
        }

        public static DataTable BuscarEmpleados(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            rpta = "OK";
            StringBuilder consulta = new StringBuilder();
            try
            {
                consulta.Append("SELECT * FROM Empleados ");

                if (tipo_busqueda.Equals("ID EMPLEADO"))
                {
                    consulta.Append("WHERE Id_empleado = '" + texto_busqueda + "' ");
                }
                else if (tipo_busqueda.Equals("NOMBRE"))
                {
                    consulta.Append("WHERE Nombre_completo like '" + texto_busqueda + "' ");
                }
                consulta.Append("ORDER BY Id_empleado DESC");
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
                return null;
            }

            return DConexion.EjecutarConsultaDt(Convert.ToString(consulta), out rpta);
        }

        public static DataTable Login(string usuario, string pass, out string rpta)
        {
            rpta = "OK";
            StringBuilder consulta = new StringBuilder();
            try
            {
                consulta.Append("SELECT * FROM Empleados ");
                consulta.Append("WHERE Nombre_completo like '" + usuario + "' and Clave = '" + pass + "' ");
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
