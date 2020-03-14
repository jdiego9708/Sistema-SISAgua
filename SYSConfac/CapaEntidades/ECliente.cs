using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class ECliente
    {
        public ECliente()
        {

        }

        public ECliente(DataRow row)
        {
            try
            {
                this.Id_cliente = Convert.ToInt32(row["Id_cliente"]);
                this.Nombres = Convert.ToString(row["Nombres"]);
                this.Apellidos = Convert.ToString(row["Apellidos"]);
                this.Identificacion = Convert.ToString(row["Identificacion"]);
                this.Celular = Convert.ToString(row["Celular"]);
                this.Correo = Convert.ToString(row["Correo_electronico"]);
                this.Estado = Convert.ToString(row["Estado_cliente"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public ECliente(DataTable dt, int fila)
        {
            try
            {
                this.Id_cliente = Convert.ToInt32(dt.Rows[fila]["Id_cliente"]);
                this.Nombres = Convert.ToString(dt.Rows[fila]["Nombres"]);
                this.Apellidos = Convert.ToString(dt.Rows[fila]["Apellidos"]);
                this.Identificacion = Convert.ToString(dt.Rows[fila]["Identificacion"]);
                this.Celular = Convert.ToString(dt.Rows[fila]["Celular"]);
                this.Correo = Convert.ToString(dt.Rows[fila]["Correo_electronico"]);
                this.Estado = Convert.ToString(dt.Rows[fila]["Estado_cliente"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public ECliente(int id_cliente)
        {
            try
            {
                DataTable dt =
                    BuscarClientes("ID CLIENTE", id_cliente.ToString(), out string rpta);
                if (dt != null)
                {
                    this.Id_cliente = Convert.ToInt32(dt.Rows[0]["Id_cliente"]);
                    this.Nombres = Convert.ToString(dt.Rows[0]["Nombres"]);
                    this.Apellidos = Convert.ToString(dt.Rows[0]["Apellidos"]);
                    this.Identificacion = Convert.ToString(dt.Rows[0]["Identificacion"]);
                    this.Celular = Convert.ToString(dt.Rows[0]["Celular"]);
                    this.Correo = Convert.ToString(dt.Rows[0]["Correo_electronico"]);
                    this.Estado = Convert.ToString(dt.Rows[0]["Estado_cliente"]);
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

        public static string InsertarCliente(ECliente eCliente, out int id_cliente)
        {
            List<string> vs = new List<string>
            {
                eCliente.Nombres, eCliente.Apellidos,
                eCliente.Identificacion, eCliente.Celular, eCliente.Correo, 
                eCliente.Estado
            };

            return DClientes.InsertarCliente(vs, out id_cliente);
        }

        public static string EditarCliente(int id_cliente, ECliente eCliente)
        {
            List<string> vs = new List<string>
            {
                eCliente.Nombres, eCliente.Apellidos,
                eCliente.Identificacion, eCliente.Celular, eCliente.Correo,
                eCliente.Estado
            };

            return DClientes.ModificarCliente(id_cliente, vs);
        }

        public static DataTable BuscarClientes(string tipo_busqueda, string texto_busqueda,
            out string rpta)
        {
            return DClientes.BuscarClientes(tipo_busqueda, texto_busqueda, out rpta);
        }

        public event EventHandler OnError;

        private int _id_cliente;
        private string _nombres;
        private string _apellidos;
        private string _identificacion;
        private string _celular;
        private string _correo;
        private string _estado;

        public int Id_cliente { get => _id_cliente; set => _id_cliente = value; }
        public string Nombres { get => _nombres; set => _nombres = value; }
        public string Apellidos { get => _apellidos; set => _apellidos = value; }
        public string Identificacion { get => _identificacion; set => _identificacion = value; }
        public string Celular { get => _celular; set => _celular = value; }
        public string Correo { get => _correo; set => _correo = value; }
        public string Estado { get => _estado; set => _estado = value; }
    }
}
