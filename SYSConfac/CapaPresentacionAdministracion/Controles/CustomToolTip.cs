using System.Windows.Forms;

namespace CapaPresentacionAdministracion
{
    public partial class CustomToolTip : UserControl
    {
        public CustomToolTip()
        {
            InitializeComponent();
        }

        private void TituloChanged(string value)
        {
            this.txtTitulo.Text = value;
        }
        private void DescripcionChanged(string value)
        {
            this.txtDescripcion.Text = value;
        }

        private string _titulo;
        private string _descripcion;

        public string Titulo
        {
            get => _titulo;
            set
            {
                _titulo = value;
                this.TituloChanged(value);
            }
        }
        public string Descripcion
        {
            get => _descripcion;
            set
            {
                _descripcion = value;
                this.DescripcionChanged(value);
            }
        }
    }
}
