using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;

namespace CapaEntidades
{
    public class EGastos
    {
        public EGastos()
        {

        }

        public EGastos(DataRow row)
        {
            try
            {
                this.Id_gasto = Convert.ToInt32(row["Id_gasto"]);
                this.Titulo_gasto = Convert.ToString(row["Titulo_gasto"]);
                this.Descripcion_gasto = Convert.ToString(row["Descripcion_gasto"]);
                this.Estado_gasto = Convert.ToString(row["Estado_gasto"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public EGastos(DataTable dt, int fila)
        {
            try
            {
                this.Id_gasto = Convert.ToInt32(dt.Rows[fila]["Id_gasto"]);
                this.Titulo_gasto = Convert.ToString(dt.Rows[fila]["Titulo_gasto"]);
                this.Descripcion_gasto = Convert.ToString(dt.Rows[fila]["Descripcion_gasto"]);
                this.Estado_gasto = Convert.ToString(dt.Rows[fila]["Estado_gasto"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public static string InsertarGasto(EGastos eGasto)
        {
            List<string> vs = new List<string>
            {
                eGasto.Titulo_gasto, eGasto.Descripcion_gasto, eGasto.Estado_gasto
            };
            return DGastos.InsertarGasto(vs);
        }

        public static string EditarGasto(EGastos eGasto, int id_gasto)
        {
            List<string> vs = new List<string>
            {
                eGasto.Titulo_gasto, eGasto.Descripcion_gasto, eGasto.Estado_gasto
            };
            return DGastos.ModificarGasto(id_gasto, vs);
        }

        public static DataTable BuscarGastos(string tipo_busqueda, string texto_busqueda,
        out string rpta)
        {
            return DGastos.BuscarGastos(tipo_busqueda, texto_busqueda, out rpta);
        }

        public event EventHandler OnError;
        private int _id_gasto;
        private string _titulo_gasto;
        private string _descripcion_gasto;
        private string _estado_gasto;

        public int Id_gasto { get => _id_gasto; set => _id_gasto = value; }
        public string Titulo_gasto { get => _titulo_gasto; set => _titulo_gasto = value; }
        public string Descripcion_gasto { get => _descripcion_gasto; set => _descripcion_gasto = value; }
        public string Estado_gasto { get => _estado_gasto; set => _estado_gasto = value; }
    }
}
