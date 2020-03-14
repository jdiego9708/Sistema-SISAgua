using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;

namespace CapaEntidades
{
    public class EMedidor
    {
        public EMedidor()
        {

        }

        public EMedidor(DataRow row)
        {
            try
            {
                this.Id_medidor = Convert.ToInt32(row["Id_medidor"]);
                this.DireccionCliente = new EDireccionCliente
                {
                    Id_direccion = Convert.ToInt32(row["Id_direccion"]),
                    Direccion = Convert.ToString(row["Direccion"]),
                    Tipo_establecimiento = Convert.ToString(row["Tipo_establecimiento"]),
                    Estado = Convert.ToString(row["Estado_direccion"]),

                    ECliente = new ECliente
                    {
                        Id_cliente = Convert.ToInt32(row["Id_cliente"]),
                        Nombres = Convert.ToString(row["Nombres"]),
                        Apellidos = Convert.ToString(row["Apellidos"]),
                        Identificacion = Convert.ToString(row["Identificacion"]),
                        Celular = Convert.ToString(row["Celular"]),
                        Correo = Convert.ToString(row["Correo_electronico"]),
                        Estado = Convert.ToString(row["Estado_cliente"])
                    },

                    EBarrio = new EBarrio(row)
                };

                this.Medidor = Convert.ToString(row["Medidor"]);
                this.Descripcion = Convert.ToString(row["Descripcion"]);
                this.Estado_medidor = Convert.ToString(row["Estado_medidor"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public EMedidor(DataTable dt, int fila)
        {
            try
            {
                this.Id_medidor = Convert.ToInt32(dt.Rows[fila]["Id_medidor"]);
                this.DireccionCliente = new EDireccionCliente
                {
                    Id_direccion = Convert.ToInt32(dt.Rows[fila]["Id_direccion"]),
                    Direccion = Convert.ToString(dt.Rows[fila]["Direccion"]),
                    Tipo_establecimiento = Convert.ToString(dt.Rows[fila]["Tipo_establecimiento"]),
                    Estado = Convert.ToString(dt.Rows[fila]["Estado_direccion"]),
                    ECliente = new ECliente
                    {
                        Id_cliente = Convert.ToInt32(dt.Rows[fila]["Id_cliente"]),
                        Nombres = Convert.ToString(dt.Rows[fila]["Nombres"]),
                        Apellidos = Convert.ToString(dt.Rows[fila]["Apellidos"]),
                        Identificacion = Convert.ToString(dt.Rows[fila]["Identificacion"]),
                        Celular = Convert.ToString(dt.Rows[fila]["Celular"]),
                        Correo = Convert.ToString(dt.Rows[fila]["Correo_electronico"]),
                        Estado = Convert.ToString(dt.Rows[fila]["Estado_cliente"])
                    },
                    EBarrio = new EBarrio(dt.Rows[fila])
                    
                };
                this.Medidor = Convert.ToString(dt.Rows[fila]["Medidor"]);
                this.Descripcion = Convert.ToString(dt.Rows[fila]["Descripcion"]);
                this.Estado_medidor = Convert.ToString(dt.Rows[fila]["Estado_medidor"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public EMedidor(int id_medidor)
        {
            try
            {
                DataTable dt =
                    DMedidores.BuscarMedidores("ID", id_medidor.ToString(), out string rpta);
                if (dt != null)
                {
                    this.Id_medidor = Convert.ToInt32(dt.Rows[0]["Id_medidor"]);
                    this.DireccionCliente = new EDireccionCliente(Convert.ToInt32(dt.Rows[0]["Id_direccion"]));
                    this.Medidor = Convert.ToString(dt.Rows[0]["Medidor"]);
                    this.Descripcion = Convert.ToString(dt.Rows[0]["Descripcion"]);
                    this.Estado_medidor = Convert.ToString(dt.Rows[0]["Estado_medidor"]);
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

        public static string InsertarMedidor(out int id_medidor, EMedidor eMedidor)
        {
            id_medidor = 0;
            List<string> vs = new List<string>
            {
                eMedidor.DireccionCliente.Id_direccion.ToString(),
                eMedidor.Medidor, eMedidor.Descripcion, eMedidor.Estado_medidor
            };
            return DMedidores.InsertarMedidor(vs);
        }

        public static string EditarMedidor(int id_medidor, EMedidor eMedidor)
        {
            List<string> vs = new List<string>
            {
                eMedidor.DireccionCliente.Id_direccion.ToString(),
                eMedidor.Medidor, eMedidor.Descripcion, eMedidor.Estado_medidor
            };
            return DMedidores.ModificarMedidor(id_medidor, vs);
        }

        public static DataTable BuscarMedidor(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            return DMedidores.BuscarMedidores(tipo_busqueda, texto_busqueda, out rpta);
        }


        public event EventHandler OnError;
        private int _id_medidor;
        private EDireccionCliente direccionCliente;
        private string _medidor;
        private string _descripcion;
        private string _estado_medidor;

        public int Id_medidor { get => _id_medidor; set => _id_medidor = value; }
        public EDireccionCliente DireccionCliente { get => direccionCliente; set => direccionCliente = value; }
        public string Medidor { get => _medidor; set => _medidor = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public string Estado_medidor { get => _estado_medidor; set => _estado_medidor = value; }
    }
}
