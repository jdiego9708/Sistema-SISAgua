using CapaPresentacionAdministracion.Formularios.FormsLecturas;
using CapaPresentacionAdministracion.Formularios.FormsPrincipales;
using CapaPresentacionCaja.Formularios.FormsPrincipales;
using System;
using System.Windows.Forms;

namespace SYSConfac
{
    public partial class FrmInicio : Form
    {
        public FrmInicio()
        {
            InitializeComponent();
            this.btnAdministracion.Click += BtnAdministracion_Click;
            this.btnCaja.Click += BtnCaja_Click;
            this.btnLecturas.Click += BtnLecturas_Click;
            this.Load += FrmInicio_Load;
        }

        private void FrmInicio_Load(object sender, EventArgs e)
        {
            Updates.InstallUpdateSyncWithInfo();

            DateTime fechaActual = DateTime.Now;
            if (fechaActual > new DateTime(2019, 09, 16) & fechaActual < new DateTime(2019, 09, 23))
            {
                MessageBox.Show("Aplicación bloqueada por falta de pago");
                foreach (Control control in this.Controls)
                {
                    control.Enabled = false;
                }
            }
        }

        private void BtnLecturas_Click(object sender, EventArgs e)
        {
            FrmIniciarSesion frmIniciarSesionLecturas = new FrmIniciarSesion
            {
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frmIniciarSesionLecturas.OnLoginSuccess += FrmIniciarSesionLecturas_OnLoginSuccess;
            frmIniciarSesionLecturas.ShowDialog();
        }

        private void FrmIniciarSesionLecturas_OnLoginSuccess(object sender, EventArgs e)
        {
            FrmPlanillaLecturas FrmPlanillaLecturas = new FrmPlanillaLecturas
            {
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Maximized
            };
            FrmPlanillaLecturas.OnBtnHome += FrmPlanillaLecturas_OnBtnHome;
            FrmPlanillaLecturas.Show();
            this.Hide();
        }

        private void FrmPlanillaLecturas_OnBtnHome(object sender, EventArgs e)
        {
            FrmPlanillaLecturas frmPlanillaLecturas = (FrmPlanillaLecturas)sender;
            frmPlanillaLecturas.Hide();
            this.Show();
        }

        private void BtnCaja_Click(object sender, EventArgs e)
        {
            FrmIniciarSesion frmIniciarSesionCaja = new FrmIniciarSesion
            {
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frmIniciarSesionCaja.OnLoginSuccess += FrmIniciarSesionCaja_OnLoginSuccess;
            frmIniciarSesionCaja.ShowDialog();
        }

        private void FrmIniciarSesionCaja_OnLoginSuccess(object sender, EventArgs e)
        {
            FrmPrincipalCaja frmPrincipalCaja = new FrmPrincipalCaja
            {
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false
            };
            frmPrincipalCaja.OnBtnHome += FrmPrincipalCaja_OnBtnHome;
            frmPrincipalCaja.Show();
            this.Hide();
        }

        private void FrmPrincipalCaja_OnBtnHome(object sender, EventArgs e)
        {
            FrmPrincipalCaja FrmPrincipalCaja = (FrmPrincipalCaja)sender;
            FrmPrincipalCaja.Hide();
            this.Show();
        }

        private void BtnAdministracion_Click(object sender, EventArgs e)
        {
            FrmIniciarSesion frmIniciarSesionAdministracion = new FrmIniciarSesion
            {
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            frmIniciarSesionAdministracion.OnLoginSuccess += FrmIniciarSesionAdministracion_OnLoginSuccess;
            frmIniciarSesionAdministracion.ShowDialog();
        }

        private void FrmIniciarSesionAdministracion_OnLoginSuccess(object sender, EventArgs e)
        {
            FrmPrincipal frmPrincipal = new FrmPrincipal
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            frmPrincipal.OnBtnHome += FrmPrincipal_OnBtnHome;
            frmPrincipal.Show();
            this.Hide();
        }

        private void FrmPrincipal_OnBtnHome(object sender, EventArgs e)
        {
            FrmPrincipal frmPrincipal = (FrmPrincipal)sender;
            frmPrincipal.Hide();
            this.Show();
        }
    }
}
