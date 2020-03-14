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

namespace CapaPresentacionAdministracion.Formularios.FormsBarrios
{
    public partial class FrmObservarBarrios : Form
    {
        public FrmObservarBarrios()
        {
            InitializeComponent();
            this.Load += FrmObservarBarrios_Load;
            this.txtBusqueda.OnPxClick += TxtBusqueda_onPxClick;
            this.txtBusqueda.OnCustomKeyPress += TxtBusqueda_onKeyPress;
            this.txtBusqueda.OnCustomLostFocus += TxtBusqueda_onLostFocus;
            this.dgvBarrios.DoubleClick += DgvBarrios_DoubleClick;
        }

        public event EventHandler OnDgvDoubleClick;

        private void DgvBarrios_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dgvBarrios.CurrentRow;
                if (row != null)
                {
                    if (this.OnDgvDoubleClick != null)
                    {
                        DataRow dataRow = ((DataRowView)row.DataBoundItem).Row;
                        this.OnDgvDoubleClick(new EBarrio(dataRow), e);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "DgvBarrios_DoubleClick",
                    "Hubo un error con la tabla de datos", ex.Message);
            }
        }

        private void TxtBusqueda_onLostFocus(object sender, EventArgs e)
        {
            CustomTextBox txt = (CustomTextBox)sender;
            if (txt.Equals(txt.Texto_inicial) || txt.Texto.Equals(""))
            {
                this.BuscarBarrios("COMPLETO", "");
            }
        }

        private void TxtBusqueda_onKeyPress(object sender, KeyPressEventArgs e)
        {
            CustomTextBox txt = (CustomTextBox)sender;
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (txt.Texto.Equals("") || txt.Texto.Equals(txt.Texto_inicial))
                {
                    this.BuscarBarrios("COMPLETO ", "");
                }
                else
                {
                    this.BuscarBarrios("NOMBRE", txt.Texto);
                }
            }
        }

        private void TxtBusqueda_onPxClick(object sender, EventArgs e)
        {
            CustomTextBox txt = (CustomTextBox)sender;
            if (txt.Texto.Equals("") || txt.Texto.Equals(txt.Texto_inicial))
            {
                this.BuscarBarrios("COMPLETO ", "");
            }
            else
            {
                this.BuscarBarrios("NOMBRE", txt.Texto);
            }
        }

        private void FrmObservarBarrios_Load(object sender, EventArgs e)
        {
            this.txtBusqueda.Texto_inicial = "Búsqueda";
            this.BuscarBarrios("COMPLETO", "");
        }

        private void BuscarBarrios(string tipo_busqueda, string texto_busqueda)
        {
            try
            {
                DataTable dtBarrios =
                    EBarrio.BuscarBarrios(tipo_busqueda, texto_busqueda, out string rpta);
                if (dtBarrios != null)
                {
                    this.lblResultados.Text = "Se encontraron " + dtBarrios.Rows.Count + " barrios";
                    this.dgvBarrios.Enabled = true;
                    this.dgvBarrios.clearDataSource();
                    this.dgvBarrios.PageSize = 15;
                    this.dgvBarrios.SetPagedDataSource(dtBarrios, this.bindingNavigator1);

                    string[] columns_header =
                    {
                        "Id barrio", "Id parroquia", "Nombre", "Descripción", "Id parroquia", "Id canton", "Pertenece a la parroquia", "Descripción",
                        "Id canton", "Nombre canton", "Descripcion"
                    };

                    bool[] columns_visible =
                    {
                        false, false, true, true, false, false, true, false, false, false, false
                    };

                    this.dgvBarrios =
                        DatagridString.ChangeHeaderTextAndVisibleCustomDataGrid(this.dgvBarrios,
                        columns_header, columns_visible);
                }
                else
                {
                    this.lblResultados.Text = "No se encontró ningún barrio";
                    this.dgvBarrios.Enabled = false;
                    this.dgvBarrios.clearDataSource();

                    if (!rpta.Equals("OK"))
                        throw new Exception(rpta);
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BuscarBarrios",
                    "Hubo un error al realizar la búsqueda", ex.Message);
            }
        }
    }
}
