using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaEntidades
{
    public class EDetalleExcedente
    {
        public EDetalleExcedente()
        {

        }

        public EDetalleExcedente(DataRow row)
        {
            try
            {

                this.Id_detalle_excedente = Convert.ToInt32(row["Id_detalle_excedente"]);

                this.ETarifa = new ETarifas
                {
                    Id_tarifa = Convert.ToInt32(row["Id_tarifa"]),
                    Descripcion = Convert.ToString(row["Descripcion"]),
                    Valor_tarifa = Convert.ToDecimal(row["Valor_tarifa"]),
                    Tipo_tarifa = Convert.ToString(row["Tipo_tarifa"])
                };

                this.Nombre_excedente = Convert.ToString(row["Nombre_excedente"]);
                this.Consumo_minimo = Convert.ToInt32(row["Consumo_minimo"]);
                this.Consumo_maximo = Convert.ToInt32(row["Consumo_maximo"]);
                this.Valor_excedente = Convert.ToDecimal(row["Valor_excedente"]);

            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public EDetalleExcedente(DataTable dt, int fila)
        {
            try
            {
                this.Id_detalle_excedente = Convert.ToInt32(dt.Rows[fila]["Id_detalle_excedente"]);
                this.ETarifa = new ETarifas
                {
                    Id_tarifa = Convert.ToInt32(dt.Rows[fila]["Id_tarifa"]),
                    Descripcion = Convert.ToString(dt.Rows[fila]["Descripcion"]),
                    Valor_tarifa = Convert.ToDecimal(dt.Rows[fila]["Valor_tarifa"]),
                    Tipo_tarifa = Convert.ToString(dt.Rows[fila]["Tipo_tarifa"])
                };

                this.Nombre_excedente = Convert.ToString(dt.Rows[fila]["Nombre_excedente"]);
                this.Consumo_minimo = Convert.ToInt32(dt.Rows[fila]["Consumo_minimo"]);
                this.Consumo_maximo = Convert.ToInt32(dt.Rows[fila]["Consumo_maximo"]);
                this.Valor_excedente = Convert.ToDecimal(dt.Rows[fila]["Valor_excedente"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public static DataTable BuscarDetalleExcedentes(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            return DDetalleExcedentes.BuscarDetalleExcedentes(tipo_busqueda, texto_busqueda, out rpta);
        }

        public static string InsertarDetalleTarifa(EDetalleExcedente detalle)
        {
            List<string> vs = new List<string>
            {
                detalle.ETarifa.Id_tarifa.ToString(),
                detalle.Nombre_excedente,
                detalle.Consumo_minimo.ToString(),
                detalle.Consumo_maximo.ToString(),
                detalle.Valor_excedente.ToString("N2").Replace(",",".")
            };
            return DDetalleExcedentes.InsertarDetalleExcedente(vs);
        }

        public static string EditarDetalleTarifa(EDetalleExcedente detalle, int id_detalle_excedente)
        {
            List<string> vs = new List<string>
            {
                detalle.ETarifa.Id_tarifa.ToString(),
                detalle.Nombre_excedente,
                detalle.Consumo_minimo.ToString(),
                detalle.Consumo_maximo.ToString(),
                detalle.Valor_excedente.ToString("N2").Replace(",",".")
            };
            return DDetalleExcedentes.ModificarDetalleExcedente(id_detalle_excedente, vs);
        }

        private int _id_detalle_excedente;
        private ETarifas _eTarifa;
        private string _nombre_excedente;
        private int _consumo_minimo;
        private int _consumo_maximo;
        private decimal _valor_excedente;

        public int Id_detalle_excedente { get => _id_detalle_excedente; set => _id_detalle_excedente = value; }
        public ETarifas ETarifa { get => _eTarifa; set => _eTarifa = value; }
        public string Nombre_excedente { get => _nombre_excedente; set => _nombre_excedente = value; }
        public int Consumo_minimo { get => _consumo_minimo; set => _consumo_minimo = value; }
        public int Consumo_maximo { get => _consumo_maximo; set => _consumo_maximo = value; }
        public decimal Valor_excedente { get => _valor_excedente; set => _valor_excedente = value; }

        public event EventHandler OnError;
    }
}
