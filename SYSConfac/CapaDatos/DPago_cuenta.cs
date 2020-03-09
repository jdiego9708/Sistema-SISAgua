using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace CapaDatos
{
    public class DPago_cuenta
    {
        public DPago_cuenta() { }

        public static string InsertarPago(out int id_pago, List<string> variables)
        {
            string consulta = "INSERT INTO Pagos_cuentas (Id_cuenta, Id_caja, Fecha_pago, Hora_pago) " +
                "VALUES('" + variables[0] + "','" + variables[1] + "','" + variables[2] + "','" + variables[3] + "'); " +
                "SELECT last_insert_rowid(); " +
                "UPDATE Cuentas_cliente " +
                "SET Estado_cuenta = 'TERMINADO' " +
                "WHERE Id_cuenta = '" + variables[0] + "' ";
            string rpta = DConexion.EjecutarConsultaCadena(consulta, true);
            id_pago = DConexion.Id_autogenerado;
            return rpta;
        }

        public static string ModificarPago(int id_pago, List<string> variables)
        {
            string consulta = "UPDATE Pagos_cuentas SET " +
                "Id_cuenta ='" + variables[0] + "', " +
                "Id_caja ='" + variables[1] + "', " +
                "Fecha_pago ='" + variables[2] + "', " +
                "Hora_pago ='" + variables[3] + "' " +
                "WHERE Id_pago = '" + id_pago + "'";
            return DConexion.EjecutarConsultaCadena(consulta, false);
        }

        public static DataTable BuscarPagos(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            rpta = "OK";
            StringBuilder consulta = new StringBuilder();
            try
            {
                consulta.Append("SELECT * " +
                "FROM Pagos_cuentas pc " +
                "INNER JOIN Cuentas_cliente ccl " +
                "ON pc.Id_cuenta = ccl.Id_cuenta " +
                "INNER JOIN Clientes cl " +
                "ON ccl.Id_cliente = cl.Id_cliente " +
                "INNER JOIN Tipo_tarifas tar " +
                "ON ccl.Id_tarifa = tar.Id_tarifa " +
                "INNER JOIN Cajas ca ON pc.Id_caja = ca.Id_caja ");

                if (tipo_busqueda.Equals("COMPLETO ID CLIENTE"))
                {
                    consulta.Append("WHERE ccl.Id_cliente = '" + texto_busqueda + "' ");
                }
                else if (tipo_busqueda.Equals("ID PAGO"))
                {
                    consulta.Append("WHERE pc.Id_pago = '" + texto_busqueda + "' ");
                }
                else if (tipo_busqueda.Equals("FECHA CAJA"))
                {
                    consulta.Append("WHERE pc.Fecha_pago = '" + texto_busqueda + "' ");
                }
                else if (tipo_busqueda.Equals("ID CAJA"))
                {
                    consulta.Append("WHERE pc.Id_caja = '" + texto_busqueda + "' ");
                }
                else if (tipo_busqueda.Equals("ID CAJA FECHA"))
                {
                    consulta.Append("WHERE pc.Id_caja = '" + texto_busqueda + "' and " +
                        "pc.Fecha_pago = '" + DateTime.Now.ToString("yyyy-MM-dd") + "' ");
                }
                else if (tipo_busqueda.Equals("CONSUMO DE AGUA"))
                {
                    int mes = Convert.ToInt32(texto_busqueda);
                    int days = DateTime.DaysInMonth(DateTime.Now.Year, mes);
                    DateTime fecha1 = new DateTime(DateTime.Now.Year, mes, 01);
                    DateTime fecha2 = new DateTime(DateTime.Now.Year, mes, days);

                    consulta.Append("WHERE tar.Descripcion like 'CONSUMO DE AGUA' and " +
                        "pc.Fecha_pago between '" + fecha1.ToString("yyyy-MM-dd") + "' and '" + fecha2.ToString("yyyy-MM-dd") + "' ");
                }
                else if (tipo_busqueda.Equals("MES"))
                {
                    int mes = Convert.ToInt32(texto_busqueda);
                    int days = DateTime.DaysInMonth(DateTime.Now.Year, mes);
                    DateTime fecha1 = new DateTime(DateTime.Now.Year, mes, 01);
                    DateTime fecha2 = new DateTime(DateTime.Now.Year, mes, days);

                    consulta.Append("WHERE pc.Fecha_pago between '" + 
                        fecha1.ToString("yyyy-MM-dd") + "' and '" + fecha2.ToString("yyyy-MM-dd") + "' ");
                }
                consulta.Append("ORDER BY pc.Id_pago DESC ");
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
                return null;
            }

            return DConexion.EjecutarConsultaDt(Convert.ToString(consulta), out rpta);
        }

        private static string MonthName(int month)
        {
            DateTimeFormatInfo dtinfo = new CultureInfo("es-ES", false).DateTimeFormat;
            return dtinfo.GetMonthName(month);
        }

        public static DataTable BuscarReportes(string tipo_busqueda,
            string texto_busqueda1, string texto_busqueda2, string texto_busqueda3, out string rpta)
        {
            rpta = "OK";
            StringBuilder consulta = new StringBuilder();
            try
            {
                consulta.Append("SELECT * " +
                "FROM Pagos_cuentas pc " +
                "INNER JOIN Cuentas_cliente ccl " +
                "ON pc.Id_cuenta = ccl.Id_cuenta " +
                "INNER JOIN Clientes cl " +
                "ON ccl.Id_cliente = cl.Id_cliente " +
                "INNER JOIN Medidores med " +
                "ON ccl.Id_medidor = med.Id_medidor " +
                "INNER JOIN Tipo_tarifas tar " +
                "ON ccl.Id_tarifa = tar.Id_tarifa ");

                if (tipo_busqueda.Equals("PAGOS CLIENTE FECHA"))
                {
                    consulta.Append("WHERE ccl.Id_cliente = '" + texto_busqueda1 + "' and " +
                        "pc.Fecha_pago between '" + texto_busqueda2 + "' and " +
                        "'" + texto_busqueda3 + "' ");
                }
                else if (tipo_busqueda.Equals("PAGOS TARIFA FECHA"))
                {
                    consulta.Append("WHERE ccl.Id_tarifa = '" + texto_busqueda1 + "' and " +
                        "pc.Fecha_pago between '" + texto_busqueda2 + "' and " +
                        "'" + texto_busqueda3 + "' ");
                }
                else if (tipo_busqueda.Equals("TODO FECHA"))
                {
                    consulta.Append("WHERE pc.Fecha_pago between '" + texto_busqueda2 + "' and " +
                        "'" + texto_busqueda3 + "' ");
                }
                consulta.Append("ORDER BY pc.Id_pago DESC");
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
