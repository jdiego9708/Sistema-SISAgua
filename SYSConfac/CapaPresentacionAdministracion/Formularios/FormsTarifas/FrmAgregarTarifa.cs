using CapaEntidades;
using System;
using System.Globalization;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;

using CapaPresentacionAdministracion.Formularios.FormsMedidas;

namespace CapaPresentacionAdministracion.Formularios.FormsTarifas
{
    public partial class FrmAgregarTarifa : Form
    {
        public FrmAgregarTarifa()
        {
            InitializeComponent();

            this.txtConsumoMaximo.KeyPress += OnlyNumbers_KeyPress;
            this.txtConsumoMinimo.KeyPress += OnlyNumbers_KeyPress;
            this.txtValorBase.KeyPress += OnlyNumbers_KeyPress;
            this.txtCostoExcedente.KeyPress += OnlyNumbers_KeyPress;

            this.txtConsumoMaximo.LostFocus += Txt_LostFocus;
            this.txtConsumoMinimo.LostFocus += Txt_LostFocus;
            this.txtValorBase.LostFocus += Txt_LostFocus;
            this.txtCostoExcedente.LostFocus += Txt_LostFocus;

            this.txtConsumoMaximo.GotFocus += Txt_GotFocus;
            this.txtConsumoMinimo.GotFocus += Txt_GotFocus;
            this.txtValorBase.GotFocus += Txt_GotFocus;
            this.txtCostoExcedente.GotFocus += Txt_GotFocus;

            this.btnGuardar.Click += BtnGuardar_Click;
            this.rdTarifaUnica.CheckedChanged += RdTarifaUnica_Click;
            this.rdTarifaDetallada.CheckedChanged += RdTarifaUnica_Click;

            this.btnMedida.Click += BtnMedida_Click;
        }

        public event EventHandler OnTarifaSuccess;

        private void BtnMedida_Click(object sender, EventArgs e)
        {
            FrmObservarMedidas frmObservarMedidas = new FrmObservarMedidas
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            frmObservarMedidas.OnDgvDoubleClick += FrmObservarMedidas_OnDgvDoubleClick;
            frmObservarMedidas.ShowDialog();
        }

        private void FrmObservarMedidas_OnDgvDoubleClick(object sender, EventArgs e)
        {
            EMedida eMedida = (EMedida)sender;
            this.btnMedida.Text = eMedida.Descripcion_medida;
            this.btnMedida.Tag = eMedida.Id_medida;
        }

        private void RdTarifaUnica_Click(object sender, EventArgs e)
        {
            RadioButton rd = (RadioButton)sender;
            if (rd.Checked)
            {
                if (rd.Name.Equals("rdTarifaUnica"))
                {
                    this.gbConsumoMaximo.Visible = false;
                    this.gbConsumoMinimo.Visible = false;
                    this.gbMedida.Visible = false;
                    this.gbCostoExcedente.Visible = false;

                    this.gbValorBase.Tag = gbValorBase.Location;
                    this.gbValorBase.Text = "Valor tarifa";
                    this.gbValorBase.Location = this.gbConsumoMinimo.Location;

                    this.btnGuardar.Tag = btnGuardar.Location;
                    this.btnGuardar.Location = this.gbConsumoMaximo.Location;

                    this.Tag = this.Size;
                    this.Size = new Size(this.Width,
                        this.gbValorBase.Location.Y + this.gbValorBase.Height * 2);
                }
                else
                {
                    this.gbConsumoMaximo.Visible = true;
                    this.gbConsumoMinimo.Visible = true;
                    this.gbMedida.Visible = true;
                    this.gbCostoExcedente.Visible = true;

                    this.gbValorBase.Text = "Valor base";

                    if (gbValorBase.Tag != null)
                    {
                        Point point = (Point)gbValorBase.Tag;
                        gbValorBase.Location = point;
                    }

                    if (this.btnGuardar.Tag != null)
                    {
                        Point point = (Point)btnGuardar.Tag;
                        this.btnGuardar.Location = point;
                    }

                    if (this.Tag != null)
                    {
                        Size size = (Size)this.Tag;
                        this.Size = size;
                    }
                }
            }
        }

        private ETarifas eTarifas;

        public void AsignarDatos(ETarifas tarifa)
        {
            if (tarifa != null)
            {
                this.eTarifas = tarifa;
                this.txtValorBase.Text = tarifa.Valor_tarifa.ToString("N2");
                this.txtDescripcion.Text = tarifa.Descripcion;

                if (tarifa.Tipo_tarifa.Equals("DETALLE"))
                {
                    this.rdTarifaDetallada.Checked = true;
                    if (tarifa.EDetalleTarifa != null)
                    {
                        this.txtConsumoMinimo.Text = tarifa.EDetalleTarifa.Consumo_minimo.ToString();
                        this.txtConsumoMaximo.Text = tarifa.EDetalleTarifa.Consumo_maximo.ToString();
                        this.txtCostoExcedente.Text = tarifa.EDetalleTarifa.Valor_excedente.ToString("N2");
                        this.btnMedida.Tag = tarifa.EDetalleTarifa.EMedida.Id_medida;
                        this.btnMedida.Text = tarifa.EDetalleTarifa.EMedida.Descripcion_medida;
                    }
                }
                else
                    this.rdTarifaUnica.Checked = true;
            }
        }

