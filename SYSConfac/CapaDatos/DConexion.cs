using System;
using System.Configuration;
using System.Data.SQLite;
using System.Data;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace CapaDatos
{
    public static class DConexion
    {        
        public static List<string> ObtenerConfiguraciones(out List<string> connectionsStrings)
        {
            StringCollection stringCollection = ConfigBD.Default.ConnectionsStrings;
            connectionsStrings = stringCollection.Cast<string>().ToList();

            return new List<string>
            {
                ConfigBD.Default.ConnectionDefault,
                ConfigBD.Default.MotorBD,
                ConfigBD.Default.TipoBackup,
                ConfigBD.Default.Frecuencia.ToString(),
                ConfigBD.Default.RutaDestinoBackup,
                ConfigBD.Default.FileNameConnection
            };
        }

        public static string AsignarConfiguraciones(List<string> configurations, 
            List<string> connectionsStrings)
        {

            try
            {
                if (configurations.Count > 0)
                {
                    StringCollection collection = new StringCollection();
                    collection.AddRange(connectionsStrings.ToArray());

                    ConfigBD.Default.ConnectionDefault = configurations[0];
                    ConfigBD.Default.MotorBD = configurations[1];
                    ConfigBD.Default.TipoBackup = configurations[2];
                    ConfigBD.Default.Frecuencia = Convert.ToInt32(configurations[3]);
                    ConfigBD.Default.ConnectionsStrings = collection;
                    ConfigBD.Default.RutaDestinoBackup = configurations[4];
                    ConfigBD.Default.FileNameConnection = configurations[5];
                    ConfigBD.Default.Save();
                    return "OK";
                }
                else
                    throw new Exception("La configuraciones a guardar están vacías.");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }           
        }

        private static string ObtenerCadenaDeConexion(string Nombre_cadena_de_conexion, string tipo_dato)
        {
            string cadena = "";
            ConnectionStringSettingsCollection connections = ConfigurationManager.ConnectionStrings;

            if (connections.Count != 0)
            {
                foreach (ConnectionStringSettings connection in connections)
                {

                    string name = connection.Name;
                    string provider = connection.ProviderName;
                    string connectionString = connection.ConnectionString;
                    if (name.Equals(Nombre_cadena_de_conexion) && tipo_dato.Equals("COMPLETA"))
                    {
                        cadena = connectionString;
                        break;
                    }
                    else if (name.Equals(Nombre_cadena_de_conexion) && tipo_dato.Equals("NOMBRE SERVIDOR"))
                    {
                        cadena = name;
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("No existe la conexión");
            }
            return cadena;
        }

        public static string Cn
        {
            get { return ConfigBD.Default.ConnectionDefault; }
        }

        public static SQLiteConnection Conex(out string rpta)
        {
            rpta = "OK";
            try
            {
                string conec = Cn;
                SQLiteConnection conn = new SQLiteConnection(conec);
                return conn;
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
                return null;
            }
        }

        public static bool TestConnection(string connectionString, out string rpta)
        {
            rpta = "OK";
            try
            {
                string conec = connectionString;
                SQLiteConnection conn = new SQLiteConnection(conec);
                return true;
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
                return false;
            }
        }

        public static DataTable EjecutarConsultaDt(string consulta, out string rpta)
        {
            rpta = "OK";
            DataTable tabla = new DataTable();
            SQLiteConnection cnn = Conex(out rpta);
            try
            {
                if (cnn == null)
                    throw new Exception(rpta);

                cnn.Open();
                SQLiteCommand m = new SQLiteCommand(consulta, cnn);
                SQLiteDataAdapter da = new SQLiteDataAdapter(m);

                da.Fill(tabla);

                if (tabla.Rows.Count < 1)
                    tabla = null;

                return tabla;
            }
            catch (SQLiteException ex)
            {
                rpta = ex.Message;
                return null;
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
                return null;
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                    cnn.Close();
            }
        }

        public static string EjecutarConsultaCadena(string consulta, bool returnIdentity)
        {
            SQLiteConnection cnn = Conex(out string rpta);
            try
            {
                if (cnn == null)
                    throw new Exception(rpta);

                cnn.Open();
                SQLiteCommand m = new SQLiteCommand(consulta, cnn);
                if (returnIdentity)
                {
                    int id = Convert.ToInt32(m.ExecuteScalar());
                    Id_autogenerado = id;
                    if (id > 0)
                        rpta = "OK";
                    else
                        throw new Exception("La identificación única (ID) no se obtuvo correctamente");
                }
                else
                {
                    rpta = m.ExecuteNonQuery() >= 1 ? "OK" : "ERROR";
                }
            }
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
                if (cnn.State == ConnectionState.Open)
                    cnn.Close();
            }

            return rpta;
        }

        public static int Id_autogenerado;
    }
}
