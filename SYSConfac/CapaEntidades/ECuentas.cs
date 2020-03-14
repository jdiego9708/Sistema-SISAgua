using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaEntidades
{
    public class ECuentas
    {
        public ECuentas()
        {

        }

        public ECuentas(DataRow row)
        {
            try
            {
                this.Id_cuenta = Convert.ToInt32(row["Id_cuenta"]);
                this.ECliente = new ECliente(Convert.ToInt32(row["Id_cliente"]));
                this.ETarifa = new ETarifas(Convert.ToInt32(row["Id_tarifa"]));
                this.EMedidor = new EMedidor(Convert.ToInt32(row["Id_medidor"]));
                this.Fecha_cuenta = Convert.ToDateTime(row["Fecha_cuenta"]);
                this.Estado_cuenta = Convert.ToString(row["Estado_cuenta"]);
                this.Iva = Convert.ToDecimal(row["IVA"]);
                this.Descuento = Convert.ToDecimal(row["Descuento"]);
                this.Motivo_descuento = Convert.ToString(row["Motivo_descuento"]);
                this.Total_pagar = Convert.ToDecimal(row["Total_pagar"]);
                this.Fecha_pago = Convert.ToDateTime(row["Fecha_pago"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public ECuentas(DataTable dt, int fila)
        {
            try
            {
                this.Id_cuenta = Convert.ToInt32(dt.Rows[fila]["Id_cuenta"]);
                this.ECliente = new ECliente(Convert.ToInt32(dt.Rows[fila]["Id_cliente"]));
                this.ETarifa = new ETarifas(Convert.ToInt32(dt.Rows[fila]["Id_tarifa"]));
                this.EMedidor = new EMedidor(Convert.ToInt32(dt.Rows[fila]["Id_medidor"]));
                this.Fecha_cuenta = Convert.ToDateTime(dt.Rows[fila]["Fecha_cuenta"]);
                this.Estado_cuenta = Convert.ToString(dt.Rows[fila]["Estado_cuenta"]);
                this.Iva = Convert.ToDecimal(dt.Rows[fila]["IVA"]);
                this.Descuento = Convert.ToDecimal(dt.Rows[fila]["Descuento"]);
                this.Motivo_descuento = Convert.ToString(dt.Rows[fila]["Motivo_descuento"]);
                this.Total_pagar = Convert.ToDecimal(dt.Rows[fila]["Total_pagar"]);
                this.Fecha_pago = Convert.ToDateTime(dt.Rows[fila]["Fecha_pago"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public ECuentas(int id_cuenta)
        {
            try
            {
                DataTable dt =
                    DCuentas.BuscarCuentas("ID CUENTA", id_cuenta.ToString(), "", out string rpta);
                if (dt != null)
                {
                    this.Id_cuenta = Convert.ToInt32(dt.Rows[0]["Id_cuenta"]);
                    this.ECliente = new ECliente(Convert.ToInt32(dt.Rows[0]["Id_cliente"]));
                    this.ETarifa = new ETarifas(Convert.ToInt32(dt.Rows[0]["Id_tarifa"]));
                    this.EMedidor = new EMedidor(Convert.ToInt32(dt.Rows[0]["Id_medidor"]));
                    this.Fecha_cuenta = Convert.ToDateTime(dt.Rows[0]["Fecha_cuenta"]);
                    this.Estado_cuenta = Convert.ToString(dt.Rows[0]["Estado_cuenta"]);
                    this.Iva = Convert.ToDecimal(dt.Rows[0]["IVA"]);
                    this.Descuento = Convert.ToDecimal(dt.Rows[0]["Descuento"]);
                    this.Motivo_descuento = Convert.ToString(dt.Rows[0]["Motivo_descuento"]);
                    this.Total_pagar = Convert.ToDecimal(dt.Rows[0]["Total_pagar"]);
                    this.Fecha_pago = Convert.ToDateTime(dt.Rows[0]["Fecha_pago"]);
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

        public static DataTable BuscarCuentas(string tipo_busqueda, string texto_busqueda1, string texto_busqueda2,
            out string rpta)
        {
            return DCuentas.BuscarCuentas(tipo_busqueda, texto_busqueda1, texto_busqueda2, out rpta);
        }

        public static string InsertarCuenta(ECuentas cuenta, out int id_cuenta)
        {
            List<string> vs = new List<string>
            {
                cuenta.ECliente.Id_cliente.ToString(), cuenta.ETarifa.Id_tarifa.ToString(),
                cuenta.EMedidor.Id_medidor.ToString(),
                cuenta.Fecha_cuenta.ToString("yyyy-MM-dd"),
                cuenta.Estado_cuenta, cuenta.Iva.ToString("N2").Replace(",","."),
                cuenta.Descuento.ToString("N2").Replace(",","."), cuenta.Motivo_descuento,
                cuenta.Total_pagar.ToString("N2").Replace(",","."),
                cuenta.Fecha_pago.ToString("yyyy-MM-dd")
            };
            return DCuentas.InsertarCuenta(out id_cuenta, vs);
        }

        public static string EditarCuenta(ECuentas cuenta, int id_cuenta)
        {
            List<string> vs = new List<string>
            {
                cuenta.ECliente.Id_cliente.ToString(), cuenta.ETarifa.Id_tarifa.ToString(),
                cuenta.EMedidor.Id_medidor.ToString(),
                cuenta.Fecha_cuenta.ToString("yyyy-MM-dd"),
                cuenta.Estado_cuenta, cuenta.Iva.ToString("N2").Replace(",","."),
                cuenta.Descuento.ToString("N2").Replace(",","."), cuenta.Motivo_descuento,
                cuenta.Total_pagar.ToString("N2").Replace(",","."),
                cuenta.Fecha_pago.ToString("yyyy-MM-dd")
            };
            return DCuentas.ModificarCuenta(id_cuenta, vs);
        }

        public event EventHandler OnError;
        private int _id_cuenta;
        private ECliente _eCliente;
        private ETarifas _eTarifa;
        private EMedidor _eMedidor;
        private DateTime _fecha_cuenta;
        private string _estado_cuenta;
        private decimal _iva;
        private decimal _descuento;
        private string _motivo_descuento;
        private decimal _total_pagar;
        private DateTime _fecha_pago;
        //Variable temporal
        private decimal _total_lectura;

        public int Id_cuenta { get => _id_cuenta; set => _id_cuenta = value; }
        public ECliente ECliente { get => _eCliente; set => _eCliente = value; }
        public ETarifas ETarifa { get => _eTarifa; set => _eTarifa = value; }
        public DateTime Fecha_cuenta { get => _fecha_cuenta; set => _fecha_cuenta = value; }
        public string Estado_cuenta { get => _estado_cuenta; set => _estado_cuenta = value; }
        public decimal Iva { get => _iva; set => _iva = value; }
        public decimal Descuento { get => _descuento; set => _descuento = value; }
        public string Motivo_descuento { get => _motivo_descuento; set => _motivo_descuento = value; }
        public decimal Total_pagar { get => _total_pagar; set => _total_pagar = value; }
        public DateTime Fecha_pago { get => _fecha_pago; set => _fecha_pago = value; }
        public EMedidor EMedidor { get => _eMedidor; set => _eMedidor = value; }
        //Variable temporal
        public decimal Total_lectura { get => _total_lectura; set => _total_lectura = value; }       
    }
}
