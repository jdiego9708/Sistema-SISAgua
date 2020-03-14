using CapaEntidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacionAdministracion.Formularios.FormsClientes
{
    public partial class FrmObservarClientes : Form
    {
        public FrmObservarClientes()
        {
            InitializeComponent();
            this.Load += FrmObservarClientes_Load;
            this.txtBusqueda.OnPxClick += TxtBusqueda_onPxClick;
            this.txtBusqueda.OnCustomKeyPress += TxtBusqueda_onKeyPress;
            this.txtBusqueda.OnCustomLostFocus += TxtBusqueda_onLostFocus;
            this.dgvClientes.DoubleClick += DgvClientes_DoubleClick;
        }

        private void DgvClientes_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dgvClientes.CurrentRow;
                if (row != null)
                {
                    if (this.OnDgvDoubleClick != null)
                    {
                        DataRow dataRow = ((DataRowView)row.DataBoundItem).Row;
                        this.OnDgvDoubleClick(new ECliente(dataRow), e);
                        this.Close();
                    }
                    else
                    {
                        DataRow dataRow = ((DataRowView)row.DataBoundItem).Row;
                        FrmDireccionesCliente frmDireccionesCliente = new FrmDireccionesCliente
                        {
                            StartPosition = FormStartPosition.CenterScreen,
                            IsLectura = this.IsLectura,
                            IsObservarLectura = this.IsObservarLectura
                        };
                        frmDireccionesCliente.AsignarDatos(new ECliente(dataRow));
                        frmDireccionesCliente.OnBtnNextClick += FrmDireccionesCliente_OnBtnNextClick;
                        frmDireccionesCliente.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "DgvClientes_DoubleClick",
                    "Hubo un error con la tabla de datos", ex.Message);
            }
        }

        private void FrmDireccionesCliente_OnBtnNextClick(object sender, EventArgs e)
        {
            OnBtnNextClick?.Invoke(sender, e);
            if (this.IsLectura & this.IsSesion == false)
                this.Close();
        }

        public event EventHandler OnDgvDoubleClick;

        private void TxtBusqueda_onLostFocus(object sender, EventArgs e)
        {
            CustomTextBox txt = (CustomTextBox)sender;
            if (txt.Equals(txt.Texto_inicial) || txt.Equals(""))
            {
                this.BuscarClientes("COMPLETO", "");
            }
        }

        private void TxtBusqueda_onKeyPress(object sender, KeyPressEventArgs e)
        {
            CustomTextBox txt = (CustomTextBox)sender;
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (txt.Texto.Equals("") || txt.Texto.Equals(txt.Texto_inicial))
                {
                    this.BuscarClientes("COMPLETO ", "");
                }
                else
                {
                    this.BuscarClientes("TODO", txt.Texto);
                }
            }
        }

        private void TxtBusqueda_onPxClick(object sender, EventArgs e)
        {
            CustomTextBox txt = (CustomTextBox)sender;
            if (txt.Texto.Equals("") || txt.Texto.Equals(txt.Texto_inicial))
            {
                this.BuscarClientes("COMPLETO ", "");
            }
            else
            {
                this.BuscarClientes("TODO", txt.Texto);
            }
        }

        private void FrmObservarClientes_Load(object sender, EventArgs e)
        {
            this.BuscarClientes("COMPLETO", "");
        }

        private void DgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    DataGridViewRow row =
            //        dgvClientes.CurrentRow;
            //    if (this.dgvClientes.Columns.Contains("Seleccionar"))
            //    {
            //        DataRow dataRow = ((DataRowView)this.dgvClientes.CurrentRow.DataBoundItem).Row;
            //        if (row.Cells["Seleccionar"].Value != null && (bool)row.Cells["Seleccionar"].Value)
            //        {
            //            row.Cells["Seleccionar"].Value = false;
            //            row.Cells["Seleccionar"].Value = null;

            //            OnDgvClientesRemoveCellContentClick?.Invoke(new ECliente(dataRow), e);
            //        }
            //        else if (row.Cells["Seleccionar"].Value == null)
            //        {
            //            OnDgvClientesAddCellContentClick?.Invoke(new ECliente(dataRow), e);
            //            row.Cells["Seleccionar"].Value = true;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Mensajes.MensajeErrorCompleto(this.Name, "DgvClientes_CellContentClick",
            //        "Hubo un error al seleccionar un elemento de la grilla", ex.Message);
            //}
        }

        private void BuscarClientes(string tipo_busqueda, string texto_busqueda)
        {
            try
            {
                DataTable dtClientess =
                    ECliente.BuscarClientes(tipo_busqueda, texto_busqueda, out string rpta);
                if (dtClientess != null)
                {
                    this.lblResultados.Text = "Se encontraron " + dtClientess.Rows.Count + " clientes";
                    this.dgvClientes.Enabled = true;
                    this.dgvClientes.clearDataSource();
                    this.dgvClientes.PageSize = 15;
                    this.dgvClientes.SetPagedDataSource(dtClientess, this.bindingNavigator1);

                    string[] columns_header =
                    {
                        "Id cliente", "Nombres", "Apellidos", "Identificación", "Celular", "Correo electrónico"
                    };

                    bool[] columns_visible =
                    {
                       false, true, true, true, true, true
                    };

                    this.dgvClientes =
                        DatagridString.ChangeHeaderTextAndVisibleCustomDataGrid(this.dgvClientes,
                        columns_header, columns_visible);
                }
                else
                {
                    this.lblResultados.Text = "No se encontró ningún cliente";
                    this.dgvClientes.Enabled = false;
                    this.dgvClientes.clearDataSource();

                    if (!rpta.Equals("OK"))
                        throw new Exception(rpta);
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BuscarClientes",
                    "Hubo un error al realizar la búsqueda", ex.Message);
            }
        }

        public event EventHandler OnBtnNextClick;

        private bool _isLectura = false;
        private bool _isObservarLectura = false;
        private bool _isSesion = false;
        public bool IsLectura { get => _isLectura; set => _isLectura = value; }
        public bool IsObservarLectura { get => _isObservarLectura; set => _isObservarLectura = value; }
        public bool IsSesion { get => _isSesion; set => _isSesion = value; }
    }
}
