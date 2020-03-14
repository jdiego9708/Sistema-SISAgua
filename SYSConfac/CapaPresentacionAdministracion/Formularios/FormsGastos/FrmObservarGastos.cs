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
    public partial class FrmObservarGastos : Form
    {
        public FrmObservarGastos()
        {
            InitializeComponent();
            this.txtBusqueda.OnPxClick += TxtBusqueda_onPxClick;
            this.txtBusqueda.OnCustomKeyPress += TxtBusqueda_onKeyPress;
            this.txtBusqueda.OnCustomLostFocus += TxtBusqueda_onLostFocus;
            this.dgvGastos.DoubleClick += DgvGastos_DoubleClick;
            this.Load += FrmObservarGastos_Load;
        }

        private void FrmObservarGastos_Load(object sender, EventArgs e)
        {
            this.BuscarGastos("COMPLETO", "");
        }

        private void DgvGastos_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dgvGastos.CurrentRow;
                if (row != null)
                {
                    if (this.OnDgvDoubleClick != null)
                    {
                        DataRow dataRow = ((DataRowView)row.DataBoundItem).Row;
                        this.OnDgvDoubleClick(new EGastos(dataRow), e);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "DgvGastos_DoubleClick",
                    "Hubo un error con la tabla de datos", ex.Message);
            }
        }

        private void TxtBusqueda_onLostFocus(object sender, EventArgs e)
        {
            CustomTextBox txt = (CustomTextBox)sender;
            if (txt.Equals(txt.Texto_inicial) || txt.Equals(""))
            {
                this.BuscarGastos("COMPLETO", "");
            }
        }

        private void TxtBusqueda_onKeyPress(object sender, KeyPressEventArgs e)
        {
            CustomTextBox txt = (CustomTextBox)sender;
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (txt.Texto.Equals("") || txt.Texto.Equals(txt.Texto_inicial))
                {
                    this.BuscarGastos("COMPLETO ", "");
                }
                else
                {
                    this.BuscarGastos("TITULO", txt.Texto);
                }
            }
        }

        private void TxtBusqueda_onPxClick(object sender, EventArgs e)
        {
            CustomTextBox txt = (CustomTextBox)sender;
            if (txt.Texto.Equals("") || txt.Texto.Equals(txt.Texto_inicial))
            {
                this.BuscarGastos("COMPLETO ", "");
            }
            else
            {
                this.BuscarGastos("TITULO", txt.Texto);
            }
        }

        private void BuscarGastos(string tipo_busqueda, string texto_busqueda)
        {
            try
            {
                DataTable dtGastos = EGastos.BuscarGastos(tipo_busqueda, texto_busqueda, out string rpta);
                this.dgvGastos.clearDataSource();
                if (dtGastos != null)
                {
                    this.lblResultados.Text = "Se encontraron " + dtGastos.Rows.Count + " tipos de gastos";
                    this.dgvGastos.PageSize = 20;
                    this.dgvGastos.SetPagedDataSource(dtGastos, this.bindingNavigator1);               
                }
                else
                {
                    this.lblResultados.Text = "No se encontraron gastos";

                    if (!rpta.Equals("OK"))
                        throw new Exception(rpta);
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BuscarGastos",
                    "Hubo un error buscando los gastos", ex.Message);
            }
        }

        public event EventHandler OnDgvDoubleClick;
    }
}
