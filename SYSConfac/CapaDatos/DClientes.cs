using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DClientes
    {
        public DClientes() { }

        public static string InsertarCliente(List<string> variables, out int id_cliente)
        {
            string consulta = "INSERT INTO Clientes (Nombres, Apellidos, Identificacion, " +
                "Celular, Correo_electronico, Estado_cliente) " +
                "VALUES('" + variables[0] + "','" + variables[1] + "','" + variables[2] + "','" + variables[3] +
                "','" + variables[4] + "','" + variables[5] + "'); " + 
                "SELECT last_insert_rowid() ";
            string rpta = DConexion.EjecutarConsultaCadena(consulta, true);
            id_cliente = DConexion.Id_autogenerado;
            return rpta;
        }

        public static string ModificarCliente(int id_cliente, List<string> variables)
        {
            string consulta = "UPDATE Clientes SET " +
                "Nombres ='" + variables[0] + "', " +
                "Apellidos ='" + variables[1] + "', " +
                "Identificacion ='" + variables[2] + "', " +
                "Celular ='" + variables[3] + "', " +
                "Correo_electronico ='" + variables[4] + "', " +
                "Estado_cliente ='" + variables[5] + "' " +
                "WHERE Id_cliente = '" + id_cliente + "'";
            return DConexion.EjecutarConsultaCadena(consulta, false);
        }

        public static DataTable BuscarClientes(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            rpta = "OK";
            StringBuilder consulta = new StringBuilder();
            try
            {
                consulta.Append("SELECT cl.* " +
                    "FROM Clientes cl ");

                if (tipo_busqueda.Equals("TODO"))
                {
                    consulta.Append("WHERE Nombres like '" + texto_busqueda + "%' or " +
                        "Apellidos like '" + texto_busqueda + "%' or " +
                        "Identificacion like '" + texto_busqueda + "%' or " +
                        "Celular like '" + texto_busqueda + "%' or " +
                        "Correo_electronico like '" + texto_busqueda + "%'");
                }
                else if (tipo_busqueda.Equals("ID CLIENTE"))
                {
                    consulta.Append("WHERE Id_cliente = '" + texto_busqueda + "'");
                }
                else if (tipo_busqueda.Equals("NOMBRE EXACTO"))
                {
                    consulta.Append("WHERE (Nombres + ' ' + Apellidos) like '" + texto_busqueda + "'");
                }
                else if (tipo_busqueda.Equals("IDENTIFICACION EXACTA"))
                {
                    consulta.Append("WHERE Identificacion = '" + texto_busqueda + "' ");
                }
                consulta.Append("ORDER BY Id_cliente DESC");
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
