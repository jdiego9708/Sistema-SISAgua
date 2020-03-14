using CapaEntidades;
using CapaPresentacionAdministracion.Formularios.FormsClientes;
using CapaPresentacionAdministracion.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacionAdministracion.Formularios.FormsCuentas
{
    public partial class FrmObservarCuentas : Form
    {
        public FrmObservarCuentas()
        {
            InitializeComponent();
            this.btnSeleccionar.Click += BtnSeleccionar_Click;
        }

        public void BuscarCuentas(string tipo_busqueda, string texto_busqueda1,
            string texto_busqueda2)
        {
            try
            {
                DataTable dtCuentas =
                    ECuentas.BuscarCuentas(tipo_busqueda, texto_busqueda1, texto_busqueda2, out string rpta);
                this.panel1.Limpiar();
                if (dtCuentas != null)
                {
                    int contador = 0;
                    this.panel1.BackgroundImage = null;
                    List<UserControl> controls = new List<UserControl>();
                    foreach (DataRow row in dtCuentas.Rows)
                    {
                        ECuentas eCuenta = new ECuentas(row);
                        CuentaLarge cuentaLarge = new CuentaLarge
                        {
                            IsCaja = this.IsCaja,
                            IsEditar = this.IsEditar
                        };
                        cuentaLarge.OnCuentasRefresh += CuentaLarge_OnCuentasRefresh;
                        cuentaLarge.OnAbonoRefresh += CuentaLarge_OnAbonoRefresh;
                        cuentaLarge.AsignarDatos(eCuenta);
                        controls.Add(cuentaLarge);

                        contador += 1;
                        if (contador == 12)
                            break;
                    }
                    this.panel1.AddArrayControl(controls);
                }
                else
                {
                    this.panel1.BackgroundImage = Resources.No_hay_cuentas_x2;

                    if (!rpta.Equals("OK"))
                        throw new Exception(rpta);
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BuscarCuentas",
                    "Hubo un error al buscar cuentas", ex.Message);
            }
        }

        private void CuentaLarge_OnAbonoRefresh(object sender, EventArgs e)
        {
            EDetalleAbonosCuentas eAbono = (EDetalleAbonosCuentas)sender;
            OnCuentaSuccess?.Invoke(eAbono.Valor_abono, e);
        }

        private void CuentaLarge_OnCuentasRefresh(object sender, EventArgs e)
        {
            EPago_cuenta ePago = (EPago_cuenta)sender;

            OnCuentaSuccess?.Invoke(ePago.ECuenta.Total_pagar, e);

            if (this.btnSeleccionar.Tag != null)
            {
                //ECliente eCliente = (ECliente)this.btnSeleccionar.Tag;
                //this.BuscarCuentas("ID CLIENTE", eCliente.Id_cliente.ToString(), "");
            }
            else
            {
                this.Close();
            }
        }

        private void BtnSeleccionar_Click(object sender, EventArgs e)
        {
            FrmObservarClientes frmObservarClientes = new FrmObservarClientes
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            frmObservarClientes.OnDgvDoubleClick += FrmObservarClientes_OnDgvDoubleClick;
            frmObservarClientes.ShowDialog();
        }

        private void FrmObservarClientes_OnDgvDoubleClick(object sender, EventArgs e)
        {
            ECliente eCliente = (ECliente)sender;
            this.btnSeleccionar.Text = eCliente.Nombres + " " + eCliente.Apellidos;
            this.btnSeleccionar.Tag = eCliente;
            this.BuscarCuentas("ID CLIENTE", eCliente.Id_cliente.ToString(), "");
        }

        private bool _isCaja;
        private bool _isEditar;
        public event EventHandler OnCuentaSuccess;

        public bool IsCaja { get => _isCaja; set => _isCaja = value; }
        public bool IsEditar { get => _isEditar; set => _isEditar = value; }
    }
}
