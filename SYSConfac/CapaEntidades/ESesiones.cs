using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class ESesiones
    {
        public ESesiones()
        {

        }

        public ESesiones(DataRow row)
        {
            try
            {
                this.Id_sesion = Convert.ToInt32(row["Id_sesion"]);
                this.Fecha_sesion = Convert.ToDateTime(row["Fecha_sesion"]);
                this.Hora_sesion = Convert.ToString(row["Hora_sesion"]);
                this.Titulo_sesion = Convert.ToString(row["Titulo_sesion"]);
                this.Descripcion_sesion = Convert.ToString(row["Descripcion_sesion"]);
                this.Documento_adjunto = Convert.ToString(row["Documento_adjunto"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public ESesiones(DataTable dt, int fila)
        {
            try
            {
                this.Id_sesion = Convert.ToInt32(dt.Rows[fila]["Id_sesion"]);
                this.Fecha_sesion = Convert.ToDateTime(dt.Rows[fila]["Fecha_sesion"]);
                this.Hora_sesion = Convert.ToString(dt.Rows[fila]["Hora_sesion"]);
                this.Titulo_sesion = Convert.ToString(dt.Rows[fila]["Titulo_sesion"]);
                this.Descripcion_sesion = Convert.ToString(dt.Rows[fila]["Descripcion_sesion"]);
                this.Documento_adjunto = Convert.ToString(dt.Rows[fila]["Documento_adjunto"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public ESesiones(int id_sesion)
        {
            try
            {
                DataTable dt =
                    DSesiones.BuscarSesiones("ID SESION", id_sesion.ToString(), out string rpta);
                if (dt != null)
                {
                    this.Id_sesion = Convert.ToInt32(dt.Rows[0]["Id_sesion"]);
                    this.Fecha_sesion = Convert.ToDateTime(dt.Rows[0]["Fecha_sesion"]);
                    this.Hora_sesion = Convert.ToString(dt.Rows[0]["Hora_sesion"]);
                    this.Titulo_sesion = Convert.ToString(dt.Rows[0]["Titulo_sesion"]);
                    this.Descripcion_sesion = Convert.ToString(dt.Rows[0]["Descripcion_sesion"]);
                    this.Documento_adjunto = Convert.ToString(dt.Rows[0]["Documento_adjunto"]);
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

        public static string InsertarSesion(ESesiones sesion, out int id_sesion)
        {
            List<string> vs = new List<string>
            {
                sesion.Fecha_sesion.ToString("yyyy-MM-dd"), sesion.Hora_sesion, sesion.Titulo_sesion,
                sesion.Descripcion_sesion, sesion.Documento_adjunto
            };
            return DSesiones.InsertarSesion(vs, out id_sesion);
        }

        public static string EditarSesion(ESesiones sesion, int id_tarifa)
        {
            List<string> vs = new List<string>
            {
                sesion.Fecha_sesion.ToString("yyyy-MM-dd"), sesion.Hora_sesion, sesion.Titulo_sesion,
                sesion.Descripcion_sesion, sesion.Documento_adjunto
            };
            return DSesiones.ModificarSesion(id_tarifa, vs);
        }

        public static DataTable BuscarSesiones(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            return DSesiones.BuscarSesiones(tipo_busqueda, texto_busqueda, out rpta);
        }

        private int _id_sesion;
        private DateTime _fecha_sesion;
        private string _hora_sesion;
        private string _titulo_sesion;
        private string _descripcion_sesion;
        private string _documento_adjunto;

        public int Id_sesion { get => _id_sesion; set => _id_sesion = value; }
        public DateTime Fecha_sesion { get => _fecha_sesion; set => _fecha_sesion = value; }
        public string Hora_sesion { get => _hora_sesion; set => _hora_sesion = value; }
        public string Titulo_sesion { get => _titulo_sesion; set => _titulo_sesion = value; }
        public string Descripcion_sesion { get => _descripcion_sesion; set => _descripcion_sesion = value; }
        public string Documento_adjunto { get => _documento_adjunto; set => _documento_adjunto = value; }

        public event EventHandler OnError;
    }
}
