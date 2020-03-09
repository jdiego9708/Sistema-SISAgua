namespace CapaPresentacionAdministracion.Servicios
{
    using System;
    using System.IO;
    using System.Security.AccessControl;

    public class HelperFiles
    {
        public static bool DirectoryExists(DirectoryInfo ruta)
        {
            return Directory.Exists(ruta.FullName);
        }

        public static bool ArchiveExists(DirectoryInfo ruta)
        {
            return File.Exists(ruta.FullName);
        }


        public static bool DirectoryAuthorization(DirectoryInfo ruta, out string rpta)
        {
            rpta = "";
            try
            {
                AuthorizationRuleCollection collection =
                Directory.GetAccessControl(ruta.FullName).GetAccessRules(true,
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
                using (FileStream fs = File.Create(Path.Combine(ruta.FullName,
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

        public static bool ArchiveAuthorization(DirectoryInfo ruta, out string rpta)
        {
            rpta = "";
            try
            {
                AuthorizationRuleCollection collection =
                Directory.GetAccessControl(ruta.FullName).GetAccessRules(true,
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
                using (FileStream fs = File.Create(ruta.FullName, 1, FileOptions.DeleteOnClose))
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

        public static bool BDAuthorization(DirectoryInfo ruta, out string rpta)
        {
            rpta = "";
            try
            {
                AuthorizationRuleCollection collection =
                Directory.GetAccessControl(ruta.FullName).GetAccessRules(true,
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

            
            return true;
        }
    }
}
