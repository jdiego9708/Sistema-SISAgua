using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DArchivosSistema
    {
        public DArchivosSistema() { }

        public static string InsertarArchivo(List<string> variables)
        {
            string consulta = "INSERT INTO Archivos_sistema (Fecha_ingreso, Nombre_archivo, Ruta_archivo, Titulo, Descripcion, Estado_archivo) " +
                "VALUES('" + variables[0] + "','" + variables[1] + "','" + variables[2] + "','" + 
                variables[3] + "','" + variables[4] + "','" + variables[5] + "') ";
            return DConexion.EjecutarConsultaCadena(consulta, false);
        }

        public static string ModificarArchivo(int id_archivo, List<string> variables)
        {
            string consulta = "UPDATE Archivos_sistema SET " +
                "Fecha_ingreso ='" + variables[0] + "', " +
                "Nombre_archivo ='" + variables[1] + "', " +
                "Ruta_archivo ='" + variables[2] + "', " +
                "Titulo ='" + variables[3] + "', " +
                "Descripcion ='" + variables[4] + "', " +
                "Estado_archivo ='" + variables[5] + "' " +
                "WHERE Id_archivo = '" + id_archivo + "'";
            return DConexion.EjecutarConsultaCadena(consulta, false);
        }

        public static DataTable BuscarArchivo(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            rpta = "OK";
            StringBuilder consulta = new StringBuilder();
            try
            {
                consulta.Append("SELECT * FROM Archivos_sistema ");


                if (tipo_busqueda.Equals("Titulo"))
                {
                    consulta.Append("WHERE Titulo like '" + texto_busqueda + "%' and Estado_archivo = 'ACTIVO' ");
                }
                else if (tipo_busqueda.Equals("ID ARCHIVO"))
                {
                    consulta.Append("WHERE Id_archivo = '" + texto_busqueda + "' and Estado_archivo = 'ACTIVO' ");
                }
                else if (tipo_busqueda.Equals("COMPLETO"))
                {
                    consulta.Append("WHERE Estado_archivo = 'ACTIVO' ");
                }

                consulta.Append("ORDER BY Id_archivo DESC");
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
