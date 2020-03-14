using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaEntidades
{
    public class ETarifas
    {
        public ETarifas()
        {

        }

        public ETarifas(DataRow row)
        {
            try
            {
                this.Id_tarifa = Convert.ToInt32(row["Id_tarifa"]);
                this.Valor_tarifa = Convert.ToDecimal(row["Valor_tarifa"]);
                this.Tipo_tarifa = Convert.ToString(row["Tipo_tarifa"]);
                this.Descripcion = Convert.ToString(row["Descripcion"]);

                if (this.Tipo_tarifa.Equals("DETALLE"))
                {
                    DataTable dtDetalle = EDetalleTarifas.BuscarDetalleTarifa("ID TARIFA",
                        this.Id_tarifa.ToString(), out string rpta);
                    if (dtDetalle != null)
                    {
                        EDetalleTarifas eDetalleTarifa = new EDetalleTarifas(dtDetalle, 0);
                        this.EDetalleTarifa = eDetalleTarifa;
                    }
                    else
                    {
                        if (!rpta.Equals("OK"))
                            throw new Exception(rpta);
                    }
                }
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public ETarifas(DataTable dt, int fila)
        {
            try
            {
                this.Id_tarifa = Convert.ToInt32(dt.Rows[fila]["Id_tarifa"]);
                this.Valor_tarifa = Convert.ToDecimal(dt.Rows[fila]["Valor_tarifa"]);
                this.Tipo_tarifa = Convert.ToString(dt.Rows[fila]["Tipo_tarifa"]);
                this.Descripcion = Convert.ToString(dt.Rows[fila]["Descripcion"]);
                if (this.Tipo_tarifa.Equals("DETALLE"))
                {
                    DataTable dtDetalle = EDetalleTarifas.BuscarDetalleTarifa("ID TARIFA",
                        this.Id_tarifa.ToString(), out string rpta);
                    if (dtDetalle != null)
                    {
                        EDetalleTarifas eDetalleTarifa = new EDetalleTarifas(dtDetalle, 0);
                        this.EDetalleTarifa = eDetalleTarifa;
                    }
                    else
                    {
                        if (!rpta.Equals("OK"))
                            throw new Exception(rpta);
                    }
                }
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public ETarifas(int id_tarifa)
        {
            try
            {
                DataTable dt =
                    DTipo_tarifas.BuscarTipoTarifas("ID TARIFA", id_tarifa.ToString(), out string rpta);
                if (dt != null)
                {
                    this.Id_tarifa = Convert.ToInt32(dt.Rows[0]["Id_tarifa"]);
                    this.Valor_tarifa = Convert.ToDecimal(dt.Rows[0]["Valor_tarifa"]);
                    this.Tipo_tarifa = Convert.ToString(dt.Rows[0]["Tipo_tarifa"]);
                    this.Descripcion = Convert.ToString(dt.Rows[0]["Descripcion"]);
                    if (this.Tipo_tarifa.Equals("DETALLE"))
                    {
                        DataTable dtDetalle = EDetalleTarifas.BuscarDetalleTarifa("ID TARIFA",
                            this.Id_tarifa.ToString(), out rpta);
                        if (dtDetalle != null)
                        {
                            EDetalleTarifas eDetalleTarifa = new EDetalleTarifas(dtDetalle, 0);
                            this.EDetalleTarifa = eDetalleTarifa;
                        }
                        else
                        {
                            if (!rpta.Equals("OK"))
                                throw new Exception(rpta);
                        }
                    }
                }
                else
                {
                    if (!rpta.Equals("OK"))
                        throw new Exception(rpta);
                }
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public static string InsertarTarifa(ETarifas tarifa, out int id_tarifa)
        {
            List<string> vs = new List<string>
            {
                tarifa.Descripcion, tarifa.Valor_tarifa.ToString("N2"), tarifa.Tipo_tarifa.ToString()
            };
            return DTipo_tarifas.InsertarTipoTarifa(out id_tarifa, vs);
        }

        public static string EditarTarifa(ETarifas tarifa, int id_tarifa)
        {
            List<string> vs = new List<string>
            {
               tarifa.Descripcion, tarifa.Valor_tarifa.ToString("N2"), tarifa.Tipo_tarifa.ToString()
            };
            return DTipo_tarifas.EditarTipoTarifa(id_tarifa, vs);
        }

        public static DataTable BuscarTarifas(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            return DTipo_tarifas.BuscarTipoTarifas(tipo_busqueda, texto_busqueda, out rpta);
        }

        private int _id_tarifa;
        private decimal _valor_tarifa;
        private string _tipo_tarifa;
        private string _descripcion;
        private EDetalleTarifas _eDetalleTarifa;

        public int Id_tarifa { get => _id_tarifa; set => _id_tarifa = value; }
        public decimal Valor_tarifa { get => _valor_tarifa; set => _valor_tarifa = value; }
        public string Tipo_tarifa { get => _tipo_tarifa; set => _tipo_tarifa = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public EDetalleTarifas EDetalleTarifa { get => _eDetalleTarifa; set => _eDetalleTarifa = value; }

        public event EventHandler OnError;

    }
}
