using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;

namespace CapaEntidades
{
    public class EDetalleAbonosCuentas
    {
        public EDetalleAbonosCuentas()
        {

        }

        public EDetalleAbonosCuentas(DataRow row)
        {
            try
            {
                this.Id_abono = Convert.ToInt32(row["Id_abono"]);
                this.ECuenta = new ECuentas(Convert.ToInt32(row["Id_cuenta"]));
                this.Fecha_abono = Convert.ToDateTime(row["Fecha_abono"]);
                this.Hora_abono = Convert.ToString(row["Hora_abono"]);
                this.Valor_abono = Convert.ToDecimal(row["Valor_abono"]);
                this.Valor_restante = Convert.ToDecimal(row["Valor_restante"]);
                this.Observaciones = Convert.ToString(row["Observaciones"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public EDetalleAbonosCuentas(DataTable dt, int fila)
        {
            try
            {
                this.Id_abono = Convert.ToInt32(dt.Rows[fila]["Id_abono"]);
                this.ECuenta = new ECuentas(Convert.ToInt32(dt.Rows[fila]["Id_cuenta"]));
                this.Fecha_abono = Convert.ToDateTime(dt.Rows[fila]["Fecha_abono"]);
                this.Hora_abono = Convert.ToString(dt.Rows[fila]["Hora_abono"]);
                this.Valor_abono = Convert.ToDecimal(dt.Rows[fila]["Valor_abono"]);
                this.Valor_restante = Convert.ToDecimal(dt.Rows[fila]["Valor_restante"]);
                this.Observaciones = Convert.ToString(dt.Rows[fila]["Observaciones"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public EDetalleAbonosCuentas(int id_abono)
        {
            try
            {
                DataTable dt = EDetalleAbonosCuentas.BuscarAbonos("ID ABONO", id_abono.ToString(), out string rpta);
                if (dt != null)
                {
                    this.Id_abono = Convert.ToInt32(dt.Rows[0]["Id_abono"]);
                    this.ECuenta = new ECuentas(Convert.ToInt32(dt.Rows[0]["Id_cuenta"]));
                    this.Fecha_abono = Convert.ToDateTime(dt.Rows[0]["Fecha_abono"]);
                    this.Hora_abono = Convert.ToString(dt.Rows[0]["Hora_abono"]);
                    this.Valor_abono = Convert.ToDecimal(dt.Rows[0]["Valor_abono"]);
                    this.Valor_restante = Convert.ToDecimal(dt.Rows[0]["Valor_restante"]);
                    this.Observaciones = Convert.ToString(dt.Rows[0]["Observaciones"]);
                }
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public static DataTable BuscarAbonos(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            return DDetalleAbonosCuentas.BuscarAbonos(tipo_busqueda, texto_busqueda, out rpta);
        }

        public static string EditarAbono(EDetalleAbonosCuentas abono, int id_abono)
        {
            List<string> vs = new List<string>
            {
                abono.ECuenta.Id_cuenta.ToString(), abono.Fecha_abono.ToString("yyyy-MM-dd"),
                abono.Hora_abono, abono.Valor_abono.ToString("N2").Replace(",","."), abono.Valor_restante.ToString("N2").Replace(",","."),
                abono.Observaciones
            };
            return DDetalleAbonosCuentas.ModificarAbono(id_abono, vs);
        }

        public static string InsertarAbono(EDetalleAbonosCuentas abono, out int id_abono)
        {
            List<string> vs = new List<string>
            {
                abono.ECuenta.Id_cuenta.ToString(), abono.Fecha_abono.ToString("yyyy-MM-dd"),
                abono.Hora_abono, abono.Valor_abono.ToString("N2"), abono.Valor_restante.ToString("N2"),
                abono.Observaciones
            };
            return DDetalleAbonosCuentas.InsertarAbono(out id_abono, vs);
        }

        public event EventHandler OnError;
        private int _id_abono;
        private ECuentas _eCuenta;
        private DateTime _fecha_abono;
        private string _hora_abono;
        private decimal _valor_abono;
        private decimal _valor_restante;
        private string _observaciones;

        public int Id_abono { get => _id_abono; set => _id_abono = value; }
        public ECuentas ECuenta { get => _eCuenta; set => _eCuenta = value; }
        public DateTime Fecha_abono { get => _fecha_abono; set => _fecha_abono = value; }
        public string Hora_abono { get => _hora_abono; set => _hora_abono = value; }
        public decimal Valor_abono { get => _valor_abono; set => _valor_abono = value; }
        public decimal Valor_restante { get => _valor_restante; set => _valor_restante = value; }
        public string Observaciones { get => _observaciones; set => _observaciones = value; }
    }
}
