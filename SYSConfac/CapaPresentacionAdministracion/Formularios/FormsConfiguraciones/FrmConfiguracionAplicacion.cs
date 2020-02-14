using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaPresentacionAdministracion.Formularios.FormsConfiguraciones.FormsBD;
using CapaPresentacionAdministracion.Formularios.FormsConfiguraciones.FormsReportes;
using CapaPresentacionAdministracion.Formularios.FormsConfiguraciones.FormsTarifas;

namespace CapaPresentacionAdministracion.Formularios.FormsConfiguraciones
{
    public partial class FrmConfiguracionAplicacion : Form
    {
        public FrmConfiguracionAplicacion()
        {
            InitializeComponent();
            this.btnReportes.Click += BtnReportes_Click;
            this.btnRutaArchivos.Click += BtnRutaArchivos_Click;
            this.btnBaseDatos.Click += BtnBaseDatos_Click;
            this.Load += FrmConfiguracionAplicacion_Load;
            this.btnTarifas.Click += BtnTarifas_Click;
        }

        private void BtnTarifas_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.panel1.Controls.Count > 0)
                    this.panel1.Controls.Clear();

                FrmConfiguracionTarifas frm = new FrmConfiguracionTarifas
                {
                    TopLevel = false,
                    StartPosition = FormStartPosition.CenterParent,
                    Dock = DockStyle.Fill,
                    FormBorderStyle = FormBorderStyle.None
                };

                Form FormComprobado = this.ComprobarExistencia(frm);
                if (FormComprobado != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.Activate();
                }
                this.panel1.Controls.Add(frm);
                this.panel1.Tag = frm;
                frm.Show();
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnTarifas_Click",
                    "Hubo un error con el botón configuración tarifas", ex.Message);
            }
        }

        private void FrmConfiguracionAplicacion_Load(object sender, EventArgs e)
        {
            this.btnBaseDatos.PerformClick();
        }

        private void BtnBaseDatos_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.panel1.Controls.Count > 0)
                    this.panel1.Controls.Clear();

                FrmConexionBD frm = new FrmConexionBD
                {
                    TopLevel = false,
                    StartPosition = FormStartPosition.CenterParent,
                    Dock = DockStyle.Fill,
                    FormBorderStyle = FormBorderStyle.None
                };

                Form FormComprobado = this.ComprobarExistencia(frm);
                if (FormComprobado != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.Activate();
                }
                this.panel1.Controls.Add(frm);
                this.panel1.Tag = frm;
                frm.Show();
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnBaseDatos_Click",
                    "Hubo un error con el botón base de datos", ex.Message);
            }
        }

        private void BtnRutaArchivos_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.panel1.Controls.Count > 0)
                    this.panel1.Controls.Clear();

                FrmRutaArchivo frm = new FrmRutaArchivo
                {
                    TopLevel = false,
                    StartPosition = FormStartPosition.CenterParent,
                    Dock = DockStyle.Fill,
                    FormBorderStyle = FormBorderStyle.None
                };

                Form FormComprobado = this.ComprobarExistencia(frm);
                if (FormComprobado != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.Activate();
                }

                this.panel1.Controls.Add(frm);
                this.panel1.Tag = frm;
                frm.Show();

                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnRutaArchivos_Click",
                    "Hubo un error con el botón ruta archivo", ex.Message);
            }
        }

        private void BtnReportes_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.panel1.Controls.Count > 0)
                    this.panel1.Controls.Clear();

                FrmConfiguracionReportes frm = new FrmConfiguracionReportes
                {
                    TopLevel = false,
                    StartPosition = FormStartPosition.CenterParent,
                    Dock = DockStyle.Fill,
                    FormBorderStyle = FormBorderStyle.None
                };

                Form FormComprobado = this.ComprobarExistencia(frm);
                if (FormComprobado != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.Activate();
                }

                this.panel1.Controls.Add(frm);
                this.panel1.Tag = frm;
                frm.Show();

                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnReportes_Click",
                    "Hubo un error con el botón configuración reporte", ex.Message);
            }
        }

        private Form ComprobarExistencia(Form form)
        {
            Form frmDevolver = null;
            foreach (Control control in this.panel1.Controls)
            {
                if (control is Form frm)
                {
                    if (frm.Name.Equals(form.Name))
                    {
                        frmDevolver = frm;
                        break;
                    }
                }
            }

            return frmDevolver;
        }
    }
}
