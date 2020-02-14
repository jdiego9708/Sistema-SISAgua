using CapaEntidades;
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

namespace CapaPresentacionAdministracion.Formularios.FormsEmpleados
{
    public partial class FrmNuevoEmpleado : Form
    {
        public FrmNuevoEmpleado()
        {
            InitializeComponent();
            this.txtCorreo.LostFocus += TxtCorreo_LostFocus;
            this.Load += FrmNuevoEmpleado_Load;
            this.txtClave2.LostFocus += TxtClave2_LostFocus;
            this.btnGuardar.Click += BtnGuardar_Click;
        }

        private void TxtClave2_LostFocus(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (txt.Text == this.txtClave1.Text)
            {
                this.errorProvider1.SetIconPadding(this.txtClave2, -25);
                this.errorProvider1.Icon = Resources.iconOk;
                this.errorProvider1.SetError(this.txtClave2, "Correcto");
            }
            else
            {
                this.errorProvider1.SetIconPadding(this.txtClave2, -25);
                this.errorProvider1.Icon = Resources.iconError;
                this.errorProvider1.SetError(this.txtClave2, "Verifique la contraseña debe ser la misma");
            }
        }

        private void FrmNuevoEmpleado_Load(object sender, EventArgs e)
        {
            if (!this.IsEditar)
            {
                this.LlenarListaTipoUsuarios();
                this.LlenarListaPermisos();
                this.listaPermisos.SelectedIndex = 0;
                this.listaTipoUsuario.SelectedIndex = 1;
            }
        }

        private void LlenarListaTipoUsuarios()
        {
            this.listaTipoUsuario.Items.Clear();
            this.listaTipoUsuario.Items.Add("ADMINISTRADOR");
            this.listaTipoUsuario.Items.Add("FUNCIONARIO");
        }

        private void LlenarListaPermisos()
        {
            this.listaPermisos.Items.Clear();
            this.listaPermisos.Items.Add("PREDETERMINADO");
            this.listaPermisos.Items.Add("CONTROL TOTAL");
            this.listaPermisos.Items.Add("PERSONALIZADO");
        }

        EEmpleado EEmpleado;

        public void AsignarDatos(EEmpleado eEmpleado)
        {
            this.EEmpleado = eEmpleado;
            if (eEmpleado != null)
            {
                this.txtNombres.Text = eEmpleado.Nombre_completo;
                this.txtCorreo.Text = eEmpleado.Correo_electronico;

                this.LlenarListaTipoUsuarios();
                this.listaTipoUsuario.Text = eEmpleado.Tipo_empleado;

                this.txtCelular.Text = eEmpleado.Celular;

                this.LlenarListaPermisos();
                this.listaPermisos.Text = eEmpleado.Permisos;

                if (eEmpleado.Estado.Equals("ACTIVO"))
                    rdActivo.Checked = true;
                else
                    rdInactivo.Checked = true;

                this.txtClave1.Text = eEmpleado.Clave;
                this.txtClave2.Text = eEmpleado.Clave;
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Comprobaciones(out EEmpleado eEmpleado))
                {
                    string rpta = "";
                    string mensaje = "";
                    if (this.IsEditar)
                    {
                        rpta = EEmpleado.EditarEmpleado(this.EEmpleado.Id_empleado, eEmpleado);
                        mensaje = "Se actualizó correctamente el empleado";
                    }
                    else
                    {
                        rpta = EEmpleado.InsertarEmpleado(eEmpleado);
                        mensaje = "Se agregó correctamente el empleado";
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
                    "Hubo un error al guardar un empleado", ex.Message);
            }
        }

        private bool Comprobaciones(out EEmpleado eEmpleado)
        {
            eEmpleado = new EEmpleado();
            bool result = true;

            if (this.txtNombres.Text.Equals(""))
            {
                this.errorProvider2.SetIconPadding(this.txtNombres, -25);
                this.errorProvider2.SetError(this.txtNombres, "Campo requerido");
                result = false;
            }

            if (this.listaTipoUsuario.Text.Equals(""))
            {
                this.errorProvider2.SetIconPadding(this.listaTipoUsuario, -25);
                this.errorProvider2.SetError(this.listaTipoUsuario, "Campo requerido");
                result = false;
            }

            if (this.listaTipoUsuario.Text.Equals("ADMINISTRADOR") | this.listaTipoUsuario.Text.Equals("FUNCIONARIO"))
            {
                if (this.txtClave1.Text.Equals("") | this.txtClave2.Text.Equals(""))
                {
                    this.errorProvider2.SetIconPadding(this.txtClave1, -25);
                    this.errorProvider2.SetError(this.txtClave1, "Campo requerido");

                    this.errorProvider2.SetIconPadding(this.txtClave2, -25);
                    this.errorProvider2.SetError(this.txtClave2, "Campo requerido");
                    result = false;
                }
            }


            eEmpleado.Nombre_completo = this.txtNombres.Text;
            eEmpleado.Estado = rdActivo.Checked ? "ACTIVO" : "INACTIVO";
            eEmpleado.Tipo_empleado = this.listaTipoUsuario.Text;
            eEmpleado.Celular = this.txtCelular.Text;
            eEmpleado.Clave = this.txtClave2.Text;
            eEmpleado.Correo_electronico = this.txtCorreo.Text;
            eEmpleado.Permisos = this.listaPermisos.Text;

            return result;

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
