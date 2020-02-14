using System;
using System.Collections.Generic;
using System.Data;

using CapaDatos;

namespace CapaEntidades
{
    public class EApertura
    {
        public EApertura()
        {

        }

        public EApertura(DataRow row)
        {
            try
            {
                this.Id_apertura = Convert.ToInt32(row["Id_apertura"]);

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

                this.ECaja = new ECaja
                {
                    Id_caja = Convert.ToInt32(row["Id_caja"]),
                    Nombre_caja = Convert.ToString(row["Nombre_caja"]),
                    Estado_caja = Convert.ToString(row["Estado_caja"])
                };

                this.Fecha = Convert.ToDateTime(row["Fecha_apertura"]);
                this.Hora = Convert.ToString(row["Hora_apertura"]);
                this.Valor_inicial = Convert.ToDecimal(row["Valor_inicial"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public EApertura(DataTable dt, int fila)
        {
            try
            {
                this.Id_apertura = Convert.ToInt32(dt.Rows[fila]["Id_apertura"]);

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

                this.ECaja = new ECaja
                {
                    Id_caja = Convert.ToInt32(dt.Rows[fila]["Id_caja"]),
                    Nombre_caja = Convert.ToString(dt.Rows[fila]["Nombre_caja"]),
                    Estado_caja = Convert.ToString(dt.Rows[fila]["Estado_caja"])
                };

                this.Fecha = Convert.ToDateTime(dt.Rows[fila]["Fecha_apertura"]);
                this.Hora = Convert.ToString(dt.Rows[fila]["Hora_apertura"]);
                this.Valor_inicial = Convert.ToDecimal(dt.Rows[fila]["Valor_inicial"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public static string InsertarApertura(EApertura eApertura)
        {
            List<string> vs = new List<string>
            {
                eApertura.EEmpleado.Id_empleado.ToString(),
                eApertura.ECaja.Id_caja.ToString(),
                eApertura.Fecha.ToString("yyyy-MM-dd"),
                Convert.ToDateTime(eApertura.Hora).ToString("HH:mm"),
                eApertura.Valor_inicial.ToString("N2")
            };

            return DAperturaCajas.InsertarAperturaCaja(vs);
        }

        public static DataTable BuscarAperturas(string tipo_busqueda, string texto_busqueda,
                out string rpta)
        {
            return DAperturaCajas.BuscarAperturaCajas(tipo_busqueda, texto_busqueda, out rpta);
        }

        public event EventHandler OnError;

        private int _id_apertura;
        private EEmpleado _eEmpleado;
        private ECaja _eCaja;
        private DateTime _fecha;
        private string _hora;
        private decimal _valor_inicial;

        public int Id_apertura { get => _id_apertura; set => _id_apertura = value; }
        public EEmpleado EEmpleado { get => _eEmpleado; set => _eEmpleado = value; }
        public ECaja ECaja { get => _eCaja; set => _eCaja = value; }
        public DateTime Fecha { get => _fecha; set => _fecha = value; }
        public string Hora { get => _hora; set => _hora = value; }
        public decimal Valor_inicial { get => _valor_inicial; set => _valor_inicial = value; }
    }
}
