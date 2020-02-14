using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;

namespace CapaEntidades
{
    public class ECierre
    {
        public ECierre()
        {

        }

        public ECierre(DataRow row)
        {
            try
            {
                this.Id_cierre = Convert.ToInt32(row["Id_cierre"]);

                this.EEmpleado = new EEmpleado
                {
                    Id_empleado = Convert.ToInt32(row["Id_empleado"]),
                    Nombre_completo = Convert.ToString(row["Nombre_completo"]),
                    Tipo_empleado = Convert.ToString(row["Tipo_empleado"]),
                    Celular = Convert.ToString(row["Celular"]),
                    Correo_electronico = Convert.ToString(row["Correo_electronico"]),
                    Permisos = Convert.ToString(row["Permisos"]),
                    Clave = Convert.ToString(row["Clave"])
                };

                this.EApertura = new EApertura 
                {
                    Id_apertura = Convert.ToInt32(row["Id_empleado"]),
                    EEmpleado = this.EEmpleado,
                    ECaja = new ECaja
                    {
                        Id_caja = Convert.ToInt32(row["Id_caja"]),
                        Nombre_caja = Convert.ToString(row["Nombre_caja"]),
                        Estado_caja = Convert.ToString(row["Estado_caja"])
                    }
                };

                this.Fecha_cierre = Convert.ToDateTime(row["Fecha_cierre"]);
                this.Hora_cierre = Convert.ToString(row["Hora_cierre"]);
                this.Deposito = Convert.ToDecimal(row["Deposito"]);
                this.Observaciones = Convert.ToString(row["Observaciones"]);

            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public ECierre(DataTable dt, int fila)
        {
            try
            {

                this.Id_cierre = Convert.ToInt32(dt.Rows[fila]["Id_cierre"]);

                this.EEmpleado = new EEmpleado
                {
                    Id_empleado = Convert.ToInt32(dt.Rows[fila]["Id_empleado"]),
                    Nombre_completo = Convert.ToString(dt.Rows[fila]["Nombre_completo"]),
                    Tipo_empleado = Convert.ToString(dt.Rows[fila]["Tipo_empleado"]),
                    Celular = Convert.ToString(dt.Rows[fila]["Celular"]),
                    Correo_electronico = Convert.ToString(dt.Rows[fila]["Correo_electronico"]),
                    Permisos = Convert.ToString(dt.Rows[fila]["Permisos"]),
                    Clave = Convert.ToString(dt.Rows[fila]["Clave"])
                };

                this.EApertura = new EApertura
                {
                    Id_apertura = Convert.ToInt32(dt.Rows[fila]["Id_empleado"]),
                    EEmpleado = this.EEmpleado,
                    ECaja = new ECaja
                    {
                        Id_caja = Convert.ToInt32(dt.Rows[fila]["Id_caja"]),
                        Nombre_caja = Convert.ToString(dt.Rows[fila]["Nombre_caja"]),
                        Estado_caja = Convert.ToString(dt.Rows[fila]["Estado_caja"])
                    }
                };

                this.Fecha_cierre = Convert.ToDateTime(dt.Rows[fila]["Fecha_cierre"]);
                this.Hora_cierre = Convert.ToString(dt.Rows[fila]["Hora_cierre"]);
                this.Deposito = Convert.ToDecimal(dt.Rows[fila]["Deposito"]);
                this.Observaciones = Convert.ToString(dt.Rows[fila]["Observaciones"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public static string InsertarCierre(ECierre eCierre)
        {
            List<string> vs = new List<string>
            {
                eCierre.EEmpleado.Id_empleado.ToString(),
                eCierre.EApertura.Id_apertura.ToString(),
                eCierre.Fecha_cierre.ToString("yyyy-MM-dd"), eCierre.Hora_cierre,
                eCierre.Deposito.ToString("N2"), eCierre.Observaciones
            };

            return DCierreCaja.InsertarCierreCaja(vs);
        }

        public static DataTable BuscarCierres(string tipo_busqueda, string texto_busqueda,
                out string rpta)
        {
            return DCierreCaja.BuscarCierre(tipo_busqueda, texto_busqueda, out rpta);
        }

        public event EventHandler OnError;

        private int _id_cierre;
        private EEmpleado _eEmpleado;
        private EApertura _eApertura;
        private DateTime _fecha_cierre;
        private string _hora_cierre;
        private decimal _deposito;
        private string _observaciones;

        public int Id_cierre { get => _id_cierre; set => _id_cierre = value; }
        public EEmpleado EEmpleado { get => _eEmpleado; set => _eEmpleado = value; }
        public EApertura EApertura { get => _eApertura; set => _eApertura = value; }
        public DateTime Fecha_cierre { get => _fecha_cierre; set => _fecha_cierre = value; }
        public string Hora_cierre { get => _hora_cierre; set => _hora_cierre = value; }
        public decimal Deposito { get => _deposito; set => _deposito = value; }
        public string Observaciones { get => _observaciones; set => _observaciones = value; }
    }
}
