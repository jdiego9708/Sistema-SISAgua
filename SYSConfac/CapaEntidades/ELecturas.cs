using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaEntidades
{
    public class ELecturas
    {
        public ELecturas()
        {

        }

        public ELecturas(DataRow row)
        {
            try
            {
                this.Id_lectura = Convert.ToInt32(row["Id_lectura"]);

                this.ECliente = new ECliente
                {
                    Id_cliente = Convert.ToInt32(row["Id_cliente"]),
                    Nombres = Convert.ToString(row["Nombres"]),
                    Apellidos = Convert.ToString(row["Apellidos"]),
                    Identificacion = Convert.ToString(row["Identificacion"]),
                    Celular = Convert.ToString(row["Celular"]),
                    Correo = Convert.ToString(row["Correo_electronico"]),
                    Estado = Convert.ToString(row["Estado_cliente"])
                };

                this.ETarifas = new ETarifas(row);

                this.EEmpleado = new EEmpleado
                {
                    Id_empleado = Convert.ToInt32(row["Id_empleado"]),
                    Nombre_completo = Convert.ToString(row["Nombre_completo"]),
                    Tipo_empleado = Convert.ToString(row["Tipo_empleado"]),
                    Celular = Convert.ToString(row["Celular"]),
                    Correo_electronico = Convert.ToString(row["Correo_electronico"]),
                    Permisos = Convert.ToString(row["Permisos"]),
                    Clave = Convert.ToString(row["Clave"])
                };

                this.EMedidor = new EMedidor
                {
                    Id_medidor = Convert.ToInt32(row["Id_medidor"]),
                    DireccionCliente = new EDireccionCliente(Convert.ToInt32(row["Id_direccion"])),
                    Medidor = Convert.ToString(row["Medidor"]),
                    Descripcion = Convert.ToString(row["Descripcion"]),
                    Estado_medidor = Convert.ToString(row["Estado_medidor"])
                };

                this.ECuenta = new ECuentas
                {
                    Id_cuenta = Convert.ToInt32(row["Id_cuenta"]),
                    ECliente = new ECliente
                    {
                        Id_cliente = Convert.ToInt32(row["Id_cliente"])
                    },
                    ETarifa = new ETarifas(Convert.ToInt32(row["Id_tarifa"])),
                    Fecha_cuenta = Convert.ToDateTime(row["Fecha_cuenta"]),
                    Estado_cuenta = Convert.ToString(row["Estado_cuenta"]),
                    Iva = Convert.ToDecimal(row["IVA"]),
                    Descuento = Convert.ToDecimal(row["Descuento"]),
                    Motivo_descuento = Convert.ToString(row["Motivo_descuento"]),
                    Total_pagar = Convert.ToDecimal(row["Total_pagar"]),
                    Fecha_pago = Convert.ToDateTime(row["Fecha_pago"])
                };

                this.Fecha_lectura = Convert.ToString(row["Fecha_lectura"]);
                this.Hora_lectura = Convert.ToString(row["Hora_lectura"]);
                this.Valor_lectura = Convert.ToInt32(row["Valor_lectura"]);

                this.EMedida = new EMedida
                {
                    Id_medida = Convert.ToInt32(row["Id_medida"]),
                    Descripcion_medida = Convert.ToString(row["Descripcion_medida"]),
                    Alias_medida = Convert.ToString(row["Alias_medida"])
                };
                
                this.Mes_lectura = Convert.ToString(row["Mes_lectura"]);

                this.Total_consumo = Convert.ToInt32(row["Total_consumo"]);
                this.Consumo_excedido = Convert.ToInt32(row["Consumo_excedido"]);
                this.Total_lectura = Convert.ToDecimal(row["Total_lectura"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public ELecturas(DataTable dt, int fila)
        {
            try
            {
                this.Id_lectura = Convert.ToInt32(dt.Rows[fila]["Id_lectura"]);

                this.ECliente = new ECliente
                {
                    Id_cliente = Convert.ToInt32(dt.Rows[fila]["Id_cliente"]),
                    Nombres = Convert.ToString(dt.Rows[fila]["Nombres"]),
                    Apellidos = Convert.ToString(dt.Rows[fila]["Apellidos"]),
                    Identificacion = Convert.ToString(dt.Rows[fila]["Identificacion"]),
                    Celular = Convert.ToString(dt.Rows[fila]["Celular"]),
                    Correo = Convert.ToString(dt.Rows[fila]["Correo_electronico"]),
                    Estado = Convert.ToString(dt.Rows[fila]["Estado_cliente"])
                };

                this.ETarifas = new ETarifas(dt.Rows[fila]);

                this.EEmpleado = new EEmpleado
                {
                    Id_empleado = Convert.ToInt32(dt.Rows[fila]["Id_empleado"]),
                    Nombre_completo = Convert.ToString(dt.Rows[fila]["Nombre_completo"]),
                    Tipo_empleado = Convert.ToString(dt.Rows[fila]["Tipo_empleado"]),
                    Celular = Convert.ToString(dt.Rows[fila]["Celular"]),
                    Correo_electronico = Convert.ToString(dt.Rows[fila]["Correo_electronico"]),
                    Permisos = Convert.ToString(dt.Rows[fila]["Permisos"]),
                    Clave = Convert.ToString(dt.Rows[fila]["Clave"])
                };

                this.EMedidor = new EMedidor
                {
                    Id_medidor = Convert.ToInt32(dt.Rows[fila]["Id_medidor"]),
                    DireccionCliente = new EDireccionCliente(Convert.ToInt32(dt.Rows[fila]["Id_direccion"])),
                    Medidor = Convert.ToString(dt.Rows[fila]["Medidor"]),
                    Descripcion = Convert.ToString(dt.Rows[fila]["Descripcion"]),
                    Estado_medidor = Convert.ToString(dt.Rows[fila]["Estado_medidor"])
                };

                this.ECuenta = new ECuentas
                {
                    Id_cuenta = Convert.ToInt32(dt.Rows[fila]["Id_cuenta"]),
                    ECliente = new ECliente
                    {
                        Id_cliente = Convert.ToInt32(dt.Rows[fila]["Id_cliente"])
                    },
                    ETarifa = new ETarifas(Convert.ToInt32(dt.Rows[fila]["Id_tarifa"])),
                    Fecha_cuenta = Convert.ToDateTime(dt.Rows[fila]["Fecha_cuenta"]),
                    Estado_cuenta = Convert.ToString(dt.Rows[fila]["Estado_cuenta"]),
                    Iva = Convert.ToDecimal(dt.Rows[fila]["IVA"]),
                    Descuento = Convert.ToDecimal(dt.Rows[fila]["Descuento"]),
                    Motivo_descuento = Convert.ToString(dt.Rows[fila]["Motivo_descuento"]),
                    Total_pagar = Convert.ToDecimal(dt.Rows[fila]["Total_pagar"]),
                    Fecha_pago = Convert.ToDateTime(dt.Rows[fila]["Fecha_pago"])
                };

                this.Fecha_lectura = Convert.ToString(dt.Rows[fila]["Fecha_lectura"]);
                this.Hora_lectura = Convert.ToString(dt.Rows[fila]["Hora_lectura"]);
                this.Valor_lectura = Convert.ToInt32(dt.Rows[fila]["Valor_lectura"]);
                this.EMedida = new EMedida
                {
                    Id_medida = Convert.ToInt32(dt.Rows[fila]["Id_medida"]),
                    Descripcion_medida = Convert.ToString(dt.Rows[fila]["Descripcion_medida"]),
                    Alias_medida = Convert.ToString(dt.Rows[fila]["Alias_medida"])
                };
                this.Mes_lectura = Convert.ToString(dt.Rows[fila]["Mes_lectura"]);
                this.Total_consumo = Convert.ToInt32(dt.Rows[fila]["Total_consumo"]);
                this.Consumo_excedido = Convert.ToInt32(dt.Rows[fila]["Consumo_excedido"]);
                this.Total_lectura = Convert.ToDecimal(dt.Rows[fila]["Total_lectura"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public ELecturas(int id_lectura)
        {
            try
            {
                DataTable dt =
                    DLecturas.BuscarLecturas("ID LECTURA", id_lectura.ToString(), out string rpta);
                if (dt != null)
                {
                    this.Id_lectura = Convert.ToInt32(dt.Rows[0]["Id_lectura"]);

                    this.ECliente = new ECliente
                    {
                        Id_cliente = Convert.ToInt32(dt.Rows[0]["Id_cliente"]),
                        Nombres = Convert.ToString(dt.Rows[0]["Nombres"]),
                        Apellidos = Convert.ToString(dt.Rows[0]["Apellidos"]),
                        Identificacion = Convert.ToString(dt.Rows[0]["Identificacion"]),
                        Celular = Convert.ToString(dt.Rows[0]["Celular"]),
                        Correo = Convert.ToString(dt.Rows[0]["Correo_electronico"]),
                        Estado = Convert.ToString(dt.Rows[0]["Estado_cliente"])
                    };

                    this.ETarifas = new ETarifas(Convert.ToInt32(dt.Rows[0]["Id_tarifa"]));

                    this.EEmpleado = new EEmpleado
                    {
                        Id_empleado = Convert.ToInt32(dt.Rows[0]["Id_empleado"]),
                        Nombre_completo = Convert.ToString(dt.Rows[0]["Nombre_completo"]),
                        Tipo_empleado = Convert.ToString(dt.Rows[0]["Tipo_empleado"]),
                        Celular = Convert.ToString(dt.Rows[0]["Celular"]),
                        Correo_electronico = Convert.ToString(dt.Rows[0]["Correo_electronico"]),
                        Permisos = Convert.ToString(dt.Rows[0]["Permisos"]),
                        Clave = Convert.ToString(dt.Rows[0]["Clave"])
                    };

                    this.EMedidor = new EMedidor
                    {
                        Id_medidor = Convert.ToInt32(dt.Rows[0]["Id_medidor"]),
                        DireccionCliente = new EDireccionCliente(Convert.ToInt32(dt.Rows[0]["Id_direccion"])),
                        Medidor = Convert.ToString(dt.Rows[0]["Medidor"]),
                        Descripcion = Convert.ToString(dt.Rows[0]["Descripcion"]),
                        Estado_medidor = Convert.ToString(dt.Rows[0]["Estado_medidor"])
                    };

                    this.ECuenta = new ECuentas
                    {
                        Id_cuenta = Convert.ToInt32(dt.Rows[0]["Id_cuenta"]),
                        ECliente = new ECliente
                        {
                            Id_cliente = Convert.ToInt32(dt.Rows[0]["Id_cliente"])
                        },
                        ETarifa = new ETarifas(Convert.ToInt32(dt.Rows[0]["Id_tarifa"])),
                        Fecha_cuenta = Convert.ToDateTime(dt.Rows[0]["Fecha_cuenta"]),
                        Estado_cuenta = Convert.ToString(dt.Rows[0]["Estado_cuenta"]),
                        Iva = Convert.ToDecimal(dt.Rows[0]["IVA"]),
                        Descuento = Convert.ToDecimal(dt.Rows[0]["Descuento"]),
                        Motivo_descuento = Convert.ToString(dt.Rows[0]["Motivo_descuento"]),
                        Total_pagar = Convert.ToDecimal(dt.Rows[0]["Total_pagar"]),
                        Fecha_pago = Convert.ToDateTime(dt.Rows[0]["Fecha_pago"])
                    };

                    this.Fecha_lectura = Convert.ToString(dt.Rows[0]["Fecha_lectura"]);
                    this.Hora_lectura = Convert.ToString(dt.Rows[0]["Hora_lectura"]);
                    this.Valor_lectura = Convert.ToInt32(dt.Rows[0]["Valor_lectura"]);
                    this.EMedida = new EMedida
                    {
                        Id_medida = Convert.ToInt32(dt.Rows[0]["Id_medida"]),
                        Descripcion_medida = Convert.ToString(dt.Rows[0]["Descripcion_medida"]),
                        Alias_medida = Convert.ToString(dt.Rows[0]["Alias_medida"])
                    };
                    this.Mes_lectura = Convert.ToString(dt.Rows[0]["Mes_lectura"]);
                    this.Total_consumo = Convert.ToInt32(dt.Rows[0]["Total_consumo"]);
                    this.Consumo_excedido = Convert.ToInt32(dt.Rows[0]["Consumo_excedido"]);
                    this.Total_lectura = Convert.ToDecimal(dt.Rows[0]["Total_lectura"]);
                }
                else
                {
                    if (!rpta.Equals("OK"))
                        throw new Exception(rpta);
                }
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public static string InsertarLectura(out int id_lectura, ELecturas eLecturas)
        {
            List<string> vs = new List<string>
            {
                eLecturas.ECliente.Id_cliente.ToString(),
                eLecturas.ETarifas.Id_tarifa.ToString(),
                eLecturas.EMedidor.Id_medidor.ToString(),
                eLecturas.EEmpleado.Id_empleado.ToString(),
                eLecturas.ECuenta.Id_cuenta.ToString(),
                eLecturas.Fecha_lectura,eLecturas.Hora_lectura,
                eLecturas.Valor_lectura.ToString(),
                eLecturas.Total_consumo.ToString(),
                eLecturas.Consumo_excedido.ToString(),
                eLecturas.EMedida.Id_medida.ToString(),
                eLecturas.Mes_lectura,
                eLecturas.Total_lectura.ToString("N2")
            };
            return DLecturas.InsertarLectura(out id_lectura, vs);
        }

        public static string EditarLectura(int id_lectura, ELecturas eLecturas)
        {
            List<string> vs = new List<string>
            {
                eLecturas.ECliente.Id_cliente.ToString(),
                eLecturas.ETarifas.Id_tarifa.ToString(),
                eLecturas.EMedidor.Id_medidor.ToString(),
                eLecturas.EEmpleado.Id_empleado.ToString(),
                eLecturas.ECuenta.Id_cuenta.ToString(),
                eLecturas.Fecha_lectura,eLecturas.Hora_lectura,
                eLecturas.Valor_lectura.ToString(),
                eLecturas.Total_consumo.ToString(),
                eLecturas.Consumo_excedido.ToString(),
                eLecturas.EMedida.Id_medida.ToString(),
                eLecturas.Mes_lectura,
                eLecturas.Total_lectura.ToString("N2")
            };
            return DLecturas.ModificarLectura(id_lectura, vs);
        }

        public static DataTable BuscarLecturas(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            return DLecturas.BuscarLecturas(tipo_busqueda, texto_busqueda, out rpta);
        }

        public static DataTable BuscarLecturas(string tipo_busqueda, string texto_busqueda1, string texto_busqueda2, out string rpta)
        {
            return DLecturas.BuscarLecturas(tipo_busqueda, texto_busqueda1, texto_busqueda2, out rpta);
        }

        private int _id_lectura;
        private ECliente _eCliente;
        private ETarifas _eTarifas;
        private EEmpleado _eEmpleado;
        private EMedidor eMedidor;
        private ECuentas eCuenta;
        private string _fecha_lectura;
        private string _hora_lectura;
        private int _valor_lectura;
        private EMedida _eMedida;
        private string _mes_lectura;
        private int _total_consumo;
        private int _consumo_excedido;
        private decimal _total_lectura;

        public event EventHandler OnError;

        public int Id_lectura { get => _id_lectura; set => _id_lectura = value; }
        public ECliente ECliente { get => _eCliente; set => _eCliente = value; }
        public ETarifas ETarifas { get => _eTarifas; set => _eTarifas = value; }
        public string Fecha_lectura { get => _fecha_lectura; set => _fecha_lectura = value; }
        public string Hora_lectura { get => _hora_lectura; set => _hora_lectura = value; }
        public int Valor_lectura { get => _valor_lectura; set => _valor_lectura = value; }
        public EEmpleado EEmpleado { get => _eEmpleado; set => _eEmpleado = value; }
        public EMedidor EMedidor { get => eMedidor; set => eMedidor = value; }
        public string Mes_lectura { get => _mes_lectura; set => _mes_lectura = value; }
        public ECuentas ECuenta { get => eCuenta; set => eCuenta = value; }
        public EMedida EMedida { get => _eMedida; set => _eMedida = value; }
        public int Total_consumo { get => _total_consumo; set => _total_consumo = value; }
        public int Consumo_excedido { get => _consumo_excedido; set => _consumo_excedido = value; }
        public decimal Total_lectura { get => _total_lectura; set => _total_lectura = value; }
    }
}
