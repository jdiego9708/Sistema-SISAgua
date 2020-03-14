using CapaEntidades;
using CapaPresentacionAdministracion.Formularios.FormsBarrios;
using CapaPresentacionAdministracion.Formularios.FormsClientes;
using CapaPresentacionAdministracion.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace CapaPresentacionAdministracion.Formularios.FormsLecturas
{
    public partial class FrmPlanillaLecturas : Form
    {
        PoperContainer container;
        public FrmPlanillaLecturas()
        {
            InitializeComponent();
            this.btnMes.Click += BtnMes_Click;
            this.Load += FrmPlanillaLecturas_Load;
            this.btnImprimir.Click += BtnImprimir_Click;
            this.timer1.Tick += Timer1_Tick;
            this.btnSincronizar.Click += BtnSincronizar_Click;
            this.btnClientesSinMedidor.Click += BtnClientesSinMedidor_Click;
            this.btnLecturasPendientes.Click += BtnLecturasPendientes_Click;
            this.btnLecturasRealizadas.Click += BtnLecturasRealizadas_Click;
            this.btnClientesProxCorte.Click += BtnClientesProxCorte_Click;
            this.btnClientesPendienteCortes.Click += BtnClientesPendienteCortes_Click;

            this.dgvLecturas.DoubleClick += DgvLecturas_DoubleClick;
            this.dgvLecturas.DataSourceChanged += DgvLecturas_DataSourceChanged;

            this.btnHome.Click += BtnHome_Click;
            this.FormClosing += FrmPlanillaLecturas_FormClosing;

            this.rdBarrios.CheckedChanged += RdBarrios_CheckedChanged;
            this.btnBarrio.Click += BtnBarrio_Click;

            this.txtBusqueda.OnCustomKeyPress += TxtBusqueda_onKeyPress;
            this.txtBusqueda.OnPxClick += TxtBusqueda_onPxClick;
        }

        private void TxtBusqueda_onKeyPress(object sender, KeyPressEventArgs e)
        {
            CustomTextBox txt = (CustomTextBox)sender;
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (txt.Texto.Equals("") || txt.Texto.Equals(txt.Texto_inicial))
                {
                    this.BuscarLecturasLocal("");
                }
                else
                {
                    this.BuscarLecturasLocal(txt.Texto);
                }
            }
        }

        private void TxtBusqueda_onPxClick(object sender, EventArgs e)
        {
            CustomTextBox txt = (CustomTextBox)sender;
            if (txt.Texto.Equals("") || txt.Texto.Equals(txt.Texto_inicial))
            {
                this.BuscarLecturasLocal("");
            }
            else
            {
                this.BuscarLecturasLocal(txt.Texto);
            }
        }

        private void BuscarLecturasLocal(string texto_busqueda)
        {
            try
            {
                if (this.dgvLecturas.DataSource != null)
                {
                    if (this.dgvLecturas.Rows.Count > 1)
                    {
                        string tipo_busqueda = "";
                        foreach (Control control in this.gbBusqueda.Controls)
                        {
                            if (control is RadioButton rd)
                            {
                                if (rd.Checked)
                                {
                                    tipo_busqueda = Convert.ToString(rd.Tag).ToUpper();
                                    break;
                                }
                            }
                        }

                        DataTable dt = (DataTable)this.dgvLecturas.DataSource;

                        if (dt.TableName.Equals("DtLecturasPendientes"))
                        {
                            dt = this.DtLecturasPendientes;
                            DataTable dtNew = dt.Clone();

                            #region BUSCAR LECTURAS PENDIENTES
                            DataRow[] rows = null;
                            if (tipo_busqueda.Equals("NOMBRE"))
                            {
                                rows = dt.Select("Nombre like '" + texto_busqueda + "*'");
                            }
                            else if (tipo_busqueda.Equals("MEDIDOR"))
                            {
                                rows = dt.Select("Medidor like '*" + texto_busqueda + "*'");
                            }
                            else
                            {
                                this.gbBusqueda.Text = "Mostrando todos los resultados de lecturas pendientes";

                                DtLecturasPendientes.TableName = "DtLecturasPendientes";
                                this.dgvLecturas.clearDataSource();
                                this.dgvLecturas.PageSize = PageSize;
                                this.dgvLecturas.SetPagedDataSource(DtLecturasPendientes, this.bindingNavigator1);
                                this.lblOpcion.Text = "Lecturas pendientes";
                                isDoubleClick = true;
                                return;
                            }

                            if (rows.Length < 1)
                            {
                                rows = null;
                                this.gbBusqueda.Text = "No se encontraron lecturas pendientes";
                                this.dgvLecturas.clearDataSource();
                            }

                            if (rows != null)
                            {
                                foreach (DataRow row in rows)
                                {
                                    DataRow rowNew = dtNew.NewRow();
                                    rowNew["Id_cliente"] = row["Id_cliente"];
                                    rowNew["Id_medidor"] = row["Id_medidor"];
                                    rowNew["Medidor"] = row["Medidor"];
                                    rowNew["Nombre"] = row["Nombre"];
                                    rowNew["Barrio"] = row["Barrio"];
                                    rowNew["Direccion"] = row["Direccion"];
                                    rowNew["Lectura_anterior"] = row["Lectura_anterior"];
                                    rowNew["Lectura_actual"] = row["Lectura_actual"];
                                    dtNew.Rows.Add(rowNew);
                                }

                                dtNew.TableName = "DtLecturasPendientes";
                                this.dgvLecturas.clearDataSource();
                                this.dgvLecturas.PageSize = PageSize;
                                this.dgvLecturas.SetPagedDataSource(dtNew, this.bindingNavigator1);
                                this.lblOpcion.Text = "Lecturas pendientes";
                                isDoubleClick = true;

                                if (dtNew.Rows.Count > 1)
                                {
                                    this.gbBusqueda.Text = "Se encontraron " + dtNew.Rows.Count + " resultados en lecturas pendientes";
                                }
                                else if (dtNew.Rows.Count == 1)
                                {
                                    this.gbBusqueda.Text = "Se encontró 1 resultado en lecturas pendientes";
                                }
                                else
                                {
                                    this.gbBusqueda.Text = "No se encontraron resultados en lecturas pendientes";
                                }

                            }
                            #endregion
                        }
                        else if (dt.TableName.Equals("DtLecturasRealizadas"))
                        {
                            dt = this.DtLecturasRealizadas;
                            DataTable dtNew = dt.Clone();

                            #region BUSCAR LECTURAS REALIZADAS
                            DataRow[] rows = null;
                            if (tipo_busqueda.Equals("NOMBRE"))
                            {
                                rows = dt.Select("Nombre like '" + texto_busqueda + "*'");
                            }
                            else if (tipo_busqueda.Equals("MEDIDOR"))
                            {
                                rows = dt.Select("Medidor like '*" + texto_busqueda + "*'");
                            }
                            else
                            {
                                this.gbBusqueda.Text = "Mostrando todos los resultados de lecturas realizadas";

                                DtLecturasRealizadas.TableName = "DtLecturasRealizadas";
                                this.dgvLecturas.clearDataSource();
                                this.dgvLecturas.PageSize = PageSize;
                                this.dgvLecturas.SetPagedDataSource(DtLecturasRealizadas, this.bindingNavigator1);
                                this.lblOpcion.Text = "Lecturas realizadas";
                                isDoubleClick = true;
                                return;
                            }

                            if (rows.Length < 1)
                            {
                                rows = null;
                                this.gbBusqueda.Text = "No se encontraron lecturas realizadas";
                                this.dgvLecturas.clearDataSource();
                            }

                            if (rows != null)
                            {
                                foreach (DataRow row in rows)
                                {
                                    DataRow rowNew = dtNew.NewRow();
                                    rowNew["Id_lectura"] = row["Id_lectura"];
                                    rowNew["Id_cliente"] = row["Id_cliente"];
                                    rowNew["Id_medidor"] = row["Id_medidor"];
                                    rowNew["Medidor"] = row["Medidor"];
                                    rowNew["Nombre"] = row["Nombre"];
                                    rowNew["Barrio"] = row["Barrio"];
                                    rowNew["Direccion"] = row["Direccion"];
                                    rowNew["Lectura_anterior"] = row["Lectura_anterior"];
                                    rowNew["Lectura_actual"] = row["Lectura_actual"];
                                    rowNew["Total_consumo"] = row["Total_consumo"];
                                    rowNew["Consumo_excedido"] = row["Consumo_excedido"];
                                    dtNew.Rows.Add(rowNew);
                                }

                                dtNew.TableName = "DtLecturasRealizadas";
                                this.dgvLecturas.clearDataSource();
                                this.dgvLecturas.PageSize = PageSize;
                                this.dgvLecturas.SetPagedDataSource(dtNew, this.bindingNavigator1);
                                this.lblOpcion.Text = "Lecturas realizadas";
                                isDoubleClick = true;

                                if (dtNew.Rows.Count > 1)
                                {
                                    this.gbBusqueda.Text = "Se encontraron " + dtNew.Rows.Count + " resultados en lecturas realizadas";
                                }
                                else if (dtNew.Rows.Count == 1)
                                {
                                    this.gbBusqueda.Text = "Se encontró 1 resultado en lecturas realizadas";
                                }
                                else
                                {
                                    this.gbBusqueda.Text = "No se encontraron resultados en lecturas realizadas";
                                }
                            }
                            #endregion
                        }
                        else if (dt.TableName.Equals("DtClientesSinMedidor"))
                        {
                            dt = this.DtClientesSinMedidor;
                            DataTable dtNew = dt.Clone();

                            #region BUSCAR CLIENTES SIN MEDIDOR
                            DataRow[] rows = null;
                            if (tipo_busqueda.Equals("NOMBRE"))
                            {
                                rows = dt.Select("Nombre_cliente like '" + texto_busqueda + "*'");
                            }
                            else
                            {
                                this.gbBusqueda.Text = "Mostrando todos los resultados de clientes sin medidor";

                                DtClientesSinMedidor.TableName = "DtClientesSinMedidor";
                                this.dgvLecturas.clearDataSource();
                                this.dgvLecturas.PageSize = PageSize;
                                this.dgvLecturas.SetPagedDataSource(DtClientesSinMedidor, this.bindingNavigator1);
                                this.lblOpcion.Text = "Clientes sin medidor";
                                isDoubleClick = true;
                                return;
                            }

                            if (rows.Length < 1)
                            {
                                rows = null;
                                this.gbBusqueda.Text = "No se encontraron clientes sin medidores";
                                this.dgvLecturas.clearDataSource();
                            }

                            if (rows != null)
                            {
                                foreach (DataRow row in rows)
                                {
                                    DataRow rowNew = dtNew.NewRow();
                                    rowNew["Id_cliente"] = row["Id_cliente"];
                                    rowNew["Nombre_cliente"] = row["Nombre_cliente"];
                                    dtNew.Rows.Add(rowNew);
                                }

                                dtNew.TableName = "DtClientesSinMedidor";
                                this.dgvLecturas.clearDataSource();
                                this.dgvLecturas.PageSize = PageSize;
                                this.dgvLecturas.SetPagedDataSource(dtNew, this.bindingNavigator1);
                                this.lblOpcion.Text = "Clientes sin medidor";
                                isDoubleClick = true;

                                if (dtNew.Rows.Count > 1)
                                {
                                    this.gbBusqueda.Text = "Se encontraron " + dtNew.Rows.Count + " clientes sin medidor";
                                }
                                else if (dtNew.Rows.Count == 1)
                                {
                                    this.gbBusqueda.Text = "Se encontró 1 cliente sin medidor";
                                }
                                else
                                {
                                    this.gbBusqueda.Text = "No se encontraron clientes sin medidores";
                                }
                            }
                            #endregion
                        }
                        else if (dt.TableName.Equals("DtMedidoresProximoCorte"))
                        {
                            dt = this.DtMedidoresProximoCorte;
                            DataTable dtNew = dt.Clone();

                            #region BUSCAR MEDIDORES PROXIMO CORTE
                            DataRow[] rows = null;
                            if (tipo_busqueda.Equals("NOMBRE"))
                            {
                                rows = dt.Select("Nombre_cliente like '" + texto_busqueda + "*'");
                            }
                            else if (tipo_busqueda.Equals("MEDIDOR"))
                            {
                                rows = dt.Select("Medidor like '*" + texto_busqueda + "*'");
                            }
                            else
                            {
                                this.gbBusqueda.Text = "Mostrando todos los resultados de medidores próximos de corte";

                                DtMedidoresProximoCorte.TableName = "DtMedidoresProximoCorte";
                                this.dgvLecturas.clearDataSource();
                                this.dgvLecturas.PageSize = PageSize;
                                this.dgvLecturas.SetPagedDataSource(DtMedidoresProximoCorte, this.bindingNavigator1);
                                this.lblOpcion.Text = "Medidores próximos a cortar";
                                isDoubleClick = true;
                                return;
                            }

                            if (rows.Length < 1)
                            {
                                rows = null;
                                this.gbBusqueda.Text = "No se encontraron resultados en medidores próximo a corte";
                                this.dgvLecturas.clearDataSource();
                            }

                            if (rows != null)
                            {
                                foreach (DataRow row in rows)
                                {
                                    DataRow rowNew = dtNew.NewRow();
                                    rowNew["Id_cliente"] = row["Id_cliente"];
                                    rowNew["Id_medidor"] = row["Id_medidor"];
                                    rowNew["Medidor"] = row["Medidor"];
                                    rowNew["Nombre_cliente"] = row["Nombre_cliente"];
                                    rowNew["Fecha_pago"] = row["Fecha_pago"];
                                    rowNew["Total_pagar"] = row["Total_pagar"];
                                    rowNew["Estado"] = row["Estado"];
                                    dtNew.Rows.Add(rowNew);
                                }

                                dtNew.TableName = "DtMedidoresProximoCorte";
                                this.dgvLecturas.clearDataSource();
                                this.dgvLecturas.PageSize = PageSize;
                                this.dgvLecturas.SetPagedDataSource(dtNew, this.bindingNavigator1);
                                this.lblOpcion.Text = "Medidores próximos a cortar";
                                isDoubleClick = true;

                                if (dtNew.Rows.Count > 1)
                                {
                                    this.gbBusqueda.Text = "Se encontraron " + dtNew.Rows.Count + " clientes próximos a corte";
                                }
                                else if (dtNew.Rows.Count == 1)
                                {
                                    this.gbBusqueda.Text = "Se encontró 1 cliente próximo a corte";
                                }
                                else
                                {
                                    this.gbBusqueda.Text = "No se encontraron clientes próximos de corte";
                                }
                            }
                            #endregion
                        }
                        else if (dt.TableName.Equals("DtMedidoresCortados"))
                        {
                            dt = this.DtMedidoresCortados;
                            DataTable dtNew = dt.Clone();

                            #region BUSCAR MEDIDORES CORTADOS
                            DataRow[] rows = null;
                            if (tipo_busqueda.Equals("NOMBRE"))
                            {
                                rows = dt.Select("Nombre_cliente like '" + texto_busqueda + "*'");
                            }
                            else if (tipo_busqueda.Equals("MEDIDOR"))
                            {
                                rows = dt.Select("Medidor like '*" + texto_busqueda + "*'");
                            }
                            else
                            {
                                this.gbBusqueda.Text = "Mostrando todos los resultados de medidores cortados";

                                DtMedidoresCortados.TableName = "DtMedidoresCortados";
                                this.dgvLecturas.clearDataSource();
                                this.dgvLecturas.PageSize = PageSize;
                                this.dgvLecturas.SetPagedDataSource(DtMedidoresCortados, this.bindingNavigator1);
                                this.lblOpcion.Text = "Medidores cortados";
                                isDoubleClick = true;
                                return;
                            }

                            if (rows.Length < 1)
                            {
                                rows = null;
                                this.gbBusqueda.Text = "No se encontraron resultados en medidores cortados";
                                this.dgvLecturas.clearDataSource();
                            }

                            if (rows != null)
                            {
                                foreach (DataRow row in rows)
                                {
                                    DataRow rowNew = dtNew.NewRow();
                                    rowNew["Id_cliente"] = row["Id_cliente"];
                                    rowNew["Id_medidor"] = row["Id_medidor"];
                                    rowNew["Medidor"] = row["Medidor"];
                                    rowNew["Nombre_cliente"] = row["Nombre_cliente"];
                                    rowNew["Fecha_pago"] = row["Fecha_pago"];
                                    rowNew["Total_pagar"] = row["Total_pagar"];
                                    rowNew["Estado"] = row["Estado"];
                                    dtNew.Rows.Add(rowNew);
                                }

                                dtNew.TableName = "DtMedidoresCortados";
                                this.dgvLecturas.clearDataSource();
                                this.dgvLecturas.PageSize = PageSize;
                                this.dgvLecturas.SetPagedDataSource(dtNew, this.bindingNavigator1);
                                this.lblOpcion.Text = "Medidores cortados";
                                isDoubleClick = true;

                                if (dtNew.Rows.Count > 1)
                                {
                                    this.gbBusqueda.Text = "Se encontraron " + dtNew.Rows.Count + " clientes con medidor cortado";
                                }
                                else if (dtNew.Rows.Count == 1)
                                {
                                    this.gbBusqueda.Text = "Se encontró 1 cliente con medidor cortado";
                                }
                                else
                                {
                                    this.gbBusqueda.Text = "No se encontraron clientes con medidores cortados";
                                }
                            }
                            #endregion
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BuscarLecturas(string tipo_busqueda, string texto_busqueda)",
                    "Hubo un error al buscar lecturas", ex.Message);
            }
        }

        FrmObservarBarrios frmObservarBarrios;

        private void BtnBarrio_Click(object sender, EventArgs e)
        {
            if (this.rdBarrios.Checked)
            {
                this.frmObservarBarrios = new FrmObservarBarrios
                {
                    StartPosition = FormStartPosition.CenterScreen
                };
                frmObservarBarrios.OnDgvDoubleClick += FrmObservarBarrios_OnDgvDoubleClick;
                frmObservarBarrios.ShowDialog();
            }
            else
            {
                DataTable dtLecturas = this.DtLecturasPendientes;

                if (dtLecturas.TableName.Equals("DtLecturasPendientes"))
                {
                    FrmReportePlanilla FrmReportePlanilla = new FrmReportePlanilla
                    {
                        WindowState = FormWindowState.Maximized
                    };
                    FrmReportePlanilla.AsignarReporte(this.btnMes.Text, dtLecturas);
                    FrmReportePlanilla.ShowDialog();
                }
                else
                {
                    Mensajes.MensajeInformacion("Solo se pueden imprimir las lecturas pendientes", "Entendido");
                }
            }
        }

        private void FrmObservarBarrios_OnDgvDoubleClick(object sender, EventArgs e)
        {
            MensajeEspera.ShowWait("Cargando...");
            if (this.frmObservarBarrios != null)
                this.frmObservarBarrios.Close();

            EBarrio eBarrio = (EBarrio)sender;
            this.btnBarrio.Text = eBarrio.Nombre;
            this.btnBarrio.Tag = eBarrio;

            DataTable dtLecturas = this.DtLecturasPendientes;
            DataTable dtPlanillaFilter = dtLecturas.Clone();
            string consulta = "Barrio = '" + eBarrio.Nombre + "' ";
            DataRow[] rows = dtLecturas.Select(consulta);
            if (rows.Length < 1)
                rows = null;

            if (rows != null)
            {
                foreach (DataRow row in rows)
                {
                    DataRow newRow = dtPlanillaFilter.NewRow();
                    newRow["Id_cliente"] = Convert.ToString(row["Id_cliente"]);
                    newRow["Id_medidor"] = Convert.ToString(row["Id_medidor"]);
                    newRow["Medidor"] = Convert.ToString(row["Medidor"]);
                    newRow["Nombre"] = Convert.ToString(row["Nombre"]);
                    newRow["Barrio"] = Convert.ToString(row["Barrio"]);
                    newRow["Direccion"] = Convert.ToString(row["Direccion"]);
                    newRow["Lectura_anterior"] = Convert.ToString(row["Lectura_anterior"]);
                    newRow["Lectura_actual"] = Convert.ToString(row["Lectura_actual"]);
                    dtPlanillaFilter.Rows.Add(newRow);
                }
            }

            FrmReportePlanilla FrmReportePlanilla = new FrmReportePlanilla
            {
                WindowState = FormWindowState.Maximized
            };
            MensajeEspera.CloseForm();
            FrmReportePlanilla.AsignarReporte(this.btnMes.Text, dtPlanillaFilter);
            FrmReportePlanilla.ShowDialog();
        }

        private void RdBarrios_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rd = (RadioButton)sender;
            if (rd.Checked)
            {
                this.btnBarrio.Text = "Seleccionar barrio";
            }
            else
            {
                this.btnBarrio.Text = "Generar";
            }
        }

        private void FrmPlanillaLecturas_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.btnHome.PerformClick();
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            OnBtnHome?.Invoke(this, e);
        }

        public event EventHandler OnBtnHome;

        private void DgvLecturas_DataSourceChanged(object sender, EventArgs e)
        {
            if (this.dgvLecturas.DataSource != null)
            {
                DataTable dt = (DataTable)this.dgvLecturas.DataSource;

                if (dt.TableName.Equals("DtLecturasRealizadas"))
                {
                    this.dgvLecturas.Columns["Lectura_anterior"].HeaderText = "Lectura anterior";
                    this.dgvLecturas.Columns["Lectura_actual"].HeaderText = "Lectura actual";
                    this.dgvLecturas.Columns["Total_consumo"].HeaderText = "Consumo total";
                    this.dgvLecturas.Columns["Consumo_excedido"].HeaderText = "Excedente";
                    this.dgvLecturas.Columns["Id_cliente"].Visible = false;
                    this.dgvLecturas.Columns["Id_medidor"].Visible = false;
                    this.dgvLecturas.Columns["Id_lectura"].Visible = false;
                }
                else if (dt.TableName.Equals("DtLecturasPendientes"))
                {
                    this.dgvLecturas.Columns["Lectura_anterior"].HeaderText = "Lectura anterior";
                    this.dgvLecturas.Columns["Lectura_actual"].HeaderText = "Lectura actual";
                    this.dgvLecturas.Columns["Id_cliente"].Visible = false;
                    this.dgvLecturas.Columns["Id_medidor"].Visible = false;
                }
                else if (dt.TableName.Equals("DtMedidoresProximoCorte"))
                {
                    this.dgvLecturas.Columns["Id_cliente"].Visible = false;
                    this.dgvLecturas.Columns["Id_medidor"].Visible = false;
                    this.dgvLecturas.Columns["Nombre_cliente"].HeaderText = "Cliente";
                    this.dgvLecturas.Columns["Fecha_pago"].HeaderText = "Fecha de pago";
                    this.dgvLecturas.Columns["Total_pagar"].HeaderText = "Total a pagar";

                }
            }
        }

        bool isDoubleClick = false;

        private void BtnClientesPendienteCortes_Click(object sender, EventArgs e)
        {
            if (this.DtMedidoresCortados != null)
            {
                if (DtMedidoresCortados.Rows.Count > 0)
                {
                    DtMedidoresCortados.TableName = "DtMedidoresCortados";
                    this.dgvLecturas.clearDataSource();
                    this.dgvLecturas.PageSize = 30;
                    this.dgvLecturas.SetPagedDataSource(DtMedidoresCortados, this.bindingNavigator1);
                    this.lblOpcion.Text = "Medidores con corte";
                    isDoubleClick = false;

                    this.rdNinguno.Enabled = true;
                    this.rdNombre.Enabled = true;
                    this.rdMedidor.Enabled = true;
                }
            }
        }

        private void BtnClientesProxCorte_Click(object sender, EventArgs e)
        {
            if (this.DtMedidoresProximoCorte != null)
            {
                if (DtMedidoresProximoCorte.Rows.Count > 0)
                {
                    DtMedidoresProximoCorte.TableName = "DtMedidoresProximoCorte";
                    this.dgvLecturas.clearDataSource();
                    this.dgvLecturas.PageSize = 30;
                    this.dgvLecturas.SetPagedDataSource(DtMedidoresProximoCorte, this.bindingNavigator1);
                    this.lblOpcion.Text = "Medidores próximos de corte";
                    isDoubleClick = false;

                    this.rdNinguno.Enabled = true;
                    this.rdNombre.Enabled = true;
                    this.rdMedidor.Enabled = true;
                }
            }
        }

        private void BtnLecturasRealizadas_Click(object sender, EventArgs e)
        {
            if (this.DtLecturasRealizadas != null)
            {
                if (DtLecturasRealizadas.Rows.Count > 0)
                {
                    DtLecturasRealizadas.TableName = "DtLecturasRealizadas";
                    this.dgvLecturas.clearDataSource();
                    this.dgvLecturas.PageSize = 30;
                    this.dgvLecturas.SetPagedDataSource(DtLecturasRealizadas, this.bindingNavigator1);
                    this.lblOpcion.Text = "Lecturas realizadas";

                    if (this.IsEditar)
                        isDoubleClick = true;
                    else
                        isDoubleClick = false;

                    this.rdNinguno.Enabled = true;
                    this.rdNombre.Enabled = true;
                    this.rdMedidor.Enabled = true;
                }
            }
        }

        private void BtnLecturasPendientes_Click(object sender, EventArgs e)
        {
            if (this.DtLecturasPendientes != null)
            {
                if (DtLecturasPendientes.Rows.Count > 0)
                {
                    DtLecturasPendientes.TableName = "DtLecturasPendientes";
                    this.dgvLecturas.clearDataSource();
                    this.dgvLecturas.PageSize = 30;
                    this.dgvLecturas.SetPagedDataSource(DtLecturasPendientes, this.bindingNavigator1);
                    this.lblOpcion.Text = "Lecturas pendientes";
                    isDoubleClick = true;
                    this.rdNinguno.Enabled = true;
                    this.rdNombre.Enabled = true;
                    this.rdMedidor.Enabled = true;
                }
            }
        }

        private void BtnClientesSinMedidor_Click(object sender, EventArgs e)
        {
            if (this.DtClientesSinMedidor != null)
            {
                if (DtClientesSinMedidor.Rows.Count > 0)
                {
                    DtClientesSinMedidor.TableName = "DtClientesSinMedidor";
                    this.dgvLecturas.clearDataSource();
                    this.dgvLecturas.PageSize = 30;
                    this.dgvLecturas.SetPagedDataSource(DtClientesSinMedidor, this.bindingNavigator1);
                    this.lblOpcion.Text = "Clientes sin medidor";
                    isDoubleClick = true;

                    this.rdNinguno.Enabled = true;
                    this.rdNombre.Enabled = true;
                    this.rdMedidor.Enabled = false;
                }
            }
        }

        DataTable DtClientesSinMedidor;
        DataTable DtLecturasRealizadas;
        DataTable DtLecturasPendientes;
        DataTable DtMedidoresProximoCorte;
        DataTable DtMedidoresCortados;

        private void BtnSincronizar_Click(object sender, EventArgs e)
        {
            if (this.btnMes.Tag != null)
            {
                this.SincronizacionAgendamientos(this.btnMes.Text);
            }
        }

        bool syncSuccess = false;
        int contador = 0;
        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (contador >= 3 & syncSuccess)
            {
                MensajeEspera.CloseForm();
                timer1.Stop();
                contador = 0;
                syncSuccess = false;
            }

            contador += 1;
        }

        private void SincronizacionAgendamientos(string mes)
        {
            try
            {
                MensajeEspera.ShowWait("Sincronizando lecturas");
                timer1.Start();
                //Primero buscamos el agendamiento que si EXISTA
                //MensajeEspera.ChangeMensaje("Buscando agendamiento");
                DataTable dtAgendamientoLectura =
                    EAgendamientoLectura.BuscarAgendamientos("MES", mes, out string rpta);
                if (dtAgendamientoLectura != null)
                {
                    //Creamos la entidad con la primer fila de la tabla que es el agendamiento correspondiente
                    EAgendamientoLectura eAgendamientoLectura =
                        new EAgendamientoLectura(dtAgendamientoLectura, 0);

                    #region TABLAS NECESARIAS

                    bool result = true;

                    //MensajeEspera.ChangeMensaje("Recopilando clientes");

                    this.DtLecturasRealizadas = null;
                    this.DtMedidoresProximoCorte = null;
                    this.DtMedidoresCortados = null;
                    this.DtLecturasPendientes = null;
                    this.DtClientesSinMedidor = null;

                    //Tabla de clientes, buscamos todos los clientes que hay en la base de datos
                    DataTable dtClientes = ECliente.BuscarClientes("COMPLETO", "", out rpta);
                    if (dtClientes == null)
                        result = false;

                    //MensajeEspera.ChangeMensaje("Recopilando medidores");

                    //Tabla de medidores, buscamos todos los medidores que hay en la base de datos
                    DataTable dtMedidores = EMedidor.BuscarMedidor("COMPLETO", "", out rpta);
                    if (dtMedidores == null)
                        result = false;

                    // MensajeEspera.ChangeMensaje("Recopilando cuentas pendientes");
                    //Obtener el mes que seleccionamos
                    int mes_actual = Convert.ToInt32(this.btnMes.Tag);

                    //Tabla de cuentas pendientes, buscamos todas las cuentas
                    DataTable dtCuentasPendientes = EDetalleAgendamientoLectura.BuscarDetalleAgendamiento(out rpta);

                    //MensajeEspera.ChangeMensaje("Recopilando lecturas");
                    //Lecturas del mes actual
                    DataTable dtLecturas =
                        ELecturas.BuscarLecturas("LECTURA MES NUMERO", mes_actual.ToString(), out rpta);

                    //MensajeEspera.ChangeMensaje("Recopilando lecturas anteriores");
                    int mes_anterior_numero = mes_actual == 1 ? 12 : mes_actual - 1;
                    //Obtenemos el mes anterior al seleccionado
                    string mes_anterior = mes_actual == 1 ? this.MonthName(12) : this.MonthName(mes_actual - 1);
                    //Buscamos las lecturas anteriores
                    DataTable dtLecturasMesAnterior =
                        ELecturas.BuscarLecturas("LECTURA MES NUMERO", mes_anterior_numero.ToString(), out rpta);

                    this.BuscarLecturas(dtLecturas, dtLecturasMesAnterior);

                    //MensajeEspera.ChangeMensaje("Recopilando detalles de agendamiento");
                    //Buscamos el detalle de agendamiento, de este mes
                    DataTable dtDetalleAgendamiento =
                        EDetalleAgendamientoLectura.BuscarDetalleAgendamiento("MES", 0, 0, 0, mes, out rpta);

                    #region CREACION DE TABLAS
                    //Tabla clientes sin medidor, para almacenar a los clientes que no tienen ningún medidor ligado
                    DtClientesSinMedidor = new DataTable("DtClientesSinMedidor");
                    DtClientesSinMedidor.Columns.Add("Id_cliente", typeof(int));
                    DtClientesSinMedidor.Columns.Add("Nombre_cliente", typeof(string));

                    //Tabla para las lecturas pendientes
                    DtLecturasPendientes = new DataTable("DtLecturasPendientes");
                    DtLecturasPendientes.Columns.Add("Id_cliente", typeof(int));
                    DtLecturasPendientes.Columns.Add("Id_medidor", typeof(int));
                    DtLecturasPendientes.Columns.Add("Medidor", typeof(string));
                    DtLecturasPendientes.Columns.Add("Nombre", typeof(string));
                    DtLecturasPendientes.Columns.Add("Barrio", typeof(string));
                    DtLecturasPendientes.Columns.Add("Direccion", typeof(string));
                    DtLecturasPendientes.Columns.Add("Lectura_anterior", typeof(int));
                    DtLecturasPendientes.Columns.Add("Lectura_actual", typeof(string));

                    //Tabla medidores pendiente de corte
                    DtMedidoresProximoCorte = new DataTable();
                    DtMedidoresProximoCorte.Columns.Add("Id_medidor", typeof(int));
                    DtMedidoresProximoCorte.Columns.Add("Id_cliente", typeof(int));
                    DtMedidoresProximoCorte.Columns.Add("Medidor", typeof(string));
                    DtMedidoresProximoCorte.Columns.Add("Nombre_cliente", typeof(string));
                    DtMedidoresProximoCorte.Columns.Add("Fecha_pago", typeof(string));
                    DtMedidoresProximoCorte.Columns.Add("Total_pagar", typeof(string));
                    DtMedidoresProximoCorte.Columns.Add("Estado", typeof(string));

                    //Tabla medidores cortados
                    DtMedidoresCortados = new DataTable();
                    DtMedidoresCortados.Columns.Add("Id_medidor", typeof(int));
                    DtMedidoresCortados.Columns.Add("Id_cliente", typeof(int));
                    DtMedidoresCortados.Columns.Add("Medidor", typeof(string));
                    DtMedidoresCortados.Columns.Add("Nombre_cliente", typeof(string));
                    DtMedidoresCortados.Columns.Add("Fecha_pago", typeof(string));
                    DtMedidoresCortados.Columns.Add("Total_pagar", typeof(string));
                    DtMedidoresCortados.Columns.Add("Estado", typeof(string));
                    #endregion                    

                    #endregion

                    //Si hay resultados en la tabla clientes y medidores
                    if (result)
                    {
                        //MensajeEspera.ChangeMensaje("Verificando información");

                        #region VERIFICACIÓN Y AGENDAMIENTO DE LECTURAS
                        //Listas para guardar los detalle de agendamientos nuevos y los que hay que editar por inconsistencias
                        List<EDetalleAgendamientoLectura> ListeAgendamientosAdd = new List<EDetalleAgendamientoLectura>();
                        List<EDetalleAgendamientoLectura> ListeAgendamientosUpdate = new List<EDetalleAgendamientoLectura>();
                        //Habilitamos todos los controles del formulario
                        foreach (Control control in this.Controls)
                        {
                            control.Enabled = true;
                        }

                        //Recorremos los clientes
                        foreach (DataRow row in dtClientes.Rows)
                        {
                            //Creamos la entidad del cliente que tenemos
                            ECliente eCliente = new ECliente(row);
                            //Buscamos los medidores del cliente                           
                            DataRow[] rowsMedidores =
                                dtMedidores.Select(string.Format("Id_cliente = {0}", eCliente.Id_cliente));
                            if (rowsMedidores.Length == 0)
                                rowsMedidores = null;

                            //Comprobamos que el cliente tenga al menos un medidor
                            if (rowsMedidores != null)
                            {
                                //Recorremos los medidores que puede tener el cliente
                                foreach (DataRow rowMedidor in rowsMedidores)
                                {
                                    //Creamos entidad de Medidor
                                    EMedidor eMedidor = new EMedidor(rowMedidor);
                                    //MensajeEspera.ChangeMensaje("Clientes próximos de corte o cortados");
                                    //Buscamos el estado del medidor, si está próximo a corte o ya está cortado
                                    if (this.BuscarClientesCorte(dtCuentasPendientes, eMedidor))
                                    {
                                        //Si aún no está cortado el medidor o no está pendiente de corte 
                                        //Buscamos el detalle de agendamiento, para verificar si ya está agendado el medidor
                                        //MensajeEspera.ChangeMensaje("Comprobando el detalle de agendamiento");
                                        DataRow[] rowsDetalle;

                                        if (dtDetalleAgendamiento != null)
                                        {
                                            rowsDetalle =
                                                dtDetalleAgendamiento.Select(string.Format("Id_medidor = {0}", eMedidor.Id_medidor));
                                            if (rowsDetalle.Length == 0)
                                                rowsDetalle = null;
                                        }
                                        else
                                            rowsDetalle = null;

                                        //Si rowsDetalle es null significa que no esta el medidor agendado
                                        if (rowsDetalle == null)
                                        {
                                            //Se procede a crear la entidad de detalle de agendamiento para agendar la lectura
                                            EDetalleAgendamientoLectura eDetalle = new EDetalleAgendamientoLectura
                                            {
                                                EAgendamientoLectura = new EAgendamientoLectura { Id_agendamiento = eAgendamientoLectura.Id_agendamiento },
                                                ECliente = new ECliente { Id_cliente = eCliente.Id_cliente },
                                                EMedidor = new EMedidor { Id_medidor = eMedidor.Id_medidor },
                                                Estado = "PENDIENTE",
                                                Mes_lectura = mes.ToUpper()
                                            };
                                            //Se agrega a la lista de detalles de agendamientos
                                            ListeAgendamientosAdd.Add(eDetalle);
                                        }
                                        else //Si rowsDetalle no es null significa que ya se encuentra agendado
                                        {
                                            //MensajeEspera.ChangeMensaje("Verificando inconsistencias");
                                            /**Se comprueba en que estado está y se comprueba que no exista en la tabla lecturas
                                             * esto se hace para solucionar el error de duplicación de lecturas**/
                                            EDetalleAgendamientoLectura eDetalle = new EDetalleAgendamientoLectura(rowsDetalle[0]);
                                            if (eDetalle.Estado.Equals("PENDIENTE"))
                                            {
                                                //Inicializamos de nuevo el rowsDetalle en null
                                                rowsDetalle = null;
                                                //Comprobamos que si hayan lecturas realizadas
                                                if (this.DtLecturasRealizadas != null)
                                                {
                                                    //Buscamos en las lecturas realizadas el id del medidor
                                                    rowsDetalle =
                                                        this.DtLecturasRealizadas.Select
                                                        (string.Format("Id_medidor = {0}", eDetalle.EMedidor.Id_medidor));
                                                    if (rowsDetalle.Length == 0)
                                                        rowsDetalle = null;
                                                }
                                                //Si rowsDetalle es diferente de null significa que si se realizó la lectura pero
                                                //no se actualizó el detalle entonces agregamos una inconsistencia
                                                if (rowsDetalle != null)
                                                {
                                                    eDetalle.Estado = "TERMINADO";
                                                    ListeAgendamientosUpdate.Add(eDetalle);
                                                }
                                                else //Si es null el rowDetalle quiere decir que efectivamente está pendiente y lo agregaremos a lecturas pendientes
                                                {
                                                    //Variable para la lectura anterior
                                                    int lectura_anterior = 0;
                                                    //Filas para la lectura anterior
                                                    DataRow[] rowsLecturaAnterior;
                                                    //Comprobamos que la tabla lecturas del mes anterior no esté null
                                                    if (dtLecturasMesAnterior != null)
                                                    {
                                                        //Buscamos la lectura anterior del medidor
                                                        rowsLecturaAnterior =
                                                                  dtLecturasMesAnterior.Select(string.Format("Id_medidor = {0}", eDetalle.EMedidor.Id_medidor));
                                                        if (rowsLecturaAnterior.Length == 0)
                                                            rowsLecturaAnterior = null;
                                                    }
                                                    else
                                                        rowsLecturaAnterior = null;
                                                    //Comprobamos que no sea null las filas de lectura anterior encontradas
                                                    if (rowsLecturaAnterior != null)
                                                    {
                                                        if (rowsLecturaAnterior.Length > 0)
                                                        {
                                                            //Asignamos la lectura anterior
                                                            lectura_anterior = Convert.ToInt32(rowsLecturaAnterior[0]["Valor_lectura"]);
                                                        }
                                                    }

                                                    //Creamos la fila de la lectura pendiente
                                                    DataRow newRow = DtLecturasPendientes.NewRow();
                                                    newRow["Id_cliente"] = eDetalle.ECliente.Id_cliente;
                                                    newRow["Id_medidor"] = eDetalle.EMedidor.Id_medidor;
                                                    newRow["Medidor"] = eDetalle.EMedidor.Medidor;
                                                    newRow["Nombre"] = eDetalle.ECliente.Nombres + " " + eDetalle.ECliente.Apellidos;
                                                    newRow["Barrio"] = eDetalle.EMedidor.DireccionCliente.EBarrio.Nombre;
                                                    newRow["Direccion"] = eDetalle.EMedidor.DireccionCliente.Direccion;
                                                    newRow["Lectura_anterior"] = lectura_anterior;
                                                    newRow["Lectura_actual"] = "";
                                                    DtLecturasPendientes.Rows.Add(newRow);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                //Agregamos la fila del cliente sin medidor
                                DataRow rowClienteSinMedidor = DtClientesSinMedidor.NewRow();
                                rowClienteSinMedidor["Id_cliente"] = eCliente.Id_cliente;
                                rowClienteSinMedidor["Nombre_cliente"] = eCliente.Nombres + " " + eCliente.Apellidos;
                                DtClientesSinMedidor.Rows.Add(rowClienteSinMedidor);
                            }
                        }

                        if (ListeAgendamientosAdd.Count > 0)
                        {
                            MensajeEspera.ChangeMensaje("Agregando los detalles de agendamientos");
                            //Insertar los detalles de agendamientos
                            rpta = EDetalleAgendamientoLectura.InsertarDetalleAgendamiento(ListeAgendamientosAdd);
                            if (!rpta.Equals("OK"))
                            {
                                Mensajes.MensajeInformacion("Hubo un error al insertar los detalles de agendamiento", "Entendido");
                            }
                        }

                        if (ListeAgendamientosUpdate.Count > 0)
                        {
                            MensajeEspera.ChangeMensaje("Solucionando inconsistencias");
                            //Actualizar los detalles de agendamientos que tengan errores
                            rpta = EDetalleAgendamientoLectura.EditarDetalleAgendamiento(ListeAgendamientosUpdate);
                            if (!rpta.Equals("OK"))
                            {
                                Mensajes.MensajeInformacion("Hubo un error al actualizar los detalles de agendamiento", "Entendido");
                            }
                        }

                        #endregion

                        if (this.DtLecturasRealizadas != null)
                            this.btnLecturasRealizadas.Text = "Lecturas \r\nrealizadas (" + this.DtLecturasRealizadas.Rows.Count + ")";
                        else
                            this.btnLecturasRealizadas.Text = "Lecturas \r\nrealizadas (0)";

                        if (DtClientesSinMedidor != null)
                        {
                            if (DtClientesSinMedidor.Rows.Count < 1)
                            {
                                this.btnClientesSinMedidor.Text = "Clientes sin \r\nmedidor (0)";
                                DtClientesSinMedidor = null;
                            }
                            else
                                this.btnClientesSinMedidor.Text = "Clientes sin \r\nmedidor (" + DtClientesSinMedidor.Rows.Count + ")";
                        }
                        else
                            this.btnClientesSinMedidor.Text = "Clientes sin \r\nmedidor (0)";

                        if (DtLecturasPendientes != null)
                        {
                            if (DtLecturasPendientes.Rows.Count < 1)
                            {
                                this.btnLecturasPendientes.Text = "Lecturas \r\npendientes (0)";
                                DtLecturasPendientes = null;
                            }
                            else
                                this.btnLecturasPendientes.Text = "Lecturas \r\npendientes (" + DtLecturasPendientes.Rows.Count + ")";
                        }
                        else
                            this.btnLecturasPendientes.Text = "Lecturas \r\npendientes (0)";

                        if (DtMedidoresProximoCorte != null)
                        {
                            if (DtMedidoresProximoCorte.Rows.Count < 1)
                            {
                                this.btnClientesProxCorte.Text = "Clientes próximos \r\nde corte (0)";
                                DtMedidoresProximoCorte = null;
                            }
                            else
                                this.btnClientesProxCorte.Text = "Clientes próximos \r\nde corte (" + DtMedidoresProximoCorte.Rows.Count + ")";
                        }
                        else
                            this.btnClientesProxCorte.Text = "Clientes próximos \r\nde corte (0)";

                        if (DtMedidoresCortados != null)
                        {
                            if (DtMedidoresCortados.Rows.Count < 1)
                            {
                                this.btnClientesPendienteCortes.Text = "Clientes pendiente \r\nde corte (0)";
                                DtMedidoresCortados = null;
                            }
                            else
                                this.btnClientesPendienteCortes.Text = "Clientes pendiente \r\nde corte (" + DtMedidoresCortados.Rows.Count + ")";
                        }
                        else
                            this.btnClientesPendienteCortes.Text = "Clientes pendiente \r\nde corte (0)";

                        this.btnLecturasPendientes.PerformClick();
                    }
                    else
                    {
                        foreach (Control control in this.Controls)
                        {
                            if (!control.Name.Equals("groupBox1"))
                                control.Enabled = false;
                        }

                        if (!rpta.Equals("OK"))
                            throw new Exception(rpta);
                    }
                    syncSuccess = true;
                }
                else
                {
                    if (!rpta.Equals("OK"))
                        throw new Exception(rpta);

                    MensajeEspera.CloseForm();
                    timer1.Stop();
                    contador = 0;
                    syncSuccess = false;
                    MensajeEspera.CloseForm();
                    Mensajes.MensajeInformacion("No se encontró el agendamiento del mes de " + mes +
                        " se agendará y por favor vuelva a intentarlo", "Entendido");

                    EAgendamientoLectura eAgendamiento = new EAgendamientoLectura
                    {
                        Mes_agendamiento = this.btnMes.Text.ToUpper(),
                        Estado_agendamiento = "PENDIENTE"
                    };

                    rpta = EAgendamientoLectura.InsertarAgendamiento(eAgendamiento, out int id_agendamiento);
                    if (rpta.Equals("OK"))
                    {
                        Mensajes.MensajeOkForm("Se agendó correctamente la lectura!");
                    }
                    else
                    {
                        throw new Exception(rpta);
                    }
                }
            }
            catch (Exception ex)
            {
                MensajeEspera.CloseForm();
                timer1.Stop();
                contador = 0;
                syncSuccess = false;
                Mensajes.MensajeErrorCompleto(this.Name, "SincronizacionAgendamientos",
                    "Hubo un error sincronizando la información de agendamientos", ex.Message);
            }
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            if (this.DtLecturasPendientes != null)
            {
                if (this.gbFiltros.Visible)
                {
                    this.gbFiltros.Visible = false;
                }
                else
                {
                    this.gbFiltros.Visible = true;
                }
            }
        }

        private void FrmPlanillaLecturas_Load(object sender, EventArgs e)
        {
            this.Activate();
        }

        private bool BuscarClientesCorte(DataTable dtCuentasPendientes, EMedidor eMedidor)
        {
            bool result = true;
            if (dtCuentasPendientes != null)
            {
                DataRow[] rowsCuentas =
                    dtCuentasPendientes.Select(string.Format("Id_medidor = {0}", eMedidor.Id_medidor));
                if (rowsCuentas.Length == 0)
                    rowsCuentas = null;

                if (rowsCuentas != null)
                {
                    foreach (DataRow row in rowsCuentas)
                    {
                        int CantidadCuentas = Convert.ToInt32(row["CantidadCuentas"]);

                        if (CantidadCuentas == 2)
                        {
                            DataRow newRow = this.DtMedidoresProximoCorte.NewRow();
                            newRow["Id_medidor"] = Convert.ToString(row["Id_medidor"]);
                            newRow["Id_cliente"] = Convert.ToString(row["Id_cliente"]);
                            newRow["Medidor"] = Convert.ToString(row["Medidor"]);
                            newRow["Nombre_cliente"] = Convert.ToString(row["Nombres"]) + " " + Convert.ToString(row["Apellidos"]);
                            newRow["Fecha_pago"] = Convert.ToString(row["Fecha_pago"]);
                            newRow["Total_pagar"] = Convert.ToString(row["TotalDeuda"]);
                            newRow["Estado"] = "PENDIENTE DE CORTE";
                            this.DtMedidoresProximoCorte.Rows.Add(newRow);
                        }
                        else if (CantidadCuentas >= 3)
                        {
                            result = false;
                            if (!eMedidor.Estado_medidor.Equals("SERVICIO CORTADO"))
                            {
                                eMedidor.Estado_medidor = "SERVICIO CORTADO";
                                string rpta = EMedidor.EditarMedidor(eMedidor.Id_medidor, eMedidor);
                            }

                            DataRow newRow = this.DtMedidoresProximoCorte.NewRow();
                            newRow["Id_medidor"] = Convert.ToString(row["Id_medidor"]);
                            newRow["Id_cliente"] = Convert.ToString(row["Id_cliente"]);
                            newRow["Medidor"] = Convert.ToString(row["Medidor"]);
                            newRow["Nombre_cliente"] = Convert.ToString(row["Nombres"]) + " " + Convert.ToString(row["Apellidos"]);
                            newRow["Fecha_pago"] = Convert.ToString(row["Fecha_pago"]);
                            newRow["Total_pagar"] = Convert.ToString(row["TotalDeuda"]);
                            newRow["Estado"] = "SERVICIO CORTADO";
                            this.DtMedidoresProximoCorte.Rows.Add(newRow);
                        }
                    }
                }
            }

            return result;
        }

        private void BuscarLecturas(DataTable dtLecturasActuales, DataTable dtLecturasAnteriores)
        {
            try
            {
                if (dtLecturasActuales != null)
                {
                    this.dgvLecturas.BackgroundImage = null;

                    DataTable dtPlanilla = new DataTable("DtLecturasRealizadas");
                    dtPlanilla.Columns.Add("Id_lectura", typeof(int));
                    dtPlanilla.Columns.Add("Id_cliente", typeof(int));
                    dtPlanilla.Columns.Add("Id_medidor", typeof(int));
                    dtPlanilla.Columns.Add("Medidor", typeof(string));
                    dtPlanilla.Columns.Add("Nombre", typeof(string));
                    dtPlanilla.Columns.Add("Barrio", typeof(string));
                    dtPlanilla.Columns.Add("Direccion", typeof(string));
                    dtPlanilla.Columns.Add("Lectura_anterior", typeof(int));
                    dtPlanilla.Columns.Add("Lectura_actual", typeof(string));
                    dtPlanilla.Columns.Add("Total_consumo", typeof(string));
                    dtPlanilla.Columns.Add("Consumo_excedido", typeof(string));

                    foreach (DataRow row in dtLecturasActuales.Rows)
                    {
                        ELecturas lectura = new ELecturas(row);
                        int lectura_anterior = 0;
                        DataRow[] rowsLecturaAnterior;

                        if (dtLecturasAnteriores != null)
                        {
                            rowsLecturaAnterior =
                                dtLecturasAnteriores.Select(string.Format("Id_medidor = {0}", lectura.EMedidor.Id_medidor));
                            if (rowsLecturaAnterior.Length == 0)
                                rowsLecturaAnterior = null;
                        }
                        else
                            rowsLecturaAnterior = null;

                        if (rowsLecturaAnterior != null)
                        {
                            if (rowsLecturaAnterior.Length > 0)
                            {
                                lectura_anterior = Convert.ToInt32(rowsLecturaAnterior[0]["Valor_lectura"]);
                            }
                        }

                        DataRow newRow = dtPlanilla.NewRow();
                        newRow["Id_lectura"] = lectura.Id_lectura;
                        newRow["Id_cliente"] = lectura.ECliente.Id_cliente;
                        newRow["Id_medidor"] = lectura.EMedidor.Id_medidor;
                        newRow["Medidor"] = lectura.EMedidor.Medidor;
                        newRow["Nombre"] = lectura.ECliente.Nombres + " " + lectura.ECliente.Apellidos;
                        newRow["Barrio"] = lectura.EMedidor.DireccionCliente.EBarrio.Nombre;
                        newRow["Direccion"] = lectura.EMedidor.DireccionCliente.Direccion;
                        newRow["Lectura_anterior"] = lectura_anterior;
                        newRow["Lectura_actual"] = lectura.Valor_lectura;
                        newRow["Total_consumo"] = lectura.Total_consumo + " " + lectura.EMedida.Alias_medida;
                        newRow["Consumo_excedido"] = lectura.Consumo_excedido + " " + lectura.EMedida.Alias_medida;

                        dtPlanilla.Rows.Add(newRow);
                    }

                    this.DtLecturasRealizadas = dtPlanilla;
                }
                else
                {
                    this.dgvLecturas.clearDataSource();
                    this.dgvLecturas.BackgroundImage = Resources.No_hay_lecturas;
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BuscarLecturas",
                    "Hubo un error al buscar lecturas", ex.Message);
            }
        }

        private void DgvLecturas_DoubleClick(object sender, EventArgs e)
        {
            DataGridViewRow row = this.dgvLecturas.CurrentRow;

            if (row != null & this.isDoubleClick)
            {
                DataTable dtClientes = (DataTable)this.dgvLecturas.DataSource;

                if (dtClientes.TableName.Equals("DtClientesSinMedidor"))
                {
                    int id_cliente = Convert.ToInt32(row.Cells["Id_cliente"].Value);
                    FrmDireccionesCliente frmDireccionesCliente = new FrmDireccionesCliente
                    {
                        StartPosition = FormStartPosition.CenterScreen,
                        IsLectura = false,
                        IsObservarLectura = false
                    };
                    frmDireccionesCliente.AsignarDatos(new ECliente(id_cliente));
                    frmDireccionesCliente.ShowDialog();
                }
                else if (dtClientes.TableName.Equals("DtLecturasPendientes"))
                {
                    if (this.btnMes.Text.ToUpper() == this.MonthName(DateTime.Now.Month).ToUpper())
                    {
                        ECliente eCliente = new ECliente(Convert.ToInt32(row.Cells["Id_cliente"].Value));
                        EMedidor eMedidor = new EMedidor(Convert.ToInt32(row.Cells["Id_medidor"].Value));
                        FrmLectura frmLectura = new FrmLectura
                        {
                            StartPosition = FormStartPosition.CenterScreen,
                            Tag = row
                        };
                        frmLectura.AsignarDatos(eMedidor, eCliente, DateTime.Now.AddMonths(+1).Month);
                        frmLectura.ShowDialog();
                    }
                    else
                    {
                        Mensajes.MensajeInformacion("No puede ejecutar la lectura, verifique el mes", "Entendido");
                    }
                }
                else if (dtClientes.TableName.Equals("DtLecturasRealizadas"))
                {
                    int id_lectura = Convert.ToInt32(row.Cells["Id_lectura"].Value);
                    FrmLectura frmLectura = new FrmLectura
                    {
                        StartPosition = FormStartPosition.CenterScreen,
                        Tag = row,
                        IsEditar = true
                    };
                    frmLectura.AsignarDatos(id_lectura);
                    frmLectura.ShowDialog();
                }
            }
        }

        public string MonthName(int month)
        {
            DateTimeFormatInfo dtinfo = new CultureInfo("es-ES", false).DateTimeFormat;
            return dtinfo.GetMonthName(month);
        }

        private void BtnMes_Click(object sender, EventArgs e)
        {
            ListaMeses listaMeses = new ListaMeses
            {
                MaxMonth = DateTime.Now.Month + 1
            };
            listaMeses.OnBtnMesClick += ListaMeses_OnBtnMesClick;
            this.container = new PoperContainer(listaMeses);
            this.container.Show(this.btnMes);
        }

        private void ListaMeses_OnBtnMesClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (this.container != null)
                this.container.Close();
            this.btnMes.Text = btn.Text;
            this.btnMes.Tag = btn.Tag;
            int mes = Convert.ToInt32(btn.Tag);

            if (this.IsEditar)
            {
                //Lecturas del mes actual
                DataTable dtLecturas =
                    ELecturas.BuscarLecturas("LECTURA MES", this.btnMes.Text.ToUpper(), out string rpta);

                MensajeEspera.ChangeMensaje("Recopilando lecturas anteriores");
                //Obtener el mes que seleccionamos
                int mes_actual = Convert.ToInt32(this.btnMes.Tag);
                //Obtenemos el mes anterior al seleccionado
                string mes_anterior = mes_actual == 1 ? this.MonthName(12) : this.MonthName(mes_actual - 1);
                //Buscamos las lecturas anteriores
                DataTable dtLecturasMesAnterior =
                    ELecturas.BuscarLecturas("LECTURA MES", mes_anterior, out rpta);

                this.BuscarLecturas(dtLecturas, dtLecturasMesAnterior);
                this.btnLecturasRealizadas.PerformClick();
            }
            else
                this.SincronizacionAgendamientos(btnMes.Text.ToUpper());
        }

        public void AsignarDatosEditar()
        {
            this.IsEditar = true;
            this.btnImprimir.Enabled = false;
            this.btnSincronizar.Enabled = false;
            this.btnLecturasPendientes.Enabled = false;
            this.btnClientesSinMedidor.Enabled = false;
            this.btnClientesProxCorte.Enabled = false;
            this.btnClientesPendienteCortes.Enabled = false;
            this.btnHome.Visible = false;

            this.isDoubleClick = true;
            this.btnMes.PerformClick();
        }

        private bool _isEditar;
        private int _pageSize = 30;

        public bool IsEditar { get => _isEditar; set => _isEditar = value; }
        public int PageSize { get => _pageSize; set => _pageSize = value; }
    }
}
