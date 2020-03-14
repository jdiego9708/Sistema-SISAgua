using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace CapaDatos
{
    public class DTipo_tarifas
    {
        #region VARIABLES
        private static string mensaje_respuesta;
        public static string Mensaje_respuesta
        {
            get
            {
                return mensaje_respuesta;
            }

            set
            {
                mensaje_respuesta = value;
            }
        }

        #endregion

        #region CONSTRUCTOR VACIO
        public DTipo_tarifas() { }
        #endregion

        #region METODO INSERTAR TIPO TARIFA
        public static string InsertarTipoTarifa(out int id_tarifa, List<string> vs)
        {
            id_tarifa = 0;
            int contador = 0;
            string consulta = "INSERT INTO Tipo_tarifas(Descripcion, Valor_tarifa, Tipo_tarifa) " +
                "VALUES(@Descripcion, @Valor_tarifa, @Tipo_tarifa); " +
                "SELECT last_insert_rowid() ";
            SQLiteConnection SqlCon = DConexion.Conex(out string rpta);
            try
            {
                if (SqlCon == null)
                    throw new Exception(rpta);

                SqlCon.Open();
                SQLiteCommand SqlCmd = new SQLiteCommand
                {
                    Connection = SqlCon,
                    CommandText = consulta,
                    CommandType = CommandType.Text
                };

                SQLiteParameter Id_tarifa = new SQLiteParameter
                {
                    ParameterName = "@Id_tarifa"
                };
                SqlCmd.Parameters.Add(Id_tarifa);

                SQLiteParameter Descripcion = new SQLiteParameter
                {
                    ParameterName = "@Descripcion",
                    Value = vs[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Descripcion);
                contador += 1;

                SQLiteParameter Valor_tarifa = new SQLiteParameter
                {
                    ParameterName = "@Valor_tarifa",
                    Value = vs[contador].Replace(",", ".")
                };
                SqlCmd.Parameters.Add(Valor_tarifa);
                contador += 1;

                SQLiteParameter Tipo_tarifa = new SQLiteParameter
                {
                    ParameterName = "@Tipo_tarifa",
                    Size = 50,
                    Value = vs[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Tipo_tarifa);
                contador += 1;

                int id = Convert.ToInt32(SqlCmd.ExecuteScalar());
                id_tarifa = id;
                if (id > 0)
                    rpta = "OK";
                else
                    throw new Exception("La identificación única (ID) no se obtuvo correctamente: " + rpta);

                if (!rpta.Equals("OK"))
                {
                    if (Mensaje_respuesta != null)
                        rpta = Mensaje_respuesta;
                }
            }
            //Mostramos posible error que tengamos
            catch (SQLiteException ex)
            {
                rpta = ex.Message;
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                //Si la cadena SqlCon esta abierta la cerramos
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }
            return rpta;
        }
        #endregion

        #region METODO EDITAR TIPO TARIFA
        public static string EditarTipoTarifa(int id_tarifa, List<string> vs)
        {
            int contador = 0;
            string consulta = "UPDATE Tipo_tarifas " +
                "SET Descripcion = @Descripcion, " +
                "Valor_tarifa = @Valor_tarifa, " +
                "Tipo_tarifa = @Tipo_tarifa " +
                "WHERE Id_tarifa = @Id_tarifa; ";
            SQLiteConnection SqlCon = DConexion.Conex(out string rpta);
            try
            {
                if (SqlCon == null)
                    throw new Exception(rpta);

                SqlCon.Open();
                SQLiteCommand SqlCmd = new SQLiteCommand
                {
                    Connection = SqlCon,
                    CommandText = consulta,
                    CommandType = CommandType.Text
                };

                SQLiteParameter Id_tarifa = new SQLiteParameter
                {
                    ParameterName = "@Id_tarifa",
                    Value = id_tarifa
                };
                SqlCmd.Parameters.Add(Id_tarifa);

                SQLiteParameter Descripcion = new SQLiteParameter
                {
                    ParameterName = "@Descripcion",
                    Value = vs[contador].ToUpper()
                };
                SqlCmd.Parameters.Add(Descripcion);
                contador += 1;

                SQLiteParameter Valor_tarifa = new SQLiteParameter
                {
                    ParameterName = "@Valor_tarifa",
                    Value = vs[contador].Replace(",", ".")
                };
                SqlCmd.Parameters.Add(Valor_tarifa);
                contador += 1;

                SQLiteParameter Tipo_tarifa = new SQLiteParameter
                {
                    ParameterName = "@Tipo_tarifa",
                    Size = 50,
                    Value = vs[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Tipo_tarifa);
                contador += 1;

                rpta = SqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "NO se Ingreso el Registro";

                if (!rpta.Equals("OK"))
                {
                    if (Mensaje_respuesta != null)
                        rpta = Mensaje_respuesta;
                }
            }
            //Mostramos posible error que tengamos
            catch (SQLiteException ex)
            {
                rpta = ex.Message;
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                //Si la cadena SqlCon esta abierta la cerramos
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }
            return rpta;
        }
        #endregion

        #region METODO BUSCAR TIPO TARIFAS
        public static DataTable BuscarTipoTarifas(string tipo_busqueda, string texto_busqueda,
            out string rpta)
        {
            rpta = "OK";
            StringBuilder consulta = new StringBuilder();
            consulta.Append("SELECT * FROM Tipo_tarifas ");

            if (tipo_busqueda.Equals("TIPO"))
            {
                consulta.Append("WHERE Tipo_tarifa like % '@Texto_busqueda'");
            }
            else if (tipo_busqueda.Equals("TARIFA MANUAL"))
            {
                consulta.Append("WHERE Descripcion like 'MANUAL' ");
            }
            //else if (tipo_busqueda.Equals("COMPLETO"))
            //{
            //    consulta.Append("WHERE Descripcion != 'MANUAL' and Descripcion != 'CONSUMO DE AGUA' ");
            //}
            else if (tipo_busqueda.Equals("CONSUMO"))
            {
                consulta.Append("WHERE Descripcion like 'CONSUMO DE AGUA' ");
            }
            else if (tipo_busqueda.Equals("ID TARIFA"))
            {
                consulta.Append("WHERE Id_tarifa = " + texto_busqueda + " ");
            }

            DataTable DtResultado = new DataTable("TipoTarifas");
            SQLiteConnection SqlCon = DConexion.Conex(out rpta);
            try
            {
                if (SqlCon == null)
                    throw new Exception(rpta);

                SqlCon.Open();
                SQLiteCommand SqlCmd = new SQLiteCommand
                {
                    Connection = SqlCon,
                    CommandText = Convert.ToString(consulta),
                    CommandType = CommandType.Text
                };

                SQLiteParameter Texto_busqueda = new SQLiteParameter
                {
                    ParameterName = "@Texto_busqueda",
                    Size = 50,
                    Value = texto_busqueda.Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Texto_busqueda);

                SQLiteDataAdapter SqlData = new SQLiteDataAdapter(SqlCmd);
                SqlData.Fill(DtResultado);

                if (DtResultado.Rows.Count < 1)
                {
                    DtResultado = null;
                }
            }
            catch (SQLiteException ex)
            {
                rpta = ex.Message;
                DtResultado = null;
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
                DtResultado = null;
            }
            finally
            {
                //Si la cadena SqlCon esta abierta la cerramos
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }

            return DtResultado;
        }

        #endregion
    }
}
