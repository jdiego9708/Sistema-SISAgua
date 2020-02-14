using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CapaEntidades
{
    public class EDetalleAgendamientoLectura
    {
        public EDetalleAgendamientoLectura()
        {

        }

        public EDetalleAgendamientoLectura(DataRow row)
        {
            try
            {
                this.EAgendamientoLectura = new EAgendamientoLectura
                {
                    Id_agendamiento = Convert.ToInt32(row["Id_agendamiento_lectura"]),
                    Mes_agendamiento = Convert.ToString(row["Mes_agendamiento"]),
                    Estado_agendamiento = Convert.ToString(row["Estado_agendamiento"])
                };
                this.ECliente = new ECliente
                {
                    Id_cliente = Convert.ToInt32(row["Id_cliente"]),
                    Nombres = Convert.ToString(row["Nombres"]),
                    Apellidos = Convert.ToString(row["Apellidos"]),
                    Identificacion = Convert.ToString(row["Identificacion"]),
                    Celular = Convert.ToString(row["Celular"]),
                    Correo = Convert.ToString(row["Correo_electronico"]),
                    Estado = Convert.ToString(row["Estado_cliente"])
                };
                this.EMedidor = new EMedidor
                {
                    Id_medidor = Convert.ToInt32(row["Id_medidor"]),
                    DireccionCliente = new EDireccionCliente(row),
                    Medidor = Convert.ToString(row["Medidor"]),
                    Descripcion = Convert.ToString(row["Descripcion"]),
                    Estado_medidor = Convert.ToString(row["Estado_medidor"])
                };
                this.Estado = Convert.ToString(row["Estado"]);
                this.Mes_lectura = Convert.ToString(row["Mes_lectura"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public EDetalleAgendamientoLectura(DataTable dt, int fila)
        {
            try
            {
                this.EAgendamientoLectura = new EAgendamientoLectura
                {
                    Id_agendamiento = Convert.ToInt32(dt.Rows[fila]["Id_agendamiento_lectura"]),
                    Mes_agendamiento = Convert.ToString(dt.Rows[fila]["Mes_agendamiento"]),
                    Estado_agendamiento = Convert.ToString(dt.Rows[fila]["Estado_agendamiento"])
                };
                this.ECliente = new ECliente
                {
                    Id_cliente = Convert.ToInt32(dt.Rows[fila]["Id_cliente"]),
                    Nombres = Convert.ToString(dt.Rows[fila]["Nombres"]),
                    Apellidos = Convert.ToString(dt.Rows[fila]["Apellidos"]),
                    Identificacion = Convert.ToString(dt.Rows[fila]["Identificacion"]),
                    Celular = Convert.ToString(dt.Rows[fila]["Celular"]),
                    Correo = Convert.ToString(dt.Rows[fila]["Correo_electronico"]),
                    Estado = Convert.ToString(dt.Rows[fila]["Estado_cliente"])
                };
                this.EMedidor = new EMedidor
                {
                    Id_medidor = Convert.ToInt32(dt.Rows[fila]["Id_medidor"]),
                    DireccionCliente = new EDireccionCliente(dt.Rows[fila]),
                    Medidor = Convert.ToString(dt.Rows[fila]["Medidor"]),
                    Descripcion = Convert.ToString(dt.Rows[fila]["Descripcion"]),
                    Estado_medidor = Convert.ToString(dt.Rows[fila]["Estado_medidor"])
                };
                this.Estado = Convert.ToString(dt.Rows[fila]["Estado"]);
                this.Mes_lectura = Convert.ToString(dt.Rows[fila]["Mes_lectura"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public static DataTable BuscarDetalleAgendamiento(string tipo_busqueda, int id_agendamiento,
            int id_cliente, int id_medidor, string mes, out string rpta)
        {
            return DDetalleAgendamientoLecturas.BuscarDetalleAgendamientoLectura(tipo_busqueda, id_agendamiento,
                id_cliente, id_medidor, mes, out rpta);
        }

        public static string InsertarDetalleAgendamiento(EDetalleAgendamientoLectura agendamiento)
        {
            List<string> vs = new List<string>
            {
                agendamiento.EAgendamientoLectura.Id_agendamiento.ToString(),
                agendamiento.ECliente.Id_cliente.ToString(),
                agendamiento.EMedidor.Id_medidor.ToString(),
                agendamiento.Estado, agendamiento.Mes_lectura
            };
            return DDetalleAgendamientoLecturas.InsertarDetalleAgendamientoLectura(vs);
        }

        public static string InsertarDetalleAgendamiento(List<EDetalleAgendamientoLectura> agendamientos)
        {
            StringBuilder consultaCompleta = new StringBuilder();

            foreach (EDetalleAgendamientoLectura eAgendamiento in agendamientos)
            {
                string consulta = "INSERT INTO Detalle_agendamiento_lecturas " +
                "(Id_agendamiento_lectura, Id_cliente, Id_medidor, Estado, Mes_lectura) " +
                "VALUES('" + eAgendamiento.EAgendamientoLectura.Id_agendamiento + "','" +
                eAgendamiento.ECliente.Id_cliente + "','" +
                eAgendamiento.EMedidor.Id_medidor + "','" +
                eAgendamiento.Estado + "','" +
                eAgendamiento.Mes_lectura + "'); ";
                consultaCompleta.Append(consulta);
            }

            return DConexion.EjecutarConsultaCadena(Convert.ToString(consultaCompleta), false);
        }

        public static string EditarDetalleAgendamiento(List<EDetalleAgendamientoLectura> agendamientos)
        {
            StringBuilder consultaCompleta = new StringBuilder();

            string mes = "";
            foreach (EDetalleAgendamientoLectura eAgendamiento in agendamientos)
            {
                mes = eAgendamiento.Mes_lectura;
                //Actualizar cada eAgendamiento que encontramos
                string consulta =
                    string.Format("UPDATE Detalle_agendamiento_lecturas " +
                                  "SET " +
                                  "Estado = '{0}' " +
                                  "WHERE Id_agendamiento_lectura = {1} and " +
                                  "Id_cliente = {2} and " +
                                  "Id_medidor = {3}; ",
                                  new object[] { "TERMINADO",
                                      eAgendamiento.EAgendamientoLectura.Id_agendamiento,
                                      eAgendamiento.ECliente.Id_cliente,
                                      eAgendamiento.EMedidor.Id_medidor});
                consultaCompleta.Append(consulta);
            }
            consultaCompleta.Append(string.Format("DELETE FROM Detalle_agendamiento_lecturas " +
                "WHERE ROWID not in " +
                "(SELECT MIN (ROWID) FROM Detalle_agendamiento_lecturas " +
                "WHERE Mes_lectura = '{0}' GROUP BY Id_medidor) " +
                "AND Mes_lectura = '{0}'; ", mes));

            return DConexion.EjecutarConsultaCadena(Convert.ToString(consultaCompleta), false);
        }

        public static DataTable BuscarDetalleAgendamiento(out string rpta)
        {
            StringBuilder consulta = new StringBuilder();

            consulta.Append("SELECT *, COUNT(*) as CantidadCuentas, SUM(Total_pagar) as TotalDeuda " +
                "FROM Cuentas_cliente ccl " +
                "INNER JOIN Clientes cl ON ccl.Id_cliente = cl.Id_cliente " +
                "INNER JOIN Tipo_tarifas tar ON ccl.Id_tarifa = tar.Id_tarifa " +
                "INNER JOIN Detalle_tipo_tarifa dtar ON tar.Id_tarifa = dtar.Id_tarifa " +
                "INNER JOIN Medidores med ON ccl.Id_medidor = med.Id_medidor " +
                "WHERE ccl.Estado_cuenta = 'PENDIENTE DE PAGO' " +
                "GROUP BY ccl.Id_medidor, ccl.Id_cliente");

            return DConexion.EjecutarConsultaDt(Convert.ToString(consulta), out rpta);
        }

        private EAgendamientoLectura _eAgendamientoLectura;
        private ECliente _eCliente;
        private EMedidor _eMedidor;
        private string _estado;
        private string _mes_lectura;

        public EAgendamientoLectura EAgendamientoLectura { get => _eAgendamientoLectura; set => _eAgendamientoLectura = value; }
        public ECliente ECliente { get => _eCliente; set => _eCliente = value; }
        public EMedidor EMedidor { get => _eMedidor; set => _eMedidor = value; }
        public string Estado { get => _estado; set => _estado = value; }
        public string Mes_lectura { get => _mes_lectura; set => _mes_lectura = value; }

        public event EventHandler OnError;
    }
}
