using CapaEntidades;
using CapaPresentacionAdministracion.Formularios.FormsConfiguraciones;

namespace CapaPresentacionAdministracion.Formularios.FormsPrincipales
{
    public class DatosInicioSesion
    {
        #region PATRON SINGLETON
        private static DatosInicioSesion _Instancia;
        public static DatosInicioSesion GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DatosInicioSesion();
            }
            return _Instancia;
        }
        #endregion

        public static bool ComprobarConfiguraciones()
        {
            FrmConfiguracionInicial frmConfiguracionInicial = new FrmConfiguracionInicial();
            bool result = frmConfiguracionInicial.ComprobarConfiguracion();
            if (!result)
            {
                Mensajes.MensajeInformacion("Encontramos problemas en la configuración de la aplicación, " +
                    "por favor revise la configuración y solucione los problemas", "Entendido");
            }
            return result;
        }

        private EEmpleado _eEmpleado;
        private ECaja _eCaja;
        public EEmpleado EEmpleado { get => _eEmpleado; set => _eEmpleado = value; }
        public ECaja ECaja { get => _eCaja; set => _eCaja = value; }
    }
}
