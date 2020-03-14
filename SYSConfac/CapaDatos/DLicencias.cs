using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DLicencias
    {
        public DLicencias() { }

        public static string InsertarLicencia(List<string> variables)
        {
            string consulta = "INSERT INTO Licencias (Fecha_ingreso, Licencia, Fecha_activacion, " +
                "Fecha_vencimiento, Estado_licencia) " +
                "VALUES('" + variables[0] + "','" + variables[1] + "','" + variables[2] + "','" + variables[3] + "','" + variables[4] + "')";
            return DConexion.EjecutarConsultaCadena(consulta, false);
        }

        public static string ModificarLicencias(int id_licencia, List<string> variables)
        {
            string consulta = "UPDATE Licencias SET " +
                "Fecha_ingreso ='" + variables[0] + "', " +
                "Licencia ='" + variables[1] + "', " +
                "Fecha_activacion ='" + variables[2] + "', " +
                "Fecha_vencimiento ='" + variables[3] + "', " +
                "Estado_licencia ='" + variables[4] + "'" +
                "WHERE Id_licencia = '" + id_licencia + "'";
            return DConexion.EjecutarConsultaCadena(consulta, false);
        }

        public static DataTable BuscarLicencias(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            rpta = "OK";
            StringBuilder consulta = new StringBuilder();
            try
            {
                consulta.Append("SELECT * FROM Licencias ");

                if (tipo_busqueda.Equals("ESTADO"))
                {
                    consulta.Append("WHERE Estado_licencia = '" + texto_busqueda + "' ");
                }
                
                consulta.Append("ORDER BY Id_licencia DESC");
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
