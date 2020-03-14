using CapaEntidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacionAdministracion.Formularios.FormsMedidores
{
    public partial class FrmAgregarMedidorCliente : Form
    {
        public FrmAgregarMedidorCliente()
        {
            InitializeComponent();
            this.Load += FrmAgregarMedidorCliente_Load;
            this.btnGuardar.Click += BtnGuardar_Click;
        }

        private EMedidor eMedidor;

        public void AsignarDatos(EMedidor medidor)
        {
            if (medidor != null)
            {
                this.eMedidor = medidor;
                this.txtMedidor.Text = medidor.Medidor;
                this.txtDescripcion.Text = medidor.Descripcion;
            }
        }

        private bool Comprobaciones(out EMedidor medidor)
        {
            medidor = new EMedidor();
            if (this.txtMedidor.Text.Equals(""))
            {
                Mensajes.MensajeInformacion("El campo medidor no puede estar vacío", "Entendido");
                return false;
            }
            else
            {
                DataTable dt = EMedidor.BuscarMedidor("NOMBRE EXACTO", this.txtMedidor.Text, out string rpta);
                if (dt != null)
                {
                    Mensajes.MensajeInformacion("Ya existe un medidor con esta identificación", "Entendido");
                    return false;
                }
            }

            medidor.DireccionCliente = new EDireccionCliente
            {
                Id_direccion = this.Id_direccion
            };
            medidor.Medidor = this.txtMedidor.Text;
            medidor.Descripcion = this.txtDescripcion.Text;
            medidor.Estado_medidor = "ACTIVO";

            return true;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                string mensaje = "";
                if (this.Comprobaciones(out EMedidor eMedidor))
                {
                    if (IsEditar)
                    {
                        rpta = EMedidor.EditarMedidor(this.eMedidor.Id_medidor, eMedidor);
                        mensaje = "Se actualizó el medidor correctamente";
                    }
                    else
                    {
                        rpta = EMedidor.InsertarMedidor(out int id_medidor, eMedidor);
                        mensaje = "Se agregó el medidor correctamente";
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
                    "Hubo un error al guardar o editar un medidor, Editar: " + IsEditar.ToString(), ex.Message);
            }
        }

        private void FrmAgregarMedidorCliente_Load(object sender, EventArgs e)
        {
            this.txtMedidor.MaxLength = 10;
        }

        private int _id_direccion;
        private bool _isEditar;

        public int Id_direccion { get => _id_direccion; set => _id_direccion = value; }
        public bool IsEditar { get => _isEditar; set => _isEditar = value; }
    }
}
