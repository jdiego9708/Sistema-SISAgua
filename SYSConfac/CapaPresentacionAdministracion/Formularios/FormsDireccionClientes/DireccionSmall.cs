using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;

using CapaPresentacionAdministracion.Formularios.FormsMedidores;

namespace CapaPresentacionAdministracion.Formularios.FormsDireccionClientes
{
    public partial class DireccionSmall : UserControl
    {
        PoperContainer container;
        public DireccionSmall()
        {
            InitializeComponent();
            this.btnEditar.Click += BtnEditar_Click;
            this.btnEliminar.Click += BtnEliminar_Click;
            this.btnSiguiente.Click += BtnSiguiente_Click;
            this.btnMedidores.Click += BtnMedidores_Click;
        }

        private void BtnMedidores_Click(object sender, EventArgs e)
        {
            FrmObservarMedidores FrmObservarMedidores = new FrmObservarMedidores
            {
                Dock = DockStyle.Fill,
                FormBorderStyle = FormBorderStyle.None,
                TopLevel = false,
                Id_direccion = eDireccionCliente.Id_direccion
            };
            FrmObservarMedidores.OnBtnMedidorSmallAgregarMedidor += FrmObservarMedidores_OnBtnMedidorSmallAgregarMedidor;
            PoperContainer container = new PoperContainer(FrmObservarMedidores);
            container.Show(this.btnMedidores);
            FrmObservarMedidores.Show();
        }

        private void FrmObservarMedidores_OnBtnMedidorSmallAgregarMedidor(object sender, EventArgs e)
        {
            FrmAgregarMedidorCliente frmAgregarMedidor = new FrmAgregarMedidorCliente
            {
                Dock = DockStyle.Fill,
                FormBorderStyle = FormBorderStyle.None,
                TopLevel = false,
                Id_direccion = eDireccionCliente.Id_direccion
            };
            PoperContainer container = new PoperContainer(frmAgregarMedidor);
            container.Show(this.btnMedidores);
            frmAgregarMedidor.Show();
        }

        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            if (this.IsObservarLectura)
            {
                OnBtnNextClick?.Invoke(this.eDireccionCliente, e);
                return;
            }

            FrmObservarMedidores observarMedidores = new FrmObservarMedidores
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill,
                Id_direccion = eDireccionCliente.Id_direccion
            };
            observarMedidores.OnBtnMedidorSmallSiguiente += ObservarMedidores_OnBtnMedidorSmallSiguiente;
            observarMedidores.OnBtnMedidorSmallAgregarMedidor += ObservarMedidores_OnBtnMedidorSmallAgregarMedidor;
            container = new PoperContainer(observarMedidores);
            container.Show(this.btnSiguiente);
            observarMedidores.Show();
        }

        private void ObservarMedidores_OnBtnMedidorSmallAgregarMedidor(object sender, EventArgs e)
        {
            FrmAgregarMedidorCliente frmAgregarMedidor = new FrmAgregarMedidorCliente
            {
                Dock = DockStyle.Fill,
                FormBorderStyle = FormBorderStyle.None,
                TopLevel = false,
                Id_direccion = eDireccionCliente.Id_direccion
            };
            PoperContainer container = new PoperContainer(frmAgregarMedidor);
            container.Show(this.btnMedidores);
            frmAgregarMedidor.Show();
        }

        private void ObservarMedidores_OnBtnMedidorSmallSiguiente(object sender, EventArgs e)
        {
            if (this.IsLectura)
                this.container.Close();

            OnBtnNextClick?.Invoke(sender, e);
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            Mensajes.MensajePregunta("¿Está seguro que desea eliminar esta dirección?", "Eliminar", "Cancelar", out DialogResult dialog);
            if (dialog == DialogResult.Yes)
            {
                string rpta = EDireccionCliente.InactivarDireccion(this.eDireccionCliente.Id_direccion);
                if (rpta.Equals("OK"))
                {
                    Mensajes.MensajeOkForm("Se eliminó la dirección correctamente");
                    this.OnClientSaved?.Invoke(eDireccionCliente, e);
                }
                else
                {
                    Mensajes.MensajeErrorCompleto(this.Name, "BtnEliminar_Click(object sender, EventArgs e)",
                        "Hubo un error al eliminar/inactivar una dirección", rpta);
                }
            }
        }

        public event EventHandler OnClientSaved;

        public event EventHandler OnBtnNextClick;

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            FrmAgregarDireccionCliente frmAgregarDireccionCliente = new FrmAgregarDireccionCliente
            {
                FormBorderStyle = FormBorderStyle.None,
                TopLevel = false,
                Dock = DockStyle.Fill,
                IsEditar = true
            };
            frmAgregarDireccionCliente.AsignarDatos(eDireccionCliente);
            frmAgregarDireccionCliente.OnClientSaved += FrmAgregarDireccionCliente_OnClientSaved;
            PoperContainer container = new PoperContainer(frmAgregarDireccionCliente);
            container.Show(this.btnEditar);
            frmAgregarDireccionCliente.Show();
        }

        private void FrmAgregarDireccionCliente_OnClientSaved(object sender, EventArgs e)
        {
            this.OnClientSaved?.Invoke(eDireccionCliente, e);
        }

        public EDireccionCliente eDireccionCliente;

        public void AsignarDatos(EDireccionCliente direccionCliente)
        {
            this.eDireccionCliente = direccionCliente;
            this.txtDireccion.Text = direccionCliente.Direccion;
            this.txtCanton.Text = direccionCliente.EBarrio.EParroquia.ECanton.Nombre;
            this.txtParroquia.Text = direccionCliente.EBarrio.EParroquia.Nombre;
            this.txtBarrio.Text = direccionCliente.EBarrio.Nombre;
            this.lblTipoEstablecimiento.Text = direccionCliente.Tipo_establecimiento;

            if (this.GbOpcionesVisible)
                this.gbOpciones.Visible = true;
            else
                this.gbOpciones.Visible = false;

            if (this.IsLectura)
            {
                this.btnSiguiente.Visible = true;
                this.btnMedidores.Visible = false;
            }
            else
            {
                this.btnSiguiente.Visible = false;
                this.btnMedidores.Visible = true;
            }
        }

        private bool _isLectura = false;
        private bool _isObservarLectura = false;
        private bool _gbOpcionesVisible = true;

        public bool IsLectura { get => _isLectura; set => _isLectura = value; }
        public bool IsObservarLectura { get => _isObservarLectura; set => _isObservarLectura = value; }
        public bool GbOpcionesVisible { get => _gbOpcionesVisible; set => _gbOpcionesVisible = value; }
    }
}
