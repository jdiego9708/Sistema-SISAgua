using CapaEntidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacionAdministracion.Formularios.FormsMedidas
{
    public partial class FrmAgregarMedida : Form
    {
        public FrmAgregarMedida()
        {
            InitializeComponent();
            this.btnGuardar.Click += BtnGuardar_Click;
        }

        EMedida EMedida;

        public void AsignarDatos(EMedida eMedida)
        {
            this.EMedida = eMedida;
            this.txtDescripcion.Text = eMedida.Descripcion_medida;
            this.txtAlias.Text = eMedida.Alias_medida;
        }

        private bool Comprobaciones(out EMedida eMedida)
        {
            eMedida = new EMedida();
            if (this.txtDescripcion.Text.Equals("") | this.txtAlias.Text.Equals(""))
            {
                Mensajes.MensajeInformacion("La descripción y el alias son necesarios", "Entendido");
                return false;
            }
            else
            {
                DataTable dt = EMedida.BuscarMedidas("NOMBRE EXTACTO", this.txtDescripcion.Text, out string rpta);
                if (dt != null)
                {
                    Mensajes.MensajeInformacion("Ya se registra una medida con esta descripción", "Entendido");
                    return false;
                }
                else
                {
                    eMedida.Descripcion_medida = this.txtDescripcion.Text;
                    eMedida.Alias_medida = this.txtAlias.Text;
                    return true;
                }
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Comprobaciones(out EMedida eMedida))
                {
                    string rpta = "";
                    string mensaje = "";

                    if (this.IsEditar)
                    {
                        rpta = EMedida.ModificarMedida(eMedida, this.EMedida.Id_medida);
                        mensaje = "Se actualizó correctamente la medida";
                    }
                    else
                    {
                        rpta = EMedida.InsertarMedida(eMedida);
                        mensaje = "Se insertó correctamente la medida";
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
                    "Hubo un error al agregar la medida", ex.Message);
            }
        }

        private bool _isEditar;

        public bool IsEditar { get => _isEditar; set => _isEditar = value; }
    }
}
