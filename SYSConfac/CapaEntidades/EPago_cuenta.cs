using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class EPago_cuenta
    {
        public EPago_cuenta()
        {

        }

        public EPago_cuenta(DataRow row)
        {
            try
            {
                this.Id_pago = Convert.ToInt32(row["Id_pago"]);
                this.ECuenta = new ECuentas(Convert.ToInt32(row["Id_cuenta"]));
                this.ECaja = new ECaja
                {
                    Id_caja = Convert.ToInt32(row["Id_caja"]),
                    Nombre_caja = Convert.ToString(row["Nombre_caja"]),
                    Estado_caja = Convert.ToString(row["Estado_caja"])
                };
                this.Fecha_pago = Convert.ToDateTime(row["Fecha_pago"]);
                this.Hora_pago = Convert.ToString(row["Hora_pago"]);
                this.Observaciones_pago = Convert.ToString(row["Observaciones_pago"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public EPago_cuenta(DataTable dt, int fila)
        {
            try
            {
                this.Id_pago = Convert.ToInt32(dt.Rows[fila]["Id_pago"]);
                this.ECuenta = new ECuentas(Convert.ToInt32(dt.Rows[fila]["Id_cuenta"]));
                this.ECaja = new ECaja
                {
                    Id_caja = Convert.ToInt32(dt.Rows[fila]["Id_caja"]),
                    Nombre_caja = Convert.ToString(dt.Rows[fila]["Nombre_caja"]),
                    Estado_caja = Convert.ToString(dt.Rows[fila]["Estado_caja"])
                };
                this.Fecha_pago = Convert.ToDateTime(dt.Rows[fila]["Fecha_pago"]);
                this.Hora_pago = Convert.ToString(dt.Rows[fila]["Hora_pago"]);
                this.Observaciones_pago = Convert.ToString(dt.Rows[fila]["Observaciones_pago"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public EPago_cuenta(int id_pago)
        {
            try
            {
                DataTable dt =
                    DPago_cuenta.BuscarPagos("ID PAGO", id_pago.ToString(), out string rpta);
                if (dt != null)
                {
                    this.Id_pago = Convert.ToInt32(dt.Rows[0]["Id_pago"]);
                    this.ECuenta = new ECuentas(Convert.ToInt32(dt.Rows[0]["Id_cuenta"]));
                    this.ECaja = new ECaja
                    {
                        Id_caja = Convert.ToInt32(dt.Rows[0]["Id_caja"]),
                        Nombre_caja = Convert.ToString(dt.Rows[0]["Nombre_caja"]),
                        Estado_caja = Convert.ToString(dt.Rows[0]["Estado_caja"])
                    };
                    this.Fecha_pago = Convert.ToDateTime(dt.Rows[0]["Fecha_pago"]);
                    this.Hora_pago = Convert.ToString(dt.Rows[0]["Hora_pago"]);
                    this.Observaciones_pago = Convert.ToString(dt.Rows[0]["Observaciones_pago"]);
                }
                else
                {
                    if (!rpta.Equals("OK"))
                        throw new Exception(rpta);
                }
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public static string InsertarPagoCuenta(EPago_cuenta pagoCuenta, out int id_pago)
        {
            List<string> vs = new List<string>
            {
                pagoCuenta.ECuenta.Id_cuenta.ToString(), pagoCuenta.ECaja.Id_caja.ToString(),
                pagoCuenta.Fecha_pago.ToString("yyyy-MM-dd"),
                pagoCuenta.Hora_pago, pagoCuenta.Observaciones_pago

            };
            return DPago_cuenta.InsertarPago(out id_pago, vs);
        }

        public static string EditarPagoCuenta(EPago_cuenta pagoCuenta, int id_pago)
        {
            List<string> vs = new List<string>
            {
                pagoCuenta.ECuenta.Id_cuenta.ToString(), pagoCuenta.ECaja.Id_caja.ToString(),
                pagoCuenta.Fecha_pago.ToString("yyyy-MM-dd"),
                pagoCuenta.Hora_pago, pagoCuenta.Observaciones_pago

            };
            return DPago_cuenta.ModificarPago(id_pago, vs);
        }

        public static DataTable BuscarPagoCuentas(string tipo_busqueda, string texto_busqueda,
                    out string rpta)
        {
            return DPago_cuenta.BuscarPagos(tipo_busqueda, texto_busqueda, out rpta);
        }

        public static DataTable BuscarReportes(string tipo_busqueda, string texto_busqueda1,
            string texto_busqueda2, string texto_busqueda3,
            out string rpta)
        {
            return DPago_cuenta.BuscarReportes(tipo_busqueda, texto_busqueda1,
                texto_busqueda2, texto_busqueda3, out rpta);
        }

        public event EventHandler OnError;
        private int _id_pago;
        private ECuentas _eCuenta;
        private DateTime _fecha_pago;
        private string _hora_pago;
        private string _observaciones_pago;
        private ECaja _eCaja;

        public int Id_pago { get => _id_pago; set => _id_pago = value; }
        public ECuentas ECuenta { get => _eCuenta; set => _eCuenta = value; }
        public DateTime Fecha_pago { get => _fecha_pago; set => _fecha_pago = value; }
        public string Hora_pago { get => _hora_pago; set => _hora_pago = value; }
        public string Observaciones_pago { get => _observaciones_pago; set => _observaciones_pago = value; }
        public ECaja ECaja { get => _eCaja; set => _eCaja = value; }
    }
}
