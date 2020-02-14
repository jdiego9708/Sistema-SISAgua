using CapaEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaPresentacionAdministracion.Formularios.FormsAgendamientoSesiones;
using CapaPresentacionAdministracion.Formularios.FormsClientes;
using System.Configuration;

namespace CapaPresentacionAdministracion.Formularios.FormsSesiones
{
    public partial class FrmNuevaSesion : Form
    {
        PoperContainer container;
        public FrmNuevaSesion()
        {
            InitializeComponent();
            this.Load += FrmNuevaSesion_Load;
            this.btnTerminarSesion.Click += BtnTerminarSesion_Click;
        }

        List<EMedidor> ClientesSeleccionados;

        private void BtnTerminarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.FrmObservarClientes != null)
                {
                    ESesiones eSesion = new ESesiones
                    {
                        Fecha_sesion = DateTime.Now,
                        Hora_sesion = DateTime.Now.ToShortTimeString(),
                        Titulo_sesion = this.EAgendamientoSesion.Titulo,
                        Descripcion_sesion = this.txtDescripcion.Text,
                        Documento_adjunto = ""
                    };

                    string rpta = ESesiones.InsertarSesion(eSesion, out int id_sesion);
                    if (rpta.Equals("OK"))
                    {
                        eSesion.Id_sesion = id_sesion;

                        foreach (EMedidor medidor in ClientesSeleccionados)
                        {
                            EDetalleSesiones eDetalleSesion = new EDetalleSesiones
                            {
                                ESesion = eSesion,
                                ECliente = medidor.DireccionCliente.ECliente,
                                Estado = "NO ASISTE"
                            };

                            rpta = EDetalleSesiones.InsertarDetalleSesiones(eDetalleSesion);
                            if (rpta.Equals("OK"))
                            {
                                ECuentas eCuenta = new ECuentas
                                {
                                    ECliente = medidor.DireccionCliente.ECliente,
                                    ETarifa = this.ETarifaSesion,
                                    EMedidor = medidor,
                                    Fecha_cuenta = DateTime.Now,
                                    Estado_cuenta = "PENDIENTE DE PAGO",
                                    Iva = 0,
                                    Descuento = 0,
                                    Motivo_descuento = "",
                                    Total_pagar = this.ETarifaSesion.Valor_tarifa,
                                    Fecha_pago = DateTime.Now
                                };

                                rpta = ECuentas.InsertarCuenta(eCuenta, out int id_cuenta);
                                if (!rpta.Equals("OK"))
                                    throw new Exception("Hubo un error al insertar una cuenta de sesión, " + rpta);
                            }
                            else
                                throw new Exception("Hubo un error al insertar un detalle de sesión, " + rpta);
                        }

                        if (rpta.Equals("OK"))
                        {
                            this.EAgendamientoSesion.Estado = "TERMINADO";
                            rpta = EAgendamientoSesion.EditarAgendamiento(this.EAgendamientoSesion, this.EAgendamientoSesion.Id_agendamiento);
                            if (rpta.Equals("OK"))
                            {
                                Mensajes.MensajeOkForm("La sesión ha sido finalizada correctamente!");
                                this.Close();
                            }
                            else
                            {
                                Mensajes.MensajeInformacion("Todos los datos de la sesión se guardaron correctamente " +
                                    "pero no se pudo actualizar el agendamiento de la sesión", "Entendido");
                                this.Close();
                            }                            
                        }

                    }
                    else
                        throw new Exception("Hubo un error al insertar la sesión, " + rpta);
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnTerminarSesion_Click",
                    "Hubo un error al terminar la sesión", ex.Message);
            }
        }

        FrmObservarClientes FrmObservarClientes;

        DataTable dtClientesSeleccionados;

        private void CrearTablaClientesSeleccionados()
        {
            this.dtClientesSeleccionados = new DataTable("ClientesSeleccionados");
            this.dtClientesSeleccionados.Columns.Add("Id_medidor", typeof(string));
            this.dtClientesSeleccionados.Columns.Add("Medidor", typeof(string));
            this.dtClientesSeleccionados.Columns.Add("Id_cliente", typeof(string));
            this.dtClientesSeleccionados.Columns.Add("Cliente", typeof(string));
            this.dtClientesSeleccionados.Columns.Add("Tarifa", typeof(string));

            this.dgvClientesSeleccionados.DataSource = dtClientesSeleccionados;
            this.dgvClientesSeleccionados.Columns["Id_medidor"].Visible = false;
            this.dgvClientesSeleccionados.Columns["Id_cliente"].Visible = false;

            this.dgvClientesSeleccionados.DoubleClick += DgvClientesSeleccionados_DoubleClick;
        }

        private void DgvClientesSeleccionados_DoubleClick(object sender, EventArgs e)
        {
            if (dgvClientesSeleccionados.Rows.Count > 0)
            {
                DataGridViewRow rowDgv = this.dgvClientesSeleccionados.CurrentRow;
                int id_medidor = Convert.ToInt32(rowDgv.Cells["Id_medidor"].Value);

                foreach(DataRow row in this.dtClientesSeleccionados.Rows)
                {
                    if (id_medidor == Convert.ToInt32(row["Id_medidor"]))
                    {
                        dtClientesSeleccionados.Rows.Remove(row);
                        break;
                    }
                }

                foreach (EMedidor eMedidor in this.ClientesSeleccionados)
                {
                    if (id_medidor == eMedidor.Id_medidor)
                    {
                        ClientesSeleccionados.Remove(eMedidor);
                        break;
                    }
                }

            }
        }

        private void AddClient(EMedidor eMedidor)
        {
            if (this.dtClientesSeleccionados != null)
            {
                DataRow row = this.dtClientesSeleccionados.NewRow();
                row["Id_medidor"] = eMedidor.Id_medidor;
                row["Medidor"] = eMedidor.Medidor;
                row["Id_cliente"] = eMedidor.DireccionCliente.ECliente.Id_cliente;
                row["Cliente"] = eMedidor.DireccionCliente.ECliente.Nombres + " " +
                    eMedidor.DireccionCliente.ECliente.Apellidos;
                row["Tarifa"] = "$" + this.ETarifaSesion.Valor_tarifa.ToString("N2");
                this.dtClientesSeleccionados.Rows.Add(row);
                this.ClientesSeleccionados.Add(eMedidor);
                this.dgvClientesSeleccionados.Refresh();
            }
        }

        private void RemoveClient(EMedidor eMedidor)
        {
            if (this.dtClientesSeleccionados != null)
            {
                foreach (DataRow row in dtClientesSeleccionados.Rows)
                {
                    int id_medidor = Convert.ToInt32(row["Id_medidor"]);
                    if (id_medidor == eMedidor.Id_medidor)
                    {
                        dtClientesSeleccionados.Rows.Remove(row);
                        break;
                    }
                }

                foreach (EMedidor Medidor in this.ClientesSeleccionados)
                {
                    if (Medidor.Id_medidor == eMedidor.Id_medidor)
                    {
                        ClientesSeleccionados.Remove(Medidor);
                        break;
                    }
                }
            }
        }

        ETarifas ETarifaSesion;

        private void FrmNuevaSesion_Load(object sender, EventArgs e)
        {
            if (int.TryParse(ConfigurationManager.AppSettings["Id_tarifa_predeterminada_sesion"].ToString(), out int id_tarifa))
            {
                DataTable dtTarifa = ETarifas.BuscarTarifas("ID TARIFA", id_tarifa.ToString(), out string rpta);
                if (dtTarifa != null)
                {
                    this.CrearTablaClientesSeleccionados();
                    ETarifas eTarifa = new ETarifas(dtTarifa, 0);
                    this.ETarifaSesion = eTarifa;
                    this.ClientesSeleccionados = new List<EMedidor>();
                    this.FrmObservarClientes = new FrmObservarClientes
                    {
                        Dock = DockStyle.Fill,
                        FormBorderStyle = FormBorderStyle.None,
                        IsSesion = true,
                        TopLevel = false,
                        IsLectura = true
                    };
                    this.FrmObservarClientes.OnBtnNextClick += FrmObservarClientes_OnBtnNextClick;
                    this.panelClientes.Controls.Add(FrmObservarClientes);
                    FrmObservarClientes.Show();
                }
                else
                {
                    Mensajes.MensajeInformacion("La tarifa predeterminada para la sesión no está establecida " +
                                "en la base de datos, verifique la tarifa en configuración de sesiones", "Entendido");
                    this.Close();
                }
            }
            else
            {
                Mensajes.MensajeInformacion("La tarifa predeterminada para la sesión no está establecida en " +
                            "el archivo de configuración, verifique la tarifa en configuración de sesiones", "Entendido");
                this.Close();
            }
        }

        private void FrmObservarClientes_OnBtnNextClick(object sender, EventArgs e)
        {
            if (this.ClientesSeleccionados != null)
            {
                EMedidor eMedidor = (EMedidor)sender;
                bool existe = false;

                foreach (EMedidor Medidor in this.ClientesSeleccionados)
                {
                    if (Medidor.Id_medidor == eMedidor.Id_medidor)
                    {
                        existe = true;
                        break;
                    }
                }

                if (existe)
                {
                    Mensajes.MensajePregunta("El cliente ya se encuentra seleccionado, ¿desea eliminarlo de la lista?",
                        "Eliminar", "Cancelar", out DialogResult dialog);
                    if (dialog == DialogResult.Yes)
                    {                        
                        this.RemoveClient(eMedidor);
                    }
                }
                else
                {
                    this.AddClient(eMedidor);
                }
            }
        }

        public void AsignarAgendamiento(EAgendamientoSesion eAgendamiento)
        {
            EAgendamientoSesion = eAgendamiento;
            AgendamientoSesionSmall agendamientoSesionSmall = new AgendamientoSesionSmall();
            agendamientoSesionSmall.AsignarDatos(eAgendamiento);
            this.container = new PoperContainer(agendamientoSesionSmall);
            this.btnSeleccionar.MouseEnter += BtnSeleccionar_MouseEnter;
            this.btnSeleccionar.MouseLeave += BtnSeleccionar_MouseLeave;
        }

        private void BtnSeleccionar_MouseLeave(object sender, EventArgs e)
        {
            if (this.container.Visible)
                this.container.Close();
        }

        private void BtnSeleccionar_MouseEnter(object sender, EventArgs e)
        {
            if (this.container != null)
                this.container.Show(btnSeleccionar);
        }

        EAgendamientoSesion EAgendamientoSesion;

    }
}
