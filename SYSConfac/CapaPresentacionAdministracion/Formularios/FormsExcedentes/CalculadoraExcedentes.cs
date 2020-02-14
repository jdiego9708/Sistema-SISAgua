using CapaEntidades;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacionAdministracion.Formularios.FormsExcedentes
{
    public partial class CalculadoraExcedentes : UserControl
    {
        public CalculadoraExcedentes()
        {
            InitializeComponent();
        }

        EDetalleTarifas EDetalleTarifas;

        public DataTable dtExcedentes;
        public DataTable dtValoresExcedentes;

        public void AsignarDatos(EDetalleTarifas eDetalle, int total_excedente)
        {
            try
            {
                this.Total_excedente = 0;
                this.Cantidad_excedente = total_excedente;
                this.EDetalleTarifas = eDetalle;
                //Buscar los excedentes que hayan en la base de datos
                DataTable dtDetalleExcedentes =
                    EDetalleExcedente.BuscarDetalleExcedentes("COMPLETO", "", out string rpta);
                if (dtDetalleExcedentes != null)
                {
                    //Creamos una tabla donde almacenaremos los excedentes en el formato legible
                    dtExcedentes = new DataTable();
                    dtExcedentes.Columns.Add("Nombre", typeof(string));
                    dtExcedentes.Columns.Add("Valor", typeof(string));
                    dtExcedentes.Columns.Add("Rango", typeof(string));

                    //Creamos una tabla donde almacenaremos los valores de los excedentes
                    dtValoresExcedentes = new DataTable();
                    dtValoresExcedentes.Columns.Add("Nombre", typeof(string));
                    dtValoresExcedentes.Columns.Add("Valor", typeof(string));

                    int excedente_sumado = 0;
                    int contador = 1;
                    //Recorremos los excedentes encontrados
                    foreach (DataRow row in dtDetalleExcedentes.Rows)
                    {
                        //Almacenamos la información de la fila recorrida
                        string nombre = Convert.ToString(row["Nombre_excedente"]);
                        int consumo_minimo = Convert.ToInt32(row["Consumo_minimo"]);
                        int consumo_maximo = Convert.ToInt32(row["Consumo_maximo"]);
                        decimal valor_exc = Convert.ToDecimal(row["Valor_excedente"]);
                        //Creamos una nueva fila y asignamos
                        DataRow newRow = dtExcedentes.NewRow();
                        newRow["Nombre"] = nombre;
                        newRow["Valor"] = "$" + valor_exc.ToString("N2");
                        newRow["Rango"] = consumo_minimo + "/" + consumo_maximo;
                        dtExcedentes.Rows.Add(newRow);

                        if (total_excedente <= consumo_maximo)
                        {
                            //Creamos una nueva fila y asignamos
                            DataRow newRowExcedente = dtValoresExcedentes.NewRow();
                            newRowExcedente["Nombre"] = "Valor excedente " + contador + ": ";
                            newRowExcedente["Valor"] = "$" + (valor_exc * (total_excedente - excedente_sumado)).ToString("N2");
                            dtValoresExcedentes.Rows.Add(newRowExcedente);

                            ////Creamos una nueva fila y asignamos
                            //DataRow newRowBase = dtValoresExcedentes.NewRow();
                            //newRowBase["Nombre"] = "Valor base: ";
                            //newRowBase["Valor"] = "$" + this.EDetalleTarifas.Valor_base.ToString("N2");
                            //dtValoresExcedentes.Rows.Add(newRowBase);
                            break;
                        }
                        else
                        {
                            //Creamos una nueva fila y asignamos
                            DataRow newRowExcedente = dtValoresExcedentes.NewRow();
                            newRowExcedente["Nombre"] = "Valor excedente " + contador + ": ";
                            newRowExcedente["Valor"] = "$" + (valor_exc * (consumo_maximo + 1 - consumo_minimo)).ToString("N2");
                            dtValoresExcedentes.Rows.Add(newRowExcedente);
                            excedente_sumado += (consumo_maximo + 1 - consumo_minimo);
                        }

                        contador += 1;
                    }

                    this.dgvTarifasExcesos.DataSource = dtExcedentes;

                    contador = 1;

                    int locationX = 0;
                    int locationY = 0;
                    this.panelExcedentes.Controls.Clear();
                    if (total_excedente > 0)
                    {
                        foreach (DataRow dataRow in dtValoresExcedentes.Rows)
                        {
                            string nombre = Convert.ToString(dataRow["Nombre"]);

                            string valor1 = Convert.ToString(dataRow["Valor"]).Replace("$", "");
                            decimal valor = Convert.ToDecimal(valor1);

                            Label lbl = new Label();
                            lbl.AutoSize = true;
                            lbl.Font = new Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            lbl.Location = new Point(locationX, locationY);
                            lbl.Name = "lblValorExcedente" + contador;
                            lbl.Text = nombre + "$" + valor;
                            contador += 1;

                            locationY = lbl.Location.Y + lbl.Height + 1;
                            this.panelExcedentes.Controls.Add(lbl);

                            this.Total_excedente += valor;
                        }

                        if (!this.IsReporte)
                            this.Total_excedente += eDetalle.Valor_base;
                    }
                    else
                    {
                        this.Total_excedente = eDetalle.Valor_base;
                    }

                    this.lblTotalExceso.Text = "Total exceso: " + total_excedente + eDetalle.EMedida.Alias_medida;
                    this.lblMedidaBase.Text = eDetalle.EMedida.Alias_medida +
                        " base: " + eDetalle.Consumo_minimo + "/" + eDetalle.Consumo_maximo + " " + eDetalle.EMedida.Alias_medida;
                    this.lblValorBase.Text = "Valor base: $" + eDetalle.Valor_base.ToString("N2");
                    this.lblCostoBase.Text = "Costo base: $" + eDetalle.Valor_base.ToString("N2");
                }
                else
                {
                    if (!rpta.Equals("OK"))
                        throw new Exception(rpta);
                }

            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "AsignarDatos",
                    "Hubo un error al asignar los datos en CalculadoraExcedentes", ex.Message);
            }
        }

        private decimal _total_excedente;
        private int _cantidad_excedente;
        private bool _isReporte = false;

        public decimal Total_excedente { get => _total_excedente; set => _total_excedente = value; }
        public int Cantidad_excedente { get => _cantidad_excedente; set => _cantidad_excedente = value; }
        public bool IsReporte { get => _isReporte; set => _isReporte = value; }
    }
}
