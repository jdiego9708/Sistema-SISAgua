using System;
using System.Windows.Forms;
using CapaEntidades;
using CapaPresentacionAdministracion.Formularios.FormsCantones;
using CapaPresentacionAdministracion.Formularios.FormsParroquias;
using CapaPresentacionAdministracion.Formularios.FormsBarrios;
using CapaPresentacionAdministracion.Formularios.FormsTarifas;
using CapaPresentacionAdministracion.Formularios.FormsMedidas;
using CapaPresentacionAdministracion.Formularios.FormsClientes;
using CapaPresentacionAdministracion.Formularios.FormsEmpleados;
using CapaPresentacionAdministracion.Formularios.FormsCuentas;
using CapaPresentacionAdministracion.Formularios.FormsAgendamientoSesiones;
using CapaPresentacionAdministracion.Formularios.FormsSesiones;
using CapaPresentacionAdministracion.Formularios.FormsGastos;
using CapaPresentacionAdministracion.Formularios.FormsCajas;
using CapaPresentacionAdministracion.Formularios.FormsArchivos;
using CapaPresentacionAdministracion.Formularios.FormsConfiguraciones;
using CapaPresentacionAdministracion.Formularios.FormsReportes;
using CapaPresentacionAdministracion.Formularios.FormsLecturas;
using CapaPresentacionAdministracion.Formularios.FormsCorreos;

namespace CapaPresentacionAdministracion.Formularios.FormsPrincipales
{
    public partial class FrmPrincipal : Form
    {
        PoperContainer container;
        public FrmPrincipal()
        {
            InitializeComponent();
            this.btnLecturas.Click += BtnLecturas_Click;
            this.btnConfiguraciones.Click += BtnConfiguraciones_Click;
            this.btnTarifas.Click += BtnTarifas_Click;
            this.btnEmpleados.Click += BtnEmpleados_Click;
            this.btnClientes.Click += BtnClientes_Click;
            this.btnSesiones.Click += BtnSesiones_Click;
            this.btnHistorialGastos.Click += BtnHistorialGastos_Click;
            this.btnCierresCaja.Click += BtnCierresCaja_Click;
            this.btnArchivos.Click += BtnArchivos_Click;
            this.btnGastos.Click += BtnGastos_Click;
            this.btnCuentas.Click += BtnCuentas_Click;
            this.btnHome.Click += BtnHome_Click;
            this.btnReportes.Click += BtnReportes_Click;
            this.FormClosing += FrmPrincipal_FormClosing;
            this.btnEnviarEmail.Click += BtnEnviarEmail_Click;
        }

        private void BtnEnviarEmail_Click(object sender, EventArgs e)
        {
            try
            {
                FrmEnvioEmail frm = new FrmEnvioEmail
                {
                    TopLevel = false,
                    StartPosition = FormStartPosition.CenterParent
                };
                Form FormComprobado = this.ComprobarExistencia(frm);
                if (FormComprobado != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.Activate();
                }
                else
                {
                    this.panel1.Controls.Add(frm);
                    this.panel1.Tag = frm;
                    frm.Show();
                }
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnEnviarEmail_Click",
                    "Hubo un error con el botón enviar email", ex.Message);
            }
        }

        private void BtnReportes_Click(object sender, EventArgs e)
        {
            FrmReportes frmReportes = new FrmReportes();
            frmReportes.Show();
        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.btnHome.PerformClick();
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            OnBtnHome?.Invoke(this, e);
        }

        public event EventHandler OnBtnHome;

