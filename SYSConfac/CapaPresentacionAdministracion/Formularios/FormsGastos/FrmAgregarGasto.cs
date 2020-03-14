using CapaEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacionAdministracion.Formularios.FormsGastos
{
    public partial class FrmAgregarGasto : Form
    {
        public FrmAgregarGasto()
        {
            InitializeComponent();
            this.btnGuardar.Click += BtnGuardar_Click;
        }

        EGastos EGasto;

        public void AsignarDatos(EGastos eGasto)
        {
            this.Text = "Editar un gasto";
            this.IsEditar = true;
            this.EGasto = eGasto;
            this.txtTitulo.Text = eGasto.Titulo_gasto;
            this.txtDescripcion.Text = eGasto.Descripcion_gasto;
        }

        private bool Comprobaciones(out EGastos eGasto)
        {
            eGasto = new EGastos();

            if (this.txtTitulo.Text.Equals(""))
            {
                Mensajes.MensajeInformacion("El título no puede estar vacío", "Entendido");
                return false;
            }

            eGasto.Titulo_gasto = this.txtTitulo.Text;
            eGasto.Descripcion_gasto = this.txtDescripcion.Text;
            eGasto.Estado_gasto = "ACTIVO";

            return true;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Comprobaciones(out EGastos eGasto))
                {
                    string mensaje = "";
                    string rpta = "";

                    if (IsEditar)
                    {
                        rpta = EGastos.EditarGasto(eGasto, this.EGasto.Id_gasto);
                        mensaje = "Se actualizó correctamente el gasto";
                    }
                    else
                    {
                        rpta = EGastos.InsertarGasto(eGasto);
                        mensaje = "Se agregó correctamente el gasto";
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
                    "Hubo un error al agregar un gasto", ex.Message);
            }
        }

        private bool _isEditar;

        public bool IsEditar { get => _isEditar; set => _isEditar = value; }
    }
}
