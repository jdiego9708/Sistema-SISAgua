using System;
using System.Collections.Generic;

using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CapaDatos
{
    public class DMedidores
    {
        public DMedidores() { }

        public static string InsertarMedidor(List<string> variables)
        {
            string consulta = "INSERT INTO Medidores (Id_direccion, Medidor, Descripcion, " +
                "Estado_medidor) " +
                "VALUES('" + variables[0] + "','" + variables[1] + "','" + variables[2] + "','" + variables[3] + "') ";
            return DConexion.EjecutarConsultaCadena(consulta, false);
        }

        public static string ModificarMedidor(int id_medidor, List<string> variables)
        {
            string consulta = "UPDATE Medidores SET " +
                "Id_direccion ='" + variables[0] + "', " +
                "Medidor ='" + variables[1] + "', " +
                "Descripcion ='" + variables[2] + "', " +
                "Estado_medidor ='" + variables[3] + "'" +
                "WHERE Id_medidor = '" + id_medidor + "'";
            return DConexion.EjecutarConsultaCadena(consulta, false);
        }

        public static DataTable BuscarMedidores(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            rpta = "OK";
            StringBuilder consulta = new StringBuilder();
            try
            {
                consulta.Append("SELECT * " +
                    "FROM Medidores med " +
                    "INNER JOIN Direccion_clientes dcl " +
                    "ON med.Id_direccion = dcl.Id_direccion " +
                    "INNER JOIN Barrios ba " +
                    "ON dcl.Id_barrio = ba.Id_barrio " +
                    "INNER JOIN Parroquias par " +
                    "ON ba.Id_parroquia = par.Id_parroquia " +
                    "INNER JOIN Cantones can " +
                    "ON par.Id_canton = can.Id_canton " +
                    "INNER JOIN Clientes cl " +
                    "ON dcl.Id_cliente = cl.Id_cliente ");

                if (tipo_busqueda.Equals("NOMBRE"))
                {
                    consulta.Append("WHERE Medidor like '" + texto_busqueda + "%' ");
                }
                else if (tipo_busqueda.Equals("NOMBRE EXACTO"))
                {
                    consulta.Append("WHERE Medidor = '" + texto_busqueda + "' ");
                }
                else if (tipo_busqueda.Equals("ID"))
                {
                    consulta.Append("WHERE med.Id_medidor = '" + texto_busqueda + "' ");
                }
                else if (tipo_busqueda.Equals("ID DIRECCION"))
                {
                    consulta.Append("WHERE med.Id_direccion = '" + texto_busqueda + "' ");
                }
                else if (tipo_busqueda.Equals("ID CLIENTE"))
                {
                    consulta.Append("WHERE dcl.Id_cliente = '" + texto_busqueda + "' ");
                }
                consulta.Append("ORDER BY med.Id_medidor DESC");
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
