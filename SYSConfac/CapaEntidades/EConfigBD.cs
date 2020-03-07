using CapaDatos;
using System;
using System.Collections.Generic;

namespace CapaEntidades
{
    public class EConfigBD
    {
        public EConfigBD()
        {
            List<string> vs = DConexion.ObtenerConfiguraciones(out List<string> connectionsStrings);

            this.ConnectionDefault = vs[0];

            if (connectionsStrings.Count < 1)
                this.ConnectionsStrings = null;
            else
                this.ConnectionsStrings = connectionsStrings;

            this.MotorBD = vs[1];
            this.TipoBackup = vs[2];
            this.Frecuencia = Convert.ToInt32(vs[3]);
            this.RutaDestinoBackup = vs[4];
            this.FileName = vs[5];
        }

        public string InsertarConfiguraciones(List<string> configurations,
            List<string> connectionsStrings)
        {
            return DConexion.AsignarConfiguraciones(configurations, connectionsStrings);
        }


        public static bool TestConnection(string connectionString, out string rpta)
        {
            return DConexion.TestConnection(connectionString, out rpta);
        }

        private string _nameBDConnection;
        private List<string> _connectionsStrings;
        private string _motorBD;
        private string _tipoBackup;
        private int _frecuencia;
        private string _rutaDestinoBackup;
        private string _fileName;

        public string ConnectionDefault { get => _nameBDConnection; set => _nameBDConnection = value; }
        public string MotorBD { get => _motorBD; set => _motorBD = value; }
        public string TipoBackup { get => _tipoBackup; set => _tipoBackup = value; }
        public int Frecuencia { get => _frecuencia; set => _frecuencia = value; }
        public string RutaDestinoBackup { get => _rutaDestinoBackup; set => _rutaDestinoBackup = value; }
        public List<string> ConnectionsStrings { get => _connectionsStrings; set => _connectionsStrings = value; }
        public string FileName { get => _fileName; set => _fileName = value; }
    }
}
