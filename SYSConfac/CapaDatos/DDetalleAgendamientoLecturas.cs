using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DDetalleAgendamientoLecturas
    {
        public DDetalleAgendamientoLecturas() { }

        public static string InsertarDetalleAgendamientoLectura(string consulta)
        {
            return DConexion.EjecutarConsultaCadena(consulta, false);
        }

        public static string EditarDetalleAgendamientoLectura(string consulta)
        {
            return DConexion.EjecutarConsultaCadena(consulta, false);
        }

        public static string InsertarDetalleAgendamientoLectura(List<string> variables)
        {
            string consulta = "INSERT INTO Detalle_agendamiento_lecturas (Id_agendamiento_lectura, Id_cliente, Id_medidor, Estado, Mes_lectura) " +
                "VALUES('" + variables[0] + "','" + variables[1] + "','" + variables[2] + "','" + variables[3] + "','" + variables[4] + "') ";
            return DConexion.EjecutarConsultaCadena(consulta, false);
        }

        public static DataTable BuscarDetalleAgendamientoLectura(string tipo_busqueda, int id_agendamiento,
            int id_cliente, int id_medidor, string mes, out string rpta)
        {
            rpta = "OK";
            StringBuilder consulta = new StringBuilder();
            try
            {
                consulta.Append("SELECT * FROM Detalle_agendamiento_lecturas dal " +
                    "INNER JOIN Agendamiento_lecturas al ON dal.Id_agendamiento_lectura = al.Id_agendamiento_lectura " +
                    "INNER JOIN Clientes cl ON dal.Id_cliente = cl.Id_cliente " +
                    "INNER JOIN Medidores med ON dal.Id_medidor = med.Id_medidor " +
                    "INNER JOIN Direccion_clientes dcl ON med.Id_direccion = dcl.Id_direccion " +
                    "INNER JOIN Barrios bar ON dcl.Id_barrio = bar.Id_barrio " +
                    "INNER JOIN Parroquias par ON bar.Id_parroquia = par.Id_parroquia " +
                    "INNER JOIN Cantones can ON par.Id_canton = can.Id_canton ");

                if (tipo_busqueda.Equals("SINCRONIZACION"))
                {
                    consulta.Append("WHERE dal.Id_agendamiento_lectura = '" + id_agendamiento + "' and " +
                        "dal.Id_cliente = '" + id_cliente + "' and dal.Id_medidor = '" + id_medidor + "' and " +
                        "dal.Mes_lectura like '" + mes + "' ");
                }
                else if (tipo_busqueda.Equals("ID AGENDAMIENTO"))
                {
                    consulta.Append("WHERE dal.Id_agendamiento_lectura = '" + id_agendamiento + "' ");
                }
                else if (tipo_busqueda.Equals("ID AGENDAMIENTO PENDIENTE"))
                {
                    consulta.Append("WHERE dal.Id_agendamiento_lectura = '" + id_agendamiento + "' and dal.Estado = 'PENDIENTE' ");
                }
                else if (tipo_busqueda.Equals("MES"))
                {
                    consulta.Append("WHERE dal.Mes_lectura = '" + mes + "' ");
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
