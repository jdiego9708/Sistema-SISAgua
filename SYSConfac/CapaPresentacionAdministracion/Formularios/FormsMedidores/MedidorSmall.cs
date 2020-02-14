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

namespace CapaPresentacionAdministracion.Formularios.FormsMedidores
{
    public partial class MedidorSmall : UserControl
    {
        public MedidorSmall()
        {
            InitializeComponent();
            this.btnSiguiente.Click += BtnSiguiente_Click;
            this.btnDelete.Click += BtnDelete_Click;
            this.Load += MedidorSmall_Load;
        }

        private void MedidorSmall_Load(object sender, EventArgs e)
        {
            this.toolTip1.SetToolTip(this.btnDelete, "Dar de baja/Inactivar");
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            OnBtnEliminarClick?.Invoke(this, e);
        }

        public event EventHandler OnBtnSiguienteClick;
        public event EventHandler OnBtnEliminarClick;

        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            OnBtnSiguienteClick?.Invoke(EMedidor, e);
        }

        public EMedidor EMedidor;

        public void AsignarDatos(EMedidor eMedidor)
        {
            if (eMedidor != null)
            {
                this.EMedidor = eMedidor;
                this.txtMedidor.Text = eMedidor.Medidor;
                this.txtDescripcion.Text = eMedidor.Descripcion;

                if (eMedidor.Estado_medidor.Equals("INACTIVO"))
                {
                    foreach (Control control in this.Controls)
                    {
                        control.Enabled = false;
                    }
                }
               
            }
        }
    }
}
