using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;

namespace CapaEntidades
{
    public class EDetalleSesiones
    {
        public EDetalleSesiones()
        {

        }

        public EDetalleSesiones(DataRow row)
        {
            try
            {
                this.ESesion = new ESesiones
                {
                    Id_sesion = Convert.ToInt32(row["Id_sesion"])
                };
                this.ECliente = new ECliente
                {
                    Id_cliente = Convert.ToInt32(row["Id_cliente"])
                };
                this.Estado = Convert.ToString(row["Estado"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public EDetalleSesiones(DataTable dt, int fila)
        {
            try
            {
                this.ESesion = new ESesiones
                {
                    Id_sesion = Convert.ToInt32(dt.Rows[fila]["Id_sesion"])
                };
                this.ECliente = new ECliente
                {
                    Id_cliente = Convert.ToInt32(dt.Rows[fila]["Id_cliente"])
                };
                this.Estado = Convert.ToString(dt.Rows[fila]["Estado"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public static DataTable BuscarDetalleSesiones(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            return DDetalleSesiones.BuscarDetalleSesion(tipo_busqueda, texto_busqueda, out rpta);
        }

        public static string InsertarDetalleSesiones(EDetalleSesiones detalle)
        {
            List<string> vs = new List<string>
            {
                detalle.ESesion.Id_sesion.ToString(),
                detalle.ECliente.Id_cliente.ToString(),
                detalle.Estado
            };
            return DDetalleSesiones.InsertarDetalleSesion(vs);
        }

        private ESesiones _eSesion;
        private ECliente _eCliente;
        private string _estado;

        public ESesiones ESesion { get => _eSesion; set => _eSesion = value; }
        public ECliente ECliente { get => _eCliente; set => _eCliente = value; }
        public string Estado { get => _estado; set => _estado = value; }

        public event EventHandler OnError;
    }
}
