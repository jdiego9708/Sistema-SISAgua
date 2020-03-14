using System;
using System.Deployment.Application;
using System.Windows.Forms;
using CapaPresentacionAdministracion;
namespace SYSConfac
{
    public class Updates
    {
        public static void InstallUpdateSyncWithInfo()
        {
            UpdateCheckInfo info = null;

            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;

                try
                {
                    info = ad.CheckForDetailedUpdate();

                }
                catch (DeploymentDownloadException dde)
                {
                    Mensajes.MensajeInformacion("La nueva versión de la aplicación no se puede descargar en este momento " +
                        "\n\nVerifique la conexión a internet y vuelva a intentar. Error: " + dde.Message, "Entendido");
                    return;
                }
                catch (InvalidDeploymentException ide)
                {
                    Mensajes.MensajeInformacion("No se pudo buscar una nueva versión de la aplicación. " +
                        "La implementación del instalador está dañada, comuníquese con soporte. Error: " + ide.Message,
                        "Entendido");
                    return;
                }
                catch (InvalidOperationException ioe)
                {
                    Mensajes.MensajeInformacion("Esta aplicación no se puede actualizar, verifique las opciones de actualización. " +
                        "Error: " + ioe.Message, "Entendido");
                    return;
                }

                if (info.UpdateAvailable)
                {
                    Boolean doUpdate = true;

                    if (!info.IsUpdateRequired)
                    {
                        Mensajes.MensajePregunta("Hay una nueva actualización disponible, ¿desea descargarla?", "Si", "No", out DialogResult dialog);

                        if (dialog == DialogResult.No)
                        {
                            doUpdate = false;
                        }
                    }
                    else
                    {
                        // Display a message that the app MUST reboot. Display the minimum required version.
                        Mensajes.MensajeInformacion("Esta aplicación ha detectado una actualización obligatoria de la " +
                            "version a la version " + info.MinimumRequiredVersion.ToString() +
                            ". La aplicación se actualizará y luego se reiniciará",
                            "Entendido");
                    }

                    if (doUpdate)
                    {
                        try
                        {
                            ad.Update();
                            Mensajes.MensajeInformacion("La aplicación se ha actualizado, ahora se va a reiniciar", "Entendido");
                            Application.Restart();
                        }
                        catch (DeploymentDownloadException dde)
                        {
                            MessageBox.Show("No se puede instalar la versión de la aplicación. \r\nVerifique la conexión a internet y vuelva a intentar. Error: " + dde);
                            return;
                        }
                    }
                }
            }
        }
    }
}
