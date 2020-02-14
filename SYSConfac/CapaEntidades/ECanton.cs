using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaEntidades
{
    public class ECanton
    {
        public ECanton()
        {

        }

        public ECanton(DataRow row)
        {
            try
            {
                this.Id_canton = Convert.ToInt32(row["Id_canton"]);
                this.Nombre = Convert.ToString(row["Nombre_canton"]);
                this.Descripcion = Convert.ToString(row["Descripcion_canton"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public ECanton(DataTable dt, int fila)
        {
            try
            {
                this.Id_canton = Convert.ToInt32(dt.Rows[fila]["Id_canton"]);
                this.Nombre = Convert.ToString(dt.Rows[fila]["Nombre_canton"]);
                this.Descripcion = Convert.ToString(dt.Rows[fila]["Descripcion_canton"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public static DataTable BuscarCantones(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            return DCantones.BuscarCantones(tipo_busqueda, texto_busqueda, out rpta);
        }

        public static string InsertarCanton(ECanton canton)
        {
            List<string> vs = new List<string>
            {
                canton.Nombre, canton.Descripcion
            };
            return DCantones.InsertarCanton(vs);
        }

        public static string EditarCanton(ECanton canton, int id_canton)
        {
            List<string> vs = new List<string>
            {
                canton.Nombre, canton.Descripcion
            };
            return DCantones.ModificarCanton(id_canton, vs);
        }


        private int _id_canton;
        private string _nombre;
        private string _descripcion;
        public event EventHandler OnError;

        public int Id_canton { get => _id_canton; set => _id_canton = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
    }
}
