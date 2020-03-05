namespace CapaPresentacionAdministracion.Formularios.FormsConfiguraciones
{
    using FormsConfiguraciones;
    using System;
    using System.Windows.Forms;

    public partial class FrmConfiguracionInicial : Form
    {
        public FrmConfiguracionInicial()
        {
            InitializeComponent();
            this.Load += FrmConfiguracionInicial_Load;
        }

        private FrmConfigBD FrmConfigBD;
        private FrmConfigCorreos FrmConfigCorreos;
        private FrmConfigFacturas FrmConfigFacturas;
        private FrmConfigGeneral FrmConfigGeneral;
        private FrmConfigInicial FrmConfigInicial;
        private FrmConfigTarifas FrmConfigTarifas;

        private void Frm_OnBtnAtras(object sender, EventArgs e)
        {

        }

        private void Frm_OnBtnSiguiente(object sender, EventArgs e)
        {

        }


        private void AbrirConfigBD()
        {
            try
            {
                if (this.panel1.Controls.Count > 0)
                    this.panel1.Controls.Clear();

                if (this.FrmConfigBD == null)
                {
                    this.FrmConfigBD = new FrmConfigBD
                    {
                        TopLevel = false,
                        StartPosition = FormStartPosition.CenterParent,
                        WindowState = FormWindowState.Normal
                    };
                    this.FrmConfigBD.OnBtnSiguiente += Frm_OnBtnSiguiente;
                    this.FrmConfigBD.OnBtnAtras += Frm_OnBtnAtras;
                }

                this.panel1.Controls.Add(this.FrmConfigBD);
                this.panel1.Tag = this.FrmConfigBD;
                this.FrmConfigBD.Show();
                this.FrmConfigBD.BringToFront();

            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "AbrirConfigBD",
                    "Hubo un error con el botón AbrirConfigBD", ex.Message);
            }
        }

        private void AbrirConfigCorreos()
        {
            try
            {
                if (this.panel1.Controls.Count > 0)
                    this.panel1.Controls.Clear();

                if (this.FrmConfigCorreos == null)
                {
                    this.FrmConfigCorreos = new FrmConfigCorreos
                    {
                        TopLevel = false,
                        StartPosition = FormStartPosition.CenterParent,
                        WindowState = FormWindowState.Normal
                    };
                    this.FrmConfigCorreos.OnBtnSiguiente += Frm_OnBtnSiguiente;
                    this.FrmConfigCorreos.OnBtnAtras += Frm_OnBtnAtras;
                }

                this.panel1.Controls.Add(this.FrmConfigCorreos);
                this.panel1.Tag = this.FrmConfigCorreos;
                this.FrmConfigCorreos.Show();
                this.FrmConfigCorreos.BringToFront();

            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "AbrirConfigCorreos",
                    "Hubo un error con el botón AbrirConfigCorreos", ex.Message);
            }
        }

        private void AbrirConfigFacturas()
        {
            try
            {
                if (this.panel1.Controls.Count > 0)
                    this.panel1.Controls.Clear();

                if (this.FrmConfigFacturas == null)
                {
                    this.FrmConfigFacturas = new FrmConfigFacturas
                    {
                        TopLevel = false,
                        StartPosition = FormStartPosition.CenterParent,
                        WindowState = FormWindowState.Normal
                    };
                }

                this.panel1.Controls.Add(this.FrmConfigFacturas);
                this.panel1.Tag = this.FrmConfigFacturas;
                this.FrmConfigFacturas.Show();
                this.FrmConfigFacturas.BringToFront();

            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "AbrirConfigFacturas",
                    "Hubo un error con el botón AbrirConfigFacturas", ex.Message);
            }
        }

        private void AbrirConfigGeneral()
        {
            try
            {
                if (this.panel1.Controls.Count > 0)
                    this.panel1.Controls.Clear();

                if (this.FrmConfigGeneral == null)
                {
                    this.FrmConfigGeneral = new FrmConfigGeneral
                    {
                        TopLevel = false,
                        StartPosition = FormStartPosition.CenterParent,
                        WindowState = FormWindowState.Normal
                    };
                }

                this.panel1.Controls.Add(this.FrmConfigGeneral);
                this.panel1.Tag = this.FrmConfigGeneral;
                this.FrmConfigGeneral.Show();
                this.FrmConfigGeneral.BringToFront();

            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "AbrirConfigGeneral",
                    "Hubo un error con el botón AbrirConfigGeneral", ex.Message);
            }
        }

        private void AbrirConfigInicial()
        {
            try
            {
                if (this.panel1.Controls.Count > 0)
                    this.panel1.Controls.Clear();

                if (this.FrmConfigInicial == null)
                {
                    this.FrmConfigInicial = new FrmConfigInicial
                    {
                        TopLevel = false,
                        StartPosition = FormStartPosition.CenterParent,
                        WindowState = FormWindowState.Normal
                    };
                }

                this.panel1.Controls.Add(this.FrmConfigInicial);
                this.panel1.Tag = this.FrmConfigInicial;
                this.FrmConfigInicial.Show();
                this.FrmConfigInicial.BringToFront();

            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "AbrirConfigInicial",
                    "Hubo un error con el botón AbrirConfigInicial", ex.Message);
            }
        }

        private void AbrirConfigTarifas()
        {
            try
            {
                if (this.panel1.Controls.Count > 0)
                    this.panel1.Controls.Clear();

                if (this.FrmConfigTarifas == null)
                {
                    this.FrmConfigTarifas = new FrmConfigTarifas
                    {
                        TopLevel = false,
                        StartPosition = FormStartPosition.CenterParent,
                        WindowState = FormWindowState.Normal
                    };
                }

                this.panel1.Controls.Add(this.FrmConfigTarifas);
                this.panel1.Tag = this.FrmConfigTarifas;
                this.FrmConfigTarifas.Show();
                this.FrmConfigTarifas.BringToFront();

            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "AbrirConfigTarifas",
                    "Hubo un error con el botón AbrirConfigTarifas", ex.Message);
            }
        }

        private void FrmConfiguracionInicial_Load(object sender, EventArgs e)
        {
            this.AbrirConfigInicial();
        }

        private Form ComprobarExistencia(Form form)
        {
            Form frmDevolver = null;
            foreach (Control control in this.panel1.Controls)
            {
                if (control is Form frm)
                {
                    if (frm.Name.Equals(form.Name))
                    {
                        frmDevolver = frm;
                        break;
                    }
                }
            }

            return frmDevolver;
        }
    }
}
