using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaEntidades
{
    public class EDetalleTarifas
    {
        public EDetalleTarifas()
        {

        }

        public EDetalleTarifas(DataRow row)
        {
            try
            {
                this.ETarifa = new ETarifas
                {
                    Id_tarifa = Convert.ToInt32(row["Id_tarifa"])
                };
                this.EMedida = new EMedida
                {
                    Id_medida = Convert.ToInt32(row["Id_medida"]),
                    Descripcion_medida = Convert.ToString(row["Descripcion_medida"]),
                    Alias_medida = Convert.ToString(row["Alias_medida"])
                };
                this.Valor_base = Convert.ToDecimal(row["Valor_base"]);
                this.Consumo_minimo = Convert.ToInt32(row["Consumo_minimo"]);
                this.Consumo_maximo = Convert.ToInt32(row["Consumo_maximo"]);
                this.Valor_excedente = Convert.ToDecimal(row["Valor_excedente"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public EDetalleTarifas(DataTable dt, int fila)
        {
            try
            {
                this.ETarifa = new ETarifas
                {
                    Id_tarifa = Convert.ToInt32(dt.Rows[fila]["Id_tarifa"])
                };
                this.EMedida = new EMedida
                {
                    Id_medida = Convert.ToInt32(dt.Rows[fila]["Id_medida"]),
                    Descripcion_medida = Convert.ToString(dt.Rows[fila]["Descripcion_medida"]),
                    Alias_medida = Convert.ToString(dt.Rows[fila]["Alias_medida"])
                };
                this.Valor_base = Convert.ToDecimal(dt.Rows[fila]["Valor_base"]);
                this.Consumo_minimo = Convert.ToInt32(dt.Rows[fila]["Consumo_minimo"]);
                this.Consumo_maximo = Convert.ToInt32(dt.Rows[fila]["Consumo_maximo"]);
                string excedente = Convert.ToString(dt.Rows[fila]["Valor_excedente"]);
                this.Valor_excedente = Convert.ToDecimal(excedente);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public static DataTable BuscarDetalleTarifa(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            return DDetalleTarifas.BuscarDetalleTarifa(tipo_busqueda, texto_busqueda, out rpta);
        }

        public static string InsertarDetalleTarifa(EDetalleTarifas detalle)
        {
            List<string> vs = new List<string>
            {
                detalle.ETarifa.Id_tarifa.ToString(),
                detalle.EMedida.Id_medida.ToString(),
                detalle.Valor_base.ToString("N2"),
                detalle.Consumo_minimo.ToString(),
                detalle.Consumo_maximo.ToString(),
                detalle.Valor_excedente.ToString("N2")
            };
            return DDetalleTarifas.InsertarDetalleTarifa(vs);
        }

        public static string EditarDetalleTarifa(EDetalleTarifas detalle, int id_detalle)
        {
            List<string> vs = new List<string>
            {
                detalle.ETarifa.Id_tarifa.ToString(),
                detalle.EMedida.Id_medida.ToString(),
                detalle.Valor_base.ToString("N2"),
                detalle.Consumo_minimo.ToString(),
                detalle.Consumo_maximo.ToString(),
                detalle.Valor_excedente.ToString("N2")
            };
            return DDetalleTarifas.ModificarDetalleTarifa(id_detalle, vs);
        }

        private int _id_detalle_tarifa;
        private ETarifas _eTarifa;
        private EMedida _eMedida;
        private decimal _valor_base;
        private int _consumo_minimo;
        private int _consumo_maximo;
        private decimal _valor_excedente;

        public int Id_detalle_tarifa { get => _id_detalle_tarifa; set => _id_detalle_tarifa = value; }
        public decimal Valor_base { get => _valor_base; set => _valor_base = value; }
        public int Consumo_minimo { get => _consumo_minimo; set => _consumo_minimo = value; }
        public int Consumo_maximo { get => _consumo_maximo; set => _consumo_maximo = value; }
        public decimal Valor_excedente { get => _valor_excedente; set => _valor_excedente = value; }
        public ETarifas ETarifa { get => _eTarifa; set => _eTarifa = value; }
        public EMedida EMedida { get => _eMedida; set => _eMedida = value; }

        public event EventHandler OnError;
    }
}
