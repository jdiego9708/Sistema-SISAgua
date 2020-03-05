using CapaPresentacionAdministracion.Controles;
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
    public partial class FrmConfigGeneral : Form
    {
        PoperContainer container;
        HelpToolTip helpToolTip;

        public FrmConfigGeneral()
        {
            InitializeComponent();
            this.btnRuta.Click += BtnRuta_Click;
            this.btnAyudaRuta.MouseEnter += BtnAyuda_MouseEnter;
            this.btnAyudaRuta.MouseLeave += BtnAyuda_MouseLeave;
            this.btnAyudaCaja.MouseEnter += BtnAyuda_MouseEnter;
        }

        public event EventHandler OnBtnSiguiente;
        public event EventHandler OnBtnAtras;

        private void BtnAyuda_MouseLeave(object sender, EventArgs e)
        {
            if (this.container != null)
                this.container.Close();
        }

        private void BtnAyuda_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (this.helpToolTip == null)
                this.helpToolTip = new HelpToolTip();

            string tipo = Convert.ToString(btn.Tag);
            switch (tipo)
            {
                case "RUTA":
                    this.helpToolTip.Texto = "Se trata de la ruta por defecto que tendrá el programa para guardar los archivos";
                    break;
                case "CAJA":
                    this.helpToolTip.Texto = "Se trata de la caja predeterminada que se tomará en el módulo de caja";
                    break;
                case "MESES ALERTA":
                    this.helpToolTip.Texto = "Indica del número de meses pendientes que debe tener una cuenta de cobro " +
                        "para mostrar una notificación de próximo corte. Debe ser menor que los meses de corte";
                    break;
                case "MESES CORTE":
                    this.helpToolTip.Texto = "Indica del número de meses pendientes que debe tener una cuenta de cobro " +
                        "para realizar el corte del servicio.";
                    break;
            }

            this.container = new PoperContainer(this.helpToolTip);
            this.container.Show(this.btnRuta);
        }

        private void BtnRuta_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string folderName = fbd.SelectedPath;
                    this.btnRuta.Text = folderName;
                    this.btnRuta.Tag = folderName;
                }
                else
                {
                    this.btnRuta.Text = "Seleccionar ruta";
                }
            }
        }
    }
}
