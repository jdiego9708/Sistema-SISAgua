using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;

namespace CapaEntidades
{
    public class ECaja
    {
        public ECaja()
        {

        }

        public ECaja(DataRow row)
        {
            try
            {
                this.Id_caja = Convert.ToInt32(row["Id_caja"]);
                this.Nombre_caja = Convert.ToString(row["Nombre_caja"]);
                this.Estado_caja = Convert.ToString(row["Estado_caja"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public ECaja(DataTable dt, int fila)
        {
            try
            {
                this.Id_caja = Convert.ToInt32(dt.Rows[fila]["Id_caja"]);
                this.Nombre_caja = Convert.ToString(dt.Rows[fila]["Nombre_caja"]);
                this.Estado_caja = Convert.ToString(dt.Rows[fila]["Estado_caja"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public static DataTable BuscarCajas(string tipo_busqueda, string texto_busqueda,
        out string rpta)
        {
            return DCajas.BuscarCajas(tipo_busqueda, texto_busqueda, out rpta);
        }

        public event EventHandler OnError;
        private int _id_caja;
        private string _nombre_caja;
        private string _estado_caja;

        public int Id_caja { get => _id_caja; set => _id_caja = value; }
        public string Nombre_caja { get => _nombre_caja; set => _nombre_caja = value; }
        public string Estado_caja { get => _estado_caja; set => _estado_caja = value; }
    }
}
