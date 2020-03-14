using System;
using System.IO;
using System.Configuration;
using CapaPresentacionAdministracion.Formularios.FormsConfiguraciones.FormsConfiguraciones;

namespace CapaPresentacionAdministracion
{
    public static class ArchivosAdjuntos
    {
        /*
         * appKey: Llave de archivo de configuración
         * nombreArchivo: Nombre del archivo a guardar, este nombre es el original del archivo 
         * que tiene la extensión incluida
         * rutaOrigen: La ruta de la cual se copiará el archivo
         * rutaDestino: La ruta de destino donde se pegará el archivo copiado.
        */
        public static string GuardarArchivo(string appKey, string nombreArchivo,
            string rutaOrigen)
        {
            string rpta = "OK";
            string rutaDestino = ObtenerRutaDestino(appKey);
            try
            {
                bool insert = true;
                if (Path.Combine(rutaDestino, nombreArchivo).Equals(rutaOrigen))
                {
                    insert = false;
                }

                if (insert)
                {
                    DirectoryInfo DirectoryInfo = new DirectoryInfo(rutaDestino);
                    string destino = Path.Combine(DirectoryInfo.ToString(), nombreArchivo);
                    File.Copy(rutaOrigen, destino, true);
                }
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            return rpta;
        }

        public static string ObtenerRutaDestino(string appKey)
        {
            string ruta = "";
            try
            {
                if (appKey.Equals("Ruta_archivos"))
                    ruta = ConfigGeneral.Default.Ruta_archivos;
            }
            catch (ConfigurationErrorsException ex)
            {
                ruta = ex.Message;
            }

            return ruta;
        }
    }
}
