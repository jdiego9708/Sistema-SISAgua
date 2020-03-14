using CapaEntidades;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacionAdministracion.Formularios.FormsDireccionClientes
{
    public partial class DireccionesCliente : UserControl
    {
        PoperContainer container;
        FrmAgregarDireccionCliente frmAgregarDireccionCliente;
        public DireccionesCliente()
        {
            InitializeComponent();

            this.MouseEnter += DireccionesCliente_MouseEnter;
            this.groupBox1.MouseEnter += DireccionesCliente_MouseEnter;
            this.lblResultados.MouseEnter += DireccionesCliente_MouseEnter;
            this.panel1.MouseEnter += DireccionesCliente_MouseEnter;
            this.btnAgregarDireccion.MouseEnter += DireccionesCliente_MouseEnter;
            this.txtCliente.MouseEnter += DireccionesCliente_MouseEnter;

            this.MouseLeave += DireccionesCliente_MouseLeave;
            this.groupBox1.MouseLeave += DireccionesCliente_MouseLeave;
            this.lblResultados.MouseLeave += DireccionesCliente_MouseLeave;
            this.panel1.MouseLeave += DireccionesCliente_MouseLeave;
            this.btnAgregarDireccion.MouseLeave += DireccionesCliente_MouseLeave;
            this.txtCliente.MouseLeave += DireccionesCliente_MouseLeave;

            this.btnAgregarDireccion.Click += BtnAgregarDireccion_Click;
        }

        private void BtnAgregarDireccion_Click(object sender, EventArgs e)
        {
            if (this.frmAgregarDireccionCliente == null)
            {
                frmAgregarDireccionCliente = new FrmAgregarDireccionCliente
                {
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill,
                    TopLevel = false
                };
                frmAgregarDireccionCliente.ObtenerCliente(this.eCliente.Id_cliente,
                    this.eCliente.Nombres + " " + this.eCliente.Apellidos);
                frmAgregarDireccionCliente.btnCliente.Enabled = false;
                frmAgregarDireccionCliente.OnClientSaved += FrmAgregarDireccionCliente_OnClientSaved;
            }

            container = new PoperContainer(frmAgregarDireccionCliente);
            container.Show(btnAgregarDireccion);
            frmAgregarDireccionCliente.Show();
        }

        private void FrmAgregarDireccionCliente_OnClientSaved(object sender, EventArgs e)
        {
            this.frmAgregarDireccionCliente = null;
            this.AsignarDatos(this.eCliente);
            if (this.container != null)
                this.container.Close();
        }

        private void DireccionesCliente_MouseLeave(object sender, EventArgs e)
        {
            this.panel2.BackColor = Color.FromArgb(0, 192, 192);
        }

        private void DireccionesCliente_MouseEnter(object sender, EventArgs e)
        {
            this.panel2.BackColor = Color.Teal;
        }

        public ECliente eCliente;

        public void AsignarDatos(ECliente cliente)
        {
            try
            {
                this.eCliente = cliente;
                this.txtCliente.Text = cliente.Nombres + " " + cliente.Apellidos;
                DataTable dtDirecciones =
                    EDireccionCliente.BuscarDirecciones("COMPLETO ID CLIENTE", cliente.Id_cliente.ToString(),
                    out string rpta);
                this.panel1.Limpiar();
                if (dtDirecciones != null)
                {
                    int ancho = this.Width;
                    int altoTotal = this.Height;
                    DireccionSmall small = new DireccionSmall();
                    int altoSmall = small.Height;

                    if (dtDirecciones.Rows.Count == 1)
                    {
                        this.lblResultados.Text = "Hay una dirección registrada";

                        int altoModificado = altoTotal - this.panel1.Height + altoSmall;
                        this.Size = new Size(ancho, altoModificado);
                    }
                    else if (dtDirecciones.Rows.Count == 2)
                    {
                        this.lblResultados.Text = "Hay " + dtDirecciones.Rows.Count + " direcciones registradas";

                        int altoModificado = altoTotal - this.panel1.Height + (altoSmall * 2);
                        this.Size = new Size(ancho, altoModificado);
                    }
                    else if (dtDirecciones.Rows.Count > 2)
                    {
                        this.lblResultados.Text = "Hay " + dtDirecciones.Rows.Count + " direcciones registradas";

                        int altoModificado = altoTotal - this.panel1.Height + (altoSmall * 3);
                        this.Size = new Size(ancho, altoModificado);
                    }

                    foreach (DataRow row in dtDirecciones.Rows)
                    {
                        EDireccionCliente direccion = new EDireccionCliente(row);
                        DireccionSmall direccionSmall = new DireccionSmall
                        {
                            IsLectura = this.IsLectura,
                            IsObservarLectura = this.IsObservarLectura
                        };
                        direccionSmall.AsignarDatos(direccion);
                        direccionSmall.OnClientSaved += DireccionSmall_OnClientSaved;
                        direccionSmall.MouseEnter += DireccionesCliente_MouseEnter;
                        direccionSmall.MouseLeave += DireccionesCliente_MouseLeave;
                        direccionSmall.OnBtnNextClick += DireccionSmall_OnBtnNextClick;

                        this.panel1.AddControl(direccionSmall);
                    }
                }
                else
                {
                    int ancho = this.Width;
                    int altoTotal = this.Height;
                    int altoModificado = altoTotal - this.panel1.Height;
                    this.Size = new Size(ancho, altoModificado);

                    this.lblResultados.Text = "No hay direcciones registradas";

                    if (!rpta.Equals("OK"))
                        throw new Exception(rpta);
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "AsignarDatos(ECliente cliente)",
                    "Hubo un error al asignar los datos de un cliente", ex.Message);
            }

        }

        private void DireccionSmall_OnBtnNextClick(object sender, EventArgs e)
        {
            OnBtnNextClick?.Invoke(sender, e);
        }

        private void DireccionSmall_OnClientSaved(object sender, EventArgs e)
        {
            this.AsignarDatos(eCliente);
        }

        public event EventHandler OnBtnNextClick;

        private bool _isLectura = false;
        private bool _isObservarLectura = false;

        public bool IsLectura { get => _isLectura; set => _isLectura = value; }
        public bool IsObservarLectura { get => _isObservarLectura; set => _isObservarLectura = value; }
    }
}
