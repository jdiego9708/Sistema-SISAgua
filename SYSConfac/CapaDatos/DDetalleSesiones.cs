using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DDetalleSesiones
    {
        public DDetalleSesiones() { }

        public static string InsertarDetalleSesion(List<string> variables)
        {
            string consulta = "INSERT INTO Detalle_sesiones (Id_sesion, Id_cliente, Estado) " +
                "VALUES('" + variables[0] + "','" + variables[1] + "','" + variables[2] + "')";
            return DConexion.EjecutarConsultaCadena(consulta, false);
        }

        public static DataTable BuscarDetalleSesion(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            rpta = "OK";
            StringBuilder consulta = new StringBuilder();
            try
            {
                consulta.Append("SELECT * FROM Detalle_sesiones ds INNER JOIN Sesiones se ON ds.Id_sesion = se.Id_sesion " +
                    "INNER JOIN Clientes cl ON ds.Id_cliente = cl.Id_cliente ");

                if (tipo_busqueda.Equals("ID SESION"))
                {
                    consulta.Append("WHERE ds.Id_sesion = '" + texto_busqueda + "' ");
                }
                else if (tipo_busqueda.Equals("ID CLIENTE"))
                {
                    consulta.Append("WHERE ds.Id_cliente = '" + texto_busqueda + "' ");
                }
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
