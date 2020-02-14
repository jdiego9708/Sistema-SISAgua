using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DDetalleExcedentes
    {
        public DDetalleExcedentes() { }

        public static string InsertarDetalleExcedente(List<string> variables)
        {
            string consulta = "INSERT INTO Detalle_excedentes (Id_tarifa, Nombre_excedente, Consumo_minimo, Consumo_maximo, Valor_excedente) " +
                "VALUES('" + variables[0] + "','" + variables[1] + "','" + 
                variables[2] + "','" + variables[3] + "','" + variables[4].Replace(",", ".") + "') ";
            return DConexion.EjecutarConsultaCadena(consulta, false);
        }

        public static string ModificarDetalleExcedente(int id_detalle_excedente, List<string> variables)
        {
            string consulta = "UPDATE Detalle_excedentes SET " +
                "Id_tarifa ='" + variables[0] + "', " +
                "Nombre_excedente ='" + variables[1] + "', " +
                "Consumo_minimo ='" + variables[2] + "', " +
                "Consumo_maximo ='" + variables[3] + "', " +
                "Valor_excedente ='" + variables[4].Replace(",", ".") + "' " +
                "WHERE Id_detalle_excedente = '" + id_detalle_excedente + "'";
            return DConexion.EjecutarConsultaCadena(consulta, false);
        }

        public static DataTable BuscarDetalleExcedentes(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            rpta = "OK";
            StringBuilder consulta = new StringBuilder();
            try
            {
                consulta.Append("SELECT * FROM Detalle_excedentes de INNER JOIN Tipo_tarifas tar ON de.Id_tarifa = tar.Id_tarifa ");

                if (tipo_busqueda.Equals("ID TARIFA"))
                {
                    consulta.Append("WHERE de.Id_tarifa = " + texto_busqueda + " ");
                }
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
                return null;
            }

            return DConexion.EjecutarConsultaDt(Convert.ToString(consulta), out rpta);
        }
    }
}
