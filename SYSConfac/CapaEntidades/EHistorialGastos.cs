using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;

namespace CapaEntidades
{
    public class EHistorialGastos
    {
        public EHistorialGastos()
        {

        }

        public EHistorialGastos(DataRow row)
        {
            try
            {
                this.Id_historial_gasto = Convert.ToInt32(row["Id_historial_gasto"]);
                this.Fecha_gasto = Convert.ToDateTime(row["Fecha_gasto"]);
                this.Hora_gasto = Convert.ToString(row["Hora_gasto"]);
                this.Valor_gasto = Convert.ToDecimal(row["Valor_gasto"]);

                this.EGasto = new EGastos
                {
                    Id_gasto = Convert.ToInt32(row["Id_gasto"]),
                    Titulo_gasto = Convert.ToString(row["Titulo_gasto"]),
                    Descripcion_gasto = Convert.ToString(row["Descripcion_gasto"]),
                    Estado_gasto = Convert.ToString(row["Estado_gasto"])
                };

                this.EEmpleado = new EEmpleado
                {
                    Id_empleado = Convert.ToInt32(row["Id_empleado"]),
                    Nombre_completo = Convert.ToString(row["Nombre_completo"]),
                    Celular = Convert.ToString(row["Celular"]),
                    Correo_electronico = Convert.ToString(row["Correo_electronico"]),
                    Tipo_empleado = Convert.ToString(row["Tipo_empleado"])
                };
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public EHistorialGastos(DataTable dt, int fila)
        {
            try
            {
                this.Id_historial_gasto = Convert.ToInt32(dt.Rows[fila]["Id_historial_gasto"]);
                this.Fecha_gasto = Convert.ToDateTime(dt.Rows[fila]["Fecha_gasto"]);
                this.Hora_gasto = Convert.ToString(dt.Rows[fila]["Hora_gasto"]);
                this.Valor_gasto = Convert.ToDecimal(dt.Rows[fila]["Valor_gasto"]);

                this.EGasto = new EGastos
                {
                    Id_gasto = Convert.ToInt32(dt.Rows[fila]["Id_gasto"]),
                    Titulo_gasto = Convert.ToString(dt.Rows[fila]["Titulo_gasto"]),
                    Descripcion_gasto = Convert.ToString(dt.Rows[fila]["Descripcion_gasto"]),
                    Estado_gasto = Convert.ToString(dt.Rows[fila]["Estado_gasto"])
                };

                this.EEmpleado = new EEmpleado
                {
                    Id_empleado = Convert.ToInt32(dt.Rows[fila]["Id_empleado"]),
                    Nombre_completo = Convert.ToString(dt.Rows[fila]["Nombre_completo"]),
                    Celular = Convert.ToString(dt.Rows[fila]["Celular"]),
                    Correo_electronico = Convert.ToString(dt.Rows[fila]["Correo_electronico"]),
                    Tipo_empleado = Convert.ToString(dt.Rows[fila]["Tipo_empleado"])
                };
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public static string InsertarHistorialGasto(out int id_historial_gasto, EHistorialGastos eHistorialGasto)
        {
            List<string> vs = new List<string>
            {
                eHistorialGasto.Fecha_gasto.ToString("yyyy-MM-dd"),
                eHistorialGasto.Hora_gasto,
                eHistorialGasto.EGasto.Id_gasto.ToString(),
                eHistorialGasto.EEmpleado.Id_empleado.ToString(),
                eHistorialGasto.Valor_gasto.ToString("N2").Replace(",",".")
            };
            return DHistorial_gastos.InsertarHistorialGasto(out id_historial_gasto, vs);
        }

        public static string EditarHistorialGasto(EHistorialGastos eHistorialGasto, int id_historial_gasto)
        {
            List<string> vs = new List<string>
            {
                eHistorialGasto.Fecha_gasto.ToString("yyyy-MM-dd"),
                eHistorialGasto.Hora_gasto,
                eHistorialGasto.EGasto.Id_gasto.ToString(),
                eHistorialGasto.EEmpleado.Id_empleado.ToString(),
                eHistorialGasto.Valor_gasto.ToString("N2").Replace(",",".")
            };
            return DHistorial_gastos.ModificarHistorialGasto(id_historial_gasto, vs);
        }

        public static DataTable BuscarHistorialGastos(string tipo_busqueda, string texto_busqueda,
        out string rpta)
        {
            return DHistorial_gastos.BuscarHistorialGastos(tipo_busqueda, texto_busqueda, out rpta);
        }

        public event EventHandler OnError;
        private int _id_historial_gasto;
        private DateTime _fecha_gasto;
        private string _hora_gasto;
        private EGastos _eGasto;
        private EEmpleado _eEmpleado;
        private decimal _valor_gasto;

        public int Id_historial_gasto { get => _id_historial_gasto; set => _id_historial_gasto = value; }
        public DateTime Fecha_gasto { get => _fecha_gasto; set => _fecha_gasto = value; }
        public string Hora_gasto { get => _hora_gasto; set => _hora_gasto = value; }
        public EGastos EGasto { get => _eGasto; set => _eGasto = value; }
        public EEmpleado EEmpleado { get => _eEmpleado; set => _eEmpleado = value; }
        public decimal Valor_gasto { get => _valor_gasto; set => _valor_gasto = value; }
    }
}
