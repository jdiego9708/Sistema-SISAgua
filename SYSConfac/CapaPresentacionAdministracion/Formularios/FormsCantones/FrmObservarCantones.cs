using CapaEntidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacionAdministracion.Formularios.FormsCantones
{
    public partial class FrmObservarCantones : Form
    {
        public FrmObservarCantones()
        {
            InitializeComponent();
            this.Load += FrmObservarCantones_Load;
            this.txtBusqueda.OnPxClick += TxtBusqueda_onPxClick;
            this.txtBusqueda.OnCustomKeyPress += TxtBusqueda_onKeyPress;
            this.txtBusqueda.OnCustomLostFocus += TxtBusqueda_onLostFocus;
            this.dgvCantones.DoubleClick += DgvCantones_DoubleClick;
        }

        public event EventHandler OnDgvDoubleClick;

        private void DgvCantones_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dgvCantones.CurrentRow;
                if (row != null)
                {
                    if (this.OnDgvDoubleClick != null)
                    {
                        DataRow dataRow = ((DataRowView)row.DataBoundItem).Row;
                        this.OnDgvDoubleClick(new ECanton(dataRow), e);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "DgvCantones_DoubleClick", 
                    "Hubo un error con la tabla de datos", ex.Message);
            }
        }

        private void TxtBusqueda_onLostFocus(object sender, EventArgs e)
        {
            CustomTextBox txt = (CustomTextBox)sender;
            if (txt.Equals(txt.Texto_inicial) || txt.Equals(""))
            {
                this.BuscarCantones("COMPLETO", "");
            }
        }

        private void TxtBusqueda_onKeyPress(object sender, KeyPressEventArgs e)
        {
            CustomTextBox txt = (CustomTextBox)sender;
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (txt.Texto.Equals("") || txt.Texto.Equals(txt.Texto_inicial))
                {
                    this.BuscarCantones("COMPLETO ", "");
                }
                else
                {
                    this.BuscarCantones("NOMBRE", txt.Texto);
                }
            }
        }

        private void TxtBusqueda_onPxClick(object sender, EventArgs e)
        {
            CustomTextBox txt = (CustomTextBox)sender;
            if (txt.Texto.Equals("") || txt.Texto.Equals(txt.Texto_inicial))
            {
                this.BuscarCantones("COMPLETO ", "");
            }
            else
            {
                this.BuscarCantones("NOMBRE", txt.Texto);
            }
        }

        private void FrmObservarCantones_Load(object sender, EventArgs e)
        {
            this.txtBusqueda.Texto_inicial = "Búsqueda";
            this.BuscarCantones("COMPLETO", "");
        }

        private void BuscarCantones(string tipo_busqueda, string texto_busqueda)
        {
            try
            {
                DataTable dtCantones =
                    ECanton.BuscarCantones(tipo_busqueda, texto_busqueda, out string rpta);
                if (dtCantones != null)
                {
                    this.lblResultados.Text = "Se encontraron " + dtCantones.Rows.Count + " cantones";
                    this.dgvCantones.Enabled = true;
                    this.dgvCantones.clearDataSource();
                    this.dgvCantones.PageSize = 15;
                    this.dgvCantones.SetPagedDataSource(dtCantones, this.bindingNavigator1);

                    string[] columns_header =
                    {
                        "Id canton", "Nombre", "Descripción"
                    };

                    bool[] columns_visible =
                    {
                        false, true, true
                    };

                    this.dgvCantones =
                        DatagridString.ChangeHeaderTextAndVisibleCustomDataGrid(this.dgvCantones,
                        columns_header, columns_visible);
                }
                else
                {
                    this.lblResultados.Text = "No se encontró ningún cantón";
                    this.dgvCantones.Enabled = false;
                    this.dgvCantones.clearDataSource();

                    if (!rpta.Equals("OK"))
                        throw new Exception(rpta);
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BuscarCantones",
                    "Hubo un error al realizar la búsqueda", ex.Message);
            }
        }
    }
}
