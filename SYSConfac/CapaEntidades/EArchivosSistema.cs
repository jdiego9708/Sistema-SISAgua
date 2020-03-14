using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class EArchivosSistema
    {
        public EArchivosSistema()
        {

        }

        public EArchivosSistema(DataRow row)
        {
            try
            {
                this.Id_archivo = Convert.ToInt32(row["Id_archivo"]);
                this.Fecha_ingreso = Convert.ToDateTime(row["Fecha_ingreso"]);
                this.Ruta_archivo = Convert.ToString(row["Ruta_archivo"]);
                this.Nombre_archivo = Convert.ToString(row["Nombre_archivo"]);
                this.Titulo = Convert.ToString(row["Titulo"]);
                this.Descripcion = Convert.ToString(row["Descripcion"]);
                this.Estado = Convert.ToString(row["Estado"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public EArchivosSistema(DataTable dt, int fila)
        {
            try
            {
                this.Id_archivo = Convert.ToInt32(dt.Rows[fila]["Id_archivo"]);
                this.Fecha_ingreso = Convert.ToDateTime(dt.Rows[fila]["Fecha_ingreso"]);
                this.Ruta_archivo = Convert.ToString(dt.Rows[fila]["Ruta_archivo"]);
                this.Nombre_archivo = Convert.ToString(dt.Rows[fila]["Nombre_archivo"]);
                this.Titulo = Convert.ToString(dt.Rows[fila]["Titulo"]);
                this.Descripcion = Convert.ToString(dt.Rows[fila]["Descripcion"]);
                this.Estado = Convert.ToString(dt.Rows[fila]["Estado"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public static DataTable BuscarArchivos(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            return DArchivosSistema.BuscarArchivo(tipo_busqueda, texto_busqueda, out rpta);
        }

        public static string InsertarArchivo(EArchivosSistema eArchivo)
        {
            List<string> vs = new List<string>
            {
                eArchivo.Fecha_ingreso.ToString("yyyy-MM-dd"), eArchivo.Nombre_archivo,
                eArchivo.Ruta_archivo,
                eArchivo.Titulo, eArchivo.Descripcion,
                eArchivo.Estado
            };
            return DArchivosSistema.InsertarArchivo(vs);
        }

        public static string EditarArchivo(int id_archivo, EArchivosSistema eArchivo)
        {
            List<string> vs = new List<string>
            {
                eArchivo.Fecha_ingreso.ToString("yyyy-MM-dd"), eArchivo.Nombre_archivo,
                eArchivo.Ruta_archivo,
                eArchivo.Titulo, eArchivo.Descripcion,
                eArchivo.Estado
            };
            return DArchivosSistema.ModificarArchivo(id_archivo, vs);
        }

        public event EventHandler OnError;

        private int _id_archivo;
        private DateTime _fecha_ingreso;
        private string _ruta_archivo;
        private string _titulo;
        private string _descripcion;
        private string _estado;
        private string _nombre_archivo;

        public int Id_archivo { get => _id_archivo; set => _id_archivo = value; }
        public DateTime Fecha_ingreso { get => _fecha_ingreso; set => _fecha_ingreso = value; }
        public string Ruta_archivo { get => _ruta_archivo; set => _ruta_archivo = value; }
        public string Titulo { get => _titulo; set => _titulo = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public string Estado { get => _estado; set => _estado = value; }
        public string Nombre_archivo { get => _nombre_archivo; set => _nombre_archivo = value; }
    }
}
