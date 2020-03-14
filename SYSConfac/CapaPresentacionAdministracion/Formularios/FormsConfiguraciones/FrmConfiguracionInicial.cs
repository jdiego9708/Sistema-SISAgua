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

        public bool ComprobarConfiguracion()
        {
            bool result = true;
            this.AbrirConfigInicial();
            result = this.FrmConfigInicial.AsignarDatos();
            if (result)
            {
                this.AbrirConfigBD();
                result = this.FrmConfigBD.AsignarDatos();

                if (result)
                {
                    this.AbrirConfigGeneral();
                    result = this.FrmConfigGeneral.AsignarDatos();

                    if (result)
                    {
                        this.AbrirConfigFacturas();
                        result = this.FrmConfigFacturas.AsignarDatos();

                        if (result)
                        {
                            this.AbrirConfigCorreos();
                            result = this.FrmConfigCorreos.AsignarDatos();

                            if (result)
                            {
                                this.AbrirConfigTarifas();
                                result = this.FrmConfigTarifas.AsignarDatos();
                            }
                        }
                    }
                }
            }
            return result;
        }

        private FrmConfigBD FrmConfigBD;
        private FrmConfigCorreos FrmConfigCorreos;
        private FrmConfigFacturas FrmConfigFacturas;
        private FrmConfigGeneral FrmConfigGeneral;
        private FrmConfigInicial FrmConfigInicial;
        private FrmConfigTarifas FrmConfigTarifas;

        private void Frm_OnBtnAtras(object sender, EventArgs e)
        {
            Form frm = (Form)sender;

            if (frm.Name.Equals("FrmConfigInicial"))
            {
                Mensajes.MensajePregunta("¿Desea abandonar la configuración?", "Abandonar", "Cancelar", out DialogResult dialog);
                if (dialog == DialogResult.Yes)
                {
                    frm.Close();
                    this.Close();
                }
            }
            else if (frm.Name.Equals("FrmConfigBD"))
            {
                this.AbrirConfigInicial();
            }
            else if (frm.Name.Equals("FrmConfigGeneral"))
            {
                this.AbrirConfigBD();
            }
            else if (frm.Name.Equals("FrmConfigFacturas"))
            {
                this.AbrirConfigGeneral();
            }
            else if (frm.Name.Equals("FrmConfigCorreos"))
            {
                this.AbrirConfigFacturas();
            }
            else if (frm.Name.Equals("FrmConfigTarifas"))
            {
                this.AbrirConfigCorreos();
            }
        }

        private void Frm_OnBtnSiguiente(object sender, EventArgs e)
        {
            Form frm = (Form)sender;
            if (frm.Name.Equals("FrmConfigInicial"))
            {
                this.AbrirConfigBD();
            }
            else if (frm.Name.Equals("FrmConfigBD"))
            {
                this.AbrirConfigGeneral();
            }
            else if (frm.Name.Equals("FrmConfigGeneral"))
            {
                this.AbrirConfigFacturas();
            }
            else if (frm.Name.Equals("FrmConfigFacturas"))
            {
                this.AbrirConfigCorreos();
            }
            else if (frm.Name.Equals("FrmConfigCorreos"))
            {
                this.AbrirConfigTarifas();
            }
            else if (frm.Name.Equals("FrmConfigTarifas"))
            {
                //Terminar la configuración
                string rpta = this.FrmConfigInicial.GuardarDatos();
                if (rpta.Equals("OK"))
                {
                    rpta = this.FrmConfigBD.GuardarDatos();
                    if (rpta.Equals("OK"))
                    {
                        rpta = this.FrmConfigGeneral.GuardarDatos();
                        if (rpta.Equals("OK"))
                        {
                            rpta = this.FrmConfigFacturas.GuardarDatos();
                            if (rpta.Equals("OK"))
                            {
                                rpta = this.FrmConfigCorreos.GuardarDatos();
                                if (rpta.Equals("OK"))
                                {
                                    rpta = this.FrmConfigTarifas.GuardarDatos();
                                    if (rpta.Equals("OK"))
                                    {
                                        Mensajes.MensajeInformacion("¡Se guardaron las configuraciones correctamente! " +
                                            "Reinicie el programa para que los cambios surgan efecto", "Entendido");
                                        this.Close();
                                    }
                                    else
                                    {
                                        Mensajes.MensajeInformacion("Hubo un error con los datos de " +
                                            "la configuración de tarifas", "Entendido");
                                        return;
                                    }
                                }
                                else
                                {
                                    Mensajes.MensajeInformacion("Hubo un error con los datos de " +
                                        "la configuración de correos", "Entendido");
                                    return;
                                }
                            }
                            else
                            {
                                Mensajes.MensajeInformacion("Hubo un error con los datos de " +
                                    "la configuración de facturas", "Entendido");
                                return;
                            }
                        }
                        else
                        {
                            Mensajes.MensajeInformacion("Hubo un error con los datos de " +
                                "la configuración general", "Entendido");
                            return;
                        }
                    }
                    else
                    {
                        Mensajes.MensajeInformacion("Hubo un error con los datos del formulario de la " +
                            "base de datos", "Entendido");
                        return;
                    }
                }
                else
                {
                    Mensajes.MensajeInformacion("Hubo un error con los datos del formulario inicial", "Entendido");
                    return;
                }
            }
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
                        WindowState = FormWindowState.Normal,
                        Dock = DockStyle.Fill
                    };
                    this.FrmConfigBD.OnBtnSiguienteClick += Frm_OnBtnSiguiente;
                    this.FrmConfigBD.OnBtnAtrasClick += Frm_OnBtnAtras;
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
                        WindowState = FormWindowState.Normal,
                        Dock = DockStyle.Fill
                    };
                    this.FrmConfigCorreos.OnBtnSiguienteClick += Frm_OnBtnSiguiente;
                    this.FrmConfigCorreos.OnBtnAtrasClick += Frm_OnBtnAtras;
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
                        WindowState = FormWindowState.Normal,
                        Dock = DockStyle.Fill
                    };
                    this.FrmConfigFacturas.OnBtnSiguienteClick += Frm_OnBtnSiguiente;
                    this.FrmConfigFacturas.OnBtnAtrasClick += Frm_OnBtnAtras;
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
                        WindowState = FormWindowState.Normal,
                        Dock = DockStyle.Fill
                    };
                    this.FrmConfigGeneral.OnBtnSiguienteClick += Frm_OnBtnSiguiente;
                    this.FrmConfigGeneral.OnBtnAtrasClick += Frm_OnBtnAtras;
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
                        WindowState = FormWindowState.Normal,
                        Dock = DockStyle.Fill
                    };
                    this.FrmConfigInicial.OnBtnSiguienteClick += Frm_OnBtnSiguiente;
                    this.FrmConfigInicial.OnBtnCancelarClick += Frm_OnBtnAtras;
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
                        WindowState = FormWindowState.Normal,
                        Dock = DockStyle.Fill
                    };
                    this.FrmConfigTarifas.OnBtnSiguienteClick += Frm_OnBtnSiguiente;
                    this.FrmConfigTarifas.OnBtnAtrasClick += Frm_OnBtnAtras;
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
    }
}
