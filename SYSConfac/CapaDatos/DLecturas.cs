using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CapaDatos
{
    public class DLecturas
    {
        public DLecturas() { }

        public static string InsertarLectura(out int id_lectura, List<string> variables)
        {
            string consulta = "INSERT INTO Lecturas_cliente (Id_cliente, Id_tarifa, Id_medidor, Id_empleado, Id_cuenta, " +
                "Fecha_lectura, Hora_lectura, Valor_lectura, Total_consumo, Consumo_excedido, Id_medida, Mes_lectura) " +
                "VALUES('" + variables[0] + "','" + variables[1] + "','" + variables[2] + "','" + variables[3] + "','" +
                variables[4] + "','" + variables[5] + "','" + variables[6] + "','" + variables[7] + "','" + 
                variables[8] + "','" + variables[9] + "','" + variables[10] + "','" + variables[11].ToUpper() + "'); " +
                "SELECT last_insert_rowid(); " +
                "UPDATE Detalle_agendamiento_lecturas " +
                "SET Estado = 'TERMINADO' " +
                "WHERE Id_cliente = " + variables[0] + " and Id_medidor = " + variables[2] + " " +
                "and Estado = 'PENDIENTE' and Mes_lectura = '" + variables[11].ToUpper() + "' ";
            string rpta = DConexion.EjecutarConsultaCadena(consulta, true);
            id_lectura = DConexion.Id_autogenerado;
            return rpta;
        }

        public static string ModificarLectura(int id_lectura, List<string> variables)
        {
            string consulta = "UPDATE Lecturas_cliente SET " +
                "Id_cliente ='" + variables[0] + "', " +
                "Id_tarifa ='" + variables[1] + "', " +
                "Id_medidor ='" + variables[2] + "', " +
                "Id_empleado ='" + variables[3] + "', " +
                "Id_cuenta ='" + variables[4] + "', " +
                "Fecha_lectura ='" + variables[5] + "', " +
                "Hora_lectura ='" + variables[6] + "', " +
                "Valor_lectura ='" + variables[7] + "', " +
                "Total_consumo ='" + variables[8] + "', " +
                "Consumo_excedido ='" + variables[9] + "', " +
                "Id_medida ='" + variables[10] + "', " +
                "Mes_lectura ='" + variables[11].ToUpper() + "' " +
                "WHERE Id_lectura = '" + id_lectura + "' ";
            return DConexion.EjecutarConsultaCadena(consulta, false);
        }

        public static DataTable BuscarLecturas(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            rpta = "OK";
            StringBuilder consulta = new StringBuilder();
            try
            {
                consulta.Append("SELECT * " +
                "FROM Lecturas_cliente lec " +
                "INNER JOIN Clientes cl " +
                "ON lec.Id_cliente = cl.Id_cliente " +
                "INNER JOIN Tipo_tarifas tpt " +
                "ON lec.Id_tarifa = tpt.Id_tarifa " +
                "INNER JOIN Empleados emp " +
                "ON lec.Id_empleado = emp.Id_empleado " +
                "INNER JOIN Medidores med " +
                "ON lec.Id_medidor = med.Id_medidor " +
                "INNER JOIN Direccion_clientes dircl " +
                "ON med.Id_direccion = dircl.Id_direccion " +
                "INNER JOIN Cuentas_cliente ccl " +
                "ON lec.Id_cuenta = ccl.Id_cuenta " +
                "INNER JOIN Medidas medidas " +
                "ON lec.Id_medida = medidas.Id_medida ");

                if (tipo_busqueda.Equals("COMPLETO ID CLIENTE"))
                {
                    consulta.Append("WHERE lec.Id_cliente = '" + texto_busqueda + "' ");
                }
                else if (tipo_busqueda.Equals("COMPLETO ID MEDIDOR"))
                {
                    consulta.Append("WHERE lec.Id_medidor = '" + texto_busqueda + "' ");
                }
                else if (tipo_busqueda.Equals("COMPLETO ID DIRECCION"))
                {
                    consulta.Append("WHERE med.Id_direccion = '" + texto_busqueda + "' ");
                }
                else if (tipo_busqueda.Equals("ID CUENTA"))
                {
                    consulta.Append("WHERE lec.Id_cuenta = '" + texto_busqueda + "' ");
                }
                else if (tipo_busqueda.Equals("LECTURA ANTERIOR ID CLIENTE"))
                {
                    consulta.Append("WHERE lec.Id_cliente = '" + texto_busqueda + "' ");
                }
                else if (tipo_busqueda.Equals("LECTURA ANTERIOR ID MEDIDOR"))
                {
                    consulta.Append("WHERE lec.Id_medidor = '" + texto_busqueda + "' ");
                }
                else if (tipo_busqueda.Equals("LECTURA MES"))
                {
                    consulta.Append("WHERE lec.Mes_lectura = '" + texto_busqueda + "' ");
                }
                else if (tipo_busqueda.Equals("ID LECTURA"))
                {
                    consulta.Append("WHERE lec.Id_lectura = '" + texto_busqueda + "' ");
                }
                consulta.Append("ORDER BY lec.Id_lectura DESC");
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
