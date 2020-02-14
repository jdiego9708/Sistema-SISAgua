using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacionAdministracion
{
    public class ListTools
    {
        public static ComboBox ListaHoras(ComboBox lista)
        {
            lista.Items.Clear();
            lista.DataSource = null;

            DataTable dtHoras = new DataTable("Horas");
            dtHoras.Columns.Add("Hora");
            dtHoras.Columns.Add("Texto_hora");

            int contador24hours = 1;
            int contador12hours = 1;
            string tipo = "am";
            while (contador24hours <= 24)
            {
                DataRow row = dtHoras.NewRow();
                row["Hora"] = contador24hours + ":00";
                row["Texto_hora"] = contador12hours + ":00 " + tipo;
                dtHoras.Rows.Add(row);
                contador24hours += 1;
                contador12hours += 1;
                if (contador12hours > 12)
                {
                    contador12hours = 1;
                    tipo = "pm";
                }
            }

            lista.DataSource = dtHoras;
            lista.ValueMember = "Hora";
            lista.DisplayMember = "Texto_hora";

            return lista;
        }
    }
}
