using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacionAdministracion.Formularios.FormsPrincipales
{
    public partial class MenuOtrasConfiguraciones : UserControl
    {
        public MenuOtrasConfiguraciones()
        {
            InitializeComponent();
            this.Load += MenuOtrasConfiguraciones_Load;
        }

        private void MenuOtrasConfiguraciones_Load(object sender, EventArgs e)
        {
            this.CargarMenuParroquias();
            this.CargarMenuBarrios();
            this.CargarMenuCantones();
            this.CargarMenuMedidas();
            this.CargarMenuConfiguracionAvanzada();
        }

        #region CONFIGURACION AVANZADA

        public event EventHandler OnBtnConfiguracionAvanzada;
        public event EventHandler OnBtnConfiguracionAvanzada2;
        private void CargarMenuConfiguracionAvanzada()
        {
            MenuConfiguracionAvanzada menuConfiguracion = new MenuConfiguracionAvanzada();
            menuConfiguracion.btnConfiguracionAvanzada.Click += BtnConfiguracionAvanzada_Click;
            menuConfiguracion.btnConfig.Click += BtnConfig_Click;
            menuConfiguracion.Dock = DockStyle.Fill;
            this.gbConfiguracionAvanzada.Controls.Add(menuConfiguracion);
        }

        private void BtnConfig_Click(object sender, EventArgs e)
        {
            OnBtnConfiguracionAvanzada2?.Invoke(sender, e);
        }

        private void BtnConfiguracionAvanzada_Click(object sender, EventArgs e)
        {
            OnBtnConfiguracionAvanzada?.Invoke(sender, e);
        }

        #endregion

        #region MEDIDAS
        public event EventHandler OnBtnAgregarMedida;
        public event EventHandler OnBtnEditarMedida;
        public event EventHandler OnBtnObservarMedidas;
        private void CargarMenuMedidas()
        {
            MenuMedidas menuMedidas = new MenuMedidas();
            menuMedidas.btnAgregarMedida.Click += BtnAgregarMedida_Click;
            menuMedidas.btnEditarMedida.Click += BtnEditarMedida_Click;
            menuMedidas.btnObservarMedidas.Click += BtnObservarMedidas_Click;
            menuMedidas.Dock = DockStyle.Fill;
            this.gbMedidas.Controls.Add(menuMedidas);
        }

        private void BtnObservarMedidas_Click(object sender, EventArgs e)
        {
            OnBtnObservarMedidas?.Invoke(sender, e);
        }

        private void BtnEditarMedida_Click(object sender, EventArgs e)
        {
            OnBtnEditarMedida?.Invoke(sender, e);
        }

        private void BtnAgregarMedida_Click(object sender, EventArgs e)
        {
            OnBtnAgregarMedida?.Invoke(sender, e);
        }

        #endregion

        #region CANTONES
        public event EventHandler OnBtnAgregarCanton;
        public event EventHandler OnBtnEditarCanton;
        public event EventHandler OnBtnObservarCantones;
        private void CargarMenuCantones()
        {
            MenuCantones menuCantones = new MenuCantones();
            menuCantones.btnAgregarCanton.Click += BtnAgregarCanton_Click;
            menuCantones.btnEditarCanton.Click += BtnEditarCanton_Click;
            menuCantones.btnObservarCantones.Click += BtnObservarCantones_Click;
            menuCantones.Dock = DockStyle.Fill;
            this.gbCantones.Controls.Add(menuCantones);
        }

        private void BtnObservarCantones_Click(object sender, EventArgs e)
        {
            OnBtnObservarCantones?.Invoke(sender, e);
        }

        private void BtnEditarCanton_Click(object sender, EventArgs e)
        {
            OnBtnEditarCanton?.Invoke(sender, e);
        }

        private void BtnAgregarCanton_Click(object sender, EventArgs e)
        {
            OnBtnAgregarCanton?.Invoke(sender, e);
        }

        #endregion

        #region PARROQUIAS
        public event EventHandler OnBtnAgregarParroquia;
        public event EventHandler OnBtnEditarParroquia;
        public event EventHandler OnBtnObservarParroquias;

        private void CargarMenuParroquias()
        {
            MenuParroquias menuParroquias = new MenuParroquias();
            menuParroquias.btnAgregarParroquia.Click += BtnAgregarParroquia_Click;
            menuParroquias.btnEditarParroquia.Click += BtnEditarParroquia_Click;
            menuParroquias.btnObservarParroquias.Click += BtnObservarParroquias_Click;
            menuParroquias.Dock = DockStyle.Fill;
            gbParroquias.Controls.Add(menuParroquias);
        }

        private void BtnObservarParroquias_Click(object sender, EventArgs e)
        {
            this.OnBtnObservarParroquias?.Invoke(sender, e);
        }

        private void BtnEditarParroquia_Click(object sender, EventArgs e)
        {
            this.OnBtnEditarParroquia?.Invoke(sender, e);
        }

        private void BtnAgregarParroquia_Click(object sender, EventArgs e)
        {
            this.OnBtnAgregarParroquia?.Invoke(sender, e);
        }
        #endregion

        #region BARRIOS
        public event EventHandler OnBtnAgregarBarrio;
        public event EventHandler OnBtnEditarBarrio;
        public event EventHandler OnBtnObservarBarrios;
        private void CargarMenuBarrios()
        {
            MenuBarrios menuBarrios = new MenuBarrios();
            menuBarrios.btnAgregarBarrio.Click += BtnAgregarBarrio_Click;
            menuBarrios.btnEditarBarrio.Click += BtnEditarBarrio_Click;
            menuBarrios.btnObservarBarrios.Click += BtnObservarBarrios_Click;
            menuBarrios.Dock = DockStyle.Fill;
            this.gbBarrios.Controls.Add(menuBarrios);
        }

        private void BtnObservarBarrios_Click(object sender, EventArgs e)
        {
            OnBtnObservarBarrios?.Invoke(sender, e);
        }

        private void BtnEditarBarrio_Click(object sender, EventArgs e)
        {
            OnBtnEditarBarrio?.Invoke(sender, e);
        }

        private void BtnAgregarBarrio_Click(object sender, EventArgs e)
        {
            OnBtnAgregarBarrio?.Invoke(sender, e);
        }

        #endregion
    }
}
