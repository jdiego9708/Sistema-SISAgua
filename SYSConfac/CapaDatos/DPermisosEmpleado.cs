using System;
using System.Collections.Generic;

using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CapaDatos
{
    public class DPermisosEmpleado
    {
        public DPermisosEmpleado() { }

        public static string InsertarPermiso(List<string> variables)
        {
            string consulta = "INSERT INTO Permisos_empleado (Nombre_funcion, Estado) " +
                "VALUES('" + variables[0] + "','" + variables[1] + "')";
            return DConexion.EjecutarConsultaCadena(consulta, false);
        }

        public static string ModificarPermiso(int id_permiso, List<string> variables)
        {
            string consulta = "UPDATE Permisos_empleado SET " +
                "Nombre_funcion ='" + variables[0] + "', " +
                "Estado ='" + variables[1] + "' " +            
                "WHERE Id_permiso = '" + id_permiso + "'";
            return DConexion.EjecutarConsultaCadena(consulta, false);
        }

        public static DataTable BuscarPermisos(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            rpta = "OK";
            StringBuilder consulta = new StringBuilder();
            try
            {
                consulta.Append("SELECT * FROM Permisos_empleado per INNER JOIN Empleados emp ON per.Id_empleado = emp.Id_empleado ");

                if (tipo_busqueda.Equals("ID EMPLEADO"))
                {
                    consulta.Append("WHERE per.Id_empleado = '" + texto_busqueda + "' ");
                }
                consulta.Append("ORDER BY per.Id_permiso DESC");
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