        private void BtnCierresCaja_Click(object sender, EventArgs e)
        {
            try
            {
                FrmHistorialCierreCaja frm = new FrmHistorialCierreCaja
                {
                    TopLevel = false,
                    StartPosition = FormStartPosition.CenterParent
                };
                Form FormComprobado = this.ComprobarExistencia(frm);
                if (FormComprobado != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.Activate();
                }
                else
                {
                    this.panel1.Controls.Add(frm);
                    this.panel1.Tag = frm;
                    frm.Show();
                }
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnCierresCaja_Click",
                    "Hubo un error con el botón OBSERVAR HISTORIAL cierre de caja", ex.Message);
            }
        }

        private void BtnHistorialGastos_Click(object sender, EventArgs e)
        {
            try
            {
                FrmObservarHistorialGastos frm = new FrmObservarHistorialGastos
                {
                    TopLevel = false,
                    StartPosition = FormStartPosition.CenterParent
                };
                Form FormComprobado = this.ComprobarExistencia(frm);
                if (FormComprobado != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.Activate();
                }
                else
                {
                    this.panel1.Controls.Add(frm);
                    this.panel1.Tag = frm;
                    frm.Show();
                }
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnHistorialGastos_Click",
                    "Hubo un error con el botón OBSERVAR HISTORIAL GASTOS", ex.Message);
            }
        }

        #region GASTOS
        private void BtnGastos_Click(object sender, EventArgs e)
        {
            MenuGastos menuGastos = new MenuGastos();
            menuGastos.btnAgregarGasto.Click += BtnAgregarGasto_Click;
            menuGastos.btnEditarGasto.Click += BtnEditarGasto_Click;
            menuGastos.btnObservarGastos.Click += BtnObservarGastos_Click;
            container = new PoperContainer(menuGastos);
            container.Show(btnGastos);
        }

        private void BtnObservarGastos_Click(object sender, EventArgs e)
        {
            try
            {
                FrmObservarGastos frm = new FrmObservarGastos
                {
                    TopLevel = false,
                    StartPosition = FormStartPosition.CenterParent
                };
                Form FormComprobado = this.ComprobarExistencia(frm);
                if (FormComprobado != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.Activate();
                }
                else
                {
                    this.panel1.Controls.Add(frm);
                    this.panel1.Tag = frm;
                    frm.Show();
                }
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnObservarGastos_Click",
                    "Hubo un error con el botón observar gastos", ex.Message);
            }
        }

        private void BtnEditarGasto_Click(object sender, EventArgs e)
        {
            FrmObservarGastos FrmObservarGastos = new FrmObservarGastos
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            FrmObservarGastos.OnDgvDoubleClick += FrmObservarGastos_OnDgvDoubleClick;
            FrmObservarGastos.ShowDialog();
        }

        private void FrmObservarGastos_OnDgvDoubleClick(object sender, EventArgs e)
        {
            try
            {
                EGastos gasto = (EGastos)sender;
                FrmAgregarGasto frm = new FrmAgregarGasto
                {
                    TopLevel = false,
                    IsEditar = true,
                    StartPosition = FormStartPosition.CenterParent
                };
                frm.AsignarDatos(gasto);
                Form FormComprobado = this.ComprobarExistencia(frm);
                if (FormComprobado != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.Activate();
                }
                else
                {
                    this.panel1.Controls.Add(frm);
                    this.panel1.Tag = frm;
                    frm.Show();
                }
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "FrmObservarGastos_OnDgvDoubleClick",
                    "Hubo un error con el botón editar gasto", ex.Message);
            }
        }

        private void BtnAgregarGasto_Click(object sender, EventArgs e)
        {
            try
            {
                FrmAgregarGasto frm = new FrmAgregarGasto
                {
                    TopLevel = false,
                    StartPosition = FormStartPosition.CenterParent
                };
                Form FormComprobado = this.ComprobarExistencia(frm);
                if (FormComprobado != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.Activate();
                }
                else
                {
                    this.panel1.Controls.Add(frm);
                    this.panel1.Tag = frm;
                    frm.Show();
                }
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnAgregarGasto_Click",
                    "Hubo un error con el botón agregar gastos", ex.Message);
            }
        }
        #endregion

        #region ARCHIVOS
        private void BtnArchivos_Click(object sender, EventArgs e)
        {
            try
            {
                FrmObservarArchivos frm = new FrmObservarArchivos
                {
                    TopLevel = false,
                    StartPosition = FormStartPosition.CenterParent,
                    Dock = DockStyle.Fill
                };
                Form FormComprobado = this.ComprobarExistencia(frm);
                if (FormComprobado != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.Activate();
                }
                else
                {
                    this.panel1.Controls.Add(frm);
                    this.panel1.Tag = frm;
                    frm.Show();
                }
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnArchivos_Click",
                    "Hubo un error con el botón observar archivos", ex.Message);
            }
        }

        #endregion

        #region SESIONES

        private void BtnSesiones_Click(object sender, EventArgs e)
        {
            MenuSesiones menuSesiones = new MenuSesiones();
            menuSesiones.btnAgendarSesion.Click += BtnAgendarSesion_Click;
            menuSesiones.btnCambiarFechaSesion.Click += BtnCambiarFechaSesion_Click;
            menuSesiones.btnObservarAgendamiento.Click += BtnObservarAgendamiento_Click;
            this.container = new PoperContainer(menuSesiones);
            this.container.Show(btnSesiones);
        }

        private void BtnObservarAgendamiento_Click(object sender, EventArgs e)
        {
            try
            {
                FrmObservarAgendamientoSesiones frm = new FrmObservarAgendamientoSesiones
                {
                    TopLevel = false,
                    StartPosition = FormStartPosition.CenterParent
                };
                frm.OnBtnSesion += Frm_OnBtnSesion;
                Form FormComprobado = this.ComprobarExistencia(frm);
                if (FormComprobado != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.Activate();
                }
                else
                {
                    this.panel1.Controls.Add(frm);
                    this.panel1.Tag = frm;
                    frm.Show();
                }
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnCambiarFechaSesion_Click",
                    "Hubo un error con el botón cambiar fecha sesion", ex.Message);
            }
        }

        private void Frm_OnBtnSesion(object sender, EventArgs e)
        {
            EAgendamientoSesion eAgendamiento = (EAgendamientoSesion)sender;
            if (eAgendamiento.Fecha.ToString("yyyy-MM-dd") != DateTime.Now.ToString("yyyy-MM-dd"))
            {
                Mensajes.MensajeInformacion("La sesión esta cerrada, se abrirá el " +
                    eAgendamiento.Fecha.ToLongDateString() + " - a las " + eAgendamiento.Hora, "Entendido");
            }
            else
            {
                FrmNuevaSesion frmNuevaSesion = new FrmNuevaSesion
                {
                    StartPosition = FormStartPosition.CenterScreen
                };
                frmNuevaSesion.AsignarAgendamiento(eAgendamiento);
                frmNuevaSesion.ShowDialog();
            }
        }

        private void BtnCambiarFechaSesion_Click(object sender, EventArgs e)
        {
            try
            {
                FrmObservarAgendamientoSesiones frm = new FrmObservarAgendamientoSesiones
                {
                    TopLevel = false,
                    StartPosition = FormStartPosition.CenterParent,
                    IsEditar = true
                };

                Form FormComprobado = this.ComprobarExistencia(frm);
                if (FormComprobado != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.Activate();
                }
                else
                {
                    this.panel1.Controls.Add(frm);
                    this.panel1.Tag = frm;
                    frm.Show();
                }
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnCambiarFechaSesion_Click",
                    "Hubo un error con el botón cambiar fecha sesion", ex.Message);
            }
        }

        private void BtnAgendarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                FrmAgendarSesion frm = new FrmAgendarSesion
                {
                    TopLevel = false,
                    StartPosition = FormStartPosition.CenterParent
                };

                Form FormComprobado = this.ComprobarExistencia(frm);
                if (FormComprobado != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.Activate();
                }
                else
                {
                    this.panel1.Controls.Add(frm);
                    this.panel1.Tag = frm;
                    frm.Show();
                }
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnAgendarSesion_Click",
                    "Hubo un error con el botón agendar sesion", ex.Message);
            }
        }
        #endregion

        #region CUENTAS
        private void BtnCuentas_Click(object sender, EventArgs e)
        {
            MenuCuentas menuCuentas = new MenuCuentas();
            menuCuentas.btnEditarCuentas.Click += BtnEditarCuenta_Click;
            menuCuentas.btnObservarCuentas.Click += BtnObservarCuentas_Click;
            container = new PoperContainer(menuCuentas);
            container.Show(btnCuentas);
        }

        private void BtnObservarCuentas_Click(object sender, EventArgs e)
        {
            try
            {
                FrmObservarCuentas frm = new FrmObservarCuentas
                {
                    TopLevel = false,
                    StartPosition = FormStartPosition.CenterParent
                };

                Form FormComprobado = this.ComprobarExistencia(frm);
                if (FormComprobado != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.Activate();
                }
                else
                {
                    this.panel1.Controls.Add(frm);
                    this.panel1.Tag = frm;
                    frm.Show();
                }
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnObservarCuentas_Click",
                    "Hubo un error con el botón observar cuentas", ex.Message);
            }
        }

        private void BtnEditarCuenta_Click(object sender, EventArgs e)
        {
            try
            {
                FrmObservarCuentas frm = new FrmObservarCuentas
                {
                    TopLevel = false,
                    StartPosition = FormStartPosition.CenterParent,
                    IsEditar = true
                };

                Form FormComprobado = this.ComprobarExistencia(frm);
                if (FormComprobado != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.Activate();
                }
                else
                {
                    this.panel1.Controls.Add(frm);
                    this.panel1.Tag = frm;
                    frm.Show();
                }
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnObservarCuentas_Click",
                    "Hubo un error con el botón observar cuentas", ex.Message);
            }
        }
        #endregion

        #region CLIENTES

        private void BtnClientes_Click(object sender, EventArgs e)
        {
            MenuClientes menuClientes = new MenuClientes();
            menuClientes.btnAgregarCliente.Click += BtnAgregarCliente_Click;
            menuClientes.btnEditarCliente.Click += BtnEditarCliente_Click;
            menuClientes.btnObservarClientes.Click += BtnObservarClientes_Click;
            menuClientes.btnCargarClientes.Click += BtnCargarClientes_Click;
            menuClientes.btnInactivarClientes.Click += BtnInactivarClientes_Click;
            container = new PoperContainer(menuClientes);
            container.Show(btnClientes);
        }

        private void BtnInactivarClientes_Click(object sender, EventArgs e)
        {
            FrmObservarClientes frmObservarClientes = new FrmObservarClientes
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            frmObservarClientes.OnDgvDoubleClick += FrmObservarClientes_OnDgvDoubleClick1;
            frmObservarClientes.ShowDialog();
        }

        private void FrmObservarClientes_OnDgvDoubleClick1(object sender, EventArgs e)
        {
            ECliente eCliente = (ECliente)sender;
            Mensajes.MensajePregunta("Está seguro que desea inactivar el cliente " +
                (eCliente.Nombres + " " + eCliente.Apellidos) + "?", "Inactivar", "Cancelar", out DialogResult dialog);
            if (dialog == DialogResult.Yes)
            {
                eCliente.Estado = "INACTIVO";
                string rpta = ECliente.EditarCliente(eCliente.Id_cliente, eCliente);
                if (rpta.Equals("OK"))
                {
                    Mensajes.MensajeOkForm("Se inactivó el cliente correctamente");
                }
                else
                {
                    Mensajes.MensajeErrorCompleto(this.Name,
                        "FrmObservarClientes_OnDgvDoubleClick1",
                        "Hubo un error al inactivar el cliente", rpta);
                }
            }
        }

        private void BtnCargarClientes_Click(object sender, EventArgs e)
        {
            FrmCargarClientes frmCargarClientes = new FrmCargarClientes();
            frmCargarClientes.Show();
        }

        private void BtnObservarClientes_Click(object sender, EventArgs e)
        {
            try
            {
                FrmObservarClientes frm = new FrmObservarClientes
                {
                    TopLevel = false,
                    StartPosition = FormStartPosition.CenterParent
                };

                Form FormComprobado = this.ComprobarExistencia(frm);
                if (FormComprobado != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.Activate();
                }
                else
                {
                    this.panel1.Controls.Add(frm);
                    this.panel1.Tag = frm;
                    frm.Show();
                }
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnObservarClientes_Click",
                    "Hubo un error con el botón observar clientes", ex.Message);
            }
        }

        private void BtnEditarCliente_Click(object sender, EventArgs e)
        {
            FrmObservarClientes FrmObservarClientes = new FrmObservarClientes
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            FrmObservarClientes.OnDgvDoubleClick += FrmObservarClientes_OnDgvDoubleClick;
            FrmObservarClientes.ShowDialog();
        }

        private void FrmObservarClientes_OnDgvDoubleClick(object sender, EventArgs e)
        {
            try
            {
                ECliente cliente = (ECliente)sender;
                FrmNuevoCliente frm = new FrmNuevoCliente
                {
                    TopLevel = false,
                    IsEditar = true,
                    StartPosition = FormStartPosition.CenterParent
                };
                frm.AsignarDatos(cliente);
                Form FormComprobado = this.ComprobarExistencia(frm);
                if (FormComprobado != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.Activate();
                }
                else
                {
                    this.panel1.Controls.Add(frm);
                    this.panel1.Tag = frm;
                    frm.Show();
                }
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "FrmObservarClientes_OnDgvDoubleClick",
                    "Hubo un error con el botón editar cliente", ex.Message);
            }
        }

        private void BtnAgregarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                FrmNuevoCliente frm = new FrmNuevoCliente
                {
                    TopLevel = false,
                    StartPosition = FormStartPosition.CenterParent
                };

                Form FormComprobado = this.ComprobarExistencia(frm);
                if (FormComprobado != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.Activate();
                }
                else
                {
                    this.panel1.Controls.Add(frm);
                    this.panel1.Tag = frm;
                    frm.Show();
                }
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnAgregarCliente_Click",
                    "Hubo un error con el botón nuevo cliente", ex.Message);
            }
        }
        #endregion

        #region EMPLEADOS
        private void BtnEmpleados_Click(object sender, EventArgs e)
        {
            MenuEmpleados menuEmpleados = new MenuEmpleados();
            menuEmpleados.btnAgregarEmpleado.Click += BtnAgregarEmpleado_Click;
            menuEmpleados.btnEditarEmpleado.Click += BtnEditarEmpleado_Click;
            menuEmpleados.btnObservarEmpleados.Click += BtnObservarEmpleados_Click;
            container = new PoperContainer(menuEmpleados);
            container.Show(btnEmpleados);
        }

        private void BtnObservarEmpleados_Click(object sender, EventArgs e)
        {
            try
            {
                FrmObservarEmpleados frm = new FrmObservarEmpleados
                {
                    TopLevel = false,
                    StartPosition = FormStartPosition.CenterParent
                };

                Form FormComprobado = this.ComprobarExistencia(frm);
                if (FormComprobado != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.Activate();
                }
                else
                {
                    this.panel1.Controls.Add(frm);
                    this.panel1.Tag = frm;
                    frm.Show();
                }
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnObservarEmpleados_Click",
                    "Hubo un error con el botón observar empleados", ex.Message);
            }
        }

        private void BtnEditarEmpleado_Click(object sender, EventArgs e)
        {

            FrmObservarEmpleados FrmObservarEmpleados = new FrmObservarEmpleados
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            FrmObservarEmpleados.OnDgvDoubleClick += FrmObservarEmpleados_OnDgvDoubleClick;
            FrmObservarEmpleados.ShowDialog();
        }

        private void FrmObservarEmpleados_OnDgvDoubleClick(object sender, EventArgs e)
        {
            try
            {
                EEmpleado empleado = (EEmpleado)sender;
                FrmNuevoEmpleado frm = new FrmNuevoEmpleado
                {
                    TopLevel = false,
                    IsEditar = true,
                    StartPosition = FormStartPosition.CenterParent
                };
                frm.AsignarDatos(empleado);
                Form FormComprobado = this.ComprobarExistencia(frm);
                if (FormComprobado != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.Activate();
                }
                else
                {
                    this.panel1.Controls.Add(frm);
                    this.panel1.Tag = frm;
                    frm.Show();
                }
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "FrmObservarEmpleados_OnDgvDoubleClick",
                    "Hubo un error con el botón editar empleado", ex.Message);
            }
        }

        private void BtnAgregarEmpleado_Click(object sender, EventArgs e)
        {
            try
            {
                FrmNuevoEmpleado frm = new FrmNuevoEmpleado
                {
                    TopLevel = false,
                    StartPosition = FormStartPosition.CenterParent
                };

                Form FormComprobado = this.ComprobarExistencia(frm);
                if (FormComprobado != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.Activate();
                }
                else
                {
                    this.panel1.Controls.Add(frm);
                    this.panel1.Tag = frm;
                    frm.Show();
                }
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnAgregarEmpleado_Click",
                    "Hubo un error con el botón nuevo empleado", ex.Message);
            }
        }
        #endregion

        #region TARIFAS
        private void BtnTarifas_Click(object sender, EventArgs e)
        {
            MenuTarifas menuTarifas = new MenuTarifas();
            menuTarifas.btnAgregarTarifa.Click += BtnAgregarTarifa_Click;
            menuTarifas.btnEditarTarifa.Click += BtnEditarTarifa_Click;
            menuTarifas.btnObservarTarifas.Click += BtnObservarTarifas_Click;
            container = new PoperContainer(menuTarifas);
            container.Show(btnTarifas);
        }

        private void BtnObservarTarifas_Click(object sender, EventArgs e)
        {
            try
            {
                FrmObservarTarifas frm = new FrmObservarTarifas
                {
                    TopLevel = false,
                    StartPosition = FormStartPosition.CenterParent
                };

                Form FormComprobado = this.ComprobarExistencia(frm);
                if (FormComprobado != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.Activate();
                }
                else
                {
                    this.panel1.Controls.Add(frm);
                    this.panel1.Tag = frm;
                    frm.Show();
                }
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnObservarTarifas_Click",
                    "Hubo un error con el botón observar tarifa", ex.Message);
            }
        }

        private void BtnEditarTarifa_Click(object sender, EventArgs e)
        {
            FrmObservarTarifas FrmObservarTarifas = new FrmObservarTarifas
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            FrmObservarTarifas.OnDgvDoubleClick += FrmObservarTarifas_OnDgvDoubleClick;
            FrmObservarTarifas.ShowDialog();
        }

        private void FrmObservarTarifas_OnDgvDoubleClick(object sender, EventArgs e)
        {
            try
            {
                ETarifas tarifa = (ETarifas)sender;
                FrmAgregarTarifa frm = new FrmAgregarTarifa
                {
                    TopLevel = false,
                    IsEditar = true,
                    StartPosition = FormStartPosition.CenterParent
                };
                frm.AsignarDatos(tarifa);
                Form FormComprobado = this.ComprobarExistencia(frm);
                if (FormComprobado != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.Activate();
                }
                else
                {
                    this.panel1.Controls.Add(frm);
                    this.panel1.Tag = frm;
                    frm.Show();
                }
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "FrmObservarTarifas_OnDgvDoubleClick",
                    "Hubo un error con el botón editar tarifa", ex.Message);
            }
        }

        private void BtnAgregarTarifa_Click(object sender, EventArgs e)
        {
            try
            {
                FrmAgregarTarifa frm = new FrmAgregarTarifa
                {
                    TopLevel = false,
                    StartPosition = FormStartPosition.CenterParent
                };

                Form FormComprobado = this.ComprobarExistencia(frm);
                if (FormComprobado != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.Activate();
                }
                else
                {
                    this.panel1.Controls.Add(frm);
                    this.panel1.Tag = frm;
                    frm.Show();
                }
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnAgregarTarifa_Click",
                    "Hubo un error con el botón agregar tarifa", ex.Message);
            }
        }

        #endregion

        #region MEDIDAS

        private void BtnConfiguraciones_Click(object sender, EventArgs e)
        {
            MenuOtrasConfiguraciones menuOtrasConfiguraciones = new MenuOtrasConfiguraciones();

            menuOtrasConfiguraciones.OnBtnAgregarCanton += MenuOtrasConfiguraciones_OnBtnAgregarCanton;
            menuOtrasConfiguraciones.OnBtnEditarCanton += MenuOtrasConfiguraciones_OnBtnEditarCanton;
            menuOtrasConfiguraciones.OnBtnObservarCantones += MenuOtrasConfiguraciones_OnBtnObservarCantones;

            menuOtrasConfiguraciones.OnBtnAgregarParroquia += MenuOtrasConfiguraciones_OnBtnAgregarParroquia;
            menuOtrasConfiguraciones.OnBtnEditarParroquia += MenuOtrasConfiguraciones_OnBtnEditarParroquia;
            menuOtrasConfiguraciones.OnBtnObservarParroquias += MenuOtrasConfiguraciones_OnBtnObservarParroquias;

            menuOtrasConfiguraciones.OnBtnAgregarBarrio += MenuOtrasConfiguraciones_OnBtnAgregarBarrio;
            menuOtrasConfiguraciones.OnBtnEditarBarrio += MenuOtrasConfiguraciones_OnBtnEditarBarrio;
            menuOtrasConfiguraciones.OnBtnObservarBarrios += MenuOtrasConfiguraciones_OnBtnObservarBarrios;

            menuOtrasConfiguraciones.OnBtnAgregarMedida += MenuOtrasConfiguraciones_OnBtnAgregarMedida;
            menuOtrasConfiguraciones.OnBtnEditarMedida += MenuOtrasConfiguraciones_OnBtnEditarMedida;
            menuOtrasConfiguraciones.OnBtnObservarMedidas += MenuOtrasConfiguraciones_OnBtnObservarMedidas;

            menuOtrasConfiguraciones.OnBtnConfiguracionAvanzada += MenuOtrasConfiguraciones_OnBtnConfiguracionAvanzada;
            menuOtrasConfiguraciones.OnBtnConfiguracionAvanzada2 += MenuOtrasConfiguraciones_OnBtnConfiguracionAvanzada2;

            container = new PoperContainer(menuOtrasConfiguraciones);
            container.Show(btnConfiguraciones);
        }

        private void MenuOtrasConfiguraciones_OnBtnConfiguracionAvanzada2(object sender, EventArgs e)
        {
            try
            {
                FrmConfiguracionInicial frm = new FrmConfiguracionInicial
                {
                    TopLevel = false,
                    StartPosition = FormStartPosition.CenterParent
                };

                Form FormComprobado = this.ComprobarExistencia(frm);
                if (FormComprobado != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.Activate();
                }
                else
                {
                    this.panel1.Controls.Add(frm);
                    this.panel1.Tag = frm;
                    frm.Show();
                }
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "MenuOtrasConfiguraciones_OnBtnConfiguracionAvanzada2",
                    "Hubo un error con el botón configuraciones avanzadas", ex.Message);
            }
        }

        private void MenuOtrasConfiguraciones_OnBtnConfiguracionAvanzada(object sender, EventArgs e)
        {
            try
            {
                FrmConfiguracionAplicacion frm = new FrmConfiguracionAplicacion
                {
                    TopLevel = false,
                    StartPosition = FormStartPosition.CenterParent
                };

                Form FormComprobado = this.ComprobarExistencia(frm);
                if (FormComprobado != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.Activate();
                }
                else
                {
                    this.panel1.Controls.Add(frm);
                    this.panel1.Tag = frm;
                    frm.Show();
                }
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "MenuOtrasConfiguraciones_OnBtnConfiguracionAvanzada",
                    "Hubo un error con el botón configuraciones avanzadas", ex.Message);
            }
        }

        private void MenuOtrasConfiguraciones_OnBtnObservarMedidas(object sender, EventArgs e)
        {
            try
            {
                FrmObservarMedidas frm = new FrmObservarMedidas
                {
                    TopLevel = false,
                    StartPosition = FormStartPosition.CenterParent
                };

                Form FormComprobado = this.ComprobarExistencia(frm);
                if (FormComprobado != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.Activate();
                }
                else
                {
                    this.panel1.Controls.Add(frm);
                    this.panel1.Tag = frm;
                    frm.Show();
                }
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "MenuOtrasConfiguraciones_OnBtnObservarMedidas",
                    "Hubo un error con el botón observar medidas", ex.Message);
            }
        }

        private void MenuOtrasConfiguraciones_OnBtnEditarMedida(object sender, EventArgs e)
        {
            FrmObservarMedidas FrmObservarMedidas = new FrmObservarMedidas
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            FrmObservarMedidas.OnDgvDoubleClick += FrmObservarMedidas_OnDgvDoubleClick;
            FrmObservarMedidas.ShowDialog();
        }

        private void FrmObservarMedidas_OnDgvDoubleClick(object sender, EventArgs e)
        {
            try
            {
                EMedida medida = (EMedida)sender;
                FrmAgregarMedida frm = new FrmAgregarMedida
                {
                    TopLevel = false,
                    IsEditar = true,
                    StartPosition = FormStartPosition.CenterParent
                };
                frm.AsignarDatos(medida);
                Form FormComprobado = this.ComprobarExistencia(frm);
                if (FormComprobado != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.Activate();
                }
                else
                {
                    this.panel1.Controls.Add(frm);
                    this.panel1.Tag = frm;
                    frm.Show();
                }
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "FrmObservarMedidas_OnDgvDoubleClick",
                    "Hubo un error con el botón editar medida", ex.Message);
            }
        }

        private void MenuOtrasConfiguraciones_OnBtnAgregarMedida(object sender, EventArgs e)
        {
            try
            {
                FrmAgregarMedida frm = new FrmAgregarMedida
                {
                    TopLevel = false,
                    StartPosition = FormStartPosition.CenterParent
                };

                Form FormComprobado = this.ComprobarExistencia(frm);
                if (FormComprobado != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.Activate();
                }
                else
                {
                    this.panel1.Controls.Add(frm);
                    this.panel1.Tag = frm;
                    frm.Show();
                }
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "MenuOtrasConfiguraciones_OnBtnAgregarMedida",
                    "Hubo un error con el botón agregar medida", ex.Message);
            }
        }

        #endregion

        #region BARRIOS
        private void MenuOtrasConfiguraciones_OnBtnObservarBarrios(object sender, EventArgs e)
        {
            try
            {
                FrmObservarBarrios frm = new FrmObservarBarrios
                {
                    TopLevel = false,
                    StartPosition = FormStartPosition.CenterParent
                };

                Form FormComprobado = this.ComprobarExistencia(frm);
                if (FormComprobado != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.Activate();
                }
                else
                {
                    this.panel1.Controls.Add(frm);
                    this.panel1.Tag = frm;
                    frm.Show();
                }
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "MenuOtrasConfiguraciones_OnBtnObservarBarrios",
                    "Hubo un error con el botón observar barrios", ex.Message);
            }
        }

        private void MenuOtrasConfiguraciones_OnBtnEditarBarrio(object sender, EventArgs e)
        {
            FrmObservarBarrios FrmObservarBarrios = new FrmObservarBarrios
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            FrmObservarBarrios.OnDgvDoubleClick += FrmObservarBarrios_OnDgvDoubleClick;
            FrmObservarBarrios.ShowDialog();
        }

        private void FrmObservarBarrios_OnDgvDoubleClick(object sender, EventArgs e)
        {
            try
            {
                EBarrio barrio = (EBarrio)sender;
                FrmAgregarBarrio frm = new FrmAgregarBarrio
                {
                    TopLevel = false,
                    IsEditar = true,
                    StartPosition = FormStartPosition.CenterParent
                };
                frm.AsignarDatos(barrio);
                Form FormComprobado = this.ComprobarExistencia(frm);
                if (FormComprobado != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.Activate();
                }
                else
                {
                    this.panel1.Controls.Add(frm);
                    this.panel1.Tag = frm;
                    frm.Show();
                }
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "FrmObservarBarrios_OnDgvDoubleClick",
                    "Hubo un error con el botón agregar barrio", ex.Message);
            }
        }

        private void MenuOtrasConfiguraciones_OnBtnAgregarBarrio(object sender, EventArgs e)
        {
            try
            {
                FrmAgregarBarrio frm = new FrmAgregarBarrio
                {
                    TopLevel = false,
                    StartPosition = FormStartPosition.CenterParent
                };

                Form FormComprobado = this.ComprobarExistencia(frm);
                if (FormComprobado != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.Activate();
                }
                else
                {
                    this.panel1.Controls.Add(frm);
                    this.panel1.Tag = frm;
                    frm.Show();
                }
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "MenuOtrasConfiguraciones_OnBtnAgregarBarrio",
                    "Hubo un error con el botón agregar barrio", ex.Message);
            }
        }
        #endregion

        #region PARROQUIAS

        private void MenuOtrasConfiguraciones_OnBtnObservarParroquias(object sender, EventArgs e)
        {
            try
            {
                FrmObservarParroquias frm = new FrmObservarParroquias
                {
                    TopLevel = false,
                    StartPosition = FormStartPosition.CenterParent
                };

                Form FormComprobado = this.ComprobarExistencia(frm);
                if (FormComprobado != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.Activate();
                }
                else
                {
                    this.panel1.Controls.Add(frm);
                    this.panel1.Tag = frm;
                    frm.Show();
                }
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "MenuOtrasConfiguraciones_OnBtnObservarParroquias",
                    "Hubo un error con el botón observar parroquias", ex.Message);
            }
        }

        private void MenuOtrasConfiguraciones_OnBtnEditarParroquia(object sender, EventArgs e)
        {
            FrmObservarParroquias FrmObservarParroquias = new FrmObservarParroquias
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            FrmObservarParroquias.OnDgvDoubleClick += FrmObservarParroquias_OnDgvDoubleClick;
            FrmObservarParroquias.ShowDialog();
        }

        private void FrmObservarParroquias_OnDgvDoubleClick(object sender, EventArgs e)
        {
            try
            {
                EParroquia parroquia = (EParroquia)sender;
                FrmAgregarParroquia frm = new FrmAgregarParroquia
                {
                    TopLevel = false,
                    IsEditar = true,
                    StartPosition = FormStartPosition.CenterParent
                };
                frm.AsignarDatos(parroquia);
                Form FormComprobado = this.ComprobarExistencia(frm);
                if (FormComprobado != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.Activate();
                }
                else
                {
                    this.panel1.Controls.Add(frm);
                    this.panel1.Tag = frm;
                    frm.Show();
                }
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "FrmObservarParroquias_OnDgvDoubleClick",
                    "Hubo un error con el botón agregar parroquia", ex.Message);
            }
        }

        private void MenuOtrasConfiguraciones_OnBtnAgregarParroquia(object sender, EventArgs e)
        {
            try
            {
                FrmAgregarParroquia frm = new FrmAgregarParroquia
                {
                    TopLevel = false,
                    StartPosition = FormStartPosition.CenterParent
                };

                Form FormComprobado = this.ComprobarExistencia(frm);
                if (FormComprobado != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.Activate();
                }
                else
                {
                    this.panel1.Controls.Add(frm);
                    this.panel1.Tag = frm;
                    frm.Show();
                }
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "MenuOtrasConfiguraciones_OnBtnAgregarParroquia",
                    "Hubo un error con el botón agregar parroquia", ex.Message);
            }
        }

        #endregion

        #region CANTONES
        private void MenuOtrasConfiguraciones_OnBtnObservarCantones(object sender, EventArgs e)
        {
            try
            {
                FrmObservarCantones frm = new FrmObservarCantones
                {
                    TopLevel = false,
                    StartPosition = FormStartPosition.CenterParent
                };

                Form FormComprobado = this.ComprobarExistencia(frm);
                if (FormComprobado != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.Activate();
                }
                else
                {
                    this.panel1.Controls.Add(frm);
                    this.panel1.Tag = frm;
                    frm.Show();
                }
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "MenuOtrasConfiguraciones_OnBtnObservarCantones",
                    "Hubo un error con el botón observar cantones", ex.Message);
            }
        }

        private void MenuOtrasConfiguraciones_OnBtnEditarCanton(object sender, EventArgs e)
        {
            FrmObservarCantones frmObservarCantones = new FrmObservarCantones
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            frmObservarCantones.OnDgvDoubleClick += FrmObservarCantones_OnDgvDoubleClick; ;
            frmObservarCantones.ShowDialog();
        }

        private void FrmObservarCantones_OnDgvDoubleClick(object sender, EventArgs e)
        {
            try
            {
                ECanton can = (ECanton)sender;
                FrmAgregarCanton frm = new FrmAgregarCanton
                {
                    TopLevel = false,
                    IsEditar = true,
                    StartPosition = FormStartPosition.CenterParent
                };
                frm.AsignarDatos(can);
                Form FormComprobado = this.ComprobarExistencia(frm);
                if (FormComprobado != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.Activate();
                }
                else
                {
                    this.panel1.Controls.Add(frm);
                    this.panel1.Tag = frm;
                    frm.Show();
                }
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "FrmObservarCantones_OnDgvDoubleClick",
                    "Hubo un error con el botón agregar canton", ex.Message);
            }
        }

        private void MenuOtrasConfiguraciones_OnBtnAgregarCanton(object sender, EventArgs e)
        {
            try
            {
                FrmAgregarCanton frm = new FrmAgregarCanton
                {
                    TopLevel = false,
                    StartPosition = FormStartPosition.CenterParent
                };

                Form FormComprobado = this.ComprobarExistencia(frm);
                if (FormComprobado != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.Activate();
                }
                else
                {
                    this.panel1.Controls.Add(frm);
                    this.panel1.Tag = frm;
                    frm.Show();
                }
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "MenuOtrasConfiguraciones_OnBtnAgregarCanton",
                    "Hubo un error con el botón agregar canton", ex.Message);
            }
        }
        #endregion

        #region LECTURAS

        private void BtnLecturas_Click(object sender, EventArgs e)
        {
            MenuLecturas menuLecturas = new MenuLecturas();
            menuLecturas.btnModificarLectura.Click += BtnModificarLectura_Click;
            container = new PoperContainer(menuLecturas);
            container.Show(btnLecturas);
        }

        private void BtnModificarLectura_Click(object sender, EventArgs e)
        {
            FrmPlanillaLecturas frmPlanillaLecturas = new FrmPlanillaLecturas
            {
                IsEditar = true
            };
            frmPlanillaLecturas.AsignarDatosEditar();
            frmPlanillaLecturas.ShowDialog();         
        }

        #endregion

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

            if (container != null)
                container.Close();

            return frmDevolver;
        }
    }
}
