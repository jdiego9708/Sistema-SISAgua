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

namespace CapaPresentacionAdministracion.Formularios.FormsMedidores
{
    public partial class FrmObservarMedidores : Form
    {
        public FrmObservarMedidores()
        {
            InitializeComponent();
            this.panel1.ControlAdded += Panel1_ControlAdded;
            this.btnAgregarMedidor.Click += BtnAgregarMedidor_Click;
        }

        private void BtnAgregarMedidor_Click(object sender, EventArgs e)
        {
            this.OnBtnMedidorSmallAgregarMedidor?.Invoke(sender, e);
        }
        private int _id_direccion;
        private int _id_cliente;

        public int Id_direccion
        {
            get => _id_direccion;
            set
            {
                _id_direccion = value;
                this.BuscarMedidores("ID DIRECCION", value.ToString());
            }
        }

        public int Id_cliente { get => _id_cliente;
            set
            {
                _id_cliente = value;
                this.BuscarMedidores("ID CLIENTE", value.ToString());
            }
        }

        private void Panel1_ControlAdded(object sender, ControlEventArgs e)
        {
            if (this.panel1.Controls.Count == 3)
            {
                this.panel1.AutoSize = false;
                this.AutoSize = false;
                this.panel1.AutoScroll = true;
            }
        }

        public void BuscarMedidores(string tipo_busqueda, string texto_busqueda)
        {
            try
            {
                DataTable dtMedidores =
                    EMedidor.BuscarMedidor(tipo_busqueda, texto_busqueda, out string rpta);
                this.panel1.Limpiar();
                if (dtMedidores != null)
                {
                    lblRespuesta.Text = "Medidores registrados " + dtMedidores.Rows.Count.ToString();

                    List<UserControl> medidors = new List<UserControl>();
                    foreach (DataRow row in dtMedidores.Rows)
                    {
                        MedidorSmall medidorSmall = new MedidorSmall();
                        EMedidor eMedidor = new EMedidor(row);
                        if (eMedidor.Estado_medidor.Equals("ACTIVO"))
                        {
                            medidorSmall.AsignarDatos(new EMedidor(row));
                            medidorSmall.OnBtnSiguienteClick += MedidorSmall_OnBtnSiguienteClick;
                            medidorSmall.OnBtnEliminarClick += MedidorSmall_OnBtnEliminarClick;
                            medidors.Add(medidorSmall);
                        }    
                    }
                    this.panel1.AddArrayControl(medidors);
                }
                else
                {
                    this.Size = new Size(this.Width, this.Height - this.panel1.Height);
                    lblRespuesta.Text = "No hay medidores registrados";

                    if (!rpta.Equals("OK"))
                        throw new Exception(rpta);
                }
            }
            catch (Exception ex)
            {

                Mensajes.MensajeErrorCompleto(this.Name, "BuscarMedidores",
                    "Hubo un error al observar los medidores", ex.Message);
            }
        }

        private void MedidorSmall_OnBtnEliminarClick(object sender, EventArgs e)
        {
            MedidorSmall medidorSmall = (MedidorSmall)sender;
            EMedidor eMedidor = medidorSmall.EMedidor;
            if (eMedidor.Estado_medidor.Equals("INACTIVO"))
            {
                Mensajes.MensajeInformacion("El medidor ya está inactivo", "Entendido");
                medidorSmall.Enabled = false;
            }
            else
            {
                Mensajes.MensajePregunta("¿Está seguro que desea inactivar o dar de baja el medidor?", 
                    "INACTIVAR", "CANCELAR", out DialogResult dialog);
                if (dialog == DialogResult.Yes)
                {
                    eMedidor.Estado_medidor = "INACTIVO";
                    string rpta = EMedidor.EditarMedidor(eMedidor.Id_medidor, eMedidor);
                    if (rpta.Equals("OK"))
                    {
                        Mensajes.MensajeInformacion("¡Medidor inactivado correctamente!", "Entendido");
                        medidorSmall.Enabled = false;
                    }
                    else
                        Mensajes.MensajeInformacion("No se pudo inactivar el medidor, detalles: " + rpta, "Entendido");
                }
            }
        }

        private void MedidorSmall_OnBtnSiguienteClick(object sender, EventArgs e)
        {        
            OnBtnMedidorSmallSiguiente?.Invoke(sender, e);
            this.Close();
        }

        public event EventHandler OnBtnMedidorSmallSiguiente;

        public event EventHandler OnBtnMedidorSmallAgregarMedidor;
    }
}
