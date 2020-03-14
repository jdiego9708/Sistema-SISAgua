using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class EParroquia
    {
        public EParroquia()
        {

        }

        public EParroquia(DataRow row)
        {
            try
            {
                this.Id_parroquia = Convert.ToInt32(row["Id_parroquia"]);
                this.Nombre = Convert.ToString(row["Nombre_parroquia"]);
                this.Descripcion = Convert.ToString(row["Descripcion_parroquia"]);

                this.ECanton = new ECanton
                {
                    Id_canton = Convert.ToInt32(row["Id_canton"]),
                    Nombre = Convert.ToString(row["Nombre_canton"])
                };
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public EParroquia(DataTable dt, int fila)
        {
            try
            {
                this.Id_parroquia = Convert.ToInt32(dt.Rows[fila]["Id_parroquia"]);
                this.Nombre = Convert.ToString(dt.Rows[fila]["Nombre_parroquia"]);
                this.Descripcion = Convert.ToString(dt.Rows[fila]["Descripcion_parroquia"]);

                this.ECanton = new ECanton
                {
                    Id_canton = Convert.ToInt32(dt.Rows[fila]["Id_canton"]),
                    Nombre = Convert.ToString(dt.Rows[fila]["Nombre_canton"])
                };
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public static DataTable BuscarParroquias(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            return DParroquias.BuscarParroquia(tipo_busqueda, texto_busqueda, out rpta);
        }

        public static string InsertarParroquia(EParroquia parroquia)
        {
            List<string> vs = new List<string>
            {
                parroquia.ECanton.Id_canton.ToString(), parroquia.Nombre, parroquia.Descripcion
            };
            return DParroquias.InsertarParroquia(vs);
        }

        public static string EditarParroquia(EParroquia parroquia, int id_parroquia)
        {
            List<string> vs = new List<string>
            {
                parroquia.ECanton.Id_canton.ToString(), parroquia.Nombre, parroquia.Descripcion
            };
            return DParroquias.ModificarParroquia(id_parroquia, vs);
        }

        private int _id_parroquia;
        private string _nombre;
        private string _descripcion;
        private ECanton _eCanton;
        public event EventHandler OnError;

        public int Id_parroquia { get => _id_parroquia; set => _id_parroquia = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public ECanton ECanton { get => _eCanton; set => _eCanton = value; }
    }
}
