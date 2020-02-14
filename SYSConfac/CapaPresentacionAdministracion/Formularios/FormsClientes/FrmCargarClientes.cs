using CapaEntidades;
using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CapaPresentacionAdministracion.Formularios.FormsClientes
{
    public partial class FrmCargarClientes : Form
    {
        public FrmCargarClientes()
        {
            InitializeComponent();

            this.Load += FrmCargarClientes_Load;

            this.btnImportar.Click += BtnImportar_Click;
            this.btnMostrarEsquema.Click += BtnMostrarEsquema_Click;
            this.txtHoja.Click += TxtHoja_Click;
            this.txtHoja.LostFocus += TxtHoja_LostFocus;
            this.btnIniciar.Click += BtnIniciar_Click;
            this.lblResultados.Click += LblResultados_Click;
        }

        private void AddError(string descripcion)
        {
            DataRow row = this.dtErrores.NewRow();
            row["Descripcion"] = descripcion;
            this.dtErrores.Rows.Add(row);

            this.lblResultados.Text = "Se han encontrado errores " +
                "en el procesamiento, verifique";
            this.lblResultados.ForeColor = Color.Red;          
        }

        private void CrearTablaErrores()
        {
            this.dtErrores = new DataTable("Errores");
            this.dtErrores.Columns.Add("Descripcion", typeof(string));
        }

        private void FrmCargarClientes_Load(object sender, EventArgs e)
        {
            this.lblResultados.Cursor = Cursors.Hand;
            this.CrearTablaErrores();
        }

        private bool VerificarCanton(out int id_canton, string canton)
        {
            id_canton = 0;
            bool result = true;
            try
            {
                DataTable dtCanton =
                    ECanton.BuscarCantones("NOMBRE EXACTO", canton, out string rpta);
                if (dtCanton != null)
                {
                    result = true;
                    ECanton eCanton = new ECanton(dtCanton, 0);
                    id_canton = eCanton.Id_canton;
                }
                else
                {
                    throw new Exception(rpta);
                }
            }
            catch (Exception ex)
            {
                result = false;
                if (ex.Message.Equals("OK"))
                {
                    this.AddError("No existe el canton " + canton + " en la base de datos");
                }
                else
                {
                    this.AddError("Hubo un error al buscar el cantón, detalles: " + ex.Message);
                }
            }
            return result;
        }

        private bool VerificarParroquia(out int id_parroquia, string parroquia)
        {
            id_parroquia = 0;
            bool result = true;
            try
            {
                DataTable dtParroquia =
                    EParroquia.BuscarParroquias("NOMBRE EXACTO", parroquia, out string rpta);
                if (dtParroquia != null)
                {
                    result = true;
                    EParroquia eParroquia = new EParroquia(dtParroquia, 0);
                    id_parroquia = eParroquia.Id_parroquia;
                }
                else
                    throw new Exception(rpta);
            }
            catch (Exception ex)
            {
                result = false;
                if (ex.Message.Equals("OK"))
                {
                    this.AddError("No existe la parroquia " + parroquia + " en la base de datos");
                }
                else
                {
                    this.AddError("Hubo un error al buscar la parroquia, detalles: " + ex.Message);
                }
            }
            return result;
        }

        private bool VerificarBarrio(out int id_barrio, string barrio)
        {
            id_barrio = 0;
            bool result = true;
            try
            {
                DataTable dtBarrio = EBarrio.BuscarBarrios("NOMBRE EXACTO", barrio, out string rpta);
                if (dtBarrio != null)
                {
                    result = true;
                    EBarrio Ebarrio = new EBarrio(dtBarrio, 0);
                    id_barrio = Ebarrio.Id_barrio;
                }
                else
                    throw new Exception(rpta);
            }
            catch (Exception ex)
            {
                result = false;
                if (ex.Message.Equals("OK"))
                {
                    this.AddError("No existe el barrio " + barrio + " en la base de datos");
                }
                else
                {
                    this.AddError("Hubo un error al buscar el barrio, detalles: " + ex.Message);
                }
            }
            return result;
        }

        private bool VerificarCliente(out int id_cliente, string nombre,
            string identificacion, string celular, string correo)
        {
            bool result = true;
            id_cliente = 0;
            try
            {
                DataTable dtCliente = ECliente.BuscarClientes("NOMBRE EXACTO", nombre, out string rpta);
                if (dtCliente != null)
                {
                    result = true;
                    ECliente eCliente = new ECliente(dtCliente, 0);
                    id_cliente = eCliente.Id_cliente;
                }
                else
                {
                    if (!rpta.Equals("OK"))
                        throw new Exception(rpta);

                    ECliente eCliente = new ECliente
                    {
                        Nombres = nombre,
                        Apellidos = "",
                        Identificacion = identificacion,
                        Celular = celular,
                        Correo = correo,
                        Estado = "ACTIVO"
                    };
                    rpta = ECliente.InsertarCliente(eCliente, out id_cliente);
                    if (rpta.Equals("OK"))
                        result = true;
                    else
                        throw new Exception(rpta);
                }
            }
            catch (Exception ex)
            {
                result = false;
                Mensajes.MensajeErrorCompleto(this.Name, "VerificarCliente",
                    "Hubo un error verificando un cliente", ex.Message);
            }
            return result;
        }

        private bool VerificarEsquema()
        {
            bool result = false;

            if (this.dtEsquema != null)
            {
                string columnText = "";
                foreach (DataColumn column in dtEsquema.Columns)
                {
                    columnText = column.ColumnName.ToUpper();
                    foreach (DataColumn columnClient in dtClientes.Columns)
                    {
                        if (columnText == columnClient.ColumnName.ToUpper())
                        {
                            result = true;
                            break;
                        }
                    }

                    if (result == false)
                    {
                        Mensajes.MensajeInformacion("No se encontró la columna " + columnText, "Entendido");
                        break;
                    }
                }
            }
            return result;
        }

        private void BtnIniciar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.VerificarEsquema())
                {
                    MensajeEspera.ShowWait("Cargando");
                    this.CrearTablaErrores();
                    foreach (DataRow row in this.dtClientes.Rows)
                    {
                        string canton = Convert.ToString(row["Canton"]);
                        string parroquia = Convert.ToString(row["Parroquia"]);
                        string barrio = Convert.ToString(row["Barrio"]);

                        bool totalResult = true;

                        if (!this.VerificarCanton(out int id_canton, canton))
                        {
                            totalResult = false;
                        }

                        if (!this.VerificarParroquia(out int id_parroquia, parroquia))
                        {
                            totalResult = false;
                        }

                        if (!this.VerificarBarrio(out int id_barrio, barrio))
                        {
                            totalResult = false;
                        }

                        if (totalResult)
                        {
                            string nombre_cliente = Convert.ToString(row["Nombre"]);
                            string identificacion = Convert.ToString(row["Cedula"]);
                            string celular = Convert.ToString(row["Celular"]);
                            string correo = Convert.ToString(row["Correo"]);
                            string direccion = Convert.ToString(row["Direccion"]);
                            string tipo_establecimiento = Convert.ToString(row["Establecimiento"]);
                            string medidor = Convert.ToString(row["Medidor"]);

                            if (this.VerificarCliente(out int id_cliente, nombre_cliente,
                                identificacion, celular, correo))
                            {
                                EDireccionCliente eDireccion = new EDireccionCliente
                                {
                                    ECliente = new ECliente() { Id_cliente = id_cliente },
                                    Direccion = direccion,
                                    EBarrio = new EBarrio() { Id_barrio = id_barrio },
                                    Tipo_establecimiento = tipo_establecimiento,
                                    Estado = "ACTIVO"
                                };

                                string rpta = "";
                                rpta = EDireccionCliente.InsertarDireccion(out int id_direccion, eDireccion);
                                if (!rpta.Equals("OK"))
                                {
                                    this.AddError("Hubo un error al insertar la dirección de un cliente: Nombre: "
                                    + nombre_cliente + " - Identificación: " + identificacion);
                                }
                                else
                                {
                                    EMedidor eMedidor = new EMedidor
                                    {
                                        DireccionCliente = new EDireccionCliente() { Id_direccion = id_direccion },
                                        Medidor = medidor,
                                        Descripcion = "",
                                        Estado_medidor = "ACTIVO"
                                    };

                                    rpta = EMedidor.InsertarMedidor(out int id_medidor, eMedidor);
                                    if (!rpta.Equals("OK"))
                                    {
                                        this.AddError("Hubo un error al insertar el medidor de un cliente: Nombre: "
                                            + nombre_cliente + " - Identificación: " + identificacion);
                                    }
                                }
                            }
                            else
                            {
                                this.AddError("Hubo un error al insertar un cliente: Nombre: "
                                    + nombre_cliente + " - Identificación: " + identificacion);
                            }
                        }
                    }
                    MensajeEspera.CloseForm();
                }
            }
            catch (Exception ex)
            {
                MensajeEspera.CloseForm();
                Mensajes.MensajeErrorCompleto(this.Name, "BtnIniciar_Click",
                    "Hubo un error al cargar los clientes", ex.Message);
            }
        }

        private void LblResultados_Click(object sender, EventArgs e)
        {
            if (this.dtErrores != null)
            {
                if (this.dtErrores.Rows.Count > 0)
                {
                    FrmErroresCarga errores = new FrmErroresCarga
                    {
                        StartPosition = FormStartPosition.CenterScreen
                    };
                    errores.FormClosing += Errores_FormClosing;
                    errores.ObtenerErrores(dtErrores);
                    errores.Show();
                }
            }
        }

        private void Errores_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.txtHoja.Focus();
        }

        private void TxtHoja_LostFocus(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (txt.Text.Equals("Hoja") | txt.Text.Equals(""))
            {
                this.gb3.Enabled = false;              
            }
            else
            {
                this.gb3.Enabled = true;
            }
        }

        private void TxtHoja_Click(object sender, EventArgs e)
        {
            this.txtHoja.SelectAll();
        }

        private void BtnMostrarEsquema_Click(object sender, EventArgs e)
        {
            DataTable dtEsquema = new DataTable();
            dtEsquema.Columns.Add("Medidor", typeof(string));
            dtEsquema.Columns.Add("Nombres", typeof(string));
            dtEsquema.Columns.Add("Cedula", typeof(string));
            dtEsquema.Columns.Add("Celular", typeof(string));
            dtEsquema.Columns.Add("Correo", typeof(string));
            dtEsquema.Columns.Add("Direccion", typeof(string));
            dtEsquema.Columns.Add("Barrio", typeof(string));
            dtEsquema.Columns.Add("Parroquia", typeof(string));
            dtEsquema.Columns.Add("Canton", typeof(string));
            dtEsquema.Columns.Add("Establecimiento", typeof(string));

            this.dgvClientes.DataSource = dtEsquema;
            this.lblResultados.Text = "El archivo a cargar debe tener las mismas columnas en el mismo orden";
            this.gb2.Enabled = true;
            this.dtEsquema = dtEsquema;
        }

        private void BtnImportar_Click(object sender, EventArgs e)
        {
            
            try
            {
                //Creo un objeto de tipo OpenFileDialog y lo instancio
                OpenFileDialog archivo = new OpenFileDialog();
                //Esta linea es para que solo se puedan visualizar los archivos con esta extension
                archivo.Filter = "Documentos válidos|*.doc;*.xls;*.ppt;*.pdf;*.xlsx";
                //Lo abro como un Dialog
                DialogResult result = archivo.ShowDialog();

                if (result == DialogResult.OK)
                {
                    //Asignamos el nombre del archivo a la caja de texto
                    this.txtArchivo.Text = archivo.SafeFileName;
                    //Asignamos a la propiedad tag del textbox la ruta completa del archivo
                    this.txtArchivo.Tag = archivo.FileName;

                    string hoja = this.txtHoja.Text;

                    if (hoja.Equals("Hoja") || hoja.Equals(""))
                    {
                        Mensajes.MensajeErrorForm("Debe ingresar un nombre de hoja válida, seleccione el archivo de nuevo");
                        this.txtHoja.SelectAll();
                    }
                    else
                    {
                        MensajeEspera.ShowWait("Cargando");
                        DataTable dt = new DataTable();
                        string fileName = archivo.FileName;
                        string query = "SELECT * FROM [" + hoja + "$]";
                        using (OleDbConnection cn = new OleDbConnection { ConnectionString = ConnectionString(fileName, "Yes") })
                        {
                            using (OleDbCommand cmd = new OleDbCommand { CommandText = query, Connection = cn })
                            {
                                cn.Open();

                                OleDbDataReader dr = cmd.ExecuteReader();
                                dt.Load(dr);
                            }
                        }

                        if (dt != null)
                        {
                            if (dt.Rows.Count > 0)
                            {
                                this.lblResultados.Text = "Se cargaron " + dt.Rows.Count + " registros";
                                this.dgvClientes.Enabled = true;
                            }
                            else
                            {
                                this.dgvClientes.Enabled = false;
                                this.lblResultados.Text = "No se cargó ningún registro";
                            }
                        }
                        dt.AcceptChanges();
                        this.dgvClientes.DataSource = dt;
                        this.gb4.Enabled = true;
                        this.dtClientes = dt;
                        MensajeEspera.CloseForm();
                    }
                }
            }
            catch (Exception ex)
            {
                MensajeEspera.CloseForm();
                Mensajes.MensajeErrorCompleto(this.Name, "BtnImportar_Click",
                    "Hubo un error al importar el archivo", ex.Message);
            }
        }

        public string ConnectionString(string FileName, string Header)
        {
            OleDbConnectionStringBuilder Builder = new OleDbConnectionStringBuilder();
            if (Path.GetExtension(FileName).ToUpper() == ".XLS")
            {
                Builder.Provider = "Microsoft.Jet.OLEDB.4.0";
                Builder.Add("Extended Properties", string.Format("Excel 8.0;IMEX=1;HDR={0};", Header));
            }
            else
            {
                Builder.Provider = "Microsoft.ACE.OLEDB.12.0";
                Builder.Add("Extended Properties", string.Format("Excel 12.0;IMEX=1;HDR={0};", Header));
            }

            Builder.DataSource = FileName;

            return Builder.ConnectionString;
        }

        private DataTable dtEsquema;
        private DataTable dtClientes;
        private DataTable dtErrores;
    }
}
