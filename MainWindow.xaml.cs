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
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Window1 datos;
        polinomioVentana cuadroPolinomio;
        //prueba ventanaDePrueba;
        Polyline polilinea;
        Binding miBinding = new Binding();
        Binding grosorPolilinea = new Binding();
        Binding grosorBarras = new Binding();
        //ObservableCollection<ObservableCollection<Point>> colecciones = new ObservableCollection<ObservableCollection<Point>>();
        viewmodel modelo = new viewmodel();
        //elementos del cuadro de dialogo
        String titulo = "aviso";

        //binding del lienzo
        Binding bindingLienzo = new Binding();
        MessageBoxButton boton = MessageBoxButton.OK;

        //bindings de la cuadrícula
        Binding centroCanvasBinding = new Binding();

        //variables para el purgado
        bool mouseDown = false;
        Point posicionRaton;

        //binding de la linea a la coleccion de datos
        Binding lineaBinding = new Binding();

        //rectangulo para la purga
        Rectangle rectangulo;

        //booleano para controlar la seleccion
        private bool seleccionActiva;
        public MainWindow()
        {
            InitializeComponent();
            polilinea = new Polyline();
            polilinea.StrokeThickness = .5;
            polilinea.Stroke = Brushes.Red;
            miBinding.ElementName = "desliz";
            miBinding.Path = new PropertyPath("Value");
            //lienzo.SetBinding(ScaleTransform.ScaleXProperty, miBinding);
            listaColecciones.ItemsSource = modelo.devolverColecciones();

            grosorPolilinea.Source = sliderGrosor;
            grosorPolilinea.Path = new PropertyPath("Value");
            polilinea.SetBinding(Polyline.StrokeThicknessProperty, grosorPolilinea);

            //binding del lienzo

            bindingLienzo.ElementName = "sliderLIenzo";
            bindingLienzo.Path = new PropertyPath("Value");
            lienzo.SetBinding(Viewbox.WidthProperty, bindingLienzo);
            lienzo.SetBinding(Viewbox.HeightProperty, bindingLienzo);

            /*//bindings de la cuadricula
            grosorCuadriculaBinding.ElementName = "sliderCuadricula";
            grosorCuadriculaBinding.Path = new PropertyPath("Value");
            //no funciona porque no puedo convertir de ese tipo tan facilamente
            lienzo.SetBinding(DrawingBrush.ViewportProperty, grosorCuadriculaBinding);*/

            //borar si no funciona
            //centroCanvasBinding.Source = sliderPosicionCanvas;
            //centroCanvasBinding.Path = new Proper


        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            //datos = new Window1();
            //datos.Show();
            //datos.Activate();
            //datos.Show();
        }

        private void dibujarPuntos_Click(object sender, RoutedEventArgs e)
        {
            polilinea.Points.Clear();
            ActualizarPolilinea();
            //representarPolilinea();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            //modo oscuro
            //Application.Current.Resources.MergedDictionaries.
            
            cambiarColorOscuro();

        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            //modo claro
            cambiarColorClaro();
        }

        private void borrarLienzo_Click(object sender, RoutedEventArgs e)
        {
            polilinea.Points.Clear();
            lienzo.Children.Clear();
        }

        /*private void ActualizarPolilinea()
         {
             //if(!datos.IsInitialized){
             ObservableCollection<Point> MisPuntos = new ObservableCollection<Point>();
             MisPuntos = datos.returnCollection();
             foreach (Point value in MisPuntos)
             {
                 Point elemento = new Point();
                 elemento.X = value.X;
                 elemento.Y = value.Y;
                 polilinea.Points.Add(elemento);
             }
             if (!lienzo.Children.Contains(polilinea))
                 lienzo.Children.Add(polilinea);
             //}
         }*/

        private void ActualizarPolilinea()
        {
            String msg = "para representar una coleccion has de seleccionarla en la lista de colecciones";
            lienzo.Children.Clear();
            if (listaColecciones.SelectedItem != null)
            {
                ObservableCollection<Point> MisPuntos = new ObservableCollection<Point>();
                MisPuntos = (ObservableCollection<Point>)listaColecciones.SelectedValue;
                foreach (Point value in MisPuntos)
                {
                    Point elemento = new Point();
                    elemento.X = value.X;
                    elemento.Y = value.Y;
                    polilinea.Points.Add(elemento);
                }
                if (!lienzo.Children.Contains(polilinea))
                    lienzo.Children.Add(polilinea);
            }
            else
            {
                MessageBox.Show(msg, titulo, boton);
            }
        }

        private void graficaDeBarras()
        {

            grosorBarras.Source = sliderGrosor;
            grosorBarras.Path = new PropertyPath("Value");
            String msg = "para dibujar una grafica has de seleccionar una coleecion";
            if (listaColecciones.SelectedItem != null)
            {

                ObservableCollection<Point> puntos = new ObservableCollection<Point>();
                Line linea = new Line();
                puntos = (ObservableCollection<Point>)listaColecciones.SelectedValue;
                lienzo.Children.Clear();
                modelo.limpiarBarras();

                foreach (Point value in puntos)
                {
                    linea = new Line();
                    linea.StrokeThickness = 1;
                    linea.Stroke = Brushes.Red;
                    linea.SetBinding(Line.StrokeThicknessProperty, grosorPolilinea);
                    linea.X1 = value.X;
                    linea.Y1 = 0;
                    linea.X2 = value.X;
                    linea.Y2 = value.Y;
                    modelo.añadirLinea(linea);
                }


                for (int i = 0; i < modelo.getBarras().Count; i++)
                {
                    lienzo.Children.Add(modelo.getBarras().ElementAt(i));
                }

            }
            else
            {
                MessageBox.Show(msg, titulo, boton);
            }
        }

    

        private void nuevaT_Click(object sender, RoutedEventArgs e)
        {
            String msg = "no se pueden abrir mas de 20 colecciones";
            if (modelo.devolverColecciones().Count <= 20)
            {
                //creo una coleccion
                //la añado a la coleccion de colecciones de puntos
                ObservableCollection<Point> Tabla = new ObservableCollection<Point>();
                modelo.añadirTabla(Tabla);
                //inicializo la ventana secundaria pasandole el parametro necesario
                datos = new Window1(Tabla);
                datos.Owner = this;
                datos.Show();
            }
            else
            {
                MessageBox.Show(msg, titulo, boton);
            }
        }

        private void ModificarTablas_Click(object sender, RoutedEventArgs e)
        {
            //ObservableCollection<Point> Tabla = new ObservableCollection<Point>();
            //Tabla = colecciones.ElementAt<ObservableCollection<Point>>(listaColecciones.SelectedIndex);
            //Tabla = (ObservableCollection<Point>)listaColecciones.SelectedValue;
            //datos = new Window1(Tabla);
            datos = new Window1((ObservableCollection<Point>)listaColecciones.SelectedValue);
            datos.Show();
        }



        public void cambiarColorOscuro()
        {
            
                App a = App.Current as App;
                var dict = new ResourceDictionary() { Source = new Uri("nuevoModoOscuro.xaml",UriKind.Relative) };

            //al darle valor utilizando diccionarios de recursos se queda "congelado"
            //empieza como deberia pero al cambiar de color no aplica lo que dicta el diccionario nuevo

            //por si no convence, se puede llegar a un estado similar pero sin el toolBox en distinto color
            //para ello hay que descomentar en el diccionario de oscuro la parte correspondiente al dock panel
            Color clor = Color.FromRgb(40, 41, 35);
            SolidColorBrush brocha = new SolidColorBrush(clor);
            miDockPanel.Background = brocha;
            a.Resources.MergedDictionaries.Clear();
            a.Resources.MergedDictionaries.Add(dict);
            
        }
        
        public void cambiarColorClaro()
        {
            App a = App.Current as App;
            var dict = new ResourceDictionary() { Source = new Uri("temaClaro.xaml", UriKind.Relative) };
            /*foreach(var mergeDict in dict.MergedDictionaries)
            {
                a.Resources.MergedDictionaries.Add(mergeDict);
            }

            foreach(var key in dict.Keys)
            {
                a.Resources[key] = dict[key];
            }*/
            miDockPanel.Background = Brushes.White;
            a.Resources.MergedDictionaries.Clear();
            a.Resources.MergedDictionaries.Add(dict);

        }

        private void BorrarTablas_Click(object sender, RoutedEventArgs e)
        {
            modelo.quitarTabla((ObservableCollection<Point>)listaColecciones.SelectedValue);
           // listaColecciones.Items.Remove(listaColecciones.SelectedItem);
        }

        /*+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
         * 
         * Aqui viene la zona de los botones de los colores
         * 
         *********************************************************************************************/

        private void botonLineaRojo_Click(object sender, RoutedEventArgs e)
        {
            Brush color = Brushes.Red;
            cambiarColorLinea(color);
        }

        private void botonLineaAmarillo_Click(object sender, RoutedEventArgs e)
        {
            Brush color = Brushes.Yellow;
            cambiarColorLinea(color);
        }

        private void botonLineaAzul_Click(object sender, RoutedEventArgs e)
        {
            Brush color = Brushes.Blue;
            cambiarColorLinea(color);
        }

        private void BotonLineaVerde_Click(object sender, RoutedEventArgs e)
        {
            Brush color = Brushes.Green;
            cambiarColorLinea(color);
        }

        private void BotonLineaNegra_Click(object sender, RoutedEventArgs e)
        {
            Brush color = Brushes.Black;
            cambiarColorLinea(color);
        }

        private void cambiarColorLinea(Brush color)
        {
            if (!lienzo.Children.Equals(null))
            {
                foreach (Shape value in lienzo.Children)
                {
                    value.Fill = color;
                    value.Stroke = color;
                }
            }
        }

       


        //representar grafica de barras
        private void GraficaBarras_Click(object sender, RoutedEventArgs e)
        {
            graficaDeBarras();
        }


        /*+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        * 
        * Aqui viene la zona de los trazos
        * 
        *********************************************************************************************/

        private void cambiarTrazoLinea(PenLineCap var)
        {
            if (!lienzo.Children.Equals(null))
            {
                foreach (Shape value in lienzo.Children)
                {
                    value.StrokeEndLineCap = var;
                }
            }
        }

        private void Trazo_Click(object sender, RoutedEventArgs e)
        {
            //trazo puntiagudo
            PenLineCap var = PenLineCap.Triangle;
            cambiarTrazoLinea(var);
        }

        private void trazoRedondo_Click(object sender, RoutedEventArgs e)
        {
            PenLineCap var = PenLineCap.Round;
            cambiarTrazoLinea(var);
        }

        private void trazoPlano_Click(object sender, RoutedEventArgs e)
        {
            PenLineCap var = PenLineCap.Flat;
            cambiarTrazoLinea(var);
        }

        /*+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        * 
        * ACambiar color lienzo
        * 
        *********************************************************************************************/

        private void cambiarColorLienzo(Brush color)
        {
 
            lienzo.Background = color;
        }

        private void colorLienzoBlanco_Click(object sender, RoutedEventArgs e)
        {
            Brush var = Brushes.White;
            cambiarColorLienzo(var);
        }

        private void botonPolinomio_Click(object sender, RoutedEventArgs e)
        {
            /*ventanaDePrueba = new prueba();
            ventanaDePrueba.Owner = this;
            ventanaDePrueba.Show();*/


            String msg = "no se pueden abrir mas de 20 colecciones";
            if (modelo.devolverColecciones().Count <= 20)
            {
                //creo una coleccion
                //la añado a la coleccion de colecciones de puntos
                ObservableCollection<Point> Tabla = new ObservableCollection<Point>();
                modelo.añadirTabla(Tabla);
                //inicializo la ventana secundaria pasandole el parametro necesario
                cuadroPolinomio = new polinomioVentana(Tabla);
                cuadroPolinomio.Owner = this;
                cuadroPolinomio.Show();
            }
            else
            {
                MessageBox.Show(msg, titulo, boton);
            }
        }
        /*+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        * 
        * purgado de lienzo
        * 
        *********************************************************************************************/


        private void botonBorrarColecciones_Click(object sender, RoutedEventArgs e)
        {
            modelo.limpiarTablas();
        }

        private void lienzo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (seleccionActiva)
            {
                rectangulo = new Rectangle();
                //rectangulo.Name = "selectionBox";
                rectangulo.Visibility = Visibility.Collapsed;
                rectangulo.Stroke = Brushes.Red;
                rectangulo.StrokeThickness = 1;
                lienzo.Children.Add(rectangulo);

                mouseDown = true;
                posicionRaton = e.GetPosition(lienzo);
                lienzo.CaptureMouse();

                Canvas.SetLeft(selectionBox, posicionRaton.X);
                Canvas.SetTop(selectionBox, posicionRaton.Y);
                selectionBox.Width = 0;
                selectionBox.Height = 0;

                Canvas.SetLeft(rectangulo, posicionRaton.X);
                Canvas.SetTop(rectangulo, posicionRaton.Y);
                rectangulo.Width = 0;
                rectangulo.Height = 0;


                selectionBox.Visibility = Visibility.Visible;
                rectangulo.Visibility = Visibility.Visible;
            }
        }
        private void lienzo_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (seleccionActiva)
            {
                List<Point> puntosMantener = new List<Point>();
                mouseDown = false;
                lienzo.ReleaseMouseCapture();

                selectionBox.Visibility = Visibility.Collapsed;

                rectangulo.Visibility = Visibility.Collapsed;

                Point posicionMouseUp = e.GetPosition(lienzo);

                //codigo de ver si hay algo en la seleccion

                if (lienzo.Children.Contains(polilinea))
                {
                    foreach (Point punto in polilinea.Points)
                    {
                        if ((punto.X < posicionMouseUp.X && punto.X > posicionRaton.X) && (punto.Y < posicionRaton.Y && punto.Y > posicionMouseUp.Y))
                        {
                            puntosMantener.Add(punto);
                        }
                        else
                        {

                        }
                    }
                    if(listaColecciones.SelectedItem != null)
                    {

                    }


                    polilinea.Points.Clear();
                    foreach (Point var in puntosMantener)
                    {
                        polilinea.Points.Add(var);
                    }
                }
            }
        }
        private void lienzo_MouseMove(object sender, MouseEventArgs e)
        {
            if (seleccionActiva)
            {
                if (mouseDown)
                {
                    Point mousePos = e.GetPosition(lienzo);

                    if (posicionRaton.X < mousePos.X)
                    {
                        Canvas.SetLeft(selectionBox, posicionRaton.X);
                        selectionBox.Width = mousePos.X - posicionRaton.X;

                        Canvas.SetLeft(rectangulo, posicionRaton.X);
                        rectangulo.Width = mousePos.X - posicionRaton.X;
                    }
                    else
                    {
                        Canvas.SetLeft(selectionBox, mousePos.X);
                        selectionBox.Width = posicionRaton.X - mousePos.X;

                        Canvas.SetLeft(rectangulo, mousePos.X);
                        rectangulo.Width = posicionRaton.X - mousePos.X;
                    }

                    if (posicionRaton.Y < mousePos.Y)
                    {
                        Canvas.SetTop(selectionBox, posicionRaton.Y);
                        selectionBox.Height = mousePos.Y - posicionRaton.Y;

                        Canvas.SetTop(rectangulo, posicionRaton.Y);
                        rectangulo.Height = mousePos.Y - posicionRaton.Y;
                    }
                    else
                    {
                        Canvas.SetTop(rectangulo, mousePos.Y);
                        rectangulo.Height = posicionRaton.Y - mousePos.Y;
                    }
                }
            }
        }


        private void botonSeleccion_Checked(object sender, RoutedEventArgs e)
        {
            seleccionActiva = true;
        }

        private void botonSeleccion_Unchecked(object sender, RoutedEventArgs e)
        {
            seleccionActiva = false;
        }

        //si hay una tabla seleccionada sobreescribe la informacion del canvas a la pantalla
        private void sobreescribirTabla_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Point> sobreescribir = new ObservableCollection<Point>();
            String msg;
            if(listaColecciones.SelectedItem != null)
            {
                sobreescribir = (ObservableCollection<Point>)listaColecciones.SelectedValue;
                sobreescribir.Clear();
                if (lienzo.Children.Contains(polilinea))
                {
                    foreach(Point value in polilinea.Points)
                    {
                        sobreescribir.Add(value);
                    }
                }
            }
            else
            {
                //cuadrodedialogo
                msg = "has de seleccionar una coleccion antes para poder sobreescribirla";
                MessageBox .Show(msg);
            }
        }

        /*+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        * 
        * checkBox linea punteada
        * 
        *********************************************************************************************/


        private void punteada_Checked(object sender, RoutedEventArgs e)
        {
            polilinea.StrokeDashArray = new DoubleCollection() { 2,2 };
        }

        private void punteada_Unchecked(object sender, RoutedEventArgs e)
        {
            polilinea.StrokeDashArray = null;

        }


       
    }


}
