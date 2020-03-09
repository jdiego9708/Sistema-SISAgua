using CapaEntidades;
using CapaPresentacionAdministracion.Formularios.FormsTarifas;
using System;
using System.Windows.Forms;

namespace CapaPresentacionAdministracion.Formularios.FormsConfiguraciones.FormsConfiguraciones
{
    public partial class FrmConfigTarifas : Form
    {
        public FrmConfigTarifas()
        {
            InitializeComponent();
            this.btnTarifaLectura.Click += BtnTarifa_Click;
            this.btnTarifaSesion.Click += BtnTarifa_Click;
            this.btnTarifaManual.Click += BtnTarifa_Click;
            this.btnTerminar.Click += BtnTerminar_Click;
            this.btnAtras.Click += BtnAtras_Click;
        }

        public string GuardarDatos()
        {
            string rpta = "OK";
            try
            {
                if (this.Comprobaciones(out int id_lectura, out int id_sesion, out int id_manual))
                {
                    ConfigTarifas.Default.Id_tarifa_lectura = id_lectura;
                    ConfigTarifas.Default.Id_tarifa_manual = id_manual;
                    ConfigTarifas.Default.Id_tarifa_sesion = id_sesion;
                    ConfigTarifas.Default.Save();
                }
                else
                    throw new Exception("No se pudo realizar la comprobación");
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            return rpta;
        }

        private bool Comprobaciones(out int id_lectura, out int id_sesion, out int id_manual)
        {
            id_lectura = 0;
            id_sesion = 0;
            id_manual = 0;

            if (this.btnTarifaLectura.Tag == null)
            {
                this.errorProvider1.SetError(this.btnTarifaLectura, "Debe seleccionar una tarifa");
                return false;
            }
            else
            {
                ETarifas eTarifa = (ETarifas)this.btnTarifaLectura.Tag;
                id_lectura = eTarifa.Id_tarifa;
            }

            if (this.btnTarifaManual.Tag == null)
            {
                this.errorProvider1.SetError(this.btnTarifaManual, "Debe seleccionar una tarifa");
                return false;
            }
            else
            {
                ETarifas eTarifa = (ETarifas)this.btnTarifaManual.Tag;
                id_manual = eTarifa.Id_tarifa;
            }

            if (this.btnTarifaSesion.Tag == null)
            {
                this.errorProvider1.SetError(this.btnTarifaSesion, "Debe seleccionar una tarifa");
                return false;
            }
            else
            {
                ETarifas eTarifa = (ETarifas)this.btnTarifaSesion.Tag;
                id_sesion = eTarifa.Id_tarifa;
            }

            return true;
        }

        private void BtnAtras_Click(object sender, EventArgs e)
        {
            OnBtnAtrasClick?.Invoke(this, e);
        }

        private void BtnTerminar_Click(object sender, EventArgs e)
        {
            if (this.Comprobaciones(out _, out _, out _))
                this.OnBtnSiguienteClick?.Invoke(this, e);
        }

        private void BtnTarifa_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            FrmObservarTarifas frmObservarTarifas = new FrmObservarTarifas
            {
                StartPosition = FormStartPosition.CenterScreen
            };

            if (Convert.ToString(btn.Tag).Equals("LECTURA"))
                frmObservarTarifas.OnDgvDoubleClick += FrmTarifaLectura_OnDgvDoubleClick;
            else if (Convert.ToString(btn.Tag).Equals("SESION"))
                frmObservarTarifas.OnDgvDoubleClick += FrmTarifaSesion_OnDgvDoubleClick;
            else if (Convert.ToString(btn.Tag).Equals("MANUAL"))
                frmObservarTarifas.OnDgvDoubleClick += FrmTarifaManual_OnDgvDoubleClick;

            frmObservarTarifas.ShowDialog();
        }

        private void FrmTarifaLectura_OnDgvDoubleClick(object sender, EventArgs e)
        {
            ETarifas eTarifa = (ETarifas)sender;
            this.btnTarifaLectura.Text = eTarifa.Descripcion;
            this.btnTarifaLectura.Tag = eTarifa;
        }

        private void FrmTarifaSesion_OnDgvDoubleClick(object sender, EventArgs e)
        {
            ETarifas eTarifa = (ETarifas)sender;
            this.btnTarifaSesion.Text = eTarifa.Descripcion;
            this.btnTarifaSesion.Tag = eTarifa;
        }

        private void FrmTarifaManual_OnDgvDoubleClick(object sender, EventArgs e)
        {
            ETarifas eTarifa = (ETarifas)sender;
            this.btnTarifaManual.Text = eTarifa.Descripcion;
            this.btnTarifaManual.Tag = eTarifa;
        }

        public event EventHandler OnBtnSiguienteClick;
        public event EventHandler OnBtnAtrasClick;
    }
}
