using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Threading;

namespace CapaPresentacionAdministracion.Controles
{
    public partial class CustomSuperTextBox : UserControl
    {
        public CustomSuperTextBox()
        {
            InitializeComponent();
            this.txtTexto.TextChanged += TxtTexto_TextChanged;
            this.txtTexto.KeyPress += TxtTexto_KeyPress;
            this.txtTexto.LostFocus += TxtTexto_LostFocus;
            this.Click += CustomSuperTextBox_Click;
            this.groupBox1.Click += CustomSuperTextBox_Click;
        }

        private void CustomSuperTextBox_Click(object sender, EventArgs e)
        {
            this.txtTexto.Focus();
        }

        private void TxtTexto_LostFocus(object sender, EventArgs e)
        {
            this.Comprobaciones();
        }

        public event EventHandler OnTextoKeyPress;

        private void TxtTexto_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnTextoKeyPress?.Invoke(sender, e);
            if (this.IsNumber || this.IsDecimal)
            {
                CultureInfo cc = Thread.CurrentThread.CurrentCulture;

                if (this.IsNumber)
                {
                    if (char.IsDigit(e.KeyChar) ||
                        (int)e.KeyChar == (int)Keys.Back)
                        e.Handled = false;
                    else
                        e.Handled = true;
                }

                if (this.IsDecimal)
                {
                    if (e.KeyChar.ToString() == cc.NumberFormat.NumberDecimalSeparator ||
                       char.IsDigit(e.KeyChar) ||
                       (int)e.KeyChar == (int)Keys.Back)
                        e.Handled = false;
                    else
                        e.Handled = true;
                }
            }
        }

        public event EventHandler OnTextoChanged;

        private void TxtTexto_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            string text = txt.Text;
            if (txt.Text.Equals("") || txt.Text.Equals(this.Place_holder))
            {
                txt.Font =
                        new Font(this.FontWordDefault, this.SizeFontDefault, FontStyle.Italic, GraphicsUnit.Point, 0);
                txt.ForeColor = this.ForeColorDefault;
            }
            else
            {
                txt.Font =
                        new Font(this.FontWordDefault, this.SizeFontDefault, this.FontStyleDefault, GraphicsUnit.Point, 0);
                txt.ForeColor = this.ForeColorDefault;
                OnTextoChanged?.Invoke(sender, e);
            }

            this.Texto = text;
        }

        private bool Comprobaciones()
        {
            if (this.IsRequired)
            {
                if (string.IsNullOrEmpty(this.Texto))
                {
                    this.Validation = false;
                    return this.Validation;
                }
            }

            if (this.IsEmail)
            {
                if (!this.ComprobarEmail(this.Texto))
                {
                    this.Validation = false;
                    return this.Validation;
                }
                this.Validation = true;
            }

            if (this.IsNumber)
            {
                if (!int.TryParse(this.Texto, out _))
                {
                    this.Validation = false;
                    return this.Validation;
                }
            }

            if (this.IsDecimal)
            {
                if (!decimal.TryParse(this.Texto, out _))
                {
                    this.Validation = false;
                    return this.Validation;
                }
            }

            return this.Validation;
        }

        private bool ComprobarEmail(string texto)
        {
            string expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(texto, expresion))
            {
                if (Regex.Replace(texto, expresion, string.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void ChangedState(bool state)
        {
            if (state)
            {
                if (this.IsRequired)
                    this.panel1.BackColor = Color.FromArgb(205, 254, 198);
                else
                    this.panel1.BackColor = Color.White;
            }
            else
            {
                if (this.IsRequired)
                    this.panel1.BackColor = Color.FromArgb(254, 198, 198);
                else
                    this.panel1.BackColor = Color.White;
            }
        }

        private string _text_description = "Descripción";
        private string _place_holder;
        private string _fontWordDefault = "Segoe UI";
        private float _sizeFontDefault = 10.5F;
        private FontStyle _fontStyleDefault = FontStyle.Regular;
        private Color _foreColorDefault = Color.FromArgb(64, 64, 64);
        private string _texto = string.Empty;
        private bool _multiline = false;
        private bool _isEmail = false;
        private bool _validation = true;
        private bool _isRequired = false;
        private bool _isNumber = false;
        private bool _isDecimal = false;
        private string _formatNumber = null;

        public string Text_description
        {
            get => _text_description;
            set
            {
                _text_description = value;
                this.groupBox1.Text = value;
            }
        }
        public string Place_holder
        {
            get => _place_holder;
            set
            {
                _place_holder = value;
                this.txtTexto.Font =
                        new Font(this.FontWordDefault, this.SizeFontDefault, FontStyle.Italic, GraphicsUnit.Point, 0);
                this.txtTexto.ForeColor = Color.FromArgb(64, 64, 64);
                this.txtTexto.Text = value;
            }
        }
        public float SizeFontDefault
        {
            get => _sizeFontDefault;
            set
            {
                _sizeFontDefault = value;
                this.txtTexto.Font =
                    new Font(this.FontWordDefault, value, this.FontStyleDefault, GraphicsUnit.Point, 0);
            }
        }
        public FontStyle FontStyleDefault
        {
            get => _fontStyleDefault;
            set
            {
                _fontStyleDefault = value;
                this.txtTexto.Font =
                   new Font(this.FontWordDefault, this.SizeFontDefault, value, GraphicsUnit.Point, 0);
            }
        }
        public string FontWordDefault
        {
            get => _fontWordDefault;
            set
            {
                _fontWordDefault = value;
                this.txtTexto.Font =
                   new Font(value, this.SizeFontDefault, this.FontStyleDefault, GraphicsUnit.Point, 0);
            }
        }
        public string Texto
        {
            get => _texto;
            set
            {
                _texto = value;
                this.txtTexto.Text = value;
            }
        }
        public bool Multiline
        {
            get => _multiline;
            set
            {
                _multiline = value;
                if (!value)
                {
                    this.groupBox1.AutoSize = true;
                    this.AutoSize = true;
                }
                this.txtTexto.Multiline = value;
            }
        }
        public bool IsEmail
        {
            get => _isEmail;
            set
            {
                _isEmail = value;
            }
        }
        public bool Validation
        {
            get => _validation;
            set
            {
                _validation = value;
                this.ChangedState(value);
            }
        }
        public Color ForeColorDefault
        {
            get => _foreColorDefault;
            set
            {
                _foreColorDefault = value;
                this.txtTexto.ForeColor = value;
            }
        }
        public bool IsRequired { get => _isRequired; set => _isRequired = value; }
        public bool IsNumber { get => _isNumber; set => _isNumber = value; }
        public bool IsDecimal { get => _isDecimal; set => _isDecimal = value; }
        public string FormatNumber { get => _formatNumber; set => _formatNumber = value; }
    }
}
