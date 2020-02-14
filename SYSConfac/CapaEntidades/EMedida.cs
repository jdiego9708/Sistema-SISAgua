using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;

namespace CapaEntidades
{
    public class EMedida
    {
        public EMedida()
        {

        }

        public EMedida(DataRow row)
        {
            try
            {
                this.Id_medida = Convert.ToInt32(row["Id_medida"]);
                this.Descripcion_medida = Convert.ToString(row["Descripcion_medida"]);
                this.Alias_medida = Convert.ToString(row["Alias_medida"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public EMedida(DataTable dt, int fila)
        {
            try
            {
                this.Id_medida = Convert.ToInt32(dt.Rows[fila]["Id_medida"]);
                this.Descripcion_medida = Convert.ToString(dt.Rows[fila]["Descripcion_medida"]);
                this.Alias_medida = Convert.ToString(dt.Rows[fila]["Alias_medida"]);

            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public static string InsertarMedida(EMedida eMedida)
        {
            List<string> vs = new List<string>
            {
                eMedida.Descripcion_medida, eMedida.Alias_medida
            };

            return DMedidas.InsertarMedida(vs);
        }

        public static string ModificarMedida(EMedida eMedida, int id_medida)
        {
            List<string> vs = new List<string>
            {
                eMedida.Descripcion_medida, eMedida.Alias_medida
            };

            return DMedidas.ModificarMedida(id_medida, vs);
        }

        public static DataTable BuscarMedidas(string tipo_busqueda, string texto_busqueda,
                out string rpta)
        {
            return DMedidas.BuscarMedidas(tipo_busqueda, texto_busqueda, out rpta);
        }

        public event EventHandler OnError;

        private int _id_medida;
        private string _descripcion_medida;
        private string _alias_medida;

        public int Id_medida { get => _id_medida; set => _id_medida = value; }
        public string Descripcion_medida { get => _descripcion_medida; set => _descripcion_medida = value; }
        public string Alias_medida { get => _alias_medida; set => _alias_medida = value; }
    }
}
