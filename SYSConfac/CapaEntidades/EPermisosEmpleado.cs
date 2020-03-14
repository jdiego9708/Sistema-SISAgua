using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;

namespace CapaEntidades
{
    public class EPermisosEmpleado
    {
        public EPermisosEmpleado()
        {

        }

        public EPermisosEmpleado(DataRow row)
        {
            try
            {
                this.Id_permiso = Convert.ToInt32(row["Id_permiso"]);
                this.Id_empleado = Convert.ToInt32(row["Id_empleado"]);
                this.Nombre_funcion = Convert.ToString(row["Nombre_funcion"]);
                this.Estado = Convert.ToString(row["Estado"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public EPermisosEmpleado(DataTable dt, int fila)
        {
            try
            {
                this.Id_permiso = Convert.ToInt32(dt.Rows[fila]["Id_permiso"]);
                this.Id_empleado = Convert.ToInt32(dt.Rows[fila]["Id_empleado"]);
                this.Nombre_funcion = Convert.ToString(dt.Rows[fila]["Nombre_funcion"]);
                this.Estado = Convert.ToString(dt.Rows[fila]["Estado"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public static DataTable BuscarPermisos(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            return DPermisosEmpleado.BuscarPermisos(tipo_busqueda, texto_busqueda, out rpta);
        }

        public static string InsertarPermiso(EPermisosEmpleado permiso)
        { 
            List<string> vs = new List<string>
            {
                permiso.Id_empleado.ToString(), permiso.Nombre_funcion, permiso.Estado
            };
            return DPermisosEmpleado.InsertarPermiso(vs);
        }

        public static string EditarPermiso(EPermisosEmpleado permiso, int id_permiso)
        {
            List<string> vs = new List<string>
            {
                permiso.Id_empleado.ToString(), permiso.Nombre_funcion, permiso.Estado
            };
            return DPermisosEmpleado.ModificarPermiso(id_permiso, vs);
        }


        /**Nota: _nombre_funcion indica el nombre del botón a bloquear o desbloquear según el estado**/
        private int _id_permiso;
        private int _id_empleado;
        private string _nombre_funcion;
        private string _estado;

        public int Id_permiso { get => _id_permiso; set => _id_permiso = value; }
        public int Id_empleado { get => _id_empleado; set => _id_empleado = value; }
        public string Nombre_funcion { get => _nombre_funcion; set => _nombre_funcion = value; }
        public string Estado { get => _estado; set => _estado = value; }

        public event EventHandler OnError;

    }
}
