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

namespace CapaPresentacionAdministracion.Formularios.FormsEmpleados
{
    public partial class FrmObservarEmpleados : Form
    {
        public FrmObservarEmpleados()
        {
            InitializeComponent();
            this.txtBusqueda.OnPxClick += TxtBusqueda_onPxClick;
            this.txtBusqueda.OnCustomKeyPress += TxtBusqueda_onKeyPress;
            this.txtBusqueda.OnCustomLostFocus += TxtBusqueda_onLostFocus;
            this.dgvEmpleados.DoubleClick += DgvEmpleados_DoubleClick;
            this.Load += FrmObservarEmpleados_Load;
        }

        private void FrmObservarEmpleados_Load(object sender, EventArgs e)
        {
            this.txtBusqueda.Texto_inicial = "Búsqueda";
            this.BuscarEmpleados("COMPLETO", "");
        }

        private void DgvEmpleados_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dgvEmpleados.CurrentRow;
                if (row != null)
                {
                    if (this.OnDgvDoubleClick != null)
                    {
                        DataRow dataRow = ((DataRowView)row.DataBoundItem).Row;
                        this.OnDgvDoubleClick(new EEmpleado(dataRow), e);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "DgvEmpleados_DoubleClick",
                    "Hubo un error con la tabla de datos", ex.Message);
            }
        }

        public event EventHandler OnDgvDoubleClick;

        private void TxtBusqueda_onLostFocus(object sender, EventArgs e)
        {
            CustomTextBox txt = (CustomTextBox)sender;
            if (txt.Equals(txt.Texto_inicial) || txt.Texto.Equals(""))
            {
                this.BuscarEmpleados("COMPLETO", "");
            }
        }

        private void TxtBusqueda_onKeyPress(object sender, KeyPressEventArgs e)
        {
            CustomTextBox txt = (CustomTextBox)sender;
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (txt.Texto.Equals("") || txt.Texto.Equals(txt.Texto_inicial))
                {
                    this.BuscarEmpleados("COMPLETO ", "");
                }
                else
                {
                    this.BuscarEmpleados("NOMBRE", txt.Texto);
                }
            }
        }

        private void TxtBusqueda_onPxClick(object sender, EventArgs e)
        {
            CustomTextBox txt = (CustomTextBox)sender;
            if (txt.Texto.Equals("") || txt.Texto.Equals(txt.Texto_inicial))
            {
                this.BuscarEmpleados("COMPLETO ", "");
            }
            else
            {
                this.BuscarEmpleados("NOMBRE", txt.Texto);
            }
        }

        private void BuscarEmpleados(string tipo_busqueda, string texto_busqueda)
        {
            try
            {
                DataTable dtEmpleados =
                    EEmpleado.BuscarEmpleados(tipo_busqueda, texto_busqueda, out string rpta);
                if (dtEmpleados != null)
                {
                    this.lblResultados.Text = "Se encontraron " + dtEmpleados.Rows.Count + " empleados";
                    this.dgvEmpleados.Enabled = true;
                    this.dgvEmpleados.clearDataSource();
                    this.dgvEmpleados.PageSize = 15;
                    this.dgvEmpleados.SetPagedDataSource(dtEmpleados, this.bindingNavigator1);

                    string[] columns_header =
                    {
                        "Id empleado", "Nombres", "Apellidos", "Celular", "Correo", "Cargo empleado", "Clave"
                    };

                    bool[] columns_visible =
                    {
                        false, true, true, true, true, true, false
                    };

                    this.dgvEmpleados =
                        DatagridString.ChangeHeaderTextAndVisibleCustomDataGrid(this.dgvEmpleados,
                        columns_header, columns_visible);
                }
                else
                {
                    this.lblResultados.Text = "No se encontró ningún empleado";
                    this.dgvEmpleados.Enabled = false;
                    this.dgvEmpleados.clearDataSource();

                    if (!rpta.Equals("OK"))
                        throw new Exception(rpta);
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BuscarEmpleados",
                    "Hubo un error al realizar la búsqueda", ex.Message);
            }
        }
    }
}
