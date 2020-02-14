using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;

namespace CapaPresentacionAdministracion.Formularios.FormsTarifas
{
    public partial class TarifaSmall : UserControl
    {
        public TarifaSmall()
        {
            InitializeComponent();
        }

        public ETarifas ETarifas;

        public void AsignarDatos(ETarifas tarifa)
        {
            this.ETarifas = tarifa;
            this.txtDescripcion.Text = tarifa.Descripcion;

            if (tarifa.Tipo_tarifa != null)
            {
                if (tarifa.Tipo_tarifa.Equals("UNICA"))
                {
                    this.gbConsMaximo.Visible = false;
                    this.gbConsMinimo.Visible = false;
                    this.gbMedida.Visible = false;
                    this.gbCostoExcedente.Visible = false;

                    this.gbCostoBase.Location = gbConsMaximo.Location;

                    if (tarifa.Descripcion.Equals("MANUAL") | tarifa.Descripcion.Equals("CONSUMO DE AGUA"))
                        this.gbCostoBase.Visible = false;

                    this.txtCostoBase.Text = tarifa.Valor_tarifa.ToString("N2");
                }
                else
                {
                    this.gbConsMaximo.Visible = true;
                    this.gbConsMinimo.Visible = true;
                    this.gbMedida.Visible = true;
                    this.gbCostoExcedente.Visible = true;

                    this.gbCostoBase.Location = new Point(171, 46);

                    this.txtConsumoMinimo.Text = tarifa.EDetalleTarifa.Consumo_minimo.ToString("N2");
                    this.txtConsumoMaximo.Text = tarifa.EDetalleTarifa.Consumo_maximo.ToString("N2");
                    this.txtMedida.Text = tarifa.EDetalleTarifa.EMedida.Descripcion_medida;
                    this.txtCostoExcedente.Text = tarifa.EDetalleTarifa.Valor_excedente.ToString("N2");
                    this.txtCostoBase.Text = tarifa.Valor_tarifa.ToString("N2");
                }
            }
        }
    }
}
