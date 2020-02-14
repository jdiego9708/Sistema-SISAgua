using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;

namespace CapaEntidades
{
    public class EBarrio
    {
        public EBarrio()
        {

        }

        public EBarrio(DataRow row)
        {
            try
            {
                this.Id_barrio = Convert.ToInt32(row["Id_barrio"]);
                this.EParroquia = new EParroquia
                {
                    Id_parroquia = Convert.ToInt32(row["Id_parroquia"]),
                    ECanton = new ECanton
                    {
                        Id_canton = Convert.ToInt32(row["Id_canton"]),
                        Nombre = Convert.ToString(row["Nombre_canton"]),
                        Descripcion = Convert.ToString(row["Descripcion_canton"])
                    },
                    Nombre = Convert.ToString(row["Nombre_parroquia"]),
                    Descripcion = Convert.ToString(row["Descripcion_parroquia"])
                };
                this.Nombre = Convert.ToString(row["Nombre_barrio"]);
                this.Descripcion = Convert.ToString(row["Descripcion_barrio"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public EBarrio(DataTable dt, int fila)
        {
            try
            {
                this.Id_barrio = Convert.ToInt32(dt.Rows[fila]["Id_barrio"]);
                this.Id_barrio = Convert.ToInt32(dt.Rows[fila]["Id_barrio"]);
                this.EParroquia = new EParroquia
                {
                    Id_parroquia = Convert.ToInt32(dt.Rows[fila]["Id_parroquia"]),
                    ECanton = new ECanton
                    {
                        Id_canton = Convert.ToInt32(dt.Rows[fila]["Id_canton"]),
                        Nombre = Convert.ToString(dt.Rows[fila]["Nombre_canton"]),
                        Descripcion = Convert.ToString(dt.Rows[fila]["Descripcion_canton"])
                    },
                    Nombre = Convert.ToString(dt.Rows[fila]["Nombre_parroquia"]),
                    Descripcion = Convert.ToString(dt.Rows[fila]["Descripcion_parroquia"])
                };
                this.Nombre = Convert.ToString(dt.Rows[fila]["Nombre_barrio"]);
                this.Descripcion = Convert.ToString(dt.Rows[fila]["Descripcion_barrio"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public static DataTable BuscarBarrios(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            return DBarrios.BuscarBarrios(tipo_busqueda, texto_busqueda, out rpta);
        }

        public static string InsertarBarrio(EBarrio barrio)
        {
            List<string> vs = new List<string>
            {
                barrio.EParroquia.Id_parroquia.ToString(), barrio.Nombre, barrio.Descripcion
            };
            return DBarrios.InsertarBarrios(vs);
        }

        public static string EditarBarrio(EBarrio barrio, int id_barrio)
        {
            List<string> vs = new List<string>
            {
                barrio.EParroquia.Id_parroquia.ToString(), barrio.Nombre, barrio.Descripcion
            };
            return DBarrios.ModificarBarrios(id_barrio, vs);
        }

        private int _id_barrio;
        private EParroquia _eParroquia;
        private string _nombre;
        private string _descripcion;
        public event EventHandler OnError;

        public int Id_barrio { get => _id_barrio; set => _id_barrio = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public EParroquia EParroquia { get => _eParroquia; set => _eParroquia = value; }
    }
}
