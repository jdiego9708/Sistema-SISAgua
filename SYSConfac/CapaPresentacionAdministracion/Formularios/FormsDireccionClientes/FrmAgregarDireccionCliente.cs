using CapaEntidades;
using CapaPresentacionAdministracion.Formularios.FormsClientes;
using System;
using System.Windows.Forms;

namespace CapaPresentacionAdministracion.Formularios.FormsDireccionClientes
{
    public partial class FrmAgregarDireccionCliente : Form
    {
        public FrmAgregarDireccionCliente()
        {
            InitializeComponent();
            this.Load += FrmAgregarDireccionCliente_Load;
            this.listaCantones.SelectedIndexChanged += ListaCantones_SelectedIndexChanged;
            this.btnGuardar.Click += BtnGuardar_Click;
            this.btnCliente.Click += BtnCliente_Click;
        }

        public EDireccionCliente eDireccionCliente;

        public void AsignarDatos(EDireccionCliente direccion)
        {
            this.eDireccionCliente = direccion;
            this.btnCliente.Text = direccion.ECliente.Nombres + " " + direccion.ECliente.Apellidos;
            this.btnCliente.Tag = direccion.ECliente.Id_cliente;
            this.btnCliente.Enabled = false;

            this.txtDireccion.Text = direccion.Direccion;

            this.listaCantones.DataSource = ECanton.BuscarCantones("COMPLETO", "", out string rpta);
            this.listaCantones.ValueMember = "Id_canton";
            this.listaCantones.DisplayMember = "Nombre_canton";
            this.listaCantones.SelectedValue = direccion.EBarrio.EParroquia.ECanton.Id_canton;

            this.listaParroquias.DataSource = EParroquia.BuscarParroquias("COMPLETO", "", out rpta);
            this.listaParroquias.ValueMember = "Id_parroquia";
            this.listaParroquias.DisplayMember = "Nombre_parroquia";
            this.listaParroquias.SelectedValue = direccion.EBarrio.EParroquia.Id_parroquia;

            this.listaBarrios.DataSource = EBarrio.BuscarBarrios("COMPLETO", "", out rpta);
            this.listaBarrios.ValueMember = "Id_barrio";
            this.listaBarrios.DisplayMember = "Nombre_barrio";
            this.listaBarrios.SelectedValue = direccion.EBarrio.Id_barrio;

            if (direccion.Tipo_establecimiento.Equals("VIVIENDA"))
                this.rdVivienda.Checked = true;
            else
                this.rdComercial.Checked = true;
        }

        private void BtnCliente_Click(object sender, EventArgs e)
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
            ECliente cliente = (ECliente)sender;
            this.ObtenerCliente(cliente.Id_cliente, cliente.Nombres + " " + cliente.Apellidos);
        }

        private bool Comprobaciones(out EDireccionCliente eDireccionCliente)
        {
            bool result = true;
            eDireccionCliente = new EDireccionCliente();

            if (this.txtDireccion.Text.Equals(""))
            {
                result = false;
                this.errorProvider1.SetIconPadding(this.txtDireccion, -25);
                this.errorProvider1.SetError(this.txtDireccion, "Campo obligatorio");
            }

            if (this.listaCantones.Text.Equals(""))
            {
                result = false;
                this.errorProvider1.SetError(this.listaCantones, "Campo obligatorio");
            }

            if (this.listaParroquias.Text.Equals(""))
            {
                result = false;
                this.errorProvider1.SetError(this.listaParroquias, "Campo obligatorio");
            }

            if (this.listaBarrios.Text.Equals(""))
            {
                result = false;
                this.errorProvider1.SetError(this.listaBarrios, "Campo obligatorio");
            }

            string tipo_establecimiento = "";
            foreach (Control control in this.gbTipoEstablecimiento.Controls)
            {
                if (control is RadioButton rd)
                {
                    if (rd.Checked)
                    {
                        tipo_establecimiento = rd.Text.ToUpper();
                        break;
                    }
                }
            }

            if (tipo_establecimiento.Equals(""))
            {
                result = false;
                this.errorProvider1.SetError(this.rdVivienda, "Seleccione una opción");
            }

            if (result)
            {
                eDireccionCliente.ECliente = new ECliente();
                eDireccionCliente.ECliente.Id_cliente = Convert.ToInt32(this.btnCliente.Tag);
                eDireccionCliente.Direccion = this.txtDireccion.Text;
                eDireccionCliente.EBarrio = new EBarrio();
                eDireccionCliente.EBarrio.Id_barrio = Convert.ToInt32(this.listaBarrios.SelectedValue);
                eDireccionCliente.Tipo_establecimiento = tipo_establecimiento;
                eDireccionCliente.Estado = "ACTIVO";
            }

            return result;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Comprobaciones(out EDireccionCliente direccionCliente))
                {
                    int id_direccion = 0;
                    string rpta = "";
                    string mensaje = "";

                    if (this.IsEditar)
                    {
                        rpta = EDireccionCliente.EditarDireccion(this.eDireccionCliente.Id_direccion, direccionCliente);
                        mensaje = "Se actualizó correctamente la dirección";
                    }
                    else
                    {
                        rpta = EDireccionCliente.InsertarDireccion(out id_direccion, direccionCliente);
                        mensaje = "Se agregó correctamente la dirección";
                    }

                    if (rpta.Equals("OK"))
                    {
                        direccionCliente.Id_direccion = id_direccion;
                        this.eDireccionCliente = direccionCliente;
                        this.OnClientSaved?.Invoke(this, e);
                        Mensajes.MensajeOkForm(mensaje);
                        this.Close();
                    }
                    else
                    {
                        throw new Exception(rpta);
                    }
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnGuardar_Click",
                    "Hubo un error al guardar la dirección", ex.Message);
            }
        }

        private void ListaCantones_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;

            string valuecb = Convert.ToString(cb.SelectedValue);
            if (int.TryParse(valuecb, out int id_canton))
            {
                this.listaParroquias.DataSource =
                    EParroquia.BuscarParroquias("ID CANTON", id_canton.ToString(), out string rpta);
                this.listaParroquias.ValueMember = "Id_parroquia";
                this.listaParroquias.DisplayMember = "Nombre";
            }
        }

        private void FrmAgregarDireccionCliente_Load(object sender, EventArgs e)
        {
            if (!this.IsEditar)
            {
                this.listaCantones.DataSource = ECanton.BuscarCantones("COMPLETO", "", out string rpta);
                this.listaCantones.ValueMember = "Id_canton";
                this.listaCantones.DisplayMember = "Nombre_canton";

                this.listaParroquias.DataSource = EParroquia.BuscarParroquias("COMPLETO", "", out rpta);
                this.listaParroquias.ValueMember = "Id_parroquia";
                this.listaParroquias.DisplayMember = "Nombre_parroquia";

                this.listaBarrios.DataSource = EBarrio.BuscarBarrios("COMPLETO", "", out rpta);
                this.listaBarrios.ValueMember = "Id_barrio";
                this.listaBarrios.DisplayMember = "Nombre_barrio";
            }
        }

        public void ObtenerCliente(int id_cliente, string nombre_cliente)
        {
            this.btnCliente.Tag = id_cliente;
            this.btnCliente.Text = nombre_cliente;
        }

        public event EventHandler OnClientSaved;

        private bool _isEditar;

        public bool IsEditar { get => _isEditar; set => _isEditar = value; }
    }
}