        private bool Comprobaciones(out ETarifas eTarifa, out EDetalleTarifas eDetalleTarifa)
        {
            eTarifa = new ETarifas();
            eDetalleTarifa = new EDetalleTarifas();
            bool result = true;

            if (this.txtDescripcion.Text.Equals(""))
            {
                this.errorProvider1.SetIconPadding(this.txtDescripcion, -25);
                this.errorProvider1.SetError(this.txtDescripcion, "Campo requerido");
                result = false;
            }

            if (this.rdTarifaDetallada.Checked)
            {
                int consumo_minimo = Convert.ToInt32(this.txtConsumoMinimo.Text);

                if (int.TryParse(this.txtConsumoMaximo.Text, out int consumo_maximo))
                {
                    if (consumo_maximo <= consumo_minimo)
                    {
                        this.errorProvider1.SetError(this.txtConsumoMaximo, "El consumo máximo debe ser mayor que el consumo mínimo");
                        result = false;
                    }
                }

                if (decimal.TryParse(this.txtValorBase.Text, out decimal valor_base))
                {
                    if (valor_base < 1)
                    {
                        this.errorProvider1.SetError(this.txtValorBase, "El valor base debe ser mayor que 0");
                        result = false;
                    }
                }

                if (!decimal.TryParse(this.txtCostoExcedente.Text, out decimal costo_excedente))
                {
                    this.errorProvider1.SetError(this.txtCostoExcedente, "Verifique el costo del excedente");
                    result = false;
                }

                if (!int.TryParse(Convert.ToString(this.btnMedida.Tag), out int id_medida))
                {
                    this.errorProvider1.SetError(this.btnMedida, "Verifique la medida seleccionada");
                    result = false;
                }

                if (result)
                {
                    eTarifa.Descripcion = this.txtDescripcion.Text;
                    eTarifa.Tipo_tarifa = "DETALLE";
                    eTarifa.Valor_tarifa = valor_base;

                    eDetalleTarifa.EMedida = new EMedida
                    {
                        Id_medida = id_medida
                    };
                    eDetalleTarifa.Valor_base = valor_base;
                    eDetalleTarifa.Consumo_minimo = consumo_minimo;
                    eDetalleTarifa.Consumo_maximo = consumo_maximo;
                    eDetalleTarifa.Valor_excedente = costo_excedente;
                }
            }
            else
            {
                if (decimal.TryParse(this.txtValorBase.Text, out decimal valor_base))
                {
                    if (valor_base < 1)
                    {
                        this.errorProvider1.SetError(this.txtValorBase, "El valor base debe ser mayor que 0");
                        result = false;
                    }
                }

                eTarifa.Descripcion = this.txtDescripcion.Text;
                eTarifa.Tipo_tarifa = "UNICA";
                eTarifa.Valor_tarifa = valor_base;
            }
            return result;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Comprobaciones(out ETarifas eTarifas, out EDetalleTarifas eDetalleTarifa))
                {
                    string rpta = "";
                    string mensaje = "";
                    if (this.IsEditar)
                    {
                        rpta = ETarifas.EditarTarifa(eTarifas, this.eTarifas.Id_tarifa);
                        if (rpta.Equals("OK") & eTarifas.Tipo_tarifa.Equals("DETALLE"))
                        {
                            rpta = EDetalleTarifas.EditarDetalleTarifa(eDetalleTarifa, this.eTarifas.EDetalleTarifa.Id_detalle_tarifa);
                        }
                        mensaje = "Se actualizó correctamente la tarifa";
                    }
                    else
                    {
                        rpta = ETarifas.InsertarTarifa(eTarifas, out int id_tarifa);
                        if (rpta.Equals("OK") & eTarifas.Tipo_tarifa.Equals("DETALLE"))
                        {
                            eTarifas.Id_tarifa = id_tarifa;
                            eDetalleTarifa.ETarifa = new ETarifas
                            {
                                Id_tarifa = id_tarifa
                            };
                            rpta = EDetalleTarifas.InsertarDetalleTarifa(eDetalleTarifa);
                        }
                        mensaje = "Se agregó correctamente la tarifa";
                    }

                    if (rpta.Equals("OK"))
                    {
                        Mensajes.MensajeOkForm(mensaje);
                        this.OnTarifaSuccess?.Invoke(eTarifas, e);
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
                    "Hubo un error al guardar una tarifa", ex.Message);
            }
        }

        private void Txt_GotFocus(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.SelectAll();
        }

        private void Txt_LostFocus(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (txt.Text.Equals(""))
                txt.Text = "0";
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

        private bool _isEditar;

        public bool IsEditar { get => _isEditar; set => _isEditar = value; }
    }
}
