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

namespace CapaPresentacionAdministracion.Formularios.FormsBarrios
{
    public partial class FrmAgregarBarrio : Form
    {
        public FrmAgregarBarrio()
        {
            InitializeComponent();
            this.btnGuardar.Click += BtnGuardar_Click;
            this.Load += FrmAgregarBarrio_Load;
        }

        public void AsignarDatos(EBarrio e)
        {
            this.eBarrio = e;
            this.txtNombre.Text = e.Nombre;
            this.txtDescripcion.Text = e.Descripcion;

            this.listaParroquias.DataSource = EParroquia.BuscarParroquias("COMPLETO", "", out string rpta);
            this.listaParroquias.ValueMember = "Id_parroquia";
            this.listaParroquias.DisplayMember = "Nombre";

            this.listaParroquias.SelectedValue = e.EParroquia.Id_parroquia;
        }

        public EBarrio eBarrio;

        private bool Comprobaciones(out EBarrio barrio)
        {
            barrio = new EBarrio();
            if (this.txtNombre.Text.Equals(""))
            {
                Mensajes.MensajeInformacion("El nombre es un campo obligatorio", "Entendido");
                return false;
            }

            DataTable dt = EBarrio.BuscarBarrios("NOMBRE EXACTO", this.txtNombre.Text, out string rpta);
            if (dt != null)
            {
                Mensajes.MensajeInformacion("Ya existe un barrio con este nombre, compruebe", "Entendido");
                return false;
            }

            if (!int.TryParse(this.listaParroquias.SelectedValue.ToString(), out int id_parroquia))
            {
                Mensajes.MensajeInformacion("Verifique la parroquia seleccionada", "Entendido");
                return false;
            }

            barrio.Nombre = this.txtNombre.Text;
            barrio.EParroquia = new EParroquia { Id_parroquia = id_parroquia };
            barrio.Descripcion = this.txtDescripcion.Text;
            return true;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                string mensaje = "";
                if (this.Comprobaciones(out EBarrio barrio))
                {
                    if (this.IsEditar)
                    {
                        rpta = EBarrio.EditarBarrio(barrio, this.eBarrio.Id_barrio);
                        mensaje = "Se actualizó correctamente el barrio";
                    }
                    else
                    {
                        rpta = EBarrio.InsertarBarrio(barrio);
                        mensaje = "Se agregó correctamente el barrio";
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
                    "Hubo un error al guardar un barrio", ex.Message);
            }
        }

        private void FrmAgregarBarrio_Load(object sender, EventArgs e)
        {
            if (this.IsEditar)
                this.btnGuardar.Text = "Actualizar";
            else
            {
                this.listaParroquias.DataSource = EParroquia.BuscarParroquias("COMPLETO", "", out string rpta);
                this.listaParroquias.ValueMember = "Id_parroquia";
                this.listaParroquias.DisplayMember = "Nombre";
            }
        }

        private bool _isEditar;

        public bool IsEditar { get => _isEditar; set => _isEditar = value; }
    }
}
