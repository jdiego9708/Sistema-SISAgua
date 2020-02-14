using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DDireccion_cliente
    {
        public DDireccion_cliente() { }

        public static string InsertarDireccionCliente(List<string> variables, out int id_direccion)
        {
            string consulta = "INSERT INTO Direccion_clientes (Id_cliente, Direccion, Id_barrio, Tipo_establecimiento, Estado_direccion) " +
                "VALUES('" + variables[0] + "','" + variables[1] + "','" + variables[2] + "','" + variables[3] + "','" + variables[4] + "'); " +
                "SELECT last_insert_rowid() ";
            string rpta = DConexion.EjecutarConsultaCadena(consulta, true);
            id_direccion = DConexion.Id_autogenerado;
            return rpta;
        }

        public static string ModificarDireccionCliente(int id_direccion, List<string> variables)
        {
            string consulta = "UPDATE Direccion_clientes SET " +
                "Id_cliente ='" + variables[0] + "', " +
                "Direccion ='" + variables[1] + "', " +
                "Id_barrio ='" + variables[2] + "', " +
                "Tipo_establecimiento ='" + variables[3] + "', " +
                "Estado_direccion ='" + variables[4] + "' " +
                "WHERE Id_direccion = '" + id_direccion + "'";
            return DConexion.EjecutarConsultaCadena(consulta, false);
        }

        public static DataTable BuscarDirecciones(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            rpta = "OK";
            StringBuilder consulta = new StringBuilder();
            try
            {
                consulta.Append("SELECT * " +
                "FROM Direccion_clientes dcl " +
                "INNER JOIN Clientes cl " +
                "ON dcl.Id_cliente = cl.Id_cliente " +
                "INNER JOIN Barrios bar " +
                "ON dcl.Id_barrio = bar.Id_barrio " +
                "INNER JOIN Parroquias par " +
                "ON bar.Id_parroquia = par.Id_parroquia " +
                "INNER JOIN Cantones can " +
                "ON par.Id_canton = can.Id_canton ");

                if (tipo_busqueda.Equals("COMPLETO"))
                {
                    consulta.Append("WHERE dcl.Estado_direccion = 'ACTIVO' ");
                }
                else if (tipo_busqueda.Equals("DIRECCION"))
                {
                    consulta.Append("WHERE dcl.Direccion like '" + texto_busqueda + "%' ");
                }
                else if (tipo_busqueda.Equals("COMPLETO ID CLIENTE"))
                {
                    consulta.Append("WHERE dcl.Id_cliente = '" + texto_busqueda + "' and dcl.Estado_direccion = 'ACTIVO' ");
                }
                else if (tipo_busqueda.Equals("BARRIO "))
                {
                    consulta.Append("WHERE dcl.Id_barrio = '" + texto_busqueda + "' and dcl.Estado_direccion = 'ACTIVO' ");
                }
                else if (tipo_busqueda.Equals("ID"))
                {
                    consulta.Append("WHERE dcl.Id_direccion = '" + texto_busqueda + "' and dcl.Estado_direccion = 'ACTIVO' ");
                }
                consulta.Append("ORDER BY Id_direccion DESC");
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
                return null;
            }

            return DConexion.EjecutarConsultaDt(Convert.ToString(consulta), out rpta);
        }

        public static string InactivarDireccionCliente(int id_direccion)
        {
            string consulta = "UPDATE Direccion_clientes SET Estado_direccion = 'INACTIVO' " +
                "WHERE Id_direccion = '" + id_direccion + "'";
            return DConexion.EjecutarConsultaCadena(consulta, false);
        }
    }
}
