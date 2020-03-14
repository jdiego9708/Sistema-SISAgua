using CapaPresentacionAdministracion.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaEntidades;

namespace CapaPresentacionAdministracion.Formularios.FormsClientes
{
    public partial class FrmNuevoCliente : Form
    {
        public FrmNuevoCliente()
        {
            InitializeComponent();
            this.txtCorreo.LostFocus += TxtCorreo_LostFocus;
            this.btnGuardar.Click += BtnGuardar_Click;
            this.Load += FrmNuevoCliente_Load;
        }

        private void FrmNuevoCliente_Load(object sender, EventArgs e)
        {
            this.txtCelular.MaxLength = 10;
        }

        public ECliente ECliente;

        public void AsignarDatos(ECliente eCliente)
        {
            this.ECliente = eCliente;
            if (eCliente != null)
            {
                this.txtNombres.Text = eCliente.Nombres;
                this.txtApellidos.Text = eCliente.Apellidos;
                this.txtIdentificacion.Text = eCliente.Identificacion;
                this.txtCelular.Text = eCliente.Celular;
                this.txtCorreo.Text = eCliente.Correo;
            }
        }

        private bool Comprobaciones(out ECliente eCliente)
        {
            eCliente = new ECliente();
            bool result = true;

            if (this.txtNombres.Text.Equals(""))
            {
                this.errorProvider2.SetIconPadding(this.txtNombres, -25);
                this.errorProvider2.SetError(this.txtNombres, "Campo requerido");
                result = false;
            }

            if (this.txtApellidos.Text.Equals(""))
            {
                this.errorProvider2.SetIconPadding(this.txtApellidos, -25);
                this.errorProvider2.SetError(this.txtApellidos, "Campo requerido");
                result = false;
            }

            if (this.txtIdentificacion.Text.Equals(""))
            {
                this.errorProvider2.SetIconPadding(this.txtIdentificacion, -25);
                this.errorProvider2.SetError(this.txtIdentificacion, "Campo requerido");
                result = false;
            }

            if (!this.IsEditar)
            {
                DataTable dtCliente =
                    ECliente.BuscarClientes("IDENTIFICACION EXACTA", this.txtIdentificacion.Text, out string rpta);
                if (dtCliente != null)
                {
                    Mensajes.MensajeInformacion("El número de identificación ya existe, por favor verifique", "Entendido");
                    this.txtIdentificacion.SelectAll();
                    result = false;
                }
            }

            eCliente.Nombres = this.txtNombres.Text;
            eCliente.Apellidos = this.txtApellidos.Text;
            eCliente.Identificacion = this.txtIdentificacion.Text;
            eCliente.Celular = this.txtCelular.Text;
            eCliente.Correo = this.txtCorreo.Text;
            eCliente.Estado = "ACTIVO";
            return result;

        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Comprobaciones(out ECliente eCliente))
                {
                    string rpta = "";
                    string mensaje = "";
                    if (this.IsEditar)
                    {
                        rpta = ECliente.EditarCliente(this.ECliente.Id_cliente, eCliente);
                        mensaje = "Se actualizó correctamente el cliente";
                    }
                    else
                    {
                        rpta = ECliente.InsertarCliente(eCliente, out int id_cliente);
                        mensaje = "Se agregó correctamente el cliente";
                    }

                    if (rpta.Equals("OK"))
                    {
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
                    "Hubo un error al guardar un cliente", ex.Message);
            }
        }

        private void TxtCorreo_LostFocus(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (ComprobacionEmail.EmailComprobado(txt.Text))
            {
                this.errorProvider1.SetIconPadding(this.txtCorreo, -25);
                this.errorProvider1.Icon = Resources.iconOk;
                this.errorProvider1.SetError(this.txtCorreo, "Correcto");
            }
            else
            {
                if (!txt.Text.Equals(""))
                {
                    this.errorProvider1.SetIconPadding(this.txtCorreo, -25);
                    this.errorProvider1.Icon = Resources.iconError;
                    this.errorProvider1.SetError(this.txtCorreo, "Verifique la dirección de correo");
                    this.txtCorreo.Focus();
                }
            }
        }

        private bool _isEditar;

        public bool IsEditar { get => _isEditar; set => _isEditar = value; }
    }
}
