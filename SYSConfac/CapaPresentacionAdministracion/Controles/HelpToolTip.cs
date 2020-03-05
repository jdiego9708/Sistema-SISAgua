using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacionAdministracion.Controles
{
    public partial class HelpToolTip : UserControl
    {
        public HelpToolTip()
        {
            InitializeComponent();
        }

        private void AsignarDatos(string texto)
        {
            this.txtTexto.Text = texto;
        }

        private string _texto;

        public string Texto
        {
            get => _texto;
            set
            {
                _texto = value;
                this.AsignarDatos(value);
            }
        }
    }
}
