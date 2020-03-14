using CapaEntidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacionAdministracion.Formularios.FormsCantones
{
    public partial class FrmAgregarCanton : Form
    {
        public FrmAgregarCanton()
        {
            InitializeComponent();
            this.Load += FrmAgregarCanton_Load;
            this.btnGuardar.Click += BtnGuardar_Click;
        }

        public void AsignarDatos(ECanton e)
        {
            this.eCanton = e;
            this.txtNombre.Text = e.Nombre;
            this.txtDescripcion.Text = e.Descripcion;
        }

        public ECanton eCanton;

        private bool Comprobaciones(out ECanton canton)
        {
            canton = new ECanton();
            if (this.txtNombre.Text.Equals(""))
            {
                Mensajes.MensajeInformacion("El nombre es un campo obligatorio", "Entendido");
                return false;
            }

            DataTable dt = ECanton.BuscarCantones("NOMBRE EXACTO", this.txtNombre.Text, out string rpta);
            if (dt != null)
            {
                Mensajes.MensajeInformacion("Ya existe un cantón con este nombre, compruebe", "Entendido");
                return false;
            }

            canton.Nombre = this.txtNombre.Text;
            canton.Descripcion = this.txtDescripcion.Text;
            return true;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                string mensaje = "";
                if (this.Comprobaciones(out ECanton Canton))
                {
                    if (this.IsEditar)
                    {
                        rpta = ECanton.EditarCanton(Canton, this.eCanton.Id_canton);
                        mensaje = "Se actualizó correctamente el cantón";
                    }
                    else
                    {
                        rpta = ECanton.InsertarCanton(Canton);
                        mensaje = "Se agregó correctamente el cantón";
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
                    "Hubo un error al guardar un cantón", ex.Message);
            }
        }

        private void FrmAgregarCanton_Load(object sender, EventArgs e)
        {
            if (this.IsEditar)
                this.btnGuardar.Text = "Actualizar";
        }

        private bool _isEditar;

        public bool IsEditar { get => _isEditar; set => _isEditar = value; }
    }
}
