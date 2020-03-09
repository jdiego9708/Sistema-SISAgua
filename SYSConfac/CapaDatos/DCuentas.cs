using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DCuentas
    {
        public DCuentas() { }

        public static string InsertarCuenta(out int id_cuenta, List<string> variables)
        {
            string consulta = "INSERT INTO Cuentas_cliente (Id_cliente, Id_tarifa, Id_medidor, Fecha_cuenta, Estado_cuenta, IVA, Descuento, Motivo_descuento, " +
                "Total_pagar, Fecha_pago) " +
                "VALUES('" + variables[0] + "','" + variables[1] + "','" + variables[2] + "','" + variables[3] + "','" + variables[4] + "','" +
                variables[5] + "','" + variables[6] + "','" + variables[7] + "','" + variables[8] + "','" + variables[9] + "'); " +
                "SELECT last_insert_rowid() ";
            string rpta = DConexion.EjecutarConsultaCadena(consulta, true);
            id_cuenta = DConexion.Id_autogenerado;
            return rpta;
        }

        public static string ModificarCuenta(int id_cuenta, List<string> variables)
        {
            string consulta = "UPDATE Cuentas_cliente SET " +
                "Id_cliente ='" + variables[0] + "', " +
                "Id_tarifa ='" + variables[1] + "', " +
                "Id_medidor = '" + variables[2] + "', " +
                "Fecha_cuenta ='" + variables[3] + "', " +
                "Estado_cuenta ='" + variables[4] + "', " +
                "IVA ='" + variables[5] + "', " +
                "Descuento ='" + variables[6] + "', " +
                "Motivo_descuento ='" + variables[7] + "', " +
                "Total_pagar ='" + variables[8] + "', " +
                "Fecha_pago ='" + variables[9] + "' " +
                "WHERE Id_cuenta = '" + id_cuenta + "'";
            return DConexion.EjecutarConsultaCadena(consulta, false);
        }

        public static DataTable BuscarCuentas(string tipo_busqueda, string texto_busqueda1,
            string texto_busqueda2, out string rpta)
        {
            rpta = "OK";
            StringBuilder consulta = new StringBuilder();
            try
            {
                consulta.Append("SELECT * " +
                                "FROM Cuentas_cliente ccl " +
                                "INNER JOIN Clientes cl " +
                                "ON ccl.Id_cliente = cl.Id_cliente " +
                                "INNER JOIN Tipo_tarifas tar " +
                                "ON ccl.Id_tarifa = tar.Id_tarifa " +
                                "INNER JOIN Medidores med " +
                                "ON ccl.Id_medidor = med.Id_medidor ");

                if (tipo_busqueda.Equals("COMPLETO ID CLIENTE"))
                {
                    consulta.Append("WHERE ccl.Id_cliente = '" + texto_busqueda1 + "'");
                }
                else if (tipo_busqueda.Equals("ID CLIENTE PENDIENTE DE PAGO"))
                {
                    consulta.Append("WHERE ccl.Id_cliente = '" + texto_busqueda1 + "' and " +
                        "ccl.Estado_cuenta = 'PENDIENTE DE PAGO'");
                }
                else if (tipo_busqueda.Equals("CLIENTE FECHA"))
                {
                    consulta.Append("WHERE ccl.Id_cliente = '" + texto_busqueda1 + "' and " +
                        "ccl.Fecha_cuenta = CONVERT(date, '" + texto_busqueda2 + "')");
                }
                else if (tipo_busqueda.Equals("FECHAS"))
                {
                    consulta.Append("WHERE ccl.Fecha_cuenta BETWEEN " +
                        "CONVERT(date, '" + texto_busqueda1 + "') and " +
                        "CONVERT(date, '" + texto_busqueda2 + "') and " +
                        "ccl.Estado_cuenta = 'PENDIENTE DE PAGO' ");
                }
                else if (tipo_busqueda.Equals("ID CUENTA"))
                {
                    consulta.Append("WHERE ccl.Id_cuenta = '" + texto_busqueda1 + "'");
                }
                else if (tipo_busqueda.Equals("TODO"))
                {
                    consulta.Append("WHERE ccl.Estado_cuenta = 'PENDIENTE DE PAGO' and " +
                        "cl.Identificacion like '" + texto_busqueda1 + "%' or " +
                        "cl.Celular like '" + texto_busqueda1 + "%' or " +
                        "cl.Correo_electronico like '" + texto_busqueda1 + "%' or " +
                        "med.Medidor like '" + texto_busqueda1 + "%'");
                }
                else if (tipo_busqueda.Equals("REFERENCIA DE PAGO"))
                {
                    consulta.Append("WHERE ccl.Estado_cuenta = 'PENDIENTE DE PAGO' and " +
                        "ccl.Id_cuenta = CONVERT(int, '" + texto_busqueda1 + "')");

                }
                else if (tipo_busqueda.Equals("ID CLIENTE"))
                {
                    consulta.Append("WHERE ccl.Id_cliente = '" + texto_busqueda1 + "'");

                }
                else if (tipo_busqueda.Equals("PENDIENTE DE PAGO HOY"))
                {
                    consulta.Append("WHERE ccl.Estado_cuenta = 'PENDIENTE DE PAGO' and " +
                        "ccl.Fecha_cuenta = '" + texto_busqueda1 + "' ");

                }
                else if (tipo_busqueda.Equals("IDENTIFICACION CLIENTE"))
                {
                    consulta.Append("WHERE ccl.Estado_cuenta = 'PENDIENTE DE PAGO' and " +
                        "cl.Identificacion like '" + texto_busqueda1 + "%' ");

                }
                else if (tipo_busqueda.Equals("MEDIDOR"))
                {
                    consulta.Append("WHERE ccl.Estado_cuenta = 'PENDIENTE DE PAGO' and " +
                        "med.Medidor like '" + texto_busqueda1 + "' ");

                }
                else if (tipo_busqueda.Equals("NOMBRE"))
                {
                    consulta.Append("WHERE ccl.Estado_cuenta = 'PENDIENTE DE PAGO' and " +
                        "cl.Nombres like '%" + texto_busqueda1 + "%' OR " +
                        "cl.Apellidos like '%" + texto_busqueda1 + "%' ");

                }
                else if (tipo_busqueda.Equals("PROXIMO CORTE"))
                {
                    consulta.Append("WHERE ccl.Estado_cuenta = 'PENDIENTE DE PAGO' and " +
                        "tar.Descripcion like 'CONSUMO DE AGUA' and " +
                        "med.Medidor like '" + texto_busqueda1 + "' ");
                }
                consulta.Append("ORDER BY ccl.Id_cuenta DESC");
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
