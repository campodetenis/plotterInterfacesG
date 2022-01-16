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
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        public ObservableCollection<Point> puntos = new ObservableCollection<Point>();
        public Window1(ObservableCollection<Point> coleccion)
        {
            InitializeComponent();
            puntos = coleccion;
            if(puntos.Count != 0)
            {
                rellenarLista();
            }
            //MiLista.ItemsSource = puntos; enlace de datos que de momento complica mas las cosas
         
        }

        private void MiLista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void añadirPunto_Click(object sender, RoutedEventArgs e)
        {

            añadirPuntos();
        }

        private void añadirPuntos()
        {
            String msg = "los valores no pueden ser nulos";
            int valueX, valueY;
            if (!string.IsNullOrEmpty(Cajax.Text) && !string.IsNullOrEmpty(CajaY.Text))
            {
                valueX = int.Parse(Cajax.Text);
                valueY = int.Parse(CajaY.Text);
                Point mipunto = new Point(valueX, valueY);
                puntos.Add(mipunto);
                MiLista.Items.Add(mipunto);
            }
            else
            {
                MessageBox.Show(msg);
            }
        }

        private void QuitarPunto_Click(object sender, RoutedEventArgs e)
        {
            /*MiLista.Items.Remove(MiLista.SelectedItem);
            puntos.Clear();
            foreach(Point Value in MiLista.Items)
            {
                puntos.Add(Value);
            }*/
            if (MiLista.SelectedItem != null)
            {
                puntos.Remove((Point)MiLista.SelectedValue);
                MiLista.Items.Remove(MiLista.SelectedItem);
            }
        }

        private void rellenarLista()
        {
            MiLista.Items.Clear();
            foreach(Point value in puntos)
            {
                MiLista.Items.Add(value);
            }
        }

        public ObservableCollection<Point> returnCollection()
        {
            return puntos;
        }

        private void MiLista_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                añadirPuntos();
            }
        }

        private void ModificarPunto_Click(object sender, RoutedEventArgs e)
        {
            Point punto = new Point();
            punto.X = int.Parse(Cajax.Text);
            punto.Y = int.Parse(CajaY.Text);
            MiLista.SelectedValue = punto;
        }
    }
}
