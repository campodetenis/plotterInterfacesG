using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace pruebaProyecto2
{
    /// <summary>
    /// Lógica de interacción para polinomioVentana.xaml
    /// </summary>
    public partial class polinomioVentana : Window
    {
        public ObservableCollection<Point> puntos = new ObservableCollection<Point>();
        public polinomioVentana(ObservableCollection<Point> tabla)
        {
            InitializeComponent();
            puntos = tabla;
        }

        private void rellenarTabla()
        {
            //Point punto;
            int valorCuadrado, valorX, valorIndependiente, incremento;
            String msg;
            valorCuadrado = valorX = valorIndependiente = 0;
            if (!string.IsNullOrEmpty(cajaBase.Text) && !string.IsNullOrEmpty(cajaTope.Text))
            {
                
                //se verifica que la caja del cuadrado no esta vacia, y si no lo esta se toma su contenido
                if (!string.IsNullOrEmpty(cajaCuadrado.Text)){
                    valorCuadrado = int.Parse(cajaCuadrado.Text);
                }
                else
                {
                    valorCuadrado = 0;
                }

                //se verifica que la caja de la X no esta vacia, y si no lo esta se toma su contenido
                if (!string.IsNullOrEmpty(cajaNormal.Text))
                {
                    valorX = int.Parse(cajaNormal.Text);
                }
                else
                {
                    valorX = 0;
                }

                //se verifica que la caja del valor independiente no esta vacia, y si no lo esta se toma su contenido
                if (!string.IsNullOrEmpty(cajaCuadrado.Text))
                {
                    valorIndependiente = int.Parse(cajaIndependiente.Text);
                }
                else
                {
                    valorIndependiente = 0;
                }

                //ahora se verifica si hay incremento modificado
                if (!string.IsNullOrEmpty(cajaIncremento.Text))
                {
                    incremento = int.Parse(cajaIncremento.Text);
                }
                else
                {
                    incremento = 1;
                }

                //ahora se efectuan los calculos
                for (int i = int.Parse(cajaBase.Text); i <= int.Parse(cajaTope.Text); i=i+incremento)
                {
                    Point punto = new Point();
                    punto.X = i;
                    punto.Y = ((valorCuadrado) * (i * i)) + (valorX * i) + valorIndependiente;
                    puntos.Add(punto);
                }

            }
            else{
                msg = "la base y el tope del rango no pueden estar vacios";
                MessageBox.Show(msg);
            }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            rellenarTabla();
        }
    }
}
