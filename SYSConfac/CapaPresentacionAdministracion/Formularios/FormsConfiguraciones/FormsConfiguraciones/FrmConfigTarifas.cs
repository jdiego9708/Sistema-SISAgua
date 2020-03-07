using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacionAdministracion.Formularios.FormsConfiguraciones.FormsConfiguraciones
{
    public partial class FrmConfigTarifas : Form
    {
        public FrmConfigTarifas()
        {
            InitializeComponent();
        }

        public event EventHandler OnBtnSiguiente;
        public event EventHandler OnBtnAtras;
    }
}
