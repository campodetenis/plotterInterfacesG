using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Input;

namespace pruebaProyecto2
{
    class numericTextBox : TextBox
    {
        public int IntValue
        {
            get
            {
                return Int32.Parse(this.Text);
            }
        }

        public double doubleValue
        {
            get
            {
                return Double.Parse(this.Text);
            }
        }

        public numericTextBox()
        {
            this.PreviewTextInput += new TextCompositionEventHandler(NumericTextBox_PreviewTextInput);
        }

        void NumericTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            NumberFormatInfo numberFormatInfo =
           System.Globalization.CultureInfo.CurrentCulture.NumberFormat;
            string decimalSeparator =
           numberFormatInfo.NumberDecimalSeparator;
            string negativeSign = numberFormatInfo.NegativeSign;
            string caracter = e.Text;
            if (Char.IsDigit(e.Text[0]))
            {
                // No hacemos nada porque aceptamos los dígitos
            }
            else if (caracter.Equals(decimalSeparator) ||
           caracter.Equals(negativeSign))
            { // No hacemos nada porque aceptamos el punto y el signo
            }
            else if (caracter == "\b")
            {
                // No hacemos nada porque aceptamos el Backspace
            }
            else
            {
                // Nos saltamos el carácter deteniendo el enrutamiento
                e.Handled = true;
            }
        }
    }
}
