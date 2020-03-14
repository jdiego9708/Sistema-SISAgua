using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DDetalleTarifas
    {
        public DDetalleTarifas() { }

        public static string InsertarDetalleTarifa(List<string> variables)
        {
            string consulta = "INSERT INTO Detalle_tipo_tarifa (Id_tarifa, Id_medida, Valor_base, Consumo_minimo, Consumo_maximo, Valor_excedente) " +
                "VALUES('" + variables[0] + "','" + variables[1] + "','" + variables[2].Replace(",",".") + 
                "','" + variables[3].Replace(",", ".") + 
                "','" + variables[4].Replace(",", ".") + 
                "','" + variables[5].Replace(",", ".") + "') ";
            return DConexion.EjecutarConsultaCadena(consulta, false);
        }

        public static string ModificarDetalleTarifa(int id_detalle_tarifa, List<string> variables)
        {
            string consulta = "UPDATE Detalle_tipo_tarifa SET " +
                "Id_tarifa ='" + variables[0] + "', " +
                "Id_medida ='" + variables[1] + "', " +
                "Valor_base ='" + variables[2].Replace(",", ".") + "', " +
                "Consumo_minimo ='" + variables[3].Replace(",", ".") + "', " +
                "Consumo_maximo ='" + variables[4].Replace(",", ".") + "', " +
                "Valor_excedente ='" + variables[5].Replace(",", ".") + "' " +
                "WHERE Id_detalle_tarifa = '" + id_detalle_tarifa + "'";
            return DConexion.EjecutarConsultaCadena(consulta, false);
        }

        public static DataTable BuscarDetalleTarifa(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            rpta = "OK";
            StringBuilder consulta = new StringBuilder();
            try
            {
                consulta.Append("SELECT * FROM Detalle_tipo_tarifa dtt INNER JOIN Tipo_tarifas tar ON dtt.Id_tarifa = tar.Id_tarifa " +
                    "INNER JOIN Medidas med ON dtt.Id_medida = med.Id_medida ");

                if (tipo_busqueda.Equals("ID TARIFA"))
                {
                    consulta.Append("WHERE dtt.Id_tarifa = " + texto_busqueda + " ");
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
