using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacionAdministracion.Formularios.FormsLecturas
{
    public partial class ListaMeses : UserControl
    {
        public ListaMeses()
        {
            InitializeComponent();
            this.Load += ListaMeses_Load;
        }

        public event EventHandler OnBtnMesClick;

        private void ListaMeses_Load(object sender, EventArgs e)
        {
            this.CargarEventos();
        }

        private void CargarEventos()
        {
            foreach (Button btn in this.panel1.Controls)
            {
                int mes = Convert.ToInt32(btn.Tag);
                if (mes <= MaxMonth)
                {
                    btn.Enabled = true;
                    btn.Click += Btn_Click;
                }
                else
                    btn.Enabled = false;
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            OnBtnMesClick?.Invoke(sender, e);
        }

        private int _maxMonth;

        public int MaxMonth { get => _maxMonth; set => _maxMonth = value; }
    }
}
