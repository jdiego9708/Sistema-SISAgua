namespace CapaPresentacionAdministracion.Servicios
{
    using System;
    using System.IO;
    using System.Security.AccessControl;

    public class HelperFiles
    {
        public static bool DirectoryExists(string ruta)
        {
            return Directory.Exists(ruta);
        }

        public static bool DirectoryAuthorization(string ruta, out string rpta)
        {
            rpta = "";
            try
            {
                AuthorizationRuleCollection collection =
                Directory.GetAccessControl(ruta).GetAccessRules(true,
                 true, typeof(System.Security.Principal.NTAccount));
                foreach (FileSystemAccessRule rule in collection)
                {
                    if (rule.AccessControlType == AccessControlType.Allow)
                    {
                        break;
                    }
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                rpta = ex.Message;
                return false;
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
                return false;
            }

            try
            {
                using (FileStream fs = File.Create(Path.Combine(ruta,
                 "AccessTemp.txt"), 1, FileOptions.DeleteOnClose))
                {
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
                return false;
            }

            return true;
        }
    }
}
