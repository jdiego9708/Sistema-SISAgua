using CapaEntidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacionAdministracion.Formularios.FormsLecturas
{
    public partial class LecturaSmall : UserControl
    {
        public LecturaSmall()
        {
            InitializeComponent();
        }

        public ELecturas ELectura;
        public ELecturas ELecturaAnterior;
        private int total_excedente;

        public int Total_excedente { get => total_excedente; set => total_excedente = value; }

        public void AsignarDatos(ELecturas lectura)
        {
            if (lectura != null)
            {
                this.ELectura = lectura;
                DateTime fecha = Convert.ToDateTime(lectura.Fecha_lectura);
                DateTime hora = Convert.ToDateTime(lectura.Hora_lectura);
                this.txtFechaHora.Text = fecha.ToString("ddd - dd - MMMM - yyyy") + " - " + hora.ToString("hh:mm tt");
                this.toolTip1.SetToolTip(this.txtFechaHora, fecha.ToLongDateString() + " - " + hora.ToLongTimeString());

                this.txtTarifa.Text = lectura.ETarifas.Descripcion;
                this.txtConsumoRegistrado.Text = lectura.Valor_lectura + " M3";
                this.txtMes.Text = lectura.Mes_lectura;

                this.txtTotal.Text = "USD$ " + lectura.ECuenta.Total_pagar.ToString("N2");

                this.txtMedidor.Text = lectura.EMedidor.Medidor;

                int lectura_anterior = 0;

                DataTable dtLecturaAnterior =
                    ELecturas.BuscarLecturas("LECTURA ANTERIOR ID MEDIDOR", lectura.EMedidor.Id_medidor.ToString(),
                    out string rpta);
                if (dtLecturaAnterior != null)
                {
                    if (dtLecturaAnterior.Rows.Count == 1)
                    {
                        ELecturas lec = new ELecturas(dtLecturaAnterior, 0);
                        if (lec.Id_lectura == lectura.Id_lectura)
                        {
                            this.ELecturaAnterior = null;
                        }
                        else
                        {
                            lectura_anterior = lec.Valor_lectura;
                            this.ELecturaAnterior = lec;
                        }
                    }
                    else
                    {
                        ELecturas lec = new ELecturas(dtLecturaAnterior, 0);
                        if (lec.Id_lectura == lectura.Id_lectura)
                        {
                            lec = new ELecturas(dtLecturaAnterior, 1);
                            this.ELecturaAnterior = lec;
                            lectura_anterior = lec.Valor_lectura;
                        }
                        else
                        {
                            this.ELecturaAnterior = lec;
                            lectura_anterior = lec.Valor_lectura;
                        }
                    }
                }
                else
                {
                    this.ELecturaAnterior = null;
                }

                int consumo_mes = lectura.Valor_lectura - lectura_anterior;
                int cantidad_sobrepasada = 0;
                int consumo_base = lectura.ETarifas.EDetalleTarifa.Consumo_maximo;

                if (consumo_mes > consumo_base)
                {
                    //Cantidad sobrepasada
                    cantidad_sobrepasada = consumo_mes - consumo_base;
                }

                this.Total_excedente = cantidad_sobrepasada;

            }
        }
    }
}
