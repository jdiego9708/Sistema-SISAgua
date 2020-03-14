using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class EEmpleado
    {
        public EEmpleado()
        {

        }

        public EEmpleado(DataRow row)
        {
            try
            {
                this.Id_empleado = Convert.ToInt32(row["Id_empleado"]);
                this.Nombre_completo = Convert.ToString(row["Nombre_completo"]);
                this.Celular = Convert.ToString(row["Celular"]);
                this.Correo_electronico = Convert.ToString(row["Correo_electronico"]);
                this.Estado = Convert.ToString(row["Estado_empleado"]);
                this.Clave = Convert.ToString(row["Clave"]);
                this.Tipo_empleado = Convert.ToString(row["Tipo_empleado"]);
                this.Permisos = Convert.ToString(row["Permisos"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public EEmpleado(DataTable dt, int fila)
        {
            try
            {
                this.Id_empleado = Convert.ToInt32(dt.Rows[fila]["Id_empleado"]);
                this.Nombre_completo = Convert.ToString(dt.Rows[fila]["Nombre_completo"]);
                this.Celular = Convert.ToString(dt.Rows[fila]["Celular"]);
                this.Correo_electronico = Convert.ToString(dt.Rows[fila]["Correo_electronico"]);
                this.Estado = Convert.ToString(dt.Rows[fila]["Estado_empleado"]);
                this.Clave = Convert.ToString(dt.Rows[fila]["Clave"]);
                this.Tipo_empleado = Convert.ToString(dt.Rows[fila]["Tipo_empleado"]);
                this.Permisos = Convert.ToString(dt.Rows[fila]["Permisos"]);

            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public EEmpleado(int id_empleado)
        {
            try
            {
                DataTable dt = 
                    DEmpleados.BuscarEmpleados("ID EMPLEADO", id_empleado.ToString(), out string rpta);
                if (dt != null)
                {
                    this.Id_empleado = Convert.ToInt32(dt.Rows[0]["Id_empleado"]);
                    this.Nombre_completo = Convert.ToString(dt.Rows[0]["Nombre_completo"]);
                    this.Celular = Convert.ToString(dt.Rows[0]["Celular"]);
                    this.Correo_electronico = Convert.ToString(dt.Rows[0]["Correo_electronico"]);
                    this.Estado = Convert.ToString(dt.Rows[0]["Estado_empleado"]);
                    this.Clave = Convert.ToString(dt.Rows[0]["Clave"]);
                    this.Tipo_empleado = Convert.ToString(dt.Rows[0]["Tipo_empleado"]);
                    this.Permisos = Convert.ToString(dt.Rows[0]["Permisos"]);
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

        public static string InsertarEmpleado(EEmpleado eEmpleado)
        {
            List<string> vs = new List<string>
            {
                eEmpleado.Nombre_completo,
                eEmpleado.Celular, eEmpleado.Correo_electronico, eEmpleado.Estado,
                eEmpleado.Tipo_empleado, eEmpleado.Clave, eEmpleado.Permisos
            };

            return DEmpleados.InsertarEmpleado(vs);
        }

        public static string EditarEmpleado(int id_empleado, EEmpleado eEmpleado)
        {
            List<string> vs = new List<string>
            {
                eEmpleado.Nombre_completo,
                eEmpleado.Celular, eEmpleado.Correo_electronico, eEmpleado.Estado,
                eEmpleado.Tipo_empleado, eEmpleado.Clave, eEmpleado.Permisos
            };

            return DEmpleados.ModificarEmpleado(id_empleado, vs);
        }

        public static DataTable BuscarEmpleados(string tipo_busqueda, string texto_busqueda,
            out string rpta)
        {
            return DEmpleados.BuscarEmpleados(tipo_busqueda, texto_busqueda, out rpta);
        }

        public static DataTable Login(string usuario, string clave,
                out string rpta)
        {
            return DEmpleados.Login(usuario, clave, out rpta);
        }

        public event EventHandler OnError;
        private int _id_empleado;
        private string _nombre_completo;
        private string _celular;
        private string _correo_electronico;
        private string _clave;
        private string _tipo_empleado;
        private string _estado;
        private string _permisos;
        private List<EPermisosEmpleado> permisosEmpleado;

        public int Id_empleado { get => _id_empleado; set => _id_empleado = value; }
        public string Nombre_completo { get => _nombre_completo; set => _nombre_completo = value; }
        public string Correo_electronico { get => _correo_electronico; set => _correo_electronico = value; }
        public string Celular { get => _celular; set => _celular = value; }
        public string Clave { get => _clave; set => _clave = value; }
        public List<EPermisosEmpleado> PermisosEmpleado { get => permisosEmpleado; set => permisosEmpleado = value; }
        public string Tipo_empleado { get => _tipo_empleado; set => _tipo_empleado = value; }
        public string Estado { get => _estado; set => _estado = value; }
        public string Permisos { get => _permisos; set => _permisos = value; }
    }
}
