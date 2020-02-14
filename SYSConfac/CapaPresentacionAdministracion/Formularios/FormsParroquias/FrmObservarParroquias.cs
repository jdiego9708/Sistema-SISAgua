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

namespace CapaPresentacionAdministracion.Formularios.FormsParroquias
{
    public partial class FrmObservarParroquias : Form
    {
        public FrmObservarParroquias()
        {
            InitializeComponent();
            this.Load += FrmObservarParroquias_Load;
            this.txtBusqueda.OnPxClick += TxtBusqueda_onPxClick;
            this.txtBusqueda.OnCustomKeyPress += TxtBusqueda_onKeyPress;
            this.txtBusqueda.OnCustomLostFocus += TxtBusqueda_onLostFocus;
            this.dgvParroquias.DoubleClick += DgvParroquias_DoubleClick;
        }

        public event EventHandler OnDgvDoubleClick;

        private void DgvParroquias_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dgvParroquias.CurrentRow;
                if (row != null)
                {
                    if (this.OnDgvDoubleClick != null)
                    {
                        DataRow dataRow = ((DataRowView)row.DataBoundItem).Row;
                        this.OnDgvDoubleClick(new EParroquia(dataRow), e);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "DgvParroquias_DoubleClick",
                    "Hubo un error con la tabla de datos", ex.Message);
            }
        }

        private void TxtBusqueda_onLostFocus(object sender, EventArgs e)
        {
            CustomTextBox txt = (CustomTextBox)sender;
            if (txt.Equals(txt.Texto_inicial) || txt.Equals(""))
            {
                this.BuscarParroquias("COMPLETO", "");
            }
        }

        private void TxtBusqueda_onKeyPress(object sender, KeyPressEventArgs e)
        {
            CustomTextBox txt = (CustomTextBox)sender;
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (txt.Texto.Equals("") || txt.Texto.Equals(txt.Texto_inicial))
                {
                    this.BuscarParroquias("COMPLETO ", "");
                }
                else
                {
                    this.BuscarParroquias("NOMBRE", txt.Texto);
                }
            }
        }

        private void TxtBusqueda_onPxClick(object sender, EventArgs e)
        {
            CustomTextBox txt = (CustomTextBox)sender;
            if (txt.Texto.Equals("") || txt.Texto.Equals(txt.Texto_inicial))
            {
                this.BuscarParroquias("COMPLETO ", "");
            }
            else
            {
                this.BuscarParroquias("NOMBRE", txt.Texto);
            }
        }

        private void FrmObservarParroquias_Load(object sender, EventArgs e)
        {
            this.txtBusqueda.Texto_inicial = "Búsqueda";
            this.BuscarParroquias("COMPLETO", "");
        }

        private void BuscarParroquias(string tipo_busqueda, string texto_busqueda)
        {
            try
            {
                DataTable dtParroquias =
                    EParroquia.BuscarParroquias(tipo_busqueda, texto_busqueda, out string rpta);
                if (dtParroquias != null)
                {
                    this.lblResultados.Text = "Se encontraron " + dtParroquias.Rows.Count + " parroquias";
                    this.dgvParroquias.Enabled = true;
                    this.dgvParroquias.clearDataSource();
                    this.dgvParroquias.PageSize = 15;
                    this.dgvParroquias.SetPagedDataSource(dtParroquias, this.bindingNavigator1);

                    string[] columns_header =
                    {
                        "Id parroquia", "Id_canton", "Nombre", "Descripción", "Canton"
                    };

                    bool[] columns_visible =
                    {
                       false, false, true, true, true
                    };

                    this.dgvParroquias =
                        DatagridString.ChangeHeaderTextAndVisibleCustomDataGrid(this.dgvParroquias,
                        columns_header, columns_visible);
                }
                else
                {
                    this.lblResultados.Text = "No se encontró ninguna parroquia";
                    this.dgvParroquias.Enabled = false;
                    this.dgvParroquias.clearDataSource();

                    if (!rpta.Equals("OK"))
                        throw new Exception(rpta);
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BuscarParroquias",
                    "Hubo un error al realizar la búsqueda", ex.Message);
            }
        }
    }
}
