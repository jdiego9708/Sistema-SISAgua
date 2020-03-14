using CapaEntidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacionAdministracion.Formularios.FormsMedidas
{
    public partial class FrmObservarMedidas : Form
    {
        public FrmObservarMedidas()
        {
            InitializeComponent();
            this.Load += FrmObservarTarifas_Load;
            this.txtBusqueda.OnPxClick += TxtBusqueda_onPxClick;
            this.txtBusqueda.OnCustomKeyPress += TxtBusqueda_onKeyPress;
            this.txtBusqueda.OnCustomLostFocus += TxtBusqueda_onLostFocus;
            this.dgvMedidas.DoubleClick += DgvMedidas_DoubleClick;
        }

        public event EventHandler OnDgvDoubleClick;

        private void DgvMedidas_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dgvMedidas.CurrentRow;
                if (row != null)
                {
                    if (this.OnDgvDoubleClick != null)
                    {
                        DataRow dataRow = ((DataRowView)row.DataBoundItem).Row;
                        this.OnDgvDoubleClick(new EMedida(dataRow), e);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "DgvMedidas_DoubleClick",
                    "Hubo un error con la tabla de datos", ex.Message);
            }
        }

        private void TxtBusqueda_onLostFocus(object sender, EventArgs e)
        {
            CustomTextBox txt = (CustomTextBox)sender;
            if (txt.Equals(txt.Texto_inicial) || txt.Equals(""))
            {
                this.BuscarMedidas("COMPLETO", "");
            }
        }

        private void TxtBusqueda_onKeyPress(object sender, KeyPressEventArgs e)
        {
            CustomTextBox txt = (CustomTextBox)sender;
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (txt.Texto.Equals("") || txt.Texto.Equals(txt.Texto_inicial))
                {
                    this.BuscarMedidas("COMPLETO ", "");
                }
                else
                {
                    this.BuscarMedidas("DESCRIPCION", txt.Texto);
                }
            }
        }

        private void TxtBusqueda_onPxClick(object sender, EventArgs e)
        {
            CustomTextBox txt = (CustomTextBox)sender;
            if (txt.Texto.Equals("") || txt.Texto.Equals(txt.Texto_inicial))
            {
                this.BuscarMedidas("COMPLETO ", "");
            }
            else
            {
                this.BuscarMedidas("DESCRIPCION", txt.Texto);
            }
        }

        private void FrmObservarTarifas_Load(object sender, EventArgs e)
        {
            this.txtBusqueda.Texto_inicial = "Búsqueda";
            this.BuscarMedidas("COMPLETO", "");
        }

        private void BuscarMedidas(string tipo_busqueda, string texto_busqueda)
        {
            try
            {
                DataTable dtMedidas =
                    EMedida.BuscarMedidas(tipo_busqueda, texto_busqueda, out string rpta);
                if (dtMedidas != null)
                {
                    this.lblResultados.Text = "Se encontraron " + dtMedidas.Rows.Count + " medidas";
                    this.dgvMedidas.Enabled = true;
                    this.dgvMedidas.clearDataSource();
                    this.dgvMedidas.PageSize = 15;
                    this.dgvMedidas.SetPagedDataSource(dtMedidas, this.bindingNavigator1);

                    string[] columns_header =
                    {
                        "Id_medida", "Medida"
                    };

                    bool[] columns_visible =
                    {
                        false, true
                    };

                    this.dgvMedidas =
                        DatagridString.ChangeHeaderTextAndVisibleCustomDataGrid(this.dgvMedidas,
                        columns_header, columns_visible);
                }
                else
                {
                    this.lblResultados.Text = "No se encontró ninguna medida";
                    this.dgvMedidas.Enabled = false;
                    this.dgvMedidas.clearDataSource();

                    if (!rpta.Equals("OK"))
                        throw new Exception(rpta);
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BuscarMedidas",
                    "Hubo un error al realizar la búsqueda", ex.Message);
            }
        }
    }
}
