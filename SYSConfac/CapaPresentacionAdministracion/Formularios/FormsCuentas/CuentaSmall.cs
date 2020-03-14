using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;

namespace CapaPresentacionAdministracion.Formularios.FormsCuentas
{
    public partial class CuentaSmall : UserControl
    {
        public CuentaSmall()
        {
            InitializeComponent();
            this.btnOpciones.Click += BtnOpciones_Click;
        }

        public event EventHandler OnBtnOpcionesClick;

        private void BtnOpciones_Click(object sender, EventArgs e)
        {
            OnBtnOpcionesClick?.Invoke(this.ECuenta, e);
        }

        public ECuentas ECuenta;
        private bool _isCaja;

        public bool IsCaja { get => _isCaja; set => _isCaja = value; }

        public void AsignarDatos(ECuentas eCuentas)
        {
            this.ECuenta = eCuentas;
            this.txtFechaPago.Text = eCuentas.Fecha_pago.ToLongDateString();
            this.txtTotalPagar.Text = "Valor a pagar: $" + eCuentas.Total_pagar.ToString("N2");
        }
    }
}
