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

namespace CapaPresentacionAdministracion.Formularios.FormsParroquias
{
    public partial class FrmAgregarParroquia : Form
    {
        public FrmAgregarParroquia()
        {
            InitializeComponent();
            this.Load += FrmAgregarParroquia_Load;
            this.btnGuardar.Click += BtnGuardar_Click;
        }

        public void AsignarDatos(EParroquia e)
        {
            this.eParroquia = e;
            this.txtNombre.Text = e.Nombre;
            this.txtDescripcion.Text = e.Descripcion;

            this.listaCantones.DataSource = ECanton.BuscarCantones("COMPLETO", "", out string rpta);
            this.listaCantones.ValueMember = "Id_canton";
            this.listaCantones.DisplayMember = "Nombre";

            this.listaCantones.SelectedValue = e.ECanton.Id_canton;
        }

        public EParroquia eParroquia;

        private bool Comprobaciones(out EParroquia parroquia)
        {
            parroquia = new EParroquia();
            if (this.txtNombre.Text.Equals(""))
            {
                Mensajes.MensajeInformacion("El nombre es un campo obligatorio", "Entendido");
                return false;
            }

            DataTable dt = EParroquia.BuscarParroquias("NOMBRE EXACTO", this.txtNombre.Text, out string rpta);
            if (dt != null)
            {
                Mensajes.MensajeInformacion("Ya existe una parroquia con este nombre, compruebe", "Entendido");
                return false;
            }

            if (this.listaCantones.Text.Equals(""))
            {
                Mensajes.MensajeInformacion("Debe seleccionar un cantón", "Entendido");
                return false;
            }

            parroquia.ECanton = new ECanton
            {
                Id_canton = Convert.ToInt32(this.listaCantones.SelectedValue)
            };
            parroquia.Nombre = this.txtNombre.Text;
            parroquia.Descripcion = this.txtDescripcion.Text;
            return true;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                string mensaje = "";
                if (this.Comprobaciones(out EParroquia Parroquia))
                {
                    if (this.IsEditar)
                    {
                        rpta = EParroquia.EditarParroquia(Parroquia, this.eParroquia.Id_parroquia);
                        mensaje = "Se actualizó correctamente la parroquia";
                    }
                    else
                    {
                        rpta = EParroquia.InsertarParroquia(Parroquia);
                        mensaje = "Se agregó correctamente la parroquia";
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
                    "Hubo un error al guardar una parroquia", ex.Message);
            }
        }

        private void FrmAgregarParroquia_Load(object sender, EventArgs e)
        {
            if (this.IsEditar)
                this.btnGuardar.Text = "Actualizar";
            else
            {
                this.listaCantones.DataSource = ECanton.BuscarCantones("COMPLETO", "", out string rpta);
                this.listaCantones.ValueMember = "Id_canton";
                this.listaCantones.DisplayMember = "Nombre";
            }

        }

        private bool _isEditar;

        public bool IsEditar { get => _isEditar; set => _isEditar = value; }
    }
}
