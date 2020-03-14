using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaEntidades
{
    public class EDireccionCliente
    {
        public EDireccionCliente()
        {

        }

        public EDireccionCliente(DataRow row)
        {
            try
            {
                this.Id_direccion = Convert.ToInt32(row["Id_direccion"]);
                this.Direccion = Convert.ToString(row["Direccion"]);
                this.Tipo_establecimiento = Convert.ToString(row["Tipo_establecimiento"]);
                this.Estado = Convert.ToString(row["Estado_direccion"]);

                this.ECliente = new ECliente
                {
                    Id_cliente = Convert.ToInt32(row["Id_cliente"]),
                    Nombres = Convert.ToString(row["Nombres"]),
                    Apellidos = Convert.ToString(row["Apellidos"])
                };

                this.EBarrio = new EBarrio(row);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public EDireccionCliente(DataTable dt, int fila)
        {
            try
            {
                this.Id_direccion = Convert.ToInt32(dt.Rows[fila]["Id_direccion"]);
                this.Direccion = Convert.ToString(dt.Rows[fila]["Direccion"]);
                this.Tipo_establecimiento = Convert.ToString(dt.Rows[fila]["Tipo_establecimiento"]);
                this.Estado = Convert.ToString(dt.Rows[fila]["Estado_direccion"]);

                this.ECliente = new ECliente
                {
                    Id_cliente = Convert.ToInt32(dt.Rows[fila]["Id_cliente"]),
                    Nombres = Convert.ToString(dt.Rows[fila]["Nombres"]),
                    Apellidos = Convert.ToString(dt.Rows[fila]["Apellidos"])
                };

                this.EBarrio = new EBarrio(dt.Rows[fila]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public EDireccionCliente(int id_direccion)
        {
            try
            {
                DataTable dt = DDireccion_cliente.BuscarDirecciones("ID", id_direccion.ToString(), out string rpta);
                if (dt != null)
                {
                    this.Id_direccion = Convert.ToInt32(dt.Rows[0]["Id_direccion"]);
                    this.Direccion = Convert.ToString(dt.Rows[0]["Direccion"]);
                    this.Tipo_establecimiento = Convert.ToString(dt.Rows[0]["Tipo_establecimiento"]);
                    this.Estado = Convert.ToString(dt.Rows[0]["Estado_direccion"]);
                    this.ECliente = new ECliente(dt.Rows[0]);

                    this.EBarrio = new EBarrio(dt.Rows[0]);
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

        public static string InsertarDireccion(out int id_direccion, EDireccionCliente cliente)
        {
            List<string> vs = new List<string>
                {
                    cliente.ECliente.Id_cliente.ToString(), cliente.Direccion,
                    cliente.EBarrio.Id_barrio.ToString(), cliente.Tipo_establecimiento, cliente.Estado
                };
            return DDireccion_cliente.InsertarDireccionCliente(vs, out id_direccion);
        }

        public static string EditarDireccion(int id_direccion, EDireccionCliente cliente)
        {
            List<string> vs = new List<string>
                {
                    cliente.ECliente.Id_cliente.ToString(), cliente.Direccion,
                    cliente.EBarrio.Id_barrio.ToString(), cliente.Tipo_establecimiento, cliente.Estado
                };
            return DDireccion_cliente.ModificarDireccionCliente(id_direccion, vs);
        }

        public static DataTable BuscarDirecciones(string tipo_busqueda,
            string texto_busqueda, out string rpta)
        {
            return DDireccion_cliente.BuscarDirecciones(tipo_busqueda, texto_busqueda, out rpta);
        }

        public static string InactivarDireccion(int id_direccion)
        {
            return DDireccion_cliente.InactivarDireccionCliente(id_direccion);
        }

        public event EventHandler OnError;

        private int _id_direccion;
        private ECliente eCliente;
        private string _direccion;
        private EBarrio eBarrio;
        private string _tipo_establecimiento;
        private string _estado;

        public int Id_direccion { get => _id_direccion; set => _id_direccion = value; }
        public string Direccion { get => _direccion; set => _direccion = value; }
        public string Tipo_establecimiento { get => _tipo_establecimiento; set => _tipo_establecimiento = value; }
        public ECliente ECliente { get => eCliente; set => eCliente = value; }
        public EBarrio EBarrio { get => eBarrio; set => eBarrio = value; }
        public string Estado { get => _estado; set => _estado = value; }
    }
}
