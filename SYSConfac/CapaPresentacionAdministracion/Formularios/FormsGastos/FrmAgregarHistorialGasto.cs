using CapaEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


using CapaPresentacionAdministracion.Formularios.FormsPrincipales;

namespace CapaPresentacionAdministracion.Formularios.FormsGastos
{
    public partial class FrmAgregarHistorialGasto : Form
    {
        public FrmAgregarHistorialGasto()
        {
            InitializeComponent();
            this.btnGuardar.Click += BtnGuardar_Click;
            this.btnSeleccionarTipoGasto.Click += BtnSeleccionarTipoGasto_Click;
            this.Load += FrmAgregarHistorialGasto_Load;

            this.txtValorHistorialGasto.KeyPress += OnlyNumbers_KeyPress;
            this.txtValorHistorialGasto.LostFocus += Txt_LostFocus;
            this.txtValorHistorialGasto.GotFocus += Txt_GotFocus;
            this.txtValorHistorialGasto.Click += Txt_GotFocus;
        }

        private bool Comprobaciones(out EHistorialGastos eHistorialGasto)
        {
            eHistorialGasto = new EHistorialGastos();

            if (this.btnSeleccionarTipoGasto.Tag == null)
            {
                Mensajes.MensajeInformacion("Debe seleccionar un tipo de gasto", "Entendido");
                return false;
            }

            if (decimal.TryParse(Convert.ToString(this.txtValorHistorialGasto.Tag), out decimal valor_gasto))
            {
                if (valor_gasto < 1)
                {
                    Mensajes.MensajeInformacion("Verifique el valor del gasto, no puede ser menor que $1 ", "Entendido");
                    return false;
                }
            }
            else
            {
                Mensajes.MensajeInformacion("Verifique el valor del gasto ", "Entendido");
                return false;
            }

            DatosInicioSesion datos = DatosInicioSesion.GetInstancia();

            eHistorialGasto.Fecha_gasto = DateTime.Now;
            eHistorialGasto.Hora_gasto = DateTime.Now.ToString("HH:mm tt");
            eHistorialGasto.EGasto = this.EGasto;
            eHistorialGasto.EEmpleado = new EEmpleado
            {
                Id_empleado = datos.EEmpleado.Id_empleado
            };
            eHistorialGasto.Valor_gasto = valor_gasto;

            return true;
        }

        private void FrmAgregarHistorialGasto_Load(object sender, EventArgs e)
        {
            this.txtFechaHora.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
        }

        private void BtnSeleccionarTipoGasto_Click(object sender, EventArgs e)
        {
            FrmObservarGastos frmObservarGastos = new FrmObservarGastos
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            frmObservarGastos.OnDgvDoubleClick += FrmObservarGastos_OnDgvDoubleClick;
            frmObservarGastos.Show();
        }

        EGastos EGasto;

        private void FrmObservarGastos_OnDgvDoubleClick(object sender, EventArgs e)
        {
            EGastos gasto = (EGastos)sender;
            this.EGasto = gasto;
            this.btnSeleccionarTipoGasto.Text = gasto.Titulo_gasto;
            this.btnSeleccionarTipoGasto.Tag = gasto.Id_gasto;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Comprobaciones(out EHistorialGastos eHistorialGasto))
                {
                    MensajeEspera.ShowWait("Cargando...");
                    string rpta = EHistorialGastos.InsertarHistorialGasto(out int id_historial_gasto, eHistorialGasto);
                    if (rpta.Equals("OK"))
                    {
                        eHistorialGasto.Id_historial_gasto = id_historial_gasto;
                        OnGastoSuccess?.Invoke(eHistorialGasto, e);
                        MensajeEspera.CloseForm();
                        #region IMPRIMIR

                        if (rdVistaPrevia.Checked)
                        {
                            MensajeEspera.ShowWait("Imprimiendo...");

                            FrmFacturaGastos FrmFacturaGastos = new FrmFacturaGastos
                            {
                                WindowState = FormWindowState.Maximized
                            };
                            FrmFacturaGastos.AsignarReporte(eHistorialGasto);
                            FrmFacturaGastos.Show();
                            FrmFacturaGastos.Activate();

                            MensajeEspera.CloseForm();
                        }
                        else if (rdImpresionDirecta.Checked)
                        {
                            MensajeEspera.ShowWait("Imprimiendo...");
                            FrmFacturaGastos FrmFacturaGastos = new FrmFacturaGastos
                            {
                                WindowState = FormWindowState.Maximized
                            };
                            FrmFacturaGastos.AsignarReporte(eHistorialGasto);
                            FrmFacturaGastos.Imprimir();

                            MensajeEspera.CloseForm();
                        }
                        #endregion
                        MensajeEspera.CloseForm();
                        Mensajes.MensajeOkForm("Se guardó correctamente el gasto");
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
                    "Hubo un error al guardar un gasto", ex.Message);
            }
        }

        private void Txt_GotFocus(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;

            decimal value = Convert.ToDecimal(txt.Tag);
            txt.Text = value.ToString("N2");

            txt.SelectAll();
        }

        private void Txt_LostFocus(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (txt.Text.Equals(""))
                txt.Text = "0";

            txt.Tag = txt.Text;
            txt.Text = "$" + txt.Text;
        }

        private void OnlyNumbers_KeyPress(object sender, KeyPressEventArgs e)
        {
            CultureInfo cc = Thread.CurrentThread.CurrentCulture;
            if (e.KeyChar.ToString() == cc.NumberFormat.NumberDecimalSeparator ||
                char.IsDigit(e.KeyChar) ||
                (int)e.KeyChar == (int)Keys.Back)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private int _id_empleado;
        public event EventHandler OnGastoSuccess;

        public int Id_empleado { get => _id_empleado; set => _id_empleado = value; }
    }
}
