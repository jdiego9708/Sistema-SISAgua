using CapaEntidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacionAdministracion.Formularios.FormsTarifas
{
    public partial class FrmObservarTarifas : Form
    {
        public FrmObservarTarifas()
        {
            InitializeComponent();
            this.Load += FrmObservarTarifas_Load;
            this.txtBusqueda.OnPxClick += TxtBusqueda_onPxClick;
            this.txtBusqueda.OnCustomKeyPress += TxtBusqueda_onKeyPress;
            this.txtBusqueda.OnCustomLostFocus += TxtBusqueda_onLostFocus;
            this.dgvTarifas.DoubleClick += DgvTarifas_DoubleClick;
        }

        public event EventHandler OnDgvDoubleClick;

        private void DgvTarifas_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dgvTarifas.CurrentRow;
                if (row != null)
                {
                    if (this.OnDgvDoubleClick != null)
                    {
                        DataRow dataRow = ((DataRowView)row.DataBoundItem).Row;
                        this.OnDgvDoubleClick(new ETarifas(dataRow), e);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "DgvTarifas_DoubleClick",
                    "Hubo un error con la tabla de datos", ex.Message);
            }
        }

        private void TxtBusqueda_onLostFocus(object sender, EventArgs e)
        {
            CustomTextBox txt = (CustomTextBox)sender;
            if (txt.Equals(txt.Texto_inicial) || txt.Equals(""))
            {
                this.BuscarTarifas("COMPLETO", "");
            }
        }

        private void TxtBusqueda_onKeyPress(object sender, KeyPressEventArgs e)
        {
            CustomTextBox txt = (CustomTextBox)sender;
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (txt.Texto.Equals("") || txt.Texto.Equals(txt.Texto_inicial))
                {
                    this.BuscarTarifas("COMPLETO", "");
                }
                else
                {
                    this.BuscarTarifas("DESCRIPCION", txt.Texto);
                }
            }
        }

        private void TxtBusqueda_onPxClick(object sender, EventArgs e)
        {
            CustomTextBox txt = (CustomTextBox)sender;
            if (txt.Texto.Equals("") || txt.Texto.Equals(txt.Texto_inicial))
            {
                this.BuscarTarifas("COMPLETO", "");
            }
            else
            {
                this.BuscarTarifas("DESCRIPCION", txt.Texto);
            }
        }

        private void FrmObservarTarifas_Load(object sender, EventArgs e)
        {
            this.txtBusqueda.Texto_inicial = "Búsqueda";
            this.BuscarTarifas("COMPLETO", "");
        }

        private void BuscarTarifas(string tipo_busqueda, string texto_busqueda)
        {
            try
            {
                DataTable dtTarifas =
                    ETarifas.BuscarTarifas(tipo_busqueda, texto_busqueda, out string rpta);
                if (dtTarifas != null)
                {
                    this.lblResultados.Text = "Se encontraron " + dtTarifas.Rows.Count + " tarifas";
                    this.dgvTarifas.Enabled = true;
                    this.dgvTarifas.clearDataSource();
                    this.dgvTarifas.PageSize = 15;
                    this.dgvTarifas.SetPagedDataSource(dtTarifas, this.bindingNavigator1);

                    string[] columns_header =
                    {
                        "Id tarifa", "Descripción", "Valor base", "Consumo mínimo", "Consumo máximo base",
                        "Medida", "Costo excedente"
                    };

                    bool[] columns_visible =
                    {
                        false, true, true, true, true, true, true
                    };

                    this.dgvTarifas =
                        DatagridString.ChangeHeaderTextAndVisibleCustomDataGrid(this.dgvTarifas,
                        columns_header, columns_visible);
                }
                else
                {
                    this.lblResultados.Text = "No se encontró ninguna tarifa";
                    this.dgvTarifas.Enabled = false;
                    this.dgvTarifas.clearDataSource();

                    if (!rpta.Equals("OK"))
                        throw new Exception(rpta);
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BuscarTarifas",
                    "Hubo un error al realizar la búsqueda", ex.Message);
            }
        }
    }
}
